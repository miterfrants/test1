<%@ Page Language="VB" AutoEventWireup="false" CodeFile="import-goods.aspx.vb" Inherits="admin_upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="fuGoodsCsv" runat="server" />
        <asp:Button ID="btnUpload" Text="匯入物品" runat="server" />
    </div>
    </form>
</body>
</html>
