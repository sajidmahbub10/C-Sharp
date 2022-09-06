using Clinic_Management_System.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_Management_System.Presentation_Layer
{
    public partial class AdminUI : Form
    {
        Admin a;
        public AdminUI()
        {
           
            InitializeComponent();
        }
        public AdminUI(Admin AD)
        {
            a = AD;
            InitializeComponent();
        }



        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void adminUIAdminManagementButton_Click(object sender, EventArgs e)
        {
            new AdminManagement(a).Show();
            this.Hide();
        }

        private void adminUIDoctorManagementButton_Click(object sender, EventArgs e)
        {
           
           new DoctorManagement(a).Show();
            this.Hide();

        }

     

        private void ReceptionistManageButton_Click(object sender, EventArgs e)
        {
            new ReceptionistManagement(a).Show();
            this.Hide();
        }

        private void AdminUI_Load(object sender, EventArgs e)
        {
            addAdminNameTextBox.Text = a.AdminName;
            addAdminEmailTextBox.Text = a.Email;
            addAdminGenderTextBox.Text = a.Gender;
            addAdminAgeTextBox.Text = a.Age.ToString();
        }

        private void adminUILogOutButton_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            new TotalEarning(a).Show();
            this.Hide();
        }
    }
}
