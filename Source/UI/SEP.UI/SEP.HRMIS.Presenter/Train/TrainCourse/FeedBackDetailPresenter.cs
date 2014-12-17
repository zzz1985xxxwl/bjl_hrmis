//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FeedBackDetailPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-11-12
// 概述: 反馈信息Presenter
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class FeedBackDetailPresenter
    {
        private readonly IFeedBackDetailView _ItsView;
        private ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        private readonly Account _LoginUser;
        private int _CourseId;
        private int _EmployeeId;

        public List<TrainEmployeeFB> _TrainEmployeeFBs;

        public FeedBackDetailPresenter(IFeedBackDetailView itsView, string courseId, string employeeId,Account loginUser)
        {
            _ItsView = itsView;
            _ItsView.CourseId = courseId;
            _ItsView.EmployeeId = employeeId;
            _LoginUser = loginUser;
            EventAttach();
        }

        public void EventAttach()
        {
            _ItsView.BtnOKEvent += BtnOkEvent;
        }

        public void InitView(bool IsPostBack, bool isFrontPage)
        {
            _ItsView.PageTitle = "培训反馈信息详情";
            _ItsView.ErrorMessage = string.Empty;
            _ItsView.IsFrontPage = isFrontPage;

            if (ValidateCourseID() && ValidateEmployeeID())
            {
                try
                {            
                    Course  _course = _ITrainFacade.GetTrainCourseByPKID(_CourseId);
                    _ItsView.IsCertificationDisplay = _course.CertifactionDisplay;
                    _TrainEmployeeFBs = _ITrainFacade.GetTrainEmployeeFB(_EmployeeId, _CourseId, string.Empty, string.Empty, -1, null, null, _LoginUser,true);
                    _ItsView.CourseName = _TrainEmployeeFBs[0].CourseName;
                    _ItsView.Trainee = _TrainEmployeeFBs[0].Trainee.Name;
                    _ItsView.Comment = _TrainEmployeeFBs[0].Remark;
                    _ItsView.FBTime = _TrainEmployeeFBs[0].FBTime.ToString();
                    _ItsView.Score = "总分：" + _TrainEmployeeFBs[0].Score;
                    _ItsView.CertificationName = _TrainEmployeeFBs[0].CertificationName;
                }
                catch
                {
                    _ItsView.ErrorMessage = "初始化错误";
                }
            }
            if (!IsPostBack)
            {
                FBDataBind();
            }
        }


        private void FBDataBind()
        {
            if (ValidateCourseID() && ValidateEmployeeID())
            {
                _ItsView.Filled = _TrainEmployeeFBs[0].FBTime != null;
                _ItsView.FBItem = _ITrainFacade.GetTraineeFBItems(_CourseId, _EmployeeId);
            }
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

        private void BtnOkEvent()
        {
            _ItsView.returnLastPage = true;
        }

        /// <summary>
        /// use for test
        /// </summary>
        public ITrainFacade GetTrainCouse
        {
            set { _ITrainFacade = value; }
        }
    }
}
