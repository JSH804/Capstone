using JoelHunt.C969.PA.Models;
using JoelHunt.C969.PA.Repositories;
using JoelHunt.C969.PA.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoelHunt.C969.PA.Forms
{
    public partial class Appointments : Form
    {
        private readonly IAppointmentService appointmentService;
        private readonly User activeUser;
        private readonly RepoControl repo;

        public Appointments(RepoControl repo, User activeUser)
        {
            this.repo = repo;
            this.appointmentService = repo.Appointments;
            this.activeUser = activeUser;
            InitializeComponent();
        }

        private void addAppButton_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment(this.repo, this.activeUser);
            addAppointment.Show();
        }
    }
}
