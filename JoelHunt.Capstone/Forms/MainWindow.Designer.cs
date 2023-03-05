
namespace JoelHunt.Capstone.Forms
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.apointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTutorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findAppointmentTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerAppointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedulePerTutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsForCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empoyeeRevenueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apointToolStripMenuItem,
            this.customersToolStripMenuItem,
            this.tutorsToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // apointToolStripMenuItem
            // 
            this.apointToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createAppointmentToolStripMenuItem,
            this.findAppointmentToolStripMenuItem});
            this.apointToolStripMenuItem.Name = "apointToolStripMenuItem";
            this.apointToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.apointToolStripMenuItem.Text = "Appointments";
            // 
            // createAppointmentToolStripMenuItem
            // 
            this.createAppointmentToolStripMenuItem.Name = "createAppointmentToolStripMenuItem";
            this.createAppointmentToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.createAppointmentToolStripMenuItem.Text = "View Appointments";
            this.createAppointmentToolStripMenuItem.Click += new System.EventHandler(this.createAppointmentToolStripMenuItem_Click);
            // 
            // findAppointmentToolStripMenuItem
            // 
            this.findAppointmentToolStripMenuItem.Name = "findAppointmentToolStripMenuItem";
            this.findAppointmentToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.findAppointmentToolStripMenuItem.Text = "Add Appointment";
            this.findAppointmentToolStripMenuItem.Click += new System.EventHandler(this.findAppointmentToolStripMenuItem_Click);
            // 
            // customersToolStripMenuItem
            // 
            this.customersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewCustomersToolStripMenuItem,
            this.createCustomerToolStripMenuItem});
            this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            this.customersToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.customersToolStripMenuItem.Text = "Customers";
            // 
            // viewCustomersToolStripMenuItem
            // 
            this.viewCustomersToolStripMenuItem.Name = "viewCustomersToolStripMenuItem";
            this.viewCustomersToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.viewCustomersToolStripMenuItem.Text = "View Customers";
            this.viewCustomersToolStripMenuItem.Click += new System.EventHandler(this.viewCustomersToolStripMenuItem_Click);
            // 
            // createCustomerToolStripMenuItem
            // 
            this.createCustomerToolStripMenuItem.Name = "createCustomerToolStripMenuItem";
            this.createCustomerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.createCustomerToolStripMenuItem.Text = "Create Customer";
            this.createCustomerToolStripMenuItem.Click += new System.EventHandler(this.createCustomerToolStripMenuItem_Click);
            // 
            // tutorsToolStripMenuItem
            // 
            this.tutorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewTutorsToolStripMenuItem,
            this.addTutorToolStripMenuItem});
            this.tutorsToolStripMenuItem.Name = "tutorsToolStripMenuItem";
            this.tutorsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.tutorsToolStripMenuItem.Text = "Tutors";
            // 
            // viewTutorsToolStripMenuItem
            // 
            this.viewTutorsToolStripMenuItem.Name = "viewTutorsToolStripMenuItem";
            this.viewTutorsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewTutorsToolStripMenuItem.Text = "View Tutors";
            this.viewTutorsToolStripMenuItem.Click += new System.EventHandler(this.viewTutorsToolStripMenuItem_Click);
            // 
            // addTutorToolStripMenuItem
            // 
            this.addTutorToolStripMenuItem.Name = "addTutorToolStripMenuItem";
            this.addTutorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addTutorToolStripMenuItem.Text = "Create Tutor";
            this.addTutorToolStripMenuItem.Click += new System.EventHandler(this.addTutorToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findAppointmentTypeToolStripMenuItem,
            this.customerAppointmentsToolStripMenuItem,
            this.schedulePerTutorToolStripMenuItem,
            this.appointmentsForCustomerToolStripMenuItem,
            this.empoyeeRevenueToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // findAppointmentTypeToolStripMenuItem
            // 
            this.findAppointmentTypeToolStripMenuItem.Name = "findAppointmentTypeToolStripMenuItem";
            this.findAppointmentTypeToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.findAppointmentTypeToolStripMenuItem.Text = "Appointment by Type";
            this.findAppointmentTypeToolStripMenuItem.Click += new System.EventHandler(this.findAppointmentTypeToolStripMenuItem_Click);
            // 
            // customerAppointmentsToolStripMenuItem
            // 
            this.customerAppointmentsToolStripMenuItem.Name = "customerAppointmentsToolStripMenuItem";
            this.customerAppointmentsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.customerAppointmentsToolStripMenuItem.Text = "Schedule Per Customer";
            this.customerAppointmentsToolStripMenuItem.Click += new System.EventHandler(this.customerAppointmentsToolStripMenuItem_Click);
            // 
            // schedulePerTutorToolStripMenuItem
            // 
            this.schedulePerTutorToolStripMenuItem.Name = "schedulePerTutorToolStripMenuItem";
            this.schedulePerTutorToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.schedulePerTutorToolStripMenuItem.Text = "Schedule Per Tutor";
            this.schedulePerTutorToolStripMenuItem.Click += new System.EventHandler(this.schedulePerTutorToolStripMenuItem_Click);
            // 
            // appointmentsForCustomerToolStripMenuItem
            // 
            this.appointmentsForCustomerToolStripMenuItem.Name = "appointmentsForCustomerToolStripMenuItem";
            this.appointmentsForCustomerToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.appointmentsForCustomerToolStripMenuItem.Text = "Appointment Type by Month";
            this.appointmentsForCustomerToolStripMenuItem.Click += new System.EventHandler(this.appointmentsForCustomerToolStripMenuItem_Click);
            // 
            // empoyeeRevenueToolStripMenuItem
            // 
            this.empoyeeRevenueToolStripMenuItem.Name = "empoyeeRevenueToolStripMenuItem";
            this.empoyeeRevenueToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.empoyeeRevenueToolStripMenuItem.Text = "Empoyee Revenue by Month";
            this.empoyeeRevenueToolStripMenuItem.Click += new System.EventHandler(this.empoyeeRevenueToolStripMenuItem_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Location = new System.Drawing.Point(0, 27);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(800, 421);
            this.MainPanel.TabIndex = 3;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "A2Z Tutoring Scheduling App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem apointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createCustomerToolStripMenuItem;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ToolStripMenuItem viewCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findAppointmentTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schedulePerTutorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentsForCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empoyeeRevenueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerAppointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tutorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTutorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTutorToolStripMenuItem;
    }
}