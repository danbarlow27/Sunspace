<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SunspaceDealerDesktop.index" %>
<!--
JWB: Super simple redirect page so everyone can being annoyed how it doesn't launch login.aspx first!
-->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sunspace</title>
    <script>
        // This can probably be replaced with a asp redirect.
        window.location.replace("Login.aspx");
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p>If you aren't redirected, click <a href="Login.aspx">here.</a></p>
    </div>
    </form>
</body>
</html>
