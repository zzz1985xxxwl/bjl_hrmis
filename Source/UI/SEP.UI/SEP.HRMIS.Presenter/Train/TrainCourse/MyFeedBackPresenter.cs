using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class MyFeedBackPresenter
    {
        private readonly IMyFeedBackView _ItsView;
        private readonly ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        //private IGetTrainCourse _GetTrainCourse = new GetTrainCourse();
        private readonly int _EmployeeId;
        private readonly Account _LoginUser;
        public MyFeedBackPresenter(IMyFeedBackView itsView, string employeeId, Account loginUser)
        {
            _ItsView = itsView;
            _LoginUser = loginUser;
            if (!int.TryParse(employeeId, out _EmployeeId))
            {
                _ItsView.ErrorMessage = "≥ı ºªØ¥ÌŒÛ";
                return;
            }
            AttachEvent();
        }

        private void AttachEvent()
        {
            _ItsView.CourseStartView.DataBind += CourseStartDataBind;
            _ItsView.CourseEndView.DataBind += CourseEndDataBind;
        }

        public void SetIfFrontPage(bool value)
        {
            _ItsView.CourseStartView.SetIfFrontDetailPage = value;
            _ItsView.CourseEndView.SetIfFrontDetailPage = value;
        }

        public void InitView(bool IsPostBack)
        {
            _ItsView.ErrorMessage = string.Empty;
            _ItsView.CourseStartView.SetScorcVisible = false;
            _ItsView.CourseEndView.SetScorcVisible = false;
            _ItsView.CourseStartView.SetFeedBackVisible = true;
            _ItsView.CourseEndView.SetFeedBackVisible = false;
            if (!IsPostBack)
            {
                CourseStartDataBind();
                CourseEndDataBind();
            }
        }

        private void CourseStartDataBind()
        {
            _ItsView.CourseStartView.employeeFBs = CourseDataBind().FindAll(FindStratCourse);
        }

        private void CourseEndDataBind()
        {
            _ItsView.CourseEndView.employeeFBs = CourseDataBind().FindAll(FindEndCourse);
        }

        private List<TrainEmployeeFB> CourseDataBind()
        {
            try
            {
                return _ITrainFacade.GetTrainEmployeeFB(_EmployeeId, -1, string.Empty, string.Empty, -1,
                                                        null, null, _LoginUser, true);
            }
            catch(Exception ae)
            {
                _ItsView.ErrorMessage = ae.Message;
            }
            return new List<TrainEmployeeFB>();
        }

        private bool FindStratCourse(TrainEmployeeFB fb)
        {
            try
            {
                Course course = _ITrainFacade.GetTrainCourseByPKID(fb.CourseId);
                if (course.Status == TrainStatusEnum.Start)
                {
                    return true;
                }
            }
            catch (Exception ae)
            {
                _ItsView.ErrorMessage = ae.Message;
            }
            return false;
        }

        private bool FindEndCourse(TrainEmployeeFB fb)
        {
            try
            {
                Course course = _ITrainFacade.GetTrainCourseByPKID(fb.CourseId);
                if (course.Status == TrainStatusEnum.End)
                {
                    return true;
                }
            }
            catch (Exception ae)
            {
                _ItsView.ErrorMessage = ae.Message;
            }
            return false;
        }

    }
}
