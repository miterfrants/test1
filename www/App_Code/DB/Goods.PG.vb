Namespace DB
    Partial Public Class Goods
        Inherits UW.DB.Record2

        '** 2013/10/5 下午 01:36:34, Set NullWithDefault to False to get exception when the field is null **

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
                Return DB.Goods.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "goods"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "goods"
            End Get
        End Property

        Public Const FullTableName_Const As String = "goods"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "goods"
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
        Public Property weight() As Decimal
            Get
                If Me.htDirty.Contains("weight") Then
                    Return Me.htDirty("weight")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("weight"))) Then
                    Return 0
                End If
                Return Me.row("weight")
            End Get
            Set(ByVal Value As Decimal)
                Me.SetField("weight", Value)
            End Set
        End Property

        Public WriteOnly Property weight__Start() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldStart("weight", Value)
            End Set
        End Property

        Public WriteOnly Property weight__End() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldEnd("weight", Value)
            End Set
        End Property

        Public WriteOnly Property weight__StartOrEqual() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldStartOrEqual("weight", Value)
            End Set
        End Property

        Public WriteOnly Property weight__EndOrEqual() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldEndOrEqual("weight", Value)
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


        ''' <summary>
        ''' 
        ''' </summary>
        Public Property size() As Decimal
            Get
                If Me.htDirty.Contains("size") Then
                    Return Me.htDirty("size")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("size"))) Then
                    Return 0
                End If
                Return Me.row("size")
            End Get
            Set(ByVal Value As Decimal)
                Me.SetField("size", Value)
            End Set
        End Property

        Public WriteOnly Property size__Start() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldStart("size", Value)
            End Set
        End Property

        Public WriteOnly Property size__End() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldEnd("size", Value)
            End Set
        End Property

        Public WriteOnly Property size__StartOrEqual() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldStartOrEqual("size", Value)
            End Set
        End Property

        Public WriteOnly Property size__EndOrEqual() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldEndOrEqual("size", Value)
            End Set
        End Property

        Shared _htTypeDefines As Hashtable
        Shared ReadOnly Property htTypeDefines() As Hashtable
            Get
                If _htTypeDefines Is Nothing Then
                    _htTypeDefines = New Hashtable
                    _htTypeDefines.Add("id", "int")
                    _htTypeDefines.Add("name", "nchar")
                    _htTypeDefines.Add("weight", "decimal")
                    _htTypeDefines.Add("description", "nvarchar")
                    _htTypeDefines.Add("size", "decimal")
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