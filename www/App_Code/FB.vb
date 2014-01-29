Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Web
Imports System
Imports System.Runtime.Serialization.json
Public Class FB

    Public Class oAuthUser
        Public name As String = ""
        Public email As String = ""
        Public address As String = ""
        Public phone As String = ""
        Public id As String = ""
        Public first_name As String = ""
        Public last_name As String = ""
        Public link As String = ""
        Public username As String = ""
        Public gender As String = ""
        Public updated_time As String = ""
        Public hometown As New hometown()
        Public location As New location()
        Public locale As String = ""
    End Class
    Public Class hometown
        Public id As String = ""
        Public name As String = ""
    End Class
    Public Class location
        Public id As String = ""
        Public name As String = ""
    End Class
    Public Class oAuthError
        Public errors As New Errors()
    End Class


    Public Class Errors
        Public message As String = ""
        Public type As String = ""
        Public code As String = ""
    End Class


    ''' <summary>
    ''' 回傳 登入授權 頁面
    ''' </summary>
    ''' <param name="fbAppId"></param>
    ''' <param name="fbAppPermission"></param>
    ''' <param name="fbAppRedirectURI"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function getOAuthURL(ByVal fbAppId As String, ByVal fbAppPermission As String, ByVal fbAppRedirectURI As String) As String
        Dim loginurl As String = "https://www.facebook.com/dialog/oauth?"
        loginurl &= "client_id=" & fbAppId
        loginurl &= "&redirect_uri=" & HttpUtility.UrlEncode(fbAppRedirectURI)
        loginurl &= "&scope=" & fbAppPermission
        Return loginurl
    End Function

    ''' <summary>
    ''' 去跟 Facebook 要 Access Token 如果要到 Session("fb_access_token") 設值
    ''' 回傳FBAccessTokenSuccess 或 FBAccessTokenError
    ''' </summary>
    ''' <param name="fbAppId"></param>
    ''' <param name="fbAppRedirectURI"></param>
    ''' <param name="code"></param>
    ''' <param name="fbAppSecret"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function getAccessToken(ByVal fbAppId As String, ByVal fbAppSecret As String, ByVal code As String, ByVal fbAppRedirectURI As String, Optional IsFullResult As Boolean = False) As String
        If fbAppSecret = " Then" Then
            fbAppSecret = DB.SysConfig.GetSysConfig("FB_App_Secret")
        End If
        'redirect to client auth
        Dim fbCheckUserStatusURL As String = "https://graph.facebook.com/oauth/access_token?client_id=" & fbAppId & "&redirect_uri=" & OAuth.OAuthBase.UrlEncodeForShared(fbAppRedirectURI) & "&client_secret=" & fbAppSecret & "&code=" & code
        Dim checkResult As String = UW.WU.getRemotePage(fbCheckUserStatusURL)
        If IsFullResult Then
            Return checkResult
        End If
        If checkResult.IndexOf("access_token") > -1 Then
            Return checkResult.Split("&")(0).Split("=")(1)
        Else
            '授權沒有給access_token 應該不會發生
            Return ""
        End If
    End Function


    ''' <summary>
    ''' 有 access token才來做這邊的事。
    ''' </summary>
    ''' <param name="fbAppId"></param>
    ''' <param name="fbAppPermission"></param>
    ''' <param name="fbAppRedirectURI"></param>
    ''' <remarks></remarks>
    Shared Function loginAndReg(ByVal fbAppId As String, ByVal fbAppPermission As String, ByVal fbAppRedirectURI As String, ByVal fbAccessToken As String) As Sign.UserLoginReturnCode
        '有授權就去抓FB的資料然後塞進資料庫
        Dim result As String = ""
        Try
            result = UW.WU.getRemotePage("https://graph.facebook.com/me?access_token=" & fbAccessToken)
        Catch ex As Exception
            Return Sign.UserLoginReturnCode.FBPageException
        End Try
        Dim fbUser As oAuthUser = UW.JSON.jsonToObject(result, GetType(FB.oAuthUser))
        If fbUser.email Is Nothing OrElse fbUser.email.Length = 0 Then
            Return Sign.UserLoginReturnCode.FBUserInfoNotEnough
        End If
        If fbUser IsNot Nothing Then
            Dim oM As New DB.Member()
            oM.outer_id = fbUser.id
            oM.en_source = DB.Member.EN.Source.Facebook
            oM = oM.GetDataRowAndReturnSelfOrNothing()
            Dim loginResult As Int32 = 0
            Dim pw As String = ""
            If oM IsNot Nothing Then
                '怕Email 之後被更新這樣pw 就沒辦法登入
                pw = UW.TextFns.getMD5(fbUser.id & "," & DB.SysConfig.GetSysConfig("FB_LOGIN_HASH_KEY") & "," & oM.salt & "," & oM.time_flag.ToString("yyyy-MM-dd HH:mm:ss.000"))
                loginResult = Sign.AuthLogin(DB.Member.EN.Source.Facebook, oM.outer_id, pw)
                '登入成功的話更新time_flag 和檢查 資料須不須要更新 
                If loginResult = Sign.UserLoginReturnCode.Success Then
                    Dim newTF As DateTime = Now()
                    oM.time_flag = newTF.ToString("yyyy-MM-dd HH:mm:ss.000")
                    oM.pw = UW.TextFns.getMD5(fbUser.id & "," & DB.SysConfig.GetSysConfig("FB_LOGIN_HASH_KEY") & "," & oM.salt & "," & oM.time_flag.ToString("yyyy-MM-dd HH:mm:ss.000"))
                    If oM.IsIsolate = False AndAlso oM.update_date < CDate(fbUser.updated_time) Then
                        oM.email = fbUser.email
                        oM.address = fbUser.address
                        oM.location = fbUser.location.name
                        oM.howetown = fbUser.hometown.name
                        If fbUser.gender.ToLower = "female" Then
                            oM.Gender = DB.Member.EN.gender.female
                        Else
                            oM.Gender = DB.Member.EN.gender.male
                        End If
                        oM.lang_id = DB.Lang.getLangCodeDic(DB.Lang.getLocalLang(fbUser.locale))
                        oM.name = fbUser.name
                        oM.first_name = fbUser.first_name
                        oM.last_name = fbUser.last_name
                        oM.phone = fbUser.phone
                        oM.link = fbUser.link
                        oM.username = fbUser.username
                    End If
                    oM.Update()
                End If
            Else
                Dim msg As String = ""
                Dim createdDate As String = Now.ToString("yyyy-MM-dd HH:mm:ss.000")

                Try
                    oM = New DB.Member()
                    oM.email = fbUser.email
                    oM.outer_id = fbUser.id
                    oM.address = fbUser.address
                    oM.location = fbUser.location.name
                    oM.howetown = fbUser.hometown.name
                    If fbUser.gender.ToLower = "female" Then
                        oM.Gender = DB.Member.EN.gender.female
                    Else
                        oM.Gender = DB.Member.EN.gender.male
                    End If
                    oM.time_flag = createdDate
                    oM.salt = UW.TextFns.getMD5(Now().ToString("yyyyMMddHHmmssfff"))
                    pw = UW.TextFns.getMD5(fbUser.id & "," & DB.SysConfig.GetSysConfig("FB_LOGIN_HASH_KEY") & "," & oM.salt & "," & oM.time_flag.ToString("yyyy-MM-dd HH:mm:ss.000"))
                    oM.pw = pw
                    oM.name = fbUser.name
                    oM.first_name = fbUser.first_name
                    oM.last_name = fbUser.last_name
                    oM.phone = fbUser.phone
                    oM.link = fbUser.link
                    oM.en_source = DB.Member.EN.Source.Facebook
                    oM.lang_id = DB.Lang.getLangCodeDic(DB.Lang.getLocalLang(fbUser.locale))
                    '這個Username目前沒有拿來特別做什麼，不過以後可以拿來登入或是只是拿來顯示用。
                    oM.username = fbUser.username
                    'oM.update_date = fbUser.updated_time
                    oM.Insert()
                Catch ex As Exception
                    Throw New Exception(ex.ToString())
                    If ex.ToString.Contains("UNIQUE KEY") Then
                        'do nothing, 接下來會用 email 和 pw 登入
                    Else
                        UW.WU.WriteErrorToLog(New Exception(ex.ToString()), True)
                        UW.WU.ShowMessageAndGoto("登入失敗，請連絡客服人員。", "/")
                    End If
                End Try
                loginResult = Sign.AuthLogin(DB.Member.EN.Source.Facebook, oM.outer_id, pw)
            End If
            If loginResult = Sign.UserLoginReturnCode.Success Then
                Return Sign.UserLoginReturnCode.Success
            ElseIf loginResult = Sign.UserLoginReturnCode.PasswordError Then
                Return Sign.UserLoginReturnCode.FBPasswordError
            Else
                Return Sign.UserLoginReturnCode.其它錯誤
            End If
        Else
            Return Sign.UserLoginReturnCode.FBUserInfoNotEnough
        End If
    End Function
End Class
