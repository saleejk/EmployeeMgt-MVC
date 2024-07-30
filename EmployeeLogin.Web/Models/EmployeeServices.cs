using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace EmployeeLogin.Web.Models
{
    public class EmployeeServices:IEmployeeServices
    {
        public readonly string connectionString;
        public EmployeeServices(IConfiguration _config) {
            connectionString = _config["ConnectionStrings:DefaultConnection"];
        }
        public async Task<string> AddEmployee(Employee emp)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "insert into employee values(@name,@salary,@department,@role)";
              await connection.ExecuteAsync(sql, emp);
            }
            return "Posted Successfull";
        }

    }
}
