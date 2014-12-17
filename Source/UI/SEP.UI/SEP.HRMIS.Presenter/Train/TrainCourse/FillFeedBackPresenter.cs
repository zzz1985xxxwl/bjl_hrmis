using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class FillFeedBackPresenter
    {
        private readonly IFeedBackDetailView _ItsView;
        private ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        //private IGetTrainCourse _GetTrainCourse = new GetTrainCourse();
        //private IGetEmployee _GetEmployee = new GetEmployee();
        //private AddCourseFeedBack _FeedBack;
        private IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private int _CourseId;
        private int _EmployeeId;
        private Account _Trainee;
        private Course _course;
        private readonly Account _LoginUser;
        public List<TrainEmployeeFB> _TrainEmployeeFBs;

        public FillFeedBackPresenter(IFeedBackDetailView itsView, string courseId, string employeeId,Account loginUser)
        {
            _ItsView = itsView;
            _LoginUser = loginUser;
            EventAttach();
            _ItsView.CourseId = courseId;
            _ItsView.EmployeeId = employeeId;

        }

        public void EventAttach()
        {
            _ItsView.BtnOKEvent += FillFeedBackEvent;
        }

        public void InitView(bool IsPostBack)
        {
            if (ValidateCourseID() && ValidateEmployeeID())
            {
                _course = _ITrainFacade.GetTrainCourseByPKID(_CourseId);
                _Trainee = _IAccountBll.GetAccountById(_EmployeeId); 

                _ItsView.PageTitle = "填写反馈信息";
                _ItsView.ErrorMessage = string.Empty;
                _ItsView.IsFrontPage = true;
                _ItsView.IsCertificationDisplay = _course.CertifactionDisplay;
                if (!IsPostBack)
                {
                    try
                    {
                        _TrainEmployeeFBs =
                            _ITrainFacade.GetTrainEmployeeFB(_EmployeeId, _CourseId, string.Empty, string.Empty, -1,
                                                               null, null, _LoginUser,true);
                    }
                    catch
                    {
                        _ItsView.ErrorMessage = "初始化错误";
                    }
                    if (_TrainEmployeeFBs == null || _TrainEmployeeFBs.Count == 0 || _TrainEmployeeFBs[0].FBTime == null)
                    {
                        _ItsView.CourseName = _course.CourseName;
                        _ItsView.Trainee = _Trainee.Name;
                        _ItsView.FBTime = DateTime.Now.ToShortDateString();
                        _ItsView.Score = string.Empty;
                    }
                    else
                    {
                        _ItsView.CourseName = _TrainEmployeeFBs[0].CourseName;
                        _ItsView.Trainee = _TrainEmployeeFBs[0].Trainee.Name;
                        _ItsView.Comment = _TrainEmployeeFBs[0].Remark;
                        _ItsView.FBTime = _TrainEmployeeFBs[0].FBTime.ToString();
                        _ItsView.Score = "总分：" + _TrainEmployeeFBs[0].Score;
                        _ItsView.CertificationName = _TrainEmployeeFBs[0].CertificationName;
                    }
                    FBDataBind();
                }
            }
        }

        private void FBDataBind()
        {
            _ItsView.Filled = _TrainEmployeeFBs[0].FBTime != null;
            _ItsView.FBItem = _ITrainFacade.GetTraineeFBItems(_CourseId, _EmployeeId);
        }

        private bool ValidateCourseID()
        {
            if (!int.TryParse(_ItsView.CourseId, out _CourseId))
            {
                _ItsView.ErrorMessage = "初始化错误";
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ValidateEmployeeID()
        {
            if (!int.TryParse(_ItsView.EmployeeId, out _EmployeeId))
            {
                _ItsView.ErrorMessage = "初始化错误";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void FillFeedBackEvent()
        {

            TrainEmployeeFB employeeFB = new TrainEmployeeFB(DateTime.Now, _ItsView.Comment);
            employeeFB.CertificationName = _ItsView.CertificationName;
            employeeFB.Trainee = _Trainee;
            employeeFB.FBItem = _ItsView.FBItem;

            try
            {
                _ITrainFacade.AddCourseFeedBack(_CourseId, employeeFB);
                //_FeedBack.Excute();
                _ItsView.returnLastPage = true;
            }
            catch (Exception ex)
            {
                _ItsView.ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// use for test
        /// </summary>
        public ITrainFacade GetTrainCouse
        {
            set { _ITrainFacade = value; }
        }

        public IAccountBll GetEmployee
        {
            set { _IAccountBll = value; }
        }
    }
}
