Imports Microsoft.VisualBasic
Imports System.Net
Public Class Twitter
    Public Class API1dot1
        Public Class UserShow
            Public id As String = ""
            Public id_str As String = ""
            Public name As String = ""
            Public sceen_name As String = ""
            Public location As String = ""
            Public description As String = ""
            Public url As String = ""
            Public created_at As String = ""
            Public lang As String = ""
            Public profile_image_url As String = ""
        End Class
        Public Shared urlUserShow As String = "https://api.twitter.com/1.1/users/show.json"
        Public Shared Function getUserShow(ByVal screenName As String, ByVal accessToken As String, ByVal accessTokenSecret As String) As String
            Dim uri As New Uri(urlUserShow & "?screen_name=" & screenName)
            Dim obAuth As New OAuth.OAuthBase()
            Dim nonce As String = obAuth.GenerateNonce()
            Dim httpMethod As String = "GET"
            Dim timestamp As String = obAuth.GenerateTimeStamp
            Dim custKey As String = DB.SysConfig.Twitter.TWITTER_LOGIN_OAUTH_CUSTOMER_KEY
            Dim custSecret As String = DB.SysConfig.Secret.TWITTER_LOGIN_OAUTH_CUSTOMER_SECRET
            Dim signature As String = obAuth.GenerateSignature(uri, custKey, custSecret, accessToken, accessTokenSecret, httpMethod, timestamp, nonce)
            Dim header As String = obAuth.generateHeader(obAuth.url, custKey, custSecret, accessTokenSecret, httpMethod, timestamp, nonce)
            Dim req As System.Net.WebRequest = System.Net.HttpWebRequest.Create(urlUserShow & "?screen_name=" & screenName)
            req.Method = httpMethod
            req.ContentType = "application/x-www-form-urlencoded"
            req.Headers.Add(header & ",oauth_signature=""" & OAuth.OAuthBase.UrlEncodeForShared(signature) & """")
            Try
                Dim sr As New IO.StreamReader(req.GetResponse().GetResponseStream())
                Dim content As String = sr.ReadToEnd()
                sr.Close()
                sr.Dispose()
                Return content
            Catch ex As Net.WebException
                Dim sr As New IO.StreamReader(ex.Response.GetResponseStream())
                Dim content As String = sr.ReadToEnd()
                sr.Close()
                sr.Dispose()
                Throw New Exception(req.RequestUri.AbsoluteUri & ":" & vbCrLf & vbCrLf & obAuth.baseString & vbCrLf & vbCrLf & req.Headers.Get("Authorization") & vbCrLf & vbCrLf & ex.ToString() & vbCrLf & vbCrLf & content)
            End Try
        End Function
    End Class
    Public Class oAuth1dot1
        Public Shared urlRequestToken As String = "https://api.twitter.com/oauth/request_token"
        Public Shared urlRedirectOAuth As String = "https://api.twitter.com/oauth/authenticate"
        Public Shared urlAccessToken As String = "https://api.twitter.com/oauth/access_token"
        Public Shared Function requestToken(ByVal callback As String) As String
            Dim custKey As String = DB.SysConfig.Twitter.TWITTER_LOGIN_OAUTH_CUSTOMER_KEY
            Dim custSecret As String = DB.SysConfig.Secret.TWITTER_LOGIN_OAUTH_CUSTOMER_SECRET
            Dim obAuth As New Global.OAuth.OAuthBase()
            Dim nonce As String = obAuth.GenerateNonce()
            Dim timestamp As String = obAuth.GenerateTimeStamp()
            Dim httpMethod As String = "POST"
            Dim accessToken As String = ""
            Dim tokenScret As String = ""
            Dim signature As String = obAuth.GenerateSignature(New Uri(urlRequestToken & "?oauth_callback=" & OAuth.OAuthBase.UrlEncodeForShared(callback)), custKey, custSecret, accessToken, tokenScret, httpMethod, timestamp, nonce)
            Dim header As String = obAuth.generateHeader(urlRequestToken, custKey, tokenScret, tokenScret, httpMethod, timestamp, nonce)
            Dim req As System.Net.WebRequest = System.Net.HttpWebRequest.Create(urlRequestToken)
            req.Method = httpMethod
            req.ContentType = "application/x-www-form-urlencoded"
            req.Headers.Add(header & ",oauth_signature=""" & OAuth.OAuthBase.UrlEncodeForShared(signature) & """")
            Try
                Dim sr As New IO.StreamReader(req.GetResponse().GetResponseStream())
                Dim content As String = sr.ReadToEnd()
                sr.Close()
                sr.Dispose()
                Return content
            Catch ex As WebException
                Throw New Exception(obAuth.url & ":" & vbCrLf & vbCrLf & obAuth.baseString & vbCrLf & vbCrLf & req.Headers.Get("Authorization") & vbCrLf & vbCrLf & ex.ToString())
            End Try
        End Function
        Public Shared Function accessToken(ByVal verifier As String, ByVal token As String, ByVal tokenSecret As String) As String
            Dim obAuth As New Global.OAuth.OAuthBase()
            Dim custKey As String = DB.SysConfig.Twitter.TWITTER_LOGIN_OAUTH_CUSTOMER_KEY
            Dim custSecret As String = DB.SysConfig.Secret.TWITTER_LOGIN_OAUTH_CUSTOMER_SECRET
            Dim nonce As String = obAuth.GenerateNonce()
            Dim timestamp As String = obAuth.GenerateTimeStamp()
            Dim httpMethod As String = "POST"
            Dim accessTokenSignature As String = obAuth.GenerateSignature(New Uri(urlAccessToken & "?oauth_verifier=" & verifier), custKey, custSecret, token, tokenSecret, httpMethod, timestamp, nonce)
            Dim accessTokenHeader As String = obAuth.generateHeader(obAuth.url, custKey, token, tokenSecret, httpMethod, timestamp, nonce)
            Dim req As WebRequest = HttpWebRequest.Create(obAuth.url)
            Try
                req.Method = httpMethod
                req.ContentType = "application/x-www-form-urlencoded"
                req.Headers.Add(accessTokenHeader & ",oauth_signature=""" & OAuth.OAuthBase.UrlEncodeForShared(accessTokenSignature) & """")
                Dim sr As New IO.StreamReader(req.GetResponse().GetResponseStream())
                Dim result As String = sr.ReadToEnd()
                sr.Close()
                sr.Dispose()
                Return result
            Catch ex As WebException
                Throw New Exception(obAuth.url & ":" & vbCrLf & vbCrLf & obAuth.baseString & vbCrLf & vbCrLf & req.Headers.Get("Authorization") & vbCrLf & vbCrLf & ex.ToString())
            End Try
        End Function
    End Class

    Public Shared Function loginOrReg(ByVal UserShow As API1dot1.UserShow) As Sign.UserLoginReturnCode
        Dim oM As New DB.Member()
        oM.en_source = DB.Member.EN.Source.Twitter
        oM.outer_id = UserShow.id
        oM = oM.GetDataRowAndReturnSelfOrNothing()
        Dim result As Sign.UserLoginReturnCode
        If oM IsNot Nothing Then
            Dim pw As String = UW.TextFns.getMD5(oM.outer_id & "," & DB.SysConfig.Secret.TWITTER_LOGIN_HASH_KEY & "," & oM.salt & "," & oM.time_flag.ToString("yyyy-MM-dd HH:mm:ss.000"))
            result = Sign.AuthLogin(DB.Member.EN.Source.Twitter, oM.outer_id, pw)
            oM.time_flag = Now.ToString("yyyy-MM-dd HH:mm:ss.000")
            oM.pw = UW.TextFns.getMD5(oM.outer_id & "," & DB.SysConfig.Secret.TWITTER_LOGIN_HASH_KEY & "," & oM.salt & "," & oM.time_flag.ToString("yyyy-MM-dd HH:mm:ss.000"))
            oM.profile = UserShow.profile_image_url
            If Not oM.IsIsolate Then
                oM.name = UserShow.name
                oM.location = UserShow.location
            End If
            oM.Update()
        Else
            oM = New DB.Member()
            oM.en_source = DB.Member.EN.Source.Twitter
            oM.outer_id = UserShow.id
            oM.created_date = Now.ToString("yyyy-MM-dd HH:mm:ss.000")
            oM.time_flag = oM.created_date
            oM.salt = UW.TextFns.getMD5(Now().ToString("yyyyMMddHHmmssfff"))
            Dim pw As String = UW.TextFns.getMD5(oM.outer_id & "," & DB.SysConfig.Secret.TWITTER_LOGIN_HASH_KEY & "," & oM.salt & "," & oM.time_flag.ToString("yyyy-MM-dd HH:mm:ss.000"))
            oM.pw = pw
            If oM.lang_id <= 0 Then
                Dim currLang As String = DB.Lang.getLocalLang(HttpContext.Current.Request.UserLanguages.ToList()(0))
                If currLang.Length > 0 Then
                    oM.lang_id = DB.Lang.convertCodeToLangId(currLang)
                Else
                    oM.lang_id = DB.Lang.convertCodeToLangId("en_us")
                End If
            End If
            oM.username = UserShow.sceen_name
            oM.name = UserShow.name
            oM.location = UserShow.location
            oM.IsIsolate = False
            oM.profile = UserShow.profile_image_url
            oM = New DB.Member(oM.Insert())
            result = Sign.AuthLogin(DB.Member.EN.Source.Twitter, oM.outer_id, pw)
        End If
        Return result
    End Function
End Class
