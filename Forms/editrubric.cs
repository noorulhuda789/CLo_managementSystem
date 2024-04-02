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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DBMidProject.Forms
{
    
    public partial class editrubric : Form
    {
        private int indexRow;
        public editrubric()
        {
            InitializeComponent();
            displayData();
        }
         
        private void displayData()
        {
            var con = Configuration.getInstance().getConnection();
            string query = @" SELECT 
                                c.Id AS CLOID, 
                                c.Name AS [CLO NAME], 
                                r.Id AS [RUBRIC ID], 
                                LEFT(r.Details, CHARINDEX('$', r.Details) - 1) AS [RUBRIC NAME], 
                                RIGHT(r.Details, LEN(r.Details) - CHARINDEX('$', r.Details)) AS [RUBRIC DETAILS] 
                            FROM 
                                Clo c 
                            JOIN 
                                Rubric r ON r.CloId = c.Id 
                            WHERE 
                                r.Details NOT LIKE '%del'";


            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            editClosGrid.DataSource = dt;
        }

        private void editClosGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;

            DataGridViewRow row = editClosGrid.Rows[indexRow];
            rubricName.Text = row.Cells[3].Value.ToString();
            id.Text = row.Cells[2].Value.ToString();
            cloId.Text = row.Cells[0].Value.ToString();
            cloname.Text = row.Cells[1].Value.ToString();
            details.Text = row.Cells[4].Value.ToString();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(details.Text)
                || !IsInputAlphabetic(details.Text)
                || string.IsNullOrEmpty(rubricName.Text)
                || !IsInputAlphabetic(rubricName.Text))
                {

                    MessageBox.Show("Text box is not valid. Please enter a non-null string.");
                    return;
                }
                var con = Configuration.getInstance().getConnection();
                string query = " Update Rubric Set Details=@details  Where Id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@details", rubricName.Text + '$' + details.Text);
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.ExecuteNonQuery();
                string q2 = @"Update";

                MessageBox.Show("Successfully Updated");
                displayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(details.Text)
                || !IsInputAlphabetic(details.Text)
                || string.IsNullOrEmpty(rubricName.Text)
                || !IsInputAlphabetic(rubricName.Text))
            {
                MessageBox.Show("Text box is not valid. Please enter a non-null string.");
                return;
            }
            var con = Configuration.getInstance().getConnection();
            string query = " Update Rubric Set Details=@details  Where Id=@idofvalidation";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@details", rubricName.Text + '$' + details.Text + "del");
            cmd.Parameters.AddWithValue("@idofvalidation", id.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Successfully Deleted");
            displayData();
        }
        private bool IsInputAlphabetic(string input)
        {
            return !string.IsNullOrEmpty(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }
    }
}
