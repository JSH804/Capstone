namespace JoelHunt.Capstone.Forms
{
    partial class Tutors
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
            this.deleteButton = new System.Windows.Forms.Button();
            this.editTutorButton = new System.Windows.Forms.Button();
            this.addTutorButton = new System.Windows.Forms.Button();
            this.tutorDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tutorDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(55, 25);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(82, 29);
            this.headerLabel.TabIndex = 9;
            this.headerLabel.Text = "Tutors";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(413, 453);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editTutorButton
            // 
            this.editTutorButton.Location = new System.Drawing.Point(494, 453);
            this.editTutorButton.Name = "editTutorButton";
            this.editTutorButton.Size = new System.Drawing.Size(98, 23);
            this.editTutorButton.TabIndex = 7;
            this.editTutorButton.Text = "Edit";
            this.editTutorButton.UseVisualStyleBackColor = true;
            this.editTutorButton.Click += new System.EventHandler(this.editTutorButton_Click);
            // 
            // addTutorButton
            // 
            this.addTutorButton.Location = new System.Drawing.Point(598, 453);
            this.addTutorButton.Name = "addTutorButton";
            this.addTutorButton.Size = new System.Drawing.Size(98, 23);
            this.addTutorButton.TabIndex = 6;
            this.addTutorButton.Text = "Add";
            this.addTutorButton.UseVisualStyleBackColor = true;
            this.addTutorButton.Click += new System.EventHandler(this.addTutorButton_Click);
            // 
            // tutorDataGrid
            // 
            this.tutorDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tutorDataGrid.Location = new System.Drawing.Point(96, 79);
            this.tutorDataGrid.Name = "tutorDataGrid";
            this.tutorDataGrid.Size = new System.Drawing.Size(600, 323);
            this.tutorDataGrid.TabIndex = 5;
            // 
            // Tutors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 520);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editTutorButton);
            this.Controls.Add(this.addTutorButton);
            this.Controls.Add(this.tutorDataGrid);
            this.Name = "Tutors";
            this.Text = "Tutors";
            ((System.ComponentModel.ISupportInitialize)(this.tutorDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editTutorButton;
        private System.Windows.Forms.Button addTutorButton;
        private System.Windows.Forms.DataGridView tutorDataGrid;
    }
}