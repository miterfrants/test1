
Partial Class controller_spider
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If UW.WU.IsNonEmptyFromQueryStringOrForm("action") Then
            Select Case UW.WU.GetValueFromQueryStringOrForm("action")
                Case "insert_json"
                    Dim oPD As New DB.PreData
                    oPD.name = UW.WU.GetValueFromQueryStringOrForm("name")
                    oPD.area_name = UW.WU.GetValueFromQueryStringOrForm("area_name")
                    oPD = oPD.GetDataRowAndReturnSelfOrNothing()
                    If oPD IsNot Nothing Then
                        Response.Write(UW.JSON.JSONString(False, "此筆資料已經存在。"))
                        Response.End()
                    End If
                    oPD = New DB.PreData()
                    oPD.name = UW.WU.GetValueFromQueryStringOrForm("name")
                    oPD.description = UW.WU.GetValueFromQueryStringOrForm("description")
                    oPD.area_name = UW.WU.GetValueFromQueryStringOrForm("area_name")
                    If UW.WU.IsNonEmptyFromQueryStringOrForm("latitude") Then
                        oPD.latitude = UW.WU.GetValueFromQueryStringOrForm("latitude")
                    End If
                    If UW.WU.IsNonEmptyFromQueryStringOrForm("longitude") Then
                        oPD.longitude = UW.WU.GetValueFromQueryStringOrForm("longitude")
                    End If

                    oPD.Insert()
                    Response.Write(UW.JSON.JSONString(True, ""))
                    Response.End()
                Case "get_pre_data"
                    Dim oJ As New UW.JSON(True, "")
                    Dim oPD As New DB.PreData()
                    Dim dt As New DataTable()
                    Dim preDt As New DataTable()
                    Dim cri As String = " and ignore_count<(select avg(Cast(ignore_count as Float))*1.7 from pre_data ) and check_count <= (select top 1 check_count from pre_data group by check_count order by count(*) desc)"
                    If Not UW.WU.IsNonEmptyFromQueryStringOrForm("id") OrElse UW.WU.GetValueFromQueryStringOrForm("id") = "0" Then
                        dt = oPD.GetQueryDT(, , cri, "id", , "top 2")
                        preDt = UW.SQL.DTFromSQL("select top 1 * from pre_data where 1=1 " & cri & " order by id desc ")
                    Else
                        If UW.WU.GetValueFromQueryStringOrForm("is_next") = "true" Then
                            dt = oPD.GetQueryDT(, , "id>=" & UW.WU.GetValueFromQueryStringOrForm("id") & cri, "id", , "top 2")
                            preDt = UW.SQL.DTFromSQL("select top 1 * from pre_data where id <" & CInt(UW.WU.GetValueFromQueryStringOrForm("id")) & cri & " order by id desc")
                        Else
                            dt = oPD.GetQueryDT(, , "id>=" & UW.WU.GetValueFromQueryStringOrForm("pre_id") & cri, "id", , "top 2")
                            preDt = UW.SQL.DTFromSQL("select top 1 * from pre_data where id < " & CInt(UW.WU.GetValueFromQueryStringOrForm("pre_id")) & cri & " order by id desc")
                        End If
                    End If
                    If dt Is Nothing Then
                        oJ.success = False
                        oJ.msg = "id>=" & UW.WU.GetValueFromQueryStringOrForm("id") & "此條件下沒有資料"
                        oJ.WriteToClient()
                        Response.End()
                    Else
                        If dt.Rows(0)("name") Is DBNull.Value Then
                            oJ.success = False
                            oJ.msg = "id=" & UW.WU.GetValueFromQueryStringOrForm("id") & " 此筆資料沒有名稱"
                            oJ.add("next_id", dt.Rows(1)("id"))
                            oJ.WriteToClient()
                            Response.End()
                        End If

                        If dt.Rows(0)("latitude") Is DBNull.Value OrElse dt.Rows(0)("longitude") Is DBNull.Value Then
                            oJ.msg = "id=" & UW.WU.GetValueFromQueryStringOrForm("id") & " 此筆資料沒有經緯度"
                            oJ.add("coordinates", ",")
                        Else
                            oJ.add("coordinates", dt.Rows(0)("latitude") & "," & dt.Rows(0)("longitude"))
                        End If
                        oJ.add("name", dt.Rows(0)("name"))
                        oJ.add("id", dt.Rows(0)("id"))
                        oJ.add("description", dt.Rows(0)("description"))
                        If dt.Rows.Count = 1 Then
                            Dim dtFirst As DataTable = UW.SQL.DTFromSQL("select top 1 * from pre_data where 1=1 " & cri & " order by id")
                            oJ.add("next_id", dtFirst.Rows(0)("id"))
                        Else
                            oJ.add("next_id", dt.Rows(1)("id"))
                        End If
                        If preDt Is Nothing OrElse preDt.Rows.Count = 0 Then
                            Dim dtLast As DataTable = UW.SQL.DTFromSQL("select top 1 * from pre_data where 1=1 " & cri & " order by id desc")
                            oJ.add("pre_id", dtLast.Rows(0)("id"))
                        Else
                            oJ.add("pre_id", preDt.Rows(0)("id"))
                        End If
                        
                        oJ.WriteToClient()
                        Response.End()
                    End If
                Case "ignore_place"
                    UW.SQL.executeSQL("update pre_data set ignore_count=ignore_count+1 where id=" & UW.WU.GetIntFromQueryStringOrForm("id"))
                    Sign.Member.addExp("place_ignore")
                    Dim oJ As New UW.JSON(True, "")
                    oJ.add("exp", Sign.Member.exp)
                    oJ.WriteToClient()
            End Select
        End If
    End Sub
End Class
