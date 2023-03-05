using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoelHunt.Capstone.Forms.ViewModels;
using JoelHunt.Capstone.Models;

namespace JoelHunt.Capstone.Services
{
    public interface IAppointmentService
    {
        bool AddAppointment(Appointment appointment);
        AppointmentEditModel GetAppointment(int id); 
        bool UpdateAppointment(Appointment app);
        bool DeleteAppointment(int id);

        List<AppointmentListModel> GetAppointmentListModels(int tutorId = 0);
        List<AppointmentListReport> GetAppointmentListReport(int tutorId = 0);
        List<AppointmentIdentificationModel> GetAppointmentIdentificationModels();
    }
}
