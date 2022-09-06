using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Data_Access_Layer
{
    public class Patient
    {

        public string PatientName { get; set; }
        public int PatientId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string BloodGroup { get; set; }
        public string Disease { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Prescription { get; set; }
    }
}
