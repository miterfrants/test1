
Partial Class controller_member
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If UW.WU.IsNonEmptyFromQueryStringOrForm("action") Then
            Select Case UW.WU.GetValueFromQueryStringOrForm("action")
                Case "fb-login"
                    If Sign.IsLogin Then
                        Response.Redirect("from_url")
                    End If
                    fbLogin()
                Case "google-login"
                    googleLogin()
                Case "twitter-request-token"
                    twitterRequestToken()
                Case "twitter-login"
                    twitterLogin()
                Case "logout"
                    Sign.Logout()
                    If Request.UrlReferrer Is Nothing Then
                        Response.Redirect("/")
                    Else
                        Response.Redirect(Request.UrlReferrer.AbsoluteUri)
                    End If
                Case "ajax-logout"
                    Sign.Logout()
                    Response.Write(UW.JSON.JSONString(True, ""))
            End Select
        Else
            Response.End()
        End If
    End Sub

    Sub googleLogin()
        Dim accessToken As Google.OAuth2.AccessToken = UW.JSON.jsonToObject(Google.OAuth2.getAccessToken(UW.WU.GetValueFromQueryStringOrForm("code")), GetType(Google.OAuth2.AccessToken))
        'access token 都放在Cookie就好了
        Response.Cookies(DB.SysConfig.COOKIE_KEY.GOOGLE_LOGIN_ACCESS_TOKEN_KEY).Value = accessToken.access_token
        Response.Cookies(DB.SysConfig.COOKIE_KEY.GOOGLE_LOGIN_ACCESS_TOKEN_KEY).Expires = Now.AddSeconds(accessToken.expires_in)
        Dim oUserInfo As Google.UserInfo = UW.JSON.jsonToObject(UW.WU.getRemotePage("https://www.googleapis.com/oauth2/v1/userinfo?access_token=" & accessToken.access_token), GetType(Google.UserInfo))
        '這邊如果讀到失敗的頁面要另外做處理 Peter Modify
        Dim loginResult As Sign.UserLoginReturnCode = Google.loginOrReg(oUserInfo)
        '如果登入成功了就到原本登入的頁面 Peter Modify
        If loginResult = Sign.UserLoginReturnCode.Success Then
            Response.Redirect("/")
        Else
            Response.Write("登入失敗:" & loginResult.ToString())
        End If

    End Sub

    Sub twitterLogin()
        Dim accessTokenResult As String = Twitter.oAuth1dot1.accessToken(UW.WU.GetValueFromQueryStringOrForm("oauth_verifier"), UW.WU.GetValueFromQueryStringOrForm("oauth_token"), Session("twitter_token_scret"))
        Dim arr As String() = accessTokenResult.Split("&")
        Dim screenName As String = ""
        Dim userId As String = ""
        Dim accessToken As String = ""
        Dim accessTokenSecret As String = ""
        For i As Int32 = 0 To arr.Length - 1
            Dim key As String = arr(i).Split("=")(0)
            Dim value As String = arr(i).Split("=")(1)
            If key = "screen_name" Then
                screenName = value
            ElseIf key = "user_id" Then
                userId = value
            ElseIf key = "oauth_token" Then
                accessToken = value
            ElseIf key = "oauth_token_secret" Then
                accessTokenSecret = value
            End If
        Next
        Dim userShow As Twitter.API1dot1.UserShow = UW.JSON.jsonToObject(Twitter.API1dot1.getUserShow(screenName, accessToken, accessTokenSecret), GetType(Twitter.API1dot1.UserShow))
        '完成授權去要資料囉。
        Dim loginResult As Sign.UserLoginReturnCode = Twitter.loginOrReg(userShow)
        If loginResult = Sign.UserLoginReturnCode.Success Then
            '這個要去改登入前的網址。 Peter Modify
            Response.Redirect("/")
        Else
            Response.Write("登入失敗:" & loginResult.ToString())
        End If
    End Sub
    Sub twitterRequestToken()
        Dim callback As String = Request.Url.Scheme & "://" & DB.SysConfig.URL.Domain & "/" & DB.SysConfig.URL.Controller & "/" & DB.SysConfig.URL.API_MEMBER_TWITTER_LOGIN
        Dim arrToken As String() = Twitter.oAuth1dot1.requestToken(callback).Split("&")
        Dim accessToken As String = ""
        Dim accessTokenSecret As String = ""
        For i As Int32 = 0 To arrToken.Length - 1
            Dim tokenKey As String = arrToken(i).Split("=")(0)
            Dim tokenvalue As String = arrToken(i).Split("=")(1)
            If tokenKey = "oauth_token" Then
                accessToken = tokenvalue
            ElseIf tokenKey = "oauth_token_secret" Then
                accessTokenSecret = tokenvalue
            End If
        Next
        '這個現在還用不到之後在來 Implement
        Session("twitter_token_scret") = accessTokenSecret
        Response.Redirect(Twitter.oAuth1dot1.urlRedirectOAuth & "?oauth_token=" & accessToken)
    End Sub

    Sub fbLogin()
        Dim appId As String = DB.SysConfig.FB.FB_LOGIN_APP_ID
        Dim appPermission As String = DB.SysConfig.FB.FB_LOGIN_PERMISSION
        Dim code As String = UW.WU.GetValueFromQueryStringOrForm("code")
        Dim appSecret As String = DB.SysConfig.Secret.FB_LOGIN_APP_SECRET
        'FB_LOGIN_FAIL_COUNT 這個KEY 不知道要不要用 DB 來管理，要不然怕哪一次用同樣的名字 Session 的 key 都用DB 的SYS.config 來管理好了。
        If UW.WU.GetValueFromQueryStringOrForm("plus") = "clear-fb-login-fail" Then
            Session(DB.SysConfig.SESSION_KEY.FB_LOGIN_FAIL_COUNT_KEY) = 0
        End If

        Dim fbFailRedirectCount As Int32 = Session(DB.SysConfig.SESSION_KEY.FB_LOGIN_FAIL_COUNT_KEY)
        'redirectURL 要跟  去facebook 要code 傳的 redirectURI 一樣 看起來是 fb 會拿redirectURL 當key 做hash
        Dim redirectURL As String = Request.Url.Scheme & "://" & DB.SysConfig.URL.Domain & "/" & DB.SysConfig.URL.Controller & "/" & DB.SysConfig.URL.API_MEMBER_FB_LOGIN
        Dim accessTokenResult As String = FB.getAccessToken(appId, appSecret, code, redirectURL, True)
        '如果傳回來沒有錯誤，應該就不會有 error code 不過這個要實驗一下還有study Graph Error 
        Dim oAE As FB.oAuthError = Nothing
        Try
            oAE = UW.JSON.jsonToObject(accessTokenResult.Replace("error", "errors"), GetType(FB.oAuthError))
        Catch ex As Exception
        End Try

        If oAE Is Nothing Then
            Dim arrAuth As String() = accessTokenResult.Split("&")
            Dim accessToekn As String = ""
            Dim expires As DateTime = Now()
            For i As Int32 = 0 To arrAuth.Length - 1
                Dim key As String = arrAuth(i).Split("=")(0)
                Dim value As String = arrAuth(i).Split("=")(1)
                If key = "access_token" Then
                    accessToekn = value
                ElseIf key = "expires" Then
                    expires = Now.AddMilliseconds(CType(value, Int32))
                End If
            Next
            Response.Cookies(DB.SysConfig.GetSysConfig("FB_LOGIN_ACCESS_TOKEN_KEY")).Value = accessToekn
            Response.Cookies(DB.SysConfig.GetSysConfig("FB_LOGIN_ACCESS_TOKEN_KEY")).Expires = expires
            Session(DB.SysConfig.GetSysConfig("FB_LOGIN_FAIL_COUNT_KEY")) = 0
            '完成授權去要資料囉。
            Dim loginResult As Sign.UserLoginReturnCode = FB.loginAndReg(appId, appPermission, redirectURL, accessToekn)
            If loginResult = Sign.UserLoginReturnCode.Success Then
                '這個要去改登入前的網址。 Peter Modify
                Response.Redirect("/")
            Else
                Response.Write("登入失敗:" & loginResult.ToString())
            End If
        ElseIf oAE.errors.code = "100" Then
            'code =100 expired
            If fbFailRedirectCount >= 3 Then
                '發生錯誤的時候 應該要在這頁把錯誤頁面寫出來，最好是有統一的錯誤頁面和統一的錯誤回報機制 Peter Modify
                Response.Write("FB 已經傳回超過三次的登入失敗，請使用其他方式登入。")
                Exit Sub
            End If
            Session(DB.SysConfig.GetSysConfig("FB_LOGIN_FAIL_COUNT_KEY")) = fbFailRedirectCount + 1
            Response.Redirect(FB.getOAuthURL(DB.SysConfig.GetSysConfig("FB_LOGIN_APP_ID"), DB.SysConfig.GetSysConfig("FB_LOGIN_PERMISSION"), redirectURL))
        Else
            Response.Write("FB回傳錯誤代碼:" & oAE.errors.code & "，我們將在最快的時間內與您聯繫。")
        End If
    End Sub
End Class
