using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Data_Access_Layer
{
 public  class Receptionist
    {
        public string ReceptionistName { get; set; }
        public int ReceptionistId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}
