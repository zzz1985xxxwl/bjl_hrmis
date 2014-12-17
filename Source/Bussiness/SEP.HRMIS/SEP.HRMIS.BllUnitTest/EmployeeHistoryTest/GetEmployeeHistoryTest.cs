//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetEmployeeHistoryTest.cs
// 创建者: 杨俞彬
// 创建日期: 2008-12-1
// 概述: GetEmployeeHistory测试
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest.EmployeeHistoryTest
{
    [TestFixture]
    public class GetEmployeeHistoryTest
    {
        private MockRepository _Mocks;
        private IDepartmentHistory _IDepartmentHistory; 
        private GetDepartmentHistory _GetDepartmentHistory;
        private IEmployeeHistory _IEmployeeHistory;
        private IPositionHistory _IPositionHistory;
        private GetEmployeeHistory _Target;

        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            _IDepartmentHistory = (IDepartmentHistory)_Mocks.CreateMock(typeof(IDepartmentHistory));
            _IPositionHistory = (IPositionHistory)_Mocks.CreateMock(typeof(IPositionHistory));
            _IEmployeeHistory = (IEmployeeHistory)_Mocks.DynamicMock(typeof(IEmployeeHistory));
            _GetDepartmentHistory = new GetDepartmentHistory(_IDepartmentHistory);
            _Target = new GetEmployeeHistory(_IEmployeeHistory);
            _Target.MockGetDepartmentHistory = _GetDepartmentHistory;
            _Target.MockPositionHistroy = _IPositionHistory;
        }

        [Test, Description("GetEmployeeHistoryByEmployeeHistoryID")]
        public void GetEmployeeHistoryByEmployeeHistoryIDTest()
        {
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryByEmployeeHistoryID(1)).Return(null);
            _Mocks.ReplayAll();
            _Target.GetEmployeeHistoryByEmployeeHistoryID(1);
            _Mocks.VerifyAll();
        }
        [Test, Description("GetEmployeeHistoryBasicInfoByEmployeeHistoryID")]
        public void GetEmployeeHistoryBasicInfoByEmployeeHistoryIDTest()
        {
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByEmployeeHistoryID(1)).Return(null);
            _Mocks.ReplayAll();
            _Target.GetEmployeeHistoryBasicInfoByEmployeeHistoryID(1);
            _Mocks.VerifyAll();
        }
        [Test, Description("GetEmployeeHistoryByAccountID")]
        public void GetEmployeeHistoryByAccountIDTest()
        {
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryByAccountID(1)).Return(null);
            _Mocks.ReplayAll();
            _Target.GetEmployeeHistoryByAccountID(1);
            _Mocks.VerifyAll();
        }
        [Test, Description("GetEmployeeHistoryBasicInfoByAccountID")]
        public void GetEmployeeHistoryBasicInfoByAccountIDTest()
        {
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByAccountID(1)).Return(null);
            _Mocks.ReplayAll();
            _Target.GetEmployeeHistoryBasicInfoByAccountID(1);
            _Mocks.VerifyAll();
        }
        [Test, Description("GetOnDutyEmployeeBasicInfoByDateTime")]
        public void GetOnDutyEmployeeBasicInfoByDateTimeTest1()
        {
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(DateTime.Now.Date)).Return(new List<EmployeeHistory>());
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList = _Target.GetOnDutyEmployeeBasicInfoByDateTime(DateTime.Now.Date);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualEmployeeList.Count, 0);
        }
        [Test, Description("GetOnDutyEmployeeBasicInfoByDateTime")]
        public void GetOnDutyEmployeeBasicInfoByDateTimeTest2()
        {
            List<EmployeeHistory> employeeHistoryList = new List<EmployeeHistory>();
            employeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
            employeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
            employeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
            employeeHistoryList[0].Employee = new Employee(1, EmployeeTypeEnum.BorrowedEmployee);
            employeeHistoryList[0].Employee.EmployeeDetails = new EmployeeDetails();
            employeeHistoryList[0].Employee.EmployeeDetails.Work = new Work();
            employeeHistoryList[0].Employee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo();
            employeeHistoryList[1].Employee = new Employee(2, EmployeeTypeEnum.DimissionEmployee);
            employeeHistoryList[1].Employee.EmployeeDetails = new EmployeeDetails();
            employeeHistoryList[1].Employee.EmployeeDetails.Work = new Work();
            employeeHistoryList[1].Employee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo();
            employeeHistoryList[1].Employee.EmployeeDetails.Work.DimissionInfo.DimissionDate =
                DateTime.Now.Date.AddDays(-1);
            employeeHistoryList[2].Employee = new Employee(3, EmployeeTypeEnum.PartTimeEmployee);
            employeeHistoryList[2].Employee.EmployeeDetails = new EmployeeDetails();
            employeeHistoryList[2].Employee.EmployeeDetails.Work = new Work();
            employeeHistoryList[2].Employee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo();
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(DateTime.Now.Date)).Return(employeeHistoryList);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList = _Target.GetOnDutyEmployeeBasicInfoByDateTime(DateTime.Now.Date);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualEmployeeList.Count, 2);
            Assert.AreNotEqual(actualEmployeeList[0].EmployeeType, EmployeeTypeEnum.DimissionEmployee);
            Assert.AreNotEqual(actualEmployeeList[1].EmployeeType, EmployeeTypeEnum.DimissionEmployee);
        }
        [Test, Description("GetOnDutyEmployeeBasicInfoByDateTimeAndCompany")]
        public void GetOnDutyEmployeeBasicInfoByDateTimeAndCompanyTest1()
        {
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(DateTime.Now.Date)).Return(new List<EmployeeHistory>());
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList = _Target.GetOnDutyEmployeeBasicInfoByDateTimeAndCompany(DateTime.Now.Date, 1);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualEmployeeList.Count, 0);
        }
        [Test, Description("GetOnDutyEmployeeBasicInfoByDateTimeAndCompany")]
        public void GetOnDutyEmployeeBasicInfoByDateTimeAndCompanyTest2()
        {
            List<EmployeeHistory> employeeHistoryList = new List<EmployeeHistory>();
            employeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
            employeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
            employeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
            employeeHistoryList[0].Employee = new Employee(1, EmployeeTypeEnum.BorrowedEmployee);
            employeeHistoryList[0].Employee.EmployeeDetails = new EmployeeDetails();
            employeeHistoryList[0].Employee.EmployeeDetails.Work = new Work();
            employeeHistoryList[0].Employee.EmployeeDetails.Work.Company = new Department(1, "");
            employeeHistoryList[1].Employee = new Employee(2, EmployeeTypeEnum.DimissionEmployee);
            employeeHistoryList[1].Employee.EmployeeDetails = new EmployeeDetails();
            employeeHistoryList[1].Employee.EmployeeDetails.Work = new Work();
            employeeHistoryList[1].Employee.EmployeeDetails.Work.Company = new Department(2, "");
            employeeHistoryList[2].Employee = new Employee(3, EmployeeTypeEnum.PartTimeEmployee);
            employeeHistoryList[2].Employee.EmployeeDetails = new EmployeeDetails();
            employeeHistoryList[2].Employee.EmployeeDetails.Work = new Work();
            employeeHistoryList[2].Employee.EmployeeDetails.Work.Company = new Department(3, "");
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(DateTime.Now.Date)).Return(employeeHistoryList);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList = _Target.GetOnDutyEmployeeBasicInfoByDateTimeAndCompany(DateTime.Now.Date, 1);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualEmployeeList.Count, 1);
            Assert.AreNotEqual(actualEmployeeList[0].EmployeeType, EmployeeTypeEnum.DimissionEmployee);
            Assert.AreEqual(actualEmployeeList[0].EmployeeDetails.Work.Company.Id, 1);
        }
        [Test, Description("GetOnDutyEmployeeBasicInfoByDateTimeAndCompany")]
        public void GetOnDutyEmployeeBasicInfoByDateTimeAndCompanyTest3()
        {
            List<EmployeeHistory> employeeHistoryList = new List<EmployeeHistory>();
            employeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
            employeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
            employeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
            employeeHistoryList[0].Employee = new Employee(1, EmployeeTypeEnum.BorrowedEmployee);
            employeeHistoryList[0].Employee.EmployeeDetails = new EmployeeDetails();
            employeeHistoryList[0].Employee.EmployeeDetails.Work = new Work();
            employeeHistoryList[0].Employee.EmployeeDetails.Work.Company = new Department(1, "");
            employeeHistoryList[1].Employee = new Employee(2, EmployeeTypeEnum.DimissionEmployee);
            employeeHistoryList[1].Employee.EmployeeDetails = new EmployeeDetails();
            employeeHistoryList[1].Employee.EmployeeDetails.Work = new Work();
            employeeHistoryList[1].Employee.EmployeeDetails.Work.Company = new Department(2, "");
            employeeHistoryList[1].Employee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo();
            employeeHistoryList[1].Employee.EmployeeDetails.Work.DimissionInfo.DimissionDate =
                DateTime.Now.Date.AddDays(-1);
            employeeHistoryList[2].Employee = new Employee(3, EmployeeTypeEnum.PartTimeEmployee);
            employeeHistoryList[2].Employee.EmployeeDetails = new EmployeeDetails();
            employeeHistoryList[2].Employee.EmployeeDetails.Work = new Work();
            employeeHistoryList[2].Employee.EmployeeDetails.Work.Company = new Department(3, "");
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(DateTime.Now.Date)).Return(employeeHistoryList);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList = _Target.GetOnDutyEmployeeBasicInfoByDateTimeAndCompany(DateTime.Now.Date, -1);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualEmployeeList.Count, 2);
            Assert.AreNotEqual(actualEmployeeList[0].EmployeeType, EmployeeTypeEnum.DimissionEmployee);
            Assert.AreEqual(actualEmployeeList[0].EmployeeDetails.Work.Company.Id, 1);
            Assert.AreNotEqual(actualEmployeeList[1].EmployeeType, EmployeeTypeEnum.DimissionEmployee);
            Assert.AreEqual(actualEmployeeList[1].EmployeeDetails.Work.Company.Id, 3);
        }
        [Test, Description("GetEmployeeBasicInfoByDepartmentAndDateTime")]
        public void GetEmployeeBasicInfoByDepartmentAndDateTimeTest1()
        {
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(1, DateTime.Now.Date)).Return(new List<EmployeeHistory>());
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList = _Target.GetEmployeeBasicInfoByDepartmentAndDateTime(1, DateTime.Now.Date);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualEmployeeList.Count, 0);
        }
        [Test, Description("GetEmployeeBasicInfoByDepartmentAndDateTime")]
        public void GetEmployeeBasicInfoByDepartmentAndDateTimeTest2()
        {
            List<EmployeeHistory> employeeHistoryList = new List<EmployeeHistory>();
            employeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
            employeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
            employeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
            employeeHistoryList[0].Employee = new Employee(1, EmployeeTypeEnum.BorrowedEmployee);
            employeeHistoryList[0].Employee.EmployeeDetails = new EmployeeDetails();
            employeeHistoryList[0].Employee.EmployeeDetails.Work = new Work();
            employeeHistoryList[0].Employee.EmployeeDetails.Work.Company = new Department(1, "");
            employeeHistoryList[1].Employee = new Employee(2, EmployeeTypeEnum.DimissionEmployee);
            employeeHistoryList[1].Employee.EmployeeDetails = new EmployeeDetails();
            employeeHistoryList[1].Employee.EmployeeDetails.Work = new Work();
            employeeHistoryList[1].Employee.EmployeeDetails.Work.Company = new Department(2, "");
            employeeHistoryList[2].Employee = new Employee(3, EmployeeTypeEnum.PartTimeEmployee);
            employeeHistoryList[2].Employee.EmployeeDetails = new EmployeeDetails();
            employeeHistoryList[2].Employee.EmployeeDetails.Work = new Work();
            employeeHistoryList[2].Employee.EmployeeDetails.Work.Company = new Department(3, "");
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(1, DateTime.Now.Date)).Return(employeeHistoryList);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList = _Target.GetEmployeeBasicInfoByDepartmentAndDateTime(1, DateTime.Now.Date);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualEmployeeList.Count, 3);
        }
        [Test, Description("GetAllEmployeeByDepartmentAndDateTime")]
        public void GetAllEmployeeBasicInfoByDepartmentAndDateTimeTest1()
        {
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(DateTime.Now.Date)).Return(new List<Department>());
            Expect.Call(
                _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTimeAndDept(DateTime.Now.Date, new List<Department>()))
                .Return(new List<EmployeeHistory>());
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList = _Target.GetAllEmployeeByDepartmentAndDateTime(1, DateTime.Now.Date, true);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualEmployeeList.Count, 0);
        }
        [Test, Description("GetAllEmployeeByDepartmentAndDateTime")]
        public void GetAllEmployeeBasicInfoByDepartmentAndDateTimeTest2()
        {
            List<Department> allDepartment = new List<Department>();
            Department Department0 = new Department(0, null, "0", null);
            Department Department1 = new Department(1, null, "1", Department0);

            allDepartment.Add(Department1);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(DateTime.Now.Date)).Return(allDepartment);

            List<EmployeeHistory> employeeHistoryList = new List<EmployeeHistory>();
            employeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
            employeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
            employeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
            employeeHistoryList[0].Employee = new Employee(1, EmployeeTypeEnum.BorrowedEmployee);
            employeeHistoryList[0].Employee.EmployeeDetails = new EmployeeDetails();
            employeeHistoryList[0].Employee.EmployeeDetails.Work = new Work();
            employeeHistoryList[0].Employee.EmployeeDetails.Work.Company = new Department(1, "");
            employeeHistoryList[1].Employee = new Employee(2, EmployeeTypeEnum.DimissionEmployee);
            employeeHistoryList[1].Employee.EmployeeDetails = new EmployeeDetails();
            employeeHistoryList[1].Employee.EmployeeDetails.Work = new Work();
            employeeHistoryList[1].Employee.EmployeeDetails.Work.Company = new Department(2, "");
            employeeHistoryList[2].Employee = new Employee(3, EmployeeTypeEnum.PartTimeEmployee);
            employeeHistoryList[2].Employee.EmployeeDetails = new EmployeeDetails();
            employeeHistoryList[2].Employee.EmployeeDetails.Work = new Work();
            employeeHistoryList[2].Employee.EmployeeDetails.Work.Company = new Department(3, "");
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTimeAndDept(DateTime.Now.Date, allDepartment)).Return(employeeHistoryList);

            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList = _Target.GetAllEmployeeByDepartmentAndDateTime(Department1.Id, DateTime.Now.Date, true);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualEmployeeList.Count, 3);
        }
    }
}