using EmployeeLogin.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace EmployeeLogin.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly IEmployeeServices employeeServices;
        public EmployeeController(IEmployeeServices emp)
        {
            employeeServices = emp;
        }
        public IActionResult Add() 
        {
            return View();
        }
        public async Task<IActionResult> AddEmpLoyee(Employee emp)
        {
           await employeeServices.AddEmployee(emp);
            return RedirectToAction("Add", "Employee");
        }
    }
}
