using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Attenda
{
    public partial class StudentMain : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
        }

        protected void ShowScheduleButton_Click(object sender, EventArgs e)
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

        protected void GiveAttendanceButton_Click(object sender, EventArgs e)
        {
            string code = txtgiveAttendance.Text;
            int studentId = Convert.ToInt32(Session["user_id"]);
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO SessionStudents (student_id) SELECT @StudentId FROM CourseStudents cs JOIN Session s ON cs.course_id = s.course_id WHERE s.code = @Code";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Code", code);
                            command.Parameters.AddWithValue("@StudentId", studentId);
                            int rowsEffected = command.ExecuteNonQuery();
                            if (rowsEffected > 0)
                            {
                                txtgiveAttendance.Text = "";
                                lblAttendance.Text = "Attendance submitted successfully.";
                                lblAttendance.ForeColor = System.Drawing.Color.Green;
                            }
                        else
                        {
                            lblAttendance.Text = "Error! There is no session with this code!";
                            lblAttendance.ForeColor = System.Drawing.Color.Red;
                        }
                        }
                }
            }
            catch
            {
                lblAttendance.Text = "Error! Contact to your admin";
                lblAttendance.ForeColor = System.Drawing.Color.Red;
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
            int studentid = Convert.ToInt32(Session["user_id"]);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "Select c.course_name, c.course_day , c.course_hour From Student s, Course c, CourseStudents cs Where s.student_id = @studentId  AND s.student_id = cs.student_id AND cs.course_id = c.course_id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentid);

                    command.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(scheduleData);
                }
                connection.Close();
            }

            return scheduleData;
        }

    }
}

