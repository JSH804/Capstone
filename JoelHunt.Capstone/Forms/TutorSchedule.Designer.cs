
namespace JoelHunt.Capstone.Forms
{
    partial class TutorSchedule
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
            this.tutorComboBox = new System.Windows.Forms.ComboBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.tutorLabel = new System.Windows.Forms.Label();
            this.resultDataGrid = new System.Windows.Forms.DataGridView();
            this.resultLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(30, 29);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(172, 29);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Tutor Schedule";
            // 
            // tutorComboBox
            // 
            this.tutorComboBox.FormattingEnabled = true;
            this.tutorComboBox.Location = new System.Drawing.Point(35, 99);
            this.tutorComboBox.Name = "tutorComboBox";
            this.tutorComboBox.Size = new System.Drawing.Size(148, 21);
            this.tutorComboBox.TabIndex = 1;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(189, 97);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(100, 23);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Get Schedule";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // tutorLabel
            // 
            this.tutorLabel.AutoSize = true;
            this.tutorLabel.Location = new System.Drawing.Point(35, 80);
            this.tutorLabel.Name = "tutorLabel";
            this.tutorLabel.Size = new System.Drawing.Size(32, 13);
            this.tutorLabel.TabIndex = 3;
            this.tutorLabel.Text = "Tutor:";
            // 
            // resultDataGrid
            // 
            this.resultDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGrid.Location = new System.Drawing.Point(35, 155);
            this.resultDataGrid.Name = "resultDataGrid";
            this.resultDataGrid.Size = new System.Drawing.Size(539, 207);
            this.resultDataGrid.TabIndex = 4;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.Location = new System.Drawing.Point(35, 392);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 25);
            this.resultLabel.TabIndex = 5;
            // 
            // TutorTutorSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 450);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.resultDataGrid);
            this.Controls.Add(this.tutorLabel);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.tutorComboBox);
            this.Controls.Add(this.headerLabel);
            this.Name = "TutorSchedule";
            this.Text = "Tutor Schedule";
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.ComboBox tutorComboBox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label tutorLabel;
        private System.Windows.Forms.DataGridView resultDataGrid;
        private System.Windows.Forms.Label resultLabel;
    }
}