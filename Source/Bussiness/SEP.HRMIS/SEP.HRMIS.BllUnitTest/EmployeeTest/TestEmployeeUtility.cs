using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.EmployeeTest
{
    [TestFixture]
    public class TestEmployeeUtility
    {
        private string _Name;

        [Test]
        public void Test()
        {
            List<Employee> list = new List<Employee>();

            list.Add(new Employee(new Account(1, "1", "1"), "", "", EmployeeTypeEnum.All, null, null));
            list.Add(new Employee(new Account(2, "2", "2"), "", "", EmployeeTypeEnum.All, null, null));
            list.Add(new Employee(new Account(3, "3", "3"), "", "", EmployeeTypeEnum.All, null, null));
            list.Add(new Employee(new Account(4, "4", "4"), "", "", EmployeeTypeEnum.All, null, null));
            list.Add(new Employee(new Account(5, "5", "5"), "", "", EmployeeTypeEnum.All, null, null));

            _Name = "1";

            Employee employee = list.Find(FindEmployee);
        }


        private bool FindEmployee(Employee employee)
        {
            return employee.Account.Name == _Name;
        }
    }
}
