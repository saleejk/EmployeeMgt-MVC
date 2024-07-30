namespace EmployeeLogin.Web.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary {  get; set; }
        public string Department {  get; set; }
        public string Role { get; set; } = "user";

    }
    public class EmployeeDto
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }

    }
}
