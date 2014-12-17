using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Model.Enum;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest.EmployeeAdjustRestTest
{
    [TestFixture]
    public class GetAdjustRestTest
    {
        private MockRepository _Mocks;
        private IAdjustRest _IAdjustRest;
        private ILeaveRequestFlowDal _DalLeaveRequestFlow;
        private GetAdjustRest _Target;
        private GetAdjustRestHistory _GetAdjustRestHistory;
        private GetEmployee _GetEmployee;

        private IAdjustRestHistory _IAdjustRestHistory;
        private IAccountBll _IAccountBll;
        private IEmployee _IEmployee;

        private IEmployeeSkill _IEmployeeSkill;
        private IDepartmentBll _IDepartmentBll;

        private int _AccountID = 1;
        private AdjustRest _AdjustRest;
        private IEmployeeAdjustRule _IEmployeeAdjustRule;
        [SetUp]
        public void SetUp()
        {
            Employee employee =
                new Employee(new Account(_AccountID, "", "王莎莉"), "", "", EmployeeTypeEnum.NormalEmployee, null,
                             new Department(1, "质量保证部"));
            employee.EmployeeDetails =
                new EmployeeDetails("", new Gender(1, ""), MaritalStatus.UnMarried, 0, 0, "", "", "",
                                    Convert.ToDateTime("1983-7-1"),
                                    PoliticalAffiliation.Party, DateTime.Now.Date, "", "");
            employee.EmployeeDetails.Work =
                new Work("", "", new WorkType(1, ""), Convert.ToDateTime("2007-7-1"), "");
            employee.EmployeeDetails.ResidencePermits = new ResidencePermit("", Convert.ToDateTime("2010-6-30"));

            _AdjustRest = new AdjustRest(1, 88, null, Convert.ToDateTime("2009-1-1"));
            _AdjustRest.Employee = employee;
            _Mocks = new MockRepository();
            _IAdjustRest = (IAdjustRest) _Mocks.DynamicMock(typeof (IAdjustRest));
            _IAdjustRestHistory = (IAdjustRestHistory) _Mocks.CreateMock(typeof (IAdjustRestHistory));
            _DalLeaveRequestFlow = (ILeaveRequestFlowDal) _Mocks.CreateMock(typeof (ILeaveRequestFlowDal));
            //_DalILeaveRequest= (ILeaveRequestDal)_Mocks.CreateMock(typeof(ILeaveRequestDal));

            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IEmployeeAdjustRule = _Mocks.DynamicMock<IEmployeeAdjustRule>();
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();
            _IEmployee = (IEmployee) _Mocks.CreateMock(typeof (IEmployee));
            _IEmployeeSkill = (IEmployeeSkill) _Mocks.CreateMock(typeof (IEmployeeSkill));
            _GetEmployee =
                new GetEmployee(_IEmployee, _IAccountBll, _IEmployeeSkill, _IDepartmentBll, _IEmployeeAdjustRule);
            _GetAdjustRestHistory = new GetAdjustRestHistory();
            _GetAdjustRestHistory.MockIAccountBll = _IAccountBll;
            _GetAdjustRestHistory.MockIAdjustRestHistory = _IAdjustRestHistory;
            //_DalILeaveRequest = _Mocks.CreateMock<ILeaveRequestDal>();
            _Target = new GetAdjustRest(_IAdjustRest, _DalLeaveRequestFlow);
            _Target.MockGetEmployee = _GetEmployee;
            _Target.MockGetAdjustRestHistory = _GetAdjustRestHistory;
        }

        //删除该测试，由于没有任何方法调用被测试的方法
        //[Test, Description("GetAvailableAdjustRestDaysByEmployeeID")]
        //public void GetAvailableAdjustRestDaysByEmployeeIDTest()
        //{
        //    MockRepository mocks = new MockRepository();
        //    IAdjustRest iAdjustRest = mocks.CreateMock<IAdjustRest>();
        //    ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
        //    ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.CreateMock<ILeaveRequestFlowDal>();

        //    //Expect.Call(iAdjustRest.GetAdjustRestHoursByAccountID(1)).Return(80);
        //    Expect.Call(iLeaveRequestDal.SumLeaveRequestCostTimeByEmployeeIDStatusApplyType(1, RequestStatus.Submit,
        //                                                                                    LeaveRequestTypeEnum.AdjustRest)).Return(40);
        //    Expect.Call(iLeaveRequestDal.SumLeaveRequestCostTimeByEmployeeIDStatusApplyType(1, RequestStatus.Approving,
        //                                                                                    LeaveRequestTypeEnum.AdjustRest)).Return(10);

        //    List<LeaveRequestItem> LeaveRequestItems1 = new List<LeaveRequestItem>();
        //    LeaveRequestItem LeaveRequestItem1 =
        //        new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4,
        //                             RequestStatus.Cancelled);

        //    List<LeaveRequestFlow> LeaveRequestFlow1 = new List<LeaveRequestFlow>();

        //    LeaveRequestFlow LeaveRequestFlow11 = new LeaveRequestFlow();
        //    LeaveRequestFlow11.LeaveRequestItem = LeaveRequestItem1; ;
        //    LeaveRequestFlow11.Account = new Account(1, "", "");
        //    LeaveRequestFlow11.OperationTime = Convert.ToDateTime("2009-1-1");
        //    LeaveRequestFlow11.Remark = "";
        //    LeaveRequestFlow11.LeaveRequestStatus = RequestStatus.Submit;
        //    LeaveRequestFlow1.Add(LeaveRequestFlow11);

        //    LeaveRequestFlow LeaveRequestFlow12 = new LeaveRequestFlow();
        //    LeaveRequestFlow12.LeaveRequestItem = LeaveRequestItem1;
        //    LeaveRequestFlow12.Account = new Account(2, "", "");
        //    LeaveRequestFlow12.OperationTime = Convert.ToDateTime("2009-1-1");
        //    LeaveRequestFlow12.Remark = "";
        //    LeaveRequestFlow12.LeaveRequestStatus = RequestStatus.ApprovePass;
        //    LeaveRequestFlow1.Add(LeaveRequestFlow12);

        //    LeaveRequestItems1.Add(LeaveRequestItem1);

        //    LeaveRequestItem LeaveRequestItem2 =
        //        new LeaveRequestItem(2, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 8,
        //                             RequestStatus.CancelApproving);

        //    List<LeaveRequestItem> LeaveRequestItems2 = new List<LeaveRequestItem>();
        //    List<LeaveRequestFlow> LeaveRequestFlow2 = new List<LeaveRequestFlow>();

        //    LeaveRequestFlow LeaveRequestFlow21 = new LeaveRequestFlow();
        //    LeaveRequestFlow21.LeaveRequestItem = LeaveRequestItem2;
        //    LeaveRequestFlow21.Account = new Account(1, "", "");
        //    LeaveRequestFlow21.OperationTime = Convert.ToDateTime("2009-1-1");
        //    LeaveRequestFlow21.Remark = "";
        //    LeaveRequestFlow21.LeaveRequestStatus = RequestStatus.Submit;
        //    LeaveRequestFlow2.Add(LeaveRequestFlow21);

        //    LeaveRequestFlow LeaveRequestFlow22 = new LeaveRequestFlow();
        //    LeaveRequestFlow22.LeaveRequestItem = LeaveRequestItem2;
        //    LeaveRequestFlow22.Account = new Account(2, "", "");
        //    LeaveRequestFlow22.OperationTime = Convert.ToDateTime("2009-1-1");
        //    LeaveRequestFlow22.Remark = "";
        //    LeaveRequestFlow22.LeaveRequestStatus = RequestStatus.Approving;
        //    LeaveRequestFlow2.Add(LeaveRequestFlow22);

        //    LeaveRequestItems2.Add(LeaveRequestItem2);

        //    Expect.Call(
        //        iLeaveRequestDal.GetLeaveRequestItemByAccountIDAndRequestStatus(1, LeaveRequestTypeEnum.AdjustRest,
        //                                                                        RequestStatus.Cancelled)).Return(
        //        LeaveRequestItems1);

        //    Expect.Call(
        //        iLeaveRequestDal.GetLeaveRequestItemByAccountIDAndRequestStatus(1, LeaveRequestTypeEnum.AdjustRest,
        //                                                                        RequestStatus.CancelApproving)).Return(
        //        LeaveRequestItems2);

        //    Expect.Call(
        //        iLeaveRequestFlowDal.GetLeaveRequestFlowByLeaveRequestItemID(1)).Return(LeaveRequestFlow1);

        //    Expect.Call(
        //        iLeaveRequestFlowDal.GetLeaveRequestFlowByLeaveRequestItemID(2)).Return(LeaveRequestFlow2);
        //    mocks.ReplayAll();

        //    GetAdjustRest Target = new GetAdjustRest(iAdjustRest, iLeaveRequestDal, iLeaveRequestFlowDal);
        //    decimal actual =  Target.GetAvailableAdjustRestDaysByEmployeeID(1);
        //    mocks.VerifyAll();
        //    Assert.AreEqual(22, actual);
        //}
        /// <summary>
        /// GetAdjustRestBasicInfoByAccountID正常路径的ExpectCall
        /// </summary>
        private void ExpectCallsGetAdjustRestBasicInfoByAccountID()
        {
            Expect.Call(_IAdjustRest.GetAdjustRestByAccountIDAndYear(1, DateTime.Now)).IgnoreArguments().Return(
                _AdjustRest).Repeat.Any();
            //获得相关的员工
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(_AccountID)).Return(_AdjustRest.Employee);
            Expect.Call(_IAccountBll.GetAccountById(_AdjustRest.Employee.Account.Id)).Return(
                _AdjustRest.Employee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(_AdjustRest.Employee.Account.Dept.Id, null)).Return(
                _AdjustRest.Employee.Account.Dept);
        }

        /// <summary>
        /// GetAdjustRestHistoryByAccountID正常路径的ExpectCall
        /// </summary>
        private void ExpectCallsGetAdjustRestHistoryByAccountID()
        {
            List<AdjustRestHistory> AdjustRestHistoryList = new List<AdjustRestHistory>();
            AdjustRestHistory adjustRestHistory =
                new AdjustRestHistory(1, new DateTime(2009, 4, 5), 8, AdjustRestHistoryTypeEnum.ModifyByOperator);
            adjustRestHistory.Operator = new Account(4, "", "");
            AdjustRestHistoryList.Add(adjustRestHistory);
            Expect.Call(_IAdjustRestHistory.GetAdjustRestHistoryByAccountID(_AccountID)).Return(AdjustRestHistoryList);
            Expect.Call(_IAccountBll.GetAccountById(adjustRestHistory.Operator.Id)).Return(adjustRestHistory.Operator);
        }

        [Test, Description("GetAdjustRestBasicInfoByAccountID，员工有AdjustRest")]
        public void GetAdjustRestBasicInfoByAccountIDTest1()
        {
            ExpectCallsGetAdjustRestBasicInfoByAccountID();

            _Mocks.ReplayAll();
            AdjustRest adjustRest = _Target.GetAdjustRestBasicInfoByAccountID(_AccountID);
            _Mocks.VerifyAll();
            Assert.IsNotNull(adjustRest.Employee);
        }

        [Test, Description("GetAdjustRestBasicInfoByAccountID，员工无AdjustRest")]
        public void GetAdjustRestBasicInfoByAccountIDTest2()
        {
            AdjustRest ad=new AdjustRest(1, 1, new Employee(), Convert.ToDateTime("2009-1-1"));
            ad.SurplusHours = 1;
            Expect.Call(_IAdjustRest.GetAdjustRestByAccountIDAndYear(1, DateTime.Now)).IgnoreArguments().Return( ad).Repeat.Any();
            //获得相关的员工
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(_AccountID)).Return(_AdjustRest.Employee);
            Expect.Call(_IAccountBll.GetAccountById(_AdjustRest.Employee.Account.Id)).Return(
                _AdjustRest.Employee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(_AdjustRest.Employee.Account.Dept.Id, null)).Return(
                _AdjustRest.Employee.Account.Dept);

            _Mocks.ReplayAll();
            AdjustRest adjustRest = _Target.GetAdjustRestBasicInfoByAccountID(_AccountID);
            _Mocks.VerifyAll();
            Assert.IsNotNull(adjustRest.Employee);
            Assert.AreEqual(adjustRest.AdjustRestID, 1);
            if (new DateTime(2009, DateTime.Now.Month, DateTime.Now.Day) > new DateTime(2009, AdjustRestUtility.AvailableTime.Month, AdjustRestUtility.AvailableTime.Day))
            {
                Assert.AreEqual(1, adjustRest.SurplusHours);
            }
            else
            {
                Assert.AreEqual(2, adjustRest.SurplusHours);
            }
        }


        [Test, Description("GetAdjustRestByAccountID，员工有AdjustRest")]
        public void GetAdjustRestByAccountIDTest1()
        {
            ExpectCallsGetAdjustRestBasicInfoByAccountID();
            ExpectCallsGetAdjustRestHistoryByAccountID();
            _Mocks.ReplayAll();
            AdjustRest adjustRest = _Target.GetAdjustRestByAccountID(_AccountID);
            _Mocks.VerifyAll();
            Assert.IsNotNull(adjustRest.Employee);
        }

        [Test, Description("GetAdjustRestByAccountID，员工无AdjustRest")]
        public void GetAdjustRestByAccountIDTest2()
        {

            AdjustRest ad = new AdjustRest(1, 1, new Employee(), Convert.ToDateTime("2009-1-1"));
            ad.SurplusHours = 1;
            Expect.Call(_IAdjustRest.GetAdjustRestByAccountIDAndYear(1, DateTime.Now)).IgnoreArguments().Return(ad).Repeat.Any();
            //获得相关的员工
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(_AccountID)).Return(_AdjustRest.Employee);
            Expect.Call(_IAccountBll.GetAccountById(_AdjustRest.Employee.Account.Id)).Return(
                _AdjustRest.Employee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(_AdjustRest.Employee.Account.Dept.Id, null)).Return(
                _AdjustRest.Employee.Account.Dept);
            ExpectCallsGetAdjustRestHistoryByAccountID();

            _Mocks.ReplayAll();
            AdjustRest adjustRest = _Target.GetAdjustRestByAccountID(_AccountID);
            _Mocks.VerifyAll();
            Assert.IsNotNull(adjustRest.Employee);
            Assert.AreEqual(adjustRest.AdjustRestID, 1);
            if (new DateTime(2009, DateTime.Now.Month, DateTime.Now.Day) > new DateTime(2009, AdjustRestUtility.AvailableTime.Month, AdjustRestUtility.AvailableTime.Day))
            {
                Assert.AreEqual(1, adjustRest.SurplusHours);
            }
            else
            {
                Assert.AreEqual(2, adjustRest.SurplusHours);
            }
        }
    }
}