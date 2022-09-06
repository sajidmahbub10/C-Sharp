using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Data_Access_Layer
{
  public  class AdminDataAccess:DataAccess
    {
        public List<Admin> GetAllAdmins()
        {
            string sql = "SELECT * FROM Admin";
            SqlDataReader reader = this.GetData(sql);
            List<Admin> admins = new List<Admin>();
            while (reader.Read())
            {
                Admin admin = new Admin();
                admin.AdminId = (int)reader["AdminId"];
                admin.AdminName = reader["AdminName"].ToString();
                admin.UserName = reader["Username"].ToString();
                admin.Password = reader["Password"].ToString();
                admin.Email = reader["Email"].ToString();
                admin.Gender = reader["Gender"].ToString();
                admin.Age = (int)reader["Age"];
              

                admins.Add(admin);
            }
            return admins;
        }

        //public List<Admin> GetAllAdminByAdminId(int AdminId)
        //{
        //    string sql = "SELECT * FROM Admin WHERE CategoryId=" + AdminId;
        //    SqlDataReader reader = this.GetData(sql);
        //    List<Admin> admins= new List<Admin>();
        //    while (reader.Read())
        //    {
        //        Admin admin= new Admin();
        //        admin.AdminId = (int)reader["AdminId"];
        //        admin.AdminName = reader["AdminName"].ToString();
                
        //       admins.Add(admin);
        //    }
        //    return admins;
        //}
        public List<string> GetAllAdminNames()
        {
            string sql = "SELECT * FROM Admin";
            SqlDataReader reader = this.GetData(sql);
            List<string> AdminName = new List<string>();
            while (reader.Read())
            {
                AdminName.Add(reader["AdminName"].ToString());
            }
            return AdminName;
        }
        
        public bool AddNewAdmin(string AdminName, string Username, string Password, string Email, string Gender, int Age )
        {
            string sql = "INSERT INTO Admin(AdminName,Username,Password,Email,Gender,Age) VALUES('" + AdminName + "','" + Username + "','" + Password + "','" + Email + "','" + Gender + "','" + Age + "')";
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteAdmin(int AdminId)
        {
            string sql = "DELETE FROM Admin WHERE AdminId=" + AdminId;
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateAdmin(int AdminId,string AdminName, string Username, string Password, string Email, string Gender, int Age)
        {
            string sql = "UPDATE Admin SET AdminName='" + AdminName + "',UserName='" + Username + "',Password='" + Password + "',Email='" + Email + "',Gender ='" + Gender + "',Age='" + Age + "' WHERE AdminId=" + AdminId;
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }


        public Admin GetAdmins(string Username, string Password)
        {
            Admin admin = null;
            string sql = "SELECT* FROM Admin WHERE Username = '" + Username + "' AND Password = '" + Password + "'";
            SqlDataReader reader = this.GetData(sql);

            while (reader.Read())
            {
                admin = new Admin();

                admin.AdminId = (int)reader["AdminId"];
                admin.AdminName = reader["AdminName"].ToString();
                admin.UserName = reader["Username"].ToString();
                admin.Password = reader["Password"].ToString();
                admin.Email = reader["Email"].ToString();
                admin.Gender = reader["Gender"].ToString();
                admin.Age = (int)reader["Age"];

            }
            return admin;
        }


    }
}
