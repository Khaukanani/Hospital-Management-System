using CTU_Care_Treatment.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTU_Care_Treatment.DAL
{
    class HistoryDAL
    {
        //Creating STATIC String Method for DB Connection
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select method for History Module
        public DataTable Select()
        {
            //Create Sql Connection to connect Databaes
            SqlConnection conn = new SqlConnection(myconnstrng);

            //DataTable to hold the data from database
            DataTable dt = new DataTable();

            try
            {
                //Writing the Query to Select data from database
                String sql = "SELECT tbl_Patients.FirstName, tbl_Patients.LastName, tbl_Patients.FileNumber, tbl_Patients.Description, tbl_Admssion.DateAdmitted, tbl_Prescription.Prescribed, tbl_Account.PrescriptionFee, tbl_Account.Total, tbl_Doctors.DrName FROM tbl_Patients, tbl_Account, tbl_Prescription, tbl_Admssion, tbl_Doctors ";

                //Creating SQL Command to Execute Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //SQL Data Adapter to hold the value from database temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
                conn.Open();

                adapter.Fill(dt);//all the data is saved in this (dt)
                /*
                 * I must find a way to extract the dt and filter only important information
                 * for history and then display the filtered information on the datagridview.
                 */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        #endregion
        #region Method to Insert Histroy in database
        public bool Insert(HistoryBLL p)
        {
            //Creating Boolean Variable and set its default value to false
            bool isSuccess = false;

            //Sql Connection for Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL Query to insert Patients into database
                String sql = "INSERT INTO tbl_History (FileNumber, AppointmentID, AdmissionID, AccountID, PrescriptionID) VALUES (@FileNumber, @AppointmentID, @AdmissionID, @AccountID, @PrescriptionID)";

                //Creating SQL Command to pass the values
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passign the values through parameters
                cmd.Parameters.AddWithValue("@FileNumber", p.FileNumber);
                cmd.Parameters.AddWithValue("@AppointmentID", p.AppointmentID);
                cmd.Parameters.AddWithValue("@AdmissionID", p.AdmissionID);
                cmd.Parameters.AddWithValue("@AccountID", p.AccountID);
                cmd.Parameters.AddWithValue("@PrescriptionID", p.PrescriptionID);

                //Opening the Database connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //If the query is executed successfully then the value of rows will be greater than 0 else it will be less than 0
                if (rows > 0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                }
                else
                {
                    //Failed to Execute Query
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        #endregion
    }
}
