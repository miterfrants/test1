Namespace DB
    Partial Public Class URMUB
        Inherits UW.DB.Record2

        '** 2013/12/13 上午 09:48:51, Set NullWithDefault to False to get exception when the field is null **

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
                Return DB.URMUB.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "ur_mub"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "ur_mub"
            End Get
        End Property

        Public Const FullTableName_Const As String = "ur_mub"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "ur_mub"
            End Get
        End Property

        Public Const IdField_Const As String = "id"

        Public Overrides ReadOnly Property IdField() As String
            Get
                Return "id"
            End Get
        End Property

        ''' <summary>
        ''' $ios=1,android=2
        ''' </summary>
        Public Property device() As Int32
            Get
                If Me.htDirty.Contains("device") Then
                    Return Me.htDirty("device")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("device"))) Then
                    Return 0
                End If
                Return Me.row("device")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("device", Value)
            End Set
        End Property

        Public WriteOnly Property device__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("device", Value)
            End Set
        End Property

        Public WriteOnly Property device__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("device", Value)
            End Set
        End Property

        Public WriteOnly Property device__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("device", Value)
            End Set
        End Property

        Public WriteOnly Property device__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("device", Value)
            End Set
        End Property

        ''' <summary>
        ''' $male=1,female=2
        ''' </summary>
        Public Property sex() As Int32
            Get
                If Me.htDirty.Contains("sex") Then
                    Return Me.htDirty("sex")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("sex"))) Then
                    Return 0
                End If
                Return Me.row("sex")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("sex", Value)
            End Set
        End Property

        Public WriteOnly Property sex__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("sex", Value)
            End Set
        End Property

        Public WriteOnly Property sex__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("sex", Value)
            End Set
        End Property

        Public WriteOnly Property sex__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("sex", Value)
            End Set
        End Property

        Public WriteOnly Property sex__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("sex", Value)
            End Set
        End Property

        ''' <summary>
        ''' $LBS=1,SocialNetwork=2,Communcation=3,Game=4,Reading=5,Music=6
        ''' </summary>
        Public Property cate() As Int32
            Get
                If Me.htDirty.Contains("cate") Then
                    Return Me.htDirty("cate")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("cate"))) Then
                    Return 0
                End If
                Return Me.row("cate")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("cate", Value)
            End Set
        End Property

        Public WriteOnly Property cate__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("cate", Value)
            End Set
        End Property

        Public WriteOnly Property cate__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("cate", Value)
            End Set
        End Property

        Public WriteOnly Property cate__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("cate", Value)
            End Set
        End Property

        Public WriteOnly Property cate__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("cate", Value)
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

        Shared _htTypeDefines As Hashtable
        Shared ReadOnly Property htTypeDefines() As Hashtable
            Get
                If _htTypeDefines Is Nothing Then
                    _htTypeDefines = New Hashtable
                    _htTypeDefines.Add("id", "int")
                    _htTypeDefines.Add("device", "int")
                    _htTypeDefines.Add("sex", "int")
                    _htTypeDefines.Add("cate", "int")
                    _htTypeDefines.Add("created_date", "datetime")
                    _htTypeDefines.Add("latitude", "decimal")
                    _htTypeDefines.Add("longitude", "decimal")
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