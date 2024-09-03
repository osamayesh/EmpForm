using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace EmpForm.Model
{
    public class EmployeeDAL
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["EmpConnection"].ConnectionString;

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Employee", con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee emp = new Employee
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            EmpNumber = Convert.ToInt32(reader["EmpNumber"]),
                            EmpName = reader["EmpName"].ToString(),
                            Position = reader["Position"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Date_of_birth = Convert.ToDateTime(reader["Date_of_birth"]),

                            Salary = Convert.ToDecimal(reader["Salary"])
                        };
                        employees.Add(emp);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (e.g., using a logging framework)
                throw new ApplicationException("An error occurred while fetching employees.", ex);
            }
            return employees;
        }
        //create method 

        public int AddEmp(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
     
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Employee (EmpNumber, EmpName, Gender, Date_of_birth, Position, Salary) VALUES (@EmpNumber, @EmpName, @Gender, @Date_of_birth, @Position, @Salary)", con);

                cmd.Parameters.AddWithValue("@EmpNumber", emp.EmpNumber);
                cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Date_of_birth",emp.Date_of_birth);
                cmd.Parameters.AddWithValue("@Position", emp.Position);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);

                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        //update method 
        public void UpdateEmp(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Employee SET EmpNumber = @EmpNumber, EmpName = @EmpName, Gender = @Gender, Date_of_birth = @Date_of_birth, Position = @Position, Salary = @Salary WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@EmpNumber", emp.EmpNumber);
                cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Date_of_birth", emp.Date_of_birth);
                cmd.Parameters.AddWithValue("@Position",    emp.Position);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

       //Delete method 

        public void DeleteEmp(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Employee WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Employee> SearchEmployees(string empName, int? empNumber, int? empId, decimal? salary)
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Id, EmpNumber, EmpName, Gender, Date_of_birth, Position, Salary " +
                    "FROM Employee " +
                    "WHERE (@EmpName IS NULL OR EmpName LIKE '%' + @EmpName + '%') " +
                    "AND (@EmpNumber IS NULL OR EmpNumber = @EmpNumber) " +
                    "AND (@EmpId IS NULL OR Id = @EmpId) " +
                    "AND (@Salary IS NULL OR Salary = @Salary)",
                    con);

                // Set parameters
                cmd.Parameters.AddWithValue("@EmpName", string.IsNullOrEmpty(empName) ? (object)DBNull.Value : empName);
                cmd.Parameters.AddWithValue("@EmpNumber", empNumber.HasValue ? (object)empNumber.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@EmpId", empId.HasValue ? (object)empId.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Salary", salary.HasValue ? (object)salary.Value : DBNull.Value);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Read results
                while (reader.Read())
                {
                    Employee emp = new Employee
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        EmpNumber = Convert.ToInt32(reader["EmpNumber"]),
                        EmpName = reader["EmpName"].ToString(),
                        Position = reader["Position"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        Date_of_birth = DateTime.Parse(reader["Date_of_birth"].ToString()).Date,
                        Salary = Convert.ToDecimal(reader["Salary"])
                    };
                    employees.Add(emp);
                }
            }

            return employees;
        }
    }
}
