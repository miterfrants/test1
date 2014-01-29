
Partial Class test_test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        For i As Int32 = 0 To Request.Form.Count - 1
            Response.Write(Request.Form.Keys(i) & "=" & Request.Form(i) & "</br>")
        Next
        Dim cookie As New HttpCookie("a", "b")
        cookie.Expires = Now()
        cookie.Domain = "www.planb-on.com"
        cookie.Path = "/"
        cookie.HttpOnly = True
        Response.SetCookie(cookie)
    End Sub
End Class
