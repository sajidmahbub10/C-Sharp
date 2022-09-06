using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Data_Access_Layer
{
    class PatientDataAccess:DataAccess
    {

        public List<Patient> GetAllPatients()
        {
            string sql = "SELECT* FROM Patients";
            SqlDataReader reader = this.GetData(sql);
            List<Patient> patients = new List<Patient>();
            while (reader.Read())
            {
                Patient patient = new Patient();
                patient.PatientId = (int)reader["PatientId"];
                patient.PatientName = reader["PatientName"].ToString();
                patient.Username = reader["Username"].ToString();
                patient.Password = reader["Password"].ToString();
                patient.Gender = reader["Gender"].ToString();
                patient.Age = (int)reader["Age"];
                patient.Height = Convert.ToDouble(reader["Height"]);
                patient.Weight = Convert.ToDouble(reader["Weight"]);
                patient.BloodGroup = reader["BloodGroup"].ToString();
                patient.Disease = reader["Disease"].ToString();
                patients.Add(patient);
            }
            return patients;
        }
       
        public bool AddNewPatient(string PatientName, string Username, string Password, string Gender, int Age, double Height, double Weight, string BloodGroup, string Disease)
        {
            string sql = "INSERT INTO Patients(PatientName,Username,Password,Gender,Age,Height,Weight,BloodGroup,Disease) VALUES('" + PatientName + "','" + Username + "','" + Password + "','" + Gender + "','" + Age + "','" + Height + "','" + Weight + "','" + BloodGroup + "','" + Disease + "')";
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeletePatient(int PatientId)
        {
            string sql = "DELETE FROM Patients WHERE PatientId=" + PatientId;
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdatePatient(int PatientId, string PatientName, string Username, string Password, string Gender, int Age, double Height, double Weight, string BloodGroup, string Disease)
        {
            string sql = "UPDATE Patients SET PatientName='" + PatientName + "',Username='" + Username + "',Password='" + Password + "',Gender='" + Gender + "', Age ='" + Age + "',Height ='" + Height + "',Weight ='"+Weight+ "',BloodGroup ='" + BloodGroup + "',Disease ='" + Disease + "' WHERE PatientId=" + PatientId;
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public Patient GetPatients(string Username, string Password)
        {
            Patient patient = null;
            string sql = "SELECT* FROM Patients WHERE Username = '" + Username + "' AND Password = '" + Password + "'";
            SqlDataReader reader = this.GetData(sql);

            while (reader.Read())
            {
                patient = new Patient();

                patient.PatientId = (int)reader["PatientId"];
                patient.PatientName = reader["PatientName"].ToString();
                patient.Username = reader["Username"].ToString();
                patient.Password = reader["Password"].ToString();
                patient.Gender = reader["Gender"].ToString();
                patient.Age = (int)reader["Age"];
                patient.Height = Convert.ToDouble(reader["Height"]);
                patient.Weight = Convert.ToDouble(reader["Weight"]);
                patient.BloodGroup = reader["BloodGroup"].ToString();
                patient.Disease = reader["Disease"].ToString();

            }
            return patient;
        }


       

    }
}
