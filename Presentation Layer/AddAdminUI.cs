using Clinic_Management_System.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_Management_System.Presentation_Layer
{
    public partial class addAdminUI : Form
    {


     public  void UpdateAdminList()
        {
            AdminDataAccess adminDataAccess = new AdminDataAccess();
            addAdminListDataGridView.DataSource = adminDataAccess.GetAllAdmins();
        }
        public addAdminUI()
        {
            InitializeComponent();
        }

        private void AddAdminUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AddAdminUI_Load(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CMS"].ConnectionString);
            connection.Open();
            //this.Show();
        }

        public bool IsValidEmailAddress(string email)
        {
            try
            {
                MailAddress ma = new MailAddress(email);

                return true;
            }
            catch
            {
                return false;
            }
        }
        private void addAdminRegisterButton_Click(object sender, EventArgs e)
        {

            if (addAdminNameTextBox.Text == "")
            {
                MessageBox.Show("Name cannot be empty");
            }
            else if (addAdminUsernameTextBox.Text == "")
            {
                MessageBox.Show("Username cannot be empty");
            }
            else if (addAdminPasswordTextBox.Text == "")
            {
                MessageBox.Show("Password cannot be empty");
            }
            else if (addAdminPasswordTextBox.Text.Length != 7)
            {
                MessageBox.Show("Password length should be seven");
            }
            else if (addAdminConfirmPasswordTextBox.Text == "")
            {
                MessageBox.Show("Confirm Password cannot be empty");
            }
            else if (addAdminEmailTextBox.Text == "")
            {
                MessageBox.Show("Email cannot be empty");
            }
            else if (IsValidEmailAddress(addAdminEmailTextBox.Text) != true)
            {
                MessageBox.Show("Email pattern is not correct");
            }

            else if (addAdminGenderComboBox.Text == "")
            {
                MessageBox.Show("Gender cannot be empty");
            }
            else if (addAdminAgeTextBox.Text == "")
            {
                MessageBox.Show("Age cannot be empty");
            }
            else if (Convert.ToInt32(addAdminAgeTextBox.Text)<0)
            {
                MessageBox.Show("Age cannot be negative");
            }
            else
            {
                if (addAdminPasswordTextBox.Text != addAdminConfirmPasswordTextBox.Text)
                {
                    MessageBox.Show("Password and Confirm Password does not match");
                }
                else
                {
                    AdminDataAccess adminDataAccess = new AdminDataAccess();
                    if (adminDataAccess.AddNewAdmin(addAdminNameTextBox.Text, addAdminUsernameTextBox.Text, addAdminPasswordTextBox.Text, addAdminEmailTextBox.Text, addAdminGenderComboBox.Text, Convert.ToInt32(addAdminAgeTextBox.Text)))
                    {
                        MessageBox.Show("Admin added");
                        UpdateAdminList();
                    }
                    else
                    {
                        MessageBox.Show("Error in adding");
                    }
                }
            }



            //AdminDataAccess adminDataAccess = new AdminDataAccess();
            //if (adminDataAccess.AddNewAdmin(addAdminNameTextBox.Text, addAdminUsernameTextBox.Text,addAdminPasswordTextBox.Text, addAdminEmailTextBox.Text,addAdminGenderTextBox.Text, Convert.ToInt32(addAdminAgeTextBox.Text)))
            //{
            //    MessageBox.Show("Admin added");
            //    UpdateAdminList();
            //}
            //else
            //{
            //    MessageBox.Show("Error in adding");
            //}
        }

        private void addAdminBackButton_Click(object sender, EventArgs e)
        {
         
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
