using DBMidProject.Bl;
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

namespace DBMidProject.Forms
{
    public partial class editStudent : Form
    {
        private GunaTextBoxValidator firstName;
        private GunaTextBoxValidator lastName;
        private GunaTextBoxValidator contact;
        private GunaTextBoxValidator email;
        private GunaTextBoxValidator contactLen;
        private GunaTextBoxValidator regno;

        // get setter of id 
        public int id { get; set; }
        // for grid index 
        private int indexRow;
        public editStudent()
        {
            InitializeComponent();
         // display data in grid
            displayData();

            // objects for validator class
            firstName = new GunaTextBoxValidator(fname, "Please enter a valid alphabetic value.");
            lastName = new GunaTextBoxValidator(lname, "Please enter a valid alphabetic value and no space.");
            contact = new GunaTextBoxValidator(number, "Please enter a valid integer value.");
            email = new GunaTextBoxValidator(mail, "Please end with @gmail.com");
            contactLen = new GunaTextBoxValidator(number, "Please Lenght of conatct number should be 11", 11);
            regno = new GunaTextBoxValidator(regnumber, "Please Lenght of Regsistration number should be 8", 8);
        }


        private void displayData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select s.firstname as [First Name],s.lastname as  [Last Name]," +               
                "s.Email ,s.RegistrationNumber as [Registration No],s.Contact,l.name as Status from student s join lookup l" +
                " on s.status=l.LookupId where l.lookupid = 5", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            editStudentGrid.DataSource = dt;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (editStudentGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select row first", "NO Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (IsTextBoxesEmpty())
                {
                    MessageBox.Show("Please  full all boxes.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (firstName.IsValid() && lastName.IsValid()
                  && regno.IsValidLength() && contact.IsValidInteger()
                  && contactLen.IsValidLength() && email.IsValidEmail()

                   )
                    {
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand cmd = new SqlCommand("Update Student set FirstName=@FirstName, LastName=@LastName,Contact=@Contact,Email=@Email,RegistrationNumber=@RegistrationNumber,Status=@Status where Id=@Id", con);
                        cmd.Parameters.AddWithValue("@FirstName", (fname.Text));
                        cmd.Parameters.AddWithValue("@LastName", lname.Text);
                        cmd.Parameters.AddWithValue("@Contact", number.Text);
                        cmd.Parameters.AddWithValue("@Email", mail.Text);
                        cmd.Parameters.AddWithValue("@RegistrationNumber", regnumber.Text);
                        cmd.Parameters.AddWithValue("@Id", this.id);
                        if (status.Text == "Active")
                        {
                            cmd.Parameters.AddWithValue("@Status", 5);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Status", 6);
                        }
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully Updated");


                    }
                }

            }

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            string firstName = fname.Text;
            string lastName = lname.Text;
            string regno = regnumber.Text;

            // making database connection
            var con = Configuration.getInstance().getConnection();
            // commnad  to determine id number 
            string query = "SELECT ID FROM Student WHERE FirstName = @FirstName AND LastName = @LastName and RegistrationNumber=@Regno ";
            // passing parameters
            using (SqlCommand cmdofID = new SqlCommand(query, con))
            {
                //setting parameters

                cmdofID.Parameters.AddWithValue("@FirstName", firstName);
                cmdofID.Parameters.AddWithValue("@LastName", lastName);
                cmdofID.Parameters.AddWithValue("@Regno", regno);

                object result = cmdofID.ExecuteScalar();
                int id = Convert.ToInt32(result);
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this student?", "Delete Student", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string query1 = "UPDATE Student SET Status = 6 WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query1, con);
                    cmd.Parameters.AddWithValue("@id", id);
                   
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Deleted");
                    displayData();
                }


            }
        }

            // empty text box checker
            private bool IsTextBoxesEmpty()
        {
            return string.IsNullOrWhiteSpace(fname.Text) ||
                   string.IsNullOrWhiteSpace(lname.Text) ||
                   string.IsNullOrWhiteSpace(number.Text) ||
                   string.IsNullOrWhiteSpace(mail.Text) ||
                   string.IsNullOrWhiteSpace(regnumber.Text);
        }
        // cell click  count 
        private void editStudentGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;

            DataGridViewRow row = editStudentGrid.Rows[indexRow];
            fname.Text = row.Cells[0].Value.ToString();
            lname.Text = row.Cells[1].Value.ToString();
            number.Text = row.Cells[4].Value.ToString();
            mail.Text = row.Cells[2].Value.ToString();
            regnumber.Text = row.Cells[3].Value.ToString();
            status.Text = row.Cells[5].Value.ToString();

        }


    }
}
