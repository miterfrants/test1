
Partial Class controller_mobile_ur_mub
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If UW.WU.IsNonEmptyFromQueryStringOrForm("action") Then
            Select Case UW.WU.GetValueFromQueryStringOrForm("action")
                Case "add"
                    Dim oJ As New UW.JSON(True, "")
                    Try
                        Dim oURMUB As New DB.URMUB()
                        oURMUB.cate = UW.WU.GetValueFromQueryStringOrForm("cate")
                        oURMUB.sex = UW.WU.GetValueFromQueryStringOrForm("sex")
                        oURMUB.device = UW.WU.GetValueFromQueryStringOrForm("device")
                        oURMUB.latitude = UW.WU.GetValueFromQueryStringOrForm("lat")
                        oURMUB.longitude = UW.WU.GetValueFromQueryStringOrForm("lon")
                        oURMUB.Insert()

                    Catch ex As Exception
                        oJ.msg = ex.Message()
                        oJ.success = False
                    End Try
                    oJ.WriteToClient()
            End Select
            Response.End()
        End If
    End Sub
End Class
