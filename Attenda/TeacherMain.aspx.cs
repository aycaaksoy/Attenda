using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace Attenda
{
    public partial class TeacherMain : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user_type"] == null || Session["user_type"].ToString() != "teacher")
                {
                    Response.Redirect("Login.aspx");

                }
                else
                {
                    int teacherId = Convert.ToInt32(Session["user_id"]);
                    PopulateCourses();
                }
            }
        
        }

        protected void ViewCourseButton_Click(object sender, EventArgs e)
        {
            DataTable scheduleDatav1 = new DataTable();
            scheduleDatav1 = GetScheduleData();
            foreach (DataRow row in scheduleDatav1.Rows)
            {
                string course = row["course_name"].ToString();
                string day = row["course_day"].ToString();
                string hour = row["Course_hour"].ToString();

                string cellId = $"{day.ToLower()}-{hour.ToLower().Replace(" ", "-")}";
                TableCell cell = FindControl(cellId) as TableCell;

                if (cell != null)
                {
                    cell.Text = course;
                }
            }
            scheduleGridView.DataSource = scheduleDatav1;
            scheduleGridView.DataBind();
        }

        protected void AttendaRecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("AttendanceRecords.aspx");

        }

        protected void btnGenerateCode_Click(object sender, EventArgs e)
        {
            string c = ddl2Courses.Text;
            int course = int.Parse(c);
            string day = txtDay.Text;
            string hour = txtHour.Text;
            string code = GenerateUniqueCode(8);
            //int courseId = GetCourseId(course);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Session (course_id, course_hour, course_day, code, isActive) VALUES (@CourseId, @CourseHour, @CourseDay, @Code, @IsActive)";   
                
                try
                {

                    using (SqlCommand command = new SqlCommand( query, connection))
                    {
                        command.Parameters.AddWithValue("@CourseId", course);
                        command.Parameters.AddWithValue("@CourseHour", hour);
                        command.Parameters.AddWithValue("@CourseDay", day);
                        command.Parameters.AddWithValue("@Code", code);
                        command.Parameters.AddWithValue("@IsActive", 1);
                        command.ExecuteNonQuery();
                    }
                    txtDay.Text = "";
                    txtHour.Text = "";


                    lblCode.Text = "Course created successfully. Attendance Code: " + code ;
                    lblCode.ForeColor = System.Drawing.Color.Green;
                }
                catch
                {
                    lblCode.Text = "Error! Contact to your admin";
                    lblCode.ForeColor = System.Drawing.Color.Red;
                }
                finally { connection.Close(); }

            }
        }
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear(); 
            Response.Redirect("Login.aspx"); 
        }
        private DataTable GetScheduleData()
        {

            DataTable scheduleData = new DataTable();
            int teacherid = Convert.ToInt32(Session["user_id"]);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "Select c.course_name, c.course_day , c.course_hour From Course c Where c.teacher_id = @teacherId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@teacherId", teacherid);

                    command.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(scheduleData);
                }
                connection.Close();
            }

            return scheduleData;
        }

        private void PopulateCourses()
        {
            ddl2Courses.DataSource = "";
            int teacherid = Convert.ToInt32(Session["user_id"]);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT course_id, course_name FROM Course c Where c.teacher_id = @teacherId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@teacherId", teacherid);

                    command.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    ddl2Courses.DataSource = dataTable;
                    ddl2Courses.DataTextField = "course_name";
                    ddl2Courses.DataValueField = "course_id";
                    ddl2Courses.DataBind();
                } 
                connection.Close();
            }
        }
        public string GenerateUniqueCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var code = new char[length];

            using (var dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();

                bool isUnique = false;
                string randomCode = string.Empty;

                while (!isUnique)
                {
                    for (int i = 0; i < length; i++)
                    {
                        code[i] = chars[random.Next(chars.Length)];
                    }

                    randomCode = new string(code);

                   
                    using (var command = new SqlCommand("SELECT COUNT(*) FROM Session WHERE Code = @Code", dbConnection))
                    {
                        command.Parameters.AddWithValue("@Code", randomCode);
                        int count = (int)command.ExecuteScalar();

                        if (count == 0)
                        {
                            isUnique = true;
                            break;
                        }
                    }
                }

                return randomCode;
            }
        }

    }
}