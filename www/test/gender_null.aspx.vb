Imports System.Net
Partial Class test_gender_null
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim oM As New DB.Member(1)
        Response.Write(oM.en_gender)
    End Sub
End Class
