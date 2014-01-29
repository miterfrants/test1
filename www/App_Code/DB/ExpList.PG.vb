Namespace DB
    Partial Public Class ExpList
        Inherits UW.DB.Record2

        '** 2013/7/26 上午 07:11:18, Set NullWithDefault to False to get exception when the field is null **

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
                Return DB.ExpList.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "exp_list"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "exp_list"
            End Get
        End Property

        Public Const FullTableName_Const As String = "exp_list"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "exp_list"
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
        Public Property exp() As Int32
            Get
                If Me.htDirty.Contains("exp") Then
                    Return Me.htDirty("exp")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("exp"))) Then
                    Return 0
                End If
                Return Me.row("exp")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("exp", Value)
            End Set
        End Property

        Public WriteOnly Property exp__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("exp", Value)
            End Set
        End Property

        Public WriteOnly Property exp__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("exp", Value)
            End Set
        End Property

        Public WriteOnly Property exp__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("exp", Value)
            End Set
        End Property

        Public WriteOnly Property exp__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("exp", Value)
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
        Public Property IsNew() As Boolean
            Get
                If Me.htDirty.Contains("is_new") Then
                    If Me.htDirty("is_new") = "Y" OrElse Me.htDirty("is_new") = "1" Then Return True Else Return False
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("is_new"))) Then
                    Return False
                End If
                If Me.row("is_new") = "Y" OrElse Me.row("is_new") = "1" Then Return True Else Return False
            End Get
            Set(ByVal Value As Boolean)
                If Value Then
                    Me.SetField("is_new", "Y")
                Else
                    Me.SetField("is_new", "N")
                End If
            End Set
        End Property

        Public ReadOnly Property IsNew_Tostring() As String
            Get
                If Me.IsNew Then
                    Return "是"
                End If

                Return "否"
            End Get
        End Property

        Public Property is_new() As String
            Get
                If Me.htDirty.Contains("is_new") Then
                    Return Me.htDirty("is_new")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("is_new"))) Then
                    Return ""
                End If
                Return Me.row("is_new")
            End Get
            Set(ByVal Value As String)
                Me.SetField("is_new", Value)
            End Set
        End Property

        Public WriteOnly Property is_new__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("is_new", Value)
            End Set
        End Property

        Public WriteOnly Property is_new__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("is_new", Value)
            End Set
        End Property

        Public WriteOnly Property is_new__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("is_new", Value)
            End Set
        End Property

        Public WriteOnly Property is_new__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("is_new", Value)
            End Set
        End Property

        Public WriteOnly Property is_new__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("is_new", Value)
            End Set
        End Property

        Shared _htTypeDefines As Hashtable
        Shared ReadOnly Property htTypeDefines() As Hashtable
            Get
                If _htTypeDefines Is Nothing Then
                    _htTypeDefines = New Hashtable
                    _htTypeDefines.Add("id", "int")
                    _htTypeDefines.Add("name", "nvarchar")
                    _htTypeDefines.Add("description", "nvarchar")
                    _htTypeDefines.Add("exp", "int")
                    _htTypeDefines.Add("created_date", "datetime")
                    _htTypeDefines.Add("is_new", "char")
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