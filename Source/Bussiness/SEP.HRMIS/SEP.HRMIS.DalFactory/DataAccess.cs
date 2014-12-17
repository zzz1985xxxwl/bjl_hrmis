//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: DataAccess.cs
// Creater:  Xue.wenlong
// Date:  2009-03-24
// Resume:
// ---------------------------------------------------------------

using System;
using System.Configuration;
using System.Reflection;
using System.Text;
using SEP.HRMIS.IDal;

namespace SEP.HRMIS.DalFactory
{
    /// <summary>
    /// 
    /// </summary>
    public static class DataAccess
    {
        public static string _path = ConfigurationManager.AppSettings["HrmisDAL"];

        private static Assembly _HrmisDalInstance;

        private static IAssessActivity _AssessActivity;


        static DataAccess()
        {
            InitAssembly();
        }

        private static void InitAssembly()
        {
            if (String.IsNullOrEmpty(_path))
            {
                return;
                //note by colbert for test
                //throw new Exception("HrmisBll Assembly Config Error!");
            }

            if (_HrmisDalInstance == null)
                _HrmisDalInstance = Assembly.Load(_path);

            //note by colbert for test
            //if (_HrmisBllInstance == null)
            //{
            //    throw new Exception("Load SEPBll Assembly Error!");
            //}
        }

        ///<summary>
        /// 构造SEP.HRMIS.SqlServerDal.AssessActivityDal
        ///</summary>
        public static IAssessActivity AssessActivityDal
        {
            get
            {
                if (_AssessActivity != null)
                    return _AssessActivity;

                InitAssembly();

                if (_HrmisDalInstance != null)
                    _AssessActivity = (IAssessActivity)_HrmisDalInstance.CreateInstance(_path + ".AssessActivityDal");

                //note by colbert for test
                //if (_AttendanceInOutRecordFacade == null)
                //{
                //    throw new Exception("Load SEPBll Assembly Error!");
                //}
                return _AssessActivity;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ILeaveRequestType CreateLeaveRequestType()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".LeaveRequestTypeDal");
            return (ILeaveRequestType)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal.LeaveRequestDal
        /// </summary>
        /// <returns></returns>
        public static ILeaveRequestDal CreateLeaveRequest()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }

            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".LeaveRequestDal");
            return (ILeaveRequestDal)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal.ApplicationDal
        /// </summary>
        /// <returns></returns>
        public static IOutApplication CreateOutApplication()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".OutApplicationDal");
            return (IOutApplication)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal.OverWorkDal
        /// </summary>
        /// <returns></returns>
        public static IOverWork CreateOverWork()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".OverWorkDal");
            return (IOverWork)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal.LeaveRequestFlowDal
        /// </summary>
        /// <returns></returns>
        public static ILeaveRequestFlowDal CreateLeaveRequestFlow()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }

            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".LeaveRequestFlowDal");
            return (ILeaveRequestFlowDal)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        ///<summary>
        /// 构造SEP.HRMIS.SqlServerDal.BadAttendanceDal
        ///</summary>
        ///<returns></returns>
        public static IBadAttendance CreateBadAttendanceDal()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".BadAttendanceDal");
            return (IBadAttendance)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        ///<summary>
        /// 构造SEP.HRMIS.SqlServerDal.AttendanceReadRuleDal
        ///</summary>
        ///<returns></returns>
        public static IAttendanceReadRule CreateAttendanceReadRule()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".AttendanceReadRuleDal");
            return (IAttendanceReadRule)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        ///<summary>
        /// 构造SEP.HRMIS.SqlServerDal.ReadDataHistoryDal
        ///</summary>
        ///<returns></returns>
        public static IReadDataHistory CreateAttendanceReadHistory()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".ReadDataHistoryDal");
            return (IReadDataHistory)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        ///<summary>
        /// 构造SEP.HRMIS.SqlServerDal.AttendanceInAndOutRecordDal
        ///</summary>
        ///<returns></returns>
        public static IAttendanceInAndOutRecord CreateAttendanceInAndOutRecord()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".AttendanceInAndOutRecordDal");
            return (IAttendanceInAndOutRecord)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        ///<summary>
        /// 构造SEP.HRMIS.SqlServerDal.AttendanceInAndOutRecordLogDal
        ///</summary>
        ///<returns></returns>
        public static IInAndOutRecordLog CreateInAndOutRecordLog()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".AttendanceInAndOutRecordLogDal");
            return (IInAndOutRecordLog)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        ///<summary>
        /// 构造SEP.HRMIS.SqlServerDal.AuthDal
        ///</summary>
        ///<returns></returns>
        public static IAuthDal CreateAuthDal()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".AuthDal");
            return (IAuthDal)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        ///<summary>
        /// 构造SEP.HRMIS.SqlServerDal.AdjustRestDal
        ///</summary>
        ///<returns></returns>
        public static IAdjustRest CreateAdjustRest()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".AdjustRestDal");
            return (IAdjustRest)Assembly.Load(_path).CreateInstance(className.ToString());
        }


        ///<summary>
        /// 构造SEP.HRMIS.SqlServerDal.AdjustRestDal
        ///</summary>
        ///<returns></returns>
        public static IDiyProcessDal CreateDiyProcessDal()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".DiyProcessDal");
            return (IDiyProcessDal)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        ///<summary>
        /// 构造SEP.HRMIS.SqlServerDal.EmployeeDiyProcessDal
        ///</summary>
        ///<returns></returns>
        public static IEmployeeDiyProcessDal CreateEmployeeDiyProcessDal()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".EmployeeDiyProcessDal");
            return (IEmployeeDiyProcessDal)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IEmployee CreateEmployee()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".EmployeeDal");
            return (IEmployee)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IAssessTemplateItem CreateAssessTemplateItem()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".AssessTemplateItemDal");
            return (IAssessTemplateItem)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IAssessTemplatePaper CreateAssessTemplatePaper()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".AssessTemplatePaperDal");
            return (IAssessTemplatePaper)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IVacation CreateVacation()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".VacationDal");
            return (IVacation)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IParameter CreateParameter()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".ParameterDal");
            return (IParameter)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IContract CreateContract()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".ContractDal");
            return (IContract)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IReimburse CreateReimburse()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".ReimburseDal");
            return (IReimburse)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static ITraineeApplication CreateTraineeApplication()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".TraineeApplicationDal");
            return (ITraineeApplication)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IPlanDutyDal CreatePlanDutyDal()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".PlanDutyDal");
            return (IPlanDutyDal)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IFBQuestion CreateFBQues()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".FBQuestionDal");
            return (IFBQuestion)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IEmployeeSkill CreateEmployeeSkill()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".EmployeeSkillDal");
            return (IEmployeeSkill)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static ISkill CreateSkill()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".SkillDal");
            return (ISkill)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IMailAccount CreateMailAccount()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".MailAccountDal");
            return (IMailAccount)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IEmployeeHistory CreateEmployeeHistory()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".EmployeeHistoryDal");
            return (IEmployeeHistory)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IPositionHistory CreatePositionHistory()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".PositionHistoryDal");
            return (IPositionHistory)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IDepartmentHistory CreateDepartmentHistory()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".DepartmentHistoryDal");
            return (IDepartmentHistory)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static ITrain CreateTrain()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".TrainDal");
            return (ITrain)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IContractType CreateContractType()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".ContractTypeDal");
            return (IContractType)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IContractBookMark CreateContractBookMark()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".ContractBookMarkDal");
            return (IContractBookMark)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IEmployeeContractBookMark CreateEmployeeContractBookMark()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".EmployeeContractBookMarkDal");
            return (IEmployeeContractBookMark)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IWelcomeMail CreateWelcomeMail()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".WelcomeMailDal");
            return (IWelcomeMail)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IEmployeeWelfare CreateEmployeeWelfare()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".EmployeeWelfareDal");
            return (IEmployeeWelfare)Assembly.Load(_path).CreateInstance(className.ToString());
        }
        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IEmployeeWelfareHistory CreateEmployeeWelfareHistory()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".EmployeeWelfareHistoryDal");
            return (IEmployeeWelfareHistory)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IPhoneMessage CreatePhoneMessage()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".PhoneMessageDal");
            return (IPhoneMessage)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IFeedBackPaper CreateFeedBackPaper()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".FeedBackPaperDal");
            return (IFeedBackPaper)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IFileCargo CreateFileCargo()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".FileCargoDal");
            return (IFileCargo)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IAdjustRule CreateAdjustRule()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".AdjustRuleDal");
            return (IAdjustRule)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IEmployeeAdjustRule CreateEmployeeAdjustRule()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".EmployeeAdjustRuleDal");
            return (IEmployeeAdjustRule)Assembly.Load(_path).CreateInstance(className.ToString());
        }


        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IAssessTemplatePaperBindPosition CreateAssessTemplatePaperBindPosition()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".AssessTemplatePaperBindPositionDal");
            return (IAssessTemplatePaperBindPosition)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static ICustomerInfoDal CreateCustomerInfoDal()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".CustomerInfoDal");
            return (ICustomerInfoDal)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static IAdjustRestHistory CreateAdjustRestHistory()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".AdjustRestHistoryDal");
            return (IAdjustRestHistory)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal类工厂
        /// </summary>
        /// <returns></returns>
        public static ISystemError CreateSystemError()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".SystemErrorDal");
            return (ISystemError)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        /// <summary>
        /// 构造SEP.HRMIS.SqlServerDal.PositionApplicationDal
        /// </summary>
        /// <returns></returns>
        public static IPositionApplicationDal CreatePositionApplication()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".PositionApplicationDal");
            return (IPositionApplicationDal)Assembly.Load(_path).CreateInstance(className.ToString());
        }

    }
}