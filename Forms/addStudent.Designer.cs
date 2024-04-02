namespace DBMidProject.Forms
{
    partial class addStudent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.Addpanel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.addButton = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.regnumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.mail = new Guna.UI2.WinForms.Guna2TextBox();
            this.number = new Guna.UI2.WinForms.Guna2TextBox();
            this.lname = new Guna.UI2.WinForms.Guna2TextBox();
            this.fname = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.Addpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.label1);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2CustomGradientPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(217)))), ((int)(((byte)(252)))));
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(800, 126);
            this.guna2CustomGradientPanel1.TabIndex = 0;
            
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(268, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 58);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Student ";
           
            // 
            // Addpanel
            // 
            this.Addpanel.Controls.Add(this.addButton);
            this.Addpanel.Controls.Add(this.regnumber);
            this.Addpanel.Controls.Add(this.mail);
            this.Addpanel.Controls.Add(this.number);
            this.Addpanel.Controls.Add(this.lname);
            this.Addpanel.Controls.Add(this.fname);
            this.Addpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Addpanel.Location = new System.Drawing.Point(0, 126);
            this.Addpanel.Name = "Addpanel";
            this.Addpanel.Size = new System.Drawing.Size(800, 592);
            this.Addpanel.TabIndex = 1;
           
            // 
            // addButton
            // 
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addButton.BackColor = System.Drawing.Color.Transparent;
            this.addButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addButton.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(141)))), ((int)(((byte)(152)))));
            this.addButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(300, 518);
            this.addButton.Name = "addButton";
            this.addButton.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.addButton.Size = new System.Drawing.Size(276, 88);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // regnumber
            // 
            this.regnumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.regnumber.Animated = true;
            this.regnumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.regnumber.DefaultText = "";
            this.regnumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.regnumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.regnumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.regnumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.regnumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.regnumber.Font = new System.Drawing.Font("Bahnschrift", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regnumber.ForeColor = System.Drawing.Color.Black;
            this.regnumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(211)))), ((int)(((byte)(252)))));
            this.regnumber.IconLeft = global::DBMidProject.Properties.Resources.regno;
            this.regnumber.IconLeftSize = new System.Drawing.Size(40, 40);
            this.regnumber.Location = new System.Drawing.Point(258, 209);
            this.regnumber.Margin = new System.Windows.Forms.Padding(6, 6, 6, 7);
            this.regnumber.Name = "regnumber";
            this.regnumber.PasswordChar = '\0';
            this.regnumber.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.regnumber.PlaceholderText = "Regsistration Number";
            this.regnumber.SelectedText = "";
            this.regnumber.Size = new System.Drawing.Size(458, 82);
            this.regnumber.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.regnumber.TabIndex = 4;
            this.regnumber.TextOffset = new System.Drawing.Point(10, 0);
            
            // 
            // mail
            // 
            this.mail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mail.Animated = true;
            this.mail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mail.DefaultText = "";
            this.mail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.mail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.mail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.mail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.mail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.mail.Font = new System.Drawing.Font("Bahnschrift", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mail.ForeColor = System.Drawing.Color.Black;
            this.mail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(211)))), ((int)(((byte)(252)))));
            this.mail.IconLeft = global::DBMidProject.Properties.Resources.download_removebg_preview;
            this.mail.IconLeftSize = new System.Drawing.Size(40, 40);
            this.mail.Location = new System.Drawing.Point(258, 399);
            this.mail.Margin = new System.Windows.Forms.Padding(6, 6, 6, 7);
            this.mail.Name = "mail";
            this.mail.PasswordChar = '\0';
            this.mail.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.mail.PlaceholderText = "Email ";
            this.mail.SelectedText = "";
            this.mail.Size = new System.Drawing.Size(458, 82);
            this.mail.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.mail.TabIndex = 3;
            this.mail.TextOffset = new System.Drawing.Point(10, 0);
            
            // 
            // number
            // 
            this.number.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.number.Animated = true;
            this.number.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.number.DefaultText = "";
            this.number.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.number.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.number.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.number.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.number.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.number.Font = new System.Drawing.Font("Bahnschrift", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number.ForeColor = System.Drawing.Color.Black;
            this.number.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(211)))), ((int)(((byte)(252)))));
            this.number.IconLeft = global::DBMidProject.Properties.Resources.contact_removebg_preview;
            this.number.IconLeftSize = new System.Drawing.Size(40, 40);
            this.number.Location = new System.Drawing.Point(258, 304);
            this.number.Margin = new System.Windows.Forms.Padding(6, 6, 6, 7);
            this.number.Name = "number";
            this.number.PasswordChar = '\0';
            this.number.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.number.PlaceholderText = "Contact";
            this.number.SelectedText = "";
            this.number.Size = new System.Drawing.Size(458, 82);
            this.number.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.number.TabIndex = 2;
            this.number.TextOffset = new System.Drawing.Point(10, 0);
            
            // 
            // lname
            // 
            this.lname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lname.Animated = true;
            this.lname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lname.DefaultText = "";
            this.lname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lname.Font = new System.Drawing.Font("Bahnschrift", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lname.ForeColor = System.Drawing.Color.Black;
            this.lname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(211)))), ((int)(((byte)(252)))));
            this.lname.IconLeft = global::DBMidProject.Properties.Resources.name;
            this.lname.IconLeftSize = new System.Drawing.Size(30, 30);
            this.lname.Location = new System.Drawing.Point(258, 114);
            this.lname.Margin = new System.Windows.Forms.Padding(6, 6, 6, 7);
            this.lname.Name = "lname";
            this.lname.PasswordChar = '\0';
            this.lname.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.lname.PlaceholderText = " Last Name";
            this.lname.SelectedText = "";
            this.lname.Size = new System.Drawing.Size(458, 82);
            this.lname.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.lname.TabIndex = 1;
            this.lname.TextOffset = new System.Drawing.Point(10, 0);
            
            // 
            // fname
            // 
            this.fname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fname.Animated = true;
            this.fname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fname.DefaultText = "";
            this.fname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.fname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.fname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.fname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.fname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.fname.Font = new System.Drawing.Font("Bahnschrift", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fname.ForeColor = System.Drawing.Color.Black;
            this.fname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(211)))), ((int)(((byte)(252)))));
            this.fname.IconLeft = global::DBMidProject.Properties.Resources.name;
            this.fname.IconLeftSize = new System.Drawing.Size(30, 30);
            this.fname.Location = new System.Drawing.Point(258, 6);
            this.fname.Margin = new System.Windows.Forms.Padding(6, 6, 6, 7);
            this.fname.Name = "fname";
            this.fname.PasswordChar = '\0';
            this.fname.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.fname.PlaceholderText = " First Name";
            this.fname.SelectedText = "";
            this.fname.Size = new System.Drawing.Size(458, 82);
            this.fname.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.fname.TabIndex = 0;
            this.fname.TextOffset = new System.Drawing.Point(10, 0);
            
            // 
            // addStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 718);
            this.Controls.Add(this.Addpanel);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Name = "addStudent";
            this.Text = "Form1";
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.Addpanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel Addpanel;
        private Guna.UI2.WinForms.Guna2TextBox fname;
        private Guna.UI2.WinForms.Guna2TextBox number;
        private Guna.UI2.WinForms.Guna2TextBox lname;
        private Guna.UI2.WinForms.Guna2TextBox regnumber;
        private Guna.UI2.WinForms.Guna2TextBox mail;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientCircleButton addButton;
    }
}