using DBMidProject.Bl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMidProject.Forms
{
    public partial class assementComponent : Form
    {
        int totalmarks = 0;
        int assementmarks = 0;
        int rubricId = 0;
        int assessmentId = 0;

        private int indexRow;

        private GunaTextBoxValidator isname;
        private GunaTextBoxValidator Marks;
        private GunaTextBoxValidator Uisname;
        private GunaTextBoxValidator UMarks;
        public assementComponent()
        {
            InitializeComponent();
            FillComboBoxes();
            displayData();

            isname = new GunaTextBoxValidator(name, "Please enter a valid alphabetic value end with a number Paper+Session+Number.");
            Marks = new GunaTextBoxValidator(mark, "Please enter a valid integer value.");
            Uisname = new GunaTextBoxValidator(rubLevName, "Please enter a valid alphabetic value end with a number Paper+Session+Number.");
            UMarks = new GunaTextBoxValidator(details, "Please enter a valid integer value.");
        }

        private void displayData()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = @"Select * FRom AssessmentComponent Where Name Not Like '%del'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                editClosGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillComboBoxes()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "SELECT LEFT(r.Details, CHARINDEX('$', r.Details) - 1) FROM Rubric r WHERE r.details NOT LIKE '%del'";
                SqlCommand cmd = new SqlCommand(query, con);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rubric.Items.Add(reader.GetString(0));
                    }
                }

                query = "SELECT Title FROM Assessment Where Title Not Like '%del' ";
                cmd = new SqlCommand(query, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Assement.Items.Add(reader.GetString(0));
                    }
                }
                this.rubric.SelectedIndex = 0;
                this.Assement.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while filling comboboxes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {

                assementNumber();
                totalNumber();
                if (isname.IsValidAssement() && Marks.IsValidInteger())
                {
                    int markValue = Convert.ToInt32(mark.Text);
                    if (totalmarks < (assementmarks + markValue))
                    {
                        MessageBox.Show("It exceeded the total marks of the assessment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    gettingIds();

                    var con = Configuration.getInstance().getConnection();
                    string checkQuery = "SELECT COUNT(*) FROM AssessmentComponent WHERE Name = @name AND RubricId = @rubricId and Name  not Like 'del'";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@name", name.Text);
                    checkCmd.Parameters.AddWithValue("@rubricId", rubricId);

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("A record with the same name already exists for the selected rubric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string query = "INSERT INTO AssessmentComponent (Name,RubricId,TotalMarks,DateCreated,DateUpdated,AssessmentId) VALUES (@name,@rubricId,@totalMarks,GETDATE(),GETDATE(),@assessmentId)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@rubricId", rubricId);
                    cmd.Parameters.AddWithValue("@totalMarks", mark.Text);
                    cmd.Parameters.AddWithValue("@assessmentId", assessmentId);

                    cmd.ExecuteNonQuery();
                    displayData();
                    MessageBox.Show("Successfully Added");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gettingIds()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = @"SELECT r.Id FROM Rubric r WHERE LEFT(r.Details, CHARINDEX('$', r.Details) - 1) = @name";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", rubric.SelectedItem.ToString());
                this.rubricId = (int)cmd.ExecuteScalar();

                string query1 = @"SELECT Id FROM Assessment WHERE Title = @Name";
                cmd = new SqlCommand(query1, con);
                cmd.Parameters.AddWithValue("@Name", Assement.SelectedItem.ToString());
                this.assessmentId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while getting IDs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void assementNumber()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "SELECT TotalMarks FROM Assessment WHERE Title=@assId and Title not Like 'del'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("assId", Assement.SelectedItem.ToString());

                this.totalmarks = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching assessment marks: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void totalNumber()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                string query = "SELECT SUM(ac.TotalMarks) " +
                               "FROM Assessment a " +
                               "JOIN AssessmentComponent ac ON a.Id = ac.AssessmentId " +
                               "WHERE a.Title=@assId  And ac.Name not Like 'del'" +
                               "GROUP BY a.Title ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("assId", Assement.SelectedItem.ToString());

                object result = cmd.ExecuteScalar();
                this.assementmarks = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching total marks: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                assementNumber();
                totalNumber();
                if (Uisname.IsValidAssement() && UMarks.IsValidInteger())
                {
                    var con = Configuration.getInstance().getConnection();
                    int markValue = Convert.ToInt32(details.Text);
                   
                  

                    if (totalmarks < (assementmarks+markValue))
                    {
                        MessageBox.Show("It exceeded the total marks of the assessment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    gettingIds();


                    string checkQuery = "SELECT COUNT(*) FROM AssessmentComponent WHERE Name = @name  And  Id<>@id";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@name", rubLevName.Text);
                    checkCmd.Parameters.AddWithValue("@id", id.Text);

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("A record with the same name already exists for the selected rubric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string query = @"Update AssessmentComponent Set Name=@name ,TotalMarks=@mark ,DateUpdated=GetDate() Where Id=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", rubLevName.Text);
                    cmd.Parameters.AddWithValue("@mark", details.Text);
                    cmd.Parameters.AddWithValue("@id", id.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully Updated");
                    displayData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editClosGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexRow = e.RowIndex;

                DataGridViewRow row = editClosGrid.Rows[indexRow];
                id.Text = row.Cells[0].Value.ToString();
                rubLevName.Text = row.Cells[1].Value.ToString();
                details.Text = row.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = @"Update AssessmentComponent Set Name=@name  Where Id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", rubLevName.Text + "del");
                cmd.Parameters.AddWithValue("@marks", rubLevName.Text);
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Deleted");
                displayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
