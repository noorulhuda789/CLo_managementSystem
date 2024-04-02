namespace DBMidProject.Forms
{
    partial class Rubric
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
            this.clo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.addButton = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.name = new Guna.UI2.WinForms.Guna2TextBox();
            this.Details = new Guna.UI2.WinForms.Guna2TextBox();
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
            this.guna2CustomGradientPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 58);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Rubric";
            // 
            // Addpanel
            // 
            this.Addpanel.Controls.Add(this.name);
            this.Addpanel.Controls.Add(this.Details);
            this.Addpanel.Controls.Add(this.clo);
            this.Addpanel.Controls.Add(this.addButton);
            this.Addpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Addpanel.Location = new System.Drawing.Point(0, 0);
            this.Addpanel.Name = "Addpanel";
            this.Addpanel.Size = new System.Drawing.Size(800, 738);
            this.Addpanel.TabIndex = 3;
            // 
            // clo
            // 
            this.clo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clo.AutoRoundedCorners = true;
            this.clo.BackColor = System.Drawing.Color.Transparent;
            this.clo.BorderRadius = 17;
            this.clo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.clo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.clo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.clo.ForeColor = System.Drawing.Color.DimGray;
            this.clo.ItemHeight = 30;
            this.clo.Items.AddRange(new object[] {
            "Select Clo Name"});
            this.clo.Location = new System.Drawing.Point(273, 288);
            this.clo.Name = "clo";
            this.clo.Size = new System.Drawing.Size(286, 36);
            this.clo.TabIndex = 6;
            this.clo.SelectedIndexChanged += new System.EventHandler(this.clo_SelectedIndexChanged);
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
            this.addButton.Location = new System.Drawing.Point(273, 471);
            this.addButton.Name = "addButton";
            this.addButton.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.addButton.Size = new System.Drawing.Size(276, 88);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
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
            this.name.Location = new System.Drawing.Point(273, 181);
            this.name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.name.Name = "name";
            this.name.PasswordChar = '\0';
            this.name.PlaceholderText = "Name";
            this.name.SelectedText = "";
            this.name.Size = new System.Drawing.Size(286, 48);
            this.name.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.name.TabIndex = 10;
            // 
            // Details
            // 
            this.Details.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Details.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Details.DefaultText = "";
            this.Details.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Details.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Details.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Details.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Details.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Details.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Details.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Details.IconLeft = global::DBMidProject.Properties.Resources.images__2_;
            this.Details.Location = new System.Drawing.Point(265, 361);
            this.Details.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Details.Name = "Details";
            this.Details.PasswordChar = '\0';
            this.Details.PlaceholderText = "Deatails";
            this.Details.SelectedText = "";
            this.Details.Size = new System.Drawing.Size(286, 56);
            this.Details.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Details.TabIndex = 9;
            // 
            // Rubric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 738);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.Addpanel);
            this.Name = "Rubric";
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
        private Guna.UI2.WinForms.Guna2ComboBox clo;
        private Guna.UI2.WinForms.Guna2TextBox Details;
        private Guna.UI2.WinForms.Guna2TextBox name;
    }
}