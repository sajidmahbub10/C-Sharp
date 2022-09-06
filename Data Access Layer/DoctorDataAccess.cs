using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Data_Access_Layer
{
    class DoctorDataAccess:DataAccess
    {
        public List<Doctor> GetAllDoctors()
        {
            string sql = "SELECT * FROM Doctors";
            SqlDataReader reader = this.GetData(sql);
            List<Doctor> doctors = new List<Doctor>();
            while (reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.DoctorId = (int)reader["DoctorId"];
                doctor.DoctorName = reader["DoctorName"].ToString();
                doctor.Username = reader["Username"].ToString();
                doctor.Password = reader["Password"].ToString();
                doctor.Department = reader["Department"].ToString();
                doctor.ChamberNo = (int)reader["ChamberNo"];
                doctor.VisitngHours = reader["VisitingHours"].ToString();
                doctor.visitingDays = reader["VisitingDays"].ToString();
                doctor.AppointmentFee = (int)reader["AppointmentFee"];
                doctors.Add(doctor);
            }
            return doctors;
        }

        public bool AddNewDoctor(string DoctorName, string Username, string Password, string Department,int ChamberNo, string VisitingDays, string VisitingHours,int AppointmentFee)
        {
            string sql = "INSERT INTO Doctors(DoctorName,Username,Password,Department,ChamberNo,VisitingDays,VisitingHours,AppointmentFee) VALUES('" + DoctorName + "','"+Username+ "','"+Password+ "','"+Department+ "','"+ChamberNo+ "','"+VisitingHours+ "','"+VisitingDays+ "','"+AppointmentFee+"')";
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteDoctor(int DoctorId)
        {
            string sql = "DELETE FROM Doctors WHERE DoctorId=" + DoctorId;
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateDoctor(int DoctorId, string DoctorName, string Username, string Password, string Department, int ChamberNo, string VisitingDays, string VisitingHours, int AppointmentFee)
        {
            string sql = "UPDATE Doctors SET DoctorName='" + DoctorName + "',UserName='" + Username + "',Password='" + Password + "',ChamberNo='" + ChamberNo + "',VisitingDays='" + VisitingDays + "',VisitingHours ='" + VisitingHours + "',AppointmentFee='"+ AppointmentFee + "' WHERE DoctorId=" + DoctorId;
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public List<Doctor> GetDoctorsByDept(string Department)
        {
            string sql = "SELECT* FROM DOCTORS WHERE Department= '" + Department + "'";
            SqlDataReader reader = this.GetData(sql);
            List<Doctor> doctors = new List<Doctor>();
            while (reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.DoctorId = (int)reader["DoctorId"];
                doctor.DoctorName = reader["DoctorName"].ToString();
                doctor.Username = reader["Username"].ToString();
                doctor.Password = reader["Password"].ToString();
                doctor.Department = reader["Department"].ToString();
                doctor.ChamberNo = (int)reader["ChamberNo"];
                doctor.VisitngHours = reader["VisitingHours"].ToString();
                doctor.visitingDays = reader["VisitingDays"].ToString();
                doctor.AppointmentFee = (int)reader["AppointmentFee"];
                doctors.Add(doctor);
            }
            return doctors;
        }
        public Doctor GetDoctors(string Username, string Password)
        {
            Doctor doctor = null;
            string sql = "SELECT* FROM DOCTORS WHERE Username = '" + Username + "' AND Password = '" + Password + "'";
            SqlDataReader reader = this.GetData(sql);

            while (reader.Read())
            {
                doctor = new Doctor();
           
                doctor.DoctorId = (int)reader["DoctorId"];
                doctor.DoctorName = reader["DoctorName"].ToString();
                doctor.Username = reader["Username"].ToString();
                doctor.Password = reader["Password"].ToString();
                doctor.Department = reader["Department"].ToString();
                doctor.ChamberNo = (int)reader["ChamberNo"];
                doctor.visitingDays = reader["VisitingDays"].ToString();
                doctor.VisitngHours = reader["VisitingHours"].ToString();
                doctor.AppointmentFee = (int)reader["AppointmentFee"];

            }
            return doctor;
        }

    }
}
