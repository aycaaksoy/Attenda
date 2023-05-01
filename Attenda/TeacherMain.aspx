<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherMain.aspx.cs" Inherits="Attenda.TeacherMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Main</title>
    <link rel="stylesheet" type="text/css" href="Styles/teachermain.css" />
</head>
<body>
    <form id="Form1" runat="server">
        <div class="header">
            <h1>Welcome to Attenda, Teacher</h1>
            <div class="logout-link">
                <asp:LinkButton ID="logoutButton" CssClass="logout-button" runat="server" OnClick="LogoutButton_Click">Logout</asp:LinkButton>
            </div>
        </div>
        <div class="options">
            <div class="option">
                <h2>View Courses</h2>
                <asp:Button ID="viewScheduleButton"  CssClass="option-button" Text="View Schedule" OnClick="ViewCourseButton_Click" runat="server" />
            </div>
            <div class="option">
                <h2>Create Attenda Code</h2>
                <asp:Button ID="giveAttendanceButton"   CssClass="option-button" Text="Give Attendance" OnClick="CreateAttendaButton_Click" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
