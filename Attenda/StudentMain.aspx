<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentMain.aspx.cs" Inherits="Attenda.StudentMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Main</title>
    <link rel="stylesheet" type="text/css" href="Styles/studentmain.css" />
</head>
<body>
    <form id="Form1" runat="server">
        <div class="header">
            <h1>Welcome to Attenda, Student</h1>
            <div class="logout-link">
                <asp:LinkButton ID="logoutButton" CssClass="logout-button" runat="server" OnClick="LogoutButton_Click">Logout</asp:LinkButton>
            </div>
        </div>
        <div class="options">
            <div class="option">
                <h2>Course Schedule</h2>
                <asp:Button ID="viewScheduleButton"  CssClass="option-button" Text="View Schedule" OnClick="ShowScheduleButton_Click" runat="server" />
            </div>
            <div class="option">
                <h2>Give Attendance</h2>
                <asp:Button ID="giveAttendanceButton"   CssClass="option-button" Text="Give Attendance" OnClick="GiveAttendanceButton_Click" runat="server" />
            </div>
        </div>
    </form>

</body>
</html>
