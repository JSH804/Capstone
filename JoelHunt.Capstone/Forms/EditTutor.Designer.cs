namespace JoelHunt.Capstone.Forms
{
    partial class EditTutor
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
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.headerLabel = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.Button();
            this.rateLabel = new System.Windows.Forms.Label();
            this.rateTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.tutorNameTextBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.adminCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(116, 224);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(203, 20);
            this.passwordTextBox.TabIndex = 45;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // headerLabel
            // 
            this.headerLabel.AllowDrop = true;
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(60, 41);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(148, 29);
            this.headerLabel.TabIndex = 44;
            this.headerLabel.Text = "Create Tutor";
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(219, 354);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(100, 23);
            this.editButton.TabIndex = 43;
            this.editButton.Text = "Save Changes";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // rateLabel
            // 
            this.rateLabel.AutoSize = true;
            this.rateLabel.Location = new System.Drawing.Point(113, 255);
            this.rateLabel.Name = "rateLabel";
            this.rateLabel.Size = new System.Drawing.Size(66, 13);
            this.rateLabel.TabIndex = 42;
            this.rateLabel.Text = "Hourly Rate:";
            // 
            // rateTextBox
            // 
            this.rateTextBox.Location = new System.Drawing.Point(116, 271);
            this.rateTextBox.Name = "rateTextBox";
            this.rateTextBox.Size = new System.Drawing.Size(202, 20);
            this.rateTextBox.TabIndex = 41;
            this.rateTextBox.TextChanged += new System.EventHandler(this.rateTextBox_TextChanged);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(113, 207);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 40;
            this.passwordLabel.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Username:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(112, 103);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(69, 13);
            this.nameLabel.TabIndex = 38;
            this.nameLabel.Text = "Tutor Name: ";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(115, 172);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(203, 20);
            this.usernameTextBox.TabIndex = 37;
            this.usernameTextBox.TextChanged += new System.EventHandler(this.usernameTextBox_TextChanged);
            // 
            // tutorNameTextBox
            // 
            this.tutorNameTextBox.Location = new System.Drawing.Point(115, 119);
            this.tutorNameTextBox.Name = "tutorNameTextBox";
            this.tutorNameTextBox.Size = new System.Drawing.Size(203, 20);
            this.tutorNameTextBox.TabIndex = 36;
            this.tutorNameTextBox.TextChanged += new System.EventHandler(this.tutorNameTextBox_TextChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(260, 48);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(100, 23);
            this.deleteButton.TabIndex = 46;
            this.deleteButton.Text = "Delete Tutor";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // adminCheckbox
            // 
            this.adminCheckbox.AutoSize = true;
            this.adminCheckbox.Location = new System.Drawing.Point(115, 310);
            this.adminCheckbox.Name = "adminCheckbox";
            this.adminCheckbox.Size = new System.Drawing.Size(86, 17);
            this.adminCheckbox.TabIndex = 47;
            this.adminCheckbox.Text = "Administrator";
            this.adminCheckbox.UseVisualStyleBackColor = true;
            // 
            // EditTutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 510);
            this.Controls.Add(this.adminCheckbox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.rateLabel);
            this.Controls.Add(this.rateTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.tutorNameTextBox);
            this.Name = "EditTutor";
            this.Text = "EditTutor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label rateLabel;
        private System.Windows.Forms.TextBox rateTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox tutorNameTextBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.CheckBox adminCheckbox;
    }
}