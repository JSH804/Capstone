using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoelHunt.Capstone.Forms.ViewModels;
using JoelHunt.Capstone.Models;

namespace JoelHunt.Capstone.Services
{
    public interface ITutorService
    {
        void AddTestTutor();
        void AddTutor(Tutor tutor);
        Tutor GetTutor(int id);
        List<TutorListModel> GetTutors();
        void EditTutor(Tutor tutor);
        bool DeleteTutor(int tutorId);
        Tutor VerifyAndGetTutor(string tutorname, string password);

        List<TutorDropDown> GetTutorDropDown();
    }
}
