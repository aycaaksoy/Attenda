<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMain.aspx.cs" Inherits="Attenda.AdminMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Main</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <link href='https://fonts.googleapis.com/css?family=Lato:400,300,700' rel='stylesheet' type='text/css' />
    <link rel="stylesheet" type="text/css" href="Styles/adminmain.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function () {
            $(".flex-container").hide();

            var anchor = window.location.hash;
            if (anchor) {
                var sectionId = anchor.substring(1);
                $("#" + sectionId).show();
                $("#" + sectionId + "-link").addClass("active");
            }


            $(".item-link").click(function () {

                $(".item-link").removeClass("active");


                $(".flex-container").hide();


                var sectionId = $(this).attr("data-section");
                $("#" + sectionId).show();


                $(this).addClass("active");
            });

        });
    </script>

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
            <div class="flex-container" id="assign-student">
                <h1>Assign Student to a Course</h1>
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

            <div class="flex-container" id="unassign-student">
                <h1>Unassign Student from a Course</h1>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Course Name"></asp:Label>
                <asp:DropDownList ID="ddlAssignedCourseName" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Text="Select Course" Value=""></asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="lblStudentName" runat="server" Text="Student Name"></asp:Label>
                <asp:DropDownList ID="ddlAssignedStudentName" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Text="Select Student" Value=""></asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Button ID="btnUnassignStudent" runat="server" Text="Unassign Student" OnClick="btnUnassignStudent_Click" />
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            </div>
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
                <h1>Create Course</h1>
                <br />
                <asp:Label ID="lblCourseName" runat="server" Text="Course Name"></asp:Label>
                <asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox>

                <br />
                <asp:Label ID="lblQuota" runat="server" Text="Quota"></asp:Label>
                <asp:TextBox ID="txtQuota" runat="server"></asp:TextBox>
                 
                <br />
                <asp:Label ID="Label5" runat="server" Text="Day"></asp:Label>
                <asp:TextBox ID="txtday" runat="server"></asp:TextBox>

                <br />
                <asp:Label ID="Label6" runat="server" Text="Hour"></asp:Label>
                <asp:TextBox ID="txthour" runat="server"></asp:TextBox>

                <br />
                <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>

                <asp:Button ID="btnCreateCourse" runat="server" Text="Create Course" OnClick="btnCreateCourse_Click" />
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>

            <div class="flex-container" id="delete-course">
                <h1>Delete Course</h1>
                <br />
                <asp:Label ID="lblCourseNameToDelete" runat="server" Text="Course Name"></asp:Label>
                <asp:TextBox ID="txtCourseNameToDelete" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnDeleteCourse" runat="server" Text="Delete Course" OnClick="btnDeleteCourse_Click" />
                <asp:Label ID="lblDeleteMessage" runat="server" Text=""></asp:Label>
            </div>

            <div class="flex-container" id="change_the_teacher">
                <h1>Change Course Teacher</h1>
                <br />
                <asp:DropDownList ID="ddlNewTeacher" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Text="Select a Teacher" Value=""></asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:DropDownList ID="ddl1Course" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Text="Select a Course" Value=""></asp:ListItem>
                </asp:DropDownList>

                <asp:Button ID="btnChangeTeacher" runat="server" Text="Change Teacher" OnClick="btnChangeTeacher_Click" />
                <asp:Label ID="lblChangeTeacherMessage" runat="server" Text=""></asp:Label>
            </div>

        </div>
    </form>

    <div class="left-area show">
        <h3 class="app-name">Sidebar</h3>
        <a href="#" id="create-course-link" class="item-link" data-section="create_course">Create Course</a>
        <a href="#" id="delete-course-link" class="item-link" data-section="delete-course">Delete Course</a>
        <a href="#" id="assign-student-link" class="item-link" data-section="assign-student">Assign Student</a>
        <a href="#" id="unassign-student-link" class="item-link" data-section="unassign-student">Unassign Student</a>
        <a href="#" id="create-account-link" class="item-link" data-section="create_account">Create Account</a>
        <a href="#" id="change-the-teacher" class="item-link" data-section="change_the_teacher">Change Teacher for a Course</a>
    </div>

</body>
</html>


