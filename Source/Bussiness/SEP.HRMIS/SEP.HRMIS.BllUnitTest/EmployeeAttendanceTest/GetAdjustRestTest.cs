using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.EmployeeAttendanceTest
{
    [TestFixture]
    public class GetAdjustRestTest
    {
        [Test, Description("GetAvailableAdjustRestDaysByEmployeeID")]
        public void GetAvailableAdjustRestDaysByEmployeeIDTest()
        {
            MockRepository mocks = new MockRepository();
            IAdjustRest iAdjustRest = mocks.CreateMock<IAdjustRest>();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.CreateMock<ILeaveRequestFlowDal>();

            Expect.Call(iAdjustRest.GetAdjustRestHoursByAccountID(1)).Return(80);
            Expect.Call(iLeaveRequestDal.SumLeaveRequestCostTimeByEmployeeIDStatusApplyType(1, RequestStatus.Submit,
                                                                                    LeaveRequestTypeEnum.AdjustRest)).Return(40);
            Expect.Call(iLeaveRequestDal.SumLeaveRequestCostTimeByEmployeeIDStatusApplyType(1, RequestStatus.Approving,
                                                                                    LeaveRequestTypeEnum.AdjustRest)).Return(10);

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

            GetAdjustRest Target = new GetAdjustRest(iAdjustRest, iLeaveRequestDal, iLeaveRequestFlowDal);
            decimal actual = Target.GetAvailableAdjustRestDaysByEmployeeID(1);
            mocks.VerifyAll();
            Assert.AreEqual(22, actual);
        }
    }
}
