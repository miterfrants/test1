Imports System.Web.HttpContext
Imports System.Web.Caching

Namespace DB
    Partial Public Class ExpList
        Inherits UW.DB.Record2

        Sub SetMatchColumn(ByVal oPH As System.Web.UI.Control, Optional ByVal StoreFilePath As String = "", Optional ByVal IsCreatePath As Boolean = True, Optional ByVal Extension As String = "", Optional ByVal IsKeepOriginalFileName As UW.EN.ThreeSatatBoolean_ForConfig = UW.EN.ThreeSatatBoolean_ForConfig.預設, Optional ByVal FieldsToSetNullWithEmptyString As String = ",,", Optional ByVal FieldsToIgnore As String = ",,", Optional ByVal IsAddTimeStampBeforeOriiginalFileName As Boolean = False, Optional ByVal IsThrowException As Boolean = False)
            UW.FormUtil.SetMatchedColunm(oPH, Me, StoreFilePath, IsCreatePath, Extension, IsKeepOriginalFileName, FieldsToSetNullWithEmptyString, FieldsToIgnore, IsAddTimeStampBeforeOriiginalFileName, IsThrowException)
        End Sub

        Sub LoadMatchedColumn(ByVal oPH As System.Web.UI.Control, Optional ByVal IsThrowExceptionForDDLNotMatch As Boolean = True, Optional ByVal ImageFolderURL As String = "")
            UW.FormUtil.LoadMatchedColumn(oPH, Me, IsThrowExceptionForDDLNotMatch, ImageFolderURL)
        End Sub

        Shared Function GetTotalCount() As Int32
            Return UW.SQL.GetSingleIntWithDefault("Select count(*) from " & DB.ExpList.BaseTableName_Const)
        End Function

        Shared Function GetSum(ByVal FieldNames As String) As Int32
            Return UW.SQL.GetSingleIntWithDefault("Select sum(" & FieldNames & ") from " & DB.ExpList.BaseTableName_Const)
        End Function

        Public Overrides ReadOnly Property DBC() As String
            Get
                Return Nothing
            End Get
        End Property


        Shared SyncLocker_GetAllDataFromBaseTableWithCache As New Object
        Shared Function GetAllDataFromBaseTableWithCache(Optional ByVal OrderFields As String = "_Default", Optional ByVal IsCopy As Boolean = True) As DataTable
            Dim CacheName As String = "GetAllDataFromBaseTableWithCache_ExpList_" & OrderFields
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


        Shared Function GetExpListFromCachedDT(ByVal Key As String) As DB.ExpList
            Dim DT As DataTable = GetAllDataFromBaseTableWithCache()
            Dim Rows As DataRow() = DT.Select(IdField_Const & " = '" & Key.Replace("'", "''") & "'")
            If Rows.Length > 0 Then
                Return New ExpList(Rows(0))
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



        Shared SyncLocker_getDicExpList As New Object
        Shared Function getDicExpList() As Generic.Dictionary(Of String, Int32)
            Dim CacheName As String = "getDicExpList"

            Dim obj As Generic.Dictionary(Of String, Int32) = Current.Cache(CacheName)
            If obj Is Nothing Then
                SyncLock SyncLocker_getDicExpList
                    obj = Current.Cache(CacheName)
                    If obj Is Nothing Then
                        obj = New Generic.Dictionary(Of String, Int32)
                        Dim dt As DataTable = UW.SQL.DTFromSQL("select * from exp_list")
                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                            For i As Int32 = 0 To dt.Rows.Count - 1
                                If Not obj.ContainsKey(dt.Rows(i)("name")) Then
                                    obj.Add(dt.Rows(i)("name"), CInt(dt.Rows(i)("exp")))
                                Else
                                    '有重覆的key 送錯誤出來 peter modify
                                End If
                            Next
                        End If
                        'Dim DepArray() As CacheDependency = {New SqlCacheDependency(UW.SQL.sqlCacheDependencyName, "Table1"), _
                        '                                     New SqlCacheDependency(UW.SQL.sqlCacheDependencyName, "Table2"), _
                        '                                     New SqlCacheDependency(UW.SQL.sqlCacheDependencyName, "Table3")}
                        'Dim AC As New AggregateCacheDependency
                        'AC.Add(DepArray)

                        Dim SC As New SqlCacheDependency(UW.SQL.sqlCacheDependencyName, "exp_list")
                        Current.Cache.Insert(CacheName, obj, SC)
                    End If
                End SyncLock
            End If

            Return obj
        End Function



    End Class
End Namespace
