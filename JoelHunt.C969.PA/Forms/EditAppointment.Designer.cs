
namespace JoelHunt.C969.PA.Forms
{
    partial class EditAppointment
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
            this.appTypeComboBox = new System.Windows.Forms.ComboBox();
            this.appDayLabel = new System.Windows.Forms.Label();
            this.appCalendar = new System.Windows.Forms.MonthCalendar();
            this.addButton = new System.Windows.Forms.Button();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.userLabel = new System.Windows.Forms.Label();
            this.customerLabel = new System.Windows.Forms.Label();
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.headerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // appTypeComboBox
            // 
            this.appTypeComboBox.FormattingEnabled = true;
            this.appTypeComboBox.Location = new System.Drawing.Point(111, 232);
            this.appTypeComboBox.Name = "appTypeComboBox";
            this.appTypeComboBox.Size = new System.Drawing.Size(227, 21);
            this.appTypeComboBox.TabIndex = 28;
            // 
            // appDayLabel
            // 
            this.appDayLabel.AutoSize = true;
            this.appDayLabel.Location = new System.Drawing.Point(108, 283);
            this.appDayLabel.Name = "appDayLabel";
            this.appDayLabel.Size = new System.Drawing.Size(95, 13);
            this.appDayLabel.TabIndex = 27;
            this.appDayLabel.Text = "Appointment Date:";
            // 
            // appCalendar
            // 
            this.appCalendar.Location = new System.Drawing.Point(111, 305);
            this.appCalendar.Name = "appCalendar";
            this.appCalendar.TabIndex = 26;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(263, 582);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 25;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(108, 524);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.endTimeLabel.TabIndex = 24;
            this.endTimeLabel.Text = "End Time:";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(111, 476);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(58, 13);
            this.startTimeLabel.TabIndex = 23;
            this.startTimeLabel.Text = "Start Time:";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(108, 216);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(96, 13);
            this.typeLabel.TabIndex = 22;
            this.typeLabel.Text = "Appointment Type:";
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(111, 540);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(227, 20);
            this.endDatePicker.TabIndex = 21;
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(111, 492);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(227, 20);
            this.startDatePicker.TabIndex = 20;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(106, 166);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(32, 13);
            this.userLabel.TabIndex = 19;
            this.userLabel.Text = "User:";
            // 
            // customerLabel
            // 
            this.customerLabel.AutoSize = true;
            this.customerLabel.Location = new System.Drawing.Point(106, 117);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(54, 13);
            this.customerLabel.TabIndex = 18;
            this.customerLabel.Text = "Customer:";
            // 
            // userComboBox
            // 
            this.userComboBox.FormattingEnabled = true;
            this.userComboBox.Location = new System.Drawing.Point(109, 182);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(229, 21);
            this.userComboBox.TabIndex = 17;
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(109, 133);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(229, 21);
            this.customerComboBox.TabIndex = 16;
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(23, 38);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(196, 29);
            this.headerLabel.TabIndex = 15;
            this.headerLabel.Text = "Edit Appointment";
            // 
            // EditAppointment
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
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.customerLabel);
            this.Controls.Add(this.userComboBox);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.headerLabel);
            this.Name = "EditAppointment";
            this.Text = "EditAppointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox appTypeComboBox;
        private System.Windows.Forms.Label appDayLabel;
        private System.Windows.Forms.MonthCalendar appCalendar;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.ComboBox userComboBox;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.Label headerLabel;
    }
}