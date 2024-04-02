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
    public partial class rubricLevel : Form
    {
        List<string> names = new List<string>();
        List<string> namesOflevel = new List<string>();
        private int count = 0;
        public rubricLevel()
        {
            InitializeComponent();
            dataBindning();
            dataBindingRbric();
        }
        private void dataBindning()
        {
            var con = Configuration.getInstance().getConnection();
            string query = "SELECT c.Name + ' - ' + SUBSTRING(r.Details, 1, CHARINDEX('$', r.Details) - 1) AS [RUBRIC NAME] " +
                            " FROM Clo c JOIN Rubric r" +
                            " ON c.Id = r.CloId " +
                            "WHERE r.Details NOT LIKE '%del'";

            SqlCommand cmd = new SqlCommand(query, con);

            

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string rubricName = reader["RUBRIC NAME"].ToString();
                    names.Add(rubricName);
                }
            }

            rubrics.DataSource = names;

        }

        private void dataBindingRbric()
        {
            namesOflevel.Add("Excellent");
            namesOflevel.Add("Good");
            namesOflevel.Add("Fair");
            namesOflevel.Add("Unsatisfactory");
            rubricname.DataSource = namesOflevel;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int reslut;
            if (string.IsNullOrEmpty(details.Text)
              || !IsInputAlphabetic(details.Text)

              )
            {
                MessageBox.Show("Text box is not valid. Please enter a non-null string.");
                return;

            }
            if (!int.TryParse(measurementLevel.Text, out int result))
            {
                MessageBox.Show("Text box is not valid. Please enter a Integer Value.");
                return;

            }
            countofRubric();
            if (this.count < 4)
            {
               
                var con = Configuration.getInstance().getConnection();
                string query = "INSERT INTO RubricLevel (RubricId, Details, MeasurementLevel) " +
                               "VALUES ((SELECT r.Id FROM Rubric r WHERE LEFT(r.Details, CHARINDEX('$', r.Details) - 1) = LTRIM(RIGHT(@name, LEN(@name) - CHARINDEX('-', @name)))), " +
                               "@details, @measurement)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@details", rubricname.SelectedItem.ToString() + "-"+ details.Text);
                cmd.Parameters.AddWithValue("@measurement", measurementLevel.Text);
                cmd.Parameters.AddWithValue("@name", "100-code");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Added");

            }
            else
            {
                MessageBox.Show("there are  already Four Measurement level of this Rubric");
            }
        }
        private bool IsInputAlphabetic(string input)
        {
            return !string.IsNullOrEmpty(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        private void countofRubric()
        {
            var con = Configuration.getInstance().getConnection();
            string query = "SELECT COUNT(l.RubricId) AS CountInRubricLevel" +
                 " FROM Rubric r JOIN RubricLevel l ON r.ID = l.RubricId" +
                 " WHERE r.Id IN (SELECT r.Id FROM Rubric r" +
                 " WHERE LEFT(r.Details, CHARINDEX('$', r.Details) - 1) = LTRIM(RIGHT(@name, LEN(@name) - CHARINDEX('-', @name))))";


            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", rubrics.SelectedItem.ToString());

            Console.WriteLine(this.count);
            int count = (int)cmd.ExecuteScalar();
            

            this.count = count;



        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
