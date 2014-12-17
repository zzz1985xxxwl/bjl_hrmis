//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CourseFeedBackListPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-11-12
// 概述: 查询课程相关反馈
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class CourseFeedBackListPresenter
    {
        private readonly IFeedBackBackSearchView _ItsView;
        //private IGetTrainCourse _GetTrainCourse = new GetTrainCourse();
        private ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        private readonly int _CourseId;
        private readonly Account _LoginUser;
        private List<TrainEmployeeFB> _TrainEmployeeFB;

        public CourseFeedBackListPresenter(IFeedBackBackSearchView itsView, string courseId, Account loginUser)
        {
            _ItsView = itsView;
            _LoginUser = loginUser;
            if (!int.TryParse(courseId, out _CourseId))
            {
                _ItsView.ResultMessage = "初始化错误";
                return;
            }
            AttachEvent();
        }

        private void AttachEvent()
        {
            _ItsView.listView.DataBind += BindData;
        }

        public void BindData()
        {
            SearchEvent(null, null);
        }

        public void SetIfFrontPage(bool value)
        {
            _ItsView.listView.SetIfFrontDetailPage = false;
        }

        public void InitView(bool IsPostBack)
        {
            new CourseFeedBackSearchIniter(_ItsView).Init();
            if (!IsPostBack)
            {
                SearchEvent(null, null);
                _ItsView.SetCourseName = true;
                _ItsView.TrainCourese = _ITrainFacade.GetTrainCourseByPKID(_CourseId).CourseName;
            }
        }


        public void SearchEvent(object sender, EventArgs e)
        {
            CourseFeedBackValidate va = new CourseFeedBackValidate(_ItsView);
            if (!va.Validate())
            {
                return;
            }
            try
            {
                _TrainEmployeeFB =
                    _ITrainFacade.GetTrainEmployeeFB(- 1, _CourseId, string.Empty, _ItsView.FBEmployee,
                                                       Convert.ToInt32(_ItsView.Status), va._OutStartFrom,
                                                       va._OutStartTo, _LoginUser,false);
                _ItsView.listView.employeeFBs = _TrainEmployeeFB;
                _ItsView.ResultMessage = _TrainEmployeeFB.Count.ToString();
            }
            catch (Exception ex)
            {
                _ItsView.ResultMessage = ex.Message;
            }
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
