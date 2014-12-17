using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Model.Request;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest.LeaveRequestTest
{
    [TestFixture]
    public class GetLeaveRequestTest
    {
        

        [Test, Description("GetLeaveRequestByAccountID")]
        public void GetLeaveRequestByAccountIDTest()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.CreateMock<ILeaveRequestFlowDal>();
            ILeaveRequestType iLeaveRequestTypeDal = mocks.CreateMock<ILeaveRequestType>();
            IAccountBll iAccountBll = mocks.CreateMock<IAccountBll>();
            IDepartmentBll iDepartmentBll = mocks.CreateMock<IDepartmentBll>();

            List <LeaveRequest> LeaveRequests = new List<LeaveRequest>();

            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""),
                                 new LeaveRequestType(11, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            leaveRequest.LeaveRequestItems.Add(new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4, RequestStatus.Submit));
            leaveRequest.LeaveRequestItems.Add(new LeaveRequestItem(2, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-2"), 4, RequestStatus.Submit));

            LeaveRequests.Add(leaveRequest);

            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestByAccountID(1)).Return(LeaveRequests);
            Expect.Call(
                iAccountBll.GetAccountById(1)).Return(new Account(1, "Account1", "Account1"));
            mocks.ReplayAll();

            GetLeaveRequest Target =
                new GetLeaveRequest(iLeaveRequestDal, iLeaveRequestFlowDal, iLeaveRequestTypeDal, iAccountBll,
                                    iDepartmentBll);
            Target.GetLeaveRequestByAccountID(1);
            mocks.VerifyAll();
        }

        [Test, Description("GetLeaveRequestByPKID")]
        public void GetLeaveRequestByPKIDTest()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.CreateMock<ILeaveRequestFlowDal>();
            ILeaveRequestType iLeaveRequestTypeDal = mocks.CreateMock<ILeaveRequestType>();
            IAccountBll iAccountBll = mocks.CreateMock<IAccountBll>();
            IDepartmentBll iDepartmentBll = mocks.CreateMock<IDepartmentBll>();

            List<LeaveRequest> LeaveRequests = new List<LeaveRequest>();

            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""),
                                 new LeaveRequestType(11, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            leaveRequest.LeaveRequestItems.Add(new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4, RequestStatus.Submit));
            leaveRequest.LeaveRequestItems.Add(new LeaveRequestItem(2, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-2"), 4, RequestStatus.Submit));

            LeaveRequests.Add(leaveRequest);

            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestByPKID(1)).Return(leaveRequest);
            Expect.Call(
                iAccountBll.GetAccountById(1)).Return(new Account(1, "Account1", "Account1"));
            mocks.ReplayAll();

            GetLeaveRequest Target =
                new GetLeaveRequest(iLeaveRequestDal, iLeaveRequestFlowDal, iLeaveRequestTypeDal, iAccountBll,
                                    iDepartmentBll);
            Target.GetLeaveRequestByPKID(1);
            mocks.VerifyAll();
        }

        [Test, Description("GetConfirmLeaveRequestaccountID")]
        public void GetConfirmLeaveRequestaccountIDTest()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.CreateMock<ILeaveRequestFlowDal>();
            ILeaveRequestType iLeaveRequestTypeDal = mocks.CreateMock<ILeaveRequestType>();
            IAccountBll iAccountBll = mocks.CreateMock<IAccountBll>();
            IDepartmentBll iDepartmentBll = mocks.CreateMock<IDepartmentBll>();

            #region prepare data

            List<LeaveRequest> LeaveRequests = new List<LeaveRequest>();

            #region leaveRequest

            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""),
                                 new LeaveRequestType(11, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            leaveRequest.LeaveRequestItems.Add(new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4, RequestStatus.Submit));
            leaveRequest.LeaveRequestItems[0].CurrentStep = new DiyStep(1, "取消", OperatorType.YourSelf, 0);
            leaveRequest.LeaveRequestItems.Add(new LeaveRequestItem(2, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-2"), 4, RequestStatus.Submit));
            leaveRequest.LeaveRequestItems[1].CurrentStep = new DiyStep(2, "审核通过", OperatorType.DepartmentLeader, 0);

            LeaveRequests.Add(leaveRequest);

            #endregion

            #region leaveRequest2

            LeaveRequest leaveRequest2 =
                new LeaveRequest(2, new Account(1, "", ""),
                                 new LeaveRequestType(11, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            leaveRequest2.LeaveRequestItems.Add(new LeaveRequestItem(3, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4, RequestStatus.Submit));
            leaveRequest2.LeaveRequestItems[0].CurrentStep = new DiyStep(3, "提交", OperatorType.GrandDepartmentLeader, 0);
            leaveRequest2.LeaveRequestItems.Add(new LeaveRequestItem(4, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-2"), 4, RequestStatus.Submit));
            leaveRequest2.LeaveRequestItems[1].CurrentStep = new DiyStep(4, "审核不通过", OperatorType.GrandGrandDepartmentLeader, 0);

            LeaveRequests.Add(leaveRequest2);

            #endregion

            #region leaveRequest3

            LeaveRequest leaveRequest3 =
                new LeaveRequest(3, new Account(1, "", ""),
                                 new LeaveRequestType(13, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            leaveRequest3.LeaveRequestItems.Add(new LeaveRequestItem(5, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4, RequestStatus.Submit));
            leaveRequest3.LeaveRequestItems[0].CurrentStep = new DiyStep(3, "审核取消", OperatorType.GrandGrandGrandDepartmentLeader, 0);
            leaveRequest3.LeaveRequestItems.Add(new LeaveRequestItem(6, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-2"), 4, RequestStatus.Submit));
            leaveRequest3.LeaveRequestItems[0].CurrentStep = new DiyStep(3, "取消", OperatorType.Others, 16);

            LeaveRequests.Add(leaveRequest3);

            #endregion

            Account Account2 = new Account(1, "Account2", "Account2");
            Department Department0 = new Department(0, "");
            Department0.Leader = new Account(0, "", "");
            Department Department1 = new Department(1, "");
            Department1.Leader = new Account(1, "", "");
            Department Department11 = new Department(11, "");
            Department11.Leader = new Account(11, "", "");
            Department Department111 = new Department(111, "");
            Department1.ParentDepartment = Department0;
            Department11.ParentDepartment = Department1;
            Department111.ParentDepartment = Department11;
            Account2.Dept = Department111;

            #endregion

            #region Expect.Call

            Expect.Call(
                iLeaveRequestDal.GetConfirmLeaveRequest()).Return(LeaveRequests);

            Expect.Call(
                iAccountBll.GetAccountById(1)).Return(Account2);
            Expect.Call(
                iAccountBll.GetLeaderByAccountId(1)).Return(new Account(4, "Account4", "Account4"));

            Expect.Call(
                iAccountBll.GetAccountById(1)).Return(Account2);
            Expect.Call(
                iAccountBll.GetAccountById(1)).Return(Account2);
            Expect.Call(
                iDepartmentBll.GetParentDept(111, null)).Return(Department11);
            Expect.Call(
                iDepartmentBll.GetParentDept(11, null)).Return(Department1);
            Expect.Call(
                iAccountBll.GetAccountById(1)).Return(Account2);
            Expect.Call(
                iDepartmentBll.GetParentDept(111, null)).Return(Department11);
            Expect.Call(
                iDepartmentBll.GetParentDept(11, null)).Return(Department1);
            Expect.Call(
                iDepartmentBll.GetParentDept(1, null)).Return(Department0);

            Expect.Call(
                iAccountBll.GetAccountById(1)).Return(Account2);

            Expect.Call(
                iLeaveRequestTypeDal.GetLeaveRequestTypeByPkid(11)).Return(
                new LeaveRequestType(1, "", "", LegalHoliday.UnInclude, RestDay.Include, 0));

            mocks.ReplayAll();

            #endregion

            GetLeaveRequest Target =
                new GetLeaveRequest(iLeaveRequestDal, iLeaveRequestFlowDal, iLeaveRequestTypeDal, iAccountBll,
                                    iDepartmentBll);
            List<LeaveRequest> actual = Target.GetConfirmLeaveRequest(1);
            mocks.VerifyAll();
            Assert.AreEqual(1, actual.Count);
        }

        [Test, Description("GetConfirmLeaveRequest")]
        public void GetConfirmLeaveRequestTest()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.CreateMock<ILeaveRequestFlowDal>();
            ILeaveRequestType iLeaveRequestTypeDal = mocks.CreateMock<ILeaveRequestType>();
            IAccountBll iAccountBll = mocks.CreateMock<IAccountBll>();
            IDepartmentBll iDepartmentBll = mocks.CreateMock<IDepartmentBll>();

            #region prepare data

            List<LeaveRequest> LeaveRequests = new List<LeaveRequest>();

            #region leaveRequest

            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""),
                                 new LeaveRequestType(11, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            leaveRequest.LeaveRequestItems.Add(new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4, RequestStatus.Submit));
            leaveRequest.LeaveRequestItems[0].CurrentStep = new DiyStep(1, "", OperatorType.YourSelf, 0);
            leaveRequest.LeaveRequestItems.Add(new LeaveRequestItem(2, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-2"), 4, RequestStatus.Submit));
            leaveRequest.LeaveRequestItems[1].CurrentStep = new DiyStep(2, "", OperatorType.DepartmentLeader, 0);
            
            LeaveRequests.Add(leaveRequest);

            #endregion

            #region leaveRequest2

            LeaveRequest leaveRequest2 =
                new LeaveRequest(2, new Account(2, "", ""),
                                 new LeaveRequestType(11, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            leaveRequest2.LeaveRequestItems.Add(new LeaveRequestItem(3, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4, RequestStatus.Submit));
            leaveRequest2.LeaveRequestItems[0].CurrentStep = new DiyStep(3, "", OperatorType.GrandDepartmentLeader, 0);
            leaveRequest2.LeaveRequestItems.Add(new LeaveRequestItem(4, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-2"), 4, RequestStatus.Submit));
            leaveRequest2.LeaveRequestItems[1].CurrentStep = new DiyStep(4, "", OperatorType.GrandGrandDepartmentLeader, 0);

            LeaveRequests.Add(leaveRequest2);

            #endregion

            #region leaveRequest3

            LeaveRequest leaveRequest3 =
                new LeaveRequest(3, new Account(3, "", ""),
                                 new LeaveRequestType(13, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            leaveRequest3.LeaveRequestItems.Add(new LeaveRequestItem(5, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4, RequestStatus.Submit));
            leaveRequest3.LeaveRequestItems[0].CurrentStep = new DiyStep(3, "", OperatorType.GrandGrandGrandDepartmentLeader, 0);
            leaveRequest3.LeaveRequestItems.Add(new LeaveRequestItem(6, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-2"), 4, RequestStatus.Submit));
            leaveRequest3.LeaveRequestItems[0].CurrentStep = new DiyStep(3, "", OperatorType.Others, 16);

            LeaveRequests.Add(leaveRequest3);

            #endregion

            Account Account2 = new Account(2, "Account2", "Account2");
            Department Department0 = new Department(0, "");
            Department0.Leader = new Account(0, "", "");
            Department Department1 = new Department(1, "");
            Department1.Leader = new Account(1, "", "");
            Department Department11 = new Department(11, "");
            Department11.Leader = new Account(11, "", "");
            Department Department111 = new Department(111, "");
            Department1.ParentDepartment = Department0;
            Department11.ParentDepartment = Department1;
            Department111.ParentDepartment = Department11;
            Account2.Dept = Department111;

            #endregion

            #region Expect.Call

            Expect.Call(
                iLeaveRequestDal.GetConfirmLeaveRequest()).Return(LeaveRequests);

            Expect.Call(
                iAccountBll.GetAccountById(1)).Return(new Account(1, "Account1", "Account1"));
            Expect.Call(
                iAccountBll.GetLeaderByAccountId(1)).Return(new Account(4, "Account4", "Account4"));

            Expect.Call(
                iAccountBll.GetAccountById(2)).Return(Account2);
            Expect.Call(
                iAccountBll.GetAccountById(2)).Return(Account2);
            Expect.Call(
                iDepartmentBll.GetParentDept(111, null)).Return(Department11);
            Expect.Call(
                iDepartmentBll.GetParentDept(11, null)).Return(Department1);
            Expect.Call(
                iAccountBll.GetAccountById(2)).Return(Account2);
            Expect.Call(
                iDepartmentBll.GetParentDept(111, null)).Return(Department11);
            Expect.Call(
                iDepartmentBll.GetParentDept(11, null)).Return(Department1);
            Expect.Call(
                iDepartmentBll.GetParentDept(1, null)).Return(Department0);

            Expect.Call(
                iAccountBll.GetAccountById(3)).Return(new Account(3, "Account3", "Account3"));
            mocks.ReplayAll();

            #endregion

            GetLeaveRequest Target =
                new GetLeaveRequest(iLeaveRequestDal, iLeaveRequestFlowDal, iLeaveRequestTypeDal, iAccountBll,
                                    iDepartmentBll);
            List<LeaveRequest> actual =  Target.GetConfirmLeaveRequest();
            mocks.VerifyAll();

            List<LeaveRequest> expect = new List<LeaveRequest>();
            leaveRequest.LeaveRequestItems[0].CurrentStep.OperatorID = 1;
            leaveRequest.LeaveRequestItems[1].CurrentStep.OperatorID = 4;
            expect.Add(leaveRequest);
            leaveRequest2.LeaveRequestItems[0].CurrentStep.OperatorID = 11;
            leaveRequest2.LeaveRequestItems[1].CurrentStep.OperatorID = 1;
            expect.Add(leaveRequest2);
            leaveRequest3.LeaveRequestItems[0].CurrentStep.OperatorID = 0;
            leaveRequest3.LeaveRequestItems[1].CurrentStep.OperatorID = 16;
            expect.Add(leaveRequest3);

            Assert.AreEqual(expect.Count, actual.Count);
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i].LeaveRequestItems.Count, actual[i].LeaveRequestItems.Count);
                for (int j = 0; j < expect[i].LeaveRequestItems.Count; j++)
                {
                    Assert.AreEqual(expect[i].LeaveRequestItems[j].CurrentStep.OperatorID,
                                    actual[i].LeaveRequestItems[j].CurrentStep.OperatorID);
                }
            }
        }

        [Test, Description("GetLeaveRequestConfirmHistoryByOperatorID")]
        public void GetLeaveRequestConfirmHistoryByOperatorIDTest()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.CreateMock<ILeaveRequestFlowDal>();
            ILeaveRequestType iLeaveRequestTypeDal = mocks.CreateMock<ILeaveRequestType>();
            IAccountBll iAccountBll = mocks.CreateMock<IAccountBll>();
            IDepartmentBll iDepartmentBll = mocks.CreateMock<IDepartmentBll>();

            List<LeaveRequest> LeaveRequests = new List<LeaveRequest>();
            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""),
                                 new LeaveRequestType(11, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            LeaveRequestItem LeaveRequestItem1 =
                new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4,
                                     RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(LeaveRequestItem1);
            LeaveRequestItem LeaveRequestItem2 =
                new LeaveRequestItem(2, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-2"), 4,
                                     RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(LeaveRequestItem2);

            List<LeaveRequestFlow> leaveRequestFlows = new List<LeaveRequestFlow>();
            LeaveRequestFlow leaveRequestFlow1 = new LeaveRequestFlow();
            leaveRequestFlow1.Account = new Account(1, "", "");
            leaveRequestFlow1.LeaveRequestItem = LeaveRequestItem1;
            leaveRequestFlow1.LeaveRequestFlowID = 1;
            leaveRequestFlow1.LeaveRequestStatus = RequestStatus.Submit;
            leaveRequestFlow1.OperationTime = DateTime.Now;
            leaveRequestFlow1.Remark = "";
            leaveRequestFlows.Add(leaveRequestFlow1);

            LeaveRequestFlow leaveRequestFlow2 = new LeaveRequestFlow();
            leaveRequestFlow2.Account = new Account(2, "", "");
            leaveRequestFlow2.LeaveRequestItem = LeaveRequestItem1;
            leaveRequestFlow2.LeaveRequestFlowID = 1;
            leaveRequestFlow2.LeaveRequestStatus = RequestStatus.Submit;
            leaveRequestFlow2.OperationTime = DateTime.Now;
            leaveRequestFlow2.Remark = "";
            leaveRequestFlows.Add(leaveRequestFlow2);
            LeaveRequests.Add(leaveRequest);
            
            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestConfirmHistoryByOperatorID(1,new DateTime(1999,01,01),new DateTime(2999,12,31) )).Return(LeaveRequests);
            Expect.Call(
                iAccountBll.GetAccountById(1)).Return(new Account(1, "Account1", "Account1"));
            mocks.ReplayAll();

            GetLeaveRequest Target =
                new GetLeaveRequest(iLeaveRequestDal, iLeaveRequestFlowDal, iLeaveRequestTypeDal, iAccountBll,
                                    iDepartmentBll);
            Target.GetLeaveRequestConfirmHistoryByOperatorID(1,"", new DateTime(1999, 01, 01), new DateTime(2999, 12, 31));
            mocks.VerifyAll();
        }

        [Test, Description("GetLeaveRequestFlowByLeaveRequestID")]
        public void GetLeaveRequestFlowByLeaveRequestIDTest()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.CreateMock<ILeaveRequestFlowDal>();
            ILeaveRequestType iLeaveRequestTypeDal = mocks.CreateMock<ILeaveRequestType>();
            IAccountBll iAccountBll = mocks.CreateMock<IAccountBll>();
            IDepartmentBll iDepartmentBll = mocks.CreateMock<IDepartmentBll>();

            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""),
                                 new LeaveRequestType(11, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            LeaveRequestItem LeaveRequestItem1 =
                new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4,
                                     RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(LeaveRequestItem1);
            LeaveRequestItem LeaveRequestItem2 =
                new LeaveRequestItem(2, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-2"), 4,
                                     RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(LeaveRequestItem2);

            List<LeaveRequestFlow> leaveRequestFlows = new List<LeaveRequestFlow>();
            LeaveRequestFlow leaveRequestFlow1 = new LeaveRequestFlow();
            leaveRequestFlow1.Account = new Account(1, "", "");
            leaveRequestFlow1.LeaveRequestItem = LeaveRequestItem1;
            leaveRequestFlow1.LeaveRequestFlowID = 1;
            leaveRequestFlow1.LeaveRequestStatus = RequestStatus.Submit;
            leaveRequestFlow1.OperationTime = DateTime.Now;
            leaveRequestFlow1.Remark = "";
            leaveRequestFlows.Add(leaveRequestFlow1);

            Expect.Call(
                iLeaveRequestFlowDal.GetLeaveRequestFlowByLeaveRequestID(1)).Return(leaveRequestFlows);
            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestItemByPKID(1)).Return(LeaveRequestItem1);
            Expect.Call(
                iAccountBll.GetAccountById(1)).Return(new Account(1, "Account1", "Account1"));
            mocks.ReplayAll();

            GetLeaveRequest Target =
                new GetLeaveRequest(iLeaveRequestDal, iLeaveRequestFlowDal, iLeaveRequestTypeDal, iAccountBll,
                                    iDepartmentBll);
            Target.GetLeaveRequestFlowByLeaveRequestID(1);
            mocks.VerifyAll();
        }

        [Test, Description("AdjustIfApprovePass")]
        public void AdjustIfApprovePassTest()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.CreateMock<ILeaveRequestFlowDal>();
            ILeaveRequestType iLeaveRequestTypeDal = mocks.CreateMock<ILeaveRequestType>();
            IAccountBll iAccountBll = mocks.CreateMock<IAccountBll>();
            IDepartmentBll iDepartmentBll = mocks.CreateMock<IDepartmentBll>();

            List<LeaveRequestItem> LeaveRequestItems = new List<LeaveRequestItem>();
            LeaveRequestItem LeaveRequestItem1 =
                new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4,
                                     RequestStatus.Submit);

            List<LeaveRequestFlow> LeaveRequestFlow1 = new List<LeaveRequestFlow>();

            LeaveRequestFlow LeaveRequestFlow11 = new LeaveRequestFlow();
            LeaveRequestFlow11.LeaveRequestItem = LeaveRequestItem1; ;
            LeaveRequestFlow11.Account = new Account(1, "", "");
            LeaveRequestFlow11.OperationTime = Convert.ToDateTime("2009-1-1");
            LeaveRequestFlow11.Remark = "";
            LeaveRequestFlow11.LeaveRequestStatus = RequestStatus.Submit;
            LeaveRequestFlow1.Add(LeaveRequestFlow11);

            LeaveRequestFlow LeaveRequestFlow12 = new LeaveRequestFlow();
            LeaveRequestFlow12.LeaveRequestItem = LeaveRequestItem1;
            LeaveRequestFlow12.Account = new Account(2, "", "");
            LeaveRequestFlow12.OperationTime = Convert.ToDateTime("2009-1-1");
            LeaveRequestFlow12.Remark = "";
            LeaveRequestFlow12.LeaveRequestStatus = RequestStatus.ApprovePass;
            LeaveRequestFlow1.Add(LeaveRequestFlow12);

            LeaveRequestItems.Add(LeaveRequestItem1);

            LeaveRequestItem LeaveRequestItem2 =
                new LeaveRequestItem(2, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4,
                                     RequestStatus.Submit);

            List<LeaveRequestFlow> LeaveRequestFlow2 = new List<LeaveRequestFlow>();

            LeaveRequestFlow LeaveRequestFlow21 = new LeaveRequestFlow();
            LeaveRequestFlow21.LeaveRequestItem = LeaveRequestItem2;
            LeaveRequestFlow21.Account = new Account(1, "", "");
            LeaveRequestFlow21.OperationTime = Convert.ToDateTime("2009-1-1");
            LeaveRequestFlow21.Remark = "";
            LeaveRequestFlow21.LeaveRequestStatus = RequestStatus.Submit;
            LeaveRequestFlow2.Add(LeaveRequestFlow21);

            LeaveRequestFlow LeaveRequestFlow22 = new LeaveRequestFlow();
            LeaveRequestFlow22.LeaveRequestItem = LeaveRequestItem2;
            LeaveRequestFlow22.Account = new Account(2, "", "");
            LeaveRequestFlow22.OperationTime = Convert.ToDateTime("2009-1-1");
            LeaveRequestFlow22.Remark = "";
            LeaveRequestFlow22.LeaveRequestStatus = RequestStatus.Approving;
            LeaveRequestFlow2.Add(LeaveRequestFlow22);

            LeaveRequestItems.Add(LeaveRequestItem2);

            Expect.Call(
                iLeaveRequestFlowDal.GetLeaveRequestFlowByLeaveRequestItemID(1)).Return(LeaveRequestFlow1);

            Expect.Call(
                iLeaveRequestFlowDal.GetLeaveRequestFlowByLeaveRequestItemID(2)).Return(LeaveRequestFlow2);
            mocks.ReplayAll();

            GetLeaveRequest Target =
                new GetLeaveRequest(iLeaveRequestDal, iLeaveRequestFlowDal, iLeaveRequestTypeDal, iAccountBll,
                                    iDepartmentBll);
            List<LeaveRequestItem> actual = Target.AdjustIfApprovePass(LeaveRequestItems);
            mocks.VerifyAll();
            Assert.AreEqual(1, actual.Count);
        }

        [Test, Description("GetAdjustRestCostTimeByEmployeeWhenCancelAfterSubmit")]
        public void GetAdjustRestCostTimeByEmployeeWhenCancelAfterSubmitTest()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.CreateMock<ILeaveRequestFlowDal>();
            ILeaveRequestType iLeaveRequestTypeDal = mocks.CreateMock<ILeaveRequestType>();
            IAccountBll iAccountBll = mocks.CreateMock<IAccountBll>();
            IDepartmentBll iDepartmentBll = mocks.CreateMock<IDepartmentBll>();

            List<LeaveRequestItem> LeaveRequestItems1 = new List<LeaveRequestItem>();
            LeaveRequestItem LeaveRequestItem1 =
                new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4,
                                     RequestStatus.Cancelled);

            List<LeaveRequestFlow> LeaveRequestFlow1 = new List<LeaveRequestFlow>();

            LeaveRequestFlow LeaveRequestFlow11 = new LeaveRequestFlow();
            LeaveRequestFlow11.LeaveRequestItem = LeaveRequestItem1; ;
            LeaveRequestFlow11.Account = new Account(1, "", "");
            LeaveRequestFlow11.OperationTime = Convert.ToDateTime("2009-1-1");
            LeaveRequestFlow11.Remark = "";
            LeaveRequestFlow11.LeaveRequestStatus = RequestStatus.Submit;
            LeaveRequestFlow1.Add(LeaveRequestFlow11);

            LeaveRequestFlow LeaveRequestFlow12 = new LeaveRequestFlow();
            LeaveRequestFlow12.LeaveRequestItem = LeaveRequestItem1;
            LeaveRequestFlow12.Account = new Account(2, "", "");
            LeaveRequestFlow12.OperationTime = Convert.ToDateTime("2009-1-1");
            LeaveRequestFlow12.Remark = "";
            LeaveRequestFlow12.LeaveRequestStatus = RequestStatus.ApprovePass;
            LeaveRequestFlow1.Add(LeaveRequestFlow12);

            LeaveRequestItems1.Add(LeaveRequestItem1);

            LeaveRequestItem LeaveRequestItem2 =
                new LeaveRequestItem(2, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 8,
                                     RequestStatus.CancelApproving);

            List<LeaveRequestItem> LeaveRequestItems2 = new List<LeaveRequestItem>();
            List<LeaveRequestFlow> LeaveRequestFlow2 = new List<LeaveRequestFlow>();

            LeaveRequestFlow LeaveRequestFlow21 = new LeaveRequestFlow();
            LeaveRequestFlow21.LeaveRequestItem = LeaveRequestItem2;
            LeaveRequestFlow21.Account = new Account(1, "", "");
            LeaveRequestFlow21.OperationTime = Convert.ToDateTime("2009-1-1");
            LeaveRequestFlow21.Remark = "";
            LeaveRequestFlow21.LeaveRequestStatus = RequestStatus.Submit;
            LeaveRequestFlow2.Add(LeaveRequestFlow21);

            LeaveRequestFlow LeaveRequestFlow22 = new LeaveRequestFlow();
            LeaveRequestFlow22.LeaveRequestItem = LeaveRequestItem2;
            LeaveRequestFlow22.Account = new Account(2, "", "");
            LeaveRequestFlow22.OperationTime = Convert.ToDateTime("2009-1-1");
            LeaveRequestFlow22.Remark = "";
            LeaveRequestFlow22.LeaveRequestStatus = RequestStatus.Approving;
            LeaveRequestFlow2.Add(LeaveRequestFlow22);

            LeaveRequestItems2.Add(LeaveRequestItem2);

            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestItemByAccountIDAndRequestStatus(1, LeaveRequestTypeEnum.AdjustRest,
                                                                                RequestStatus.Cancelled)).Return(
                LeaveRequestItems1);

            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestItemByAccountIDAndRequestStatus(1, LeaveRequestTypeEnum.AdjustRest,
                                                                                RequestStatus.CancelApproving)).Return(
                LeaveRequestItems2);

            Expect.Call(
                iLeaveRequestFlowDal.GetLeaveRequestFlowByLeaveRequestItemID(1)).Return(LeaveRequestFlow1);

            Expect.Call(
                iLeaveRequestFlowDal.GetLeaveRequestFlowByLeaveRequestItemID(2)).Return(LeaveRequestFlow2);
            mocks.ReplayAll();

            GetLeaveRequest Target =
                new GetLeaveRequest(iLeaveRequestDal, iLeaveRequestFlowDal, iLeaveRequestTypeDal, iAccountBll,
                                    iDepartmentBll);
            decimal actual = Target.GetAdjustRestCostTimeByEmployeeWhenCancelAfterSubmit(1);
            mocks.VerifyAll();
            Assert.AreEqual(8, actual);
        }

        [Test, Ignore, Description("请假开始时间早于年假开始时间，请假结束时间晚于年假结束时间")]
        public void AdjudgeVacationDaysAvailableTest()
        {
            MockRepository mocks = new MockRepository();
            IVacation iVacation = mocks.CreateMock<IVacation>();
            ILeaveRequestType iLeaveRequestTypeDal = mocks.CreateMock<ILeaveRequestType>();
            IPlanDutyDal iPlanDutyDal = mocks.CreateMock<IPlanDutyDal>();
             
            LeaveRequestType leaveRequestType = new LeaveRequestType(1, "", "", LegalHoliday.UnInclude, RestDay.Include, 4);

            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""), leaveRequestType, Convert.ToDateTime("2009-1-1"), "");
            LeaveRequestItem LeaveRequestItem1 =
                new LeaveRequestItem(1, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-12 17:30:00"), 56,
                                     RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(LeaveRequestItem1);

            List<Model.Vacation> vacations = new List<Model.Vacation>();
            Model.Vacation vacation0 =
                new Model.Vacation(1, new Employee(1, EmployeeTypeEnum.NormalEmployee), 80, Convert.ToDateTime("2008-12-29"),
                             Convert.ToDateTime("2009-1-4"), 40, 20, "");
            vacations.Add(vacation0);
            Model.Vacation vacation1 =
                new Model.Vacation(1, new Employee(1, EmployeeTypeEnum.NormalEmployee), 80, Convert.ToDateTime("2009-1-5"),
                             Convert.ToDateTime("2009-1-11"), 40, 40, "");
            vacations.Add(vacation1);
            Model.Vacation vacation2 =
                new Model.Vacation(2, new Employee(1, EmployeeTypeEnum.NormalEmployee), 80, Convert.ToDateTime("2009-1-12"),
                             Convert.ToDateTime("2009-1-18"), 20, 4, "");
            vacations.Add(vacation2);

            Expect.Call(
                iVacation.GetVacationByAccountIDAndTimeSpan(1, Convert.ToDateTime("2009-1-2"),
                                                            Convert.ToDateTime("2009-1-12 17:30:00"))).Return(vacations);
            Expect.Call(
                iLeaveRequestTypeDal.GetLeaveRequestTypeByPkid(1)).Return(leaveRequestType);
            Expect.Call(
                iLeaveRequestTypeDal.GetLeaveRequestTypeByPkid(1)).Return(leaveRequestType);
            Expect.Call(
                iLeaveRequestTypeDal.GetLeaveRequestTypeByPkid(1)).Return(leaveRequestType);

            Expect.Call(
                iPlanDutyDal.GetPlanDutyDetailByAccount(1, Convert.ToDateTime("2009-1-2"),
                                                        Convert.ToDateTime("2009-1-4"))).Return(
                GetPlanDutyDetails0101_0104());

            Expect.Call(
                iPlanDutyDal.GetPlanDutyDetailByAccount(1, Convert.ToDateTime("2009-1-5"),
                                                        Convert.ToDateTime("2009-1-11"))).Return(
                GetPlanDutyDetails0105_0111());

            Expect.Call(
                iPlanDutyDal.GetPlanDutyDetailByAccount(1, Convert.ToDateTime("2009-1-12"),
                                                        Convert.ToDateTime("2009-1-12 17:30:00"))).Return(
                GetPlanDutyDetails0112_0112());
            mocks.ReplayAll();

            GetLeaveRequest Target = new GetLeaveRequest(iVacation, iLeaveRequestTypeDal, iPlanDutyDal);
            bool actual = Target.AdjudgeVacationDaysAvailable(leaveRequest);
            mocks.VerifyAll();
            Assert.IsTrue(actual);
        }

        private static List<PlanDutyDetail> GetPlanDutyDetails0101_0104()
        {
            DutyClass rule1 =
                new DutyClass("班别1", DT(" 8:00:00"), DT(" 9:00:00"),
                DT(" 11:30:00"), DT(" 12:30:00"), DT(" 17:00:00"), 9,
                1, 11,1, 11);
            rule1.DutyClassID = 1;
            List<PlanDutyDetail> planDutyDetails = new List<PlanDutyDetail>();
            PlanDutyDetail planDutyDetail1 = new PlanDutyDetail();
            planDutyDetail1.Date = Convert.ToDateTime("2009-1-1 00:00:00");
            planDutyDetail1.PlanDutyClass = rule1;
            PlanDutyDetail planDutyDetail2 = new PlanDutyDetail();
            planDutyDetail2.Date = Convert.ToDateTime("2009-1-2 00:00:00");
            planDutyDetail2.PlanDutyClass = rule1;
            planDutyDetails.Add(planDutyDetail1);
            planDutyDetails.Add(planDutyDetail2);
            return planDutyDetails;
        }

        private static List<PlanDutyDetail> GetPlanDutyDetails0105_0111()
        {
            DutyClass rule1 =
                new DutyClass("班别1", DT(" 8:00:00"), DT(" 9:00:00"),
                DT(" 11:30:00"), DT(" 12:30:00"), DT(" 17:00:00"), 9,
                1, 11, 1, 11);
            rule1.DutyClassID = 1;
            List<PlanDutyDetail> planDutyDetails = new List<PlanDutyDetail>();
            PlanDutyDetail planDutyDetail1 = new PlanDutyDetail();
            planDutyDetail1.Date = Convert.ToDateTime("2009-1-5 00:00:00");
            planDutyDetail1.PlanDutyClass = rule1;
            PlanDutyDetail planDutyDetail2 = new PlanDutyDetail();
            planDutyDetail2.Date = Convert.ToDateTime("2009-1-6 00:00:00");
            planDutyDetail2.PlanDutyClass = rule1;
            PlanDutyDetail planDutyDetail3 = new PlanDutyDetail();
            planDutyDetail3.Date = Convert.ToDateTime("2009-1-7 00:00:00");
            planDutyDetail3.PlanDutyClass = rule1;
            PlanDutyDetail planDutyDetail4 = new PlanDutyDetail();
            planDutyDetail4.Date = Convert.ToDateTime("2009-1-8 00:00:00");
            planDutyDetail4.PlanDutyClass = rule1;
            PlanDutyDetail planDutyDetail5 = new PlanDutyDetail();
            planDutyDetail5.Date = Convert.ToDateTime("2009-1-9 00:00:00");
            planDutyDetail5.PlanDutyClass = rule1;
            planDutyDetails.Add(planDutyDetail1);
            planDutyDetails.Add(planDutyDetail2);
            planDutyDetails.Add(planDutyDetail3);
            planDutyDetails.Add(planDutyDetail4);
            planDutyDetails.Add(planDutyDetail5);
            return planDutyDetails;
        }

        private static List<PlanDutyDetail> GetPlanDutyDetails0112_0112()
        {
            DutyClass rule1 =
                new DutyClass("班别1", DT(" 8:00:00"), DT(" 9:00:00"),
                DT(" 11:30:00"), DT(" 12:30:00"), DT(" 17:00:00"), 9,
                1, 11, 1, 11);
            rule1.DutyClassID = 1;
            List<PlanDutyDetail> planDutyDetails = new List<PlanDutyDetail>();
            PlanDutyDetail planDutyDetail1 = new PlanDutyDetail();
            planDutyDetail1.Date = Convert.ToDateTime("2009-1-12 00:00:00");
            planDutyDetail1.PlanDutyClass = rule1;
            planDutyDetails.Add(planDutyDetail1);
            return planDutyDetails;
        }

        private static DateTime DT(string datetime)
        {
            return Convert.ToDateTime(datetime);
        }
    }
}
