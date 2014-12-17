//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CourseDetailPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-11-15
// 概述:培训课程详情
// ----------------------------------------------------------------

using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class CourseDetailPresenter
    {
        private readonly ICourseView _ItsView;
        public Model.Course _ANewObject;
        private readonly string _CourseId;

        public CourseDetailPresenter(ICourseView itsView, string courseId)
        {
            _ItsView = itsView;
            _CourseId = courseId;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += OkEvent;
        }

        public void InitView(bool isPostBack, bool IsFront)
        {
            _ItsView.Message = string.Empty;
            _ItsView.OperationTitle = CourseUtility.DetailPageTitle;
            _ItsView.OperationType = CourseUtility.DetailOperationType;
            if (!isPostBack)
            {
                new CourseInfoViewIniter(_ItsView).InitTheViewToDefault();
                new CourseDataBinder(_ItsView).DataBind(_CourseId);
            }
            _ItsView.SetBtnhiden = !IsFront;
        }

        public void OkEvent()
        {
            _ItsView.ActionSuccess = true;
        }
    }
}
