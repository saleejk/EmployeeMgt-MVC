using Dapper;
using Microsoft.Data.SqlClient;
using Serilog;
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
                string sql = "insert into employee values(@name,@email,@department,@role,@password)";
              await connection.ExecuteAsync(sql, emp);
            }
            return "Posted Successfull";
        }
        public async Task<List<Employee>> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "select * from employee";
                var std=connection.Query<Employee>(sql);
                return std.ToList();
            }
        }
        //public async Task<Employee>LogIn(LoginDto login)
        //{
        //    using(SqlConnection connection=new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string sql = $"select * from employee where email={login.Email}";
        //       var employee= await connection.QueryFirstOrDefaultAsync<Employee>(sql);
        //        return employee;
        //    }
        //}
        public async Task<Employee> LogIn(LoginDto login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Log.Information("Iam at service");
                string sql = "SELECT * FROM employee WHERE email = @email";
                Log.Information(sql);
                var employee = await connection.QueryFirstOrDefaultAsync<Employee>(sql, new { email = login.Email });
                Log.Information(employee + "kkklll");
                return  employee;
            }
        }



    }
}
