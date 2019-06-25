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
    public partial class AdminDashboad : Form
    {
        public AdminDashboad()
        {
            InitializeComponent();
        }

        private void AdminDashboad_Load(object sender, EventArgs e)
        {

        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm user = new UsersForm();
            user.Show();
        }

        private void DoctorsMNS_Click(object sender, EventArgs e)
        {
            DoctorsForm doctors = new DoctorsForm();
            doctors.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatientsForm patients = new PatientsForm();
            patients.Show();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryForm hist = new HistoryForm();
            hist.Show();
        }
    }
}
