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
    public partial class EditTutor : Form
    {
        private readonly Tutor activeTutor;
        private Tutor tutor;
        private readonly ITutorService tutorService;
        public EditTutor(RepoControl repo, Tutor activeTutor, int id)
        {
            this.activeTutor = activeTutor;
            this.tutorService = repo.Tutors;

            InitializeComponent();
            GetTutorForForm(id);
            this.editButton.Enabled = CheckIfFormIsValid();
        }

        private void GetTutorForForm(int id)
        {
            this.tutor = this.tutorService.GetTutor(id);

            if(this.tutor != null)
            {
                this.tutorNameTextBox.Text = tutor.TutorName;
                this.usernameTextBox.Text = tutor.UserName;
                this.passwordTextBox.Text = tutor.Password;
                this.rateTextBox.Text = tutor.Rate.ToString();
                this.adminCheckbox.Checked = tutor.IsAdmin;
            }

            if (tutor.UserName.Equals("admin"))
            {
                this.usernameTextBox.ReadOnly = true;
                this.adminCheckbox.Enabled = false;
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (Decimal.TryParse(this.rateTextBox.Text, out decimal rate))
            {
                Tutor tutor = new Tutor()
                {
                    TutorId = this.tutor.TutorId,
                    TutorName = this.tutorNameTextBox.Text,
                    UserName = this.usernameTextBox.Text,
                    Password = this.passwordTextBox.Text,
                    Rate = rate,
                    IsAdmin = this.adminCheckbox.Checked,
                };

                try
                {
                    this.tutorService.EditTutor(tutor);
                    MessageBox.Show("Tutor updated successfully");
                    this.Close();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Error while updating the tutor");
                }
            }
        }

        private bool CheckIfFormIsValid()
        {
            return !String.IsNullOrWhiteSpace(this.tutorNameTextBox.Text) &&
                   !String.IsNullOrWhiteSpace(this.usernameTextBox.Text) &&
                   !String.IsNullOrWhiteSpace(this.passwordTextBox.Text) &&
                   Decimal.TryParse(this.rateTextBox.Text, out decimal rate);
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

            this.editButton.Enabled = CheckIfFormIsValid();
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

            this.editButton.Enabled = CheckIfFormIsValid();
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

            this.editButton.Enabled = CheckIfFormIsValid();
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

            this.editButton.Enabled = CheckIfFormIsValid();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (tutor.UserName.Equals("admin"))
                {
                    MessageBox.Show("Not allowed to delete system created admin profile.");
                    return;
                }

                if (tutor.UserName.Equals(activeTutor.UserName))
                {
                    MessageBox.Show("Cannot delete a logged in tutor");
                    return;
                }

                this.tutorService.DeleteTutor(this.tutor.TutorId);
                MessageBox.Show("Tutor deleted successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Error deleting the tutor");
            }
        }
    }
}
