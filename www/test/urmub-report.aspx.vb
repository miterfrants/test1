
Partial Class test_urmub_report
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sql As String = "select device,sex,cate,count(*) as c from ur_mub group by sex,device,cate"
        Dim dt As DataTable = UW.SQL.DTFromSQL(sql)
        Dim total As Int32 = 0
        Response.Write("<table>")
        Response.Write("<tr>")
        Response.Write("<th>性別</th>")
        Response.Write("<th>手機平台</th>")
        Response.Write("<th>使用APP</th>")
        Response.Write("<th>人數</th>")
        Response.Write("</tr>")
        For i As Int32 = 0 To dt.Rows.Count - 1
            Response.Write("<tr>")
            Response.Write("<td>" & getSexString(CInt(dt.Rows(i)("sex"))) & "</td>")
            Response.Write("<td>" & getDeviceString(CInt(dt.Rows(i)("device"))) & "</td>")
            Response.Write("<td>" & getCateString(CInt(dt.Rows(i)("cate"))) & "</td>")
            Response.Write("<td>" & CInt(dt.Rows(i)("c")) & "</td>")
            Response.Write("</tr>")
            total += CInt(dt.Rows(i)("c"))
        Next
        Response.Write("<tr>")
        Response.Write("<td colspan=""4"">")
        Response.Write("樣本數:" & total)
        Response.Write("</tr>")
        Response.Write("</table>")
    End Sub
    Function getSexString(ByVal sex As Int32) As String
        If sex = 1 Then
            Return "male"
        Else
            Return "female"
        End If
    End Function
    Function getDeviceString(ByVal device As Int32) As String
        If device = 1 Then
            Return "iOS"
        Else
            Return "Android"
        End If
    End Function
    Function getCateString(ByVal cate As String) As String
        Select Case cate
            Case 1
                Return "LBS"
            Case 2
                Return "Social Network"
            Case 3
                Return "Communication"
            Case 4
                Return "Gaming"
            Case 5
                Return "Reading"
            Case 6
                Return "Music"
            Case 7
                Return "Photo"
            Case 8
                Return "Video"
            Case 9
                Return "Testing"

        End Select
    End Function
End Class
