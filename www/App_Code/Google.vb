Imports Microsoft.VisualBasic
Imports System.Net
Public Class Google
    Public Class UserInfo
        Public id As String = ""
        Public email As String = ""
        Public name As String = ""
        Public given_name As String = ""
        Public family_name As String = ""
        Public link As String = ""
        Public gender As String = ""
        Public locale As String = ""
    End Class
    Public Class GeoCode
        Public results As List(Of GeoCodeMain)
        Public status As String
    End Class
    Public Class GeoCodeMain
        Public address_components As List(Of AddressItem)
        Public formatted_address As String
        Public geometry As Geometry
        Public partial_match As Boolean
        Public types As List(Of String)
    End Class
    Public Class Location
        Public lat As Decimal
        Public lng As Decimal
    End Class
    Public Class Geometry
        Public location As Location
        Public location_type As String
        Public viewPort As ViewPort
    End Class
    Public Class ViewPort

    End Class
    Public Class AddressItem
        Public long_name As String = ""
        Public short_name As String = ""
        Public types As List(Of String)
    End Class
    Public Shared Function loginOrReg(ByVal userInfo As UserInfo) As Sign.UserLoginReturnCode
        If userInfo Is Nothing Then
            Return Sign.UserLoginReturnCode.GooglePasswordError
        End If
        Dim oM As New DB.Member()
        oM.en_source = DB.Member.EN.Source.Google
        oM.outer_id = userInfo.id
        oM = oM.GetDataRowAndReturnSelfOrNothing()
        Dim pw As String = ""
        Dim loginResult As Sign.UserLoginReturnCode
        If oM IsNot Nothing Then
            pw = UW.TextFns.getMD5(userInfo.id & "," & DB.SysConfig.GetSysConfig("GOOGLE_LOGIN_HASH_KEY") & "," & oM.salt & "," & oM.time_flag.ToString("yyyy-MM-dd HH:mm:ss.000"))
            loginResult = Sign.AuthLogin(DB.Member.EN.Source.Google, oM.outer_id, pw)
            '登入成功的話更新time_flag 和檢查 資料須不須要更新 
            If loginResult = Sign.UserLoginReturnCode.Success Then
                Dim newTF As DateTime = Now()
                oM.time_flag = newTF.ToString("yyyy-MM-dd HH:mm:ss.000")
                oM.pw = UW.TextFns.getMD5(userInfo.id & "," & DB.SysConfig.GetSysConfig("GOOGLE_LOGIN_HASH_KEY") & "," & oM.salt & "," & oM.time_flag.ToString("yyyy-MM-dd HH:mm:ss.000"))
                '檢查google api 能提供的資料
                If oM.IsIsolate = False Then
                    oM.email = userInfo.email
                    'oM.address = userInfo.address
                    'oM.location = fbUser.location.name
                    'oM.howetown = fbUser.hometown.name
                    If userInfo.gender.ToLower = "female" Then
                        oM.Gender = DB.Member.EN.gender.female
                    Else
                        oM.Gender = DB.Member.EN.gender.male
                    End If
                    oM.name = userInfo.name
                    oM.first_name = userInfo.given_name
                    oM.last_name = userInfo.family_name
                    oM.link = userInfo.link
                    oM.username = oM.name
                End If
                oM.Update()
            End If
        Else
            Dim msg As String = ""
            Dim createdDate As String = Now.ToString("yyyy-MM-dd HH:mm:ss.000")

            Try
                oM = New DB.Member()
                oM.email = userInfo.email
                oM.outer_id = userInfo.id
                'oM.address = userInfo.address
                'oM.location = fbUser.location.name
                'oM.howetown = fbUser.hometown.name
                If userInfo.gender.ToLower = "female" Then
                    oM.Gender = DB.Member.EN.gender.female
                Else
                    oM.Gender = DB.Member.EN.gender.male
                End If
                oM.time_flag = createdDate
                oM.salt = UW.TextFns.getMD5(Now().ToString("yyyyMMddHHmmssfff"))
                pw = UW.TextFns.getMD5(userInfo.id & "," & DB.SysConfig.GetSysConfig("GOOGLE_LOGIN_HASH_KEY") & "," & oM.salt & "," & oM.time_flag.ToString("yyyy-MM-dd HH:mm:ss.000"))
                oM.pw = pw
                oM.name = userInfo.name
                oM.first_name = userInfo.given_name
                oM.last_name = userInfo.family_name
                oM.lang_id = DB.Lang.convertCodeToLangId(DB.Lang.getLocalLang(userInfo.locale))
                If oM.lang_id <= 0 Then
                    Dim currLang As String = DB.Lang.getLocalLang(HttpContext.Current.Request.UserLanguages.ToList()(0))
                    If currLang.Length > 0 Then
                        oM.lang_id = DB.Lang.convertCodeToLangId(currLang)
                    Else
                        oM.lang_id = DB.Lang.convertCodeToLangId("en_us")
                    End If
                End If
                oM.link = userInfo.link
                oM.en_source = DB.Member.EN.Source.Google
                oM.username = oM.name
                oM.insert()
            Catch ex As Exception
                If ex.ToString.Contains("UNIQUE KEY") Then
                    'do nothing, 接下來會用 email 和 pw 登入
                Else
                    UW.WU.WriteErrorToLog(New Exception(ex.ToString()), True)
                    UW.WU.ShowMessageAndGoto("登入失敗，請連絡客服人員。", "/")
                End If
            End Try
            loginResult = Sign.AuthLogin(DB.Member.EN.Source.Google, userInfo.id, pw)
        End If
        If loginResult = Sign.UserLoginReturnCode.Success Then
            Return Sign.UserLoginReturnCode.Success
        ElseIf loginResult = Sign.UserLoginReturnCode.PasswordError Then
            Return Sign.UserLoginReturnCode.GooglePasswordError
        Else
            Return Sign.UserLoginReturnCode.其它錯誤
        End If

    End Function
    Public Class OAuth2
        Public Shared Property urlOAuth2 As String = "https://accounts.google.com/o/oauth2/auth"
        Public Shared Property urlAccessToken As String = "https://accounts.google.com/o/oauth2/token"
        Public Class OAuthParameter
            Public responseType As String = ""
            Public clientId As String = ""
            Public redirectURI As String = ""
            Public scope As String = ""
            Public state As String = ""
            Public loginHinit As String = ""
        End Class
        Public Class AccessToken
            Public access_token As String = ""
            Public token_type As String = ""
            Public expires_in As String = ""
            Public id_token As String = ""
        End Class

        Public Shared Function getOAuth2URL(ByVal oAuthParameter As OAuthParameter) As String
            Dim result As String = ""
            Dim sb As New StringBuilder()
            sb.Append(urlOAuth2 & "?")
            sb.Append("response_type=code&")
            sb.Append("client_id=" & oAuthParameter.clientId & "&")
            sb.Append("redirect_uri=" & oAuthParameter.redirectURI & "&")
            sb.Append("scope=" & oAuthParameter.scope & "&")
            sb.Append("state=offline")
            Return sb.ToString()
        End Function
        Public Shared Function getAccessToken(ByVal code As String) As String
            'urlAccessToken = "http://www.planb-on.com/test/record.aspx"
            Dim url As String = urlAccessToken
            Dim postData As String = "code=" & code & "&client_id=" & DB.SysConfig.Google.GOOGLE_LOGIN_CLIENT_ID & "&client_secret=" & DB.SysConfig.Secret.GOOGLE_LOGIN_CLIENT_SECRET
            postData &= "&redirect_uri=http://" & DB.SysConfig.URL.Domain & "/" & DB.SysConfig.URL.Controller & "/" & DB.SysConfig.URL.API_MEMBER_GOOGLE_LOGIN
            postData &= "&grant_type=authorization_code"
            Dim encoder As New Text.UTF8Encoding()
            Dim postDataBytes As Byte() = encoder.GetBytes(postData)
            Dim req As System.Net.WebRequest = System.Net.HttpWebRequest.Create(url)
            req.Method = "POST"
            req.ContentType = "application/x-www-form-urlencoded"
            req.ContentLength = postDataBytes.Length
            Try
                req.GetRequestStream().Write(postDataBytes, 0, postDataBytes.Length)
                Dim sr As New IO.StreamReader(req.GetResponse().GetResponseStream())
                Dim content As String = sr.ReadToEnd()
                sr.Close()
                sr.Dispose()
                Return content
            Catch ex As WebException
                Dim sr As New IO.StreamReader(ex.Response.GetResponseStream())
                Dim content As String = sr.ReadToEnd()
                'Peter Modify
                Throw New Exception(content)
            End Try
        End Function

    End Class
End Class
