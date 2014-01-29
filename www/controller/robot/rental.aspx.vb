
Partial Class controller_robot_rental
    Inherits System.Web.UI.Page


    Sub updateDiff(ByVal enType As DB.RentalPlace.EN.type)
        '把暫存的和正式的抓出來比較一次。
        '正式資料沒有暫存的資料就做下面這個BLOCK
        Dim dtDiff As DataTable = UW.SQL.DTFromSQL("select * from temp_rental_place where en_type=" & enType & " and name not in (select name from rental_place where en_type=" & enType & ")")
        If dtDiff IsNot Nothing Then
            For i As Int32 = 0 To dtDiff.Rows.Count - 1
                Dim oTempPlace As New DB.TempRentalPlace(dtDiff(i))
                Dim oPlace As New DB.RentalPlace()
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
        Dim dtDelete As DataTable = UW.SQL.DTFromSQL("select * from rental_place where en_type=" & enType & " and name not in (select name from temp_rental_place where en_type=" & enType & ")")
        If dtDelete IsNot Nothing Then
            For i As Int32 = 0 To dtDelete.Rows.Count - 1
                Dim oRentalPlace As New DB.RentalPlace(dtDelete.Rows(i))
                oRentalPlace.deleted_count = oRentalPlace.deleted_count + 1
                oRentalPlace.Update()
            Next
        End If
        updateGeography()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If UW.WU.GetValueFromQueryStringOrForm("pw") <> DB.SysConfig.GetSysConfig("ROBOT_PW") Then
            Exit Sub
        End If
        If UW.WU.IsNonEmptyFromQueryStringOrForm("action") Then
            Select Case UW.WU.GetValueFromQueryStringOrForm("action")
                Case "update-diff"
                    updateDiff(DB.RentalPlace.EN.type.汽車)
                    updateDiff(DB.RentalPlace.EN.type.機車)
                    updateDiff(DB.RentalPlace.EN.type.自行車)
            End Select
        End If
    End Sub

    Shared threadSleepingTime As Int32 = 300
    Shared overRequestCount As Int32 = 0
    Sub setPlaceFromGoogle(ByRef oPlace As DB.RentalPlace)
        Threading.Thread.Sleep(threadSleepingTime)
        Dim convertToLat As String = "http://maps.googleapis.com/maps/api/geocode/json?address=" & oPlace.address & "&sensor=false&language=zh_TW"
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
                msg = oPlace.name & ":" & ob.results(0).formatted_address & ":(" & ob.results(0).geometry.location.lat & "," & ob.results(0).geometry.location.lng & ")"
            Else
                'UW.Mail.SendMail("miterfrants@gmail.com", "spider@planb-on.com", "地址轉經緯度失敗", address)
                msg = oPlace.name & ":google 未回傳資料"
            End If
        Catch ex As Exception
            If locationJSON.IndexOf("OVER_QUERY_LIMIT") > -1 Then

                If overRequestCount > 3 Then
                    threadSleepingTime = 0
                Else
                    overRequestCount += 1
                End If
                msg = oPlace.name & ":超過google 最大的Request"
            Else
                msg = oPlace.name & ":其他錯誤:" & locationJSON
            End If
        End Try
        If address.Length > 0 Then
            oPlace.address = address
        End If
        oPlace.latitude = lat
        oPlace.longitude = lng
        oPlace.msg = msg
    End Sub

    Sub updateGeography()
        Dim sql As String = "update rental_place set geo_location = geography::Point(latitude,longitude,4326) where latitude>0 and longitude>0"
        UW.SQL.executeSQL(sql)
    End Sub

End Class
