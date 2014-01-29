Imports System.Web.HttpContext
Imports System.Web.Caching

Namespace DB
    Partial Public Class Lang
        Inherits UW.DB.Record2

        Sub SetMatchColumn(ByVal oPH As System.Web.UI.Control, Optional ByVal StoreFilePath As String = "", Optional ByVal IsCreatePath As Boolean = True, Optional ByVal Extension As String = "", Optional ByVal IsKeepOriginalFileName As UW.EN.ThreeSatatBoolean_ForConfig = UW.EN.ThreeSatatBoolean_ForConfig.預設, Optional ByVal FieldsToSetNullWithEmptyString As String = ",,", Optional ByVal FieldsToIgnore As String = ",,", Optional ByVal IsAddTimeStampBeforeOriiginalFileName As Boolean = False, Optional ByVal IsThrowException As Boolean = False)
            UW.FormUtil.SetMatchedColunm(oPH, Me, StoreFilePath, IsCreatePath, Extension, IsKeepOriginalFileName, FieldsToSetNullWithEmptyString, FieldsToIgnore, IsAddTimeStampBeforeOriiginalFileName, IsThrowException)
        End Sub

        Sub LoadMatchedColumn(ByVal oPH As System.Web.UI.Control, Optional ByVal IsThrowExceptionForDDLNotMatch As Boolean = True, Optional ByVal ImageFolderURL As String = "")
            UW.FormUtil.LoadMatchedColumn(oPH, Me, IsThrowExceptionForDDLNotMatch, ImageFolderURL)
        End Sub

        Shared Function GetTotalCount() As Int32
            Return UW.SQL.GetSingleIntWithDefault("Select count(*) from " & DB.Lang.BaseTableName_Const)
        End Function

        Shared Function GetSum(ByVal FieldNames As String) As Int32
            Return UW.SQL.GetSingleIntWithDefault("Select sum(" & FieldNames & ") from " & DB.Lang.BaseTableName_Const)
        End Function

        Public Overrides ReadOnly Property DBC() As String
            Get
                Return Nothing
            End Get
        End Property


        Shared SyncLocker_GetAllDataFromBaseTableWithCache As New Object
        Shared Function GetAllDataFromBaseTableWithCache(Optional ByVal OrderFields As String = "_Default", Optional ByVal IsCopy As Boolean = True) As DataTable
            Dim CacheName As String = "GetAllDataFromBaseTableWithCache_Lang_" & OrderFields
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


        Shared Function GetLangFromCachedDT(ByVal Key As String) As DB.Lang
            Dim DT As DataTable = GetAllDataFromBaseTableWithCache()
            Dim Rows As DataRow() = DT.Select(IdField_Const & " = '" & Key.Replace("'", "''") & "'")
            If Rows.Length > 0 Then
                Return New Lang(Rows(0))
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



        Shared SyncLocker_getLangDic As New Object
        Shared Function getLangDic() As Generic.Dictionary(Of String, DB.Lang)
            Dim CacheName As String = "getLangDic"

            Dim obj As Generic.Dictionary(Of String, DB.Lang) = Current.Cache(CacheName)
            If obj Is Nothing Then
                SyncLock SyncLocker_getLangDic
                    obj = Current.Cache(CacheName)
                    If obj Is Nothing Then
                        obj = New Generic.Dictionary(Of String, DB.Lang)
                        Dim dt As DataTable = UW.SQL.DTFromSQL("select * from lang")
                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                            For i As Int32 = 0 To dt.Rows.Count - 1
                                If Not obj.ContainsKey(dt.Rows(i)("name")) Then
                                    obj.Add(dt.Rows(i)("name"), New DB.Lang(dt.Rows(i)))
                                End If
                            Next
                        End If
                        Dim SC As New SqlCacheDependency(UW.SQL.sqlCacheDependencyName, "lang")
                        Current.Cache.Insert(CacheName, obj, SC)
                    End If
                End SyncLock
            End If

            Return obj
        End Function


        Shared SyncLocker_getLangCodeDic As New Object
        Shared Function getLangCodeDic() As Generic.Dictionary(Of String, Int32)
            Dim CacheName As String = "getLangCodeDic"

            Dim obj As Generic.Dictionary(Of String, Int32) = Current.Cache(CacheName)
            If obj Is Nothing Then
                SyncLock SyncLocker_getLangDic
                    obj = Current.Cache(CacheName)
                    If obj Is Nothing Then
                        obj = New Generic.Dictionary(Of String, Int32)
                        Dim dt As DataTable = UW.SQL.DTFromSQL("select * from lang")
                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                            For i As Int32 = 0 To dt.Rows.Count - 1
                                If Not obj.ContainsKey(dt.Rows(i)("abbr")) Then
                                    obj.Add(dt.Rows(i)("abbr"), CInt(dt.Rows(i)("id")))
                                End If
                            Next
                        End If
                        Dim SC As New SqlCacheDependency(UW.SQL.sqlCacheDependencyName, "lang")
                        Current.Cache.Insert(CacheName, obj, SC)
                    End If
                End SyncLock
            End If

            Return obj
        End Function

        Shared Function convertCodeToLangId(ByVal code As String) As Int32
            If getLangCodeDic.ContainsKey(code) Then
                Return getLangCodeDic(code)
            End If
            Return -1
        End Function

        Public Shared Function getLocalLang(ByVal locate As String) As String
            locate = locate.ToLower().Replace(".", "_").Replace("-", "_")
            If locate.StartsWith("en_") Then
                Return "en_us"
            ElseIf locate.StartsWith("zh_") AndAlso Not locate.ToLower().EndsWith("cn") Then
                Return "zh_tw"
            ElseIf locate = "zh_cn" Then
                Return "zh_cn"
            ElseIf locate.StartsWith("ja_") Then
                Return "ja"
            ElseIf locate.StartsWith("es_") Then
                Return "es"
            Else
                Return "en_us"
            End If
        End Function


    End Class
End Namespace
