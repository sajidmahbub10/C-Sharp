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
    public partial class AppointmentListUI : Form
    {
        Doctor d;
        public AppointmentListUI()
        {
            InitializeComponent();
        }
        public AppointmentListUI(Doctor dr)
        {
            d = dr;
            InitializeComponent();
        }

        private void AppointmentList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AppointmentListUI_Load(object sender, EventArgs e)
        {
            Appointment appointment = new Appointment();
            appointmentListDataGridView.DataSource = appointment.ShowDoctorAppointment(d.DoctorId);
        }

        

        private void giveTreatmentButton_Click(object sender, EventArgs e)
        {
            new GiveTreatmentUI(d).Show();
            this.Hide();
        }

        private void appointmentListBackButton_Click(object sender, EventArgs e)
        {
            new DoctorUI(d).Show();
            this.Hide();
        }
    }
}
