using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.LeaveRequests;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.LeaveRequestTest
{
    [TestFixture]
    public class ApproveFailLeaveRequestItemTest
    {


        [Test, Description("因为流程中断，审批不通过整张请假单")]
        public void ApproveFailLeaveRequestItemSuccess()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.Stub<ILeaveRequestFlowDal>();

            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""),
                                 new LeaveRequestType(11, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            leaveRequest.LeaveRequestItems.Add(new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4, RequestStatus.Submit));
            leaveRequest.LeaveRequestItems.Add(new LeaveRequestItem(2, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-2"), 4, RequestStatus.Submit));

            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestByPKID(1)).Return(leaveRequest);
            Expect.Call(
                iLeaveRequestDal.UpdateLeaveRequestItemStatusByLeaveRequestItemID(1, RequestStatus.ApproveFail, 0)).Return(1);

            mocks.ReplayAll();

            ApproveFailLeaveRequestItem Target =
                new ApproveFailLeaveRequestItem(1, 1, 1, RequestStatus.ApproveFail, "", iLeaveRequestDal,
                                                iLeaveRequestFlowDal);
            Target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("因为没有请假单，操作失败")]
        public void LeaveRequestNotExist()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.Stub<ILeaveRequestFlowDal>();


            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestByPKID(1)).Return(null);

            mocks.ReplayAll();

            ApproveFailLeaveRequestItem Target =
                new ApproveFailLeaveRequestItem(1, 1, 1, RequestStatus.ApproveFail, "", iLeaveRequestDal,
                                                iLeaveRequestFlowDal);
            try
            {
                Target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("该请假单不存在", ex.Message);
            }
            mocks.VerifyAll();
        }

        [Test,  Description("因为流程中断，审批不通过整张请假单")]
        public void ApproveFailLeaveRequestItemAdjustRest()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.Stub<ILeaveRequestFlowDal>();

            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""),
                                 new LeaveRequestType(5, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            LeaveRequestItem LeaveRequestItem1 =
                new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4,
                                     RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(LeaveRequestItem1);

            LeaveRequestItem LeaveRequestItem2 =
                new LeaveRequestItem(2, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-2"), 4,
                                     RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(LeaveRequestItem2);

            List<LeaveRequestFlow> LeaveRequestFlow1 = new List<LeaveRequestFlow>();
            LeaveRequestFlow LeaveRequestFlow11 = new LeaveRequestFlow();
            LeaveRequestFlow11.LeaveRequestItem = LeaveRequestItem1;
            LeaveRequestFlow11.Account = new Account(1, "", "");
            LeaveRequestFlow11.LeaveRequestStatus = RequestStatus.Submit;
            LeaveRequestFlow1.Add(LeaveRequestFlow11);

            List<LeaveRequestFlow> LeaveRequestFlow2 = new List<LeaveRequestFlow>();
            LeaveRequestFlow LeaveRequestFlow21 = new LeaveRequestFlow();
            LeaveRequestFlow21.LeaveRequestItem = LeaveRequestItem2;
            LeaveRequestFlow21.Account = new Account(1, "", "");
            LeaveRequestFlow21.LeaveRequestStatus = RequestStatus.Submit;
            LeaveRequestFlow LeaveRequestFlow22 = new LeaveRequestFlow();
            LeaveRequestFlow22.LeaveRequestItem = LeaveRequestItem2;
            LeaveRequestFlow21.Account = new Account(1, "", "");
            LeaveRequestFlow22.LeaveRequestStatus = RequestStatus.ApprovePass;
            LeaveRequestFlow2.Add(LeaveRequestFlow22);

            Expect.Call(iLeaveRequestDal.GetLeaveRequestByPKID(1)).Return(leaveRequest);
            Expect.Call(
                iLeaveRequestDal.UpdateLeaveRequestItemStatusByLeaveRequestItemID(1, RequestStatus.ApproveCancelFail, 0)).Return(1);

            Expect.Call(iLeaveRequestFlowDal.GetLeaveRequestFlowByLeaveRequestItemID(1)).Return(LeaveRequestFlow1);
            Expect.Call(iLeaveRequestFlowDal.GetLeaveRequestFlowByLeaveRequestItemID(2)).Return(LeaveRequestFlow2);
            mocks.ReplayAll();

            ApproveFailLeaveRequestItem Target =
                new ApproveFailLeaveRequestItem(1, 1, 1, RequestStatus.ApproveCancelFail, "", iLeaveRequestDal,
                                                iLeaveRequestFlowDal);
            Target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("因为流程中断，审批不通过整张请假单")]
        public void ApproveFailLeaveRequestItemVacation()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.Stub<ILeaveRequestFlowDal>();
            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""),
                                 new LeaveRequestType(5, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            LeaveRequestItem LeaveRequestItem1 =
                new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4,
                                     RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(LeaveRequestItem1);

            LeaveRequestItem LeaveRequestItem2 =
                new LeaveRequestItem(2, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-2"), 8,
                                     RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(LeaveRequestItem2);

            List<LeaveRequestFlow> LeaveRequestFlow1 = new List<LeaveRequestFlow>();
            LeaveRequestFlow LeaveRequestFlow11 = new LeaveRequestFlow();
            LeaveRequestFlow11.LeaveRequestItem = LeaveRequestItem1;
            LeaveRequestFlow11.Account = new Account(1, "", "");
            LeaveRequestFlow11.LeaveRequestStatus = RequestStatus.Submit;
            LeaveRequestFlow1.Add(LeaveRequestFlow11);

            List<LeaveRequestFlow> LeaveRequestFlow2 = new List<LeaveRequestFlow>();
            LeaveRequestFlow LeaveRequestFlow21 = new LeaveRequestFlow();
            LeaveRequestFlow21.LeaveRequestItem = LeaveRequestItem2;
            LeaveRequestFlow21.Account = new Account(1, "", "");
            LeaveRequestFlow21.LeaveRequestStatus = RequestStatus.Submit;
            LeaveRequestFlow LeaveRequestFlow22 = new LeaveRequestFlow();
            LeaveRequestFlow22.LeaveRequestItem = LeaveRequestItem2;
            LeaveRequestFlow21.Account = new Account(1, "", "");
            LeaveRequestFlow22.LeaveRequestStatus = RequestStatus.ApprovePass;
            LeaveRequestFlow2.Add(LeaveRequestFlow22);

            List<Model.Vacation> Vacations = new List<Model.Vacation>();
            Vacations.Add(
                new Model.Vacation(1, new Employee(1, EmployeeTypeEnum.NormalEmployee), 40, Convert.ToDateTime("2009-1-1"),
                             Convert.ToDateTime("2009-12-31"), 28, 12, ""));

            Expect.Call(iLeaveRequestDal.GetLeaveRequestByPKID(1)).Return(leaveRequest);
            Expect.Call(
                iLeaveRequestDal.UpdateLeaveRequestItemStatusByLeaveRequestItemID(1, RequestStatus.ApproveCancelFail, 0)).Return(1);

            Expect.Call(iLeaveRequestFlowDal.GetLeaveRequestFlowByLeaveRequestItemID(1)).Return(LeaveRequestFlow1);
            Expect.Call(iLeaveRequestFlowDal.GetLeaveRequestFlowByLeaveRequestItemID(2)).Return(LeaveRequestFlow2);

            mocks.ReplayAll();

            ApproveFailLeaveRequestItem Target =
                new ApproveFailLeaveRequestItem(1, 1, 1, RequestStatus.ApproveCancelFail, "", iLeaveRequestDal,
                                                iLeaveRequestFlowDal);
            Target.Excute();
            mocks.VerifyAll();
        }
    }
}
