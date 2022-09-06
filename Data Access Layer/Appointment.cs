using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Data_Access_Layer
{
   public class Appointment : DataAccess
    {
        public int DoctorId { get; private set; }
        public int PatientId { get; private set; }
        public string PatientName { get; private set; }
        public string DoctorName { get; private set; }
        public string AppointmentFee { get; private set; }
        public int Income{ get; set; }
        public DateTime AppointmentDate { get; set; }



        public bool SetAppointment(Patient P, Doctor D)
        {
            string sql = "INSERT INTO Appointment(DoctorId,PatientId,PatientName,DoctorName,AppointmentDate,AppointmentFee) VALUES('" +D.DoctorId+ "','" + P.PatientId + "','" + P.PatientName + "','" + D.DoctorName + "','" + P.AppointmentDate + "','" + D.AppointmentFee + "')";
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
      




        public List<Appointment> ShowUpComingAppointment(int PatientId)
        {
            string sql = "SELECT* from Appointment where  PatientId=" + PatientId + " AND AppointmentDate>GETDATE()";
            SqlDataReader reader = this.GetData(sql);
            List<Appointment> appointments = new List<Appointment>();
            while (reader.Read())
            {
                Appointment appointment = new Appointment();
                appointment.DoctorId = (int)reader["DoctorId"];
                appointment.PatientId = (int)reader["PatientId"];
                appointment.PatientName = reader["PatientName"].ToString();

                appointment.DoctorName = reader["DoctorName"].ToString();
                appointment.AppointmentFee = reader["AppointmentFee"].ToString();
                appointment.AppointmentDate = Convert.ToDateTime( reader["AppointmentDate"]);
                appointments.Add(appointment);
            }
            return appointments;
        }


        public List<Appointment> ShowAllAppointment()
        {
            string sql = "SELECT* from Appointment ";
            SqlDataReader reader = this.GetData(sql);
            List<Appointment> appointments = new List<Appointment>();
            while (reader.Read())
            {
                Appointment appointment = new Appointment();
                appointment.DoctorId = (int)reader["DoctorId"];
                appointment.PatientId = (int)reader["PatientId"];
                appointment.PatientName = reader["PatientName"].ToString();

                appointment.DoctorName = reader["DoctorName"].ToString();
                appointment.AppointmentFee = reader["AppointmentFee"].ToString();
                appointment.AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                appointments.Add(appointment);
            }
            return appointments;
        }





        public List<Appointment> ShowPreviousAppointment(int PatientId)
        {
            string sql = "SELECT* from Appointment where  PatientId=" + PatientId + " AND AppointmentDate<GETDATE()";
            SqlDataReader reader = this.GetData(sql);
            List<Appointment> appointments = new List<Appointment>();
            while (reader.Read())
            {
                Appointment appointment = new Appointment();
                appointment.DoctorId = (int)reader["DoctorId"];
                appointment.PatientId = (int)reader["PatientId"];
                appointment.PatientName = reader["PatientName"].ToString();

                appointment.DoctorName = reader["DoctorName"].ToString();
                appointment.AppointmentFee = reader["AppointmentFee"].ToString();
                appointment.AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                appointments.Add(appointment);
            }
            return appointments;
        }




        public bool DeleteAppointment(int PatientId)
        {
            string sql = "Delete from Appointment where PatientId=" + PatientId + "AND AppointmentDate<GETDATE()";
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public bool CancleAppointment(int PatientId, int DoctorId)
        {
            string sql = "Delete from Appointment where PatientId=" + PatientId + " AND DoctorId=" + DoctorId +"";
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool ShowUpDoctorAppointment(int DoctorId)
        {
            string sql = "SELECT * from Appointment where DoctorId=" + DoctorId + " AND AppointmentDate>GETDATE()";
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public List<Appointment> ShowDoctorAppointment(int DoctorId)
        {
            string sql = "SELECT * from Appointment where DoctorId=" + DoctorId + " AND AppointmentDate>GETDATE()";
            SqlDataReader reader = this.GetData(sql);
            List<Appointment> appointments = new List<Appointment>();
            while (reader.Read())
            {
                Appointment appointment = new Appointment();
                appointment.DoctorId = (int)reader["DoctorId"];
                appointment.PatientId = (int)reader["PatientId"];
                appointment.PatientName = reader["PatientName"].ToString();

                appointment.DoctorName = reader["DoctorName"].ToString();
                appointment.AppointmentFee = reader["AppointmentFee"].ToString();
                appointment.AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                appointments.Add(appointment);
            }
            return appointments;
        }

    }
}
