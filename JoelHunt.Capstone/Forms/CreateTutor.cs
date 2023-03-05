using JoelHunt.Capstone.Models;
using JoelHunt.Capstone.Repositories;
using JoelHunt.Capstone.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoelHunt.Capstone.Forms
{
    public partial class CreateTutor : Form
    {
        private readonly Tutor activeTutor;
        private readonly ITutorService tutorService;
        public CreateTutor(RepoControl repo, Tutor activeTutor)
        {
            this.activeTutor = activeTutor;
            this.tutorService = repo.Tutors;
            InitializeComponent();
            this.createButton.Enabled = CheckIfFormIsValid();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if(Decimal.TryParse(this.rateTextBox.Text, out decimal rate))
            {
                Tutor tutor = new Tutor()
                {
                    TutorName = this.tutorNameTextBox.Text,
                    UserName = this.usernameTextBox.Text,
                    Password = this.passwordTextBox.Text,
                    Rate = rate,
                    IsAdmin = this.adminCheckbox.Checked,
                    CreateDate = DateTime.UtcNow,
                    CreatedBy = this.activeTutor.UserName
                };

                try
                {
                    this.tutorService.AddTutor(tutor);
                    MessageBox.Show("Tutor created successfully");
                    this.Close();
                }
                catch(ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Error while saving the tutor");
                }
            }
        }

        private bool CheckIfFormIsValid()
        {
            return !String.IsNullOrWhiteSpace(this.tutorNameTextBox.Text) &&
                   !String.IsNullOrWhiteSpace(this.usernameTextBox.Text) &&
                   !String.IsNullOrWhiteSpace(this.passwordTextBox.Text) &&
                   Double.TryParse(this.rateTextBox.Text, out double rate);
        }

        private void tutorNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.tutorNameTextBox.Text))
            {
                this.tutorNameTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                this.tutorNameTextBox.BackColor = Color.White;
            }

            this.createButton.Enabled = CheckIfFormIsValid();
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.usernameTextBox.Text))
            {
                this.usernameTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                this.usernameTextBox.BackColor = Color.White;
            }

            this.createButton.Enabled = CheckIfFormIsValid();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.passwordTextBox.Text))
            {
                this.passwordTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                this.passwordTextBox.BackColor = Color.White;
            }

            this.createButton.Enabled = CheckIfFormIsValid();
        }

        private void rateTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!Decimal.TryParse(this.rateTextBox.Text, out decimal rate) || String.IsNullOrWhiteSpace(this.rateTextBox.Text))
            {
                this.rateTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                this.rateTextBox.BackColor = Color.White;
            }

            this.createButton.Enabled = CheckIfFormIsValid();
        }
    }
}
