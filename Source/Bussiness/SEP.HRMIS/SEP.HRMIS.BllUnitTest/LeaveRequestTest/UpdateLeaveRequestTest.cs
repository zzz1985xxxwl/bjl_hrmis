using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.LeaveRequestTest
{
    [TestFixture]
    public class UpdateLeaveRequestTest
    {
        

        [Test, Description("成功修改请假")]
        public void AddLeaveTypeTestSuccessfull()
        {
            MockRepository mocks = new MockRepository();
            IVacation iVacation = mocks.CreateMock<IVacation>();
            IAdjustRest iAdjustRest = mocks.CreateMock<IAdjustRest>();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.CreateMock<ILeaveRequestFlowDal>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.CreateMock<IEmployeeDiyProcessDal>();
            IOverWork iOverWork = mocks.CreateMock<IOverWork>();
            IOutApplication iOutApplication = mocks.CreateMock<IOutApplication>();
            IPlanDutyDal iPlanDutyDal = mocks.CreateMock<IPlanDutyDal>();
            ILeaveRequestType iLeaveRequestType = mocks.CreateMock<ILeaveRequestType>();
            IEmployee iEmployee = mocks.CreateMock<IEmployee>();

            bool ifSubmit = false;
            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""),
                                 new LeaveRequestType(11, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            leaveRequest.LeaveRequestItems.Add(new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4, RequestStatus.Submit));
            leaveRequest.LeaveRequestItems.Add(new LeaveRequestItem(1, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-2"), 4, RequestStatus.Submit));

            Expect.Call(
                iLeaveRequestDal.CountLeaveRequestInRepeatDateDiffPKID(1, 1, Convert.ToDateTime("2009-1-1"),
                                                                       Convert.ToDateTime("2009-1-1"))).Return(0);
            Expect.Call(
                iLeaveRequestDal.CountLeaveRequestInRepeatDateDiffPKID(1, 1, Convert.ToDateTime("2009-1-2"),
                                                                       Convert.ToDateTime("2009-1-2"))).Return(0);
            Expect.Call(
                iOverWork.CountOverWorkInRepeatDateDiffPKID(1, 0, Convert.ToDateTime("2009-1-1"),
                                                                       Convert.ToDateTime("2009-1-1"))).Return(0);
            Expect.Call(
                iOverWork.CountOverWorkInRepeatDateDiffPKID(1, 0, Convert.ToDateTime("2009-1-2"),
                                                                       Convert.ToDateTime("2009-1-2"))).Return(0);
            //Expect.Call(
            //    iOutApplication.CountOutApplicationInRepeatDateDiffPKID(1, 0, Convert.ToDateTime("2009-1-1"),
            //                                                           Convert.ToDateTime("2009-1-1"))).Return(0);
            //Expect.Call(
            //    iOutApplication.CountOutApplicationInRepeatDateDiffPKID(1, 0, Convert.ToDateTime("2009-1-2"),
            //                                                           Convert.ToDateTime("2009-1-2"))).Return(0);
            DiyProcess DiyProcess1 = new DiyProcess();
            DiyProcess1.DiySteps.Add(new DiyStep(1, "提交", OperatorType.YourSelf, 0));
            DiyProcess1.DiySteps.Add(new DiyStep(2, "审批", OperatorType.DepartmentLeader, 0));
            Expect.Call(
                iEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.LeaveRequest, 1)).Return(DiyProcess1);
            Expect.Call(
                iLeaveRequestDal.UpdateLeaveRequest(leaveRequest, 1)).Return(1);

            Employee employee = new Employee();
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.ProbationTime = Convert.ToDateTime("2008-1-1");
            Expect.Call(
              iEmployee.GetEmployeeByAccountID(1)).Return(employee);

            mocks.ReplayAll();

            UpdateLeaveRequest Target =
                new UpdateLeaveRequest(leaveRequest, ifSubmit, iVacation, iAdjustRest, iLeaveRequestDal,
                                       iLeaveRequestFlowDal, iEmployeeDiyProcessDal, iOverWork, iOutApplication,
                                       iPlanDutyDal, iLeaveRequestType, iEmployee);
            Target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("没有有请假流程")]
        public void NoLeaveRequestDiyProcess()
        {
            MockRepository mocks = new MockRepository();
            IVacation iVacation = mocks.CreateMock<IVacation>();
            IAdjustRest iAdjustRest = mocks.CreateMock<IAdjustRest>();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();
            ILeaveRequestFlowDal iLeaveRequestFlowDal = mocks.CreateMock<ILeaveRequestFlowDal>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.CreateMock<IEmployeeDiyProcessDal>();
            IOverWork iOverWork = mocks.CreateMock<IOverWork>();
            IOutApplication iOutApplication = mocks.CreateMock<IOutApplication>();
            IPlanDutyDal iPlanDutyDal = mocks.CreateMock<IPlanDutyDal>();
            ILeaveRequestType iLeaveRequestType = mocks.CreateMock<ILeaveRequestType>();
            IEmployee iEmployee = mocks.CreateMock<IEmployee>();
            bool ifSubmit = false;
            LeaveRequest leaveRequest =
                new LeaveRequest(1, new Account(1, "", ""),
                                 new LeaveRequestType(11, "", "", LegalHoliday.UnInclude, RestDay.Include, 4), DateTime.Now, "");
            leaveRequest.LeaveRequestItems.Add(new LeaveRequestItem(1, Convert.ToDateTime("2009-1-1"), Convert.ToDateTime("2009-1-1"), 4, RequestStatus.Submit));
            leaveRequest.LeaveRequestItems.Add(new LeaveRequestItem(1, Convert.ToDateTime("2009-1-2"), Convert.ToDateTime("2009-1-2"), 4, RequestStatus.Submit));

            Expect.Call(
                iLeaveRequestDal.CountLeaveRequestInRepeatDateDiffPKID(1, 1, Convert.ToDateTime("2009-1-1"),
                                                                       Convert.ToDateTime("2009-1-1"))).Return(0);
            Expect.Call(
                iLeaveRequestDal.CountLeaveRequestInRepeatDateDiffPKID(1, 1, Convert.ToDateTime("2009-1-2"),
                                                                       Convert.ToDateTime("2009-1-2"))).Return(0);
            Expect.Call(
                iOverWork.CountOverWorkInRepeatDateDiffPKID(1, 0, Convert.ToDateTime("2009-1-1"),
                                                                       Convert.ToDateTime("2009-1-1"))).Return(0);
            Expect.Call(
                iOverWork.CountOverWorkInRepeatDateDiffPKID(1, 0, Convert.ToDateTime("2009-1-2"),
                                                                       Convert.ToDateTime("2009-1-2"))).Return(0);
            //Expect.Call(
            //    iOutApplication.CountOutApplicationInRepeatDateDiffPKID(1, 0, Convert.ToDateTime("2009-1-1"),
            //                                                           Convert.ToDateTime("2009-1-1"))).Return(0);
            //Expect.Call(
            //    iOutApplication.CountOutApplicationInRepeatDateDiffPKID(1, 0, Convert.ToDateTime("2009-1-2"),
            //                                                           Convert.ToDateTime("2009-1-2"))).Return(0);
            Expect.Call(
                iEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.LeaveRequest, 1)).Return(null);
            mocks.ReplayAll();

            UpdateLeaveRequest Target =
                new UpdateLeaveRequest(leaveRequest, ifSubmit, iVacation, iAdjustRest, iLeaveRequestDal,
                                       iLeaveRequestFlowDal, iEmployeeDiyProcessDal, iOverWork, iOutApplication,
                                       iPlanDutyDal, iLeaveRequestType, iEmployee);
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
