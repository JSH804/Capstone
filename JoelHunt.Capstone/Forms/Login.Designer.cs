
namespace JoelHunt.Capstone.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.loginButton = new System.Windows.Forms.Button();
            this.tutornameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.tutornameText = new System.Windows.Forms.Label();
            this.passwordText = new System.Windows.Forms.Label();
            this.loginTextHeader = new System.Windows.Forms.Label();
            this.loginHeaderTwo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            resources.ApplyResources(this.loginButton, "loginButton");
            this.loginButton.Name = "loginButton";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // tutornameTextBox
            // 
            resources.ApplyResources(this.tutornameTextBox, "tutornameTextBox");
            this.tutornameTextBox.Name = "tutornameTextBox";
            // 
            // passwordTextBox
            // 
            resources.ApplyResources(this.passwordTextBox, "passwordTextBox");
            this.passwordTextBox.Name = "passwordTextBox";
            // 
            // tutornameText
            // 
            resources.ApplyResources(this.tutornameText, "tutornameText");
            this.tutornameText.Name = "tutornameText";
            // 
            // passwordText
            // 
            resources.ApplyResources(this.passwordText, "passwordText");
            this.passwordText.Name = "passwordText";
            // 
            // loginTextHeader
            // 
            resources.ApplyResources(this.loginTextHeader, "loginTextHeader");
            this.loginTextHeader.Name = "loginTextHeader";
            // 
            // loginHeaderTwo
            // 
            resources.ApplyResources(this.loginHeaderTwo, "loginHeaderTwo");
            this.loginHeaderTwo.Name = "loginHeaderTwo";
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loginHeaderTwo);
            this.Controls.Add(this.loginTextHeader);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.tutornameText);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.tutornameTextBox);
            this.Controls.Add(this.loginButton);
            this.Name = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox tutornameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label tutornameText;
        private System.Windows.Forms.Label passwordText;
        private System.Windows.Forms.Label loginTextHeader;
        private System.Windows.Forms.Label loginHeaderTwo;
    }
}