
namespace JoelHunt.C969.PA.Forms
{
    partial class CreateCountry
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.countryTextBox = new System.Windows.Forms.TextBox();
            this.countryNameLabel = new System.Windows.Forms.Label();
            this.createCountryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(22, 33);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(173, 29);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Create Country";
            // 
            // countryTextBox
            // 
            this.countryTextBox.Location = new System.Drawing.Point(39, 152);
            this.countryTextBox.Name = "countryTextBox";
            this.countryTextBox.Size = new System.Drawing.Size(212, 20);
            this.countryTextBox.TabIndex = 1;
            // 
            // countryNameLabel
            // 
            this.countryNameLabel.AutoSize = true;
            this.countryNameLabel.Location = new System.Drawing.Point(36, 136);
            this.countryNameLabel.Name = "countryNameLabel";
            this.countryNameLabel.Size = new System.Drawing.Size(77, 13);
            this.countryNameLabel.TabIndex = 2;
            this.countryNameLabel.Text = "Country Name:";
            // 
            // createCountryButton
            // 
            this.createCountryButton.Location = new System.Drawing.Point(176, 178);
            this.createCountryButton.Name = "createCountryButton";
            this.createCountryButton.Size = new System.Drawing.Size(75, 23);
            this.createCountryButton.TabIndex = 3;
            this.createCountryButton.Text = "Add Country";
            this.createCountryButton.UseVisualStyleBackColor = true;
            this.createCountryButton.Click += new System.EventHandler(this.createCountryButton_Click);
            // 
            // CreateCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 258);
            this.Controls.Add(this.createCountryButton);
            this.Controls.Add(this.countryNameLabel);
            this.Controls.Add(this.countryTextBox);
            this.Controls.Add(this.headerLabel);
            this.Name = "CreateCountry";
            this.Text = "CreateCountry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.TextBox countryTextBox;
        private System.Windows.Forms.Label countryNameLabel;
        private System.Windows.Forms.Button createCountryButton;
    }
}