using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIThales.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            //List<Employee> employeesList;
            //employeesList = EmployeeBS.getInstance().EmployeesList();
            return View();
        }

        [HttpPost]
        public JsonResult EmployeesList(string type)
        {
            List<Employee> employeesList;
            if (type == "")
            {
                employeesList = EmployeeBS.getInstance().EmployeesList();
            }
            else
            {
                employeesList = null;
            }
            return Json(employeesList);
        }

        [HttpPost]
        public JsonResult Employee(string type)
        {
            Employee employee;
            if (type != "")
            {
                employee = EmployeeBS.getInstance().Employee(type);
            }
            else
            {
                employee = null;
            }
            return Json(employee);
        }
    }
}