using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;

namespace SEP.HRMIS.Presenter.TrainApplication
{
    public class TrainApplicationUtilityPresenter : PresenterCore.BasePresenter
    {
        private readonly ITrainApplicationView _ItsView;
        private readonly ITraineeApplicationFacade _ITrainFacade = InstanceFactory.CreateTraineeApplicationFacade();
        private readonly IGetBindFieldFacade _IGetBindFieldFacade = PayModuleInstanceFactory.CreateGetBindFieldFacade();
        public const string AddPageTitle = "新增培训申请";
        public const string AddOperationType = "Add";

        public const string UpdatePageTitle = "修改培训申请";
        public const string UpdateOperationType = "Update";

        public const string DeletePageTitle = "删除培训申请";
        public const string DeleteOperationType = "Delete";

        public const string DetailPageTitle = "查看培训申请";
        public const string DetailOperationType = "Detail";

        public const string ApprovePageTitle = "审核培训申请";
        public const string ApproveOperationType = "Approve";

        public const string _IsEmpty = "不能为空";
        public const string _FieldWrongFormat = "格式不对";
        public const string _StartEndDateError = "开始日期晚于结束日期";
        public const string _ExpectHourError = "计划课时不能小于等于0";
        public const string _ExpectCostError = "计划成本不能小于等于0";
        public const string _ActualHourError = "实际课时不能小于等于0";
        public const string _ActualCostError = "实际成本不能小于等于0";
        public const string _InitialWrong = "初始化信息失败";

        public TrainApplicationUtilityPresenter(ITrainApplicationView view, Account loginUser)
            : base(loginUser)
        {
            _ItsView = view;
        }

        public override void Initialize(bool isPostBack)
        {
            if (!isPostBack)
            {
                _ItsView.ScopeSource= TrainScopeType.AllTrainScopeTypes;
                _ItsView.ChoosedEmployees = string.Empty;
                _ItsView.Cost = string.Empty;
                _ItsView.EduSpuCost = string.Empty;
                _ItsView.CourseName = string.Empty;

                _ItsView.EndTime = string.Empty;
                _ItsView.HasCertifaction = false;
                _ItsView.Hour = string.Empty;

                _ItsView.Place = string.Empty;
                _ItsView.Skills = string.Empty;
                _ItsView.StartTime = string.Empty;

                _ItsView.Trainer = string.Empty;
                _ItsView.TrainScope = string.Empty;
            }
        }

        public void Init(string id, bool isPostBack)
        {
            int _ID;
            if (!int.TryParse(id, out _ID))
            {
                _ItsView.Message = _InitialWrong;
                return;
            }
            _ItsView.TrainApplicationID = id;
            if (!isPostBack)
            {
                TraineeApplication traineeApplication = _ITrainFacade.GetTraineeApplicationByPkid(_ID);
                _ItsView.ScopeSource = TrainScopeType.AllTrainScopeTypes;
                if (traineeApplication == null)
                {
                    _ItsView.Message = _InitialWrong;
                    return;
                }
                _ItsView.EmployeeList = traineeApplication.StudentList;
                string _ChoosedEmployees = "";
                foreach (Account account in traineeApplication.StudentList)
                {
                    _ChoosedEmployees = _ChoosedEmployees + account.Name + ",";
                }
                _ItsView.ChoosedEmployees = _ChoosedEmployees;
                _ItsView.Cost = traineeApplication.TrainCost.ToString();
                _ItsView.EduSpuCost = traineeApplication.EduSpuCost == null
                                          ? ""
                                          : traineeApplication.EduSpuCost.ToString();
                _ItsView.CourseName = traineeApplication.CourseName;

                _ItsView.EndTime = traineeApplication.EndTime.ToShortDateString();
                _ItsView.HasCertifaction = traineeApplication.HasCertifacation;
                _ItsView.Hour = traineeApplication.TrainHour.ToString();

                _ItsView.Place = traineeApplication.TrainPlace;
                _ItsView.Skills = traineeApplication.Skills;
                _ItsView.StartTime = traineeApplication.StratTime.ToShortDateString();

                _ItsView.Trainer = traineeApplication.Trainer;
                _ItsView.TrainScope = traineeApplication.TrainType.Id.ToString();
                _ItsView.Orgnation = traineeApplication.TrainOrgnatiaon;
                if (_ItsView.OperationType == DetailOperationType)
                {
                    _ItsView.SetEnable = false;
                }
                else if (_ItsView.OperationType == ApproveOperationType)
                {
                    _ItsView.SetEnable = false;
                    _ItsView.SetApprove = true;
                    try
                    {
                        BindItemValueCollection BindItemValueCollection =
                            _IGetBindFieldFacade.GetEmployeePassMonthBindField(traineeApplication.Applicant.Id,
                                                                               DateTime.Now.AddYears(1));
                        decimal month = BindItemValueCollection.GetBindItemValue(
                                                   BindItemEnum.LastYearProbationPassMonth);
                        _ItsView.ApplierInfo = traineeApplication.Applicant.Name + "; 今年年年底满试用期月份" +
                                               month + "个月";
                    }
                    catch
                    {
                        _ItsView.ApplierInfo = "数据确实，无法获取申请人信息。";
                    }
                }
                else
                {
                    _ItsView.SetEnable = true;
                }
            }
        }

        public bool Vaildation()
        {
            bool courseName = CouseNameValidate();
            bool place = PlaceValidate();
            bool trainer = TrainerValidate();
            bool employees = EmployeesValidate();
            bool expectHour = HourValidate();
            bool expectCost = CostValidate();
            bool expectST = STValidate();
            bool expectET = ETValidate();
            bool orgnation = OrgnationValidate();
            bool expectSTAndExpectET = ExpectSTAndExpectETValidate();
            bool skill = SkillValidate();
            bool eduSpuCost = EduSpuCostValidate();
            return
                courseName && place && trainer && expectHour && expectCost &&
                employees && expectST && expectET && expectSTAndExpectET && orgnation && skill && eduSpuCost;

        }

        //public bool DataBind(string courseId)
        //{
        //    int _courseId;
        //    if (!int.TryParse(courseId, out _courseId))
        //    {
        //        _ItsView.Message = _InitError;
        //        return false;
        //    }

        //    TraineeApplication course = _ITrainFacade.GetTraineeApplicationByPkid(_courseId);
        //    if (course != null)
        //    {
        //        _ItsView.CourseName = course.CourseName;
        //        _ItsView.Place = course.TrainPlace;
        //        _ItsView.Coordinator = course.Coordinator.Name;
        //        _ItsView.Trainer = course.Trainer;

        //        _ItsView.TrainScope = Convert.ToInt32(course.Scope).ToString();
        //        _ItsView.TrainStatus = Convert.ToInt32(course.Status).ToString();

        //        List<Account> employeeList = new List<Account>();
        //        foreach (TrainEmployeeFB employee in course.TrainFBResult.TrainEmployeeFBs)
        //        {
        //            employeeList.Add(employee.Trainee);
        //        }
        //        _ItsView.EmployeeList = employeeList;
        //        _ItsView.ChoosedEmployees = RequestUtility.GetEmployeeNames(_ItsView.EmployeeList);
        //        List<Skill> skilllist = new List<Skill>();
        //        foreach (Skill skill in course.Skill)
        //        {
        //            skilllist.Add(skill);
        //        }
        //        _ItsView.SkillList = skilllist;
        //        _ItsView.ChoosedSkills = GetSkillNames(_ItsView.SkillList);

        //        _ItsView.ExpectST = course.ExpectST.ToShortDateString();
        //        _ItsView.ExpectET = course.ExpectET.ToShortDateString();
        //        _ItsView.ExpectCost = course.ExpectCost.ToString();
        //        _ItsView.ExpectHour = course.ExpectHour.ToString();
        //        _ItsView.ActualST = course.ActualST.ToShortDateString();
        //        _ItsView.ActualET = course.ActualET.ToShortDateString();
        //        _ItsView.ActualCost = course.ActualCost.ToString();
        //        _ItsView.ActualHour = course.ActualHour.ToString();
        //        _ItsView.PaperId = course.CourseFeedBackPaper.FeedBackPaperId;
        //        _ItsView.HasCertifaction = course.HasCertification.Equals(1);
        //        return true;
        //    }
        //    _ItsView.Message = CourseUtility._InitError;
        //    return false;
        //}

        #region validate
        private bool CouseNameValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.CourseName.Trim()))
            {
                _ItsView.CourseNameMsg = _IsEmpty;
                return false;
            }
            _ItsView.CourseNameMsg = string.Empty;
            return true;
        }

        private bool PlaceValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.Place.Trim()))
            {
                _ItsView.PlaceMsg = _IsEmpty;
                return false;
            }
            _ItsView.PlaceMsg = string.Empty;
            return true;
        }

        private bool SkillValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.Skills.Trim()))
            {
                _ItsView.SkillsMsg = _IsEmpty;
                return false;
            }
            _ItsView.SkillsMsg = string.Empty;
            return true;
        }

        private bool OrgnationValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.Orgnation.Trim()))
            {
                _ItsView.OrgnationMsg = _IsEmpty;
                return false;
            }
            _ItsView.OrgnationMsg = string.Empty;
            return true;
        }

        private bool TrainerValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.Trainer.Trim()))
            {
                _ItsView.TrainersMsg = _IsEmpty;
                return false;
            }
            _ItsView.TrainersMsg = string.Empty;
            return true;
        }
        private bool EmployeesValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.ChoosedEmployees.Trim()))
            {
                _ItsView.EmployeeMsg = _IsEmpty;
                return false;
            }
            _ItsView.EmployeeMsg = string.Empty;
            return true;
        }
        private bool HourValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.Hour.Trim()))
            {
                _ItsView.Hour = "0";
            }
            decimal expectHour;
            if (!decimal.TryParse(_ItsView.Hour, out expectHour))
            {
                _ItsView.HourMsg = _FieldWrongFormat;
                return false;
            }
            if (expectHour <= 0)
            {
                _ItsView.HourMsg = _ExpectHourError;
                return false;
            }
            _ItsView.HourMsg = string.Empty;
            return true;
        }
        private bool CostValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.Cost.Trim()))
            {
                _ItsView.Cost = "0";
            }
            decimal expectCost;
            if (!decimal.TryParse(_ItsView.Cost, out expectCost))
            {
                _ItsView.CostMsg = _FieldWrongFormat;
                return false;
            }
            if (expectCost <= 0)
            {
                _ItsView.CostMsg = _ExpectCostError;
                return false;
            }
            _ItsView.CostMsg = string.Empty;
            return true;
        }

        public bool EduSpuCostValidate()
        {
            if (!string.IsNullOrEmpty(_ItsView.EduSpuCost.Trim()))
            {
                decimal expectCost;
                if (!decimal.TryParse(_ItsView.EduSpuCost, out expectCost))
                {
                    _ItsView.EduSpuCostMsg = _FieldWrongFormat;
                    return false;
                }
                if (expectCost <= 0)
                {
                    _ItsView.EduSpuCostMsg = _ExpectCostError;
                    return false;
                }
            }
            _ItsView.EduSpuCostMsg = string.Empty;
            return true;
        }

        private bool STValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.StartTime.Trim()))
            {
                _ItsView.STMsg = _IsEmpty;
                return false;
            }
            DateTime expectST;
            if (!DateTime.TryParse(_ItsView.StartTime, out expectST))
            {
                _ItsView.STMsg = _FieldWrongFormat;
                return false;
            }
            _ItsView.STMsg = string.Empty;

            return true;
        }
        private bool ETValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.EndTime.Trim()))
            {
                _ItsView.ETMsg = _IsEmpty;
                return false;
            }
            DateTime expectET;
            if (!DateTime.TryParse(_ItsView.EndTime, out expectET))
            {
                _ItsView.ETMsg = _FieldWrongFormat;
                return false;
            }

            _ItsView.ETMsg = string.Empty;
            return true;
        }
        private bool ExpectSTAndExpectETValidate()
        {
            if (STValidate() && ETValidate())
            {
                if (DateTime.Compare(Convert.ToDateTime(_ItsView.StartTime), Convert.ToDateTime(_ItsView.EndTime)) > 0)
                {
                    _ItsView.ETMsg = _StartEndDateError;
                    return false;
                }
                else
                {
                    _ItsView.ETMsg = string.Empty;
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        #endregion


        public static Dictionary<string, string> GetStatusForApproveSubmit()
        {
            Dictionary<string, string> leaveRequestStatus = new Dictionary<string, string>();
            leaveRequestStatus.Add(TraineeApplicationStatus.ApprovePass.Id.ToString(), "审核通过");
            leaveRequestStatus.Add(TraineeApplicationStatus.ApproveFail.Id.ToString(), "审核不通过");
            return leaveRequestStatus;
        }
    }
}
