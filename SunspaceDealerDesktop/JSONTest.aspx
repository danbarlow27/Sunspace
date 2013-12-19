<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSONTest.aspx.cs" Inherits="SunspaceDealerDesktop.JSONTest" %>

<!DOCTYPE html>
<script>
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblJSON" runat="server">Test Failed</asp:Label>
    </div>
    
        <asp:TextBox ID="txtShit" runat="server" OnChange="runme()"></asp:TextBox>
        <asp:Button ID="btnFuck" runat="server" OnClick="btnFuck_Click" />
    </form>

    <input id="hidRealHidden" type="hidden" runat="server" />
</body>
</html>
