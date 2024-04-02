using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DBMidProject.Forms
{
    public partial class reslut : Form
    {


        public reslut()
        {
            InitializeComponent();
            try
            {

                getId();
                displayData();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        


        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void getId()
        {
            try
            {

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select Id from Student where Status=5", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student.Items.Add(reader["Id"].ToString());
                }
                reader.Close();
                //Fill the combobox with the data from the database
                var con1 = Configuration.getInstance().getConnection();
                SqlCommand cmd1 = new SqlCommand("Select Id from AssessmentComponent Where Name not like '%del'", con1);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    Assement.Items.Add(reader1["Id"].ToString());
                }
                reader1.Close();
                //Fill the combobox with the data from the database
                var con2 = Configuration.getInstance().getConnection();
                SqlCommand cmd2 = new SqlCommand("Select Id from RubricLevel ", con2);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    rubric.Items.Add(reader2["Id"].ToString());
                }
                reader2.Close();
                rubric.SelectedIndex = 0;
                Student.SelectedIndex = 0;
                Assement.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while getting ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void displayData()
        {
            try
            {
               
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select * from StudentResult", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                data.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while displaying data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            try
            { 
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT 1 FROM StudentResult WHERE StudentId = @StudentId AND AssessmentComponentId = @AssessmentComponentId) " +
                                                 "BEGIN " +
                                                 "INSERT INTO StudentResult (StudentId, AssessmentComponentId, RubricMeasurementId, EvaluationDate) VALUES (@StudentId, @AssessmentComponentId, @RubricMeasurementId, GETDATE()) " +
                                                 "END", con);
                cmd.Parameters.AddWithValue("@StudentId", Student.Text);
                cmd.Parameters.AddWithValue("@AssessmentComponentId", Assement.Text);
                cmd.Parameters.AddWithValue("@RubricMeasurementId", rubric.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    displayData();
                    MessageBox.Show("Data Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data already exists for the selected student and assessment component.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
