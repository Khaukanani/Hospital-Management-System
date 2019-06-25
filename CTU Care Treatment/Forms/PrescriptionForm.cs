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
    public partial class PrescriptionForm : Form
    {
        public PrescriptionForm()
        {
            InitializeComponent();
        }
        PrescriptionDAL cdal = new PrescriptionDAL();
        PrescriptionBLL p = new PrescriptionBLL();
        UserDAL dal = new UserDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void button2_Click(object sender, EventArgs e)//Prescribe button
        {
            //Get all the values from form
            p.FileNumber = int.Parse(txtFileNumber.Text);
            p.DoctorsID = int.Parse(txtDoctorsID.Text);
            p.Date = DateTime.Now;
            p.Prescribed = txtDescription.Text;
            //Geeting username of logged in user
            //String loggedUsr = Login.loggedIn;
            //UserBLL usr = dal.GetIDFromUsername(loggedUsr);



            //Boolean variable to check if the data has been successfully added
            bool success = cdal.Insert(p);
            //if the data is successfully added then the value of success will be true else it will be false
            if (success == true)
            {
                //data inserted successfully
                MessageBox.Show("Succesful");
                //Cleaaring all textboxes
               // Clear();
                //Refreshing dataGridview
                DataTable dt = cdal.Select();
                dgvPatientsView.DataSource = dt;
            }
            else
            {
                //failed to add data
                MessageBox.Show("Failed");
            }
        }
    }
}
