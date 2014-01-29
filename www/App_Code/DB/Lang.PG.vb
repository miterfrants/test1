Namespace DB
    Partial Public Class Lang
        Inherits UW.DB.Record2

        '** 2013/7/27 下午 03:53:28, Set NullWithDefault to False to get exception when the field is null **

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
                Return DB.Lang.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "lang"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "lang"
            End Get
        End Property

        Public Const FullTableName_Const As String = "lang"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "lang"
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
        Public Property abbr() As String
            Get
                If Me.htDirty.Contains("abbr") Then
                    Return Me.htDirty("abbr")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("abbr"))) Then
                    Return ""
                End If
                Return Me.row("abbr")
            End Get
            Set(ByVal Value As String)
                Me.SetField("abbr", Value)
            End Set
        End Property

        Public WriteOnly Property abbr__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("abbr", Value)
            End Set
        End Property

        Public WriteOnly Property abbr__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("abbr", Value)
            End Set
        End Property

        Public WriteOnly Property abbr__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("abbr", Value)
            End Set
        End Property

        Public WriteOnly Property abbr__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("abbr", Value)
            End Set
        End Property

        Public WriteOnly Property abbr__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("abbr", Value)
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

        Shared _htTypeDefines As Hashtable
        Shared ReadOnly Property htTypeDefines() As Hashtable
            Get
                If _htTypeDefines Is Nothing Then
                    _htTypeDefines = New Hashtable
                    _htTypeDefines.Add("id", "int")
                    _htTypeDefines.Add("abbr", "nvarchar")
                    _htTypeDefines.Add("name", "nvarchar")
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