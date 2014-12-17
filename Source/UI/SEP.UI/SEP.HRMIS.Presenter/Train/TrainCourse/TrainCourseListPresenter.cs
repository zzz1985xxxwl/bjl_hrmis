//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TrainCourseListPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-11-12
// 概述: 查询培训课程Presenter
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class TrainCourseListPresenter
    {
        private readonly ITrainCourseListView _ItsView;
        private ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        private readonly Account _LoginUser;
        public TrainCourseListPresenter(ITrainCourseListView itsView,Account loginUser)
        {
            _ItsView = itsView;
            _LoginUser = loginUser;
            AttachEvent();
        }

        private void AttachEvent()
        {
            _ItsView.DataBind += TrainCourseDataBind;
        }

        public void InitView(bool IsPostBack)
        {
            _ItsView.SetVisisle = false;
            if (!IsPostBack)
            {
                TrainCourseDataBind();
            }
        }

        private void TrainCourseDataBind()
        {
            List<Course> courses =
                _ITrainFacade.GetCourseByConditon(string.Empty, string.Empty, -1, -1, string.Empty, string.Empty, string.Empty, Convert.ToDateTime("1900-01-01"), Convert.ToDateTime("2999-12-31"), Convert.ToDateTime("1900-01-01"), Convert.ToDateTime("2999-12-31"), -1, -1, -1, -1, _LoginUser);
            _ItsView.Course = courses;
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
