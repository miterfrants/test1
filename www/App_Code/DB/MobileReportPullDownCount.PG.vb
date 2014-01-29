Namespace DB
    Partial Public Class MobileReportPullDownCount
        Inherits UW.DB.Record2

        '** 2013/11/25 下午 11:33:22, Set NullWithDefault to False to get exception when the field is null **

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
                Return DB.MobileReportPullDownCount.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "mobile_report_pull_down_count"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "mobile_report_pull_down_count"
            End Get
        End Property

        Public Const FullTableName_Const As String = "mobile_report_pull_down_count"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "mobile_report_pull_down_count"
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
        Public Property category() As String
            Get
                If Me.htDirty.Contains("category") Then
                    Return Me.htDirty("category")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("category"))) Then
                    Return ""
                End If
                Return Me.row("category")
            End Get
            Set(ByVal Value As String)
                Me.SetField("category", Value)
            End Set
        End Property

        Public WriteOnly Property category__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("category", Value)
            End Set
        End Property

        Public WriteOnly Property category__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("category", Value)
            End Set
        End Property

        Public WriteOnly Property category__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("category", Value)
            End Set
        End Property

        Public WriteOnly Property category__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("category", Value)
            End Set
        End Property

        Public WriteOnly Property category__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("category", Value)
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
        Public Property creator_ip() As String
            Get
                If Me.htDirty.Contains("creator_ip") Then
                    Return Me.htDirty("creator_ip")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("creator_ip"))) Then
                    Return ""
                End If
                Return Me.row("creator_ip")
            End Get
            Set(ByVal Value As String)
                Me.SetField("creator_ip", Value)
            End Set
        End Property

        Public WriteOnly Property creator_ip__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("creator_ip", Value)
            End Set
        End Property

        Public WriteOnly Property creator_ip__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("creator_ip", Value)
            End Set
        End Property

        Public WriteOnly Property creator_ip__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("creator_ip", Value)
            End Set
        End Property

        Public WriteOnly Property creator_ip__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("creator_ip", Value)
            End Set
        End Property

        Public WriteOnly Property creator_ip__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("creator_ip", Value)
            End Set
        End Property

        Shared _htTypeDefines As Hashtable
        Shared ReadOnly Property htTypeDefines() As Hashtable
            Get
                If _htTypeDefines Is Nothing Then
                    _htTypeDefines = New Hashtable
                    _htTypeDefines.Add("id", "int")
                    _htTypeDefines.Add("category", "nvarchar")
                    _htTypeDefines.Add("created_date", "datetime")
                    _htTypeDefines.Add("creator_ip", "nvarchar")
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