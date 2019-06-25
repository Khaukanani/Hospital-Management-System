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
    public partial class Admitted : Form
    {
        public Admitted()
        {
            InitializeComponent();
        }
       
        AdmittedDAL cdal = new AdmittedDAL();
        AdmittedBLL p = new AdmittedBLL();
        UserDAL dal = new UserDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PatientView_Load(object sender, EventArgs e)
        {
            DataTable dt = cdal.Select();
            dgvPatientsView.DataSource = dt;
        }

        private void dgvPatientsView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of particular row
            int rowIndex = e.RowIndex;
            txtAdmissionID.Text = dgvPatientsView.Rows[rowIndex].Cells[0].Value.ToString();
            txtFileNumber.Text = dgvPatientsView.Rows[rowIndex].Cells[1].Value.ToString();
            txtUserID.Text = dgvPatientsView.Rows[rowIndex].Cells[2].Value.ToString();
            txtDescription.Text = dgvPatientsView.Rows[rowIndex].Cells[3].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get Keyword from Text box
            string keywords = txtSearch.Text;

            //Chec if the keywords has value or not
            if (keywords != null)
            {
                //Show user based on keywords
                DataTable dt = cdal.Search(keywords);
                dgvPatientsView.DataSource = dt;
            }
            else
            {
                //show all users from the database
                DataTable dt = cdal.Select();
                dgvPatientsView.DataSource = dt;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            //show all users from the database
            DataTable dt = cdal.Select();
            dgvPatientsView.DataSource = dt;
        }

        private void pictureBoxClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

            //Get Keyword from Text box
            string keywords = txtSearch.Text;

            //Chec if the keywords has value or not
            if (keywords != null)
            {
                //Show user based on keywords
                DataTable dt = cdal.Search(keywords);
                dgvPatientsView.DataSource = dt;
            }
            else
            {
                //show all users from the database
                DataTable dt = cdal.Select();
                dgvPatientsView.DataSource = dt;
            }
        }

        private void dgvPatientsView_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of particular row
            int rowIndex = e.RowIndex;
            txtAdmissionID.Text = dgvPatientsView.Rows[rowIndex].Cells[0].Value.ToString();
            txtFileNumber.Text = dgvPatientsView.Rows[rowIndex].Cells[1].Value.ToString();
            txtUserID.Text = dgvPatientsView.Rows[rowIndex].Cells[2].Value.ToString();
            txtDescription.Text = dgvPatientsView.Rows[rowIndex].Cells[3].Value.ToString();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            //Get the Values from Form
            p.FileNumber = int.Parse(txtFileNumber.Text);
            p.Id = int.Parse(txtUserID.Text);
            p.Reason = txtDescription.Text;
            p.DateAdmitted = DateTime.Now;
            //Getting the ID to Logged in user and passign its value in dealer or cutomer module
            string loggedUsr = Login.loggedIn;
            UserBLL usr = dal.GetIDFromUsername(loggedUsr);
            p.Id = usr.Id;

            //Creating boolean variable to check whether the dealer or cutomer is added or not
            bool success = cdal.Insert(p);

            if (success == true)
            {
                //Dealer or Cutomer inserted successfully 
                MessageBox.Show("Successfully");
                //Clear();
                //Refresh Data Grid View
                DataTable dt = cdal.Select();
                dgvPatientsView.DataSource = dt;
            }
            else
            {
                //failed to insert dealer or customer
            }
        }
    }
}
