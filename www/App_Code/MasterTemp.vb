Imports Microsoft.VisualBasic
Imports System
Public Class MasterTemp
    Inherits System.Web.UI.Page
    Public tmp As UW.Template = Nothing
    Public tmpMaster As UW.Template = New UW.Template(Server.MapPath("html/temp/master.html"))
    Public Sub iniTemp(ByVal file As String)
        tmp = New UW.Template(Server.MapPath(file))
    End Sub
    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        tmpMaster.replaceTag("content", tmp.getTagById("content").Result)
        tmpMaster.replaceHead(tmp)

        Dim currLang As String = DB.Lang.getLocalLang(Request.UserLanguages.ToList()(0))



        Dim redirectURL As String = Request.Url.Scheme & "://" & DB.SysConfig.URL.Domain & "/" & DB.SysConfig.URL.Controller & "/" & DB.SysConfig.URL.API_MEMBER_FB_LOGIN
        'Facebook Login
        tmpMaster.Result = tmpMaster.Result.Replace("{FB_LOGIN_URL}", FB.getOAuthURL(DB.SysConfig.GetSysConfig("FB_LOGIN_APP_ID"), DB.SysConfig.GetSysConfig("FB_LOGIN_PERMISSION"), redirectURL))
        'Twitter Login
        tmpMaster.Result = tmpMaster.Result.Replace("{TWITTER_LOGIN_URL}", "/" & DB.SysConfig.URL.Controller & "/" & DB.SysConfig.URL.API_MEMBER_TWITTER_REQUEST_TOKEN)
        'Google Login
        Dim googleParameter As New Google.OAuth2.OAuthParameter()
        googleParameter.clientId = DB.SysConfig.Google.GOOGLE_LOGIN_CLIENT_ID
        googleParameter.scope = DB.SysConfig.Google.GOOGLE_LOGIN_SCOPE
        googleParameter.redirectURI = Request.Url.Scheme & "://" & DB.SysConfig.URL.Domain & "/" & DB.SysConfig.URL.Controller & "/" & DB.SysConfig.URL.API_MEMBER_GOOGLE_LOGIN
        tmpMaster.Result = tmpMaster.Result.Replace("{GOOGLE_LOGIN_URL}", Google.OAuth2.getOAuth2URL(googleParameter))

        If Sign.IsLogin() Then
            tmpMaster.Result = tmpMaster.Result.Replace("{MEMBER_STATUS}", "login")
            tmpMaster.RemoveBlock("Unlogin")
            tmpMaster.ReplaceString("{Profile_Img}", Sign.Member.getProfilePicture())
            tmpMaster.ReplaceString("{EXP}", Sign.Member.exp)
            tmpMaster.RemoveBlock("Unlogin")
            If Sign.Member.lang_abbr.Length > 0 Then
                currLang = Sign.Member.lang_abbr
            Else
                currLang = currLang
            End If
        Else
            tmpMaster.ReplaceString("{Profile_Img}", "")
            tmpMaster.Result = tmpMaster.Result.Replace("{MEMBER_STATUS}", "unlogin")
            tmpMaster.RemoveBlock("Login")
        End If

        '換語言
        If Request.Cookies("lang") IsNot Nothing AndAlso Request.Cookies("lang").Value.Length > 0 Then
            currLang = Request.Cookies("lang").Value
        Else
            Response.Cookies("lang").Value = currLang
        End If
        Dim langDic As Dictionary(Of String, String) = DB.Text.getTextDic(currLang)
        If langDic.Count > 0 Then
            For Each key As String In langDic.Keys
                tmpMaster.ReplaceString("{" & key & "}", langDic(key))
            Next
        End If
        Response.Write(tmpMaster.Result)
    End Sub
End Class
