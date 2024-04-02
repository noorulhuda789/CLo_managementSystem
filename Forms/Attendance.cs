using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DBMidProject.Bl;

namespace DBMidProject.Forms
{
    public partial class Attendance : Form
    {
        List<String> studentInfoList = new List<String>();
        int classID = 0;

        public Attendance()
        {
            InitializeComponent();
            displayData();
        }

        private void displayData()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select s.firstname as [First Name], s.lastname as [Last Name], " +
                                                " s.RegistrationNumber as [Registration No],  l.name as Status " +
                                                "from student s join lookup l on s.status=l.LookupId where l.lookupid = 5", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                attendanceGrid.DataSource = dt;
                attendanceGrid.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while displaying data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                loadClassAttendance();
                getStudentStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while submitting attendance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadClassAttendance()
        {
            try
            {
                string query = "INSERT INTO ClassAttendance (AttendanceDate) VALUES (@time);";
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@time", guna2DateTimePicker1.Value);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while loading class attendance: " + ex.Message);
            }
        }

        private void getClassId()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "SELECT TOP(1) Id FROM ClassAttendance ORDER BY Id DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                classID = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting class ID: " + ex.Message);
            }
        }

        private void getStudentStatus()
        {
            try
            {
                getClassId();
                string registration = "";
                int sID = 0;
                foreach (DataGridViewRow row in attendanceGrid.Rows)
                {
                    registration = row.Cells[3].Value.ToString();
                    sID = getRegId(registration);

                    if (row.Cells[0].Value == null) { MessageBox.Show("Attendance not marked against a student"); }

                    else if (row.Cells[0].Value.ToString() == "Present")
                    {
                        insertStudents(sID, 1);
                        MessageBox.Show("All Attendances have been successfully inserted for today.");
                    }
                    else if (row.Cells[0].Value.ToString() == "Absent")
                    {
                        insertStudents(sID, 2);
                        MessageBox.Show("All Attendances have been successfully inserted for today.");
                    }
                    else if (row.Cells[0].Value.ToString() == "Leave")
                    {
                        insertStudents(sID, 3);
                        MessageBox.Show("All Attendances have been successfully inserted for today.");
                    }
                    else if (row.Cells[0].Value.ToString() == "Late")
                    {
                        insertStudents(sID, 4);
                        MessageBox.Show("All Attendances have been successfully inserted for today.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting student status: " + ex.Message);
            }
        }

        private int getRegId(string Reg)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "SELECT Id FROM Student WHERE RegistrationNumber = @reg";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@reg", Reg);
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting registration ID: " + ex.Message);
            }
        }

        private void insertStudents(int sId, int status)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "INSERT INTO StudentAttendance (AttendanceID,StudentID,AttendanceStatus) VALUES (@attID,@stuID,@stat)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@attID", classID);
                cmd.Parameters.AddWithValue("@stuID", sId);
                cmd.Parameters.AddWithValue("@stat", status);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting students: " + ex.Message);
            }
        }
    }
}
