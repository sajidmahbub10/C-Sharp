using Clinic_Management_System.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_Management_System.Presentation_Layer
{
    public partial class addDoctorUI : Form
    {
        public addDoctorUI()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DoctorRegistration_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CMS"].ConnectionString);
            connection.Open();
            //this.Show();
        }

        private void DoctorRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void UpdateDoctorList()
        {
            DoctorDataAccess doctorDataAccess = new DoctorDataAccess();
            addDoctorDataGridView.DataSource = doctorDataAccess.GetAllDoctors();
        }

        private void addDoctorRegistrationButton_Click(object sender, EventArgs e)
        {

            if (addDoctorNameTextBox.Text == "")
            {
                MessageBox.Show("Name cannot be empty");
            }
            else if (addDoctorUsernameTextBox.Text == "")
            {
                MessageBox.Show("Username cannot be empty");
            }
            else if (addDoctorPasswordTextBox.Text == "")
            {
                MessageBox.Show("Password cannot be empty");
            }
            else if (addDoctorPasswordTextBox.Text.Length != 8)
            {
                MessageBox.Show("Password length should be eight");
            }
            else if (addDoctorConfirmPasswordTextBox.Text == "")
            {
                MessageBox.Show("Confirm Password cannot be empty");
            }
            else if (addDoctorDepartmentComboBox.Text == "")
            {
                MessageBox.Show("Department cannot be empty");
            }
            else if (addDoctorChamberNoComboBox.Text == "")
            {
                MessageBox.Show("Chamber No cannot be empty");
            }
            else if (addDoctorVisitingDaysComboBox.Text == "")
            {
                MessageBox.Show("Visiting Days cannot be empty");
            }
            else if (addDoctorVisitingHoursComboBox.Text == "")
            {
                MessageBox.Show("Visiting Hours cannot be empty");
            }
            else if (addDoctorAppointmentFeeComboBox.Text == "")
            {
                MessageBox.Show("Appointment Fee cannot be empty");
            }
            else
            {
                if (addDoctorPasswordTextBox.Text != addDoctorConfirmPasswordTextBox.Text)
                {
                    MessageBox.Show("Password and Confirm Password does not match");
                }
                else
                {
                    DoctorDataAccess doctorDataAccess = new DoctorDataAccess();
                    if (doctorDataAccess.AddNewDoctor(addDoctorNameTextBox.Text, addDoctorUsernameTextBox.Text, addDoctorPasswordTextBox.Text, addDoctorDepartmentComboBox.Text, Convert.ToInt32(addDoctorChamberNoComboBox.Text), addDoctorVisitingDaysComboBox.Text, addDoctorVisitingHoursComboBox.Text, Convert.ToInt32(addDoctorAppointmentFeeComboBox.Text)))
                    {
                        MessageBox.Show("Doctor added");
                        UpdateDoctorList();
                    }
                    else
                    {
                        MessageBox.Show("Error in adding");
                    }
                }
            }

            //    DoctorDataAccess doctorDataAccess = new DoctorDataAccess();
            //if (doctorDataAccess.AddNewDoctor(addDoctorNameTextBox.Text, addDoctorUsernameTextBox.Text, addDoctorPasswordTextBox.Text,addDoctorDepartmentComboBox.Text, Convert.ToInt32(addDoctorChamberNoComboBox.Text),addDoctorVisitingDaysComboBox.Text, addDoctorVisitingHoursComboBox.Text, Convert.ToInt32(addDoctorAppointmentFeeComboBox.Text)))
            //{
            //    MessageBox.Show("Doctor added");
            //    UpdateDoctorList();
            //}
            //else
            //{
            //    MessageBox.Show("Error in adding");
            //}
        }

        private void addDoctorDepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addDoctorBackButton_Click(object sender, EventArgs e)
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
