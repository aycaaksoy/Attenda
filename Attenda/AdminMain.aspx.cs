using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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
            if (!IsPostBack)
            {
                if (Session["user_type"] == null || Session["user_type"].ToString() != "admin")
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    int adminId = Convert.ToInt32(Session["user_id"]);
                    PopulateCourses();
                    PopulateStudents();
                    PopulateAssignedCourse();
                    PopulateAssignedStudent();
                    PopulateTeachers();
                }
            }
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
            
        }

        protected void NoName1(object sender, EventArgs e)
        {
           
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
                        
                    }
                    txtAge.Text = "";
                    txtName.Text = "";
                    txtDepartment.Text = "";
                    txtUsername.Text = "";
                    lblMessage.Text = "Course created successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                catch 
                {
                    lblMessage.Text = "Error! Contact to your admin";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                finally { connection.Close(); }
               
            }
        }
        protected void btnCreateCourse_Click(object sender, EventArgs e)
        {
            string courseName = txtCourseName.Text;
            int quota = Convert.ToInt32(txtQuota.Text);
            string day = txtday.Text;
            string hour = txthour.Text; 
            string description = txtDescription.Text;
            int teacherId = GetAdminId(); 

            
            if (InsertCourse(courseName, quota, description, teacherId, day, hour))
            {
                Label1.Text = "Course created successfully.";
                Label1.ForeColor = System.Drawing.Color.Green;
                txtCourseName.Text = "";
                txtQuota.Text = "";
                txtDescription.Text = "";
            }
            else
            {
                Label1.Text = "Failed to create the course.";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            
            string courseName = txtCourseNameToDelete.Text;

            
            bool deletionSuccess = DeleteCourse(courseName);

            if (deletionSuccess)
            {
                lblDeleteMessage.Text = "Course deleted successfully.";
                lblDeleteMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblDeleteMessage.Text = "Failed to delete the course.";
                lblDeleteMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnAssign_Click(object sender, EventArgs e)
        {

            string courseId = ddlCourses.SelectedValue;
            string studentId = ddlStudents.SelectedValue;


            bool success = AssignStudentToCourse(courseId, studentId);

            if (success)
            {
                Label2.Text = "Student assigned to course successfully.";
                Label2.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Label2.Text = "Failed to assign student to course.";
                Label2.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnUnassignStudent_Click(object sender, EventArgs e)
        {
            string selectedCourseId = ddlAssignedCourseName.SelectedValue;
            string selectedStudentId = ddlAssignedStudentName.SelectedValue;

            if (string.IsNullOrEmpty(selectedCourseId) || string.IsNullOrEmpty(selectedStudentId))
            {
                Label4.Text = "Please select both a course and a student.";
                Label4.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM CourseStudents WHERE course_id = @courseId AND student_id = @studentId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@courseId", selectedCourseId);
                        command.Parameters.AddWithValue("@studentId", selectedStudentId);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Label4.Text = "Student unassigned from the selected course successfully.";
                            Label4.ForeColor = System.Drawing.Color.Green;

                        }
                        else
                        {
                            Label4.Text = "Failed to unassign the student from the course.";
                            Label4.ForeColor = System.Drawing.Color.Red;
                        }
                        
                    }
                    connection.Close();
                }
            }
            catch
            {

                Label4.Text = "Selected Student is not assigned to the Selected Course ";
                Label4.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected void btnChangeTeacher_Click(object sender, EventArgs e)
        {
            string teacherId = ddlNewTeacher.SelectedValue;
            string selectedCourseId = ddl1Course.SelectedValue;

            bool success = ChangeCourseTeacher(selectedCourseId, teacherId);

            if (success)
            {
                lblChangeTeacherMessage.Text = "Course teacher changed successfully.";
            }
            else
            {
                lblChangeTeacherMessage.Text = "Failed to change the course teacher.";
            }
        }
        private bool DeleteCourse(string courseName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Course WHERE course_name = @CourseName";

                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@CourseName", courseName);

               
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
                return rowsAffected > 0;
            }
        }
        private void PopulateCourses()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT course_id, course_name FROM Course";
                SqlCommand command = new SqlCommand(query, connection);
               
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                ddlCourses.DataSource = dataTable;
                ddlCourses.DataTextField = "course_name";
                ddlCourses.DataValueField = "course_id";
                ddlCourses.DataBind();
                ddl1Course.DataSource = dataTable;
                ddl1Course.DataTextField = "course_name";
                ddl1Course.DataValueField = "course_id";
                ddl1Course.DataBind();
                connection.Close();
            }
        }
        private void PopulateStudents()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT student_id, student_name FROM Student";
                SqlCommand command = new SqlCommand(query, connection);
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                ddlStudents.DataSource = dataTable;
                ddlStudents.DataTextField = "student_name";
                ddlStudents.DataValueField = "student_id";
                ddlStudents.DataBind();
                connection.Close();
            }
        }

        private bool ChangeCourseTeacher(string courseId, string teacherId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = "UPDATE Course SET teacher_id = @TeacherId WHERE course_id = @CourseId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CourseId", courseId);
                    command.Parameters.AddWithValue("@TeacherId", teacherId);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch
            {
                
                lblChangeTeacherMessage.Text = "Error";
                lblChangeTeacherMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }
        }
        private void PopulateTeachers()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "SELECT teacher_id, teacher_name FROM Teacher";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                ddlNewTeacher.DataSource = dataTable;
                ddlNewTeacher.DataTextField = "teacher_name";
                ddlNewTeacher.DataValueField = "teacher_id";
                ddlNewTeacher.DataBind();
                connection.Close();
            }
        }
        private bool AssignStudentToCourse(string courseId, string studentId)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                    string checkQuery = "SELECT COUNT(*) FROM CourseStudents WHERE course_id = @CourseId AND student_id = @StudentId";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@CourseId", courseId);
                    checkCommand.Parameters.AddWithValue("@StudentId", studentId);
                    connection.Open();
                    int count = (int)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        
                        return false;
                    }
                    string query = "INSERT INTO CourseStudents (course_id, student_id) VALUES (@CourseId, @StudentId)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CourseId", courseId);
                    command.Parameters.AddWithValue("@StudentId", studentId);
                    
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                    
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
        private void PopulateAssignedCourse()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Distinct c.course_name, c.course_id FROM  Course c, CourseStudents cs Where cs.course_id = c.course_id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            ddlAssignedCourseName.DataSource = reader;
                            ddlAssignedCourseName.DataTextField = "course_name";
                            ddlAssignedCourseName.DataValueField = "course_id";
                            ddlAssignedCourseName.DataBind();
                            
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
               
                lblMessage.Text = "An error occurred while populating the course dropdown: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void PopulateAssignedStudent()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Distinct s.student_name, s.student_id  FROM  Student s, CourseStudents cs Where cs.student_id = s.student_id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            ddlAssignedStudentName.DataSource = reader;
                            ddlAssignedStudentName.DataTextField = "student_name";
                            ddlAssignedStudentName.DataValueField = "student_id";
                            ddlAssignedStudentName.DataBind();
                            
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                
                lblMessage.Text = "An error occurred while populating the student dropdown: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;

            }
        }
        private bool InsertCourse(string courseName, int quota, string description, int teacherId, string day, string hour)
        {
            string query = @"INSERT INTO Course (course_name, course_quota, course_description, teacher_id, is_active, course_day, course_hour)
                     VALUES (@courseName, @quota, @description, @teacherId, 1, @day, @hour)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@courseName", courseName);
                command.Parameters.AddWithValue("@quota", quota);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@teacherId", teacherId);
                command.Parameters.AddWithValue("@day", day);
                command.Parameters.AddWithValue("@hour", hour);

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
    }
}