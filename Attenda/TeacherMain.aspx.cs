using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Attenda
{
    public partial class TeacherMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_type"] == null || Session["user_type"].ToString() != "teacher")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                int teacherId = Convert.ToInt32(Session["user_id"]);
            }
        }

        protected void ViewCourseButton_Click(object sender, EventArgs e)
        {
            // Code to display the student's course schedule goes here
        }

        protected void CreateAttendaButton_Click(object sender, EventArgs e)
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