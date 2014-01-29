﻿<%@ Application Language="VB" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        UW.SQL.DBC = System.Configuration.ConfigurationManager.ConnectionStrings("DBC").ConnectionString
        UW.Mail.SMTP_SERVER_NAME="127.0.0.1"
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' 應用程式關閉時執行的程式碼
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' 發生未處理錯誤時執行的程式碼
        UW.WU.WriteErrorToLog(Server.GetLastError.InnerException, True)
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' 啟動新工作階段時執行的程式碼
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' 工作階段結束時執行的程式碼。 
        ' 注意: 只有在 Web.config 檔將 sessionstate 模式設定為 InProc 時，
        ' 才會引發 Session_End 事件。如果將工作階段模式設定為 StateServer 
        ' 或 SQLServer，就不會引發這個事件。
    End Sub
       
</script>