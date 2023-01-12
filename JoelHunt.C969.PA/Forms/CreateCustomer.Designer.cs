
namespace JoelHunt.C969.PA.Forms
{
    partial class CreateCustomer
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
            this.customerNameTextBox = new System.Windows.Forms.TextBox();
            this.addressOneTextBox = new System.Windows.Forms.TextBox();
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addressTwoLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.postalCodeTextBox = new System.Windows.Forms.TextBox();
            this.postalCodeLabel = new System.Windows.Forms.Label();
            this.countryLabel = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.headerLabel = new System.Windows.Forms.Label();
            this.createCountryButton = new System.Windows.Forms.Button();
            this.countryComboBox = new System.Windows.Forms.ComboBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.addressTwoTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // customerNameTextBox
            // 
            this.customerNameTextBox.Location = new System.Drawing.Point(67, 106);
            this.customerNameTextBox.Name = "customerNameTextBox";
            this.customerNameTextBox.Size = new System.Drawing.Size(203, 20);
            this.customerNameTextBox.TabIndex = 0;
            // 
            // addressOneTextBox
            // 
            this.addressOneTextBox.Location = new System.Drawing.Point(67, 159);
            this.addressOneTextBox.Name = "addressOneTextBox";
            this.addressOneTextBox.Size = new System.Drawing.Size(203, 20);
            this.addressOneTextBox.TabIndex = 1;
            // 
            // activeCheckBox
            // 
            this.activeCheckBox.AutoSize = true;
            this.activeCheckBox.Location = new System.Drawing.Point(66, 444);
            this.activeCheckBox.Name = "activeCheckBox";
            this.activeCheckBox.Size = new System.Drawing.Size(56, 17);
            this.activeCheckBox.TabIndex = 3;
            this.activeCheckBox.Text = "Active";
            this.activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(64, 90);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(88, 13);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Customer Name: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Address One:";
            // 
            // addressTwoLabel
            // 
            this.addressTwoLabel.AutoSize = true;
            this.addressTwoLabel.Location = new System.Drawing.Point(64, 195);
            this.addressTwoLabel.Name = "addressTwoLabel";
            this.addressTwoLabel.Size = new System.Drawing.Size(72, 13);
            this.addressTwoLabel.TabIndex = 6;
            this.addressTwoLabel.Text = "Address Two:";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(64, 246);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(27, 13);
            this.cityLabel.TabIndex = 7;
            this.cityLabel.Text = "City:";
            // 
            // postalCodeTextBox
            // 
            this.postalCodeTextBox.Location = new System.Drawing.Point(67, 310);
            this.postalCodeTextBox.Name = "postalCodeTextBox";
            this.postalCodeTextBox.Size = new System.Drawing.Size(202, 20);
            this.postalCodeTextBox.TabIndex = 9;
            // 
            // postalCodeLabel
            // 
            this.postalCodeLabel.AutoSize = true;
            this.postalCodeLabel.Location = new System.Drawing.Point(64, 294);
            this.postalCodeLabel.Name = "postalCodeLabel";
            this.postalCodeLabel.Size = new System.Drawing.Size(67, 13);
            this.postalCodeLabel.TabIndex = 12;
            this.postalCodeLabel.Text = "Postal Code:";
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(64, 344);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(46, 13);
            this.countryLabel.TabIndex = 13;
            this.countryLabel.Text = "Country:";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(169, 478);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(100, 23);
            this.createButton.TabIndex = 14;
            this.createButton.Text = "Add Customer";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // headerLabel
            // 
            this.headerLabel.AllowDrop = true;
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(12, 28);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(195, 29);
            this.headerLabel.TabIndex = 15;
            this.headerLabel.Text = "Create Customer";
            // 
            // createCountryButton
            // 
            this.createCountryButton.Location = new System.Drawing.Point(291, 362);
            this.createCountryButton.Name = "createCountryButton";
            this.createCountryButton.Size = new System.Drawing.Size(90, 23);
            this.createCountryButton.TabIndex = 17;
            this.createCountryButton.Text = "Create Country";
            this.createCountryButton.UseVisualStyleBackColor = true;
            this.createCountryButton.Click += new System.EventHandler(this.createCountryButton_Click);
            // 
            // countryComboBox
            // 
            this.countryComboBox.FormattingEnabled = true;
            this.countryComboBox.Location = new System.Drawing.Point(66, 362);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Size = new System.Drawing.Size(203, 21);
            this.countryComboBox.TabIndex = 19;
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(67, 263);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(203, 20);
            this.cityTextBox.TabIndex = 20;
            // 
            // addressTwoTextBox
            // 
            this.addressTwoTextBox.Location = new System.Drawing.Point(67, 212);
            this.addressTwoTextBox.Name = "addressTwoTextBox";
            this.addressTwoTextBox.Size = new System.Drawing.Size(203, 20);
            this.addressTwoTextBox.TabIndex = 21;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(66, 409);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 20);
            this.textBox1.TabIndex = 22;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.AutoSize = true;
            this.phoneTextBox.Location = new System.Drawing.Point(64, 393);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(41, 13);
            this.phoneTextBox.TabIndex = 23;
            this.phoneTextBox.Text = "Phone:";
            // 
            // CreateCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 560);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.addressTwoTextBox);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.countryComboBox);
            this.Controls.Add(this.createCountryButton);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.postalCodeLabel);
            this.Controls.Add(this.postalCodeTextBox);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.addressTwoLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.activeCheckBox);
            this.Controls.Add(this.addressOneTextBox);
            this.Controls.Add(this.customerNameTextBox);
            this.Name = "CreateCustomer";
            this.Text = "Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox customerNameTextBox;
        private System.Windows.Forms.TextBox addressOneTextBox;
        private System.Windows.Forms.CheckBox activeCheckBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label addressTwoLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox postalCodeTextBox;
        private System.Windows.Forms.Label postalCodeLabel;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button createCountryButton;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox addressTwoTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label phoneTextBox;
    }
}