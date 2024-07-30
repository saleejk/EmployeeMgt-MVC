namespace EmployeeLogin.Web.Models
{
    public interface IEmployeeServices
    {
         Task<string> AddEmployee(Employee emp);
    }
}
