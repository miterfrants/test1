
Partial Class test_insert_place_v2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Sign.IsLogin Then
            Dim tmp As New UW.Template(Server.MapPath("/html/test/insert-place-v2.html"))
            tmp.ReplaceString("{Profile_Img}", Sign.Member.getProfilePicture())
            tmp.ReplaceString("{EXP}", Sign.Member.exp)
            Response.Write(tmp.Result)
        End If

    End Sub
End Class
