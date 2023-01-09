
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addressOneTextBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addressTwoTextBox = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.postalCodeTextBox = new System.Windows.Forms.TextBox();
            this.countryTextBox = new System.Windows.Forms.TextBox();
            this.postalCodeLabel = new System.Windows.Forms.Label();
            this.countryLabel = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.headerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(203, 20);
            this.textBox1.TabIndex = 0;
            // 
            // addressOneTextBox
            // 
            this.addressOneTextBox.Location = new System.Drawing.Point(67, 159);
            this.addressOneTextBox.Name = "addressOneTextBox";
            this.addressOneTextBox.Size = new System.Drawing.Size(203, 20);
            this.addressOneTextBox.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(67, 211);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(203, 20);
            this.textBox3.TabIndex = 2;
            // 
            // activeCheckBox
            // 
            this.activeCheckBox.AutoSize = true;
            this.activeCheckBox.Location = new System.Drawing.Point(67, 396);
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
            // addressTwoTextBox
            // 
            this.addressTwoTextBox.AutoSize = true;
            this.addressTwoTextBox.Location = new System.Drawing.Point(64, 195);
            this.addressTwoTextBox.Name = "addressTwoTextBox";
            this.addressTwoTextBox.Size = new System.Drawing.Size(72, 13);
            this.addressTwoTextBox.TabIndex = 6;
            this.addressTwoTextBox.Text = "Address Two:";
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(67, 262);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(202, 20);
            this.textBox2.TabIndex = 8;
            // 
            // postalCodeTextBox
            // 
            this.postalCodeTextBox.Location = new System.Drawing.Point(67, 310);
            this.postalCodeTextBox.Name = "postalCodeTextBox";
            this.postalCodeTextBox.Size = new System.Drawing.Size(202, 20);
            this.postalCodeTextBox.TabIndex = 9;
            // 
            // countryTextBox
            // 
            this.countryTextBox.Location = new System.Drawing.Point(67, 360);
            this.countryTextBox.Name = "countryTextBox";
            this.countryTextBox.Size = new System.Drawing.Size(202, 20);
            this.countryTextBox.TabIndex = 10;
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
            this.createButton.Location = new System.Drawing.Point(195, 445);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 14;
            this.createButton.Text = "Create";
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
            // CreateCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 560);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.postalCodeLabel);
            this.Controls.Add(this.countryTextBox);
            this.Controls.Add(this.postalCodeTextBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.addressTwoTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.activeCheckBox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.addressOneTextBox);
            this.Controls.Add(this.textBox1);
            this.Name = "CreateCustomer";
            this.Text = "Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox addressOneTextBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox activeCheckBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label addressTwoTextBox;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox postalCodeTextBox;
        private System.Windows.Forms.TextBox countryTextBox;
        private System.Windows.Forms.Label postalCodeLabel;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label headerLabel;
    }
}