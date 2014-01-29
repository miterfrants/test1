Imports System.Web.HttpContext
Imports System.Web.Caching
Imports System
Imports System.Data
Imports System.Collections
Namespace DB
    Partial Public Class Member
        Inherits UW.DB.Record2

        Sub SetMatchColumn(ByVal oPH As System.Web.UI.Control, Optional ByVal StoreFilePath As String = "", Optional ByVal IsCreatePath As Boolean = True, Optional ByVal Extension As String = "", Optional ByVal IsKeepOriginalFileName As UW.EN.ThreeSatatBoolean_ForConfig = UW.EN.ThreeSatatBoolean_ForConfig.預設, Optional ByVal FieldsToSetNullWithEmptyString As String = ",,", Optional ByVal FieldsToIgnore As String = ",,", Optional ByVal IsAddTimeStampBeforeOriiginalFileName As Boolean = False, Optional ByVal IsThrowException As Boolean = False)
            UW.FormUtil.SetMatchedColunm(oPH, Me, StoreFilePath, IsCreatePath, Extension, IsKeepOriginalFileName, FieldsToSetNullWithEmptyString, FieldsToIgnore, IsAddTimeStampBeforeOriiginalFileName, IsThrowException)
        End Sub

        Sub LoadMatchedColumn(ByVal oPH As System.Web.UI.Control, Optional ByVal IsThrowExceptionForDDLNotMatch As Boolean = True, Optional ByVal ImageFolderURL As String = "")
            UW.FormUtil.LoadMatchedColumn(oPH, Me, IsThrowExceptionForDDLNotMatch, ImageFolderURL)
        End Sub

        Shared Function GetTotalCount() As Int32
            Return UW.SQL.GetSingleIntWithDefault("Select count(*) from " & DB.Member.BaseTableName_Const)
        End Function

        Shared Function GetSum(ByVal FieldNames As String) As Int32
            Return UW.SQL.GetSingleIntWithDefault("Select sum(" & FieldNames & ") from " & DB.Member.BaseTableName_Const)
        End Function

        Public Overrides ReadOnly Property DBC() As String
            Get
                Return Nothing
            End Get
        End Property

        Public Class EN
            Public Enum Source
                Facebook = 1
                Yahoo = 2
                Twitter = 3
                Google = 4
            End Enum

         
        End Class
        


        Shared SyncLocker_GetAllDataFromBaseTableWithCache As New Object
        Shared Function GetAllDataFromBaseTableWithCache(Optional ByVal OrderFields As String = "_Default", Optional ByVal IsCopy As Boolean = True) As DataTable
            Dim CacheName As String = "GetAllDataFromBaseTableWithCache_Member_" & OrderFields
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


        Shared Function GetMemberFromCachedDT(ByVal Key As String) As DB.Member
            Dim DT As DataTable = GetAllDataFromBaseTableWithCache()
            Dim Rows As DataRow() = DT.Select(IdField_Const & " = '" & Key.Replace("'", "''") & "'")
            If Rows.Length > 0 Then
                Return New Member(Rows(0))
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

        Public Function getProfilePicture() As String
            If Me.en_source = EN.Source.Facebook Then
                Return "<img class=""lazy"" src=""../img/grey.gif"" data-original=""http://graph.facebook.com/" & Me.outer_id & "/picture?width=40&height=40""/>"
            ElseIf Me.en_source = EN.Source.Twitter Then
                Return "<img class=""lazy"" src=""../img/grey.gif"" data-original=""" & Me.profile & """ style=""margin:-4px 0 0 -4px;""/>"
            Else
                Return "<img class=""lazy"" src=""../img/grey.gif"" data-original=""https://plus.google.com/s2/photos/profile/" & Me.outer_id & "?sz=40""/>"
            End If
        End Function

        Public Overloads Function insert(Optional ByRef tran As SqlTransaction = Nothing) As Int32
            Dim dicExpList As Dictionary(Of String, Int32) = DB.ExpList.getDicExpList()
            Dim exp As Int32 = 0
            If Me.email.Length > 0 AndAlso dicExpList.ContainsKey("member_email") Then
                exp += dicExpList("member_email")
            End If
            If Me.first_name.Length > 0 AndAlso dicExpList.ContainsKey("member_first_name") Then
                exp += dicExpList("member_first_name")
            End If
            If Me.last_name.Length > 0 AndAlso dicExpList.ContainsKey("member_last_name") Then
                exp += dicExpList("member_last_name")
            End If
            If Me.country_id > 0 AndAlso dicExpList.ContainsKey("member_country_id") Then
                exp += dicExpList("member_country_id")
            End If
            If Me.en_gender > 0 AndAlso dicExpList.ContainsKey("member_en_gender") Then
                exp += dicExpList("member_en_gender")
            End If
            If Me.address.Length > 0 AndAlso dicExpList.ContainsKey("member_address") Then
                exp += dicExpList("member_address")
            End If
            If Me.phone.Length > 0 AndAlso dicExpList.ContainsKey("member_phone") Then
                exp += dicExpList("member_phone")
            End If
            If Me.link.Length > 0 AndAlso dicExpList.ContainsKey("member_link") Then
                exp += dicExpList("member_link")
            End If
            If Me.howetown.Length > 0 AndAlso dicExpList.ContainsKey("member_home_town") Then
                exp += dicExpList("member_home_town")
            End If

            If Me.location.Length > 0 AndAlso dicExpList.ContainsKey("member_location") Then
                exp += dicExpList("member_location")
            End If
            If Me.birthday > DateTime.MinValue AndAlso dicExpList.ContainsKey("member_birthday") Then
                exp += dicExpList("member_birthday")
            End If
            If Me.lang_id > 0 AndAlso dicExpList.ContainsKey("member_lang_id") Then
                exp += dicExpList("member_lang_id")
            End If
            Dim oEL As New DB.ExpLog()
            Dim member_id As Int32 = -1
            If tran Is Nothing Then
                Dim Conn As SqlConnection = UW.SQL.GetOpenedConnection
                Dim Tran1 As SqlTransaction = Conn.BeginTransaction
                Try
                    member_id = MyBase.Insert(Tran1)
                    oEL.member_id = member_id
                    oEL.exp += exp
                    oEL.Insert(Tran1)
                    Tran1.Commit()
                Catch ex As Exception
                    '如果在加log 發生錯誤用email回報 peter modify
                    Tran1.Rollback()
                Finally
                    If Conn.State <> ConnectionState.Closed Then
                        Conn.Close()
                    End If
                End Try
            Else
                member_id = MyBase.Insert(tran)
                oEL.member_id = member_id
                oEL.exp += exp
                oEL.Insert(tran)
            End If
            Return member_id
        End Function


        Sub addExp(ByVal expName As String, Optional ByVal tran As SqlTransaction = Nothing)
            Dim dicExpList As Dictionary(Of String, Int32) = DB.ExpList.getDicExpList()
            If dicExpList.ContainsKey(expName) Then
                Dim oEL As New DB.ExpLog()
                Me.exp += dicExpList(expName)
                oEL.exp = Me.exp
                oEL.member_id = Me.Id
                oEL.Insert(tran)
            End If
        End Sub
    End Class
End Namespace
