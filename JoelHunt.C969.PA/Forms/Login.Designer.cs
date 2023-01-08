
namespace JoelHunt.C969.PA.Forms
{
    partial class Login
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
            this.loginButton = new System.Windows.Forms.Button();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameText = new System.Windows.Forms.Label();
            this.passwordText = new System.Windows.Forms.Label();
            this.loginTextHeader = new System.Windows.Forms.Label();
            this.LoginHeaderTwo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(396, 304);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(188, 180);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(283, 20);
            this.usernameTextBox.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(188, 234);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(283, 20);
            this.passwordTextBox.TabIndex = 2;
            // 
            // usernameText
            // 
            this.usernameText.AutoSize = true;
            this.usernameText.Location = new System.Drawing.Point(185, 164);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(67, 13);
            this.usernameText.TabIndex = 3;
            this.usernameText.Text = "Username: $";
            // 
            // passwordText
            // 
            this.passwordText.AutoSize = true;
            this.passwordText.Location = new System.Drawing.Point(187, 218);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(56, 13);
            this.passwordText.TabIndex = 4;
            this.passwordText.Text = "Password:";
            // 
            // loginTextHeader
            // 
            this.loginTextHeader.AutoSize = true;
            this.loginTextHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.loginTextHeader.Location = new System.Drawing.Point(269, 55);
            this.loginTextHeader.Name = "loginTextHeader";
            this.loginTextHeader.Size = new System.Drawing.Size(101, 39);
            this.loginTextHeader.TabIndex = 5;
            this.loginTextHeader.Text = "Login";
            // 
            // LoginHeaderTwo
            // 
            this.LoginHeaderTwo.AutoSize = true;
            this.LoginHeaderTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.LoginHeaderTwo.Location = new System.Drawing.Point(148, 94);
            this.LoginHeaderTwo.Name = "LoginHeaderTwo";
            this.LoginHeaderTwo.Size = new System.Drawing.Size(378, 24);
            this.LoginHeaderTwo.TabIndex = 6;
            this.LoginHeaderTwo.Text = "Please Enter Your Username and Password";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 387);
            this.Controls.Add(this.LoginHeaderTwo);
            this.Controls.Add(this.loginTextHeader);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.loginButton);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label usernameText;
        private System.Windows.Forms.Label passwordText;
        private System.Windows.Forms.Label loginTextHeader;
        private System.Windows.Forms.Label LoginHeaderTwo;
    }
}