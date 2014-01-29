Namespace DB
    Partial Public Class Vote
        Inherits UW.DB.Record2

        '** 2013/10/20 下午 08:48:23, Set NullWithDefault to False to get exception when the field is null **

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
                Return DB.Vote.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "Vote"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "Vote"
            End Get
        End Property

        Public Const FullTableName_Const As String = "V_Vote"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "V_Vote"
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
        Public Property deleted_tf() As DateTime
            Get
                If Me.htDirty.Contains("deleted_tf") Then
                    Return Me.htDirty("deleted_tf")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("deleted_tf"))) Then
                    Return DateTime.MinValue
                End If
                Return Me.row("deleted_tf")
            End Get
            Set(ByVal Value As DateTime)
                Me.SetField("deleted_tf", Value)
            End Set
        End Property

        Public Function deleted_tfToString(Format As String) As String
            If Me.htDirty.Contains("deleted_tf") Then
                Return CType(Me.htDirty("deleted_tf"), DateTime).Tostring(Format)
            End If

            If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("deleted_tf"))) Then
                Return ""
            End If
            Return CType(Me.row("deleted_tf"), DateTime).Tostring(Format)
        End Function

        Public WriteOnly Property deleted_tf__Start() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldStart("deleted_tf", Value)
            End Set
        End Property

        Public WriteOnly Property deleted_tf__End() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldEnd("deleted_tf", Value)
            End Set
        End Property

        Public WriteOnly Property deleted_tf__StartOrEqual() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldStartOrEqual("deleted_tf", Value)
            End Set
        End Property

        Public WriteOnly Property deleted_tf__EndOrEqual() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldEndOrEqual("deleted_tf", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property outer_id() As String
            Get
                If Me.htDirty.Contains("outer_id") Then
                    Return Me.htDirty("outer_id")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("outer_id"))) Then
                    Return ""
                End If
                Return Me.row("outer_id")
            End Get
            Set(ByVal Value As String)
                Me.SetField("outer_id", Value)
            End Set
        End Property

        Public WriteOnly Property outer_id__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("outer_id", Value)
            End Set
        End Property

        Public WriteOnly Property outer_id__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("outer_id", Value)
            End Set
        End Property

        Public WriteOnly Property outer_id__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("outer_id", Value)
            End Set
        End Property

        Public WriteOnly Property outer_id__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("outer_id", Value)
            End Set
        End Property

        Public WriteOnly Property outer_id__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("outer_id", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property Source() As DB.Member.EN.Source
            Get
                If Me.htDirty.Contains("en_source") Then
                    Return Me.htDirty("en_source")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("en_source"))) Then
                    Return 0
                End If
                Return Me.row("en_source")
            End Get
            Set(ByVal Value As DB.Member.EN.Source)
                Me.SetField("en_source", Value)
            End Set
        End Property

        Public Function Source__Name() As String
            Return Me.Source.ToString()
        End Function

        Public Property en_source() As DB.Member.EN.Source
            Get
                If Me.htDirty.Contains("en_source") Then
                    Return Me.htDirty("en_source")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("en_source"))) Then
                End If
                Return Me.row("en_source")
            End Get
            Set(ByVal Value As DB.Member.EN.Source)
                Me.SetField("en_source", Value)
            End Set
        End Property

        Public WriteOnly Property en_source__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("en_source", Value)
            End Set
        End Property

        Public WriteOnly Property en_source__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("en_source", Value)
            End Set
        End Property

        Public WriteOnly Property en_source__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("en_source", Value)
            End Set
        End Property

        Public WriteOnly Property en_source__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("en_source", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property email() As String
            Get
                If Me.htDirty.Contains("email") Then
                    Return Me.htDirty("email")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("email"))) Then
                    Return ""
                End If
                Return Me.row("email")
            End Get
            Set(ByVal Value As String)
                Me.SetField("email", Value)
            End Set
        End Property

        Public WriteOnly Property email__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("email", Value)
            End Set
        End Property

        Public WriteOnly Property email__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("email", Value)
            End Set
        End Property

        Public WriteOnly Property email__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("email", Value)
            End Set
        End Property

        Public WriteOnly Property email__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("email", Value)
            End Set
        End Property

        Public WriteOnly Property email__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("email", Value)
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
        Public Property comment() As String
            Get
                If Me.htDirty.Contains("comment") Then
                    Return Me.htDirty("comment")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("comment"))) Then
                    Return ""
                End If
                Return Me.row("comment")
            End Get
            Set(ByVal Value As String)
                Me.SetField("comment", Value)
            End Set
        End Property

        Public WriteOnly Property comment__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("comment", Value)
            End Set
        End Property

        Public WriteOnly Property comment__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("comment", Value)
            End Set
        End Property

        Public WriteOnly Property comment__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("comment", Value)
            End Set
        End Property

        Public WriteOnly Property comment__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("comment", Value)
            End Set
        End Property

        Public WriteOnly Property comment__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("comment", Value)
            End Set
        End Property

        Shared _htTypeDefines As Hashtable
        Shared ReadOnly Property htTypeDefines() As Hashtable
            Get
                If _htTypeDefines Is Nothing Then
                    _htTypeDefines = New Hashtable
                    _htTypeDefines.Add("member_id", "int")
                    _htTypeDefines.Add("place_id", "int")
                    _htTypeDefines.Add("created_date", "datetime")
                    _htTypeDefines.Add("rating", "decimal")
                    _htTypeDefines.Add("deleted_tf", "datetime")
                    _htTypeDefines.Add("outer_id", "nvarchar")
                    _htTypeDefines.Add("en_source", "int")
                    _htTypeDefines.Add("email", "nvarchar")
                    _htTypeDefines.Add("google_reference", "nvarchar")
                    _htTypeDefines.Add("fb_place_id", "nvarchar")
                    _htTypeDefines.Add("google_id", "nvarchar")
                    _htTypeDefines.Add("comment", "nvarchar")
                    _htTypeDefines.Add("id", "int")
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