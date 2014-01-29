Namespace DB
    Partial Public Class PlaceAndCate
        Inherits UW.DB.Record2

        '** 2013/10/1 下午 01:52:29, Set NullWithDefault to False to get exception when the field is null **

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
                Return DB.PlaceAndCate.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "place_and_cate"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "place_and_cate"
            End Get
        End Property

        Public Const FullTableName_Const As String = "place_and_cate"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "place_and_cate"
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
        Public Property place_id() As Int32
            Get
                If Me.htDirty.Contains("place_id") Then
                    Return Me.htDirty("place_id")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("place_id"))) Then
                    Return 0
                End If
                Return Me.row("place_id")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("place_id", Value)
            End Set
        End Property

        Public WriteOnly Property place_id__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("place_id", Value)
            End Set
        End Property

        Public WriteOnly Property place_id__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("place_id", Value)
            End Set
        End Property

        Public WriteOnly Property place_id__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("place_id", Value)
            End Set
        End Property

        Public WriteOnly Property place_id__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("place_id", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property cate_id() As Int32
            Get
                If Me.htDirty.Contains("cate_id") Then
                    Return Me.htDirty("cate_id")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("cate_id"))) Then
                    Return 0
                End If
                Return Me.row("cate_id")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("cate_id", Value)
            End Set
        End Property

        Public WriteOnly Property cate_id__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("cate_id", Value)
            End Set
        End Property

        Public WriteOnly Property cate_id__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("cate_id", Value)
            End Set
        End Property

        Public WriteOnly Property cate_id__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("cate_id", Value)
            End Set
        End Property

        Public WriteOnly Property cate_id__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("cate_id", Value)
            End Set
        End Property

        Shared _htTypeDefines As Hashtable
        Shared ReadOnly Property htTypeDefines() As Hashtable
            Get
                If _htTypeDefines Is Nothing Then
                    _htTypeDefines = New Hashtable
                    _htTypeDefines.Add("id", "int")
                    _htTypeDefines.Add("place_id", "int")
                    _htTypeDefines.Add("cate_id", "int")
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