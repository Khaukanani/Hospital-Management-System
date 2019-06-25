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
    class AppointmentDAL
    {
        //Creating STATIC String Method for DB Connection
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select method for Product Module
        public DataTable Select()
        {
            //Create Sql Connection to connect Databaes
            SqlConnection conn = new SqlConnection(myconnstrng);

            //DataTable to hold the data from database
            DataTable dt = new DataTable();

            try
            {
                //Writing the Query to Select data from database
                String sql = "SELECT * FROM tbl_Appointment";

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
        public bool Insert(AppointmentBLL p)
        {
            //Creating Boolean Variable and set its default value to false
            bool isSuccess = false;

            //Sql Connection for Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL Query to insert Patients into database
                String sql = "INSERT INTO tbl_Appointment (FirstName, LastName, IdNumber, Gender, Contact, AddedDate, Reason, Email, Address ) VALUES (@FirstName, @LastName, @IdNumber, @Gender, @Contact, @AddedDate, @Reason, @Email, @Address)";

                //Creating SQL Command to pass the values
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passign the values through parameters
                cmd.Parameters.AddWithValue("@FirstName", p.FirstName);
                cmd.Parameters.AddWithValue("@LastName", p.LastName);
                cmd.Parameters.AddWithValue("@IdNumber", p.IdNumber);
                cmd.Parameters.AddWithValue("@Gender", p.Gender);
                cmd.Parameters.AddWithValue("@Contact", p.Contact);
                cmd.Parameters.AddWithValue("@AddedDate", p.AddedDate);
                cmd.Parameters.AddWithValue("@Reason", p.Reason);
                cmd.Parameters.AddWithValue("@Email", p.Email);
                cmd.Parameters.AddWithValue("@Address", p.Address);

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
