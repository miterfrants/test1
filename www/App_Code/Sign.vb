Imports System.Security.Cryptography
Imports System.Web.HttpContext

Public Class Sign
    ' Cookie 登入系統，可適用於多主機系統 Version 2.0
    ' 不直接存取資料庫，而是透過 DB 下的物件。
    Shared Function Version() As Single
        Return 2.1
    End Function

    '使用四個 Session 變數
    '四個變數都用sys config 來處理。 Peter Modify
    '_WSC_KEY_  ==> 使用者的帳號
    '_WSC_UserObject_  ==>  Member Object
    '_WSC_LoginDate_  ==> 登入時間，和 Cookie 中的 Login_Date_Time 比較，若 Cookie 中的 Login_Date_Time 較新，則重新讀取使用者資料。
    '_WSC_AuthCodeList  ==> 授權碼列表

    '使用四個 Cookie 變數
    'Username  ==>  使用者名稱，沒有 UserName 視為未登入或已登出
    'Login_Date_Time  ==> 登入時間，用來控制 Session 中的使用者資料是否要更新，更新使用者資料後可重設此變數，以逹到更新多台主機的目的
    'Last_Update  ==>  上次更新 HashKey 的時間，檢查 IsLogin 時會更新
    'HashKey ==> 簽章 '每半小時更新一次，檢查 IsLogin 時會更新

    '使用兩個 Application 變數(借由 CST 傳回)，每小時更新一次，相當於使用者端的 HashKey 有兩小時的有效時間
    'MD5_HASH_KEY_OLD  ==>  舊的  MD5_HASH_KEY
    'MD5_HASH_KEY_NEW  ==>  新的  MD5_HASH_KEY


    Shared Function AuthLogin(ByVal en_source As DB.Member.EN.Source, ByVal id As String, ByVal pw As String) As Sign.UserLoginReturnCode
        Dim oM As New DB.Member()
        oM.outer_id = id
        oM.en_source = en_source
        oM.GetDataRowAndReturnSelfOrNothing()
        If oM Is Nothing Then
            Return Sign.UserLoginReturnCode.UserNotFound
        End If
        If oM.pw <> pw Then
            Return Sign.UserLoginReturnCode.PasswordError
        End If

        'If oMember.MemberStatus <> DB.Member.EN.MemberStatus.正常 Then
        '    If oMember.MemberStatus = DB.Member.EN.MemberStatus.鎖定 Then
        '        Return UserLoginReturnCode.鎖定
        '    End If
        '    If oMember.MemberStatus = DB.Member.EN.MemberStatus.未認證 Then
        '        Return UserLoginReturnCode.未認證
        '    End If
        '    Return UserLoginReturnCode.其它錯誤
        'End If

        '把使用者 en_source 和 ID 做 MD5 寫入 Session 
        Current.Session("_WSC_KEY_") = oM.en_source.ToString() & ":" & oM.outer_id

        '把使用者資料記入 Current.Session("_WSC_UserObject_")
        SetUserData(oM)

        '記錄登入時間
        Dim TimeStamp As String = Now.ToString("yyyy-MM-dd HH:mm:ss")
        Current.Session("_WSC_LoginDate_") = TimeStamp
        Sign.SetCookie(TimeStamp)
        Return Sign.UserLoginReturnCode.Success
    End Function

    Shared Sub SetUserData(ByVal LoginDate As DateTime, Optional ByVal oMember As DB.Member = Nothing, Optional ByVal RefreshFlag As Boolean = False)

        '每個要求登入的 Page 都會執行一次。

        '更新使用者資料，當:  _WSC_UserObject_ 不存在，強迫更新，使用者帳號不符，登入時間較 Session 中的記錄要晚
        If Current.Session("_WSC_UserObjec") Is Nothing OrElse _
           RefreshFlag OrElse _
           CType(Current.Session("_WSC_UserObjec"), DB.Member).en_source & ":" & CType(Current.Session("_WSC_UserObjec"), DB.Member).outer_id <> Current.Session("_WSC_KEY_") OrElse _
           LoginDate.ToString("yyyy-MM-dd HH:mm:ss") > Current.Session("_WSC_LoginDate_") Then

            If Current.Session("_WSC_KEY_") Is Nothing Then
                Throw New Exception("SetUserData: User is not login!!")
            End If

            '設定使用者物件
            If oMember Is Nothing Then
                oMember = New DB.Member()
                'Peter Modify
                oMember.en_source = [Enum].Parse(GetType(DB.Member.EN.Source), Current.Session("_WSC_KEY_").ToString.Split(":")(0))
                oMember.outer_id = Current.Session("_WSC_KEY_").ToString.Split(":")(1)
                oMember = oMember.GetDataRowAndReturnSelfOrNothing()
            End If
            Current.Session("_WSC_UserObject_") = oMember
            '讀取權限清單 
            'Current.Session("_WSC_AuthCodeList") = oMember.GetAuthrizationHT
            If LoginDate.ToString("yyyy-MM-dd HH:mm:ss") > Current.Session("_WSC_LoginDate_") Then
                Current.Session("_WSC_LoginDate_") = LoginDate.ToString("yyyy-MM-dd HH:mm:ss")
            End If
        End If
    End Sub

    Shared Sub SetUserData(Optional ByVal oMember As DB.Member = Nothing, Optional ByVal RefreshFlag As Boolean = False)
        SetUserData(DateTime.MinValue, oMember, RefreshFlag)
    End Sub


    Shared Sub ReloadMemberData()
        SetUserData(DateTime.MinValue, Nothing, True)
    End Sub


    Shared Sub SetCookie(ByVal LoginTime As String)
        Dim ck1 As New HttpCookie("HashID")
        Dim ck2 As New HttpCookie("Login_Date_Time")
        Dim ck3 As New HttpCookie("HashKey")

        If DB.SysConfig.URL.Domain <> " Then" Then
            ck1.Domain = DB.SysConfig.URL.Domain
            ck2.Domain = DB.SysConfig.URL.Domain
            ck3.Domain = DB.SysConfig.URL.Domain
        Else
            Throw New Exception("請設定 db.SysConfig.DomainName")
        End If

        ck1.Value = Current.Session("_WSC_KEY_")
        Current.Response.Cookies.Add(ck1)

        ck2.Value = LoginTime
        Current.Response.Cookies.Add(ck2)
        Dim HK As String = Current.Session("_WSC_KEY_") & "," & LoginTime & "," & DB.SysConfig.Secret.MD5_HASH_KEY_NEW
        ck3.Value = GetMD5HashString(HK)
        Current.Response.Cookies.Add(ck3)

    End Sub

    Shared Function GetMD5HashString(ByVal source As String) As String
        Dim data2ToHash As [Byte]() = ConvertStringToByteArray(source)
        Dim hashvalue2 As Byte() = New MD5CryptoServiceProvider().ComputeHash(data2ToHash)
        Return BitConverter.ToString(hashvalue2)
    End Function

    Shared Function ConvertStringToByteArray(ByVal s As [String]) As [Byte]()
        Return (New System.Text.UTF8Encoding).GetBytes(s)
    End Function

    Public Shared Function IsLogin() As Boolean
        '確定使用者有 Login 同時也要保証 Session 裡的 _WSC_KEY_ 和 _WSC_UserObject_ 是正確的
        '登入時間檢查，Session 中的 _WSC_LoginDate_ 和 Cookie 中的 Login_Date_Time 比較，若 Cookie 中的 Login_Date_Time 較新，則重新讀取使用者資料。以確保多主機系統的重新登入可正常運作。

        Dim Res As Boolean = False

        '檢查 Cookie，若沒有 Cookie 視為未登入或已登出以解決多機時的問題(不可以只看 session)
        'UW.WU.DebugWriteLine(Current.Request.Cookies("Username").Value & ", " & Current.Session("_WSC_KEY_"))

        If Current.Request.Cookies("HashID") Is Nothing OrElse Current.Request.Cookies("HashID").Value.Length = 0 Then
            Res = False
        Else
            '比對 Current.Session("_WSC_KEY_") ，若相同，則不需檢查 HashKey 
            If Not Current.Session("_WSC_KEY_") Is Nothing AndAlso Current.Session("_WSC_KEY_").ToString = Current.Request.Cookies("HashID").Value Then
                'Current.Session("_WSC_KEY_") 相同，檢查 HashKey 是否要更新

                Res = True
                If Current.Request.Cookies("HashKey").Value <> GetMD5HashString(Current.Request.Cookies("HashID").Value & "," & Current.Request.Cookies("Login_Date_Time").Value & "," & DB.SysConfig.Secret.MD5_HASH_KEY_NEW) Then
                    '若使用了舊的 Key，則更新為新的 Key。
                    Sign.SetCookie(Current.Request.Cookies("Login_Date_Time").Value)
                End If
            Else
                '檢查 Hash Key
                Dim HashValue As String = Current.Request.Cookies("HashKey").Value
                '先用 MD5_HASH_KEY_NEW
                If HashValue = GetMD5HashString(Current.Request.Cookies("HashID").Value & "," & Current.Request.Cookies("Login_Date_Time").Value & "," & DB.SysConfig.Secret.MD5_HASH_KEY_NEW) Then
                    Res = True
                Else
                    '再試試 MD5_HASH_KEY_OLD
                    If HashValue = GetMD5HashString(Current.Request.Cookies("HashID").Value & "," & Current.Request.Cookies("Login_Date_Time").Value & "," & DB.SysConfig.Secret.MD5_HASH_KEY_OLD) Then
                        Res = True
                        '要把 Hash Key 換成 MD5_HASH_KEY_NEW
                        SetCookie(Current.Request.Cookies("Login_Date_Time").Value)
                    Else
                        Res = False '不成功
                    End If
                End If

                If Res Then
                    '更新 session 變數
                    Current.Session("_WSC_KEY_") = Current.Request.Cookies("HashID").Value
                    SetUserData()
                End If
            End If
        End If
        Return Res
    End Function

    Public Shared Sub ClearCookie()
        '清除 Cookie 裡的 Username
        Current.Response.Cookies.Remove("HashID")

        Dim ck1 As New HttpCookie("HashID")

        If DB.SysConfig.URL.Domain <> " Then" Then
            ck1.Domain = DB.SysConfig.URL.Domain
        Else
            Throw New Exception("請設定 Sysconfig 中的 DOMAIN_NAME")
        End If

        ck1.Value = ""
        Current.Response.Cookies.Add(ck1)
    End Sub

    Public Shared Sub Logout()
        '清除 Cookie 裡的 Username
        ClearCookie()
        Current.Session.Abandon()
    End Sub

    Public Shared ReadOnly Property Member() As DB.Member
        '讀取使用者資料
        '假設使用前會檢查是否登入，在這裡就不再重複檢查。
        Get
            Return Current.Session("_WSC_UserObject_")
        End Get
    End Property


    Public Shared Function MemberCheckLogin() As Boolean
        If Not IsLogin() Then
            Return False
        Else
            Return True
        End If

    End Function
    Public Shared Function CheckLogin() As Boolean
        If Not IsLogin() Then
            'Current.Response.Redirect(DB.SysConfig.URL_APPROOT & "admin/member/login.aspx?returnURL=" & Current.Server.UrlEncode(UW.WU.URL))
        End If
        Return True
    End Function

    Shared Function GetLoginErrorMessage(ByVal EeturnCode As Sign.UserLoginReturnCode) As String
        Select Case EeturnCode
            Case Sign.UserLoginReturnCode.Success
                Return "Login Successfully !!"
            Case Sign.UserLoginReturnCode.UserNotFound
                Return "User Notfound !!"
            Case Sign.UserLoginReturnCode.PasswordError
                Return "Password Error !!"
            Case Sign.UserLoginReturnCode.鎖定
                Return "You are locked out. Please contact administrator."
        End Select
        Return "Some error is happened, error code is " & EeturnCode & ". Please contact administrator."
    End Function

    'Public Shared Function CheckRightOrStop(ByVal AuthCode As AuthCode) As Boolean
    '    If Not IsAuthrized(AuthCode) Then
    '        Current.Response.Write("<br>您沒有使用此功能的權限!!!")
    '        Current.Response.Write("<br><br>若有需要，請向管理員取得權限!!!")
    '        Current.Response.Write("<br>然後再重新登入!!!")
    '        Current.Response.Write("<br><br><a href=javascript:history.go(-1)>上一頁</a>")
    '        Current.Response.End()
    '    End If
    'End Function

    Public Shared Function IsAuthrized(ByVal AuthCode As AuthCode) As Boolean
        If AuthCode = AuthCode.不設限 Then Return True
        If Not IsLogin() Then Return False
        Dim HT As Hashtable = Current.Session("_WSC_AuthCodeList")
        Return (HT.Contains(Convert.ToInt32(AuthCode)) OrElse HT.Contains(Convert.ToInt32(AuthCode.系統管理員)))
    End Function

    Public Shared Function MemberId() As Int32
        Return Int32.Parse(Member.Id)
    End Function

    ''' <summary>
    ''' 授權碼的 Enum
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum AuthCode
        不設限 = -1
        系統管理員 = 1
        會員管理 = 100
        課程管理 = 200
        廣告管理 = 300
        靜態頁面 = 400
        檔案類別 = 500
    End Enum

    Private Shared _htAuthCode As Hashtable
    ''' <summary>
    ''' 授權碼
    ''' </summary>
    Shared Function htAuthCode() As Hashtable
        If _htAuthCode Is Nothing Then
            _htAuthCode = UW.HashtableFns.HTFromEnum(GetType(AuthCode))
        End If
        Return _htAuthCode
    End Function

    ''' <summary>
    ''' 授權碼
    ''' </summary>
    Shared Function strAuthCode(ByVal Key As AuthCode) As String
        Return htAuthCode(Key)
    End Function


    Private Shared _alAuthCode As ArrayList = Nothing
    ''' <summary>
    ''' 授權碼列表
    ''' </summary>
    Public Shared Function alAuthCode() As ArrayList
        If _alAuthCode Is Nothing Then
            _alAuthCode = UW.ArrayListFns.ALFromEnum(GetType(AuthCode))
        End If
        Return _alAuthCode
    End Function

    Public Enum UserLoginReturnCode
        Success = 0
        UserNotFound = 1
        PasswordError = 2
        AdminPasswordError = 3
        鎖定 = 4
        IP錯誤 = 5
        其它錯誤 = -1
        'Yahoo Facebook

        FBPasswordError = 6
        FBUserInfoNotEnough = 7
        FBPageException = 8
        FBAccessTokenError = 9
        FBAccessTokenSuccess = 10
        YahooPasswordError = 11
        YahooNotYetAuth = 12
        GooglePasswordError = 13
        GooglePageException = 14
        '外站註冊結果跟外站登入是寫在同一個function
        Yahoo重複帳號 = 13
        Facebook重複帳號 = 14
    End Enum
End Class

