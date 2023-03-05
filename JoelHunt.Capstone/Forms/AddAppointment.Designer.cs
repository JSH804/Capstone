
namespace JoelHunt.Capstone.Forms
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
            this.tutorComboBox = new System.Windows.Forms.ComboBox();
            this.customerLabel = new System.Windows.Forms.Label();
            this.tutorLabel = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.typeLabel = new System.Windows.Forms.Label();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.appCalendar = new System.Windows.Forms.MonthCalendar();
            this.appDayLabel = new System.Windows.Forms.Label();
            this.appTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(12, 28);
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
            this.customerComboBox.Size = new System.Drawing.Size(229, 21);
            this.customerComboBox.TabIndex = 1;
            // 
            // tutorComboBox
            // 
            this.tutorComboBox.FormattingEnabled = true;
            this.tutorComboBox.Location = new System.Drawing.Point(98, 172);
            this.tutorComboBox.Name = "tutorComboBox";
            this.tutorComboBox.Size = new System.Drawing.Size(229, 21);
            this.tutorComboBox.TabIndex = 2;
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
            // tutorLabel
            // 
            this.tutorLabel.AutoSize = true;
            this.tutorLabel.Location = new System.Drawing.Point(95, 156);
            this.tutorLabel.Name = "tutorLabel";
            this.tutorLabel.Size = new System.Drawing.Size(35, 13);
            this.tutorLabel.TabIndex = 4;
            this.tutorLabel.Text = "Tutor:";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(100, 482);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(227, 20);
            this.startDatePicker.TabIndex = 6;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(100, 530);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(227, 20);
            this.endDatePicker.TabIndex = 7;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(97, 206);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(96, 13);
            this.typeLabel.TabIndex = 8;
            this.typeLabel.Text = "Appointment Type:";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(100, 466);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(58, 13);
            this.startTimeLabel.TabIndex = 9;
            this.startTimeLabel.Text = "Start Time:";
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(97, 514);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.endTimeLabel.TabIndex = 10;
            this.endTimeLabel.Text = "End Time:";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(252, 572);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // appCalendar
            // 
            this.appCalendar.Location = new System.Drawing.Point(100, 295);
            this.appCalendar.Name = "appCalendar";
            this.appCalendar.TabIndex = 12;
            // 
            // appDayLabel
            // 
            this.appDayLabel.AutoSize = true;
            this.appDayLabel.Location = new System.Drawing.Point(97, 273);
            this.appDayLabel.Name = "appDayLabel";
            this.appDayLabel.Size = new System.Drawing.Size(95, 13);
            this.appDayLabel.TabIndex = 13;
            this.appDayLabel.Text = "Appointment Date:";
            // 
            // appTypeComboBox
            // 
            this.appTypeComboBox.FormattingEnabled = true;
            this.appTypeComboBox.Location = new System.Drawing.Point(100, 222);
            this.appTypeComboBox.Name = "appTypeComboBox";
            this.appTypeComboBox.Size = new System.Drawing.Size(227, 21);
            this.appTypeComboBox.TabIndex = 14;
            // 
            // AddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 665);
            this.Controls.Add(this.appTypeComboBox);
            this.Controls.Add(this.appDayLabel);
            this.Controls.Add(this.appCalendar);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.endTimeLabel);
            this.Controls.Add(this.startTimeLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.tutorLabel);
            this.Controls.Add(this.customerLabel);
            this.Controls.Add(this.tutorComboBox);
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
        private System.Windows.Forms.ComboBox tutorComboBox;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.Label tutorLabel;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.MonthCalendar appCalendar;
        private System.Windows.Forms.Label appDayLabel;
        private System.Windows.Forms.ComboBox appTypeComboBox;
    }
}