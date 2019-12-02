using EntityFrameworkCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEmployees()
        {
            var employees = EmployeeRepository.GetEmployees();
            return Json(employees);
        }

        public ActionResult GetEmployee(int Id)
        {
            var employee = EmployeeRepository.GetEmployee(Id);
            return Json(employee);
        }

        public ActionResult CreateEmployee(Employee model)
        {
            var msg = EmployeeRepository.CreateEmployee(model);

            return Json(msg);
        }

        public ActionResult UpdateEmployee(Employee model)
        {
            var msg = EmployeeRepository.UpdateEmployee(model);

            return Json(msg);
        }

        public ActionResult DeleteEmployee(int Id)
        {
            var employee = EmployeeRepository.DeleteEmployee(Id);
            return Json(employee);
        }
    }
}