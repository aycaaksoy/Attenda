<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Attenda.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="Styles/login.css" />
</head>
<body>
    <form id="Form1" runat="server" class="login-form">
        <div>
            <h1>Login to Attenda</h1>
            <br />

            <div>
                <label for="username">Username:</label>
                <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <label for="password">Password:</label>
                <asp:TextBox ID="txtpassword" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="loginButton" Text="Login" OnClick="LoginButton_Click" runat="server" />
            <asp:Label ID="txterrorLabel" runat="server" CssClass="error-message" Visible="true"></asp:Label>
        </div>
    </form>
</body>
</html>
