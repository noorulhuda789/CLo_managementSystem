using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMidProject.Forms;
namespace DBMidProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CustomizeDesign(sutdentPanel);
            CustomizeDesign(cloPanel);
            CustomizeDesign(rubricpanel);
            CustomizeDesign(assementPanel);
        }



        private void guna2Button14_Click(object sender, EventArgs e)
        {
            Attendance form = new Attendance();
            setPanel(form);
        }


        private void Student_Click(object sender, EventArgs e)
        {
            showsubmenu(sutdentPanel);
        }

        private void closButton_Click(object sender, EventArgs e)
        {
            Attendance form =new Attendance();
            setPanel(form);
        }

        /* sub menu display  mechanism */
        private void hidesubmenu(Panel panel)
        {
            if (panel.Visible == true)
            { panel.Visible = false; }

        }
        private void showsubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hidesubmenu(subMenu);
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void CustomizeDesign(Panel panel)
        {
            panel.Visible = false;
        }

        private void addStudent_Click(object sender, EventArgs e)
        {
            addStudent form = new addStudent();
            setPanel(form);
            
        }

        //panel setter
        private void setPanel(Form form)
        {
            centerPanel.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            centerPanel.Controls.Add(form);
            centerPanel.Tag = form;
            form.BringToFront();
            form.Show();
        }

        private void editStudent_Click(object sender, EventArgs e)
        {
            editStudent form = new editStudent();
            setPanel(form);
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            addClos form=new addClos();
            setPanel(form);
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            editCLOS form=new editCLOS();   
            setPanel(form);
        }

        private void guna2Panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            showsubmenu(rubricpanel);
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            showsubmenu(assementPanel);
        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            report form =new report();
            setPanel(form);
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            reslut form =new reslut();
            setPanel(form);
        }

        private void assementPanel_Paint(object sender, PaintEventArgs e)
        {
            //showsubmenu(assementPanel);
        }

        private void guna2Button12_Click_1(object sender, EventArgs e)
        {
            showsubmenu(cloPanel);
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Rubric form =new Rubric();
            setPanel(form);
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            editrubric form =new editrubric();
            setPanel(form);
        }

        private void guna2Button14_Click_1(object sender, EventArgs e)
        {
            rubricLevel form =new rubricLevel();
            setPanel(form);

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            editrubricLevel from =new editrubricLevel();
            setPanel(from);
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            addassesment form =new addassesment();
            setPanel(form);
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            editAssessment from =new editAssessment();
            setPanel(from);
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            assementComponent from =new assementComponent();
            setPanel(from);
        }

        private void guna2Button13_Click_1(object sender, EventArgs e)
        {
            addClos form =new addClos();
            setPanel(form);
        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            editCLOS form =new editCLOS();
            setPanel(form);
        }
    }
}
