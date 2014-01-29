Namespace DB
    Partial Public Class TempGasStationPlace
        Inherits UW.DB.Record2

        '** 2013/12/10 下午 05:18:26, Set NullWithDefault to False to get exception when the field is null **

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
                Return DB.TempGasStationPlace.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "temp_gas_station_place"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "temp_gas_station_place"
            End Get
        End Property

        Public Const FullTableName_Const As String = "temp_gas_station_place"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "temp_gas_station_place"
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
        Public Property msg() As String
            Get
                If Me.htDirty.Contains("msg") Then
                    Return Me.htDirty("msg")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("msg"))) Then
                    Return ""
                End If
                Return Me.row("msg")
            End Get
            Set(ByVal Value As String)
                Me.SetField("msg", Value)
            End Set
        End Property

        Public WriteOnly Property msg__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("msg", Value)
            End Set
        End Property

        Public WriteOnly Property msg__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("msg", Value)
            End Set
        End Property

        Public WriteOnly Property msg__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("msg", Value)
            End Set
        End Property

        Public WriteOnly Property msg__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("msg", Value)
            End Set
        End Property

        Public WriteOnly Property msg__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("msg", Value)
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
        Public Property update_date() As DateTime
            Get
                If Me.htDirty.Contains("update_date") Then
                    Return Me.htDirty("update_date")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("update_date"))) Then
                    Return DateTime.MinValue
                End If
                Return Me.row("update_date")
            End Get
            Set(ByVal Value As DateTime)
                Me.SetField("update_date", Value)
            End Set
        End Property

        Public Function update_dateToString(Format As String) As String
            If Me.htDirty.Contains("update_date") Then
                Return CType(Me.htDirty("update_date"), DateTime).Tostring(Format)
            End If

            If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("update_date"))) Then
                Return ""
            End If
            Return CType(Me.row("update_date"), DateTime).Tostring(Format)
        End Function

        Public WriteOnly Property update_date__Start() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldStart("update_date", Value)
            End Set
        End Property

        Public WriteOnly Property update_date__End() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldEnd("update_date", Value)
            End Set
        End Property

        Public WriteOnly Property update_date__StartOrEqual() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldStartOrEqual("update_date", Value)
            End Set
        End Property

        Public WriteOnly Property update_date__EndOrEqual() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldEndOrEqual("update_date", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property deleted_count() As Int32
            Get
                If Me.htDirty.Contains("deleted_count") Then
                    Return Me.htDirty("deleted_count")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("deleted_count"))) Then
                    Return 0
                End If
                Return Me.row("deleted_count")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("deleted_count", Value)
            End Set
        End Property

        Public WriteOnly Property deleted_count__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("deleted_count", Value)
            End Set
        End Property

        Public WriteOnly Property deleted_count__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("deleted_count", Value)
            End Set
        End Property

        Public WriteOnly Property deleted_count__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("deleted_count", Value)
            End Set
        End Property

        Public WriteOnly Property deleted_count__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("deleted_count", Value)
            End Set
        End Property

        ''' <summary>
        ''' $中油=1,台塑化=2,北基加油站=3,全國加油站=4,速邁特=5
        ''' </summary>
        Public Property Type() As EN.Type
            Get
                If Me.htDirty.Contains("en_type") Then
                    Return Me.htDirty("en_type")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("en_type"))) Then
                    Return 0
                End If
                Return Me.row("en_type")
            End Get
            Set(ByVal Value As EN.Type)
                Me.SetField("en_type", Value)
            End Set
        End Property

        Public Function Type__Name() As String
            Return HT.Type(Me.Type)
        End Function

        Public Property en_type() As EN.Type
            Get
                If Me.htDirty.Contains("en_type") Then
                    Return Me.htDirty("en_type")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("en_type"))) Then
                End If
                Return Me.row("en_type")
            End Get
            Set(ByVal Value As EN.Type)
                Me.SetField("en_type", Value)
            End Set
        End Property

        Public WriteOnly Property en_type__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("en_type", Value)
            End Set
        End Property

        Public WriteOnly Property en_type__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("en_type", Value)
            End Set
        End Property

        Public WriteOnly Property en_type__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("en_type", Value)
            End Set
        End Property

        Public WriteOnly Property en_type__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("en_type", Value)
            End Set
        End Property

        Shared _htTypeDefines As Hashtable
        Shared ReadOnly Property htTypeDefines() As Hashtable
            Get
                If _htTypeDefines Is Nothing Then
                    _htTypeDefines = New Hashtable
                    _htTypeDefines.Add("id", "int")
                    _htTypeDefines.Add("name", "nvarchar")
                    _htTypeDefines.Add("address", "nvarchar")
                    _htTypeDefines.Add("msg", "nvarchar")
                    _htTypeDefines.Add("latitude", "decimal")
                    _htTypeDefines.Add("longitude", "decimal")
                    _htTypeDefines.Add("update_date", "datetime")
                    _htTypeDefines.Add("deleted_count", "int")
                    _htTypeDefines.Add("en_type", "int")
                End If
                Return _htTypeDefines
            End Get
        End Property

        ''' <summary>
        ''' 使用到的 Enum
        ''' </summary>
        Partial Public Class EN
            '''$中油=1,台塑化=2,北基加油站=3,全國加油站=4,速邁特=5
            Public Enum type
                中油 = 1
                台塑化 = 2
                北基加油站 = 3
                全國加油站 = 4
                速邁樂 = 5
            End Enum

        End Class



        ''' <summary>
        ''' 使用到的 Enum 所產生的 HashTable，用來顯示用。
        ''' </summary>
        Partial Public Class HT
            Private Shared _type As Hashtable
            ''' <summary>
            ''' $中油=1,台塑化=2,北基加油站=3,全國加油站=4,速邁特=5
            ''' </summary>
            Shared Function typeHT() As Hashtable
                If _type Is Nothing Then
                    _type = UW.HashtableFns.HTFromEnum(GetType(EN.type))
                End If
                Return _type
            End Function

            ''' <summary>
            ''' $中油=1,台塑化=2,北基加油站=3,全國加油站=4,速邁特=5
            ''' </summary>
            Shared Function type(ByVal Key As EN.type) As String
                Return typeHT(Key)
            End Function

        End Class



        ''' <summary>
        ''' 使用到的 Enum 所產生的 Array List，用來顯示用。
        ''' </summary>
        Public Class AL
            Private Shared _type As ArrayList = Nothing
            ''' <summary>
            ''' $中油=1,台塑化=2,北基加油站=3,全國加油站=4,速邁特=5
            ''' </summary>
            Public Shared Function type() As ArrayList
                If _type Is Nothing Then
                    _type = UW.ArrayListFns.ALFromEnum(GetType(EN.type))
                End If
                Return _type
            End Function

        End Class





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