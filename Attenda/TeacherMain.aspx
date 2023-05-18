﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherMain.aspx.cs" Inherits="Attenda.TeacherMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Main</title>
    <link rel="stylesheet" type="text/css" href="Styles/teachermain.css" />
</head>
<body>
    <form id="FormCreate" runat="server">
        <div class="header">
            <h1>Welcome to Attenda, Teacher</h1>
            <div class="logout-link">
                <asp:LinkButton ID="logoutButton" CssClass="logout-button" runat="server" OnClick="LogoutButton_Click">Logout</asp:LinkButton>
            </div>
        </div>
        <div class="content">
        <div class="options">
            <div class="option">
                <h2>View Courses</h2>
                <asp:Button ID="viewScheduleButton"  CssClass="option-button" Text="View Schedule" OnClick="ViewCourseButton_Click" runat="server" />
            </div>
            <div class="option">
                <h2>Create Attenda Code</h2>
                <asp:Button ID="giveAttendanceButton"   CssClass="option-button" Text="Create Attendance Code" OnClick="CreateAttendaButton_Click" runat="server" />
            </div>
        </div>
         <div class="flex-container">
            <asp:GridView ID="scheduleGridView" runat="server" CssClass="schedule-grid" AutoGenerateColumns="true"></asp:GridView>
        </div>
         

             <div class="flex-container" id="assign-student">
                <h1>Create Session Code</h1>
                <br />
                <asp:Label ID="lblCourse" runat="server" Text="Course:"></asp:Label>
                <asp:DropDownList ID="ddl2Courses" runat="server"></asp:DropDownList>
                <br />
                <asp:Label ID="lblDay" runat="server" Text="Day"></asp:Label>
                <asp:TextBox ID="txtDay" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblHour" runat="server" Text="Hour"></asp:Label>
                <asp:TextBox ID="txtHour" runat="server"></asp:TextBox>
                 <br />
                <asp:Button ID="btnGenerateCode" runat="server" Text="Get Code" OnClick="btnGenerateCode_Click" />
                <asp:Label ID="lblCode" runat="server" Text=""></asp:Label>
            </div>
         </div>
    </form>
</body>
</html>
<style>
    .flex-container {
        display: flex;
        justify-content: center;
        overflow: auto;

    }
    .schedule-grid {
        width: 100%;
        border-collapse: collapse;
         border-color: darkorange;
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
    
body {
    font-family: 'DM Sans', sans-serif;
    overflow: hidden;
    overflow-x: hidden;
    background-image: linear-gradient(to top, #a3bded 0%, #6991c7 100%);
    background-position: center;
    background-size: cover;
}
.content {
    overflow-y: scroll;
    max-height:700px;
    overflow: auto;
}

.flex-container {
    display: flex;
    flex-direction: column;
    flex-wrap: wrap;
    justify-content: flex-start;
    align-items: flex-start;
    font-size: 20px;
    margin: 50px auto;
    max-width: 800px;
    padding: 20px;
    background-color: #f8f8f8;
    border-radius: 10px;
    overflow: auto;
}

    .flex-container label {
        font-size: 16px;
        margin-bottom: 5px;
        color: #333;
        font-family: 'DM Sans', sans-serif;
    }

    .flex-container input[type="text"],
    .flex-container input[type="password"],
    .flex-container select {
        border: 1px solid #ccc;
        border-radius: 4px;
        box-shadow: inset 0 1px 2px rgba(15, 15, 16, 0.2);
        font-size: 16px;
        padding: 10px;
        width: 100%;
    }

    .flex-container input[type="submit"] {
        background-color: #6991c7;
        border: none;
        border-radius: 4px;
        box-shadow: 0 2px 2px rgba(15, 15, 16, 0.2);
        color: #fff;
        cursor: pointer;
        font-size: 16px;
        margin-top: 20px;
        padding: 10px;
        width: 100%;
        transition: .2s;
    }

        .flex-container input[type="submit"]:hover {
            transform: translateY(-5px);
            box-shadow: 0 10px 20px rgba(15, 15, 16, 0.2);
            background-color: #5a5a5a;
        }

    .flex-container .error-message {
        color: #FF0000;
        font-size: 14px;
        margin-top: 10px;
        text-align: center;
    }

    .flex-container select {
        padding: 10px;
        font-size: 16px;
    }
.left-area {
    border-top-right-radius: 50px;
    position: fixed;
    top: 100px;
    left: 0;
    bottom: 0;
    padding: 15px;
    flex-basis: 1 0 132px;
    background-color: #6991c7;
    display: inline-flex;
    flex-direction: column;
    align-items: flex-start;
}

    .left-area a {
        font-family: 'DM Sans', sans-serif;
        background-color: #6991c7;
        border: none;
        color: #fff;
        cursor: pointer;
        font-size: 16px;
        padding: 10px 20px;
        transition: .2s;
        display: inline-block;
    }

    .left-area h3 {
        font-size: 30px;
        margin-bottom: 16px;
        color: var(--dark-font);
    }

    .left-area.show {
        transform: translateX(0);
        opacity: 1;
    }

.header {
    background-color: rgba(255, 255, 255, 0.9);
    border-color: darkorange;
    color: var(--dark-font);
    padding: 32px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    position: relative;
    z-index: 999;
    width: 100%;
}

    .header .logout-link {
        font-size: 16px;
        color: var(--light-font);
        cursor: pointer;
        transition: .2s;
    }

.options {
    margin: 50px auto;
    max-width: 1200px;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-wrap: wrap;
}

.option {
    background-color: rgba(255, 255, 255, 0.9);
    border: 1px solid rgba(15, 15, 16, 0.1);
    border-radius: 10px;
    box-shadow: 0 0 0 10px rgba(255, 255, 255, 0.4);
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    margin: 10px;
    max-width: 250px;
    width: 100%;
    height: 300px;
    padding: 20px;
    text-align: center;
    transition: .2s;
    box-shadow: 0 10px 20px rgba(15, 15, 16, 0.2);
}

    .option h2 {
        font-size: 24px;
        margin-bottom: 16px;
        color: var(--dark-font);
    }

.option-button {
    background-color: #6991c7;
    border: none;
    border-radius: 4px;
    box-shadow: 0 2px 2px rgba(15, 15, 16, 0.2);
    color: #fff;
    cursor: pointer;
    font-size: 16px;
    margin-top: 32px;
    padding: 10px 20px;
    transition: .2s;
}

    .option-button:hover {
        background-color: #5A5A5A;
    }

{
    background-color: #0072ff;
}


.logout-button {
    display: inline-block;
    border-radius: 4px;
    border: none;
    background-color: #6991c7;
    color: #fff;
    cursor: pointer;
    font-size: 16px;
    font-weight: bold;
    padding: 10px 20px;
    text-align: center;
    text-decoration: none;
    transition: background-color 0.3s ease;
}

    .logout-button:hover {
        background-color: #5A5A5A;
    }

* {
    box-sizing: border-box;
    margin: 0;
    padding: 0;
}

html {
    scroll-behavior: smooth;
}

html, body {
    width: 100%;
    height: 100%;
    margin: 0;
}



.option:hover {
    transform: translateY(-5px);
    box-shadow: 0 10px 20px rgba(15, 15, 16, 0.2);
}

</style>