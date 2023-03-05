
namespace JoelHunt.Capstone.Forms
{
    partial class TutorTypeReport
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
            this.appComboBox = new System.Windows.Forms.ComboBox();
            this.tutorComboBox = new System.Windows.Forms.ComboBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.typeLabel = new System.Windows.Forms.Label();
            this.tutorLabel = new System.Windows.Forms.Label();
            this.resultDataGrid = new System.Windows.Forms.DataGridView();
            this.headerLabel = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // appComboBox
            // 
            this.appComboBox.FormattingEnabled = true;
            this.appComboBox.Location = new System.Drawing.Point(47, 84);
            this.appComboBox.Name = "appComboBox";
            this.appComboBox.Size = new System.Drawing.Size(143, 21);
            this.appComboBox.TabIndex = 0;
            // 
            // tutorComboBox
            // 
            this.tutorComboBox.FormattingEnabled = true;
            this.tutorComboBox.Location = new System.Drawing.Point(226, 85);
            this.tutorComboBox.Name = "tutorComboBox";
            this.tutorComboBox.Size = new System.Drawing.Size(138, 21);
            this.tutorComboBox.TabIndex = 1;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(397, 85);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(47, 65);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(96, 13);
            this.typeLabel.TabIndex = 3;
            this.typeLabel.Text = "Appointment Type:";
            // 
            // tutorLabel
            // 
            this.tutorLabel.AutoSize = true;
            this.tutorLabel.Location = new System.Drawing.Point(223, 66);
            this.tutorLabel.Name = "tutorLabel";
            this.tutorLabel.Size = new System.Drawing.Size(32, 13);
            this.tutorLabel.TabIndex = 4;
            this.tutorLabel.Text = "Tutor:";
            // 
            // resultDataGrid
            // 
            this.resultDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGrid.Location = new System.Drawing.Point(47, 133);
            this.resultDataGrid.Name = "resultDataGrid";
            this.resultDataGrid.Size = new System.Drawing.Size(634, 187);
            this.resultDataGrid.TabIndex = 5;
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(42, 18);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(353, 29);
            this.headerLabel.TabIndex = 6;
            this.headerLabel.Text = "Find Appointment Type By Tutor";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.Location = new System.Drawing.Point(47, 355);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(70, 25);
            this.resultLabel.TabIndex = 7;
            this.resultLabel.Text = "label1";
            // 
            // TutorTypeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 449);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.resultDataGrid);
            this.Controls.Add(this.tutorLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.tutorComboBox);
            this.Controls.Add(this.appComboBox);
            this.Name = "TutorTypeReport";
            this.Text = "Report";
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox appComboBox;
        private System.Windows.Forms.ComboBox tutorComboBox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label tutorLabel;
        private System.Windows.Forms.DataGridView resultDataGrid;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label resultLabel;
    }
}