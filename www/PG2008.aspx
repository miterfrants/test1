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
                Fields and Types(用 Tab 分隔)</p>
            <p>
                Class Name:
                <asp:TextBox ID="txtClassName" runat="server"></asp:TextBox>&nbsp; 資料庫：<asp:DropDownList
                    ID="ddlDBType" runat="server">
                    <asp:ListItem>SQL2008</asp:ListItem>
                </asp:DropDownList>DBC:
                <asp:DropDownList ID="ddlDBC" runat="server">
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList></p>
            <p>
                Table Name:
                <asp:TextBox ID="txttableName" runat="server"></asp:TextBox>, ID Field:
                <asp:TextBox ID="txtID" runat="server" Width="80px">id</asp:TextBox>,&nbsp;型態:
                <asp:DropDownList ID="ddlIdType" runat="server">
                    <asp:ListItem Value="Int32">整數</asp:ListItem>
                    <asp:ListItem Value="String">字串</asp:ListItem>
                </asp:DropDownList>, Base Table Name:
                <asp:TextBox ID="txtBasetableName" runat="server"></asp:TextBox></p>
            <p>
                Password:
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>&nbsp;請見 "btnGetfields_Click"
                的 Source Code</p>
            <p>
                <asp:Button ID="btnGetfields" runat="server" Text="Get Fields"></asp:Button><br />
                <span style="color: red; font-size: 12px">新版會讀資庫欄位註解，請用 "中文名稱或說明@Type$例舉1=值1,例舉2=值2"
                    的格式做註解，@ 和 $ 請擇一使用。<br />
                    在 View 中可增加擴充屬性 "Fields"，可多行。格式: FieldName:中文名稱或說明@Type$例舉1=值1,例舉2=值2<br />
                    Is_ 開頭的欄位，請不要加入 @boolean_yn，Is_XXX 會定義為 string, IsXXX 會定義為 boolean<br />
                </span>
            </p>
            <p>
                <asp:Button ID="btnResultFromFields" runat="server" Text="由所得欄位產生程式碼"></asp:Button>
                <asp:CheckBox ID="cbTail" runat="server" Text="不產生結尾段落"></asp:CheckBox><asp:CheckBox
                    ID="cbAddNameSpace" runat="server" Text="加入 NameSpace" Checked="true"></asp:CheckBox></p>
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
                            Type 對應表</p>
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
            <asp:Button ID="btnGenerate" runat="server" Text="由 TextArea 產生程式碼" Visible="false">
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
