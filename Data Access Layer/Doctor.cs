using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Data_Access_Layer
{
   public class Doctor
    {
        public string DoctorName { get; set; }
        public int DoctorId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Department { get; set; }

        public int ChamberNo { get; set; }
        public string visitingDays { get; set; }
        public string VisitngHours { get; set; }
        public int AppointmentFee { get; set; }

        public string Prescription { get; private set; }


    }
}
