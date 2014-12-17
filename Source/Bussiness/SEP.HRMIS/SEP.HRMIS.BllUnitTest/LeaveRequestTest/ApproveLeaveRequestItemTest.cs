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
    public class ApproveLeaveRequestItemTest
    {
        
        [Test, Ignore, Description("�ɹ����һ�������")]
        public void ApproveLeaveRequestItemSuccess()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.Stub<ILeaveRequestFlowDal>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.CreateMock<IEmployeeDiyProcessDal>();
            IVacation iVacation = mocks.Stub<IVacation>();
            IAdjustRest iAdjustRest = mocks.Stub<IAdjustRest>();
            IPlanDutyDal iPlanDutyDal = mocks.Stub<IPlanDutyDal>();
            ILeaveRequestType iLeaveRequestType = mocks.Stub<ILeaveRequestType>();

            DiyProcess DiyProcess1 = new DiyProcess();
            DiyStep DiyStep1 = new DiyStep(1, "�ύ", OperatorType.YourSelf, 0);
            DiyProcess1.DiySteps.Add(DiyStep1);
            DiyStep DiyStep2 = new DiyStep(2, "����", OperatorType.DepartmentLeader, 0);
            DiyProcess1.DiySteps.Add(DiyStep2);

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
                iLeaveRequestDal.UpdateLeaveRequestItemStatusByLeaveRequestItemID(1, RequestStatus.Approving, 2)).Return
                (1);

            mocks.ReplayAll();

            ApproveLeaveRequestItem Target =
                new ApproveLeaveRequestItem(1, 1, 1, RequestStatus.Approving, "", iLeaveRequestDal, iLeaveRequestFlowDal,
                                            iEmployeeDiyProcessDal, iVacation, iAdjustRest,
                                            iPlanDutyDal, iLeaveRequestType);
            Target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("����ٵ�������")]
        public void LeaveRequestNotExist()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.Stub<ILeaveRequestFlowDal>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.CreateMock<IEmployeeDiyProcessDal>();
            IVacation iVacation = mocks.Stub<IVacation>();
            IAdjustRest iAdjustRest = mocks.Stub<IAdjustRest>();
            IPlanDutyDal iPlanDutyDal = mocks.Stub<IPlanDutyDal>();
            ILeaveRequestType iLeaveRequestType = mocks.Stub<ILeaveRequestType>();

            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestByPKID(1)).Return(null);

            mocks.ReplayAll();

            ApproveLeaveRequestItem Target =
                new ApproveLeaveRequestItem(1, 1, 1, RequestStatus.Approving, "", iLeaveRequestDal, iLeaveRequestFlowDal,
                                            iEmployeeDiyProcessDal, iVacation, iAdjustRest,
                                            iPlanDutyDal, iLeaveRequestType);
            try
            {
                Target.Excute();
            }
            catch(Exception ex)
            {
                Assert.AreEqual("����ٵ�������", ex.Message);
            }
            mocks.VerifyAll();
        }

        [Test, Description("���˺�û���������")]
        public void NoLeaveRequestDiyProcess()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.Stub<ILeaveRequestFlowDal>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.CreateMock<IEmployeeDiyProcessDal>();
            IVacation iVacation = mocks.Stub<IVacation>();
            IAdjustRest iAdjustRest = mocks.Stub<IAdjustRest>();
            IPlanDutyDal iPlanDutyDal = mocks.Stub<IPlanDutyDal>();
            ILeaveRequestType iLeaveRequestType = mocks.Stub<ILeaveRequestType>();

            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""),
                                 new LeaveRequestType(11, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            LeaveRequestItem LeaveRequestItem1 =
                new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4,
                                     RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(LeaveRequestItem1);

            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestByPKID(1)).Return(leaveRequest);

            Expect.Call(
                iEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.LeaveRequest, 1)).Return(null);

            mocks.ReplayAll();

            ApproveLeaveRequestItem Target =
                new ApproveLeaveRequestItem(1, 1, 1, RequestStatus.Approving, "", iLeaveRequestDal, iLeaveRequestFlowDal,
                                            iEmployeeDiyProcessDal, iVacation, iAdjustRest,
                                            iPlanDutyDal, iLeaveRequestType);
            try
            {
                Target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("���˺�û���������", ex.Message);
            }
            mocks.VerifyAll();
        }

        [Test, Description("����ٵ����ֲ��ܱ����")]
        public void LeaveRequestPartialCanNotBeApproved()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.Stub<ILeaveRequestFlowDal>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.CreateMock<IEmployeeDiyProcessDal>();
            IVacation iVacation = mocks.Stub<IVacation>();
            IAdjustRest iAdjustRest = mocks.Stub<IAdjustRest>();
            IPlanDutyDal iPlanDutyDal = mocks.Stub<IPlanDutyDal>();
            ILeaveRequestType iLeaveRequestType = mocks.Stub<ILeaveRequestType>();

            DiyProcess DiyProcess1 = new DiyProcess();
            DiyStep DiyStep1 = new DiyStep(1, "�ύ", OperatorType.YourSelf, 0);
            DiyProcess1.DiySteps.Add(DiyStep1);
            DiyStep DiyStep2 = new DiyStep(2, "����", OperatorType.DepartmentLeader, 0);
            DiyProcess1.DiySteps.Add(DiyStep2);

            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""),
                                 new LeaveRequestType(11, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            LeaveRequestItem LeaveRequestItem1 =
                new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4,
                                     RequestStatus.ApprovePass);
            LeaveRequestItem1.CurrentStep = DiyStep1;
            leaveRequest.LeaveRequestItems.Add(LeaveRequestItem1);

            Expect.Call(
                iLeaveRequestDal.GetLeaveRequestByPKID(1)).Return(leaveRequest);

            Expect.Call(
                iEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.LeaveRequest, 1)).Return(DiyProcess1);

            mocks.ReplayAll();

            ApproveLeaveRequestItem Target =
                new ApproveLeaveRequestItem(1, 1, 1, RequestStatus.Approving, "", iLeaveRequestDal, iLeaveRequestFlowDal,
                                            iEmployeeDiyProcessDal, iVacation, iAdjustRest,
                                            iPlanDutyDal, iLeaveRequestType);
            try
            {
                Target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("����ٵ����ֲ��ܱ����", ex.Message);
            }
            mocks.VerifyAll();
        }

        [Test, Description("û��Ȩ����˸���ٵ�")]
        public void NoAuthToApprove()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.Stub<ILeaveRequestFlowDal>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.CreateMock<IEmployeeDiyProcessDal>();
            IVacation iVacation = mocks.Stub<IVacation>();
            IAdjustRest iAdjustRest = mocks.Stub<IAdjustRest>();
            IPlanDutyDal iPlanDutyDal = mocks.Stub<IPlanDutyDal>();
            ILeaveRequestType iLeaveRequestType = mocks.Stub<ILeaveRequestType>();

            DiyProcess DiyProcess1 = new DiyProcess();
            DiyStep DiyStep1 = new DiyStep(1, "�ύ", OperatorType.YourSelf, 0);
            DiyProcess1.DiySteps.Add(DiyStep1);
            DiyStep DiyStep2 = new DiyStep(2, "����", OperatorType.DepartmentLeader, 0);
            DiyProcess1.DiySteps.Add(DiyStep2);

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

            mocks.ReplayAll();

            ApproveLeaveRequestItem Target =
                new ApproveLeaveRequestItem(1, 1, 2, RequestStatus.Approving, "", iLeaveRequestDal, iLeaveRequestFlowDal,
                                            iEmployeeDiyProcessDal, iVacation, iAdjustRest,
                                            iPlanDutyDal, iLeaveRequestType);
            try
            {
                Target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("û��Ȩ����˸���ٵ�", ex.Message);
            }
            mocks.VerifyAll();
        }
    }
}
