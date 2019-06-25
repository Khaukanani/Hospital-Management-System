using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTU_Care_Treatment.Forms
{
    public partial class UserDashboard : Form
    {
        public UserDashboard()
        {
            InitializeComponent();
        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {

        }

        private void lblLName_Click(object sender, EventArgs e)
        {

        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatientView patient = new PatientView();
            patient.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Appointment1 appointment = new Appointment1();
            appointment.Show();
        }

        private void admissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admitted admited = new Admitted();
            admited.Show();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountForm acc = new AccountForm();
            acc.Show();
        }

        private void prescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrescriptionForm presc = new PrescriptionForm();
            presc.Show();
        }
    }
}
