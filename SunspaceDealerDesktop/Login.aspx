<%@ Page Title="Dealer Desktop Login" Language="C#" MasterPageFile="~/NoIcons.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SunspaceDealerDesktop.Login" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:Table ID="tblLogin" CssClass="tblLogin" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="2">
                <h1>Please login</h1>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2" CssClass="tdErrorLogin">
                <asp:Label runat="server" ID="lblError" CssClass="lblErrorLogin" Text= "" ></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="lblUsername" Text="Username: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="txtUsername" CssClass="txtField txtInput"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="lblPassword" Text="Password: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="txtPassword" CssClass="txtField txtInput" TextMode="Password"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Button runat="server" ID="btnLogin" CssClass="btnSubmit btnLogin" Text="Login" OnClick="btnLogin_Click"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

        
    
    <asp:SqlDataSource ID="sdsLogin" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [customers]"></asp:SqlDataSource>
</asp:Content>
