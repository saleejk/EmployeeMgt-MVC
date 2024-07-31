using EmployeeLogin.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Serilog;
using Serilog.Core;

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
            return RedirectToAction("GetAll", "Employee");
        }
        public async Task<IActionResult> GetAll()
        { 
            var std=await employeeServices.GetAll();
            return View(std);
        }
        public async Task<IActionResult> LogInn()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginDto login)
        {
            login.Password = "12345678";
            Log.Error("hello guyzz");
            var employee = await employeeServices.LogIn(login);
            //if (employee != null)
            //{
            return RedirectToAction("LogInn", "Employee");
            //}
            //else
            //{
            //    return BadRequest();
            //}

        }
    }
}
