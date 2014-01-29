Namespace DB
    Partial Public Class TempPlace
        Inherits UW.DB.Record2

        '** 2013/10/2 下午 09:24:41, Set NullWithDefault to False to get exception when the field is null **

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
                Return DB.TempPlace.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "temp_place"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "temp_place"
            End Get
        End Property

        Public Const FullTableName_Const As String = "temp_place"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "temp_place"
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
        Public Property google_description() As String
            Get
                If Me.htDirty.Contains("google_description") Then
                    Return Me.htDirty("google_description")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("google_description"))) Then
                    Return ""
                End If
                Return Me.row("google_description")
            End Get
            Set(ByVal Value As String)
                Me.SetField("google_description", Value)
            End Set
        End Property

        Public WriteOnly Property google_description__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("google_description", Value)
            End Set
        End Property

        Public WriteOnly Property google_description__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("google_description", Value)
            End Set
        End Property

        Public WriteOnly Property google_description__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("google_description", Value)
            End Set
        End Property

        Public WriteOnly Property google_description__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("google_description", Value)
            End Set
        End Property

        Public WriteOnly Property google_description__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("google_description", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property google_rating() As String
            Get
                If Me.htDirty.Contains("google_rating") Then
                    Return Me.htDirty("google_rating")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("google_rating"))) Then
                    Return ""
                End If
                Return Me.row("google_rating")
            End Get
            Set(ByVal Value As String)
                Me.SetField("google_rating", Value)
            End Set
        End Property

        Public WriteOnly Property google_rating__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("google_rating", Value)
            End Set
        End Property

        Public WriteOnly Property google_rating__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("google_rating", Value)
            End Set
        End Property

        Public WriteOnly Property google_rating__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("google_rating", Value)
            End Set
        End Property

        Public WriteOnly Property google_rating__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("google_rating", Value)
            End Set
        End Property

        Public WriteOnly Property google_rating__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("google_rating", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property google_reference() As String
            Get
                If Me.htDirty.Contains("google_reference") Then
                    Return Me.htDirty("google_reference")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("google_reference"))) Then
                    Return ""
                End If
                Return Me.row("google_reference")
            End Get
            Set(ByVal Value As String)
                Me.SetField("google_reference", Value)
            End Set
        End Property

        Public WriteOnly Property google_reference__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("google_reference", Value)
            End Set
        End Property

        Public WriteOnly Property google_reference__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("google_reference", Value)
            End Set
        End Property

        Public WriteOnly Property google_reference__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("google_reference", Value)
            End Set
        End Property

        Public WriteOnly Property google_reference__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("google_reference", Value)
            End Set
        End Property

        Public WriteOnly Property google_reference__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("google_reference", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property google_phone() As String
            Get
                If Me.htDirty.Contains("google_phone") Then
                    Return Me.htDirty("google_phone")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("google_phone"))) Then
                    Return ""
                End If
                Return Me.row("google_phone")
            End Get
            Set(ByVal Value As String)
                Me.SetField("google_phone", Value)
            End Set
        End Property

        Public WriteOnly Property google_phone__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("google_phone", Value)
            End Set
        End Property

        Public WriteOnly Property google_phone__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("google_phone", Value)
            End Set
        End Property

        Public WriteOnly Property google_phone__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("google_phone", Value)
            End Set
        End Property

        Public WriteOnly Property google_phone__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("google_phone", Value)
            End Set
        End Property

        Public WriteOnly Property google_phone__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("google_phone", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property google_web_site() As String
            Get
                If Me.htDirty.Contains("google_web_site") Then
                    Return Me.htDirty("google_web_site")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("google_web_site"))) Then
                    Return ""
                End If
                Return Me.row("google_web_site")
            End Get
            Set(ByVal Value As String)
                Me.SetField("google_web_site", Value)
            End Set
        End Property

        Public WriteOnly Property google_web_site__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("google_web_site", Value)
            End Set
        End Property

        Public WriteOnly Property google_web_site__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("google_web_site", Value)
            End Set
        End Property

        Public WriteOnly Property google_web_site__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("google_web_site", Value)
            End Set
        End Property

        Public WriteOnly Property google_web_site__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("google_web_site", Value)
            End Set
        End Property

        Public WriteOnly Property google_web_site__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("google_web_site", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property google_address() As String
            Get
                If Me.htDirty.Contains("google_address") Then
                    Return Me.htDirty("google_address")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("google_address"))) Then
                    Return ""
                End If
                Return Me.row("google_address")
            End Get
            Set(ByVal Value As String)
                Me.SetField("google_address", Value)
            End Set
        End Property

        Public WriteOnly Property google_address__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("google_address", Value)
            End Set
        End Property

        Public WriteOnly Property google_address__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("google_address", Value)
            End Set
        End Property

        Public WriteOnly Property google_address__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("google_address", Value)
            End Set
        End Property

        Public WriteOnly Property google_address__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("google_address", Value)
            End Set
        End Property

        Public WriteOnly Property google_address__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("google_address", Value)
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
        Public Property fb_place_id() As String
            Get
                If Me.htDirty.Contains("fb_place_id") Then
                    Return Me.htDirty("fb_place_id")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("fb_place_id"))) Then
                    Return ""
                End If
                Return Me.row("fb_place_id")
            End Get
            Set(ByVal Value As String)
                Me.SetField("fb_place_id", Value)
            End Set
        End Property

        Public WriteOnly Property fb_place_id__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("fb_place_id", Value)
            End Set
        End Property

        Public WriteOnly Property fb_place_id__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("fb_place_id", Value)
            End Set
        End Property

        Public WriteOnly Property fb_place_id__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("fb_place_id", Value)
            End Set
        End Property

        Public WriteOnly Property fb_place_id__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("fb_place_id", Value)
            End Set
        End Property

        Public WriteOnly Property fb_place_id__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("fb_place_id", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property fb_description() As String
            Get
                If Me.htDirty.Contains("fb_description") Then
                    Return Me.htDirty("fb_description")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("fb_description"))) Then
                    Return ""
                End If
                Return Me.row("fb_description")
            End Get
            Set(ByVal Value As String)
                Me.SetField("fb_description", Value)
            End Set
        End Property

        Public WriteOnly Property fb_description__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("fb_description", Value)
            End Set
        End Property

        Public WriteOnly Property fb_description__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("fb_description", Value)
            End Set
        End Property

        Public WriteOnly Property fb_description__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("fb_description", Value)
            End Set
        End Property

        Public WriteOnly Property fb_description__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("fb_description", Value)
            End Set
        End Property

        Public WriteOnly Property fb_description__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("fb_description", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property fb_checkin_count() As Int32
            Get
                If Me.htDirty.Contains("fb_checkin_count") Then
                    Return Me.htDirty("fb_checkin_count")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("fb_checkin_count"))) Then
                    Return 0
                End If
                Return Me.row("fb_checkin_count")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("fb_checkin_count", Value)
            End Set
        End Property

        Public WriteOnly Property fb_checkin_count__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("fb_checkin_count", Value)
            End Set
        End Property

        Public WriteOnly Property fb_checkin_count__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("fb_checkin_count", Value)
            End Set
        End Property

        Public WriteOnly Property fb_checkin_count__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("fb_checkin_count", Value)
            End Set
        End Property

        Public WriteOnly Property fb_checkin_count__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("fb_checkin_count", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property vote() As Decimal
            Get
                If Me.htDirty.Contains("vote") Then
                    Return Me.htDirty("vote")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("vote"))) Then
                    Return 0
                End If
                Return Me.row("vote")
            End Get
            Set(ByVal Value As Decimal)
                Me.SetField("vote", Value)
            End Set
        End Property

        Public WriteOnly Property vote__Start() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldStart("vote", Value)
            End Set
        End Property

        Public WriteOnly Property vote__End() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldEnd("vote", Value)
            End Set
        End Property

        Public WriteOnly Property vote__StartOrEqual() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldStartOrEqual("vote", Value)
            End Set
        End Property

        Public WriteOnly Property vote__EndOrEqual() As Decimal
            Set(ByVal Value As Decimal)
                SetFieldEndOrEqual("vote", Value)
            End Set
        End Property

        Shared _htTypeDefines As Hashtable
        Shared ReadOnly Property htTypeDefines() As Hashtable
            Get
                If _htTypeDefines Is Nothing Then
                    _htTypeDefines = New Hashtable
                    _htTypeDefines.Add("id", "int")
                    _htTypeDefines.Add("latitude", "decimal")
                    _htTypeDefines.Add("longitude", "decimal")
                    _htTypeDefines.Add("name", "nvarchar")
                    _htTypeDefines.Add("google_description", "nvarchar")
                    _htTypeDefines.Add("google_rating", "nchar")
                    _htTypeDefines.Add("google_reference", "nvarchar")
                    _htTypeDefines.Add("google_phone", "nvarchar")
                    _htTypeDefines.Add("google_web_site", "nvarchar")
                    _htTypeDefines.Add("google_address", "nvarchar")
                    _htTypeDefines.Add("google_id", "nvarchar")
                    _htTypeDefines.Add("fb_place_id", "nvarchar")
                    _htTypeDefines.Add("fb_description", "nvarchar")
                    _htTypeDefines.Add("fb_checkin_count", "int")
                    _htTypeDefines.Add("vote", "decimal")
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