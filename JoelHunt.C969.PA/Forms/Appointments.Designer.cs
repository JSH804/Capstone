
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
            this.searchCalender = new System.Windows.Forms.MonthCalendar();
            this.calendarUpdateButton = new System.Windows.Forms.Button();
            this.weekRadio = new System.Windows.Forms.RadioButton();
            this.monthRadio = new System.Windows.Forms.RadioButton();
            this.allRadio = new System.Windows.Forms.RadioButton();
            this.addAppButton = new System.Windows.Forms.Button();
            this.appointmentDataGrid = new System.Windows.Forms.DataGridView();
            this.headerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // searchCalender
            // 
            this.searchCalender.Location = new System.Drawing.Point(793, 194);
            this.searchCalender.Name = "searchCalender";
            this.searchCalender.ShowWeekNumbers = true;
            this.searchCalender.TabIndex = 1;
            this.searchCalender.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.searchCalender_DateChanged);
            // 
            // calendarUpdateButton
            // 
            this.calendarUpdateButton.Location = new System.Drawing.Point(922, 381);
            this.calendarUpdateButton.Name = "calendarUpdateButton";
            this.calendarUpdateButton.Size = new System.Drawing.Size(98, 23);
            this.calendarUpdateButton.TabIndex = 2;
            this.calendarUpdateButton.Text = "Update Calendar";
            this.calendarUpdateButton.UseVisualStyleBackColor = true;
            this.calendarUpdateButton.Click += new System.EventHandler(this.calendarUpdateButton_Click);
            // 
            // weekRadio
            // 
            this.weekRadio.AutoSize = true;
            this.weekRadio.Location = new System.Drawing.Point(878, 155);
            this.weekRadio.Name = "weekRadio";
            this.weekRadio.Size = new System.Drawing.Size(54, 17);
            this.weekRadio.TabIndex = 4;
            this.weekRadio.TabStop = true;
            this.weekRadio.Text = "Week";
            this.weekRadio.UseVisualStyleBackColor = true;
            this.weekRadio.CheckedChanged += new System.EventHandler(this.weekRadio_CheckedChanged);
            // 
            // monthRadio
            // 
            this.monthRadio.AutoSize = true;
            this.monthRadio.Location = new System.Drawing.Point(973, 155);
            this.monthRadio.Name = "monthRadio";
            this.monthRadio.Size = new System.Drawing.Size(55, 17);
            this.monthRadio.TabIndex = 5;
            this.monthRadio.TabStop = true;
            this.monthRadio.Text = "Month";
            this.monthRadio.UseVisualStyleBackColor = true;
            this.monthRadio.CheckedChanged += new System.EventHandler(this.monthRadio_CheckedChanged);
            // 
            // allRadio
            // 
            this.allRadio.AutoSize = true;
            this.allRadio.Location = new System.Drawing.Point(793, 155);
            this.allRadio.Name = "allRadio";
            this.allRadio.Size = new System.Drawing.Size(36, 17);
            this.allRadio.TabIndex = 6;
            this.allRadio.TabStop = true;
            this.allRadio.Text = "All";
            this.allRadio.UseVisualStyleBackColor = true;
            this.allRadio.CheckedChanged += new System.EventHandler(this.allRadio_CheckedChanged);
            // 
            // addAppButton
            // 
            this.addAppButton.Location = new System.Drawing.Point(647, 441);
            this.addAppButton.Name = "addAppButton";
            this.addAppButton.Size = new System.Drawing.Size(109, 23);
            this.addAppButton.TabIndex = 7;
            this.addAppButton.Text = "Add Appointment";
            this.addAppButton.UseVisualStyleBackColor = true;
            this.addAppButton.Click += new System.EventHandler(this.addAppButton_Click);
            // 
            // appointmentDataGrid
            // 
            this.appointmentDataGrid.AllowUserToAddRows = false;
            this.appointmentDataGrid.AllowUserToDeleteRows = false;
            this.appointmentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDataGrid.Location = new System.Drawing.Point(34, 93);
            this.appointmentDataGrid.MultiSelect = false;
            this.appointmentDataGrid.Name = "appointmentDataGrid";
            this.appointmentDataGrid.ReadOnly = true;
            this.appointmentDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentDataGrid.Size = new System.Drawing.Size(722, 324);
            this.appointmentDataGrid.TabIndex = 8;
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(29, 25);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(160, 29);
            this.headerLabel.TabIndex = 9;
            this.headerLabel.Text = "Appointments";
            // 
            // Appointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 562);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.appointmentDataGrid);
            this.Controls.Add(this.addAppButton);
            this.Controls.Add(this.allRadio);
            this.Controls.Add(this.monthRadio);
            this.Controls.Add(this.weekRadio);
            this.Controls.Add(this.calendarUpdateButton);
            this.Controls.Add(this.searchCalender);
            this.Name = "Appointments";
            this.Text = "Appointments";
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MonthCalendar searchCalender;
        private System.Windows.Forms.Button calendarUpdateButton;
        private System.Windows.Forms.RadioButton weekRadio;
        private System.Windows.Forms.RadioButton monthRadio;
        private System.Windows.Forms.RadioButton allRadio;
        private System.Windows.Forms.Button addAppButton;
        private System.Windows.Forms.DataGridView appointmentDataGrid;
        private System.Windows.Forms.Label headerLabel;
    }
}