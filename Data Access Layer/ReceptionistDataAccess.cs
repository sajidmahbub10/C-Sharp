using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Data_Access_Layer
{
    class ReceptionistDataAccess: DataAccess
    {
        public List<Receptionist> GetAllReceptionists()
        {
            string sql = "SELECT * FROM Receptionists";
            SqlDataReader reader = this.GetData(sql);
            List<Receptionist> receptionists = new List<Receptionist>();
            while (reader.Read())
            {
                Receptionist receptionist = new Receptionist();
                receptionist.ReceptionistId = (int)reader["ReceptionistId"];
                receptionist.ReceptionistName = reader["ReceptionistName"].ToString();
                receptionist.UserName = reader["Username"].ToString();
                receptionist.Password = reader["Password"].ToString();
                receptionist.Email = reader["Email"].ToString();
                receptionist.Gender = reader["Gender"].ToString();
                receptionist.Age = (int)reader["Age"];
               

                receptionists.Add(receptionist);
            }
            return receptionists;
        }

        public bool AddNewReceptionist(string ReceptionistName, string Username, string Password, string Email, string Gender, int Age)
        {
            string sql = "INSERT INTO Receptionists(ReceptionistName,Username,Password,Email,Gender,Age) VALUES('" + ReceptionistName + "','" + Username + "','" + Password + "','" + Email + "','" + Gender + "','"+Age+"')";
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteReceptionist(int ReceptionistId)
        {
            string sql = "DELETE FROM Receptionists WHERE ReceptionistId=" + ReceptionistId;
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateReceptionist(int ReceptionistId, string ReceptionistName, string Username, string Password, string Email, string Gender, int Age)
        {
            string sql = "UPDATE Receptionists SET ReceptionistName='" + ReceptionistName + "',UserName='" + Username + "',Password='" + Password + "',Email='" + Email + "',Gender ='" + Gender + "',Age='" + Age + "' WHERE ReceptionistId=" + ReceptionistId;
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public Receptionist GetReceptionists(string Username, string Password)
        {
            Receptionist receptionist = null;
            string sql = "SELECT* FROM Receptionists WHERE Username = '" + Username + "' AND Password = '" + Password + "'";
            SqlDataReader reader = this.GetData(sql);

            while (reader.Read())
            {
                receptionist = new Receptionist();

                receptionist.ReceptionistId = (int)reader["ReceptionistId"];
                receptionist.ReceptionistName = reader["ReceptionistName"].ToString();
                receptionist.UserName = reader["Username"].ToString();
                receptionist.Password = reader["Password"].ToString();
                receptionist.Email = reader["Email"].ToString();
                receptionist.Gender = reader["Gender"].ToString();
                receptionist.Age = (int)reader["Age"];

            }
            return receptionist;
        }
    }
}
