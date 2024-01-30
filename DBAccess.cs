using System.Data.SqlClient;


namespace CRUDOperation_UsingSP
{
    internal class DBAccess
    {
        string connectionString = string.Empty;
        public DBAccess()
        {
            connectionString = "Data Source=LAPTOP-QIT9OAD4\\SQLEXPRESS;Initial Catalog=newDB;Integrated Security=True";
        }

        public void InsertEmployee(string? firstName, string? lastName, double salary)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    using (SqlCommand command = new SqlCommand("InsertEmployee", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Salary", salary);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Insert Error: {ex.Message}");
                }
            }
        }

        public void GetEmployee(int employeeID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    using (SqlCommand command = new SqlCommand("GetEmployee", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@EmployeeID", employeeID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"EmployeeID: {reader["EmployeeID"]}, FirstName: {reader["FirstName"]}, LastName: {reader["LastName"]}, Salary: {reader["Salary"]}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Select Error: {ex.Message}");
                }
            }
        }

        public void UpdateEmployee(int employeeID, string? firstName, string? lastName, double salary)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    using (SqlCommand command = new SqlCommand("UpdateEmployee", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@EmployeeID", employeeID);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Salary", salary);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Update Error: {ex.Message}");
                }
            }
        }

        public void DeleteEmployee(int employeeID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    using (SqlCommand command = new SqlCommand("DeleteEmployee", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@EmployeeID", employeeID);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Delete Error: {ex.Message}");
                }
            }
        }
    }
}
