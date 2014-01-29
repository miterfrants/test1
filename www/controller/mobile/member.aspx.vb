
Partial Class controller_member
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If UW.WU.IsNonEmptyFromQueryStringOrForm("action") Then
            Select Case UW.WU.GetValueFromQueryStringOrForm("action")
                Case "get_goods"
                    getGoods()
                Case "get_badge"
                    getBadge()
                Case "get_local_id"
                    getLocalId()
            End Select
            Response.End()
        End If
    End Sub
    Sub getLocalId()
        Dim oM As New DB.Member()
        oM.en_source = UW.WU.GetValueFromQueryStringOrForm("source")
        oM.outer_id = UW.WU.GetValueFromQueryStringOrForm("outer_id")
        oM = oM.GetDataRowAndReturnSelfOrNothing()
        If oM IsNot Nothing Then
            Response.Write(oM.Id)
        Else
            Response.Write(-1)
        End If
    End Sub
    Sub valify()
        Dim id As Int32 = UW.WU.GetValueFromQueryStringOrForm("id")
        Dim token As String = UW.WU.GetValueFromQueryStringOrForm("token")
        Dim source As String = UW.WU.GetValueFromQueryStringOrForm("source")
        If token.Length = 0 OrElse Not UW.WU.IsNonEmptyFromQueryStringOrForm("id") OrElse source.Length = 0 Then
            Response.Write(UW.JSON.JSONString(False, "not auth"))
            Response.End()
            Exit Sub
        End If

        Dim result As String = UW.WU.getRemotePage(" https://graph.facebook.com/me?access_token=" & token)
        Dim oFBUser As FB.oAuthUser = UW.JSON.jsonToObject(result, GetType(FB.oAuthUser))
        Dim oMember As New DB.Member(id)
        If oFBUser Is Nothing OrElse (oFBUser.id <> oMember.outer_id AndAlso oMember.en_source = source) Then
            Response.Write(UW.JSON.JSONString(False, "not auth"))
            Response.End()
            Exit Sub
        End If
    End Sub

    Sub getBadge()

        valify() 'if not auth sotp on the sub

        Dim oMNB As New DB.MemberAndBadge
        oMNB.member_id = id
        Dim dt As DataTable = oMNB.GetQueryDT()
        Dim strBuilder As New StringBuilder()

        If dt IsNot Nothing Then
            For i As Int32 = 0 To dt.Rows.Count - 1
                strBuilder.Append("[""name"":""" & dt.Rows(i)("name") & """,")
                strBuilder.Append("""description"":""" & dt.Rows(i)("description") & """,")
                strBuilder.Append("""pic"":""" & dt.Rows(i)("pic") & """,")
                strBuilder.Append("""created_date"":""" & dt.Rows(i)("created_date") & """]")
                If i <> dt.Rows.Count - 1 Then
                    strBuilder.Append(",")
                End If
            Next
        End If
        Response.Write(strBuilder.ToString())
    End Sub
    Sub getGoods()
        Dim id As Int32 = UW.WU.GetValueFromQueryStringOrForm("id")
        Dim token As String = UW.WU.GetValueFromQueryStringOrForm("token")
        If token.Length = 0 Then
            Response.Write(UW.JSON.JSONString(False, "not auth"))
            Exit Sub
        End If

        Dim result As String = UW.WU.getRemotePage(" https://graph.facebook.com/me?access_token=" & token)

        Dim oFBUser As FB.oAuthUser = UW.JSON.jsonToObject(result, GetType(FB.oAuthUser))
        Dim oMember As New DB.Member(id)

        If oFBUser Is Nothing OrElse (oFBUser.id <> oMember.outer_id AndAlso oMember.en_source = DB.Member.EN.Source.Facebook) Then
            Response.Write(UW.JSON.JSONString(False, "not auth"))
            Exit Sub
        End If

        Dim sqlGetGoods As String = "select t.goods_id,t.member_id,t.qty,goods.name,goods.description,goods.weight,goods.pic,goods.size from (select goods_id,member_id,count(*) as qty from member_and_goods where member_id=" & id & " group by goods_id,member_id) as t left join goods on t.goods_id=goods.id"
        Dim dt As DataTable = UW.SQL.DTFromSQL(sqlGetGoods)
        Dim strBuilder As New StringBuilder()
        strBuilder.Append("{""goods"":[")
        If dt IsNot Nothing Then
            For i As Int32 = 0 To dt.Rows.Count - 1
                strBuilder.Append("{""name"":""" & dt.Rows(i)("name") & """,")
                strBuilder.Append("""description"":""" & dt.Rows(i)("description") & """,")
                strBuilder.Append("""weight"":""" & dt.Rows(i)("weight") & """,")
                strBuilder.Append("""pic"":""" & "http://" & DB.SysConfig.URL.Mobile_Goods_Img & dt.Rows(i)("pic") & """,")
                strBuilder.Append("""qty"":""" & dt.Rows(i)("qty") & """,")
                strBuilder.Append("""size"":""" & dt.Rows(i)("size") & """}")
                If i <> dt.Rows.Count - 1 Then
                    strBuilder.Append(",")
                End If
            Next
        End If
        strBuilder.Append("]}")
        Response.Write(strBuilder.ToString())
    End Sub
   
End Class
