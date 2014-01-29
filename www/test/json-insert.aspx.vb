
Partial Class test_json_insert
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim tmp As New UW.Template(Server.MapPath("/html/test/json-insert.html"))
        Response.Write(tmp.Result)
    End Sub
End Class
