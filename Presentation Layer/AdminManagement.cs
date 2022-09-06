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
    public partial class AdminManagement : Form
    {
        Admin a;
        public AdminManagement()
        {
            InitializeComponent();
        }
        public AdminManagement(Admin ad)
        {
            a = ad;
            InitializeComponent();
        }

        private void adminManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AdminManagement_Load(object sender, EventArgs e)
        {

            AdminDataAccess adminDataAccess = new AdminDataAccess();
            adminListDataGridView.DataSource = adminDataAccess.GetAllAdmins();

        }

        private void addAdminLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addAdminUI addAdminUI = new addAdminUI();
            addAdminUI.Show();
            //this.Hide();
            
        }

        private void deleteAdminLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DeleteAdminUI deleteAdminUI = new DeleteAdminUI();
            deleteAdminUI.Show();
       
        }

        private void updateAdminLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateAdminUI updateAdminUI = new UpdateAdminUI();
            updateAdminUI.Show();
            
        }

        private void backButton_Click(object sender, EventArgs e)
        {

            new AdminUI(a).Show();
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
