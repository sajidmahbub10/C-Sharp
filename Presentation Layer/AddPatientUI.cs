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
    public partial class AddPatientUI : Form
    {
        public AddPatientUI()
        {
            InitializeComponent();
        }
        private void AddPatientUI_Load(object sender, EventArgs e)
        {
            //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CMS"].ConnectionString);
            //connection.Open();
            PatientDataAccess patientDataAccess = new PatientDataAccess();
            addPatientDataGridView.DataSource = patientDataAccess.GetAllPatients();
        }
        private void AddPatientUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void addPatientBackButton_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }
        public void UpdatePatientList()
        {
            PatientDataAccess patientDataAccess = new PatientDataAccess();
            addPatientDataGridView.DataSource = patientDataAccess.GetAllPatients();
        }

        private void addPatientRegisterButton_Click(object sender, EventArgs e)
        {
            if (addPatientNameTextBox.Text == "")
            {
                MessageBox.Show("Name cannot be empty");
            }
            else if (addPatientUserNameTextBox.Text == "")
            {
                MessageBox.Show("Username cannot be empty");
            }
            else if (addPatientPasswordTextBox.Text == "")
            {
                MessageBox.Show("Password cannot be empty");
            }
            else if (addPatientPasswordTextBox.Text.Length != 9)
            {
                MessageBox.Show("Password length should be nine");
            }
            else if (addPatientConfirmPasswordTextBox.Text == "")
            {
                MessageBox.Show("Confirm Password cannot be empty");
            }
            else if (addPatientGenderComboBox.Text == "")
            {
                MessageBox.Show("Gender cannot be empty");
            }
            else if (addPatientAgeTextBox.Text == "")
            {
                MessageBox.Show("Age cannot be empty");
            }
            else if (Convert.ToInt32(addPatientAgeTextBox.Text) < 0)
            {
                MessageBox.Show("Age cannot be negative");
            }
            else if (addPatientHeightTextBox.Text == "")
            {
                MessageBox.Show("Height cannot be empty");
            }
            else if (Convert.ToInt32(addPatientHeightTextBox.Text) <0)
            {
                MessageBox.Show("Height cannot be negative");
            }
            else if (addPatientWeightTextBox.Text == "")
            {
                MessageBox.Show("Weight cannot be empty");
            }
            else if (Convert.ToInt32(addPatientWeightTextBox.Text) < 0)
            {
                MessageBox.Show("Weight cannot be negative");
            }
            else if (bloodGroupComboBox.Text == "")
            {
                MessageBox.Show("Blood Group cannot be empty");
            }
            else if (checkedListBox1.Text == "")
            {
                MessageBox.Show("Current Disease cannot be empty");
            }
            else
            {
                if (addPatientPasswordTextBox.Text != addPatientConfirmPasswordTextBox.Text)
                {
                    MessageBox.Show("Password and Confirm Password does not match");
                }
                else
                {
                    PatientDataAccess patientDataAccess = new PatientDataAccess();
                    if (patientDataAccess.AddNewPatient(addPatientNameTextBox.Text, addPatientUserNameTextBox.Text, addPatientPasswordTextBox.Text, addPatientGenderComboBox.Text, Convert.ToInt32(addPatientAgeTextBox.Text), Convert.ToInt32(addPatientHeightTextBox.Text), Convert.ToInt32(addPatientWeightTextBox.Text), bloodGroupComboBox.Text, checkedListBox1.Text))
                    {
                        MessageBox.Show("Patient added");
                        UpdatePatientList();
                    }
                    else
                    {
                        MessageBox.Show("Error in adding");
                    }
                }
            }
            
            //PatientDataAccess patientDataAccess = new PatientDataAccess();
            //if (patientDataAccess.AddNewPatient(addPatientNameTextBox.Text, addPatientUserNameTextBox.Text, addPatientPasswordTextBox.Text, addPatientGenderTextBox.Text, Convert.ToInt32(addPatientAgeTextBox.Text), Convert.ToInt32(addPatientHeightTextBox.Text), Convert.ToInt32(addPatientWeightTextBox.Text), bloodGroupComboBox.Text, checkedListBox1.Text))
            //{
            //    MessageBox.Show("Patient added");
            //    UpdatePatientList();
            //}
            //else
            //{
            //    MessageBox.Show("Error in adding");
            //}
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
