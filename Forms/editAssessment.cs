using DBMidProject.Bl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DBMidProject.Forms
{
    public partial class editAssessment : Form
    {
        private GunaTextBoxValidator isname;
        private GunaTextBoxValidator Marks;
        private GunaTextBoxValidator Weight;

        private int indexRow;
        public editAssessment()
        {
            InitializeComponent();
            displaydata();
            isname = new GunaTextBoxValidator(name, "Please enter a valid alphabetic value end with a number Paper+Session+Number.");
            Marks = new GunaTextBoxValidator(mark, "Please enter a valid integer value.");
            Weight = new GunaTextBoxValidator(weight, "Please enter a valid integer value.");
        }

        private void displaydata()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = @"Select * FRom Assessment Where Title Not Like '%del'";
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
        private bool IsTextBoxesEmpty()
        {
            return string.IsNullOrWhiteSpace(name.Text) ||
                   string.IsNullOrWhiteSpace(weight.Text) ||
                   string.IsNullOrWhiteSpace(mark.Text);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string query = @"
                                    UPDATE Assessment
                                    SET Title = @name
                                    WHERE Id=@id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", name.Text+ "del");
            cmd.Parameters.AddWithValue("@id", id.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
            displaydata();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (IsTextBoxesEmpty())
            {
                MessageBox.Show("Please  full all boxes.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isname.IsValidAssement() && Marks.IsValidInteger() && Weight.IsValidInteger())
            {
                var con = Configuration.getInstance().getConnection();
                string queryCheckExisting = "SELECT COUNT(*) FROM Assessment WHERE Title = @title And Id<>@id ";
                SqlCommand cmdCheckExisting = new SqlCommand(queryCheckExisting, con);
                cmdCheckExisting.Parameters.AddWithValue("@title", name.Text);
                cmdCheckExisting.Parameters.AddWithValue("@id", id.Text);

                int existingAssessmentCount = (int)cmdCheckExisting.ExecuteScalar();

                if (existingAssessmentCount > 0)
                {
                    MessageBox.Show("Assessment with the same title already exists. Please choose a different title.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string query = @"
                                    UPDATE Assessment
                                    SET Title = @name, TotalMarks = @marks, TotalWeightage = @weight
                                    WHERE Id=@id";
                    SqlCommand cmdQuery = new SqlCommand(query, con);
                    cmdQuery.Parameters.AddWithValue("@name", name.Text);
                    cmdQuery.Parameters.AddWithValue("@marks", mark.Text);
                    cmdQuery.Parameters.AddWithValue("@weight", weight.Text);
                    cmdQuery.Parameters.AddWithValue("@id", id.Text);
                    cmdQuery.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated");
                    displaydata();
                }
            }
        }

        private void editClosGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;

            DataGridViewRow row = editClosGrid.Rows[indexRow];
            id.Text = row.Cells[0].Value.ToString();
            name.Text = row.Cells[1].Value.ToString();
            mark.Text = row.Cells[3].Value.ToString();
            weight.Text = row.Cells[4].Value.ToString();
        }
    }
}
