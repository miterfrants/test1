
Partial Class controller_temp_place
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If UW.WU.IsNonEmptyFromQueryStringOrForm("action") Then
            Select Case UW.WU.GetValueFromQueryStringOrForm("action")
                Case "is_exist"
                    If Not UW.WU.IsNonEmptyFromQueryStringOrForm("google_id") Then
                        Response.Write(UW.JSON.JSONString(False, ""))
                        Response.End()
                    End If
                    Dim oTemp As New DB.TempPlace()
                    oTemp.google_id = UW.WU.GetValueFromQueryStringOrForm("google_id")
                    oTemp = oTemp.GetDataRowAndReturnSelfOrNothing()
                    If oTemp IsNot Nothing Then
                        Response.Write(UW.JSON.JSONString(True, ""))
                    Else
                        Response.Write(UW.JSON.JSONString(False, ""))
                    End If
                Case "vote"
                    Dim oTP As New DB.TempPlace(UW.WU.GetIntFromQueryStringOrForm("id"))
                    Dim oJ As New UW.JSON(True, "")
                    If oTP.vote = 0 Then
                        oTP.vote = UW.WU.GetValueFromQueryStringOrForm("vote")
                        oTP.Update()
                    Else
                        oJ.success = False
                        oJ.msg = "你的票被別人搶先了。"
                    End If
                    oJ.WriteToClient()
                Case "get"
                    Dim sql As String = ""
                    If UW.WU.IsNonEmptyFromQueryStringOrForm("id") AndAlso UW.WU.GetValueFromQueryStringOrForm("id") <> -1 Then
                        sql &= "select top 1 * from temp_place where vote is null and id<" & UW.WU.GetValueFromQueryStringOrForm("id").Replace("'", "''") & " order by id desc"
                    Else
                        sql &= "select top 1 * from temp_place where vote is null order by id desc"
                    End If
                    Dim dt As DataTable = UW.SQL.DTFromSQL(sql)
                    If dt IsNot Nothing Then
                        Dim oTP As New DB.TempPlace(dt.Rows(0))
                        Dim oJ As New UW.JSON(True, "")
                        For Each key As String In oTP.htTypeDefinesForRecord.Keys
                            If oTP.row(key) Is DBNull.Value Then
                                oJ.add(key, "")
                            Else
                                oJ.add(key, oTP.row(key))
                            End If
                        Next
                        If oTP.google_description.Length > 0 Then
                            oJ.add("desc", oTP.google_description)
                        End If
                        If oTP.fb_description.Length > 0 Then
                            oJ.add("desc", oTP.fb_description)
                        End If
                        If Not oJ.htb.ContainsKey("desc") Then
                            oJ.add("desc", "")
                        End If
                        oJ.add("types", getTypes(UW.WU.GetIntFromQueryStringOrForm("id")))
                        oJ.WriteToClient()
                    Else
                        Response.Write(UW.JSON.JSONString(False, "IN 弘恭喜你破關了。"))
                    End If
                Case "insert"

                    Dim Conn As SqlConnection = UW.SQL.GetOpenedConnection
                    Dim Tran As SqlTransaction = Conn.BeginTransaction
                    Dim msg As String = ""
                    Try
                        Dim oTemp As New DB.TempPlace()
                        UW.FormUtil.setRecordFromForm(oTemp)
                        Dim tempId As Int32 = oTemp.Insert(Tran)
                        Dim dicCategory As Dictionary(Of String, DB.Category) = DB.Category.getDicCategory()
                        Dim types As String = UW.WU.GetValueFromQueryStringOrForm("types")
                        If types.Length > 0 Then
                            Dim arrTypes As String() = types.Split(",")
                            For i As Int32 = 0 To arrTypes.Length - 1
                                If dicCategory.ContainsKey(arrTypes(i)) Then
                                    Dim oPC As New DB.PlaceAndCate
                                    oPC.cate_id = dicCategory(arrTypes(i)).Id
                                    oPC.place_id = tempId
                                    oPC.Insert(Tran)
                                End If
                            Next
                        End If

                        Tran.Commit()
                    Catch ex As Exception
                        Tran.Rollback()
                        'UW.WU.DebugWriteLine(ex.ToString, True, True)
                        msg = ex.ToString()

                    Finally
                        If Conn.State <> ConnectionState.Closed Then
                            Conn.Close()
                        End If

                    End Try
                    If msg.Length > 0 Then
                        Response.Write(UW.JSON.JSONString(False, msg))
                    Else
                        Response.Write(UW.JSON.JSONString(True, ""))
                    End If

            End Select
            Response.End()
        End If
    End Sub
    Function getTypes(ByVal id As Int32) As String
        Dim sql As String = "select zh_name from category where id in (select cate_id from place_and_cate where place_id = " & id & ")"
        Dim dt As DataTable = UW.SQL.DTFromSQL(sql)
        Dim result As String = ""
        If dt IsNot Nothing Then
            For i As Int32 = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("zh_name") IsNot DBNull.Value Then
                    result &= dt.Rows(i)("zh_name") & ","
                End If
            Next
        End If
        If result.EndsWith(",") Then
            result = result.Substring(0, result.Length - 1)
        End If
        Return result
    End Function
End Class
