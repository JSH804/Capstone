
namespace JoelHunt.C969.PA.Forms
{
    partial class Appointments
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
            this.appointmentListView = new System.Windows.Forms.ListView();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.calendarUpdateButton = new System.Windows.Forms.Button();
            this.weekRadio = new System.Windows.Forms.RadioButton();
            this.yearRadio = new System.Windows.Forms.RadioButton();
            this.allRadio = new System.Windows.Forms.RadioButton();
            this.addAppButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // appointmentListView
            // 
            this.appointmentListView.HideSelection = false;
            this.appointmentListView.Location = new System.Drawing.Point(45, 70);
            this.appointmentListView.Name = "appointmentListView";
            this.appointmentListView.Size = new System.Drawing.Size(440, 325);
            this.appointmentListView.TabIndex = 0;
            this.appointmentListView.UseCompatibleStateImageBehavior = false;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(568, 164);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            // 
            // calendarUpdateButton
            // 
            this.calendarUpdateButton.Location = new System.Drawing.Point(697, 351);
            this.calendarUpdateButton.Name = "calendarUpdateButton";
            this.calendarUpdateButton.Size = new System.Drawing.Size(98, 23);
            this.calendarUpdateButton.TabIndex = 2;
            this.calendarUpdateButton.Text = "Update Calendar";
            this.calendarUpdateButton.UseVisualStyleBackColor = true;
            // 
            // weekRadio
            // 
            this.weekRadio.AutoSize = true;
            this.weekRadio.Location = new System.Drawing.Point(653, 125);
            this.weekRadio.Name = "weekRadio";
            this.weekRadio.Size = new System.Drawing.Size(54, 17);
            this.weekRadio.TabIndex = 4;
            this.weekRadio.TabStop = true;
            this.weekRadio.Text = "Week";
            this.weekRadio.UseVisualStyleBackColor = true;
            // 
            // yearRadio
            // 
            this.yearRadio.AutoSize = true;
            this.yearRadio.Location = new System.Drawing.Point(748, 125);
            this.yearRadio.Name = "yearRadio";
            this.yearRadio.Size = new System.Drawing.Size(47, 17);
            this.yearRadio.TabIndex = 5;
            this.yearRadio.TabStop = true;
            this.yearRadio.Text = "Year";
            this.yearRadio.UseVisualStyleBackColor = true;
            // 
            // allRadio
            // 
            this.allRadio.AutoSize = true;
            this.allRadio.Location = new System.Drawing.Point(568, 125);
            this.allRadio.Name = "allRadio";
            this.allRadio.Size = new System.Drawing.Size(36, 17);
            this.allRadio.TabIndex = 6;
            this.allRadio.TabStop = true;
            this.allRadio.Text = "All";
            this.allRadio.UseVisualStyleBackColor = true;
            // 
            // addAppButton
            // 
            this.addAppButton.Location = new System.Drawing.Point(376, 425);
            this.addAppButton.Name = "addAppButton";
            this.addAppButton.Size = new System.Drawing.Size(109, 23);
            this.addAppButton.TabIndex = 7;
            this.addAppButton.Text = "Add Appointment";
            this.addAppButton.UseVisualStyleBackColor = true;
            this.addAppButton.Click += new System.EventHandler(this.addAppButton_Click);
            // 
            // Appointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 555);
            this.Controls.Add(this.addAppButton);
            this.Controls.Add(this.allRadio);
            this.Controls.Add(this.yearRadio);
            this.Controls.Add(this.weekRadio);
            this.Controls.Add(this.calendarUpdateButton);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.appointmentListView);
            this.Name = "Appointments";
            this.Text = "Appointments";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView appointmentListView;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button calendarUpdateButton;
        private System.Windows.Forms.RadioButton weekRadio;
        private System.Windows.Forms.RadioButton yearRadio;
        private System.Windows.Forms.RadioButton allRadio;
        private System.Windows.Forms.Button addAppButton;
    }
}