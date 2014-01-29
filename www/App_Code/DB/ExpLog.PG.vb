Namespace DB
    Partial Public Class ExpLog
        Inherits UW.DB.Record2

        '** 2013/7/26 上午 07:12:18, Set NullWithDefault to False to get exception when the field is null **

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
                Return DB.ExpLog.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "exp_log"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "exp_log"
            End Get
        End Property

        Public Const FullTableName_Const As String = "exp_log"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "exp_log"
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

        Shared _htTypeDefines As Hashtable
        Shared ReadOnly Property htTypeDefines() As Hashtable
            Get
                If _htTypeDefines Is Nothing Then
                    _htTypeDefines = New Hashtable
                    _htTypeDefines.Add("id", "int")
                    _htTypeDefines.Add("member_id", "int")
                    _htTypeDefines.Add("exp", "int")
                    _htTypeDefines.Add("created_date", "datetime")
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