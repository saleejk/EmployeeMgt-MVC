namespace EmployeeLogin.Web.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email {  get; set; }
        public string Department {  get; set; }
        public string Role { get; set; } = "user";
        public string Password { get; set; }


    }
    public class EmployeeDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public string Password {  get; set; }
    }
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
