﻿Namespace DB
    Partial Public Class MemberAndBadge
        Inherits UW.DB.Record2

        '** 2013/10/5 下午 03:43:58, Set NullWithDefault to False to get exception when the field is null **

        Public Sub New(ByVal Id As Int32, ByVal Conn As SqlConnection, Optional ByVal ViewName As String = "", Optional ByVal IsReadWithNoLock As Boolean = True, Optional ByVal Fields As String = "*")
            MyBase.New(Id, , Conn, Fields, IsReadWithNoLock, ViewName)
        End Sub

        Public Sub New(ByVal Id As Int32, Optional ByVal ViewName As String = "", Optional ByVal IsReadWithNoLock As Boolean = True, Optional ByVal Fields As String = "*")
            MyBase.New(Id, , , Fields, IsReadWithNoLock, ViewName)
        End Sub

        Public Sub New(ByVal Id As Int32, ByVal Tran As SqlTransaction, Optional ByVal ViewName As String = "", Optional ByVal Fields As String = "*")
            MyBase.New(Id, Tran, , Fields, , ViewName)
        End Sub

        Sub New(ByVal row As DataRow)
            MyBase.New(row)
        End Sub

        Sub New()
        End Sub

        Overrides ReadOnly Property htTypeDefinesForRecord() As Hashtable
            Get
                Return DB.MemberAndBadge.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "member_and_badge"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "member_and_badge"
            End Get
        End Property

        Public Const FullTableName_Const As String = "V_member_and_badge"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "V_member_and_badge"
            End Get
        End Property

        Public Const IdField_Const As String = "id"

        Public Overrides ReadOnly Property IdField() As String
            Get
                Return "id"
            End Get
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property member_id() As Int32
            Get
                If Me.htDirty.Contains("member_id") Then
                    Return Me.htDirty("member_id")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("member_id"))) Then
                    Return 0
                End If
                Return Me.row("member_id")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("member_id", Value)
            End Set
        End Property

        Public WriteOnly Property member_id__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("member_id", Value)
            End Set
        End Property

        Public WriteOnly Property member_id__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("member_id", Value)
            End Set
        End Property

        Public WriteOnly Property member_id__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("member_id", Value)
            End Set
        End Property

        Public WriteOnly Property member_id__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("member_id", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property badge_id() As Int32
            Get
                If Me.htDirty.Contains("badge_id") Then
                    Return Me.htDirty("badge_id")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("badge_id"))) Then
                    Return 0
                End If
                Return Me.row("badge_id")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("badge_id", Value)
            End Set
        End Property

        Public WriteOnly Property badge_id__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("badge_id", Value)
            End Set
        End Property

        Public WriteOnly Property badge_id__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("badge_id", Value)
            End Set
        End Property

        Public WriteOnly Property badge_id__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("badge_id", Value)
            End Set
        End Property

        Public WriteOnly Property badge_id__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("badge_id", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property created_date() As DateTime
            Get
                If Me.htDirty.Contains("created_date") Then
                    Return Me.htDirty("created_date")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("created_date"))) Then
                    Return DateTime.MinValue
                End If
                Return Me.row("created_date")
            End Get
            Set(ByVal Value As DateTime)
                Me.SetField("created_date", Value)
            End Set
        End Property

        Public Function created_dateToString(Format As String) As String
            If Me.htDirty.Contains("created_date") Then
                Return CType(Me.htDirty("created_date"), DateTime).Tostring(Format)
            End If

            If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("created_date"))) Then
                Return ""
            End If
            Return CType(Me.row("created_date"), DateTime).Tostring(Format)
        End Function

        Public WriteOnly Property created_date__Start() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldStart("created_date", Value)
            End Set
        End Property

        Public WriteOnly Property created_date__End() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldEnd("created_date", Value)
            End Set
        End Property

        Public WriteOnly Property created_date__StartOrEqual() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldStartOrEqual("created_date", Value)
            End Set
        End Property

        Public WriteOnly Property created_date__EndOrEqual() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldEndOrEqual("created_date", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property deleted_tf() As DateTime
            Get
                If Me.htDirty.Contains("deleted_tf") Then
                    Return Me.htDirty("deleted_tf")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("deleted_tf"))) Then
                    Return DateTime.MinValue
                End If
                Return Me.row("deleted_tf")
            End Get
            Set(ByVal Value As DateTime)
                Me.SetField("deleted_tf", Value)
            End Set
        End Property

        Public Function deleted_tfToString(Format As String) As String
            If Me.htDirty.Contains("deleted_tf") Then
                Return CType(Me.htDirty("deleted_tf"), DateTime).Tostring(Format)
            End If

            If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("deleted_tf"))) Then
                Return ""
            End If
            Return CType(Me.row("deleted_tf"), DateTime).Tostring(Format)
        End Function

        Public WriteOnly Property deleted_tf__Start() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldStart("deleted_tf", Value)
            End Set
        End Property

        Public WriteOnly Property deleted_tf__End() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldEnd("deleted_tf", Value)
            End Set
        End Property

        Public WriteOnly Property deleted_tf__StartOrEqual() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldStartOrEqual("deleted_tf", Value)
            End Set
        End Property

        Public WriteOnly Property deleted_tf__EndOrEqual() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldEndOrEqual("deleted_tf", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property deleted_reason() As String
            Get
                If Me.htDirty.Contains("deleted_reason") Then
                    Return Me.htDirty("deleted_reason")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("deleted_reason"))) Then
                    Return ""
                End If
                Return Me.row("deleted_reason")
            End Get
            Set(ByVal Value As String)
                Me.SetField("deleted_reason", Value)
            End Set
        End Property

        Public WriteOnly Property deleted_reason__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("deleted_reason", Value)
            End Set
        End Property

        Public WriteOnly Property deleted_reason__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("deleted_reason", Value)
            End Set
        End Property

        Public WriteOnly Property deleted_reason__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("deleted_reason", Value)
            End Set
        End Property

        Public WriteOnly Property deleted_reason__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("deleted_reason", Value)
            End Set
        End Property

        Public WriteOnly Property deleted_reason__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("deleted_reason", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property name() As String
            Get
                If Me.htDirty.Contains("name") Then
                    Return Me.htDirty("name")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("name"))) Then
                    Return ""
                End If
                Return Me.row("name")
            End Get
            Set(ByVal Value As String)
                Me.SetField("name", Value)
            End Set
        End Property

        Public WriteOnly Property name__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("name", Value)
            End Set
        End Property

        Public WriteOnly Property name__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("name", Value)
            End Set
        End Property

        Public WriteOnly Property name__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("name", Value)
            End Set
        End Property

        Public WriteOnly Property name__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("name", Value)
            End Set
        End Property

        Public WriteOnly Property name__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("name", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property description() As String
            Get
                If Me.htDirty.Contains("description") Then
                    Return Me.htDirty("description")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("description"))) Then
                    Return ""
                End If
                Return Me.row("description")
            End Get
            Set(ByVal Value As String)
                Me.SetField("description", Value)
            End Set
        End Property

        Public WriteOnly Property description__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("description", Value)
            End Set
        End Property

        Public WriteOnly Property description__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("description", Value)
            End Set
        End Property

        Public WriteOnly Property description__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("description", Value)
            End Set
        End Property

        Public WriteOnly Property description__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("description", Value)
            End Set
        End Property

        Public WriteOnly Property description__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("description", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property pic() As String
            Get
                If Me.htDirty.Contains("pic") Then
                    Return Me.htDirty("pic")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("pic"))) Then
                    Return ""
                End If
                Return Me.row("pic")
            End Get
            Set(ByVal Value As String)
                Me.SetField("pic", Value)
            End Set
        End Property

        Public WriteOnly Property pic__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("pic", Value)
            End Set
        End Property

        Public WriteOnly Property pic__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("pic", Value)
            End Set
        End Property

        Public WriteOnly Property pic__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("pic", Value)
            End Set
        End Property

        Public WriteOnly Property pic__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("pic", Value)
            End Set
        End Property

        Public WriteOnly Property pic__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("pic", Value)
            End Set
        End Property

        Shared _htTypeDefines As Hashtable
        Shared ReadOnly Property htTypeDefines() As Hashtable
            Get
                If _htTypeDefines Is Nothing Then
                    _htTypeDefines = New Hashtable
                    _htTypeDefines.Add("id", "int")
                    _htTypeDefines.Add("member_id", "int")
                    _htTypeDefines.Add("badge_id", "int")
                    _htTypeDefines.Add("created_date", "datetime")
                    _htTypeDefines.Add("deleted_tf", "datetime")
                    _htTypeDefines.Add("deleted_reason", "nvarchar")
                    _htTypeDefines.Add("name", "nvarchar")
                    _htTypeDefines.Add("description", "nvarchar")
                    _htTypeDefines.Add("pic", "nvarchar")
                End If
                Return _htTypeDefines
            End Get
        End Property









        Shared Function GetAllDataFromFullTable(Optional ByVal OrderFields As String = "") As DataTable
            Dim Sql As String = "Select * from " & FullTableName_Const '因為這是 shared, 所以沒辨法寫在 Record2 裡 ..
            If OrderFields.Length > 0 Then
                Sql &= " Order By " & OrderFields
            End If
            Return UW.SQL.DTFromSQL(Sql)
        End Function


        Shared Function GetAllDataFromBaseTable(Optional ByVal OrderFields As String = "") As DataTable
            Dim Sql As String = "Select * from " & BaseTableName_Const
            If OrderFields.Length > 0 Then
                Sql &= " Order By " & OrderFields
            End If
            Return UW.SQL.DTFromSQL(Sql)
        End Function
    End Class
End Namespace