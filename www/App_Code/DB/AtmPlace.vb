Imports System.Web.HttpContext
Imports System.Web.Caching

Namespace DB
    Partial Public Class AtmPlace
        Inherits UW.DB.Record2

        Sub SetMatchColumn(ByVal oPH As System.Web.UI.Control, Optional ByVal StoreFilePath As String = "", Optional ByVal IsCreatePath As Boolean = True, Optional ByVal Extension As String = "", Optional ByVal IsKeepOriginalFileName As UW.EN.ThreeSatatBoolean_ForConfig = UW.EN.ThreeSatatBoolean_ForConfig.預設, Optional ByVal FieldsToSetNullWithEmptyString As String = ",,", Optional ByVal FieldsToIgnore As String = ",,", Optional ByVal IsAddTimeStampBeforeOriiginalFileName As Boolean = False, Optional ByVal IsThrowException As Boolean = False)
            UW.FormUtil.SetMatchedColunm(oPH, Me, StoreFilePath, IsCreatePath, Extension, IsKeepOriginalFileName, FieldsToSetNullWithEmptyString, FieldsToIgnore, IsAddTimeStampBeforeOriiginalFileName, IsThrowException)
        End Sub

        Sub LoadMatchedColumn(ByVal oPH As System.Web.UI.Control, Optional ByVal IsThrowExceptionForDDLNotMatch As Boolean = True, Optional ByVal ImageFolderURL As String = "")
            UW.FormUtil.LoadMatchedColumn(oPH, Me, IsThrowExceptionForDDLNotMatch, ImageFolderURL)
        End Sub

        Shared Function GetTotalCount() As Int32
            Return UW.SQL.GetSingleIntWithDefault("Select count(*) from " & DB.AtmPlace.BaseTableName_Const)
        End Function

        Shared Function GetSum(ByVal FieldNames As String) As Int32
            Return UW.SQL.GetSingleIntWithDefault("Select sum(" & FieldNames & ") from " & DB.AtmPlace.BaseTableName_Const)
        End Function

        Public Overrides ReadOnly Property DBC() As String
            Get
                Return Nothing
            End Get
        End Property


        Shared SyncLocker_GetAllDataFromBaseTableWithCache As New Object
        Shared Function GetAllDataFromBaseTableWithCache(Optional ByVal OrderFields As String = "_Default", Optional ByVal IsCopy As Boolean = True) As DataTable
            Dim CacheName As String = "GetAllDataFromBaseTableWithCache_AtmPlace_" & OrderFields
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


        Shared Function GetAtmPlaceFromCachedDT(ByVal Key As String) As DB.AtmPlace
            Dim DT As DataTable = GetAllDataFromBaseTableWithCache()
            Dim Rows As DataRow() = DT.Select(IdField_Const & " = '" & Key.Replace("'", "''") & "'")
            If Rows.Length > 0 Then
                Return New AtmPlace(Rows(0))
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


        Shared Function getPlaceInRadius(ByVal radius As Decimal, ByVal lat As Decimal, ByVal lng As Decimal) As List(Of AtmPlace)
            Dim oAP As New DB.AtmPlace()
            oAP.AddCriteria("latitude <> 0 and geo_location.STDistance(geography::Point(" & lat & "," & lng & ",4326)) <1000")
            Dim list As New List(Of DB.AtmPlace)
            Dim dt As DataTable = oAP.GetQueryDT()
            If dt IsNot Nothing Then
                For i As Int32 = 0 To dt.Rows.Count - 1
                    Dim itemAp As New DB.AtmPlace(dt.Rows(i))
                    list.Add(itemAp)
                Next
            End If
            Return list
        End Function

    End Class
End Namespace
