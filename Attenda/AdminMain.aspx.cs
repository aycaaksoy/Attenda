using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Attenda
{
    public partial class AdminMain : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_type"] == null || Session["user_type"].ToString() != "admin")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                int adminId = Convert.ToInt32(Session["user_id"]);
                
            }
        }

        protected void NoName(object sender, EventArgs e)
        {
            // Code to display the student's course schedule goes here
        }

        protected void NoName1(object sender, EventArgs e)
        {
            // Code to allow the student to give attendance goes here
        }
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear(); 
            Response.Redirect("Login.aspx"); 
        }


        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int age = int.Parse(txtAge.Text);
            string department = txtDepartment.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string accountType = ddlAccountType.SelectedValue;

           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "";
                if (accountType == "Student")
                {
                    query = "INSERT INTO Student (student_username, student_password, student_name, student_age, student_department) " +
                            "VALUES (@Username, @Password, @Name, @Age, @Department)";
                }
                else if (accountType == "Teacher")
                {
                    query = "INSERT INTO Teacher (teacher_username, teacher_password, teacher_name, teacher_age, teacher_department) " +
                            "VALUES (@Username, @Password, @Name, @Age, @Department)";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Age", age);
                    command.Parameters.AddWithValue("@Department", department);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

    }
}