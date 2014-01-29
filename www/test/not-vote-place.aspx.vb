
Partial Class test_nearby_search
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim tmp As New UW.Template(Server.MapPath("/html/test/not-vote-place.html"))
        tmp.ReplaceString("{Not_Vote_Count}", UW.SQL.GetSingleIntWithDefault("(select count(*) from temp_place where vote is null)"))
        Response.Write(tmp.Result)
    End Sub
End Class
