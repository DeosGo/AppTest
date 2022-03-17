using Business;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmployeeNameTest()
        {
            Employee employeeTest= EmployeeBS.getInstance().Employee("5");
            string employeeName = "Airi Satou";
            Assert.AreEqual(employeeName,employeeTest.employeeName);
        }

        [TestMethod]
        public void AnualSalaryComputeTest()
        {
            Employee employeeTest = EmployeeBS.getInstance().Employee("5");
            string employeeAnualSalary = (162700*12).ToString("C");
            Assert.AreEqual(employeeAnualSalary, employeeTest.employeeAnualSalary);
        }
    }
}
