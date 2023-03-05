using JoelHunt.Capstone.Forms.ViewModels;
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
    public partial class Tutors : Form
    {
        private readonly RepoControl repo;
        private readonly ITutorService tutorService;
        private readonly Tutor activeTutor;

        public Tutors(RepoControl repo, Tutor activeTutor)
        {
            this.repo = repo;
            this.tutorService = repo.Tutors;
            this.activeTutor = activeTutor;
            InitializeComponent();
            GetTutorsList();
            PopulateTutorGrid();
        }

        private void GetTutorsList()
        {
            this.tutors = this.tutorService.GetTutors();
        }

        private void PopulateTutorGrid()
        {
            this.tutorDataGrid.DataSource = this.tutors;
            this.tutorDataGrid.MultiSelect = false;
            this.tutorDataGrid.ReadOnly = true;
            this.tutorDataGrid.Columns[0].Visible = false;
            this.tutorDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.tutorDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void RefreshDataGrid()
        {
            this.tutorDataGrid.DataSource = typeof(TutorListModel);
            GetTutorsList();
            this.tutorDataGrid.DataSource = this.tutors;
        }

        private void RefreshAfterUpdate(object sender, EventArgs args)
        {
            RefreshDataGrid();
        }

        private void addTutorButton_Click(object sender, EventArgs e)
        {
            CreateTutor createTutor = new CreateTutor(repo, activeTutor);
            createTutor.Show();
            createTutor.FormClosed += RefreshAfterUpdate;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.tutorDataGrid.SelectedRows[0];
            int tutorId = Convert.ToInt32(row.Cells["tutorId"].Value);

            Tutor tutor = this.tutorService.GetTutor(tutorId);

            if(tutor != null)
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

                    this.tutorService.DeleteTutor(tutor.TutorId);
                    MessageBox.Show("Tutor deleted successfully");
                    RefreshDataGrid();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error deleting the tutor");
                }
            }


        }

        private void editTutorButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.tutorDataGrid.SelectedRows[0];
            int tutorId = Convert.ToInt32(row.Cells["tutorId"].Value);

            EditTutor edit = new EditTutor(repo, activeTutor, tutorId);
            edit.Show();
            edit.FormClosed += RefreshAfterUpdate;
        }

        private List<TutorListModel> tutors = new List<TutorListModel>();
    }
}
