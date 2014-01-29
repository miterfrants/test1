
Partial Class controller_mobile_place
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If UW.WU.IsNonEmptyFromQueryStringOrForm("action") Then
            Select Case UW.WU.GetValueFromQueryStringOrForm("action")
                Case "vote"
                    vote()
                Case "get"
                    getPlaceVote()
                Case "get-atm"
                    getAtm()
                Case "get-gas"
                    getGas()
                Case "get-rental"
                    getRental()
            End Select
        End If
    End Sub

    Sub getRental()
        Dim lat As Decimal = CDec(UW.WU.GetValueFromQueryStringOrForm("lat"))
        Dim lng As Decimal = CDec(UW.WU.GetValueFromQueryStringOrForm("lng"))
        Dim list As List(Of DB.RentalPlace) = Nothing
        If lat <> 0 AndAlso lng <> 0 Then
            list = DB.RentalPlace.getPlaceInRadius(1000, lat, lng)
        End If

        Dim result As New StringBuilder()
        result.Append("{")
        result.Append("""results"":[")

        For i As Int32 = 0 To list.Count - 1
            result.Append("{""geometry"":{""location"":{""lat"":" & list(i).latitude & ",""lng"":" & list(i).longitude & "}},""name"":""" & UW.WU.jsonEncode(list(i).name) & """,""rating"":0,""types"":[""atm""],""vicinity"":""" & UW.WU.jsonEncode(list(i).address) & """}")
            If i < list.Count - 1 Then
                result.Append(",")
            End If
        Next
        If list.Count > 0 Then
            result.Append("],""status"":""OK""}")
        Else
            result.Append("],""status"":""ZERO_RESULTS""}")
        End If
        Response.Write(result.ToString())
    End Sub

    Sub getAtm()
        Dim lat As Decimal = CDec(UW.WU.GetValueFromQueryStringOrForm("lat"))
        Dim lng As Decimal = CDec(UW.WU.GetValueFromQueryStringOrForm("lng"))
        Dim list As List(Of DB.AtmPlace) = Nothing
        If lat <> 0 AndAlso lng <> 0 Then
            list = DB.AtmPlace.getPlaceInRadius(1000, lat, lng)
        End If

        Dim result As New StringBuilder()
        result.Append("{")
        result.Append("""results"":[")

        For i As Int32 = 0 To list.Count - 1
            result.Append("{""geometry"":{""location"":{""lat"":" & list(i).latitude & ",""lng"":" & list(i).longitude & "}},""name"":""" & UW.WU.jsonEncode(list(i).name) & """,""rating"":0,""types"":[""atm""],""vicinity"":""" & UW.WU.jsonEncode(list(i).address) & """}")
            If i < list.Count - 1 Then
                result.Append(",")
            End If
        Next
        If list.Count > 0 Then
            result.Append("],""status"":""OK""}")
        Else
            result.Append("],""status"":""ZERO_RESULTS""}")
        End If
        Response.Write(result.ToString())
    End Sub
    Sub getGas()
        Dim lat As Decimal = CDec(UW.WU.GetValueFromQueryStringOrForm("lat"))
        Dim lng As Decimal = CDec(UW.WU.GetValueFromQueryStringOrForm("lng"))
        Dim list As List(Of DB.GasStationPlace) = Nothing
        If lat <> 0 AndAlso lng <> 0 Then
            list = DB.GasStationPlace.getPlaceInRadius(1000, lat, lng)
        End If

        Dim result As New StringBuilder()
        result.Append("{")
        result.Append("""results"":[")

        For i As Int32 = 0 To list.Count - 1
            result.Append("{""geometry"":{""location"":{""lat"":" & list(i).latitude & ",""lng"":" & list(i).longitude & "}},""name"":""" & UW.WU.jsonEncode(list(i).name) & """,""rating"":0,""types"":[""atm""],""vicinity"":""" & UW.WU.jsonEncode(list(i).address) & """}")
            If i < list.Count - 1 Then
                result.Append(",")
            End If
        Next
        If list.Count > 0 Then
            result.Append("],""status"":""OK""}")
        Else
            result.Append("],""status"":""ZERO_RESULTS""}")
        End If

        Response.Write(result.ToString())
    End Sub

    Sub getPlaceVote()
        Dim oVote As New DB.Vote
        oVote.member_id = UW.WU.GetValueFromQueryStringOrForm("member_id")
        oVote.google_id = UW.WU.GetValueFromQueryStringOrForm("google_id")
        oVote = oVote.GetDataRowAndReturnSelfOrNothing()
        Dim oJ As New UW.JSON(True, "")
        If oVote Is Nothing Then
            oJ.success = False
            oJ.msg = "Nothing"
        Else
            oJ.success = True
            oJ.msg = ""
            oJ.add("rating", oVote.rating)
            oJ.add("comment", oVote.comment)
        End If
        oJ.WriteToClient()
    End Sub
    Sub vote()
        Dim msg As String = ""
        If UW.WU.GetValueFromQueryStringOrForm("member_id") = 0 Then
            Response.Write(UW.JSON.JSONString(False, "User not found!"))
            Response.End()
        End If
        Dim oJ As New UW.JSON(True, "")
        Try
            Dim oTP As New DB.TempPlace()
            oTP.google_id = UW.WU.GetValueFromQueryStringOrForm("google_id")
            oTP = oTP.GetDataRowAndReturnSelfOrNothing()
            If oTP Is Nothing Then
                oTP = New DB.TempPlace()
                oTP.google_id = UW.WU.GetValueFromQueryStringOrForm("google_id")
                oTP.latitude = UW.WU.GetValueFromQueryStringOrForm("lat")
                oTP.longitude = UW.WU.GetValueFromQueryStringOrForm("lng")
                oTP.google_reference = UW.WU.GetValueFromQueryStringOrForm("google_reference")
                oTP.google_address = UW.WU.GetValueFromQueryStringOrForm("google_address")
                oTP.google_phone = UW.WU.GetValueFromQueryStringOrForm("google_phone")
                oTP.name = UW.WU.GetValueFromQueryStringOrForm("google_name")
                oTP = New DB.TempPlace(oTP.Insert())
            End If

            Dim oVote As New DB.Vote()
            oVote.member_id = UW.WU.GetValueFromQueryStringOrForm("member_id")
            oVote.place_id = oTP.Id
            oVote = oVote.GetDataRowAndReturnSelfOrNothing()
            If oVote Is Nothing Then
                oVote = New DB.Vote()
                oVote.member_id = UW.WU.GetValueFromQueryStringOrForm("member_id")
                oVote.place_id = oTP.Id
                oVote.rating = UW.WU.GetValueFromQueryStringOrForm("rating")
                oVote.comment = UW.WU.GetValueFromQueryStringOrForm("comment")
                oVote.Insert()
            Else
                oVote.comment = UW.WU.GetValueFromQueryStringOrForm("comment")
                oVote.rating = UW.WU.GetValueFromQueryStringOrForm("rating")
                oVote.Update()
            End If
            Dim drawLotGoods As DB.Goods = DB.DrawlotRate.drawLot(UW.WU.GetValueFromQueryStringOrForm("google_name"), Now(), UW.WU.GetValueFromQueryStringOrForm("member_id"))
            If drawLotGoods IsNot Nothing Then
                oJ.add("goods_name", drawLotGoods.name)
                oJ.add("goods_desc", drawLotGoods.description)
                oJ.add("goods_pic", drawLotGoods.pic)
            End If
            
        Catch ex As Exception
            oJ.success = False
            oJ.msg = ex.ToString()
        End Try
        oJ.WriteToClient()
        
        Response.End()
    End Sub
End Class
