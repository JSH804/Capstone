using JoelHunt.C969.PA.Forms.ViewModels;
using JoelHunt.C969.PA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.C969.PA.Services
{
    public interface IAppointmentService
    {
        bool AddAppointment(Appointment appointment);
        AppointmentEditModel GetAppointment(int id); 
        bool UpdateAppointment(Appointment app);
        bool DeleteAppointment(int id);

        List<AppointmentListModel> GetAppointmentListModels(int userId = 0);
        List<AppointmentListReport> GetAppointmentListReport(int userId = 0);
        List<AppointmentIdentificationModel> GetAppointmentIdentificationModels();
    }
}
