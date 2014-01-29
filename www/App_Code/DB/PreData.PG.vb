Namespace DB
    Partial Public Class PreData
        Inherits UW.DB.Record2

        '** 2013/8/7 下午 10:43:25, Set NullWithDefault to False to get exception when the field is null **

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
                Return DB.PreData.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "pre_data"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "pre_data"
            End Get
        End Property

        Public Const FullTableName_Const As String = "pre_data"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "pre_data"
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
        Public Property latitude() As Decimal
            Get
                If Me.htDirty.Contains("latitude") Then
                    Return Me.htDirty("latitude")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("latitude"))) Then
                    Return 0
                End If
                Return Me.row("latitude")
            End Get
            Set(ByVal Value As Decimal)
                Me.SetField("latitude", Value)
            End Set
        End Property

        Public WriteOnly Property latitude__Start() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldStart("latitude", Value)
            End Set
        End Property

        Public WriteOnly Property latitude__End() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldEnd("latitude", Value)
            End Set
        End Property

        Public WriteOnly Property latitude__StartOrEqual() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldStartOrEqual("latitude", Value)
            End Set
        End Property

        Public WriteOnly Property latitude__EndOrEqual() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldEndOrEqual("latitude", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property longitude() As Decimal
            Get
                If Me.htDirty.Contains("longitude") Then
                    Return Me.htDirty("longitude")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("longitude"))) Then
                    Return 0
                End If
                Return Me.row("longitude")
            End Get
            Set(ByVal Value As Decimal)
                Me.SetField("longitude", Value)
            End Set
        End Property

        Public WriteOnly Property longitude__Start() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldStart("longitude", Value)
            End Set
        End Property

        Public WriteOnly Property longitude__End() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldEnd("longitude", Value)
            End Set
        End Property

        Public WriteOnly Property longitude__StartOrEqual() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldStartOrEqual("longitude", Value)
            End Set
        End Property

        Public WriteOnly Property longitude__EndOrEqual() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldEndOrEqual("longitude", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property area_name() As String
            Get
                If Me.htDirty.Contains("area_name") Then
                    Return Me.htDirty("area_name")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("area_name"))) Then
                    Return ""
                End If
                Return Me.row("area_name")
            End Get
            Set(ByVal Value As String)
                Me.SetField("area_name", Value)
            End Set
        End Property

        Public WriteOnly Property area_name__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("area_name", Value)
            End Set
        End Property

        Public WriteOnly Property area_name__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("area_name", Value)
            End Set
        End Property

        Public WriteOnly Property area_name__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("area_name", Value)
            End Set
        End Property

        Public WriteOnly Property area_name__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("area_name", Value)
            End Set
        End Property

        Public WriteOnly Property area_name__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("area_name", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property check_count() As Int32
            Get
                If Me.htDirty.Contains("check_count") Then
                    Return Me.htDirty("check_count")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("check_count"))) Then
                    Return 0
                End If
                Return Me.row("check_count")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("check_count", Value)
            End Set
        End Property

        Public WriteOnly Property check_count__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("check_count", Value)
            End Set
        End Property

        Public WriteOnly Property check_count__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("check_count", Value)
            End Set
        End Property

        Public WriteOnly Property check_count__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("check_count", Value)
            End Set
        End Property

        Public WriteOnly Property check_count__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("check_count", Value)
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
                    _htTypeDefines.Add("latitude", "decimal")
                    _htTypeDefines.Add("longitude", "decimal")
                    _htTypeDefines.Add("area_name", "nvarchar")
                    _htTypeDefines.Add("check_count", "int")
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