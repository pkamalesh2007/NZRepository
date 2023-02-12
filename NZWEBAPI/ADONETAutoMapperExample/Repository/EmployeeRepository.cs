using ADONETAutoMapperExample.Models.Domain;
using Microsoft.Data.SqlClient;

namespace ADONETAutoMapperExample.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT EmployeeId, FirstName, LastName, Email, PhoneNumber FROM Employee", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Employee emp = new Employee
                        {

                            
                            EmployeeId = reader["EmployeeId"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString()
                        };

                        employees.Add(emp);
                    }

                    return employees;



                    
                }
            }

            
        
        }

    }
}
