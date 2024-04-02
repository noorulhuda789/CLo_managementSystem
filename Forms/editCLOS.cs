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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Diagnostics.Eventing.Reader;

namespace DBMidProject.Forms
{
    public partial class editCLOS : Form
    { 
        // Grid index 
        private int indexRow;
        public editCLOS()
        {
            InitializeComponent();
            displayData();
        }
        private void displayData()
        {

            var con = Configuration.getInstance().getConnection();
            string selectQuery = "SELECT * FROM Clo WHERE Name  not LIKE '%del'";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            editClosGrid.DataSource = dt;
            con.Close();


        }

        //grid enterin data 
        private void editStudentGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;

            DataGridViewRow row = editClosGrid.Rows[indexRow];
            name.Text = row.Cells[1].Value.ToString();
            id.Text = row.Cells[0].Value.ToString();
        }




        private void updateBtn_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            con.Open();
            string selectQuery = "SELECT * FROM Clo WHERE Name = @name";
            SqlCommand cmd1 = new SqlCommand(selectQuery, con);
            cmd1.Parameters.AddWithValue("@name", name.Text);
            SqlDataReader dr = cmd1.ExecuteReader();
            
            if (string.IsNullOrWhiteSpace(id.Text) == false && name.Text.Length < 8 && !(dr.HasRows))
            {
                
                //closing dr connection
                dr.Close();
                string query = "UPDATE Clo SET Name=@name,DateUpdated= GETDATE() WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.ExecuteNonQuery();
                con.Close(); // closing con connection
                MessageBox.Show("Successfully Updated");
                displayData();
            }

            else if (dr.HasRows) { MessageBox.Show("Already Exists ", "Exits", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else { MessageBox.Show("Reduce CLO name characters  to 8 len or it is null .", "Invalid lenght ", MessageBoxButtons.OK, MessageBoxIcon.Error); };
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();

            con.Open();
                string selectQuery = "SELECT * FROM Clo WHERE Name = @name";
                SqlCommand cmd1 = new SqlCommand(selectQuery, con);
                cmd1.Parameters.AddWithValue("@name", name.Text);
                SqlDataReader dr = cmd1.ExecuteReader();

                if (!string.IsNullOrWhiteSpace(id.Text) && name.Text.Length < 8 && dr.HasRows)
                {
                  
                    string query = "UPDATE Clo SET Name=@name, DateUpdated=GETDATE() WHERE Id=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", name.Text + "del");
                    cmd.Parameters.AddWithValue("@id", id.Text);
                    dr.Close();

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully Deleted");
                    displayData();
                }
                else if (!dr.HasRows)
                {
                    MessageBox.Show("Does not exist", "Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
 
        }




    }
}
