Namespace DB
    Partial Public Class Member
        Inherits UW.DB.Record2

        '** 2013/7/27 下午 05:12:57, Set NullWithDefault to False to get exception when the field is null **

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
                Return DB.Member.htTypeDefines
            End Get
        End Property

        Public Const BaseTableName_Const As String = "member"

        Public Overrides ReadOnly Property BaseTableName() As String
            Get
                Return "member"
            End Get
        End Property

        Public Const FullTableName_Const As String = "V_member"

        Public Overrides ReadOnly Property FullTableName() As String
            Get
                Return "V_member"
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
        Public Property Source() As EN.Source
            Get
                If Me.htDirty.Contains("en_source") Then
                    Return Me.htDirty("en_source")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("en_source"))) Then
                    Return 0
                End If
                Return Me.row("en_source")
            End Get
            Set(ByVal Value As EN.Source)
                Me.SetField("en_source", Value)
            End Set
        End Property

        Public Function Source__Name() As String
            Return Me.Source.ToString()
        End Function

        Public Property en_source() As EN.Source
            Get
                If Me.htDirty.Contains("en_source") Then
                    Return Me.htDirty("en_source")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("en_source"))) Then
                End If
                Return Me.row("en_source")
            End Get
            Set(ByVal Value As EN.Source)
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
        Public Property pw() As String
            Get
                If Me.htDirty.Contains("pw") Then
                    Return Me.htDirty("pw")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("pw"))) Then
                    Return ""
                End If
                Return Me.row("pw")
            End Get
            Set(ByVal Value As String)
                Me.SetField("pw", Value)
            End Set
        End Property

        Public WriteOnly Property pw__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("pw", Value)
            End Set
        End Property

        Public WriteOnly Property pw__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("pw", Value)
            End Set
        End Property

        Public WriteOnly Property pw__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("pw", Value)
            End Set
        End Property

        Public WriteOnly Property pw__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("pw", Value)
            End Set
        End Property

        Public WriteOnly Property pw__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("pw", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property salt() As String
            Get
                If Me.htDirty.Contains("salt") Then
                    Return Me.htDirty("salt")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("salt"))) Then
                    Return ""
                End If
                Return Me.row("salt")
            End Get
            Set(ByVal Value As String)
                Me.SetField("salt", Value)
            End Set
        End Property

        Public WriteOnly Property salt__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("salt", Value)
            End Set
        End Property

        Public WriteOnly Property salt__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("salt", Value)
            End Set
        End Property

        Public WriteOnly Property salt__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("salt", Value)
            End Set
        End Property

        Public WriteOnly Property salt__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("salt", Value)
            End Set
        End Property

        Public WriteOnly Property salt__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("salt", Value)
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
        Public Property created_ip() As String
            Get
                If Me.htDirty.Contains("created_ip") Then
                    Return Me.htDirty("created_ip")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("created_ip"))) Then
                    Return ""
                End If
                Return Me.row("created_ip")
            End Get
            Set(ByVal Value As String)
                Me.SetField("created_ip", Value)
            End Set
        End Property

        Public WriteOnly Property created_ip__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("created_ip", Value)
            End Set
        End Property

        Public WriteOnly Property created_ip__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("created_ip", Value)
            End Set
        End Property

        Public WriteOnly Property created_ip__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("created_ip", Value)
            End Set
        End Property

        Public WriteOnly Property created_ip__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("created_ip", Value)
            End Set
        End Property

        Public WriteOnly Property created_ip__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("created_ip", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property first_name() As String
            Get
                If Me.htDirty.Contains("first_name") Then
                    Return Me.htDirty("first_name")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("first_name"))) Then
                    Return ""
                End If
                Return Me.row("first_name")
            End Get
            Set(ByVal Value As String)
                Me.SetField("first_name", Value)
            End Set
        End Property

        Public WriteOnly Property first_name__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("first_name", Value)
            End Set
        End Property

        Public WriteOnly Property first_name__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("first_name", Value)
            End Set
        End Property

        Public WriteOnly Property first_name__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("first_name", Value)
            End Set
        End Property

        Public WriteOnly Property first_name__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("first_name", Value)
            End Set
        End Property

        Public WriteOnly Property first_name__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("first_name", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property middle_name() As String
            Get
                If Me.htDirty.Contains("middle_name") Then
                    Return Me.htDirty("middle_name")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("middle_name"))) Then
                    Return ""
                End If
                Return Me.row("middle_name")
            End Get
            Set(ByVal Value As String)
                Me.SetField("middle_name", Value)
            End Set
        End Property

        Public WriteOnly Property middle_name__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("middle_name", Value)
            End Set
        End Property

        Public WriteOnly Property middle_name__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("middle_name", Value)
            End Set
        End Property

        Public WriteOnly Property middle_name__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("middle_name", Value)
            End Set
        End Property

        Public WriteOnly Property middle_name__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("middle_name", Value)
            End Set
        End Property

        Public WriteOnly Property middle_name__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("middle_name", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property last_name() As String
            Get
                If Me.htDirty.Contains("last_name") Then
                    Return Me.htDirty("last_name")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("last_name"))) Then
                    Return ""
                End If
                Return Me.row("last_name")
            End Get
            Set(ByVal Value As String)
                Me.SetField("last_name", Value)
            End Set
        End Property

        Public WriteOnly Property last_name__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("last_name", Value)
            End Set
        End Property

        Public WriteOnly Property last_name__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("last_name", Value)
            End Set
        End Property

        Public WriteOnly Property last_name__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("last_name", Value)
            End Set
        End Property

        Public WriteOnly Property last_name__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("last_name", Value)
            End Set
        End Property

        Public WriteOnly Property last_name__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("last_name", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property country_id() As Int32
            Get
                If Me.htDirty.Contains("country_id") Then
                    Return Me.htDirty("country_id")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("country_id"))) Then
                    Return 0
                End If
                Return Me.row("country_id")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("country_id", Value)
            End Set
        End Property

        Public WriteOnly Property country_id__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("country_id", Value)
            End Set
        End Property

        Public WriteOnly Property country_id__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("country_id", Value)
            End Set
        End Property

        Public WriteOnly Property country_id__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("country_id", Value)
            End Set
        End Property

        Public WriteOnly Property country_id__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("country_id", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property lang_id() As Int32
            Get
                If Me.htDirty.Contains("lang_id") Then
                    Return Me.htDirty("lang_id")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("lang_id"))) Then
                    Return 0
                End If
                Return Me.row("lang_id")
            End Get
            Set(ByVal Value As Int32)
                Me.SetField("lang_id", Value)
            End Set
        End Property

        Public WriteOnly Property lang_id__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("lang_id", Value)
            End Set
        End Property

        Public WriteOnly Property lang_id__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("lang_id", Value)
            End Set
        End Property

        Public WriteOnly Property lang_id__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("lang_id", Value)
            End Set
        End Property

        Public WriteOnly Property lang_id__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("lang_id", Value)
            End Set
        End Property

        ''' <summary>
        ''' $male=1,female=0
        ''' </summary>
        Public Property Gender() As EN.Gender
            Get
                If Me.htDirty.Contains("en_gender") Then
                    Return Me.htDirty("en_gender")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("en_gender"))) Then
                    Return 0
                End If
                Return Me.row("en_gender")
            End Get
            Set(ByVal Value As EN.Gender)
                Me.SetField("en_gender", Value)
            End Set
        End Property

        Public Function Gender__Name() As String
            Return HT.Gender(Me.Gender)
        End Function

        Public Property en_gender() As EN.Gender
            Get
                If Me.htDirty.Contains("en_gender") Then
                    Return Me.htDirty("en_gender")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("en_gender"))) Then
                End If
                Return Me.row("en_gender")
            End Get
            Set(ByVal Value As EN.Gender)
                Me.SetField("en_gender", Value)
            End Set
        End Property

        Public WriteOnly Property en_gender__Start() As Int32
            Set(ByVal Value As Int32)
                SetFieldStart("en_gender", Value)
            End Set
        End Property

        Public WriteOnly Property en_gender__End() As Int32
            Set(ByVal Value As Int32)
                SetFieldEnd("en_gender", Value)
            End Set
        End Property

        Public WriteOnly Property en_gender__StartOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldStartOrEqual("en_gender", Value)
            End Set
        End Property

        Public WriteOnly Property en_gender__EndOrEqual() As Int32
            Set(ByVal Value As Int32)
                SetFieldEndOrEqual("en_gender", Value)
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
        Public Property phone() As String
            Get
                If Me.htDirty.Contains("phone") Then
                    Return Me.htDirty("phone")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("phone"))) Then
                    Return ""
                End If
                Return Me.row("phone")
            End Get
            Set(ByVal Value As String)
                Me.SetField("phone", Value)
            End Set
        End Property

        Public WriteOnly Property phone__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("phone", Value)
            End Set
        End Property

        Public WriteOnly Property phone__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("phone", Value)
            End Set
        End Property

        Public WriteOnly Property phone__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("phone", Value)
            End Set
        End Property

        Public WriteOnly Property phone__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("phone", Value)
            End Set
        End Property

        Public WriteOnly Property phone__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("phone", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property link() As String
            Get
                If Me.htDirty.Contains("link") Then
                    Return Me.htDirty("link")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("link"))) Then
                    Return ""
                End If
                Return Me.row("link")
            End Get
            Set(ByVal Value As String)
                Me.SetField("link", Value)
            End Set
        End Property

        Public WriteOnly Property link__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("link", Value)
            End Set
        End Property

        Public WriteOnly Property link__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("link", Value)
            End Set
        End Property

        Public WriteOnly Property link__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("link", Value)
            End Set
        End Property

        Public WriteOnly Property link__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("link", Value)
            End Set
        End Property

        Public WriteOnly Property link__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("link", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property username() As String
            Get
                If Me.htDirty.Contains("username") Then
                    Return Me.htDirty("username")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("username"))) Then
                    Return ""
                End If
                Return Me.row("username")
            End Get
            Set(ByVal Value As String)
                Me.SetField("username", Value)
            End Set
        End Property

        Public WriteOnly Property username__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("username", Value)
            End Set
        End Property

        Public WriteOnly Property username__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("username", Value)
            End Set
        End Property

        Public WriteOnly Property username__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("username", Value)
            End Set
        End Property

        Public WriteOnly Property username__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("username", Value)
            End Set
        End Property

        Public WriteOnly Property username__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("username", Value)
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
        Public Property howetown() As String
            Get
                If Me.htDirty.Contains("howetown") Then
                    Return Me.htDirty("howetown")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("howetown"))) Then
                    Return ""
                End If
                Return Me.row("howetown")
            End Get
            Set(ByVal Value As String)
                Me.SetField("howetown", Value)
            End Set
        End Property

        Public WriteOnly Property howetown__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("howetown", Value)
            End Set
        End Property

        Public WriteOnly Property howetown__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("howetown", Value)
            End Set
        End Property

        Public WriteOnly Property howetown__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("howetown", Value)
            End Set
        End Property

        Public WriteOnly Property howetown__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("howetown", Value)
            End Set
        End Property

        Public WriteOnly Property howetown__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("howetown", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property location() As String
            Get
                If Me.htDirty.Contains("location") Then
                    Return Me.htDirty("location")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("location"))) Then
                    Return ""
                End If
                Return Me.row("location")
            End Get
            Set(ByVal Value As String)
                Me.SetField("location", Value)
            End Set
        End Property

        Public WriteOnly Property location__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("location", Value)
            End Set
        End Property

        Public WriteOnly Property location__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("location", Value)
            End Set
        End Property

        Public WriteOnly Property location__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("location", Value)
            End Set
        End Property

        Public WriteOnly Property location__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("location", Value)
            End Set
        End Property

        Public WriteOnly Property location__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("location", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property time_flag() As DateTime
            Get
                If Me.htDirty.Contains("time_flag") Then
                    Return Me.htDirty("time_flag")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("time_flag"))) Then
                    Return DateTime.MinValue
                End If
                Return Me.row("time_flag")
            End Get
            Set(ByVal Value As DateTime)
                Me.SetField("time_flag", Value)
            End Set
        End Property

        Public Function time_flagToString(Format As String) As String
            If Me.htDirty.Contains("time_flag") Then
                Return CType(Me.htDirty("time_flag"), DateTime).Tostring(Format)
            End If

            If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("time_flag"))) Then
                Return ""
            End If
            Return CType(Me.row("time_flag"), DateTime).Tostring(Format)
        End Function

        Public WriteOnly Property time_flag__Start() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldStart("time_flag", Value)
            End Set
        End Property

        Public WriteOnly Property time_flag__End() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldEnd("time_flag", Value)
            End Set
        End Property

        Public WriteOnly Property time_flag__StartOrEqual() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldStartOrEqual("time_flag", Value)
            End Set
        End Property

        Public WriteOnly Property time_flag__EndOrEqual() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldEndOrEqual("time_flag", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property IsIsolate() As Boolean
            Get
                If Me.htDirty.Contains("is_isolate") Then
                    If Me.htDirty("is_isolate") = "Y" OrElse Me.htDirty("is_isolate") = "1" Then Return True Else Return False
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("is_isolate"))) Then
                    Return False
                End If
                If Me.row("is_isolate") = "Y" OrElse Me.row("is_isolate") = "1" Then Return True Else Return False
            End Get
            Set(ByVal Value As Boolean)
                If Value Then
                    Me.SetField("is_isolate", "Y")
                Else
                    Me.SetField("is_isolate", "N")
                End If
            End Set
        End Property

        Public ReadOnly Property IsIsolate_Tostring() As String
            Get
                If Me.IsIsolate Then
                    Return "是"
                End If

                Return "否"
            End Get
        End Property

        Public Property is_isolate() As String
            Get
                If Me.htDirty.Contains("is_isolate") Then
                    Return Me.htDirty("is_isolate")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("is_isolate"))) Then
                    Return ""
                End If
                Return Me.row("is_isolate")
            End Get
            Set(ByVal Value As String)
                Me.SetField("is_isolate", Value)
            End Set
        End Property

        Public WriteOnly Property is_isolate__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("is_isolate", Value)
            End Set
        End Property

        Public WriteOnly Property is_isolate__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("is_isolate", Value)
            End Set
        End Property

        Public WriteOnly Property is_isolate__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("is_isolate", Value)
            End Set
        End Property

        Public WriteOnly Property is_isolate__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("is_isolate", Value)
            End Set
        End Property

        Public WriteOnly Property is_isolate__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("is_isolate", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property profile() As String
            Get
                If Me.htDirty.Contains("profile") Then
                    Return Me.htDirty("profile")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("profile"))) Then
                    Return ""
                End If
                Return Me.row("profile")
            End Get
            Set(ByVal Value As String)
                Me.SetField("profile", Value)
            End Set
        End Property

        Public WriteOnly Property profile__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("profile", Value)
            End Set
        End Property

        Public WriteOnly Property profile__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("profile", Value)
            End Set
        End Property

        Public WriteOnly Property profile__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("profile", Value)
            End Set
        End Property

        Public WriteOnly Property profile__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("profile", Value)
            End Set
        End Property

        Public WriteOnly Property profile__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("profile", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property birthday() As DateTime
            Get
                If Me.htDirty.Contains("birthday") Then
                    Return Me.htDirty("birthday")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("birthday"))) Then
                    Return DateTime.MinValue
                End If
                Return Me.row("birthday")
            End Get
            Set(ByVal Value As DateTime)
                Me.SetField("birthday", Value)
            End Set
        End Property

        Public Function birthdayToString(Format As String) As String
            If Me.htDirty.Contains("birthday") Then
                Return CType(Me.htDirty("birthday"), DateTime).Tostring(Format)
            End If

            If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("birthday"))) Then
                Return ""
            End If
            Return CType(Me.row("birthday"), DateTime).Tostring(Format)
        End Function

        Public WriteOnly Property birthday__Start() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldStart("birthday", Value)
            End Set
        End Property

        Public WriteOnly Property birthday__End() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldEnd("birthday", Value)
            End Set
        End Property

        Public WriteOnly Property birthday__StartOrEqual() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldStartOrEqual("birthday", Value)
            End Set
        End Property

        Public WriteOnly Property birthday__EndOrEqual() As DateTime
            Set(ByVal Value As DateTime)
                SetFieldEndOrEqual("birthday", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property IsVerify() As Boolean
            Get
                If Me.htDirty.Contains("is_verify") Then
                    If Me.htDirty("is_verify") = "Y" OrElse Me.htDirty("is_verify") = "1" Then Return True Else Return False
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("is_verify"))) Then
                    Return False
                End If
                If Me.row("is_verify") = "Y" OrElse Me.row("is_verify") = "1" Then Return True Else Return False
            End Get
            Set(ByVal Value As Boolean)
                If Value Then
                    Me.SetField("is_verify", "Y")
                Else
                    Me.SetField("is_verify", "N")
                End If
            End Set
        End Property

        Public ReadOnly Property IsVerify_Tostring() As String
            Get
                If Me.IsVerify Then
                    Return "是"
                End If

                Return "否"
            End Get
        End Property

        Public Property is_verify() As String
            Get
                If Me.htDirty.Contains("is_verify") Then
                    Return Me.htDirty("is_verify")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("is_verify"))) Then
                    Return ""
                End If
                Return Me.row("is_verify")
            End Get
            Set(ByVal Value As String)
                Me.SetField("is_verify", Value)
            End Set
        End Property

        Public WriteOnly Property is_verify__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("is_verify", Value)
            End Set
        End Property

        Public WriteOnly Property is_verify__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("is_verify", Value)
            End Set
        End Property

        Public WriteOnly Property is_verify__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("is_verify", Value)
            End Set
        End Property

        Public WriteOnly Property is_verify__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("is_verify", Value)
            End Set
        End Property

        Public WriteOnly Property is_verify__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("is_verify", Value)
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        Public Property lang_abbr() As String
            Get
                If Me.htDirty.Contains("lang_abbr") Then
                    Return Me.htDirty("lang_abbr")
                End If

                If NullWithDefault AndAlso (Me.row Is Nothing OrElse IsDBNull(Me.row("lang_abbr"))) Then
                    Return ""
                End If
                Return Me.row("lang_abbr")
            End Get
            Set(ByVal Value As String)
                Me.SetField("lang_abbr", Value)
            End Set
        End Property

        Public WriteOnly Property lang_abbr__Like() As String
            Set(ByVal Value As String)
                SetFieldLike("lang_abbr", Value)
            End Set
        End Property

        Public WriteOnly Property lang_abbr__Start() As String
            Set(ByVal Value As String)
                SetFieldStart("lang_abbr", Value)
            End Set
        End Property

        Public WriteOnly Property lang_abbr__End() As String
            Set(ByVal Value As String)
                SetFieldEnd("lang_abbr", Value)
            End Set
        End Property

        Public WriteOnly Property lang_abbr__StartOrEqual() As String
            Set(ByVal Value As String)
                SetFieldStartOrEqual("lang_abbr", Value)
            End Set
        End Property

        Public WriteOnly Property lang_abbr__EndOrEqual() As String
            Set(ByVal Value As String)
                SetFieldEndOrEqual("lang_abbr", Value)
            End Set
        End Property

        Shared _htTypeDefines As Hashtable
        Shared ReadOnly Property htTypeDefines() As Hashtable
            Get
                If _htTypeDefines Is Nothing Then
                    _htTypeDefines = New Hashtable
                    _htTypeDefines.Add("exp", "int")
                    _htTypeDefines.Add("id", "int")
                    _htTypeDefines.Add("outer_id", "nvarchar")
                    _htTypeDefines.Add("en_source", "int")
                    _htTypeDefines.Add("email", "nvarchar")
                    _htTypeDefines.Add("pw", "nvarchar")
                    _htTypeDefines.Add("salt", "nvarchar")
                    _htTypeDefines.Add("created_date", "datetime")
                    _htTypeDefines.Add("created_ip", "nvarchar")
                    _htTypeDefines.Add("first_name", "nvarchar")
                    _htTypeDefines.Add("middle_name", "nvarchar")
                    _htTypeDefines.Add("last_name", "nvarchar")
                    _htTypeDefines.Add("country_id", "int")
                    _htTypeDefines.Add("lang_id", "int")
                    _htTypeDefines.Add("en_gender", "int")
                    _htTypeDefines.Add("name", "nvarchar")
                    _htTypeDefines.Add("address", "nvarchar")
                    _htTypeDefines.Add("phone", "nvarchar")
                    _htTypeDefines.Add("link", "nvarchar")
                    _htTypeDefines.Add("username", "nvarchar")
                    _htTypeDefines.Add("update_date", "datetime")
                    _htTypeDefines.Add("howetown", "nvarchar")
                    _htTypeDefines.Add("location", "nvarchar")
                    _htTypeDefines.Add("time_flag", "datetime")
                    _htTypeDefines.Add("is_isolate", "char")
                    _htTypeDefines.Add("profile", "nvarchar")
                    _htTypeDefines.Add("birthday", "datetime")
                    _htTypeDefines.Add("is_verify", "char")
                    _htTypeDefines.Add("lang_abbr", "nvarchar")
                End If
                Return _htTypeDefines
            End Get
        End Property

        ''' <summary>
        ''' 使用到的 Enum
        ''' </summary>
        Partial Public Class EN
            '''$male=1,female=0
            Public Enum gender
                male = 1
                female = 0
            End Enum

        End Class



        ''' <summary>
        ''' 使用到的 Enum 所產生的 HashTable，用來顯示用。
        ''' </summary>
        Partial Public Class HT
            Private Shared _gender As Hashtable
            ''' <summary>
            ''' $male=1,female=0
            ''' </summary>
            Shared Function genderHT() As Hashtable
                If _gender Is Nothing Then
                    _gender = UW.HashtableFns.HTFromEnum(GetType(EN.gender))
                End If
                Return _gender
            End Function

            ''' <summary>
            ''' $male=1,female=0
            ''' </summary>
            Shared Function gender(ByVal Key As EN.gender) As String
                Return genderHT(Key)
            End Function

        End Class



        ''' <summary>
        ''' 使用到的 Enum 所產生的 Array List，用來顯示用。
        ''' </summary>
        Public Class AL
            Private Shared _gender As ArrayList = Nothing
            ''' <summary>
            ''' $male=1,female=0
            ''' </summary>
            Public Shared Function gender() As ArrayList
                If _gender Is Nothing Then
                    _gender = UW.ArrayListFns.ALFromEnum(GetType(EN.gender))
                End If
                Return _gender
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