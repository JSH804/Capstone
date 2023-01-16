
namespace JoelHunt.C969.PA.Forms
{
    partial class AddAppointment
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
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.customerLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.appTypeTextBox = new System.Windows.Forms.TextBox();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.typeLabel = new System.Windows.Forms.Label();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(26, 35);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(197, 29);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Add Appointment";
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(98, 123);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(206, 21);
            this.customerComboBox.TabIndex = 1;
            // 
            // userComboBox
            // 
            this.userComboBox.FormattingEnabled = true;
            this.userComboBox.Location = new System.Drawing.Point(98, 172);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(206, 21);
            this.userComboBox.TabIndex = 2;
            // 
            // customerLabel
            // 
            this.customerLabel.AutoSize = true;
            this.customerLabel.Location = new System.Drawing.Point(95, 107);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(54, 13);
            this.customerLabel.TabIndex = 3;
            this.customerLabel.Text = "Customer:";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(95, 156);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(32, 13);
            this.userLabel.TabIndex = 4;
            this.userLabel.Text = "User:";
            // 
            // appTypeTextBox
            // 
            this.appTypeTextBox.Location = new System.Drawing.Point(98, 221);
            this.appTypeTextBox.Name = "appTypeTextBox";
            this.appTypeTextBox.Size = new System.Drawing.Size(206, 20);
            this.appTypeTextBox.TabIndex = 5;
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(98, 269);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(206, 20);
            this.startDatePicker.TabIndex = 6;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(98, 321);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(206, 20);
            this.endDatePicker.TabIndex = 7;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(95, 205);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(96, 13);
            this.typeLabel.TabIndex = 8;
            this.typeLabel.Text = "Appointment Type:";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(95, 253);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(58, 13);
            this.startTimeLabel.TabIndex = 9;
            this.startTimeLabel.Text = "Start Time:";
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(95, 305);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.endTimeLabel.TabIndex = 10;
            this.endTimeLabel.Text = "End Time:";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(228, 396);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // AddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 500);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.endTimeLabel);
            this.Controls.Add(this.startTimeLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.appTypeTextBox);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.customerLabel);
            this.Controls.Add(this.userComboBox);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.headerLabel);
            this.Name = "AddAppointment";
            this.Text = "AddAppointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.ComboBox userComboBox;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.TextBox appTypeTextBox;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Button addButton;
    }
}