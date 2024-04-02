namespace DBMidProject.Forms
{
    partial class rubricLevel
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
            this.rubricname = new Guna.UI2.WinForms.Guna2ComboBox();
            this.rubrics = new Guna.UI2.WinForms.Guna2ComboBox();
            this.details = new Guna.UI2.WinForms.Guna2TextBox();
            this.measurementLevel = new Guna.UI2.WinForms.Guna2TextBox();
            this.addButton = new Guna.UI2.WinForms.Guna2GradientCircleButton();
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
            this.guna2CustomGradientPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(233, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 58);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Rubric Level";
            // 
            // Addpanel
            // 
            this.Addpanel.Controls.Add(this.rubricname);
            this.Addpanel.Controls.Add(this.rubrics);
            this.Addpanel.Controls.Add(this.details);
            this.Addpanel.Controls.Add(this.measurementLevel);
            this.Addpanel.Controls.Add(this.addButton);
            this.Addpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Addpanel.Location = new System.Drawing.Point(0, 0);
            this.Addpanel.Name = "Addpanel";
            this.Addpanel.Size = new System.Drawing.Size(800, 734);
            this.Addpanel.TabIndex = 5;
            // 
            // rubricname
            // 
            this.rubricname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rubricname.AutoRoundedCorners = true;
            this.rubricname.BackColor = System.Drawing.Color.Transparent;
            this.rubricname.BorderRadius = 17;
            this.rubricname.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.rubricname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rubricname.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rubricname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rubricname.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.rubricname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.rubricname.ItemHeight = 30;
            this.rubricname.Location = new System.Drawing.Point(243, 268);
            this.rubricname.Name = "rubricname";
            this.rubricname.Size = new System.Drawing.Size(438, 36);
            this.rubricname.TabIndex = 10;
            this.rubricname.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // rubrics
            // 
            this.rubrics.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rubrics.AutoRoundedCorners = true;
            this.rubrics.BackColor = System.Drawing.Color.Transparent;
            this.rubrics.BorderRadius = 17;
            this.rubrics.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.rubrics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rubrics.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rubrics.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rubrics.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rubrics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.rubrics.ItemHeight = 30;
            this.rubrics.Location = new System.Drawing.Point(243, 195);
            this.rubrics.Name = "rubrics";
            this.rubrics.Size = new System.Drawing.Size(438, 36);
            this.rubrics.TabIndex = 9;
            // 
            // details
            // 
            this.details.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.details.Animated = true;
            this.details.AutoRoundedCorners = true;
            this.details.BorderRadius = 40;
            this.details.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.details.DefaultText = "";
            this.details.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.details.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.details.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.details.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.details.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.details.Font = new System.Drawing.Font("Bahnschrift", 14F);
            this.details.ForeColor = System.Drawing.Color.Black;
            this.details.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(211)))), ((int)(((byte)(252)))));
            this.details.IconLeft = global::DBMidProject.Properties.Resources.images__2_;
            this.details.IconLeftSize = new System.Drawing.Size(30, 30);
            this.details.Location = new System.Drawing.Point(233, 343);
            this.details.Margin = new System.Windows.Forms.Padding(6, 6, 6, 7);
            this.details.Name = "details";
            this.details.PasswordChar = '\0';
            this.details.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.details.PlaceholderText = "Details";
            this.details.SelectedText = "";
            this.details.Size = new System.Drawing.Size(458, 82);
            this.details.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.details.TabIndex = 8;
            this.details.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // measurementLevel
            // 
            this.measurementLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.measurementLevel.Animated = true;
            this.measurementLevel.AutoRoundedCorners = true;
            this.measurementLevel.BorderRadius = 40;
            this.measurementLevel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.measurementLevel.DefaultText = "";
            this.measurementLevel.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.measurementLevel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.measurementLevel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.measurementLevel.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.measurementLevel.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.measurementLevel.Font = new System.Drawing.Font("Bahnschrift", 14F);
            this.measurementLevel.ForeColor = System.Drawing.Color.Black;
            this.measurementLevel.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(211)))), ((int)(((byte)(252)))));
            this.measurementLevel.IconLeft = global::DBMidProject.Properties.Resources.measurementlevel;
            this.measurementLevel.IconLeftSize = new System.Drawing.Size(30, 30);
            this.measurementLevel.Location = new System.Drawing.Point(243, 438);
            this.measurementLevel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 7);
            this.measurementLevel.Name = "measurementLevel";
            this.measurementLevel.PasswordChar = '\0';
            this.measurementLevel.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.measurementLevel.PlaceholderText = "Mesurement Level";
            this.measurementLevel.SelectedText = "";
            this.measurementLevel.Size = new System.Drawing.Size(458, 82);
            this.measurementLevel.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.measurementLevel.TabIndex = 6;
            this.measurementLevel.TextOffset = new System.Drawing.Point(10, 0);
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
            this.addButton.Location = new System.Drawing.Point(289, 547);
            this.addButton.Name = "addButton";
            this.addButton.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.addButton.Size = new System.Drawing.Size(276, 88);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // rubricLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 734);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.Addpanel);
            this.Name = "rubricLevel";
            this.Text = "Form1";
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.Addpanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel Addpanel;
        private Guna.UI2.WinForms.Guna2GradientCircleButton addButton;
        private Guna.UI2.WinForms.Guna2TextBox measurementLevel;
        private Guna.UI2.WinForms.Guna2TextBox details;
        private Guna.UI2.WinForms.Guna2ComboBox rubrics;
        private Guna.UI2.WinForms.Guna2ComboBox rubricname;
    }
}