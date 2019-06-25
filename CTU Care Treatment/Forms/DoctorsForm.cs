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
    public partial class DoctorsForm : Form
    {
        public DoctorsForm()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click_1(object sender, EventArgs e)
        {
            //Write the code to close this form
            this.Hide();
        }

        DoctorsBLL dc = new DoctorsBLL();
        DoctrosDAL dcDal = new DoctrosDAL();

        UserDAL uDal = new UserDAL();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get the Values from Form
            dc.Type = cmbType.Text;
            dc.DrName = txtName.Text;
            dc.Email = txtEmail.Text;
            dc.Contact = txtContact.Text;
            dc.Address = txtAddress.Text;
            dc.AddedDate = DateTime.Now;
            //Getting the ID to Logged in user and passign its value in dealer or cutomer module
            string loggedUsr = Login.loggedIn;
            UserBLL usr = uDal.GetIDFromUsername(loggedUsr);
            dc.AddedBy = usr.Id;

            //Creating boolean variable to check whether the dealer or cutomer is added or not
            bool success = dcDal.Insert(dc);

            if (success == true)
            {
                //Dealer or Cutomer inserted successfully 
                MessageBox.Show("DOCTOR Added Successfully");
                Clear();
                //Refresh Data Grid View
                DataTable dt = dcDal.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                //failed to insert dealer or customer
            }
        }
        public void Clear()
        {
            txtDoctorsID.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            txtSearch.Text = "";
            cmbType.Text = "";
        }


        private void dgvDeaCust_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            //int variable to get the identityof row clicked
            int rowIndex = e.RowIndex;

            txtDoctorsID.Text = dgvDeaCust.Rows[rowIndex].Cells[0].Value.ToString();
            cmbType.Text = dgvDeaCust.Rows[rowIndex].Cells[5].Value.ToString();
            txtName.Text = dgvDeaCust.Rows[rowIndex].Cells[1].Value.ToString();
            txtEmail.Text = dgvDeaCust.Rows[rowIndex].Cells[2].Value.ToString();
            txtContact.Text = dgvDeaCust.Rows[rowIndex].Cells[3].Value.ToString();
            txtAddress.Text = dgvDeaCust.Rows[rowIndex].Cells[4].Value.ToString();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            //Get the values from Form
            dc.DoctorsID = int.Parse(txtDoctorsID.Text);
            dc.Type = cmbType.Text;
            dc.DrName = txtName.Text;
            dc.Email = txtEmail.Text;
            dc.Contact = txtContact.Text;
            dc.Address = txtAddress.Text;
            dc.AddedDate = DateTime.Now;
            //Getting the ID to Logged in user and passign its value in dealer or cutomer module
            string loggedUsr = Login.loggedIn;
            UserBLL usr = uDal.GetIDFromUsername(loggedUsr);
            dc.AddedBy = usr.Id;

            //create boolean variable to check whether the dealer or customer is updated or not
            bool success = dcDal.Update(dc);

            if (success == true)
            {
                //Dealer and Customer update Successfully
                MessageBox.Show("Doctor updated Successfully");
                Clear();
                //Refresh the Data Grid View
                DataTable dt = dcDal.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                //Failed to udate Dealer or Customer
                MessageBox.Show("Failed to Udpate Doctor");
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            //Get the id of the user to be deleted from form
            dc.DoctorsID = int.Parse(txtDoctorsID.Text);

            //Create boolean variable to check wheteher the dealer or customer is deleted or not
            bool success = dcDal.Delete(dc);

            if (success == true)
            {
                //Dealer or Customer Deleted Successfully
                MessageBox.Show("Doctor Deleted Successfully");
                Clear();
                //Refresh the Data Grid View
                DataTable dt = dcDal.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                //Dealer or Customer Failed to Delete
                MessageBox.Show("Failed to Delete Doctor");
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            //Get the keyowrd from text box
            string keyword = txtSearch.Text;

            if (keyword != null)
            {
                //Search the Dealer or Customer
                DataTable dt = dcDal.Search(keyword);
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                //Show all the Dealer or Customer
                DataTable dt = dcDal.Select();
                dgvDeaCust.DataSource = dt;
            }
        }

        private void dgvDeaCust_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void DoctorsForm_Load(object sender, EventArgs e)
        {
            DataTable dt = dcDal.Select();
            dgvDeaCust.DataSource = dt;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {

        }
    }
}
