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
    public partial class addReceptionistUI : Form
    {
        public addReceptionistUI()
        {
            InitializeComponent();
        }

       
        private void addReceptionistUI_Load(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CMS"].ConnectionString);
            connection.Open();
            //this.Show();
        }

        public void UpdateReceptionistList()
        {
            ReceptionistDataAccess receptionistDataAccess = new ReceptionistDataAccess();
            addReceptionistDataGridView.DataSource = receptionistDataAccess.GetAllReceptionists();
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
        private void addReceptionistRegisterButton_Click(object sender, EventArgs e)
        {

            if (addReceptionistNameTextBox.Text == "")
            {
                MessageBox.Show("Name cannot be empty");
            }
            else if (addReceptionistUsernameTextBox.Text == "")
            {
                MessageBox.Show("Username cannot be empty");
            }
            else if (addReceptionistPasswordTextBox.Text == "")
            {
                MessageBox.Show("Password cannot be empty");
            }
            else if (addReceptionistPasswordTextBox.Text.Length != 10)
            {
                MessageBox.Show("Password length should be ten");
            }
            else if (addReceptionistConfirmPasswordTextBox.Text == "")
            {
                MessageBox.Show("Confirm Password cannot be empty");
            }
            else if (addReceptionistEmailTextBox.Text == "")
            {
                MessageBox.Show("Email cannot be empty");
            }
            else if (IsValidEmailAddress(addReceptionistEmailTextBox.Text) != true)
            {
                MessageBox.Show("Email pattern is not correct");
            }
            else if (addReceptionistGenderComboBox.Text == "")
            {
                MessageBox.Show("Gender cannot be empty");
            }
            else if (addReceptionistAgeTextBox.Text == "")
            {
                MessageBox.Show("Age cannot be empty");
            }
            else if (Convert.ToInt32(addReceptionistAgeTextBox.Text) < 0)
            {
                MessageBox.Show("Age cannot be negative");
            }
            else
            {
                if (addReceptionistPasswordTextBox.Text != addReceptionistConfirmPasswordTextBox.Text)
                {
                    MessageBox.Show("Password and Confirm Password does not match");
                }
                else
                {

                    ReceptionistDataAccess adminDataAccess = new ReceptionistDataAccess();
                    if (adminDataAccess.AddNewReceptionist(addReceptionistNameTextBox.Text, addReceptionistUsernameTextBox.Text, addReceptionistPasswordTextBox.Text, addReceptionistEmailTextBox.Text, addReceptionistGenderComboBox.Text, Convert.ToInt32(addReceptionistAgeTextBox.Text)))
                    {
                        MessageBox.Show("Receptionist added");
                        UpdateReceptionistList();
                    }
                    else
                    {
                        MessageBox.Show("Error in adding");
                    }
                }
            }



                // ReceptionistDataAccess adminDataAccess = new ReceptionistDataAccess();
                //if (adminDataAccess.AddNewReceptionist(addReceptionistNameTextBox.Text,addReceptionistUsernameTextBox.Text, addReceptionistPasswordTextBox.Text, addReceptionistEmailTextBox.Text, addReceptionistGenderTextBox.Text, Convert.ToInt32(addReceptionistAgeTextBox.Text)))
                //{
                //    MessageBox.Show("Receptionist added");
                //    UpdateReceptionistList();
                //}
                //else
                //{
                //    MessageBox.Show("Error in adding");
                //}
            }

        private void addReceptionistBackButton_Click(object sender, EventArgs e)
        {
           
            this.Hide();
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
