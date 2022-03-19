using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EmployeeDT
    {
        public static string ruta = "http://dummy.restapiexample.com/api/v1/";

        #region "Instance"
        private static EmployeeDT objEmployeeDT = null;
        private EmployeeDT() { }
        public static EmployeeDT getInstance()
        {
            if (objEmployeeDT == null)
            {
                objEmployeeDT = new EmployeeDT();
            }
            return objEmployeeDT;
        }
        #endregion

        public void WriteLog(string Mensaje)
        {
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "Log_API";
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }

            string archivo = AppDomain.CurrentDomain.BaseDirectory + "Log_API\\Log_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(archivo))
            {
                using (StreamWriter log = File.CreateText(archivo))
                {
                    log.WriteLine("[" + DateTime.Now + "]  " + Mensaje);
                }
            }
            else
            {
                using (StreamWriter log = File.AppendText(archivo))
                {
                    log.WriteLine("[" + DateTime.Now + "]  " + Mensaje);
                }
            }
        }

        public List<Employee> EmployeesList()
        {
            List<Employee> employeesList = new List<Employee>();
            string url = ruta + "employees";
            var json = new WebClient().DownloadString(url);
            dynamic m = JsonConvert.DeserializeObject(json);
            foreach (var i in m.data)
            {
                string employeeId = i.id;
                string employeeName = i.employee_name;
                string employeeSalary = i.employee_salary;
                string employeeAge = i.employee_age;
                string profileImage = i.profile_image;
                if (profileImage == "")
                {
                    profileImage = "NoImage.png";
                }
                Employee objEmployee;
                objEmployee = new Employee
                {
                    employeeId = Convert.ToInt32(employeeId.Trim()),
                    employeeName = employeeName.Trim(),
                    employeeSalary = employeeSalary.Trim(),
                    employeeAge = Convert.ToInt32(employeeAge.Trim()),
                    profileImage = profileImage.Trim(),
                    employeeAnualSalary = "0",
                    error = Convert.ToBoolean(0)
                };
                employeesList.Add(objEmployee);
            }
            return employeesList;
        }

        public Employee Employee(string idSearch)
        {
            Employee employee = new Employee();
            string url = ruta + "employee/" + idSearch;
            var json = new WebClient().DownloadString(url);
            dynamic m = JsonConvert.DeserializeObject(json);
            string employeeId = m.data.id;
            string employeeName = m.data.employee_name;
            string employeeSalary = m.data.employee_salary;
            string employeeAge = m.data.employee_age;
            string profileImage = m.data.profile_image;
            if (profileImage == "")
            {
                profileImage = "NoImage.png";
            }
            employee = new Employee
            {
                employeeId = Convert.ToInt32(employeeId.Trim()),
                employeeName = employeeName.Trim(),
                employeeSalary = employeeSalary.Trim(),
                employeeAge = Convert.ToInt32(employeeAge.Trim()),
                profileImage = profileImage.Trim(),
                employeeAnualSalary = "0",
                error = Convert.ToBoolean(0)
            };
            return employee;
        }
    }
}
