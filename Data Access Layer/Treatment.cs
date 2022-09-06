using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Data_Access_Layer
{
    class Treatment : DataAccess
    {
        public int DoctorId { get; private set; }
        public int PrescriptionNo { get; private set; }
        public int PatientId { get; private set; }
        public string PatientName { get; private set; }
        public string DoctorName { get; private set; }
        public string Prescription { get; set; }
        public DateTime Date { get; set; }
        public bool InsertPrescription(Patient P, Doctor D)
        {
            string sql = "INSERT INTO Treatment(PatientId,DoctorId,PatientName,DoctorName,Prescription) VALUES('" + P.PatientId + "','" + D.DoctorId + "','" + P.PatientName + "','" + D.DoctorName + "','" + P.Prescription + "')";
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public List<Treatment> ShowPrecription(int PatientId)
        {

            string sql = "SELECT* FROM Treatment WHERE PatientId=" + PatientId;
            SqlDataReader reader = this.GetData(sql);
            List<Treatment> treatments = new List<Treatment>();
            while (reader.Read())
            {
                Treatment treatment = new Treatment();
                treatment.PrescriptionNo = (int)reader["PrescriptionNo"];
                treatment.PatientId = (int)reader["PatientId"];
                treatment.DoctorId = (int)reader["DoctorId"];

                treatment.PatientName = reader["PatientName"].ToString();

                treatment.DoctorName = reader["DoctorName"].ToString();
                treatment.Prescription = reader["Prescription"].ToString();

                treatments.Add(treatment);
            }
            return treatments;
        }

    }
}
