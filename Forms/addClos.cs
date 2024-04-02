using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DBMidProject.Forms
{
    public partial class addClos : Form
    {

        public addClos()
        {
            InitializeComponent();
        }

        private void lname_TextChanged(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string selectQuery = "SELECT * FROM Clo WHERE Name = @name And Name  not LIKE '%del' ";
            SqlCommand cmd1 = new SqlCommand(selectQuery, con);
            cmd1.Parameters.AddWithValue("@name", lname.Text);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (string.IsNullOrWhiteSpace(lname.Text) == false && lname.Text.Length < 8 && !(dr.HasRows))
            {

                string query = "INSERT INTO Clo (Name,DateCreated,DateUpdated) VALUES (@name,GETDATE(),GETDATE())";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", lname.Text);
                dr.Close();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Added");

            }

            else if (dr.HasRows) { MessageBox.Show("Already Exists ", "Exits", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dr.Close();
            }
            else { return; };

        }
    }
}
