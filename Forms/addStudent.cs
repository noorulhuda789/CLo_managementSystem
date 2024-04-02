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
using DBMidProject.Bl;
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace DBMidProject.Forms
{
    public partial class addStudent : Form
    {
        private GunaTextBoxValidator firstName;
        private GunaTextBoxValidator lastName;
        private GunaTextBoxValidator contact;
        private GunaTextBoxValidator email;
        private GunaTextBoxValidator contactLen;
        private GunaTextBoxValidator regno;

        //database count 
        private int databaseStudentCount;
        public addStudent()
        {
            InitializeComponent();

            // database configuration 
            
            databaseStudentCount = getStudentCountFromDataBase();

            // validation insistance 
            firstName = new GunaTextBoxValidator(fname, "Please enter a valid alphabetic value and no space.");
            lastName = new GunaTextBoxValidator(lname, "Please enter a valid alphabetic value and no space.");
            contact = new GunaTextBoxValidator(number, "Please enter a valid integer value.");
            email = new GunaTextBoxValidator(mail, "Please end with @gmail.com");
            contactLen = new GunaTextBoxValidator(number, "Please Lenght of conatct number should be 11",  11);
            regno = new GunaTextBoxValidator(regnumber, "Please Lenght of Regsistration number should be 8 or format 20022cs60", 8);
        }



        private void addButton_Click(object sender, EventArgs e)
        {
            if (IsTextBoxesEmpty() )
            {
                MessageBox.Show("Please  full all boxes.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                if(firstName.IsValid() && lastName.IsValid()
                  && regno.IsValidLength() && contact.IsValidInteger()
                  && contactLen.IsValidLength() && email.IsValidEmail() && regno.IsValidRegistrationNumber()
                   
                   )
                {
                    var con = Configuration.getInstance().getConnection();

                        // Insert the new record
                        string queryInsert = "IF NOT EXISTS (SELECT 1 FROM Student WHERE RegistrationNumber = @regnumber) BEGIN " +
                    "INSERT INTO Student (FirstName, LastName, Contact, Email, RegistrationNumber, Status) " +
                    "VALUES (@fname, @lname, @contact, @email, @regnumber, @status) " +
                    "END";
                        SqlCommand cmdInsert = new SqlCommand(queryInsert, con);
                        cmdInsert.Parameters.AddWithValue("@fname", fname.Text);
                        cmdInsert.Parameters.AddWithValue("@lname", lname.Text);
                        cmdInsert.Parameters.AddWithValue("@contact", number.Text);
                        cmdInsert.Parameters.AddWithValue("@email", mail.Text);
                        cmdInsert.Parameters.AddWithValue("@regnumber", regnumber.Text);
                        cmdInsert.Parameters.AddWithValue("@status", 5);

                    int rowsAffected = cmdInsert.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Already Exists");
                    }
                    else
                    {                         // Registration number already exists
                        MessageBox.Show("Registration number already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                        



                }

            }

        }

        private bool IsTextBoxesEmpty()
        {
            return string.IsNullOrWhiteSpace(fname.Text) ||
                   string.IsNullOrWhiteSpace(lname.Text) ||
                   string.IsNullOrWhiteSpace(number.Text)||
                   string.IsNullOrWhiteSpace(mail.Text)||
                   string.IsNullOrWhiteSpace(regnumber.Text);
        }

        // database codes
        private int getStudentCountFromDataBase()
        {
            var con = Configuration.getInstance().getConnection();
            string query = "SELECT COUNT(S.ID) FROM Student S";
            SqlCommand cmd = new SqlCommand(query, con);

            return (int)cmd.ExecuteScalar();
        }
    }
}
