
Partial Class controller_robot_gas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If UW.WU.GetValueFromQueryStringOrForm("pw") <> DB.SysConfig.GetSysConfig("ROBOT_PW") Then
            Exit Sub
        End If
        If UW.WU.IsNonEmptyFromQueryStringOrForm("action") Then
            Select Case UW.WU.GetValueFromQueryStringOrForm("action")
                Case "get-smile"
                    getSmile()
                Case "get-allcountry"
                    getAllCountry()
                Case "get-nspco"
                    getNSPCO()
                Case "get-fpcc"
                    getFpcc()
                Case "get-chinese-oil"
                    getChineseoil()
                Case "update-diff"
                    Dim al As ArrayList = DB.GasStationPlace.AL.type
                    For i As Int32 = 0 To al.Count - 1
                        updateDiff(al(i))
                    Next
                Case "all"
                    getSmile()
                    getAllCountry()
                    getNSPCO()
                    getFpcc()
                    getChineseoil()
                    Dim al As ArrayList = DB.GasStationPlace.AL.type
                    For i As Int32 = 0 To al.Count - 1
                        updateDiff(al(i))
                    Next
                Case "update-zero-geometry"
                    updateZeroLocation()
                Case "update-geography"
                    updateGeography()
            End Select
        End If
    End Sub

    Sub updateZeroLocation()
        Dim dtZero As DataTable = UW.SQL.DTFromSQL("select top 2500 * from gas_station_place where latitude=0 and longitude=0")
        If dtZero IsNot Nothing Then
            For i As Int32 = 0 To dtZero.Rows.Count - 1
                Dim oPlace As New DB.GasStationPlace(dtZero.Rows(i))
                setPlaceFromGoogle(oPlace)
                Response.Write(oPlace.msg & "<br/>")
                Response.Flush()
                oPlace.Update()
            Next
        End If
        updateGeography()
    End Sub

    Sub updateDiff(ByVal enType As DB.GasStationPlace.EN.type)
        '把暫存的和正式的抓出來比較一次。
        '正式資料沒有暫存的資料就做下面這個BLOCK
        Dim dtDiff As DataTable = UW.SQL.DTFromSQL("select * from temp_gas_station_place where en_type=" & enType & " and name not in (select name from gas_station_place where en_type=" & enType & ")")
        If dtDiff IsNot Nothing Then
            For i As Int32 = 0 To dtDiff.Rows.Count - 1
                Dim oTempPlace As New DB.TempGasStationPlace(dtDiff(i))
                Dim oPlace As New DB.GasStationPlace()
                oPlace.address = oTempPlace.address
                oPlace.name = oTempPlace.name
                oPlace.en_type = enType
                setPlaceFromGoogle(oPlace)
                oPlace.Insert()
                Response.Write(oPlace.msg & "<br/>")
                Response.Flush()
            Next
        End If
        '正式資料有但是Temp沒有待刪除資料，跑三次沒有就自動刪除，第二次寄Email 給管理者，第一次註記。
        Dim dtDelete As DataTable = UW.SQL.DTFromSQL("select * from gas_station_place where en_type=" & enType & " and name not in (select name from temp_gas_station_place where en_type=" & enType & ")")
        If dtDelete IsNot Nothing Then
            For i As Int32 = 0 To dtDelete.Rows.Count - 1
                Dim oAtmPlace As New DB.AtmPlace(dtDelete.Rows(i))
                oAtmPlace.deleted_count = oAtmPlace.deleted_count + 1
                oAtmPlace.Update()
            Next
        End If
        updateGeography()
    End Sub

    Sub updateGeography()
        Dim sql As String = "update gas_station_place set geo_location = geography::Point(latitude,longitude,4326) where latitude>0 and longitude>0"
        UW.SQL.executeSQL(sql)
    End Sub

    Shared threadSleepingTime As Int32 = 300
    Shared overRequestCount As Int32 = 0
    Sub setPlaceFromGoogle(ByRef oAtmPlace As DB.GasStationPlace)
        Threading.Thread.Sleep(threadSleepingTime)
        Dim convertToLat As String = "http://maps.googleapis.com/maps/api/geocode/json?address=" & oAtmPlace.address & "&sensor=false&language=zh_TW"
        Dim dicHeader As New Dictionary(Of String, String)
        dicHeader.Add("Accept-Language", "zh-TW")
        Dim locationJSON As String = UW.WU.getRemotePage(convertToLat, dicHeader)
        Dim ob As Google.GeoCode = UW.JSON.jsonToObject(locationJSON, GetType(Google.GeoCode))
        Dim lat As Decimal = 0
        Dim lng As Decimal = 0
        Dim msg As String = ""
        Dim address As String = ""
        Try
            If ob IsNot Nothing AndAlso ob.results(0) IsNot Nothing Then
                lat = ob.results(0).geometry.location.lat
                lng = ob.results(0).geometry.location.lng
                address = ob.results(0).formatted_address
                msg = oAtmPlace.name & ":" & ob.results(0).formatted_address & ":(" & ob.results(0).geometry.location.lat & "," & ob.results(0).geometry.location.lng & ")"
            Else
                'UW.Mail.SendMail("miterfrants@gmail.com", "spider@planb-on.com", "地址轉經緯度失敗", address)
                msg = oAtmPlace.name & ":google 未回傳資料"
            End If
        Catch ex As Exception
            If locationJSON.IndexOf("OVER_QUERY_LIMIT") > -1 Then

                If overRequestCount > 3 Then
                    threadSleepingTime = 0
                Else
                    overRequestCount += 1
                End If
                msg = oAtmPlace.name & ":超過google 最大的Request"
            Else
                msg = oAtmPlace.name & ":其他錯誤:" & locationJSON
            End If
        End Try
        If address.Length > 0 Then
            oAtmPlace.address = address
        End If
        oAtmPlace.latitude = lat
        oAtmPlace.longitude = lng
        oAtmPlace.msg = msg
    End Sub

    Sub getFpcc()
        Response.Buffer = False
        UW.SQL.executeSQL("delete temp_gas_station_place where en_type=" & DB.GasStationPlace.EN.type.台塑化)
        Dim url As String = "http://www.fpcc.com.tw/station/allstation.htm"
        Dim pageString As String = UW.WU.getRemotePage(url, charset:="big5-hkscs")
        Dim html As New HtmlAgilityPack.HtmlDocument()
        html.LoadHtml(pageString)
        Dim tr As HtmlAgilityPack.HtmlNodeCollection = html.DocumentNode.SelectNodes("//table/tr")
        For i As Int32 = 2 To tr.Count - 2
            Dim oTempGas As New DB.TempGasStationPlace()
            oTempGas.name = tr(i).SelectSingleNode("td[2]").InnerText
            oTempGas.en_type = DB.TempGasStationPlace.EN.type.台塑化
            oTempGas.address = tr(i).SelectSingleNode("td[3]").InnerHtml & tr(i).SelectSingleNode("td[4]").InnerHtml & tr(i).SelectSingleNode("td[5]").InnerHtml
            oTempGas.msg = oTempGas.name & ":" & oTempGas.address & ":暫存資料。"
            oTempGas.Insert()
            Response.Write(oTempGas.msg & "<br/>")
            Response.Flush()
        Next
    End Sub

    Sub getNSPCO()
        Response.Buffer = False
        UW.SQL.executeSQL("delete temp_gas_station_place where en_type=" & DB.GasStationPlace.EN.type.北基加油站)
        Dim url As String = "http://www.nspco.com.tw/index.php?route=game/national"
        Dim pageString As String = UW.WU.getRemotePage(url)
        Dim html As New HtmlAgilityPack.HtmlDocument()
        html.LoadHtml(pageString)
        Dim tr As HtmlAgilityPack.HtmlNodeCollection = html.DocumentNode.SelectNodes("//table/tr")
        For i As Int32 = 2 To tr.Count - 1
            Dim oTempGas As New DB.TempGasStationPlace()
            oTempGas.name = tr(i).SelectSingleNode("td[1]/a").InnerHtml
            oTempGas.en_type = DB.TempGasStationPlace.EN.type.北基加油站
            oTempGas.address = tr(i).SelectSingleNode("td[2]").InnerHtml
            oTempGas.msg = oTempGas.name & ":" & oTempGas.address & ":暫存資料。"
            oTempGas.Insert()
            Response.Write(oTempGas.msg & "<br/>")
            Response.Flush()
        Next
    End Sub


    Sub getAllCountry()
        Response.Buffer = False
        UW.SQL.executeSQL("delete temp_gas_station_place where en_type=" & DB.GasStationPlace.EN.type.全國加油站)
        Dim url As String = "http://www.npcgas.com.tw/html/locations/index2.aspx?Page={page}&kind1={kide}"
        Dim iniPage As String = UW.WU.getRemotePage(url.Replace("{page}", 1).Replace("{kide}", 1))
        Dim iniHtml As New HtmlAgilityPack.HtmlDocument()
        iniHtml.LoadHtml(iniPage)
        Dim kide As HtmlAgilityPack.HtmlNodeCollection = iniHtml.DocumentNode.SelectNodes("//select[@name='lsearch_01$kind1']/option")
        getAllCountryMain(1, 1)
        For i As Int32 = 2 To kide.Count - 1
            getAllCountryMain(1, i)
        Next

    End Sub

    Sub getAllCountryMain(ByVal page As Int32, ByVal kide As Int32)
        Dim url As String = "http://www.npcgas.com.tw/html/locations/index2.aspx?Page={page}&kind1={kide}"
        Dim iniPage As String = UW.WU.getRemotePage(url.Replace("{page}", page).Replace("{kide}", kide))
        Dim iniHtml As New HtmlAgilityPack.HtmlDocument()
        iniHtml.LoadHtml(iniPage)
        Dim item As HtmlAgilityPack.HtmlNodeCollection = iniHtml.DocumentNode.SelectNodes("//body/table[1]/tr[1]/td[2]/table[1]/tr[4]/td[1]/table[1]/tr[2]/td[1]/table[1]/tr[1]/td[3]/table[1]/tr[2]/td[1]/table[1]/tr[4]/td[1]/table")
        For i As Int32 = 0 To item.Count - 1
            Dim oTempGas As New DB.TempGasStationPlace()
            oTempGas.name = item(i).SelectSingleNode("tr[1]/td[1]/table[1]/tr[1]/td[1]/a").InnerHtml
            oTempGas.en_type = DB.TempGasStationPlace.EN.type.全國加油站
            oTempGas.address = item(i).SelectSingleNode("tr[1]/td[1]/table[1]/tr[1]/td[2]").InnerHtml
            oTempGas.msg = oTempGas.name & ":" & oTempGas.address & ":暫存資料。"
            oTempGas.Insert()
            Response.Write(oTempGas.msg & "<br/>")
            Response.Flush()
        Next
        '第一個類別的分頁
        Dim paging As HtmlAgilityPack.HtmlNodeCollection = iniHtml.DocumentNode.SelectNodes("//select[@name='gopage']/option")
        For i As Int32 = 1 To paging.Count - 1
            Dim pageString As String = UW.WU.getRemotePage(url.Replace("{page}", paging(i).Attributes("value").Value).Replace("{kide}", kide))
            Dim html As New HtmlAgilityPack.HtmlDocument()
            html.LoadHtml(pageString)
            item = html.DocumentNode.SelectNodes("//body/table[1]/tr[1]/td[2]/table[1]/tr[4]/td[1]/table[1]/tr[2]/td[1]/table[1]/tr[1]/td[3]/table[1]/tr[2]/td[1]/table[1]/tr[4]/td[1]/table")
            For j As Int32 = 0 To item.Count - 1
                Dim oTempGas As New DB.TempGasStationPlace()
                oTempGas.name = item(j).SelectSingleNode("tr[1]/td[1]/table[1]/tr[1]/td[1]/a").InnerHtml
                oTempGas.en_type = DB.TempGasStationPlace.EN.type.全國加油站
                oTempGas.address = item(j).SelectSingleNode("tr[1]/td[1]/table[1]/tr[1]/td[2]").InnerHtml
                oTempGas.msg = oTempGas.name & ":" & oTempGas.address & ":暫存資料。"
                oTempGas.Insert()
                Response.Write(oTempGas.msg & "<br/>")
                Response.Flush()
            Next
        Next
    End Sub

    Sub getSmile()
        Response.Buffer = False
        UW.SQL.executeSQL("delete temp_gas_station_place where en_type=" & DB.GasStationPlace.EN.type.速邁樂)
        Dim iniPage As String = UW.WU.getRemotePage("http://www.mech-smile.com.tw/www/Stations/index.php?page=1")
        Dim iniHtml As New HtmlAgilityPack.HtmlDocument()
        iniHtml.LoadHtml(iniPage)
        Dim item As HtmlAgilityPack.HtmlNodeCollection = iniHtml.DocumentNode.SelectNodes("//table[@class='ListTableCss']/tr")
        For i As Int32 = 1 To item.Count - 2
            If i Mod 2 <> 0 Then
                Continue For
            End If
            Dim oTempGas As New DB.TempGasStationPlace()

            oTempGas.name = "速邁樂 " & item(i).SelectSingleNode("td[1]").InnerText.Replace("&nbsp;", "")
            oTempGas.en_type = DB.TempGasStationPlace.EN.type.速邁樂
            oTempGas.address = item(i).SelectSingleNode("td[2]").InnerText.Replace("&nbsp;", "")
            oTempGas.msg = oTempGas.name & ":" & oTempGas.address & ":暫存資料。"
            oTempGas.Insert()
            Response.Write(oTempGas.msg & "<br/>")
            Response.Flush()
        Next
        Dim pageOption As HtmlAgilityPack.HtmlNodeCollection = iniHtml.DocumentNode.SelectNodes("//select[@name='page']/option")
        For i As Int32 = 1 To pageOption.Count - 1
            Dim page As String = UW.WU.getRemotePage("http://www.mech-smile.com.tw/www/Stations/index.php?page=" & pageOption(i).Attributes("value").Value)
            Dim html As New HtmlAgilityPack.HtmlDocument()
            html.LoadHtml(page)
            item = html.DocumentNode.SelectNodes("//table[@class='ListTableCss']/tr")
            For j As Int32 = 1 To item.Count - 2
                If j Mod 2 <> 0 Then
                    Continue For
                End If
                Dim oTempGas As New DB.TempGasStationPlace()
                oTempGas.name = "速邁樂 " & item(j).SelectSingleNode("td[1]").InnerText.Replace("&nbsp;", "")
                oTempGas.en_type = DB.TempGasStationPlace.EN.type.速邁樂
                oTempGas.address = item(j).SelectSingleNode("td[2]").InnerText.Replace("&nbsp;", "")
                oTempGas.msg = oTempGas.name & ":" & oTempGas.address & ":暫存資料。"
                oTempGas.Insert()
                Response.Write(oTempGas.msg & "<br/>")
                Response.Flush()
            Next
        Next
    End Sub

    Sub getChineseoil()
        Response.Buffer = False
        UW.SQL.executeSQL("delete temp_gas_station_place where en_type=" & DB.GasStationPlace.EN.type.中油)
        Dim url As String = "http://www.cpc.com.tw/big5_bd/tmtd/station/gsearch-1.asp?pno=65"
        Dim charSet As String = "BIG5-HKSCS"
        Dim cookieContainer As New System.Net.CookieContainer()
        Dim iniPage As String = UW.WU.getRemotePage(url, charset:=charSet, cookies:=cookieContainer)
        Dim iniHtml As New HtmlAgilityPack.HtmlDocument()
        iniHtml.LoadHtml(iniPage)
        Dim input As HtmlAgilityPack.HtmlNodeCollection = iniHtml.DocumentNode.SelectNodes("//input[@name='type1']")

        For i As Int32 = 1 To input.Count - 1
            Dim postData As New Dictionary(Of String, String)
            postData.Add("pno", "65")
            postData.Add("city1", "全部縣市")
            postData.Add("search_button1", "查 詢")
            postData.Add("type1", input(i).Attributes("value").Value)
            postData.Add("C1", "")


            Dim searchURL As String = "http://www.cpc.com.tw/big5_bd/tmtd/station/searchstn-1.asp"

            Dim postIniPage As String = UW.WU.getRemotePage(searchURL, method:="POST", postData:=postData, charset:=charSet, cookies:=cookieContainer)
            Dim postIniHtml As New HtmlAgilityPack.HtmlDocument()
            postIniHtml.LoadHtml(postIniPage)
            Dim tr As HtmlAgilityPack.HtmlNodeCollection = postIniHtml.DocumentNode.SelectNodes("//table[@summary='加油站查詢欄位']/tbody/tr")

            For j As Int32 = 0 To tr.Count - 1
                Dim name As String = tr(j).SelectSingleNode("td[3]").InnerText & vbCrLf
                If name.IndexOf("站名") > -1 Then
                    Continue For
                End If
                If tr(j).SelectSingleNode("td[6]").InnerText.IndexOf("整修暫停營業") > -1 Then
                    Continue For
                End If
                Dim address As String
                If tr(j).SelectSingleNode("td[4]").InnerText.IndexOf("(") > -1 Then
                    address = tr(j).SelectSingleNode("td[1]").InnerText & tr(j).SelectSingleNode("td[2]").InnerText & tr(j).SelectSingleNode("td[4]").InnerText.Substring(0, tr(j).SelectSingleNode("td[4]").InnerText.IndexOf("("))
                Else
                    address = tr(j).SelectSingleNode("td[1]").InnerText & tr(j).SelectSingleNode("td[2]").InnerText & tr(j).SelectSingleNode("td[4]").InnerText
                End If

                Dim tempGas As New DB.TempGasStationPlace()
                tempGas.name = "中油" & input(i).Attributes("value").Value.Substring(0, 2) & " " & tr(j).SelectSingleNode("td[2]").InnerText & " " & name
                tempGas.address = address
                tempGas.msg = tempGas.name & ":" & tempGas.address.Trim() & ":暫存資料"
                tempGas.en_type = DB.TempGasStationPlace.EN.type.中油
                tempGas.Insert()
                Response.Write(tempGas.msg & "<br/>")
                Response.Flush()
            Next

        Next

    End Sub

    Function convertToEncode(ByVal data As String, ByVal oriEncode As String, ByVal desEncode As String) As String
        Dim big5Encoder As Encoding = Encoding.GetEncoding(oriEncode)
        Dim big5Bytes As Byte() = big5Encoder.GetBytes(data)

        Dim targetEncoer As Encoding = Encoding.GetEncoding(desEncode)
        Dim targetBytes As Byte() = Encoding.Convert(big5Encoder, targetEncoer, big5Bytes)
        Return targetEncoer.GetString(targetBytes)
    End Function

End Class
