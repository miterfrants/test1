Namespace DB
    Partial Public Class Category
        Inherits UW.DB.Record2

        '** 2013/8/8 下午 11:56:21, Set NullWithDefault to False to get exception when the field is null **

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
                Return DB.Category.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "category"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "category"
            End Get
        End Property

        Public Const FullTableName_Const As String = "category"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "category"
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
        Public Property stay() As Int32
            Get
                If Me.htDirty.Contains("stay") Then
                    Return Me.htDirty("stay")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("stay"))) Then
                    Return 0
                End If
                Return Me.row("stay")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("stay", Value)
            End Set
        End Property

        Public WriteOnly Property stay__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("stay", Value)
            End Set
        End Property

        Public WriteOnly Property stay__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("stay", Value)
            End Set
        End Property

        Public WriteOnly Property stay__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("stay", Value)
            End Set
        End Property

        Public WriteOnly Property stay__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("stay", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property cate_trav_id() As Int32
            Get
                If Me.htDirty.Contains("cate_trav_id") Then
                    Return Me.htDirty("cate_trav_id")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("cate_trav_id"))) Then
                    Return 0
                End If
                Return Me.row("cate_trav_id")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("cate_trav_id", Value)
            End Set
        End Property

        Public WriteOnly Property cate_trav_id__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("cate_trav_id", Value)
            End Set
        End Property

        Public WriteOnly Property cate_trav_id__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("cate_trav_id", Value)
            End Set
        End Property

        Public WriteOnly Property cate_trav_id__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("cate_trav_id", Value)
            End Set
        End Property

        Public WriteOnly Property cate_trav_id__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("cate_trav_id", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property sce1() As Int32
            Get
                If Me.htDirty.Contains("sce1") Then
                    Return Me.htDirty("sce1")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("sce1"))) Then
                    Return 0
                End If
                Return Me.row("sce1")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("sce1", Value)
            End Set
        End Property

        Public WriteOnly Property sce1__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("sce1", Value)
            End Set
        End Property

        Public WriteOnly Property sce1__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("sce1", Value)
            End Set
        End Property

        Public WriteOnly Property sce1__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("sce1", Value)
            End Set
        End Property

        Public WriteOnly Property sce1__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("sce1", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property sce2() As Int32
            Get
                If Me.htDirty.Contains("sce2") Then
                    Return Me.htDirty("sce2")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("sce2"))) Then
                    Return 0
                End If
                Return Me.row("sce2")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("sce2", Value)
            End Set
        End Property

        Public WriteOnly Property sce2__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("sce2", Value)
            End Set
        End Property

        Public WriteOnly Property sce2__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("sce2", Value)
            End Set
        End Property

        Public WriteOnly Property sce2__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("sce2", Value)
            End Set
        End Property

        Public WriteOnly Property sce2__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("sce2", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property sce3() As Int32
            Get
                If Me.htDirty.Contains("sce3") Then
                    Return Me.htDirty("sce3")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("sce3"))) Then
                    Return 0
                End If
                Return Me.row("sce3")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("sce3", Value)
            End Set
        End Property

        Public WriteOnly Property sce3__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("sce3", Value)
            End Set
        End Property

        Public WriteOnly Property sce3__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("sce3", Value)
            End Set
        End Property

        Public WriteOnly Property sce3__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("sce3", Value)
            End Set
        End Property

        Public WriteOnly Property sce3__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("sce3", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property sce4() As Int32
            Get
                If Me.htDirty.Contains("sce4") Then
                    Return Me.htDirty("sce4")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("sce4"))) Then
                    Return 0
                End If
                Return Me.row("sce4")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("sce4", Value)
            End Set
        End Property

        Public WriteOnly Property sce4__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("sce4", Value)
            End Set
        End Property

        Public WriteOnly Property sce4__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("sce4", Value)
            End Set
        End Property

        Public WriteOnly Property sce4__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("sce4", Value)
            End Set
        End Property

        Public WriteOnly Property sce4__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("sce4", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property sce5() As Int32
            Get
                If Me.htDirty.Contains("sce5") Then
                    Return Me.htDirty("sce5")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("sce5"))) Then
                    Return 0
                End If
                Return Me.row("sce5")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("sce5", Value)
            End Set
        End Property

        Public WriteOnly Property sce5__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("sce5", Value)
            End Set
        End Property

        Public WriteOnly Property sce5__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("sce5", Value)
            End Set
        End Property

        Public WriteOnly Property sce5__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("sce5", Value)
            End Set
        End Property

        Public WriteOnly Property sce5__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("sce5", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property sce6() As Int32
            Get
                If Me.htDirty.Contains("sce6") Then
                    Return Me.htDirty("sce6")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("sce6"))) Then
                    Return 0
                End If
                Return Me.row("sce6")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("sce6", Value)
            End Set
        End Property

        Public WriteOnly Property sce6__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("sce6", Value)
            End Set
        End Property

        Public WriteOnly Property sce6__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("sce6", Value)
            End Set
        End Property

        Public WriteOnly Property sce6__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("sce6", Value)
            End Set
        End Property

        Public WriteOnly Property sce6__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("sce6", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property sce7() As Int32
            Get
                If Me.htDirty.Contains("sce7") Then
                    Return Me.htDirty("sce7")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("sce7"))) Then
                    Return 0
                End If
                Return Me.row("sce7")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("sce7", Value)
            End Set
        End Property

        Public WriteOnly Property sce7__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("sce7", Value)
            End Set
        End Property

        Public WriteOnly Property sce7__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("sce7", Value)
            End Set
        End Property

        Public WriteOnly Property sce7__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("sce7", Value)
            End Set
        End Property

        Public WriteOnly Property sce7__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("sce7", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property sce8() As Int32
            Get
                If Me.htDirty.Contains("sce8") Then
                    Return Me.htDirty("sce8")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("sce8"))) Then
                    Return 0
                End If
                Return Me.row("sce8")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("sce8", Value)
            End Set
        End Property

        Public WriteOnly Property sce8__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("sce8", Value)
            End Set
        End Property

        Public WriteOnly Property sce8__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("sce8", Value)
            End Set
        End Property

        Public WriteOnly Property sce8__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("sce8", Value)
            End Set
        End Property

        Public WriteOnly Property sce8__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("sce8", Value)
            End Set
        End Property

        Shared _htTypeDefines As Hashtable
        Shared ReadOnly Property htTypeDefines() As Hashtable
            Get
                If _htTypeDefines Is Nothing Then
                    _htTypeDefines = New Hashtable
                    _htTypeDefines.Add("id", "int")
                    _htTypeDefines.Add("name", "nvarchar")
                    _htTypeDefines.Add("stay", "int")
                    _htTypeDefines.Add("cate_trav_id", "int")
                    _htTypeDefines.Add("sce1", "bit")
                    _htTypeDefines.Add("sce2", "bit")
                    _htTypeDefines.Add("sce3", "bit")
                    _htTypeDefines.Add("sce4", "bit")
                    _htTypeDefines.Add("sce5", "bit")
                    _htTypeDefines.Add("sce6", "bit")
                    _htTypeDefines.Add("sce7", "bit")
                    _htTypeDefines.Add("sce8", "bit")
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