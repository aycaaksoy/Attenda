<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMain.aspx.cs" Inherits="Attenda.AdminMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Main</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css">
    <link href='https://fonts.googleapis.com/css?family=Lato:400,300,700' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" type="text/css" href="Styles/adminmain.css" />
</head>


<body>


    <form id="Form1" runat="server">
        <div class="header">
            <h1>Welcome to Attenda, Admin</h1>
            <div class="logout-link">
                <asp:LinkButton ID="logoutButton" CssClass="logout-button" runat="server" OnClick="LogoutButton_Click">Logout</asp:LinkButton>
            </div>
        </div>

    </form>

    <div class="left-area show">
        <h3 class="app-name">Sidebar</h3>
        <a href="#" class="item-link">Create Course</a>
        <a href="#" class="item-link">Delete Course</a>
        <a href="#" class="item-link">Assign Student</a>
        <a href="#" class="item-link">Unassign Student</a>
        <a href="#" class="item-link">Create Account</a>
    </div>

</body>
</html>


<script>
    const toggleButton = document.getElementById('toggle-button');
    const sidebar = document.querySelector('.sidebar');

    toggleButton.addEventListener('click', function () {
        sidebar.classList.toggle('sidebar-closed');
    });
</script>
