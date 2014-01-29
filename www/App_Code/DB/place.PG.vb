Namespace DB
    Partial Public Class Place
        Inherits UW.DB.Record2

        '** 2013/8/8 上午 12:47:03, Set NullWithDefault to False to get exception when the field is null **

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
                Return DB.Place.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "Place"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "Place"
            End Get
        End Property

        Public Const FullTableName_Const As String = "Place"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "Place"
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
        Public Property rating() As Decimal
            Get
                If Me.htDirty.Contains("rating") Then
                    Return Me.htDirty("rating")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("rating"))) Then
                    Return 0
                End If
                Return Me.row("rating")
            End Get
            Set(ByVal Value As Decimal)
                Me.SetField("rating", Value)
            End Set
        End Property

        Public WriteOnly Property rating__Start() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldStart("rating", Value)
            End Set
        End Property

        Public WriteOnly Property rating__End() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldEnd("rating", Value)
            End Set
        End Property

        Public WriteOnly Property rating__StartOrEqual() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldStartOrEqual("rating", Value)
            End Set
        End Property

        Public WriteOnly Property rating__EndOrEqual() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldEndOrEqual("rating", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property address() As String
            Get
                If Me.htDirty.Contains("address") Then
                    Return Me.htDirty("address")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("address"))) Then
                    Return ""
                End If
                Return Me.row("address")
            End Get
            Set(ByVal Value As String)
                Me.SetField("address", Value)
            End Set
        End Property

        Public WriteOnly Property address__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("address", Value)
            End Set
        End Property

        Public WriteOnly Property address__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("address", Value)
            End Set
        End Property

        Public WriteOnly Property address__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("address", Value)
            End Set
        End Property

        Public WriteOnly Property address__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("address", Value)
            End Set
        End Property

        Public WriteOnly Property address__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("address", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property tel() As String
            Get
                If Me.htDirty.Contains("tel") Then
                    Return Me.htDirty("tel")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("tel"))) Then
                    Return ""
                End If
                Return Me.row("tel")
            End Get
            Set(ByVal Value As String)
                Me.SetField("tel", Value)
            End Set
        End Property

        Public WriteOnly Property tel__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("tel", Value)
            End Set
        End Property

        Public WriteOnly Property tel__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("tel", Value)
            End Set
        End Property

        Public WriteOnly Property tel__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("tel", Value)
            End Set
        End Property

        Public WriteOnly Property tel__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("tel", Value)
            End Set
        End Property

        Public WriteOnly Property tel__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("tel", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property open_time() As String
            Get
                If Me.htDirty.Contains("open_time") Then
                    Return Me.htDirty("open_time")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("open_time"))) Then
                    Return ""
                End If
                Return Me.row("open_time")
            End Get
            Set(ByVal Value As String)
                Me.SetField("open_time", Value)
            End Set
        End Property

        Public WriteOnly Property open_time__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("open_time", Value)
            End Set
        End Property

        Public WriteOnly Property open_time__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("open_time", Value)
            End Set
        End Property

        Public WriteOnly Property open_time__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("open_time", Value)
            End Set
        End Property

        Public WriteOnly Property open_time__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("open_time", Value)
            End Set
        End Property

        Public WriteOnly Property open_time__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("open_time", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property close_time() As String
            Get
                If Me.htDirty.Contains("close_time") Then
                    Return Me.htDirty("close_time")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("close_time"))) Then
                    Return ""
                End If
                Return Me.row("close_time")
            End Get
            Set(ByVal Value As String)
                Me.SetField("close_time", Value)
            End Set
        End Property

        Public WriteOnly Property close_time__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("close_time", Value)
            End Set
        End Property

        Public WriteOnly Property close_time__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("close_time", Value)
            End Set
        End Property

        Public WriteOnly Property close_time__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("close_time", Value)
            End Set
        End Property

        Public WriteOnly Property close_time__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("close_time", Value)
            End Set
        End Property

        Public WriteOnly Property close_time__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("close_time", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property reference() As String
            Get
                If Me.htDirty.Contains("reference") Then
                    Return Me.htDirty("reference")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("reference"))) Then
                    Return ""
                End If
                Return Me.row("reference")
            End Get
            Set(ByVal Value As String)
                Me.SetField("reference", Value)
            End Set
        End Property

        Public WriteOnly Property reference__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("reference", Value)
            End Set
        End Property

        Public WriteOnly Property reference__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("reference", Value)
            End Set
        End Property

        Public WriteOnly Property reference__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("reference", Value)
            End Set
        End Property

        Public WriteOnly Property reference__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("reference", Value)
            End Set
        End Property

        Public WriteOnly Property reference__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("reference", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property main_cate_id() As Int32
            Get
                If Me.htDirty.Contains("main_cate_id") Then
                    Return Me.htDirty("main_cate_id")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("main_cate_id"))) Then
                    Return 0
                End If
                Return Me.row("main_cate_id")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("main_cate_id", Value)
            End Set
        End Property

        Public WriteOnly Property main_cate_id__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("main_cate_id", Value)
            End Set
        End Property

        Public WriteOnly Property main_cate_id__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("main_cate_id", Value)
            End Set
        End Property

        Public WriteOnly Property main_cate_id__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("main_cate_id", Value)
            End Set
        End Property

        Public WriteOnly Property main_cate_id__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("main_cate_id", Value)
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
        Public Property google_id() As String
            Get
                If Me.htDirty.Contains("google_id") Then
                    Return Me.htDirty("google_id")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("google_id"))) Then
                    Return ""
                End If
                Return Me.row("google_id")
            End Get
            Set(ByVal Value As String)
                Me.SetField("google_id", Value)
            End Set
        End Property

        Public WriteOnly Property google_id__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("google_id", Value)
            End Set
        End Property

        Public WriteOnly Property google_id__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("google_id", Value)
            End Set
        End Property

        Public WriteOnly Property google_id__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("google_id", Value)
            End Set
        End Property

        Public WriteOnly Property google_id__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("google_id", Value)
            End Set
        End Property

        Public WriteOnly Property google_id__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("google_id", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property pre_data_id() As Int32
            Get
                If Me.htDirty.Contains("pre_data_id") Then
                    Return Me.htDirty("pre_data_id")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("pre_data_id"))) Then
                    Return 0
                End If
                Return Me.row("pre_data_id")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("pre_data_id", Value)
            End Set
        End Property

        Public WriteOnly Property pre_data_id__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("pre_data_id", Value)
            End Set
        End Property

        Public WriteOnly Property pre_data_id__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("pre_data_id", Value)
            End Set
        End Property

        Public WriteOnly Property pre_data_id__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("pre_data_id", Value)
            End Set
        End Property

        Public WriteOnly Property pre_data_id__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("pre_data_id", Value)
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
                    _htTypeDefines.Add("rating", "decimal")
                    _htTypeDefines.Add("address", "nvarchar")
                    _htTypeDefines.Add("tel", "nvarchar")
                    _htTypeDefines.Add("open_time", "nvarchar")
                    _htTypeDefines.Add("close_time", "nvarchar")
                    _htTypeDefines.Add("reference", "nvarchar")
                    _htTypeDefines.Add("main_cate_id", "int")
                    _htTypeDefines.Add("latitude", "decimal")
                    _htTypeDefines.Add("longitude", "decimal")
                    _htTypeDefines.Add("google_id", "nvarchar")
                    _htTypeDefines.Add("pre_data_id", "int")
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