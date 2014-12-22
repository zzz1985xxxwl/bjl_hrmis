using System.Reflection;
using System.Text;
using SEP.HRMIS.Facade;
using SEP.HRMIS.Facade.PayModule;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.IFacede.PayModule;

namespace SEP.HRMIS.Presenter
{
    public class InstanceFactory
    {
        public static IAttendanceInOutRecordFacade AttendanceInOutRecordFacade()
        {
            return new AttendanceInOutRecordFacade();
        }

        /// <summary>
        ///     实例化SEP.HRMIS.Facade.ReadExternalDataFacade
        /// </summary>
        public static IReadExternalDataFacade ReadExternalDataFacade()
        {
            return new ReadExternalDataFacade();
        }

        /// <summary>
        ///     实例化SEP.HRMIS.Facade.AssessActivityFacade
        /// </summary>
        public static IAssessActivityFacade AssessActivityFacade()
        {
            return new AssessActivityFacade();
        }

        /// <summary>
        /// </summary>
        public static IEmployeeWelfareFacade CreateEmployeeWelfareFacade()
        {
            return new EmployeeWelfareFacade();
        }

        /// <summary>
        /// </summary>
        public static IEmployeeFacade CreateEmployeeFacade()
        {
            return new EmployeeFacade();
        }

        /// <summary>
        /// </summary>
        public static IAutoRemindServerFacade CreateAutoRemindServerFacade()
        {
            return new AutoRemindServerFacade();
        }

        /// <summary>
        /// </summary>
        public static IEmployeeHistoryFacade CreateEmployeeHistoryFacade()
        {
            return new EmployeeHistoryFacade();
        }

        /// <summary>
        /// </summary>
        public static IDepartmentHistoryFacade CreateDepartmentHistoryFacade()
        {
            return new DepartmentHistoryFacade();
        }

        /// <summary>
        /// </summary>
        public static IPlanDutyFacade CreatePlanDutyFacade()
        {
            return new PlanDutyFacade();
        }

        /// <summary>
        /// </summary>
        public static IAttendanceReadDataFacade CreateAttendanceReadDataFacade()
        {
            return new AttendanceReadDataFacade();
        }

        /// <summary>
        /// </summary>
        public static ITrainFacade CreateTrainFacade()
        {
            return new TrainFacade();
        }

        /// <summary>
        /// </summary>
        public static ISkillFacade CreateSkillFacade()
        {
            return new SkillFacade();
        }

        /// <summary>
        /// </summary>
        public static ISkillTypeFacade CreateSkillTypeFacade()
        {
            return new SkillTypeFacade();
        }

        /// <summary>
        /// </summary>
        public static IVacationFacade CreateVacationFacade()
        {
            return new VacationFacade();
        }

        /// <summary>
        /// </summary>
        public static IContractTypeFacade CreateContractTypeFacade()
        {
            return new ContractTypeFacade();
        }

        /// <summary>
        /// </summary>
        public static IApplyAssessConditionFacade CreateApplyAssessConditionFacade()
        {
            return new ApplyAssessConditionFacade();
        }

        /// <summary>
        /// </summary>
        public static IEmployeeContractFacade CreateEmployeeContractFacade()
        {
            return new EmployeeContractFacade();
        }

        /// <summary>
        /// </summary>
        public static IEmployeeStatisticsFacade CreateEmployeeStatisticsFacade()
        {
            return new EmployeeStatisticsFacade();
        }

        /// <summary>
        /// </summary>
        public static IReimburseFacade CreateReimburseFacade()
        {
            return new ReimburseFacade();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static ITraineeApplicationFacade CreateTraineeApplicationFacade()
        {
            return new TraineeApplicationFacade();
        }


        /// <summary>
        /// </summary>
        public static ILeaveRequestFacade CreateLeaveRequestFacade()
        {
            return new LeaveRequestFacade();
        }

        /// <summary>
        /// </summary>
        public static ILeaveRequestTypeFacade CreateLeaveRequestTypeFacade()
        {
            return new LeaveRequestTypeFacade();
        }

        /// <summary>
        /// </summary>
        public static IEmployeeAttendanceFacade CreateEmployeeAttendanceFacade()
        {
            return new EmployeeAttendanceFacade();
        }

        /// <summary>
        /// </summary>
        public static IAccountAuthFacade CreateAccountAuthFacade()
        {
            return new AccountAuthFacade();
        }

        /// <summary>
        /// </summary>
        public static IPositionHistoryFacade CreatePositionHistoryFacade()
        {
            return new PositionHistoryFacade();
        }

        /// <summary>
        /// </summary>
        public static IOutApplicationFacade CreateOutApplicationFacade()
        {
            return new OutApplicationFacade();
        }

        /// <summary>
        /// </summary>
        public static IAssessManagementFacade CreateAssessManagementFacade()
        {
            return new AssessManagementFacade();
        }

        /// <summary>
        /// </summary>
        public static ICompanyInvolveFacade CreateCompanyInvolveFacade()
        {
            return new CompanyInvolveFacade();
        }

        /// <summary>
        /// </summary>
        public static IDiyProcessFacade CreateDiyProcessFacade()
        {
            return new DiyProcessFacade();
        }

        /// <summary>
        /// </summary>
        public static IOverWorkFacade CreateOverWorkFacade()
        {
            return new OverWorkFacade();
        }

        /// <summary>
        ///     考勤统计
        /// </summary>
        public static IEmployeeAttendanceStatisticsFacade CreateEmployeeAttendanceStatisticsFacade()
        {
            return new EmployeeAttendanceStatisticsFacade();
        }

        /// <summary>
        /// </summary>
        public static IConfirmMessageFacade CreateConfirmMessageFacade()
        {
            return new ConfirmMessageFacade();
        }

        /// <summary>
        /// </summary>
        public static INationalityFacade CreateNationalityFacade()
        {
            return new NationalityFacade();
        }

        /// <summary>
        /// </summary>
        public static IFileCargoFacade CreateFileCargoFacade()
        {
            return new FileCargoFacade();
        }

        /// <summary>
        ///     反馈问卷
        /// </summary>
        public static IFeedBackPaperFacade CreateFeedBackPaperFacade()
        {
            return new FeedBackPaperFacade();
        }

        /// <summary>
        /// </summary>
        public static IAdjustRuleFacade CreateAdjustRuleFacade()
        {
            return new AdjustRuleFacade();
        }

        /// <summary>
        /// </summary>
        public static IEmployeeAdjustRuleFacade CreateEmployeeAdjustRuleFacade()
        {
            return new EmployeeAdjustRuleFacade();
        }

        /// <summary>
        /// </summary>
        public static ICustomerInfoFacade CreateCustomerInfoFacade()
        {
            return new CustomerInfoFacade();
        }

        /// <summary>
        /// </summary>
        public static ISystemErrorFacade CreateSystemErrorFacade()
        {
            return new SystemErrorFacade();
        }

        /// <summary>
        /// </summary>
        public static IPhoneMessageFacade CreatePhoneMessageFacade()
        {
            return new PhoneMessageFacade();
        }

        /// <summary>
        /// </summary>
        public static IAdvanceSearchFacade CreateAdvanceSearchFacade()
        {
            return new AdvanceSearchFacade();
        }

        /// <summary>
        /// </summary>
        public static IPositionApplicationFacade CreatePositionApplicationFacade()
        {
            return new PositionApplicationFacade();
        }



        /// <summary>
        /// 
        /// </summary>
        public static IAccountSetFacade CreateAccountSetFacade()
        {
            return new AccountSetFacade();
        }
        /// <summary>
        /// 
        /// </summary>
        public static IEmployeeAccountSetFacade CreateEmployeeAccountSetFacade()
        {
            return new EmployeeAccountSetFacade();
        }
        /// <summary>
        /// 
        /// </summary>
        public static ITaxFacade CreateTaxFacade()
        {
            return new TaxFacade();
        }
        /// <summary>
        /// 
        /// </summary>
        public static IEmployeeSalaryStatisticsFacade CreateEmployeeSalaryStatisticsFacade()
        {
            return new EmployeeSalaryStatisticsFacade();
        }
        /// <summary>
        /// 
        /// </summary>
        public static IGetBindFieldFacade CreateGetBindFieldFacade()
        {
            return new GetBindFieldFacade();
        }
    }
}