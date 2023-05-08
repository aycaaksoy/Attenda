using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.Activities;

namespace Attenda
{
    public partial class Login : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;

            if (CheckAdminLogin(username, password))
            {
                Response.Redirect("AdminMain.aspx");
            }

            else if (CheckStudentLogin(username, password))
            {
                Response.Redirect("StudentMain.aspx");
            }

            else if (CheckTeacherLogin(username, password))
            {
                Response.Redirect("TeacherMain.aspx");
            }

            else
            {
                txterrorLabel.Text = "Invalid username or password.";
            }
        }

        private bool CheckAdminLogin(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM Admin WHERE admin_username=@username AND admin_password=@password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();
                return (count > 0);
                
            }
        }

        private bool CheckStudentLogin(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM Student WHERE student_username=@username AND student_password=@password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();
                return (count > 0);
                
            }
        }

        private bool CheckTeacherLogin(string username, string password)
        {          
            string query = "SELECT COUNT(*) FROM Teacher WHERE teacher_username=@username AND teacher_password=@password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();
                return (count > 0);
                
            }
        }

    }
}