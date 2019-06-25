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
    public partial class PatientsForm : Form
    {
        public PatientsForm()
        {
            InitializeComponent();
        }
        //Creating BLL and DAL objects for accessing their properties
        PatientsDAL cdal = new PatientsDAL();
        PatientsBLL p = new PatientsBLL();
        UserDAL dal = new UserDAL();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get all the values from form
            p.FirstName = txtName.Text;
            p.LastName = txtLastName.Text;
            p.IdNumber = txtIdNumber.Text;
            p.Gender = cmbCategory.Text;
            p.Contact = txtMedicalAid.Text;
            p.AddedDate = DateTime.Now;
            p.AddedBy = 1;
            p.Email = txtEmail.Text;
            p.Address = txtAddress.Text;
            p.Description = txtDescription.Text;
            //Geeting username of logged in user
            String loogedUser = Login.loggedIn;
            UserBLL usr = dal.GetIDFromUsername(loogedUser);

            p.AddedBy = usr.Id;

            //Boolean variable to check if the data has been successfully added
            bool success = cdal.Insert(p);
            //if the data is successfully added then the value of success will be true else it will be false
            if (success == true)
            {
                //data inserted successfully
                MessageBox.Show("Patient Added");
                //Cleaaring all textboxes
                Clear();
                //Refreshing dataGridview
                DataTable dt = cdal.Select();
                dgvPatients.DataSource = dt;
            }
            else
            {
                //failed to add data
                MessageBox.Show("Failed to add patient");
            }
        }
        public void Clear()
        {
             txtName.Text = "";
             txtLastName.Text="";
             txtIdNumber.Text="";
             cmbCategory.Text="";
             txtMedicalAid.Text="";
             txtAddedBy.Text="";
             txtEmail.Text="";
             txtAddress.Text="";
             txtDate.Text = "";
             cmbCategory.Text = "";
            txtDescription.Text = "";

        }

        private void dgvPatients_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of particular row
            int rowIndex = e.RowIndex;
            txtID.Text = dgvPatients.Rows[rowIndex].Cells[0].Value.ToString();
            txtName.Text = dgvPatients.Rows[rowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvPatients.Rows[rowIndex].Cells[2].Value.ToString();
            txtIdNumber.Text = dgvPatients.Rows[rowIndex].Cells[3].Value.ToString();
            cmbCategory.Text = dgvPatients.Rows[rowIndex].Cells[4].Value.ToString();
            txtMedicalAid.Text = dgvPatients.Rows[rowIndex].Cells[5].Value.ToString();
            txtDate.Text = dgvPatients.Rows[rowIndex].Cells[6].Value.ToString();
            txtAddedBy.Text = dgvPatients.Rows[rowIndex].Cells[7].Value.ToString();
            txtEmail.Text = dgvPatients.Rows[rowIndex].Cells[8].Value.ToString();
            txtAddress.Text = dgvPatients.Rows[rowIndex].Cells[9].Value.ToString();
            txtDescription.Text = dgvPatients.Rows[rowIndex].Cells[10].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get all the values from form
            p.FirstName = txtName.Text;
            p.LastName = txtLastName.Text;
            p.IdNumber = txtIdNumber.Text;
            p.Gender = cmbCategory.Text;
            p.Contact = txtMedicalAid.Text;
            p.AddedDate = DateTime.Now;
            p.AddedBy = 1;
            p.Email = txtEmail.Text;
            p.Address = txtAddress.Text;
            p.Description = txtDescription.Text;

            //Updating Data into database
            bool success = cdal.Update(p);
            //if data is updated successfully then the value of success will be true else it will be false
            if (success == true)
            {
                //Data Updated Successfully
                MessageBox.Show("Patient successfully updated");
                Clear();
            }
            else
            {
                //failed to update Patient
                MessageBox.Show("Failed to update Patient");
            }
            //Refreshing Data Grid View
            DataTable dt = cdal.Select();
            dgvPatients.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Getting User ID from Form
            p.FileNumber = Convert.ToInt32(txtID.Text);

            bool success = cdal.Delete(p);
            //if data is deleted then the value of success will be true else it will be false
            if (success == true)
            {
                //User Deleted Successfully 
                MessageBox.Show("Patients deleted successfully");
                Clear();
            }
            else
            {
                //Failed to Delete User
                MessageBox.Show("Failed to delete Patients");

            }
            //refreshing Datagrid view
            DataTable dt = cdal.Select();
            dgvPatients.DataSource = dt;
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
                dgvPatients.DataSource = dt;
            }
            else
            {
                //show all users from the database
                DataTable dt = cdal.Select();
                dgvPatients.DataSource = dt;
            }
        }

        private void PatientsForm_Load(object sender, EventArgs e)
        {
            DataTable dt = cdal.Select();
            dgvPatients.DataSource = dt;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
