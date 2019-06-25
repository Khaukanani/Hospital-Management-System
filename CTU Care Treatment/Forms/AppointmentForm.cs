using CTU_Care_Treatment.BLL;
using CTU_Care_Treatment.DAL;
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
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
        }
        AppointmentDAL cdal = new AppointmentDAL();
        AppointmentBLL p = new AppointmentBLL();
        UserDAL dal = new UserDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Clear()
        {
            txtName.Text = "";
            txtLastName.Text = "";
            txtIdNumber.Text = "";
            txtMedicalAid.Text = "";
            txtAddedBy.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtDate.Text = "";
           

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get all the values from form
            p.FirstName = txtName.Text;
            p.LastName = txtLastName.Text;
            p.IdNumber = txtIdNumber.Text;
            p.Gender = cmbCategory.Text;
            p.Contact = txtMedicalAid.Text;
            p.AddedDate = DateTime.Now;
            p.Reason = txtAddedBy.Text;
            p.Email = txtEmail.Text;
            p.Address = txtAddress.Text;
            //Geeting username of logged in user

           

            //Boolean variable to check if the data has been successfully added
            bool success = cdal.Insert(p);
            //if the data is successfully added then the value of success will be true else it will be false
            if (success == true)
            {
                //data inserted successfully
                MessageBox.Show("Appointment Added");
                //Cleaaring all textboxes
                Clear();
                //Refreshing dataGridview
                DataTable dt = cdal.Select();
                dgvPatients.DataSource = dt;
            }
            else
            {
                //failed to add data
                MessageBox.Show("Failed to Book a patient");
            }
        }
    }
}
