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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;
using iText.StyledXmlParser.Jsoup.Select;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace DBMidProject.Forms
{
    public partial class Rubric : Form
    {
        List<string> names = new List<string>();
        public Rubric()
        {
            InitializeComponent();
            dataBindinWithComboBox();
        }
        public void dataBindinWithComboBox()
        {
            var con = Configuration.getInstance().getConnection();
            string selectQuery = "SELECT Name FROM Clo WHERE Name  not LIKE '%del'";
            SqlCommand cmd = new SqlCommand(selectQuery, con);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string name = reader["Name"].ToString();
                    names.Add(name);
                }
            }
            
            clo.DataSource = names;
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (clo.SelectedItem == null)
            {
                MessageBox.Show("Please select a CLo from the combo box.");
                return; 
            }


            if (string.IsNullOrEmpty(Details.Text)
                || !IsInputAlphabetic(Details.Text)
                || string.IsNullOrEmpty(name.Text)
                || !IsInputAlphabetic(name.Text))
            {
                MessageBox.Show("Text box is not valid. Please enter a non-null string.");
                return;
            }
            var con = Configuration.getInstance().getConnection();
            string query = "INSERT INTO Rubric (Id, Details, CLoId) " +
                "VALUES" +
                "(COALESCE((SELECT TOP 1 Id + 1 FROM Rubric ORDER BY Id DESC), 1)," +
                "CAST(@title AS NVARCHAR(MAX)) + '$' + CAST(@details AS NVARCHAR(MAX))," +
                "(SELECT Id FROM Clo WHERE Name = @name)); ";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@details", Details.Text);
            cmd.Parameters.AddWithValue("@name", clo.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@title", name.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Added");

        }
        private bool IsInputAlphabetic(string input)
        {
            return !string.IsNullOrEmpty(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        private void clo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
