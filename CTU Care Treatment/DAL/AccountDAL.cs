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
    class AccountDAL
    {
        //Creating STATIC String Method for DB Connection
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select method for Patients Module
        public DataTable Select()
        {
            //Create Sql Connection to connect Databaes
            SqlConnection conn = new SqlConnection(myconnstrng);

            //DataTable to hold the data from database
            DataTable dt = new DataTable();

            try
            {
                //Writing the Query to Select data from database
                String sql = "SELECT * FROM tbl_Account";

                //Creating SQL Command to Execute Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //SQL Data Adapter to hold the value from database temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
                conn.Open();

                adapter.Fill(dt);
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
        #region Method to Insert Patients in database
        public bool Insert(AccountBLL p)
        {
            //Creating Boolean Variable and set its default value to false
            bool isSuccess = false;

            //Sql Connection for Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL Query to insert Patients into database
                String sql = "INSERT INTO tbl_Account (FileNumber, Id, PrescriptionID, AdmissionFee, AccommodationFee, PrescriptionFee, Total, Date ) VALUES (@FileNumber, @Id, @PrescriptionID, @AdmissionFee, @AccommodationFee, @PrescriptionFee, @Total, @Date )";

                //Creating SQL Command to pass the values
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passign the values through parameters
                cmd.Parameters.AddWithValue("@FileNumber", p.FileNumber);
                cmd.Parameters.AddWithValue("@Id", p.Id);
                cmd.Parameters.AddWithValue("@PrescriptionID", p.PrescriptionID);
                cmd.Parameters.AddWithValue("@AdmissionFee", p.AdmissionFee);
                cmd.Parameters.AddWithValue("@AccommodationFee", p.AccommodationFee);
                cmd.Parameters.AddWithValue("@PrescriptionFee", p.PrescriptionFee);
                cmd.Parameters.AddWithValue("@Total", p.Total);
                cmd.Parameters.AddWithValue("@Date", p.Date);


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

        #region SEARCH METHOD for Dealer and Customer Module
        public DataTable Search(string keyword)
        {
            //Create a Sql Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Creating a Data TAble and returnign its value
            DataTable dt = new DataTable();

            try
            {
                //Write the Query to Search Dealer or Customer Based in id, type and name
                string sql = "SELECT * FROM tbl_Account WHERE PrescriptionID LIKE '%" + keyword + "%' OR Type LIKE '%" + keyword + "%' OR PrescriptionID LIKE '%" + keyword + "%'";

                //Sql Command to Execute the Query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Sql Dat Adapeter to hold tthe data from dataase temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open DAta Base Connection
                conn.Open();
                //Pass the value from adapter to data table
                adapter.Fill(dt);
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
    }

}
