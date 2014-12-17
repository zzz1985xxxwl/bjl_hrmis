using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.LeaveRequests;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.LeaveRequestTest
{
    [TestFixture]
    public class ApproveWholeLeaveRequestTest
    {
        

        [Test, Description("成功审核整张请假单")]
        public void ApproveWholeLeaveRequestSuccess()
        {
            MockRepository mocks = new MockRepository(); 
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.Stub<ILeaveRequestFlowDal>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.Stub<IEmployeeDiyProcessDal>();
            IVacation iVacation = mocks.Stub<IVacation>();
            IAdjustRest iAdjustRest = mocks.Stub<IAdjustRest>();
            IPlanDutyDal iPlanDutyDal = mocks.Stub<IPlanDutyDal>();
            ILeaveRequestType iLeaveRequestType = mocks.Stub<ILeaveRequestType>();

            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""),
                                 new LeaveRequestType(11, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            leaveRequest.LeaveRequestItems.Add(new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4, RequestStatus.Submit));
            leaveRequest.LeaveRequestItems.Add(new LeaveRequestItem(2, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-2"), 4, RequestStatus.Submit));

            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestByPKID(1)).Return(leaveRequest);
            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestByPKID(1)).Return(leaveRequest);
            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestByPKID(1)).Return(leaveRequest);
            
            mocks.ReplayAll();

            ApproveWholeLeaveRequest Target =
                new ApproveWholeLeaveRequest(1, 1, RequestStatus.ApproveFail, "", iLeaveRequestDal, iLeaveRequestFlowDal,
                                             iEmployeeDiyProcessDal, iVacation, iAdjustRest,
                                             iPlanDutyDal, iLeaveRequestType);
            Target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("该请假单不存在")]
        public void LeaveRequestNotExist()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.Stub<ILeaveRequestFlowDal>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.Stub<IEmployeeDiyProcessDal>();
            IVacation iVacation = mocks.Stub<IVacation>();
            IAdjustRest iAdjustRest = mocks.Stub<IAdjustRest>();
            IPlanDutyDal iPlanDutyDal = mocks.Stub<IPlanDutyDal>();
            ILeaveRequestType iLeaveRequestType = mocks.Stub<ILeaveRequestType>();

            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestByPKID(1)).Return(null);

            mocks.ReplayAll();

            ApproveWholeLeaveRequest Target =
                new ApproveWholeLeaveRequest(1, 1, RequestStatus.ApproveFail, "", iLeaveRequestDal, iLeaveRequestFlowDal,
                                             iEmployeeDiyProcessDal, iVacation, iAdjustRest,
                                             iPlanDutyDal, iLeaveRequestType);
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
    }
}
