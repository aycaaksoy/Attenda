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

            // Check if the user is an admin
            if (CheckAdminLogin(username, password))
            {
                // Redirect the user to the admin page
                Response.Redirect("AdminMain.aspx");
            }

            // Check if the user is a student
            else if (CheckStudentLogin(username, password))
            {
                // Redirect the user to the student page
                Response.Redirect("StudentMain.aspx");
            }

            // Check if the user is a teacher
            else if (CheckTeacherLogin(username, password))
            {
                // Redirect the user to the teacher page
                Response.Redirect("TeacherMain.aspx");
            }

            // If the user's credentials are invalid, display an error message
            else
            {
                txterrorLabel.Text = "Invalid username or password.";
            }
        }

        private bool CheckAdminLogin(string username, string password)
        {
            // Check the Admin table for a matching username and password
            string query = "SELECT COUNT(*) FROM Admin WHERE username=@username AND password=@password";
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
            // Check the Student table for a matching username and password
            string query = "SELECT COUNT(*) FROM Student WHERE username=@username AND password=@password";
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
            // Check the Teacher table for a matching username and password
           
            string query = "SELECT COUNT(*) FROM Teacher WHERE username=@username AND password=@password";
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