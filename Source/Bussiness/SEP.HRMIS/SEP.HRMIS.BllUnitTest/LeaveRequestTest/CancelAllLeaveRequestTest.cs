using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.LeaveRequests;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.LeaveRequestTest
{
    [TestFixture]
    public class CancelAllLeaveRequestTest
    {
        

        [Test, Description("成功取消一个请假项")]
        public void CancelLeaveRequestItemSuccess()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.Stub<ILeaveRequestFlowDal>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.CreateMock<IEmployeeDiyProcessDal>();

            DiyProcess DiyProcess1 = new DiyProcess();
            DiyStep DiyStep1 = new DiyStep(1, "提交", OperatorType.YourSelf, 0);
            DiyProcess1.DiySteps.Add(DiyStep1);
            DiyStep DiyStep2 = new DiyStep(2, "审批", OperatorType.DepartmentLeader, 0);
            DiyProcess1.DiySteps.Add(DiyStep2);
            DiyStep DiyStep3 = new DiyStep(3, "取消", OperatorType.YourSelf, 0);
            DiyProcess1.DiySteps.Add(DiyStep3);
            DiyStep DiyStep4 = new DiyStep(4, "审批取消", OperatorType.DepartmentLeader, 0);
            DiyProcess1.DiySteps.Add(DiyStep4);

            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""),
                                 new LeaveRequestType(11, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            LeaveRequestItem LeaveRequestItem1 =
                new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4,
                                     RequestStatus.Submit);
            LeaveRequestItem1.CurrentStep = DiyStep1;
            leaveRequest.LeaveRequestItems.Add(LeaveRequestItem1);

            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestByPKID(1)).Return(leaveRequest);

            Expect.Call(
                iEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.LeaveRequest, 1)).Return(DiyProcess1);

            Expect.Call(
                iLeaveRequestDal.UpdateLeaveRequestItemStatusByLeaveRequestItemID(1, RequestStatus.Approving, 4)).Return
                (1);

            mocks.ReplayAll();

            CancelAllLeaveRequest Target =
                new CancelAllLeaveRequest(1, RequestStatus.Approving, "", iLeaveRequestDal, iLeaveRequestFlowDal,
                                          iEmployeeDiyProcessDal);
            Target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("该请假单不存在")]
        public void LeaveRequestNotExist()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.Stub<ILeaveRequestFlowDal>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.CreateMock<IEmployeeDiyProcessDal>();

            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestByPKID(1)).Return(null);

            mocks.ReplayAll();

            CancelAllLeaveRequest Target =
                new CancelAllLeaveRequest(1, RequestStatus.Approving, "", iLeaveRequestDal, iLeaveRequestFlowDal,
                                          iEmployeeDiyProcessDal);
            try
            {
                Target.Excute();
            }
            catch(Exception ex)
            {
                Assert.AreEqual("该请假单不存在", ex.Message);
            }
            mocks.VerifyAll();
        }

        [Test, Description("该账号没有请假流程")]
        public void NoLeaveRequestDiyProcess()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.Stub<ILeaveRequestFlowDal>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.CreateMock<IEmployeeDiyProcessDal>();

            DiyStep DiyStep1 = new DiyStep(1, "提交", OperatorType.YourSelf, 0);

            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""),
                                 new LeaveRequestType(11, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            LeaveRequestItem LeaveRequestItem1 =
                new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4,
                                     RequestStatus.Submit);
            LeaveRequestItem1.CurrentStep = DiyStep1;
            leaveRequest.LeaveRequestItems.Add(LeaveRequestItem1);

            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestByPKID(1)).Return(leaveRequest);

            Expect.Call(
                iEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.LeaveRequest, 1)).Return(null);

            mocks.ReplayAll();

            CancelAllLeaveRequest Target =
                new CancelAllLeaveRequest(1, RequestStatus.Approving, "", iLeaveRequestDal, iLeaveRequestFlowDal,
                                          iEmployeeDiyProcessDal);
            try
            {
                Target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("该账号没有请假流程", ex.Message);
            }
            mocks.VerifyAll();
        }
    }
}
