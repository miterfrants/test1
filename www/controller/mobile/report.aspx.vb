
Partial Class controller_mobile_report
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If UW.WU.IsNonEmptyFromQueryStringOrForm("action") Then
            Dim oJ As New UW.JSON(True, "")
            Select Case UW.WU.GetValueFromQueryStringOrForm("action")
                Case "add-category-count"
                    Try
                        Dim oMobileCateCount As New DB.MobileReportCategoryClick()
                        oMobileCateCount.creator_ip = UW.WU.GetValueFromQueryStringOrForm("creator_ip")
                        oMobileCateCount.category = UW.WU.GetValueFromQueryStringOrForm("cate")
                        oMobileCateCount.Insert()
                    Catch ex As Exception
                        oJ.success = False
                        oJ.msg = ex.Message()
                    End Try

                Case "add-pull-down"
                    Try
                        Dim oMobileCateCount As New DB.MobileReportPullDownCount()
                        oMobileCateCount.creator_ip = UW.WU.GetValueFromQueryStringOrForm("creator_ip")
                        oMobileCateCount.category = UW.WU.GetValueFromQueryStringOrForm("cate")
                        oMobileCateCount.Insert()
                    Catch ex As Exception
                        oJ.success = False
                        oJ.msg = ex.Message()
                    End Try
                Case "add-pull-up"
                    Try
                        Dim oMombilePullUp As New DB.MobileReportPullUpToGetNextPage()
                        oMombilePullUp.creator_ip = UW.WU.GetValueFromQueryStringOrForm("creator_ip")
                        oMombilePullUp.category = UW.WU.GetValueFromQueryStringOrForm("cate")
                        oMombilePullUp.Insert()
                    Catch ex As Exception
                        oJ.success = False
                        oJ.msg = ex.Message()
                    End Try
                Case "add-app-use-long"
                    Try
                        Dim oMombileAppUseLong As New DB.MobileReportAppUseLong()
                        oMombileAppUseLong.creator_ip = UW.WU.GetValueFromQueryStringOrForm("creator_ip")
                        oMombileAppUseLong.launch_date = UW.WU.GetValueFromQueryStringOrForm("launch_date")
                        oMombileAppUseLong.exit_date = UW.WU.GetValueFromQueryStringOrForm("exit_date")
                        oMombileAppUseLong.Insert()
                    Catch ex As Exception
                        oJ.success = False
                        oJ.msg = ex.Message()
                    End Try
            End Select
            oJ.WriteToClient()
            Response.End()
        End If
    End Sub


End Class
