
Partial Class controller_spider
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If UW.WU.IsNonEmptyFromQueryStringOrForm("action") Then
            Select Case UW.WU.GetValueFromQueryStringOrForm("action")
                Case "insert_place"
                    InsertPlace()
                Case "update_place"

            End Select
        End If
    End Sub
    Sub InsertPlace()
        Dim oP As New DB.Place()
        Dim oJ As New UW.JSON(True, "")
        oP.google_id = UW.WU.GetValueFromQueryStringOrForm("id")
        oP = oP.GetDataRowAndReturnSelfOrNothing()
        If oP IsNot Nothing Then
            UW.SQL.executeSQL("update pre_data set check_count=check_count+1 where id=" & UW.WU.GetIntFromQueryStringOrForm("pre_data_id"))
            Sign.Member.addExp("place_check")
            oJ.success = False
            oJ.msg = "已經新增過此筆資料"
            oJ.add("status", "warning")
            oJ.add("exp", Sign.Member.exp)
            oJ.WriteToClient()
            Response.End()
        End If

        oP = New DB.Place()
        oP.pre_data_id = UW.WU.GetValueFromQueryStringOrForm("pre_data_id")
        oP = oP.GetDataRowAndReturnSelfOrNothing()
        If oP IsNot Nothing Then
            UW.SQL.executeSQL("update pre_data set check_count=check_count+1 where id=" & UW.WU.GetIntFromQueryStringOrForm("pre_data_id"))
            Sign.Member.addExp("place_ignore")
            oJ.success = False
            oJ.msg = "已經新增過此筆資料"
            oJ.add("status", "warning")
            oJ.add("exp", Sign.Member.exp)
            oJ.WriteToClient()
            Response.End()
        End If

        oP = New DB.Place()
        oP.address = UW.WU.GetValueFromQueryStringOrForm("address")
        oP.longitude = UW.WU.GetValueFromQueryStringOrForm("pos").Split(",")(1)
        oP.latitude = UW.WU.GetValueFromQueryStringOrForm("pos").Split(",")(0)
        oP.name = UW.WU.GetValueFromQueryStringOrForm("name")
        oP.description = UW.WU.GetValueFromQueryStringOrForm("desc")
        If UW.WU.GetValueFromQueryStringOrForm("desc").Length > 0 Then
            Sign.Member.addExp("place_des")
        End If
        oP.reference = UW.WU.GetValueFromQueryStringOrForm("ref")
        oP.google_id = UW.WU.GetValueFromQueryStringOrForm("id")
        oP.pre_data_id = UW.WU.GetValueFromQueryStringOrForm("pre_data_id")
        If UW.WU.GetValueFromQueryStringOrForm("rating").Length > 0 Then
            oP.rating = UW.WU.GetValueFromQueryStringOrForm("rating")
            If oP.rating > 4 Then
                Sign.Member.addExp("place_rating4")
            Else
                Sign.Member.addExp("place_rating")
            End If
        End If
        Dim dicCate As Dictionary(Of String, DB.Category) = DB.Category.getDicCategory
        If UW.WU.GetValueFromQueryStringOrForm("main_cate").Length > 0 Then
            If dicCate.ContainsKey(UW.WU.GetValueFromQueryStringOrForm("main_cate")) Then
                Dim oCate As DB.Category = dicCate(UW.WU.GetValueFromQueryStringOrForm("main_cate"))
                oP.main_cate_id = oCate.Id
                If oCate.cate_trav_id > 0 Then
                    Sign.Member.addExp("place_right_cate")
                End If
            End If
        End If

        oP.Insert()
        Sign.Member.addExp("place_new")
        UW.SQL.executeSQL("update pre_data set check_count=check_count+1 where id=" & UW.WU.GetIntFromQueryStringOrForm("pre_data_id"))
        oJ.add("exp", Sign.Member.exp)
        oJ.WriteToClient()
        Response.End()
    End Sub
End Class
