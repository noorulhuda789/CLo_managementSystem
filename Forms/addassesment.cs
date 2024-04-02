using DBMidProject.Bl;
using PdfSharp.Pdf.Content.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMidProject.Bl;
namespace DBMidProject.Forms
{
    public partial class addassesment : Form
    {

        private GunaTextBoxValidator isname;
        private GunaTextBoxValidator Marks;
        private GunaTextBoxValidator Weight;
        public addassesment()
        {

            InitializeComponent();
            isname= new GunaTextBoxValidator(name, "Please enter a valid alphabetic value end with a number Paper+Session+Number.");
            Marks = new GunaTextBoxValidator(marks, "Please enter a valid integer value.");
            Weight = new GunaTextBoxValidator(weight, "Please enter a valid integer value.");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (IsTextBoxesEmpty())
            {
                MessageBox.Show("Please  full all boxes.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(isname.IsValidAssement() && Marks.IsValidInteger()&& Weight.IsValidInteger()) {


                var con = Configuration.getInstance().getConnection();
                string queryCheckExisting = "SELECT COUNT(*) FROM Assessment WHERE Title = @title";
                SqlCommand cmdCheckExisting = new SqlCommand(queryCheckExisting, con);
                cmdCheckExisting.Parameters.AddWithValue("@title", name.Text);

                int existingAssessmentCount = (int)cmdCheckExisting.ExecuteScalar();

                if (existingAssessmentCount > 0)
                {
                    MessageBox.Show("Assessment with the same title already exists. Please choose a different title.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string queryInsert = "INSERT INTO Assessment (Title, DateCreated, TotalMarks, TotalWeightage) VALUES (@title, GETDATE(), @marks, @weightage)";
                    SqlCommand cmdInsert = new SqlCommand(queryInsert, con);
                    cmdInsert.Parameters.AddWithValue("@title", name.Text);
                    cmdInsert.Parameters.AddWithValue("@marks", marks.Text);
                    cmdInsert.Parameters.AddWithValue("@weightage", weight.Text);

                    cmdInsert.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
                


        }
        private bool IsTextBoxesEmpty()
        {
            return string.IsNullOrWhiteSpace(name.Text) ||
                   string.IsNullOrWhiteSpace(weight.Text) ||
                   string.IsNullOrWhiteSpace(marks.Text);
        }

    }
}
