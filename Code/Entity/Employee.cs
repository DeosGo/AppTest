using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Employee
    {
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public string employeeSalary { get; set; }
        public int employeeAge { get; set; }
        public string profileImage { get; set; }
        public string employeeAnualSalary { get; set; }
        public bool error { get; set; }
        public string errorMessage { get; set; }
        public Employee() { }
        public Employee(int employeeId, string employeeName, string employeeSalary, int employeeAge, string profileImage, string employeeAnualSalary, bool error, string errorMessage)
        {
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.employeeSalary = employeeSalary;
            this.employeeAge = employeeAge;
            this.profileImage = profileImage;
            this.employeeAnualSalary = employeeAnualSalary;
            this.error = error;
            this.errorMessage = errorMessage;
        }
    }
}
