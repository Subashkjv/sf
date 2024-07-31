using MVCSAMPLE.Models;
using System.Data;
using System.Data.SqlClient;


namespace UserSignupLogin.Models
{

    public class AppDBConnection
    {


        string ConnectionString = "Server=DEV8\\SQLEXPRESS;Database=DBuserSignupLogin;TrustServerCertificate=True;Trusted_Connection=True";

        public DataTable Dbcheck()
        {
            DataTable dataTable = new DataTable();
            try
            {

                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("CheckUser", con))
                    {                    
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {


            }

            return dataTable;
        }

        public bool DbEntry (UserModel query)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("SP_entry", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@SPUsernameUs", SqlDbType.VarChar, 20).Value = query.username ?? (object)DBNull.Value;
                        command.Parameters.Add("@SPPasswordUs", SqlDbType.VarChar, 20).Value = query.Password ?? (object)DBNull.Value;
                        command.ExecuteNonQuery();

                    }
                    con.Close();
                }

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

    }

}
