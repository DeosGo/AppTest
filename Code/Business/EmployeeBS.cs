using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EmployeeBS
    {
        #region "Instancia"
        private static EmployeeBS objEmployeeBS = null;
        private EmployeeBS() { }
        public static EmployeeBS getInstance()
        {
            if (objEmployeeBS == null)
            {
                objEmployeeBS = new EmployeeBS();
            }
            return objEmployeeBS;
        }
        #endregion

        public List<Employee> EmployeesList()
        {
            WriteLog("API consumption started http://dummy.restapiexample.com/api/v1/employees");
            try
            {
                WriteLog("Successful Consumption http://dummy.restapiexample.com/api/v1/employees");
                return EmployeesAnualSalary(EmployeeDT.getInstance().EmployeesList());
            }
            catch (Exception ex)
            {
                WriteLog("error in consumption: " + ex.Message + " http://dummy.restapiexample.com/api/v1/employees");
                List<Employee> error = new List<Employee>();
                error.Add(new Employee { error = Convert.ToBoolean(1), errorMessage = ex.Message });
                return error;
            }
        }

        public List<Employee> EmployeesAnualSalary(List<Employee> employeesList)
        {
            foreach (var i in employeesList)
            {
                i.employeeAnualSalary = (Convert.ToInt32(i.employeeSalary) * 12).ToString("C");
                i.employeeSalary = Convert.ToInt32(i.employeeSalary).ToString("C");
                i.employeeSalary = i.employeeSalary.Replace("$", "$ ");
            }
            return employeesList;
        }

        public Employee EmployeeAnualSalary(Employee employee)
        {
            employee.employeeAnualSalary = (Convert.ToInt32(employee.employeeSalary) * 12).ToString("C");
            employee.employeeSalary = Convert.ToInt32(employee.employeeSalary).ToString("C");
            employee.employeeSalary = employee.employeeSalary.Replace("$", "$ ");
            return employee;
        }
        public Employee Employee(string idSearch)
        {
            WriteLog("API consumption started http://dummy.restapiexample.com/api/v1/employee/");
            try
            {
                WriteLog("Successful Consumption http://dummy.restapiexample.com/api/v1/employee/");
                return EmployeeAnualSalary(EmployeeDT.getInstance().Employee(idSearch));
            }
            catch (Exception ex)
            {
                WriteLog("error in consumption: " + ex.Message + " http://dummy.restapiexample.com/api/v1/employee/");
                Employee error;
                error = new Employee { error = Convert.ToBoolean(1), errorMessage = ex.Message };
                return error;
            }
        }
        public void WriteLog(string Mensaje)
        {
            try
            {
                EmployeeDT.getInstance().WriteLog(Mensaje);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
