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
    public partial class Appointment1 : Form
    {
        public Appointment1()
        {
            InitializeComponent();
        }
        Appointment1DAL cdal = new Appointment1DAL();
        Appointment1BLL p = new Appointment1BLL();
        UserDAL dal = new UserDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Clear()
        {
            txtFileNumber.Text = "";
            txtUserID.Text = "";
            txtDescription.Text = "";
            txtDate.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get all the values from form
            p.FileNumber = int.Parse(txtFileNumber.Text);
            p.Id = int.Parse(txtUserID.Text);
            p.Description = txtDescription.Text;
            p.A_Date = DateTime.Now;
            //Geeting username of logged in user
            String loggedUsr = Login.loggedIn;
            UserBLL usr = dal.GetIDFromUsername(loggedUsr);

            p.Id = usr.Id;


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
                dgvProducts.DataSource = dt;
            }
            else
            {
                //failed to add data
                MessageBox.Show("Failed to Book a patient");
            }
        }

        private void Appointment1_Load(object sender, EventArgs e)
        {
            DataTable dt = cdal.Select();
            dgvProducts.DataSource = dt;
        }
    }
}
