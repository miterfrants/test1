Imports System.Web.HttpContext


Namespace DB
    Partial Public Class SysConfig
        Inherits UW.DB.Record2

        Sub SetMatchColumn(ByVal oPH As System.Web.UI.Control, Optional ByVal StoreFilePath As String = "", Optional ByVal IsCreatePath As Boolean = True, Optional ByVal Extension As String = "", Optional ByVal IsKeepOriginalFileName As UW.EN.ThreeSatatBoolean_ForConfig = UW.EN.ThreeSatatBoolean_ForConfig.預設, Optional ByVal FieldsToSetNullWithEmptyString As String = ",,", Optional ByVal FieldsToIgnore As String = ",,", Optional ByVal IsAddTimeStampBeforeOriiginalFileName As Boolean = False, Optional ByVal IsThrowException As Boolean = False)
            UW.FormUtil.SetMatchedColunm(oPH, Me, StoreFilePath, IsCreatePath, Extension, IsKeepOriginalFileName, FieldsToSetNullWithEmptyString, FieldsToIgnore, IsAddTimeStampBeforeOriiginalFileName, IsThrowException)
        End Sub

        Sub LoadMatchedColumn(ByVal oPH As System.Web.UI.Control, Optional ByVal IsThrowExceptionForDDLNotMatch As Boolean = True, Optional ByVal ImageFolderURL As String = "")
            UW.FormUtil.LoadMatchedColumn(oPH, Me, IsThrowExceptionForDDLNotMatch, ImageFolderURL)
        End Sub

        Shared Function GetTotalCount() As Int32
            Return UW.SQL.GetSingleIntWithDefault("Select count(*) from " & DB.SysConfig.BaseTableName_Const)
        End Function

        Shared Function GetSum(ByVal FieldNames As String) As Int32
            Return UW.SQL.GetSingleIntWithDefault("Select sum(" & FieldNames & ") from " & DB.SysConfig.BaseTableName_Const)
        End Function

        Public Overrides ReadOnly Property DBC() As String
            Get
                Return Nothing
            End Get
        End Property


        Shared SyncLocker_GetAllDataFromBaseTableWithCache As New Object
        Shared Function GetAllDataFromBaseTableWithCache(Optional ByVal OrderFields As String = "_Default", Optional ByVal IsCopy As Boolean = True) As DataTable
            Dim CacheName As String = "GetAllDataFromBaseTableWithCache_SysConfig_" & OrderFields
            If OrderFields = "_Default" Then
                OrderFields = GetDefaultSortFieldName()
            End If
            Dim obj As DataTable = System.Web.HttpContext.Current.Cache(CacheName)
            If obj Is Nothing Then
                SyncLock SyncLocker_GetAllDataFromBaseTableWithCache
                    obj = System.Web.HttpContext.Current.Cache(CacheName)
                    If obj Is Nothing Then
                        Dim SQL As String = "select * from " & BaseTableName_Const
                        If OrderFields.Length > 0 Then
                            SQL = SQL & " Order By " & OrderFields
                        End If
                        obj = UW.SQL.DTFromSQL(SQL)
                        Dim SC As New SqlCacheDependency(UW.SQL.sqlCacheDependencyName, BaseTableName_Const)
                        System.Web.HttpContext.Current.Cache.Insert(CacheName, obj, SC)
                    End If
                End SyncLock
            End If
            If IsCopy Then
                Return obj.Copy
            Else
                Return obj
            End If
        End Function


        Shared Function GetSysConfigFromCachedDT(ByVal Key As String) As DB.SysConfig
            Dim DT As DataTable = GetAllDataFromBaseTableWithCache()
            Dim Rows As DataRow() = DT.Select(IdField_Const & " = '" & Key.Replace("'", "''") & "'")
            If Rows.Length > 0 Then
                Return New SysConfig(Rows(0))
            Else
                Return Nothing
            End If
        End Function


        Shared Function GetDefaultSortFieldName() As String
            Dim Ht As Hashtable = htTypeDefines
            For Each key As String In Ht.Keys
                If key.ToLower = "orderno" Then
                    Return key
                End If
                If key.ToLower = "order_no" Then
                    Return key
                End If
            Next
            Return ""
        End Function



        Shared SyncLocker_getDicSysConfigFromCache As New Object
        Shared Function getDicSysConfigFromCache() As Dictionary(Of String, String)
            Dim CacheName As String = "getDicSysConfigFromCache"
            Dim obj As Dictionary(Of String, String) = Current.Cache(CacheName)
            If obj Is Nothing Then
                SyncLock SyncLocker_getDicSysConfigFromCache
                    obj = Current.Cache(CacheName)
                    If obj Is Nothing Then
                        obj = New Dictionary(Of String, String)
                        Dim dt As DataTable = UW.SQL.DTFromSQL("select * from sys_config")

                        If dt IsNot Nothing Then
                            For i As Int32 = 0 To dt.Rows.Count - 1
                                Try
                                    If Not obj.ContainsKey(dt.Rows(i)("name").ToString()) Then
                                        obj.Add(dt.Rows(i)("name"), dt.Rows(i)("content"))
                                    End If
                                Catch ex As Exception
                                    Throw New Exception(dt.Rows(i)("name"))
                                End Try

                            Next
                        End If
                        Dim SC As New SqlCacheDependency(UW.SQL.sqlCacheDependencyName, "sys_config")
                        Current.Cache.Insert(CacheName, obj, SC)
                    End If
                End SyncLock
            End If

            Return obj
        End Function

        Shared Function GetSysConfig(ByVal name As String) As String
            Dim dic As Dictionary(Of String, String) = getDicSysConfigFromCache()
            If dic.ContainsKey(name) Then
                Return dic(name)
            Else
                Return ""
            End If
        End Function

        Public Class COOKIE_KEY
            Public Shared Property FB_LOGIN_ACCESS_TOKEN_KEY As String = DB.SysConfig.GetSysConfig("FB_LOGIN_ACCESS_TOKEN_KEY")
            Public Shared Property GOOGLE_LOGIN_ACCESS_TOKEN_KEY As String = DB.SysConfig.GetSysConfig("GOOGLE_LOGIN_ACCESS_TOKEN_KEY")
            Public Shared Property LOGIN_COOKIE_KEY As String = DB.SysConfig.GetSysConfig("LOGIN_COOKIE_KEY")
        End Class
        Public Class Secret
            Public Shared Property FB_LOGIN_APP_SECRET As String = DB.SysConfig.GetSysConfig("FB_LOGIN_APP_SECRET")
            Public Shared Property FB_LOGIN_HASH_KEY As String = DB.SysConfig.GetSysConfig("FB_LOGIN_HASH_KEY")
            Public Shared Property TWITTER_LOGIN_HASH_KEY As String = DB.SysConfig.GetSysConfig("TWITTER_LOGIN_HASH_KEY")
            Public Shared Property TWITTER_LOGIN_OAUTH_CUSTOMER_SECRET As String = DB.SysConfig.GetSysConfig("TWITTER_LOGIN_OAUTH_CUSTOMER_SECRET")
            Public Shared Property GOOGLE_LOGIN_CLIENT_SECRET As String = DB.SysConfig.GetSysConfig("GOOGLE_LOGIN_CLIENT_SECRET")
            Public Shared Property MD5_HASH_KEY_NEW As String = DB.SysConfig.GetSysConfig("MD5_HASH_KEY_NEW")
            Public Shared Property MD5_HASH_KEY_OLD As String = DB.SysConfig.GetSysConfig("MD5_HASH_KEY_OLD")
        End Class
        Public Class Google
            Public Shared Property GOOGLE_LOGIN_CLIENT_ID As String = DB.SysConfig.GetSysConfig("GOOGLE_LOGIN_CLIENT_ID")
            Public Shared Property GOOGLE_LOGIN_SCOPE As String = DB.SysConfig.GetSysConfig("GOOGLE_LOGIN_SCOPE")
        End Class
        Public Class FB
            Public Shared Property FB_LOGIN_APP_ID As String = DB.SysConfig.GetSysConfig("FB_LOGIN_APP_ID")
            Public Shared Property FB_LOGIN_PERMISSION As String = DB.SysConfig.GetSysConfig("FB_LOGIN_PERMISSION")
        End Class
        Public Class Twitter
            Public Shared Property TWITTER_LOGIN_OAUTH_CUSTOMER_KEY As String = DB.SysConfig.GetSysConfig("TWITTER_LOGIN_OAUTH_CUSTOMER_KEY")
        End Class
        Public Class SESSION_KEY
            Public Shared Property FB_LOGIN_FAIL_COUNT_KEY As String = DB.SysConfig.GetSysConfig("FB_LOGIN_FAIL_COUNT_KEY")

            Public Shared Property LOGIN_SESSION_KEY As String = DB.SysConfig.GetSysConfig("LOGIN_SESSION_KEY")
        End Class
        Public Class URL
            Public Shared Property Domain As String = DB.SysConfig.GetSysConfig("DOMAIN")
            Public Shared Property Controller As String = DB.SysConfig.GetSysConfig("CONTROLLER")
            Public Shared Property API_MEMBER_FB_LOGIN As String = DB.SysConfig.GetSysConfig("API_MEMBER_FB_LOGIN")
            Public Shared Property API_MEMBER_TWITTER_LOGIN As String = DB.SysConfig.GetSysConfig("API_MEMBER_TWITTER_LOGIN")
            Public Shared Property API_MEMBER_TWITTER_REQUEST_TOKEN As String = DB.SysConfig.GetSysConfig("API_MEMBER_TWITTER_REQUEST_TOKEN")
            Public Shared Property API_MEMBER_GOOGLE_LOGIN As String = DB.SysConfig.GetSysConfig("API_MEMBER_GOOGLE_LOGIN")
            Public Shared Property Upload As String = Domain & "/Upload/"
            Public Shared Property Mobile_Goods_Img As String = Upload & "Goods/"
        End Class
        Public Class Path
            Public Shared Property Upload As String = Current.Server.MapPath(URL.Upload)
            Public Shared Property GoodsCSV As String = Upload & "\goods_csv\"
        End Class

    End Class
End Namespace
