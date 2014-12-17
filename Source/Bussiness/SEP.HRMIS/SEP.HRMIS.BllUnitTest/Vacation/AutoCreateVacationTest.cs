using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest.Vacation
{
    [TestFixture]
    public class AutoCreateVacationTest
    {
        private AutoCreateVacation autoCreateVacation;
        private DateTime _Date;
        private MockRepository _Mock;
        private static IVacation _VacationDal;
        private List<Model.Vacation> MockVacationList;
        [SetUp]
        public void SetUp()
        {
            _Mock = new MockRepository();
            _VacationDal = (IVacation)_Mock.CreateMock(typeof(IVacation));
        }
        //2007/2/4	2007/8/3	2007/9/1-2008/4/20;（（4+6）*6/12）=5天	2007/12/21-2009/4/20; 7天
        //2007/6/1	2007/11/30	2007/12/1-2008/4/20; ((1+6)*6/12)=3.5天	2007/12/21-2009/4/20; 7天
        //2007/6/8	2007/12/7	2008/1/1-2008/4/20; ((0+6)*6/12)=3天	2007/12/21-2009/4/20; 7天
        //2007/7/1	2007/12/31	2008/1/1-2008/4/20; ((6+0)*6/12)=3天	2007/12/21-2009/4/20; 6天
        //2007/7/9	2008/1/8	2008/2/1-2008/4/20; (5*6/12)=2.5天	2007/12/21-2009/4/20; 6天
        //2007/9/23	2008/3/20	2008/4/1-2008/4/20; (3*6/12)=1.5天	2007/12/21-2009/4/20; 6天
        //2007/1/2	2007/7/1	2007/8/1-2008/4/20；(11*6/12)=5.5天	2007/12/21-2009/4/20；7天
        //2007/1/1	2007/6/30	2007/7/1-2008/4/20；（6+6）*6/12=6天	2007/12/21-2009/4/20；7天

        //2007/6/30	2007/12/29	2008/1/1-2008/4/20；（0+6）*6/12=3天	2007/12/21-2009/4/20; 7天
        //2007/7/2	2008/1/1	2008/2/1-2008/4/20; ((5+0)*6/12)=2.5天	2007/12/21-2009/4/20; 6天
        //用例改变 有效期为试用期过后的第一个月1号——>试用期过后第一天
        [Test]
        public void TestGetVacationDayNum()
        {
            _Date = new DateTime(2007, 12, 21);
            autoCreateVacation = new AutoCreateVacation(_Date, 12, 6, 15, 4, 6, 30);

            Assert.AreEqual(7,autoCreateVacation.GetVacationDayNum(new DateTime(2007, 2, 4),new DateTime(2007, 8, 3)));
            Assert.AreEqual(7, autoCreateVacation.GetVacationDayNum(new DateTime(2007, 6, 1), new DateTime(2007, 11, 30)));
            Assert.AreEqual(6, autoCreateVacation.GetVacationDayNum(new DateTime(2007, 7, 1), new DateTime(2007, 12, 31)));
            Assert.AreEqual(7, autoCreateVacation.GetVacationDayNum(new DateTime(2007, 1, 2), new DateTime(2007, 7, 1)));
            Assert.AreEqual(6, autoCreateVacation.GetVacationDayNum(new DateTime(2007, 7, 9), new DateTime(2008, 1, 8)));
            Assert.AreEqual(6, autoCreateVacation.GetVacationDayNum(new DateTime(2007, 9, 23), new DateTime(2008, 3, 20)));
            Assert.AreEqual(7, autoCreateVacation.GetVacationDayNum(new DateTime(2007, 6, 30), new DateTime(2007, 12, 29)));
            Assert.AreEqual(6, autoCreateVacation.GetVacationDayNum(new DateTime(2007, 7, 2), new DateTime(2008, 1, 1)));

            Assert.AreEqual(8, autoCreateVacation.GetVacationDayNum(new DateTime(2006, 2, 4), new DateTime(2006, 8, 3)));
            Assert.AreEqual(8, autoCreateVacation.GetVacationDayNum(new DateTime(2006, 6, 1), new DateTime(2006, 11, 30)));
            Assert.AreEqual(7, autoCreateVacation.GetVacationDayNum(new DateTime(2006, 7, 1), new DateTime(2006, 12, 31)));
            Assert.AreEqual(8, autoCreateVacation.GetVacationDayNum(new DateTime(2006, 1, 2), new DateTime(2006, 7, 1)));
            Assert.AreEqual(7, autoCreateVacation.GetVacationDayNum(new DateTime(2006, 7, 9),new DateTime(2007, 1, 8)));
            Assert.AreEqual(7, autoCreateVacation.GetVacationDayNum(new DateTime(2006, 9, 23),new DateTime(2007, 3, 20)));
            Assert.AreEqual(8, autoCreateVacation.GetVacationDayNum(new DateTime(2006, 6, 30), new DateTime(2006, 12, 29)));
            Assert.AreEqual(7, autoCreateVacation.GetVacationDayNum(new DateTime(2006, 7, 2),new DateTime(2007, 1, 1)));

            Assert.AreEqual(9, autoCreateVacation.GetVacationDayNum(new DateTime(2005, 2, 4), new DateTime(2005, 8, 3)));
            Assert.AreEqual(9, autoCreateVacation.GetVacationDayNum(new DateTime(2005, 6, 1), new DateTime(2005, 11, 30)));
            Assert.AreEqual(8, autoCreateVacation.GetVacationDayNum(new DateTime(2005, 7, 1), new DateTime(2005, 12, 31)));
            Assert.AreEqual(9, autoCreateVacation.GetVacationDayNum(new DateTime(2005, 1, 2), new DateTime(2005, 7, 1)));
            Assert.AreEqual(8, autoCreateVacation.GetVacationDayNum(new DateTime(2005, 7, 9), new DateTime(2006, 1, 8)));
            Assert.AreEqual(8, autoCreateVacation.GetVacationDayNum(new DateTime(2005, 9, 23), new DateTime(2006, 3, 20)));
            Assert.AreEqual(9, autoCreateVacation.GetVacationDayNum(new DateTime(2005, 6, 30), new DateTime(2005, 12, 29)));
            Assert.AreEqual(8, autoCreateVacation.GetVacationDayNum(new DateTime(2005, 7, 2), new DateTime(2006, 1, 1)));

            Assert.AreEqual(10, autoCreateVacation.GetVacationDayNum(new DateTime(2004, 2, 4), new DateTime(2004, 8, 3)));
            Assert.AreEqual(11, autoCreateVacation.GetVacationDayNum(new DateTime(2003, 2, 4), new DateTime(2003, 8, 3)));
            Assert.AreEqual(12, autoCreateVacation.GetVacationDayNum(new DateTime(2002, 2, 4), new DateTime(2002, 8, 3)));
            Assert.AreEqual(13, autoCreateVacation.GetVacationDayNum(new DateTime(2001, 2, 4), new DateTime(2001, 8, 3)));
            Assert.AreEqual(14, autoCreateVacation.GetVacationDayNum(new DateTime(2000, 2, 4), new DateTime(2000, 8, 3)));

            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1999, 2, 4), new DateTime(1999, 8, 3)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1999, 6, 1), new DateTime(1999, 11, 30)));
            Assert.AreEqual(14, autoCreateVacation.GetVacationDayNum(new DateTime(1999, 7, 1), new DateTime(1999, 12, 31)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1999, 1, 2), new DateTime(1999, 7, 1)));
            Assert.AreEqual(14, autoCreateVacation.GetVacationDayNum(new DateTime(1999, 7, 9), new DateTime(2000, 1, 8)));
            Assert.AreEqual(14, autoCreateVacation.GetVacationDayNum(new DateTime(1999, 9, 23), new DateTime(2000, 3, 20)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1999, 6, 30), new DateTime(1999, 12, 29)));
            Assert.AreEqual(14, autoCreateVacation.GetVacationDayNum(new DateTime(1999, 7, 2), new DateTime(2000, 1, 1)));

            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1998, 2, 4), new DateTime(1998, 8, 3)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1998, 6, 1), new DateTime(1998, 11, 30)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1998, 7, 1), new DateTime(1998, 12, 31)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1998, 1, 2), new DateTime(1998, 7, 1)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1998, 7, 9), new DateTime(1999, 1, 8)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1998, 9, 23), new DateTime(1999, 3, 20)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1998, 6, 30), new DateTime(1998, 12, 29)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1998, 7, 2), new DateTime(1999, 1, 1)));

            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1990, 2, 4),new DateTime(1990, 8, 3)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1990, 6, 1),new DateTime(1990, 11, 30)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1990, 7, 1),new DateTime(1990, 12, 31)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1990, 1, 2),new DateTime(1990, 7, 1)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1990, 7, 9), new DateTime(1991, 1, 8)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1990, 9, 23), new DateTime(1991, 3, 20)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1990, 6, 30),new DateTime(1990, 12, 29)));
            Assert.AreEqual(15, autoCreateVacation.GetVacationDayNum(new DateTime(1990, 7, 2),new DateTime(1991, 1, 1)));

        }

        [Test]
        public void TestMarginMonth()
        {
            _Date = new DateTime(2007, 12, 21);
            autoCreateVacation = new AutoCreateVacation(_Date, 12, 6, 15, 4, 6, 21);

            Assert.AreEqual(10, autoCreateVacation.MarginMonth(new DateTime(2007, 2, 4), new DateTime(2008, 1, 1)));
            Assert.AreEqual(7, autoCreateVacation.MarginMonth(new DateTime(2007, 6, 1), new DateTime(2008, 1, 1)));
            Assert.AreEqual(6, autoCreateVacation.MarginMonth(new DateTime(2007, 6, 8), new DateTime(2008, 1, 1)));
            Assert.AreEqual(6, autoCreateVacation.MarginMonth(new DateTime(2007, 7, 1), new DateTime(2008, 1, 1)));
            Assert.AreEqual(5, autoCreateVacation.MarginMonth(new DateTime(2007, 7, 9), new DateTime(2008, 1, 1)));
            Assert.AreEqual(3, autoCreateVacation.MarginMonth(new DateTime(2007, 9, 23), new DateTime(2008, 1, 1)));
            Assert.AreEqual(11, autoCreateVacation.MarginMonth(new DateTime(2007, 1, 2), new DateTime(2008, 1, 1)));
        }
        
        [Test, Description("如果是每年生成年假的固定日期")]
        public void TestCreateAllVacation()
        {
            string remark = "系统每年自动生成年假记录";
            MockVacationList = new List<Model.Vacation>();
            _Date = new DateTime(2007, 12, 21);
            List<Employee> employeeList = CreateEmployeeList();
            
            List<Model.Vacation> expect=new List<Model.Vacation>();
            Model.Vacation vacation = new Model.Vacation(0, employeeList[1], 7, 
                new DateTime(2007,12,21), new DateTime(2009,4,20), 0, 7, remark);
            expect.Add(vacation);
            vacation = new Model.Vacation(0, employeeList[2], 7,
    new DateTime(2007, 12, 21), new DateTime(2009, 4, 20), 0, 7, remark);
            expect.Add(vacation);
            vacation = new Model.Vacation(0, employeeList[3], 7,
   new DateTime(2007, 12, 21), new DateTime(2009, 4, 20), 0, 7, remark);
            expect.Add(vacation);
            vacation = new Model.Vacation(0, employeeList[4], 6,
    new DateTime(2007, 12, 21), new DateTime(2009, 4, 20), 0, 6, remark);
            expect.Add(vacation);
            vacation = new Model.Vacation(0, employeeList[5], 6,
    new DateTime(2007, 12, 21), new DateTime(2009, 4, 20), 0, 6, remark);
            expect.Add(vacation);
            vacation = new Model.Vacation(0, employeeList[6], 6,
    new DateTime(2007, 12, 21), new DateTime(2009, 4, 20), 0, 6, remark);
            expect.Add(vacation);
            vacation = new Model.Vacation(0, employeeList[7], 7,
    new DateTime(2007, 12, 21), new DateTime(2009, 4, 20), 0, 7, remark);
            expect.Add(vacation);
            vacation = new Model.Vacation(0, employeeList[8], 7,
    new DateTime(2007, 12, 21), new DateTime(2009, 4, 20), 0, 7, remark);
            expect.Add(vacation);
            vacation = new Model.Vacation(0, employeeList[9], 6,
    new DateTime(2007, 12, 21), new DateTime(2009, 4, 20), 0, 6, remark);
            expect.Add(vacation);

            Expect.Call(delegate { _VacationDal.Insert(null); }).IgnoreArguments().Do(
                new InsertVacationDelegate(MockInsertVacation));
            Expect.Call(delegate { _VacationDal.Insert(null); }).IgnoreArguments().Do(
                new InsertVacationDelegate(MockInsertVacation));
            Expect.Call(delegate { _VacationDal.Insert(null); }).IgnoreArguments().Do(
                new InsertVacationDelegate(MockInsertVacation));
            Expect.Call(delegate { _VacationDal.Insert(null); }).IgnoreArguments().Do(
                new InsertVacationDelegate(MockInsertVacation));
            Expect.Call(delegate { _VacationDal.Insert(null); }).IgnoreArguments().Do(
                new InsertVacationDelegate(MockInsertVacation));
            Expect.Call(delegate { _VacationDal.Insert(null); }).IgnoreArguments().Do(
                new InsertVacationDelegate(MockInsertVacation));
            Expect.Call(delegate { _VacationDal.Insert(null); }).IgnoreArguments().Do(
                new InsertVacationDelegate(MockInsertVacation));
            Expect.Call(delegate { _VacationDal.Insert(null); }).IgnoreArguments().Do(
                new InsertVacationDelegate(MockInsertVacation));
            Expect.Call(delegate { _VacationDal.Insert(null); }).IgnoreArguments().Do(
                new InsertVacationDelegate(MockInsertVacation));

            _Mock.ReplayAll();
            autoCreateVacation = new AutoCreateVacation(_Date, 12, 6, 15, 4, 6, 21, _VacationDal);
            autoCreateVacation.CreateAllVacation(employeeList);
            _Mock.VerifyAll();
            AssertVacationList(expect, MockVacationList);
        }

        private void TestCreatePartVacation(decimal vacationDayNum, DateTime vacationStartDate,
                        DateTime vacationEndDate)
        {
            MockVacationList = new List<Model.Vacation>();
            string remark = "试用期结束系统自动生成年假信息";
            List<Employee> employeeList = CreateEmployeeList();

            List<Model.Vacation> expect = new List<Model.Vacation>();
            Model.Vacation vacation = new Model.Vacation(0, employeeList[1], vacationDayNum,
                vacationStartDate, vacationEndDate, 0, vacationDayNum, remark);
            expect.Add(vacation);
            Expect.Call(delegate { _VacationDal.Insert(null); }).IgnoreArguments().Do(
               new InsertVacationDelegate(MockInsertVacation));

            _Mock.ReplayAll();
            autoCreateVacation = new AutoCreateVacation(_Date, 12, 6, 15, 4, 6, 21, _VacationDal);
            autoCreateVacation.CreatePartVacation(employeeList);
            _Mock.VerifyAll();
            AssertVacationList(expect, MockVacationList);
        }
        [Test, Description("找出试用期结束的员工生成第一年年假")]
        public void TestCreatePartVacation1()
        {
           _Date = new DateTime(2007, 8, 4);
           TestCreatePartVacation(5, new DateTime(2007, 8, 4), new DateTime(2008, 4, 20));
        }
        [Test, Description("找出试用期结束的员工生成第一年年假")]
        public void TestCreatePartVacation2()
        {
            _Date = new DateTime(2007, 12, 1);
            TestCreatePartVacation(3.5m, new DateTime(2007, 12, 1), new DateTime(2008, 4, 20));
        }
        [Test, Description("找出试用期结束的员工生成第一年年假")]
        public void TestCreatePartVacation3()
        {
            _Date = new DateTime(2008, 1, 9);
            TestCreatePartVacation(2.5m, new DateTime(2008, 1, 9), new DateTime(2008, 4, 20));
        }
        [Test, Description("找出试用期结束的员工生成第一年年假")]
        public void TestCreatePartVacation4()
        {
            _Date = new DateTime(2008, 3, 21);
            TestCreatePartVacation(1.5m, new DateTime(2008, 3, 21), new DateTime(2008, 4, 20));
        }
        [Test, Description("找出试用期结束的员工生成第一年年假")]
        public void TestCreatePartVacation5()
        {
            _Date = new DateTime(2007, 7, 2);
            TestCreatePartVacation(5.5m, new DateTime(2007, 7, 2), new DateTime(2008, 4, 20));
        }

        [Test, Description("找出试用期结束的员工生成第一年年假")]
        public void TestCreatePartVacation6()
        {
            _Date = new DateTime(2008, 1, 1);
            TestCreatePartVacation(3m, new DateTime(2008, 1, 1), new DateTime(2008, 4, 20));
        }

        private static void AssertVacationList(IList<Model.Vacation> expect, IList<Model.Vacation> actual)
        {
            Assert.AreEqual(expect.Count, actual.Count);
            for (int i = 0; i < expect.Count;i++ )
            {
                Assert.AreEqual(expect[i].Remark, actual[i].Remark);
                Assert.AreEqual(expect[i].SurplusDayNum, actual[i].SurplusDayNum);
                Assert.AreEqual(expect[i].UsedDayNum, actual[i].UsedDayNum);
                Assert.AreEqual(expect[i].VacationDayNum, actual[i].VacationDayNum);
            }
        }

        private List<Employee>  CreateEmployeeList()
        {
            List<Employee> employeeList = new List<Employee>();
            Employee employee=new Employee();
            employee.EmployeeType = EmployeeTypeEnum.DimissionEmployee;
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.Work = new Work();
            employee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo();
            employee.EmployeeDetails.Work.DimissionInfo.DimissionDate = _Date.Date;
            employeeList.Add(employee);

            employee = new Employee();
            employee.EmployeeType = EmployeeTypeEnum.NormalEmployee;
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.ProbationTime = new DateTime(2007, 8, 3);
            employee.EmployeeDetails.Work = new Work();
            employee.EmployeeDetails.ProbationStartTime = new DateTime(2007, 2 , 4);
            employeeList.Add(employee);

            employee = new Employee();
            employee.EmployeeType = EmployeeTypeEnum.NormalEmployee;
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.ProbationTime = new DateTime(2007, 11, 30);
            employee.EmployeeDetails.Work = new Work();
            employee.EmployeeDetails.ProbationStartTime = new DateTime(2007, 6, 1);
            employeeList.Add(employee);

            employee = new Employee();
            employee.EmployeeType = EmployeeTypeEnum.NormalEmployee;
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.ProbationTime = new DateTime(2007, 12, 7);
            employee.EmployeeDetails.Work = new Work();
            employee.EmployeeDetails.ProbationStartTime = new DateTime(2007, 6, 8);
            employeeList.Add(employee);

            employee = new Employee();
            employee.EmployeeType = EmployeeTypeEnum.NormalEmployee;
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.ProbationTime = new DateTime(2007, 12, 31);
            employee.EmployeeDetails.Work = new Work();
            employee.EmployeeDetails.ProbationStartTime = new DateTime(2007, 7, 1);
            employeeList.Add(employee);


            employee = new Employee();
            employee.EmployeeType = EmployeeTypeEnum.NormalEmployee;
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.ProbationTime = new DateTime(2008, 1, 8);
            employee.EmployeeDetails.Work = new Work();
            employee.EmployeeDetails.ProbationStartTime = new DateTime(2007, 7, 9);
            employeeList.Add(employee);


            employee = new Employee();
            employee.EmployeeType = EmployeeTypeEnum.NormalEmployee;
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.ProbationTime = new DateTime(2008, 3, 20);
            employee.EmployeeDetails.Work = new Work();
            employee.EmployeeDetails.ProbationStartTime = new DateTime(2007, 9, 23);
            employeeList.Add(employee);

            employee = new Employee();
            employee.EmployeeType = EmployeeTypeEnum.NormalEmployee;
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.ProbationTime = new DateTime(2007, 7, 1);
            employee.EmployeeDetails.Work = new Work();
            employee.EmployeeDetails.ProbationStartTime = new DateTime(2007, 1, 2);
            employeeList.Add(employee);

            employee = new Employee();
            employee.EmployeeType = EmployeeTypeEnum.NormalEmployee;
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.ProbationTime = new DateTime(2007, 12, 29);
            employee.EmployeeDetails.Work = new Work();
            employee.EmployeeDetails.ProbationStartTime = new DateTime(2007, 6, 30);
            employeeList.Add(employee);

            employee = new Employee();
            employee.EmployeeType = EmployeeTypeEnum.NormalEmployee;
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.ProbationTime = new DateTime(2008, 1, 1);
            employee.EmployeeDetails.Work = new Work();
            employee.EmployeeDetails.ProbationStartTime = new DateTime(2007, 7, 2);
            employeeList.Add(employee);
            return employeeList;
        }
        private delegate int InsertVacationDelegate(Model.Vacation vacation);

        private int MockInsertVacation(Model.Vacation vacation)
        {
            MockVacationList.Add(vacation);
            return 2;
        }

    }

    
}
