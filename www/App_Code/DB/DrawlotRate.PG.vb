Namespace DB
    Partial Public Class DrawlotRate
        Inherits UW.DB.Record2

        '** 2013/11/5 下午 11:32:07, Set NullWithDefault to False to get exception when the field is null **

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
                Return DB.DrawlotRate.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "drawlot_rate"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "drawlot_rate"
            End Get
        End Property

        Public Const FullTableName_Const As String = "V_drawlot_rate"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "V_drawlot_rate"
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
        Public Property goods_id() As Int32
            Get
                If Me.htDirty.Contains("goods_id") Then
                    Return Me.htDirty("goods_id")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("goods_id"))) Then
                    Return 0
                End If
                Return Me.row("goods_id")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("goods_id", Value)
            End Set
        End Property

        Public WriteOnly Property goods_id__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("goods_id", Value)
            End Set
        End Property

        Public WriteOnly Property goods_id__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("goods_id", Value)
            End Set
        End Property

        Public WriteOnly Property goods_id__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("goods_id", Value)
            End Set
        End Property

        Public WriteOnly Property goods_id__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("goods_id", Value)
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
        Public Property place_name_condition() As String
            Get
                If Me.htDirty.Contains("place_name_condition") Then
                    Return Me.htDirty("place_name_condition")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("place_name_condition"))) Then
                    Return ""
                End If
                Return Me.row("place_name_condition")
            End Get
            Set(ByVal Value As String)
                Me.SetField("place_name_condition", Value)
            End Set
        End Property

        Public WriteOnly Property place_name_condition__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("place_name_condition", Value)
            End Set
        End Property

        Public WriteOnly Property place_name_condition__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("place_name_condition", Value)
            End Set
        End Property

        Public WriteOnly Property place_name_condition__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("place_name_condition", Value)
            End Set
        End Property

        Public WriteOnly Property place_name_condition__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("place_name_condition", Value)
            End Set
        End Property

        Public WriteOnly Property place_name_condition__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("place_name_condition", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property date_condition() As String
            Get
                If Me.htDirty.Contains("date_condition") Then
                    Return Me.htDirty("date_condition")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("date_condition"))) Then
                    Return ""
                End If
                Return Me.row("date_condition")
            End Get
            Set(ByVal Value As String)
                Me.SetField("date_condition", Value)
            End Set
        End Property

        Public WriteOnly Property date_condition__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("date_condition", Value)
            End Set
        End Property

        Public WriteOnly Property date_condition__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("date_condition", Value)
            End Set
        End Property

        Public WriteOnly Property date_condition__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("date_condition", Value)
            End Set
        End Property

        Public WriteOnly Property date_condition__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("date_condition", Value)
            End Set
        End Property

        Public WriteOnly Property date_condition__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("date_condition", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property goods_condition() As String
            Get
                If Me.htDirty.Contains("goods_condition") Then
                    Return Me.htDirty("goods_condition")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("goods_condition"))) Then
                    Return ""
                End If
                Return Me.row("goods_condition")
            End Get
            Set(ByVal Value As String)
                Me.SetField("goods_condition", Value)
            End Set
        End Property

        Public WriteOnly Property goods_condition__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("goods_condition", Value)
            End Set
        End Property

        Public WriteOnly Property goods_condition__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("goods_condition", Value)
            End Set
        End Property

        Public WriteOnly Property goods_condition__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("goods_condition", Value)
            End Set
        End Property

        Public WriteOnly Property goods_condition__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("goods_condition", Value)
            End Set
        End Property

        Public WriteOnly Property goods_condition__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("goods_condition", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property rate_level() As Int32
            Get
                If Me.htDirty.Contains("rate_level") Then
                    Return Me.htDirty("rate_level")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("rate_level"))) Then
                    Return 0
                End If
                Return Me.row("rate_level")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("rate_level", Value)
            End Set
        End Property

        Public WriteOnly Property rate_level__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("rate_level", Value)
            End Set
        End Property

        Public WriteOnly Property rate_level__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("rate_level", Value)
            End Set
        End Property

        Public WriteOnly Property rate_level__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("rate_level", Value)
            End Set
        End Property

        Public WriteOnly Property rate_level__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("rate_level", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property memo() As String
            Get
                If Me.htDirty.Contains("memo") Then
                    Return Me.htDirty("memo")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("memo"))) Then
                    Return ""
                End If
                Return Me.row("memo")
            End Get
            Set(ByVal Value As String)
                Me.SetField("memo", Value)
            End Set
        End Property

        Public WriteOnly Property memo__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("memo", Value)
            End Set
        End Property

        Public WriteOnly Property memo__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("memo", Value)
            End Set
        End Property

        Public WriteOnly Property memo__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("memo", Value)
            End Set
        End Property

        Public WriteOnly Property memo__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("memo", Value)
            End Set
        End Property

        Public WriteOnly Property memo__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("memo", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property limit_count() As Int32
            Get
                If Me.htDirty.Contains("limit_count") Then
                    Return Me.htDirty("limit_count")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("limit_count"))) Then
                    Return 0
                End If
                Return Me.row("limit_count")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("limit_count", Value)
            End Set
        End Property

        Public WriteOnly Property limit_count__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("limit_count", Value)
            End Set
        End Property

        Public WriteOnly Property limit_count__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("limit_count", Value)
            End Set
        End Property

        Public WriteOnly Property limit_count__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("limit_count", Value)
            End Set
        End Property

        Public WriteOnly Property limit_count__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("limit_count", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property division() As Int32
            Get
                If Me.htDirty.Contains("division") Then
                    Return Me.htDirty("division")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("division"))) Then
                    Return 0
                End If
                Return Me.row("division")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("division", Value)
            End Set
        End Property

        Public WriteOnly Property division__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("division", Value)
            End Set
        End Property

        Public WriteOnly Property division__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("division", Value)
            End Set
        End Property

        Public WriteOnly Property division__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("division", Value)
            End Set
        End Property

        Public WriteOnly Property division__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("division", Value)
            End Set
        End Property

        Shared _htTypeDefines As Hashtable
        Shared ReadOnly Property htTypeDefines() As Hashtable
            Get
                If _htTypeDefines Is Nothing Then
                    _htTypeDefines = New Hashtable
                    _htTypeDefines.Add("goods_id", "int")
                    _htTypeDefines.Add("id", "int")
                    _htTypeDefines.Add("name", "nvarchar")
                    _htTypeDefines.Add("pic", "nvarchar")
                    _htTypeDefines.Add("description", "nvarchar")
                    _htTypeDefines.Add("place_name_condition", "nvarchar")
                    _htTypeDefines.Add("date_condition", "nvarchar")
                    _htTypeDefines.Add("goods_condition", "nvarchar")
                    _htTypeDefines.Add("rate_level", "int")
                    _htTypeDefines.Add("memo", "nvarchar")
                    _htTypeDefines.Add("limit_count", "int")
                    _htTypeDefines.Add("division", "int")
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