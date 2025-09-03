using System.Data;
using Microsoft.Data.SqlClient; 



namespace DataLayer
{
    public class Operations
    {
        // Corrected connection string
        public string connectionString = "Your DB string here"; 


        // Method for executing an INSERT, UPDATE, or DELETE query

        public int ExecuteProcedureIUD(string procName, SqlParameter[] parameters)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(procName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                        {
                            foreach (SqlParameter param in parameters)
                            {
                                cmd.Parameters.Add(param);
                            }
                        }

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine("An error occurred: " + ex.Message);
                // Optionally, rethrow or handle the exception based on your requirements
            }

            return rowsAffected;
        }

        public DataTable ExecuteProcedureSelect(string procedureName, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                try
                {
                    connection.Open();
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {

                    throw new Exception("Error executing stored procedure", ex);
                }
                finally
                {
                    connection.Close();
                }
            }

            return dt;
        }

        public bool ExecuteProcedureUpdate(string procedureName, SqlParameter[] parameters)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    success = rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Handle the exception (log it, throw it, etc.)
                    throw new Exception("Error executing stored procedure for update", ex);
                }
                finally
                {
                    connection.Close();
                }
            }

            return success;
        }




        public DataTable GetData(string StoredProcedure)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(StoredProcedure, connection))
                {
                    command.CommandType = CommandType.Text; // Indicate that this is a raw SQL query


                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }



    }


}



