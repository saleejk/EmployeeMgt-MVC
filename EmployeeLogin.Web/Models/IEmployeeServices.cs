namespace EmployeeLogin.Web.Models
{
    public interface IEmployeeServices
    {
         Task<string> AddEmployee(Employee emp);
        Task<List<Employee>> GetAll();
        Task<Employee> LogIn(LoginDto login);


    }
}
