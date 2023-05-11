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
                try {
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
                    lblMessage.Text = "Course created successfully.";
                }
                catch 
                {
                    lblMessage.Text = "Error! Contact to your admin";   
                }
               
            }
        }
        protected void btnCreateCourse_Click(object sender, EventArgs e)
        {
            string courseName = txtCourseName.Text;
            int quota = Convert.ToInt32(txtQuota.Text);
            string description = txtDescription.Text;
            int teacherId = GetAdminId(); 

            
            if (InsertCourse(courseName, quota, description, teacherId))
            {
                Label1.Text = "Course created successfully.";
              
                txtCourseName.Text = "";
                txtQuota.Text = "";
                txtDescription.Text = "";
            }
            else
            {
                Label1.Text = "Failed to create the course.";
            }
        }
        private bool InsertCourse(string courseName, int quota, string description, int teacherId)
        {
            string query = @"INSERT INTO Course (course_name, course_quota, course_description, teacher_id, is_active)
                     VALUES (@courseName, @quota, @description, @teacherId, 1)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@courseName", courseName);
                command.Parameters.AddWithValue("@quota", quota);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@teacherId", teacherId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                return (rowsAffected > 0);
            }
        }
        private int GetAdminId()
        {
            
            if (Session["user_id"] != null)
            {
                return Convert.ToInt32(Session["user_id"]);
            }
            else
            {
                return -1;
            }
        }

        protected void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            
            string courseName = txtCourseNameToDelete.Text;

            
            bool deletionSuccess = DeleteCourse(courseName);

            if (deletionSuccess)
            {
                lblDeleteMessage.Text = "Course deleted successfully.";
            }
            else
            {
                lblDeleteMessage.Text = "Failed to delete the course.";
            }
        }

        private bool DeleteCourse(string courseName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM Course WHERE course_name = @CourseName";

                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@CourseName", courseName);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
                return rowsAffected > 0;
            }
        }
    }
}