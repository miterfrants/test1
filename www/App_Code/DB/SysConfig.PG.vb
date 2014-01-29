Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Namespace DB
    Partial Public Class SysConfig
        Inherits UW.DB.Record2

        '** 2013/7/10 下午 10:59:06, Set NullWithDefault to False to get exception when the field is null **

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
                Return DB.SysConfig.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "sys_config"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "sys_config"
            End Get
        End Property

        Public Const FullTableName_Const As String = "sys_config"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "sys_config"
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
        Public Property name() As String
            Get
                If Me.htDirty.Contains("name") Then
                    Return Me.htDirty("name")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse Me.row("name") Is DBNull.Value) Then
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
        Public Property content() As String
            Get
                If Me.htDirty.Contains("content") Then
                    Return Me.htDirty("content")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse Me.row("content") Is DBNull.Value) Then
                    Return ""
                End If
                Return Me.row("content")
            End Get
            Set(ByVal Value As String)
                Me.SetField("content", Value)
            End Set
        End Property

        Public WriteOnly Property content__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("content", Value)
            End Set
        End Property

        Public WriteOnly Property content__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("content", Value)
            End Set
        End Property

        Public WriteOnly Property content__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("content", Value)
            End Set
        End Property

        Public WriteOnly Property content__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("content", Value)
            End Set
        End Property

        Public WriteOnly Property content__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("content", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property desc() As String
            Get
                If Me.htDirty.Contains("desc") Then
                    Return Me.htDirty("desc")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse Me.row("desc") Is DBNull.Value) Then
                    Return ""
                End If
                Return Me.row("desc")
            End Get
            Set(ByVal Value As String)
                Me.SetField("desc", Value)
            End Set
        End Property

        Public WriteOnly Property desc__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("desc", Value)
            End Set
        End Property

        Public WriteOnly Property desc__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("desc", Value)
            End Set
        End Property

        Public WriteOnly Property desc__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("desc", Value)
            End Set
        End Property

        Public WriteOnly Property desc__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("desc", Value)
            End Set
        End Property

        Public WriteOnly Property desc__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("desc", Value)
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

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse Me.row("deleted_tf") Is DBNull.Value) Then
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

            If NullWithDefault AndAlso (Me.row Is Nothing OrElse Me.row("deleted_tf") Is DBNull.Value) Then
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

        Shared _htTypeDefines As Hashtable
        Shared ReadOnly Property htTypeDefines() As Hashtable
            Get
                If _htTypeDefines Is Nothing Then
                    _htTypeDefines = New Hashtable
                    _htTypeDefines.Add("id", "int")
                    _htTypeDefines.Add("name", "nvarchar")
                    _htTypeDefines.Add("content", "ntext")
                    _htTypeDefines.Add("desc", "ntext")
                    _htTypeDefines.Add("deleted_tf", "datetime")
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