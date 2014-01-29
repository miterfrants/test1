<%@ Page Language="VB" AutoEventWireup="false" CodeFile="detect_lang.aspx.vb" Inherits="test_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var language = navigator.systemLanguage || window.navigator.userLanguage || window.navigator.language;
        alert(language);
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
