namespace DBMidProject.Forms
{
    partial class addassesment
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
            this.marks = new Guna.UI2.WinForms.Guna2TextBox();
            this.name = new Guna.UI2.WinForms.Guna2TextBox();
            this.weight = new Guna.UI2.WinForms.Guna2TextBox();
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
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(918, 126);
            this.guna2CustomGradientPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(275, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 58);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Assesment";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Addpanel
            // 
            this.Addpanel.Controls.Add(this.marks);
            this.Addpanel.Controls.Add(this.name);
            this.Addpanel.Controls.Add(this.weight);
            this.Addpanel.Controls.Add(this.addButton);
            this.Addpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Addpanel.Location = new System.Drawing.Point(0, 0);
            this.Addpanel.Name = "Addpanel";
            this.Addpanel.Size = new System.Drawing.Size(918, 672);
            this.Addpanel.TabIndex = 5;
            // 
            // marks
            // 
            this.marks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.marks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.marks.DefaultText = "";
            this.marks.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.marks.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.marks.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.marks.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.marks.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.marks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.marks.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.marks.IconLeft = global::DBMidProject.Properties.Resources.measurementlevel;
            this.marks.Location = new System.Drawing.Point(324, 228);
            this.marks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.marks.Name = "marks";
            this.marks.PasswordChar = '\0';
            this.marks.PlaceholderText = "Total Marks";
            this.marks.SelectedText = "";
            this.marks.Size = new System.Drawing.Size(286, 56);
            this.marks.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.marks.TabIndex = 12;
            // 
            // name
            // 
            this.name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.name.DefaultText = "";
            this.name.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.name.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.name.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.name.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.name.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.name.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.name.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.name.IconLeft = global::DBMidProject.Properties.Resources.name;
            this.name.Location = new System.Drawing.Point(332, 148);
            this.name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.name.Name = "name";
            this.name.PasswordChar = '\0';
            this.name.PlaceholderText = "Name";
            this.name.SelectedText = "";
            this.name.Size = new System.Drawing.Size(286, 48);
            this.name.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.name.TabIndex = 10;
            // 
            // weight
            // 
            this.weight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.weight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.weight.DefaultText = "";
            this.weight.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.weight.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.weight.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.weight.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.weight.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.weight.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.weight.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.weight.IconLeft = global::DBMidProject.Properties.Resources.weight;
            this.weight.Location = new System.Drawing.Point(324, 328);
            this.weight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.weight.Name = "weight";
            this.weight.PasswordChar = '\0';
            this.weight.PlaceholderText = "Total Weightage";
            this.weight.SelectedText = "";
            this.weight.Size = new System.Drawing.Size(286, 56);
            this.weight.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.weight.TabIndex = 9;
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
            this.addButton.Location = new System.Drawing.Point(332, 438);
            this.addButton.Name = "addButton";
            this.addButton.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.addButton.Size = new System.Drawing.Size(276, 88);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // addassesment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 672);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.Addpanel);
            this.Name = "addassesment";
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
        private Guna.UI2.WinForms.Guna2TextBox name;
        private Guna.UI2.WinForms.Guna2TextBox weight;
        private Guna.UI2.WinForms.Guna2GradientCircleButton addButton;
        private Guna.UI2.WinForms.Guna2TextBox marks;
    }
}