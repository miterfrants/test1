Imports System.Net
Partial Class test_gender_null
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim oM As New DB.Member()
        Dim dtMember As DataTable = oM.GetQueryDT()
        Dim dicExpList As Dictionary(Of String, Int32) = DB.ExpList.getDicExpList()
        If dtMember IsNot Nothing AndAlso dtMember.Rows.Count > 0 Then
            For i As Int32 = 0 To dtMember.Rows.Count - 1
                Dim oTempM As New DB.Member(dtMember.Rows(i))
                Dim exp As Int32 = 0
                If oTempM.email.Length > 0 AndAlso dicExpList.ContainsKey("member_email") Then
                    exp += dicExpList("member_email")
                End If
                If oTempM.first_name.Length > 0 AndAlso dicExpList.ContainsKey("member_first_name") Then
                    exp += dicExpList("member_first_name")
                End If
                If oTempM.last_name.Length > 0 AndAlso dicExpList.ContainsKey("member_last_name") Then
                    exp += dicExpList("member_last_name")
                End If
                If oTempM.country_id > 0 AndAlso dicExpList.ContainsKey("member_country_id") Then
                    exp += dicExpList("member_country_id")
                End If
                If oTempM.en_gender > 0 AndAlso dicExpList.ContainsKey("member_en_gender") Then
                    exp += dicExpList("member_en_gender")
                End If
                If oTempM.address.Length > 0 AndAlso dicExpList.ContainsKey("member_address") Then
                    exp += dicExpList("member_address")
                End If
                If oTempM.phone.Length > 0 AndAlso dicExpList.ContainsKey("member_phone") Then
                    exp += dicExpList("member_phone")
                End If
                If oTempM.link.Length > 0 AndAlso dicExpList.ContainsKey("member_link") Then
                    exp += dicExpList("member_link")
                End If
                If oTempM.howetown.Length > 0 AndAlso dicExpList.ContainsKey("member_home_town") Then
                    exp += dicExpList("member_home_town")
                End If

                If oTempM.location.Length > 0 AndAlso dicExpList.ContainsKey("member_location") Then
                    exp += dicExpList("member_location")
                End If
                If oTempM.birthday > DateTime.MinValue AndAlso dicExpList.ContainsKey("member_birthday") Then
                    exp += dicExpList("member_birthday")
                End If
                If oTempM.lang_id > 0 AndAlso dicExpList.ContainsKey("member_lang_id") Then
                    exp += dicExpList("member_lang_id")
                End If
                Dim oEL As New DB.ExpLog()
                oEL.member_id = oTempM.Id
                oEL.exp = exp
                oEL.Insert()
            Next

        End If
    End Sub
End Class
