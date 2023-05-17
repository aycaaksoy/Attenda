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

        <div class="flex-container">
            <asp:GridView ID="scheduleGridView" runat="server" CssClass="schedule-grid" AutoGenerateColumns="true"></asp:GridView>
            
        </div>
    </form>

</body>
</html>
<style>
    .schedule-grid {
        width: 100%;
        border-collapse: collapse;
    }

    .schedule-grid th,
    .schedule-grid td {
        padding: 10px;
        border: 1px solid #ddd;
        text-align: center;
    }

    .schedule-grid th {
        background-color: #f2f2f2;
        font-weight: bold;
    }

    .schedule-grid tr:nth-child(even) {
        background-color: #f9f9f9;
    }

    .schedule-grid tr:hover {
        background-color: #e6e6e6;
    }
</style>