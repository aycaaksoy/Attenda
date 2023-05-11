using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Attenda
{
    public partial class StudentMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_type"] == null || Session["user_type"].ToString() != "student")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                int studentId = Convert.ToInt32(Session["user_id"]);
            }
        }

        protected void ShowScheduleButton_Click(object sender, EventArgs e)
        {
            // Code to display the student's course schedule goes here
        }

        protected void GiveAttendanceButton_Click(object sender, EventArgs e)
        {
            // Code to allow the student to give attendance goes here
        }
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear(); 
            Response.Redirect("Login.aspx"); 
        }

        

    }
}
