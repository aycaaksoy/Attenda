<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMain.aspx.cs" Inherits="Attenda.AdminMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Main</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <link href='https://fonts.googleapis.com/css?family=Lato:400,300,700' rel='stylesheet' type='text/css' />
    <link rel="stylesheet" type="text/css" href="Styles/adminmain.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

</head>


<body>
    <form class="FormCreate" runat="server">
        <div class="header">
            <h1>Welcome to Attenda, Admin</h1>
            <div class="logout-link">
                <asp:LinkButton ID="logoutButton" CssClass="logout-button" runat="server" OnClick="LogoutButton_Click">Logout</asp:LinkButton>
            </div>
        </div>
        <div class="content">

            <div class="flex-container" id="create_account">
                <h1>Create Account</h1>
                <br />
                <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblAge" runat="server" Text="Age"></asp:Label>
                <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>
                <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <asp:Label ID="lblAccountType" runat="server" Text="Account Type"></asp:Label>
                <asp:DropDownList ID="ddlAccountType" runat="server">
                    <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                    <asp:ListItem Text="Teacher" Value="Teacher"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" OnClick="btnCreateAccount_Click" />
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>


            <div class="flex-container" id="create_course">
                <h2>Create Course</h2>
                 <br />
                <asp:Label ID="lblCourseName" runat="server" Text="Course Name"></asp:Label>
                <asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblQuota" runat="server" Text="Quota"></asp:Label>
                <asp:TextBox ID="txtQuota" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnCreateCourse" runat="server" Text="Create Course" OnClick="btnCreateCourse_Click" />
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>

            <div class="flex-container" id="delete-course">
                <h2>Delete Course</h2>
                 <br />
                <asp:Label ID="lblCourseNameToDelete" runat="server" Text="Course Name"></asp:Label>
                <asp:TextBox ID="txtCourseNameToDelete" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnDeleteCourse" runat="server" Text="Delete Course" OnClick="btnDeleteCourse_Click" />
                <asp:Label ID="lblDeleteMessage" runat="server" Text=""></asp:Label>
            </div>

            <div class="flex-container" id="assign-student">
            <h1>Assign Student to Course</h1>
            <br />
            <asp:Label ID="lblCourse" runat="server" Text="Course:"></asp:Label>
            <asp:DropDownList ID="ddlCourses" runat="server"></asp:DropDownList>
            <br />
            <asp:Label ID="lblStudent" runat="server" Text="Student:"></asp:Label>
            <asp:DropDownList ID="ddlStudents" runat="server"></asp:DropDownList>
            <br />
            <asp:Button ID="btnAssign" runat="server" Text="Assign" OnClick="btnAssign_Click" />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </div>

        </div>
    </form>

    <div class="left-area show">
        <h3 class="app-name">Sidebar</h3>
        <a href="#" id="create-course-link" class="item-link">Create Course</a>
        <a href="#" id="delete-course-link" class="item-link">Delete Course</a>
        <a href="#" id="assign-student-link" class="item-link">Assign Student</a>
        <a href="#" id="unassign-student-link" class="item-link">Unassign Student</a>
        <a href="#" id="create-account-link" class="item-link">Create Account</a>
    </div>

    <script>

</script>

</body>
</html>


