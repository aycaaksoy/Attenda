using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Attenda
{
    public partial class AttendanceRecords : System.Web.UI.Page
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

        protected void GoBackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherMain.aspx");
        }

        protected void GetStudentsAttendance_Click(object sender, EventArgs e)
        {
            scheduleGridView1.DataSource = "";
            string c = DropDownList1.Text;
            DataTable scheduleData = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT  s.student_name, (SELECT COUNT(*) FROM Session s WHERE s.course_id = @CourseId) AS session_count, (COUNT(ss.session_id) * 1.0) / (SELECT COUNT(*) FROM Session s WHERE s.course_id = @CourseId) AS attendance_ratio FROM Course c JOIN CourseStudents cs ON c.course_id = cs.course_id JOIN Student s ON cs.student_id = s.student_id LEFT JOIN SessionStudents ss ON cs.student_id = ss.student_id WHERE c.course_id = @CourseId GROUP BY s.student_id, s.student_name;";
                    try
                    {

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CourseId", c);
                            command.ExecuteNonQuery();
                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            adapter.Fill(scheduleData);
                        }
                        foreach (DataRow row in scheduleData.Rows)
                        {
                            string course = row["student_name"].ToString();
                            string day = row["session_count"].ToString();
                            string hour = row["attendance_ratio"].ToString();

                            string cellId = $"{day.ToLower()}-{hour.ToLower().Replace(" ", "-")}";
                            TableCell cell = FindControl(cellId) as TableCell;

                            if (cell != null)
                            {
                                cell.Text = course;
                            }
                        }
                        scheduleGridView1.DataSource = scheduleData;
                        scheduleGridView1.DataBind();

                    }
                    catch
                    {
                      
                    }
                    finally { connection.Close(); }

                }
            }
            catch
            {

            }
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        private void PopulateCourses()
        {
            DropDownList1.DataSource = "";
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
                    DropDownList1.DataSource = dataTable;
                    DropDownList1.DataTextField = "course_name";
                    DropDownList1.DataValueField = "course_id";
                    DropDownList1.DataBind();
                }
                connection.Close();
            }
        }
    }
}