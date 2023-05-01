using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Attenda
{
    public partial class TeacherMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Code to load the student's course schedule goes here
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
            // Code to run when the logout button is clicked
        }
    }
}