<%@ Page Language="vb" ValidateRequest="false" AutoEventWireup="false" Inherits="UW.PG2008" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Property Generater</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                Fields and Types(�� Tab ���j)</p>
            <p>
                Class Name:
                <asp:TextBox ID="txtClassName" runat="server"></asp:TextBox>&nbsp; ��Ʈw�G<asp:DropDownList
                    ID="ddlDBType" runat="server">
                    <asp:ListItem>SQL2008</asp:ListItem>
                </asp:DropDownList>DBC:
                <asp:DropDownList ID="ddlDBC" runat="server">
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList></p>
            <p>
                Table Name:
                <asp:TextBox ID="txttableName" runat="server"></asp:TextBox>, ID Field:
                <asp:TextBox ID="txtID" runat="server" Width="80px">id</asp:TextBox>,&nbsp;���A:
                <asp:DropDownList ID="ddlIdType" runat="server">
                    <asp:ListItem Value="Int32">���</asp:ListItem>
                    <asp:ListItem Value="String">�r��</asp:ListItem>
                </asp:DropDownList>, Base Table Name:
                <asp:TextBox ID="txtBasetableName" runat="server"></asp:TextBox></p>
            <p>
                Password:
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>&nbsp;�Ш� "btnGetfields_Click"
                �� Source Code</p>
            <p>
                <asp:Button ID="btnGetfields" runat="server" Text="Get Fields"></asp:Button><br />
                <span style="color: red; font-size: 12px">�s���|Ū��w�����ѡA�Х� "����W�٩λ���@Type$���|1=��1,���|2=��2"
                    ���榡�����ѡA@ �M $ �оܤ@�ϥΡC<br />
                    �b View ���i�W�[�X�R�ݩ� "Fields"�A�i�h��C�榡: FieldName:����W�٩λ���@Type$���|1=��1,���|2=��2<br />
                    Is_ �}�Y�����A�Ф��n�[�J @boolean_yn�AIs_XXX �|�w�q�� string, IsXXX �|�w�q�� boolean<br />
                </span>
            </p>
            <p>
                <asp:Button ID="btnResultFromFields" runat="server" Text="�ѩұo��첣�͵{���X"></asp:Button>
                <asp:CheckBox ID="cbTail" runat="server" Text="�����͵����q��"></asp:CheckBox><asp:CheckBox
                    ID="cbAddNameSpace" runat="server" Text="�[�J NameSpace" Checked="true"></asp:CheckBox></p>
            <p>
                <asp:Table ID="tblFiels" runat="server">
                </asp:Table>
            </p>
            <table id="table1" style="width: 504px; height: 258px" cellspacing="1" cellpadding="1"
                width="504" border="1" runat="server" visible="false">
                <tr>
                    <td>
                        <p>
                            <asp:TextBox ID="txtFieldAndType" runat="server" TextMode="MultiLine" Height="248px"
                                Width="280px"></asp:TextBox></p>
                    </td>
                    <td>
                        <p>
                            Type ������</p>
                        <p>
                            int -&gt; int32</p>
                        <p>
                            "char", "varchar", "nchar", "nvarchar" -&gt; string</p>
                        <p>
                            datetime -&gt; datetime</p>
                        <p>
                            char_yn -&gt; boolean</p>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnGenerate" runat="server" Text="�� TextArea ���͵{���X" Visible="false">
            </asp:Button><br />
            <asp:Label ID="lblPG" runat="server" Text="Label"></asp:Label><br />
            <asp:TextBox ID="txtRes" runat="server" TextMode="MultiLine" Height="270px" Width="800px"></asp:TextBox><br />
            <br />
            <asp:Label ID="lblVB" runat="server" Text="Label"></asp:Label><br />
            <asp:TextBox ID="txtVBRes" runat="server" TextMode="MultiLine" Height="270px" Width="800px"></asp:TextBox><br />
            <br />
        </div>
    </form>
</body>
</html>
