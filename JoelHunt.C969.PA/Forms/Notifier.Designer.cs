
namespace JoelHunt.C969.PA.Forms
{
    partial class Notifier
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
            this.notificationMessage = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notificationMessage
            // 
            this.notificationMessage.AutoSize = true;
            this.notificationMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationMessage.Location = new System.Drawing.Point(61, 118);
            this.notificationMessage.Name = "notificationMessage";
            this.notificationMessage.Size = new System.Drawing.Size(0, 24);
            this.notificationMessage.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.closeButton.Location = new System.Drawing.Point(30, 267);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(257, 30);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // Notifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 297);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.notificationMessage);
            this.Name = "Notifier";
            this.Padding = new System.Windows.Forms.Padding(30, 0, 45, 0);
            this.Text = "Notifier";
            this.Load += new System.EventHandler(this.Notifier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label notificationMessage;
        private System.Windows.Forms.Button closeButton;
    }
}