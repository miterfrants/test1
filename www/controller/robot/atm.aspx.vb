
Partial Class test_atm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If UW.WU.GetValueFromQueryStringOrForm("pw") <> DB.SysConfig.GetSysConfig("ROBOT_PW") Then
            Exit Sub
        End If
        If UW.WU.IsNonEmptyFromQueryStringOrForm("action") Then
            Select Case UW.WU.GetValueFromQueryStringOrForm("action")
                Case "get-711"
                    get711()
                    'every week
                Case "get-family"
                    getFamily()
                Case "update-711-diff-geometry"
                    updateDiffGeometry(DB.AtmPlace.EN.type.統一中國信託)
                Case "update-family-diff-geometry"
                    updateDiffGeometry(DB.AtmPlace.EN.type.全家台新)
                Case "update-zero-geometry"
                    updateZeroGeometry()
                Case "update-geography"
                    updateGeography()
            End Select
        End If
    End Sub
    Sub updateGeography()
        Dim sql As String = "update atm_place set geo_location = geography::Point(latitude,longitude,4326) where latitude>0 and longitude>0"
        UW.SQL.executeSQL(sql)
    End Sub
    Sub getFamily()
        UW.SQL.executeSQL("delete temp_atm_place where en_type=" & DB.AtmPlace.EN.type.全家台新)
        Dim url As String = "https://www.taishinbank.com.tw/cs/groups/public/documents/document/atmajax.jsp?city="
        Dim html As New HtmlAgilityPack.HtmlDocument()
        Response.Buffer = False
        html.LoadHtml(UW.WU.getRemotePage(url))
        Dim options As HtmlAgilityPack.HtmlNodeCollection = html.DocumentNode.SelectNodes("//option")
        '抓資料的網址
        url = "https://www.taishinbank.com.tw/TS/TS12/TS1202/index.htm?pageNum={page}&inputvalue1={city}"
        Dim page As Int32 = 1
        For i As Int32 = 0 To options.Count - 1
            '第一頁先抓分頁頁碼。
            Dim iniPageString As String = UW.WU.getRemotePage(url.Replace("{page}", page).Replace("{city}", options.Item(i).Attributes("value").Value))
            Response.Write("initial page : " + url.Replace("{page}", page).Replace("{city}", options.Item(i).Attributes("value").Value) & "<br/>")
            Response.Flush()
            Dim iniPageHtml As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument()
            iniPageHtml.LoadHtml(iniPageString)
            '第一頁ATM 列表
            Dim list As HtmlAgilityPack.HtmlNodeCollection = iniPageHtml.DocumentNode.SelectNodes("//table[@class='table01']/tr")
            For j As Int32 = 1 To list.Count - 1
                If list(j).SelectSingleNode("td[1]").InnerHtml.IndexOf("全家") > -1 OrElse list(j).SelectSingleNode("td[1]").InnerHtml.IndexOf("OK") > -1 Then
                    Dim oTempAP As New DB.TempAtmPlace()
                    oTempAP.en_type = DB.TempAtmPlace.EN.type.全家台新
                    oTempAP.name = list(j).SelectSingleNode("td[1]").InnerHtml
                    oTempAP.address = list(j).SelectSingleNode("td[2]").InnerText
                    oTempAP.update_date = Now()
                    oTempAP.msg = "暫存資料"
                    Response.Write(oTempAP.name & ":" & oTempAP.address & "<br/>")
                    Response.Flush()
                    oTempAP.Insert()
                End If
            Next


            Dim node As HtmlAgilityPack.HtmlNode = iniPageHtml.DocumentNode.SelectSingleNode("//div[@class='nblist']/a[@class='current']/following-sibling::a[1]")
            Dim whileCount As Int32 = 0
            While node.InnerHtml <> "下一頁" AndAlso whileCount < 1000
                Dim PageString As String = UW.WU.getRemotePage(url.Replace("{page}", node.InnerHtml).Replace("{city}", options.Item(i).Attributes("value").Value))
                Response.Write("second:" + url.Replace("{page}", CInt(node.InnerHtml)).Replace("{city}", options.Item(i).Attributes("value").Value) & "<br/>")
                Response.Flush()
                Dim pageHtml As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument()
                pageHtml.LoadHtml(PageString)
                list = pageHtml.DocumentNode.SelectNodes("//table[@class='table01']/tr")
                For k As Int32 = 1 To list.Count - 1
                    If list(k).SelectSingleNode("td[1]").InnerHtml.IndexOf("全家") > -1 OrElse list(k).SelectSingleNode("td[1]").InnerHtml.IndexOf("OK") > -1 Then
                        Dim oTempAP As New DB.TempAtmPlace()
                        oTempAP.en_type = DB.TempAtmPlace.EN.type.全家台新
                        oTempAP.name = list(k).SelectSingleNode("td[1]").InnerHtml
                        oTempAP.address = list(k).SelectSingleNode("td[2]").InnerText
                        oTempAP.update_date = Now()
                        oTempAP.msg = "暫存資料"
                        Response.Write(oTempAP.name & ":" & oTempAP.address & "<br/>")
                        Response.Flush()
                        oTempAP.Insert()
                    End If
                Next
                node = pageHtml.DocumentNode.SelectSingleNode("//div[@class='nblist']/a[@class='current']/following-sibling::a[1]")
                whileCount += 1
            End While
            

            'Response.Write(options.Item(i).Attributes("value").Value & ":" & nodes.Count - 2 & "<br/>")
            'Response.Write(options.Item(i).Attributes("value").Value)
        Next


    End Sub
    Sub updateZeroGeometry()
        Dim dtZero As DataTable = UW.SQL.DTFromSQL("select top 2500 * from atm_place where latitude=0 and longitude=0")
        If dtZero IsNot Nothing Then
            For i As Int32 = 0 To dtZero.Rows.Count - 1
                Dim oAtmPlace As New DB.AtmPlace(dtZero.Rows(i))
                setAtmPlaceFromGoogle(oAtmPlace)
                Response.Write(oAtmPlace.msg & "<br/>")
                Response.Flush()
                oAtmPlace.Update()
            Next
        End If
        updateGeography()
    End Sub
    Shared threadSleepingTime As Int32 = 300
    Shared overRequestCount As Int32 = 0
    Sub setAtmPlaceFromGoogle(ByRef oAtmPlace As DB.AtmPlace)
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


    ''' <summary>
    ''' 每天資料更新，只抓差異資料做更新動作。
    ''' </summary>
    ''' <param name="enType"></param>
    ''' <remarks></remarks>
    Sub updateDiffGeometry(ByVal enType As DB.AtmPlace.EN.type)
        '把暫存的和正式的抓出來比較一次。
        '正式資料沒有暫存的資料就做下面這個BLOCK
        Dim dtDiff As DataTable = UW.SQL.DTFromSQL("select * from temp_atm_place where en_type=" & enType & " and name not in (select name from atm_place where en_type=" & enType & ")")
        If dtDiff IsNot Nothing Then
            For i As Int32 = 0 To dtDiff.Rows.Count - 1
                Dim oTempAtmPlace As New DB.TempAtmPlace(dtDiff(i))
                Dim oAtmPlace As New DB.AtmPlace()
                oAtmPlace.address = oTempAtmPlace.address
                oAtmPlace.name = oTempAtmPlace.name
                oAtmPlace.en_type = enType
                setAtmPlaceFromGoogle(oAtmPlace)
                oAtmPlace.Insert()
                Response.Write(oAtmPlace.msg & "<br/>")
                Response.Flush()
            Next
        End If
        '正式資料有但是Temp沒有待刪除資料，跑三次沒有就自動刪除，第二次寄Email 給管理者，第一次註記。
        Dim dtDelete As DataTable = UW.SQL.DTFromSQL("select * from atm_place where en_type=" & enType & " and name not in (select name from temp_atm_place where en_type=" & enType & ")")
        If dtDelete IsNot Nothing Then
            For i As Int32 = 0 To dtDelete.Rows.Count - 1
                Dim oAtmPlace As New DB.AtmPlace(dtDelete.Rows(i))
                oAtmPlace.deleted_count = oAtmPlace.deleted_count + 1
                oAtmPlace.Update()
            Next
        End If
        updateGeography()
    End Sub


    Sub get711()
        UW.SQL.executeSQL("delete temp_atm_place where en_type=" & DB.AtmPlace.EN.type.統一中國信託)
        Dim cookiesContainer As New System.Net.CookieContainer()
        Dim header As New Dictionary(Of String, String)
        header.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8")
        header.Add("Accept-Encoding", "gzip,deflate,sdch")
        header.Add("Accept-Language", "zh-TW,zh;q=0.8,en-US;q=0.6,en;q=0.4")
        header.Add("Cache-Control", "max-age=0")
        header.Add("Connection", "keep-alive")
        header.Add("Host", "consumer.chinatrust.com.tw")
        header.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36")
        header.Add("Referer", "https://consumer.chinatrust.com.tw/CTCBPortalWeb/appmanager/ebank/rb?_nfpb=true&_pageLabel=TW_RB_CM_ebank_022001&_windowLabel=T31000267011286792822875&_nffvid=%2FCTCBPortalWeb%2Fpages%2FserviceLocation%2FbranchLocation.faces&firstView=true")
        header.Add("Origin", "https://consumer.chinatrust.com.tw")
        Dim index As Int32 = 2
        If Session("test_atm_index") IsNot Nothing AndAlso Not UW.WU.IsNonEmptyFromQueryStringOrForm("clear_session") Then
            index = CInt(Session("test_atm_index"))
        End If
        Dim html As HtmlAgilityPack.HtmlDocument = initialAtmPage(cookiesContainer, header)
        Response.Write("index:00<br/>")
        get711Data(html)
        For i As Int32 = index To 25
            If i = 10 OrElse i = 17 OrElse i = 19 Then
                Continue For
            End If
            html = getSecondAtmPage(html, cookiesContainer, header, i.ToString("00"))
            Response.Write("index:" & i & "<br/>")
            Response.Flush()
            get711Data(html)
            Response.Write("<br/><br/>")
            Session("test_atm_index") = i
        Next
    End Sub

    Sub get711Data(ByVal html As HtmlAgilityPack.HtmlDocument)
        'Dim mainTable As HtmlAgilityPack.HtmlNode = html.DocumentNode.SelectSingleNode("//table[@id='mainTable']")
        Dim mainTestTr As HtmlAgilityPack.HtmlNodeCollection = html.DocumentNode.SelectNodes("//table[@id='mainTable']/tr[not(@class)='tdtitle01']")
        Try
            If mainTestTr IsNot Nothing Then
                For i As Int32 = 0 To mainTestTr.Count - 1
                    Dim mainTr As HtmlAgilityPack.HtmlNode = html.DocumentNode.SelectSingleNode("//table[@id='mainTable']/tr[not(@class)='tdtitle01'][" & i + 1 & "]")
                    Dim atmTitle As String = mainTr.SelectSingleNode("td[1]/a").InnerHtml.Replace("&nbsp;", "")
                    If atmTitle.IndexOf("統一") > -1 Then
                        Dim address As String = mainTr.SelectSingleNode("td[2]/p").InnerHtml
                        Dim rec As New DB.TempAtmPlace()
                        rec.name = atmTitle
                        rec.address = address
                        rec.update_date = Now()
                        rec.en_type = DB.TempAtmPlace.EN.type.統一中國信託
                        rec.msg = "暫存資料"
                        rec.Insert()
                        Response.Write(atmTitle & "<br/>")
                        Response.Buffer = False
                        Response.Flush()
                        'Threading.Thread.Sleep(300)
                    End If
                Next
            End If
        Catch ex As Exception
            Throw New Exception("發生錯誤:" & ex.ToString() & html.DocumentNode.OuterHtml)
        End Try
    End Sub

    Function getSecondAtmPage(ByVal firstPage As HtmlAgilityPack.HtmlDocument, cookiesContainer As System.Net.CookieContainer, ByVal header As Dictionary(Of String, String), ByVal masterIndex As String) As HtmlAgilityPack.HtmlDocument
        Dim url As String = "https://consumer.chinatrust.com.tw/CTCBPortalWeb/appmanager/ebank/rb?_nfpb=true&_windowLabel=T31000267011286792822875&_nffvid=%2FCTCBPortalWeb%2Fpages%2FserviceLocation%2FatmLocation.faces&_pageLabel=TW_RB_CM_ebank_022001"
        Dim postData As New Dictionary(Of String, String)
        postData.Add("locationRadio", "radio")
        postData.Add("serviceLocationForm:master", masterIndex)
        postData.Add("serviceLocationForm:child", "default_select_value")
        postData.Add("serviceLocationForm:master:hiddenValue:", "")
        postData.Add("serviceLocationForm:child:hiddenValue", "default_select_value@|@請選擇$@$116@|@文山區$@$114@|@內湖區$@$115@|@南港區$@$112@|@北投區$@$110@|@信義區$@$108@|@萬華區$@$111@|@士林區$@$106@|@大安區$@$105@|@松山區$@$104@|@中山區$@$103@|@大同區$@$100@|@中正區")
        postData.Add("serviceLocationForm:doSearch", "查詢")
        postData.Add("form_city", "02")
        postData.Add("form_town", "")
        postData.Add("form_isFirst", "false")
        postData.Add("errorWording", "無法正確取得google地圖的對應位置")
        postData.Add("serviceLocationForm", "serviceLocationForm")
        postData.Add("javax.faces.ViewState", firstPage.DocumentNode.SelectSingleNode("//input[@id='javax.faces.ViewState']").GetAttributeValue("value", ""))
        postData.Add("ineb_check_back_id", firstPage.DocumentNode.SelectSingleNode("//input[@id='ineb_check_back_id']").GetAttributeValue("value", ""))
        Dim tmp As String = UW.WU.getRemotePage(url, header, "POST", postData, cookiesContainer)
        Dim html As New HtmlAgilityPack.HtmlDocument()
        html.LoadHtml(tmp)
        Return html
    End Function

    Function initialAtmPage(ByRef cookiesContainer As System.Net.CookieContainer, ByVal header As Dictionary(Of String, String)) As HtmlAgilityPack.HtmlDocument
        Dim url As String = "https://consumer.chinatrust.com.tw/CTCBPortalWeb/appmanager/ebank/rb?_nfpb=true&_windowLabel=T31000267011286792822875&_nffvid=%2FCTCBPortalWeb%2Fpages%2FserviceLocation%2FbranchLocation.faces&_pageLabel=TW_RB_CM_ebank_022001"
        Dim commonPage As String = UW.WU.getRemotePage(url, Nothing, "GET", Nothing, cookiesContainer)
        Dim htmlCommon As New HtmlAgilityPack.HtmlDocument()
        htmlCommon.LoadHtml(commonPage)
        url = "https://consumer.chinatrust.com.tw/CTCBPortalWeb/appmanager/ebank/rb?_nfpb=true&_windowLabel=T31000267011286792822875&_nffvid=%2FCTCBPortalWeb%2Fpages%2FserviceLocation%2FatmLocation.faces&_pageLabel=TW_RB_CM_ebank_022001"
        Dim postData As New Dictionary(Of String, String)
        postData.Add("locationRadio", "radio")
        postData.Add("serviceLocationForm:master", "01")
        postData.Add("serviceLocationForm:child", "default_select_value")
        postData.Add("serviceLocationForm:master:hiddenValue:", "")
        postData.Add("serviceLocationForm:child:hiddenValue", "default_select_value@|@請選擇$@$116@|@文山區$@$114@|@內湖區$@$115@|@南港區$@$112@|@北投區$@$110@|@信義區$@$108@|@萬華區$@$111@|@士林區$@$106@|@大安區$@$105@|@松山區$@$104@|@中山區$@$103@|@大同區$@$100@|@中正區")
        postData.Add("serviceLocationForm:go2atm_target", "")
        'postData.Add("serviceLocationForm:doSearch", "查詢")
        postData.Add("form_city", "default_select_value")
        postData.Add("form_town", "")
        postData.Add("form_isFirst", "true")
        postData.Add("errorWording", "無法正確取得google地圖的對應位置")
        postData.Add("serviceLocationForm", "serviceLocationForm")
        postData.Add("javax.faces.ViewState", htmlCommon.DocumentNode.SelectSingleNode("//input[@id='javax.faces.ViewState']").GetAttributeValue("value", ""))
        postData.Add("ineb_check_back_id", htmlCommon.DocumentNode.SelectSingleNode("//input[@id='ineb_check_back_id']").GetAttributeValue("value", ""))
        Dim tmp As String = UW.WU.getRemotePage(url, header, "POST", postData, cookiesContainer)
        'For Each key As System.Net.Cookie In cookiesContainer.GetCookies(New Uri(url))
        '    Response.Write(key.Name & ":" & key.Value & "<br/>")
        'Next
        Dim html As New HtmlAgilityPack.HtmlDocument()
        html.LoadHtml(tmp)
        Return html

    End Function

End Class
