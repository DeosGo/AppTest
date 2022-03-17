using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIThales.Controllers
{
    public class EmployeeAPIController : ApiController
    {
        [HttpGet]
        public IHttpActionResult add(string value="") {
            if (value != "")
            {
                Employee employee;
                employee = EmployeeBS.getInstance().Employee(value);
                return Json(employee);
            }
            else
            {
                List<Employee> employeesList;
                employeesList = EmployeeBS.getInstance().EmployeesList();
                return Json(employeesList);
            }
        }
    }
}
