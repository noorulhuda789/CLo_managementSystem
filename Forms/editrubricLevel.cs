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
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace DBMidProject.Forms
{

    public partial class editrubricLevel : Form
    {
        List<string> mLev = new List<string>();
        private int indexRow;
        public editrubricLevel()
        {
            InitializeComponent();
            displayData();
        }

        private void displayData()
        {
            var con = Configuration.getInstance().getConnection();
            string query = "SELECT  r.Id AS [RUBRIC ID], " +
                "LEFT(r.Details, CHARINDEX('$', r.Details) - 1) AS [RUBRIC NAME], " +
                "RIGHT(r.Details, LEN(r.Details) - CHARINDEX('$', r.Details)) AS [RUBRIC DETAILS], " +
                "l.ID,LEFT(l.Details, CHARINDEX('-', l.Details) - 1) AS [RUBRICLEVELNAME]," +
                " RIGHT(l.Details, LEN(l.Details) - CHARINDEX('-', l.Details)) AS [RUBRICLEVELDETAILS], l.MeasurementLevel" +
                " FROM Rubric r Left JOIN " +
                "RubricLevel l " +
                "ON r.ID = l.RubricId " +
                "WHERE r.Id NOT LIKE '%del' AND l.Details NOT LIKE '%del' or l.RubricId  IS Null";


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
            rubLevId.Text = row.Cells[3].Value.ToString();
            rubLevName.Text = row.Cells[4].Value.ToString();
            Measurement.Text = row.Cells[6].Value.ToString();
            details.Text = row.Cells[5].Value.ToString();

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(details.Text)
                    || !IsInputAlphabetic(details.Text)
                    || string.IsNullOrEmpty(rubLevName.Text)
                    || !IsInputAlphabetic(rubLevName.Text))
            {
                MessageBox.Show("Text box is not valid. Please enter a non-null string.");
                return;
            }
            if ((!rubLevName.Text.Equals("Excellent", StringComparison.OrdinalIgnoreCase)
                && !rubLevName.Text.Equals("Good", StringComparison.OrdinalIgnoreCase)
                && !rubLevName.Text.Equals("Fair", StringComparison.OrdinalIgnoreCase)
                && !rubLevName.Text.Equals("Unsatisfactory", StringComparison.OrdinalIgnoreCase))
                )
            {
                MessageBox.Show("Name can be only Excellent Good Fair or Unsatisfactory");
                return;
            }
            if (!int.TryParse(Measurement.Text, out int measurementValue))
            {
                MessageBox.Show("Measurement should be an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var con = Configuration.getInstance().getConnection();

            // Check if the measurement level has been changed
            string queryCheck = @"SELECT Measurementlevel
                    FROM RubricLevel
                    WHERE id = @id";

            SqlCommand cmdCheck = new SqlCommand(queryCheck, con);
            cmdCheck.Parameters.AddWithValue("@id", rubLevId.Text);
            int currentMeasurementLevel = (int)cmdCheck.ExecuteScalar(); ;
            
            if ( currentMeasurementLevel != int.Parse(Measurement.Text))
            {
                // Measurement level has been changed, check if the new measurement level already exists
                string queryCheckExistence = @"
                                IF EXISTS (
                                    SELECT 1
                                    FROM RubricLevel
                                    WHERE id <> @id AND Measurementlevel = @measurementLevel
                                     And  LEFT(r.Details, CHARINDEX('$', r.Details) - 1)=@name
                                )
                                    SELECT 'true' AS MeasuremntLevelExists
                                ELSE
                                    SELECT 'false' AS MeasuremntLevelExists";

                SqlCommand cmdCheckExistence = new SqlCommand(queryCheckExistence, con);
                cmdCheckExistence.Parameters.AddWithValue("@id", rubLevId.Text);
                cmdCheckExistence.Parameters.AddWithValue("@measurementLevel", Measurement.Text);
                cmdCheckExistence.Parameters.AddWithValue("@name", rubLevName.Text);

                string result = (string)cmdCheckExistence.ExecuteScalar();
                if (result == "true")
                {
                    MessageBox.Show("Measurement Level  or Rubric Level Name already exists for this Rubric.");
                    return;
                }
            }

            // Update the rubric
            string queryUpdate = "UPDATE RubricLevel  SET Details = @details, Measurementlevel = @mLevel WHERE Id = @id";
            SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con);
            cmdUpdate.Parameters.AddWithValue("@details", rubLevName.Text + '-' + details.Text);
            cmdUpdate.Parameters.AddWithValue("@id", rubLevId.Text);
            cmdUpdate.Parameters.AddWithValue("@mLevel", Measurement.Text);
            cmdUpdate.ExecuteNonQuery();

            MessageBox.Show("Successfully Updated");
            displayData();

        }




        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Measurement.Text, out int measurementValue))
            {
                MessageBox.Show("Measurement should be an integer.");
                return;
            }

            if (measurementValue > 4)
            {
                MessageBox.Show("Sould be smaller than 4");
                return;
            }
            var con = Configuration.getInstance().getConnection();
            string query = @"Update RubricLevel Set Details=@id where Id =@IDv";
            SqlCommand cmd= new SqlCommand(query, con);
            
            cmd.Parameters.AddWithValue("@id", rubLevName.Text + '-' + details.Text+ "del");
            cmd.Parameters.AddWithValue("@IDV",rubLevId.Text);
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
