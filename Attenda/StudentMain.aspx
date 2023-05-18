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
                <asp:TextBox ID="txtgiveAttendance" runat="server"></asp:TextBox>
                <asp:Label ID="lblAttendance" runat="server" Text=""></asp:Label>
                <asp:Button ID="btngiveAttendance"   CssClass="option-button" Text="Give Attendance" OnClick="GiveAttendanceButton_Click" runat="server" />
            </div>
        </div>
         
        <div class="flex-container">
            <asp:GridView ID="scheduleGridView" runat="server" CssClass="schedule-grid" AutoGenerateColumns="true"></asp:GridView>
            
        </div>

    </form>

</body>
</html>
<style>
    .flex-container {
        display: flex;
        justify-content: center;
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

.header {
    border-style: solid;
    border-color: darkorange;
    background-color: rgba(255, 255, 255, 0.9);
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

.left-area {
    border-style: solid;
    border-color: darkorange;
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


.item-link {
    font-family: 'DM Sans', sans-serif;
    text-decoration: none;
    color: var(--light-font);
    margin-bottom: 32px;
    transition: .2s;
    border-radius: 4px;
    border: none;
    display: inline-block;
    font-size: 25px;
    font-weight: bold;
    padding: 10px 20px;
    text-align: center;
}

    .item-link:hover {
        transform: translateY(-5px);
        background-color: #5A5A5A;
    }

    .item-link.active {
        color: var(--dark-font);
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

.flex-container {
    display: flex;
    justify-content: center;
}

.schedule-grid {
    width: 100%;
}

    .schedule-grid th,
    .schedule-grid td {
        padding: 10px;
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

    .schedule-grid .empty-cell {
        background-color: #f2f2f2;
        font-style: italic;
        color: #999999;
    }

    .schedule-grid .course-cell {
        font-weight: bold;
    }

        .schedule-grid .course-cell:hover {
            background-color: #d9edf7;
        }
     .option input[type="text"],
    .option input[type="password"],
    .option select {
        border: 1px solid #ccc;
        border-radius: 4px;
        box-shadow: inset 0 1px 2px rgba(15, 15, 16, 0.2);
        font-size: 16px;
        padding: 10px;
        width: 100%;
    }
</style>