//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: AddUpdateResumeInfoPresenterBase.cs
// 创建者: 倪豪
// 创建日期: 2008-9-24
// 概述: 新增/修改简历信息的Base类，将界面中与小界面相关的事件处理
//       单独抽出来做成该类，
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeEducationInfo;
using SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeWorkInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations
{
    public class AddUpdateResumeInfoPresenterBase
    {
        protected readonly IResumeInfoView _ItsView;
     
        public AddUpdateResumeInfoPresenterBase(IResumeInfoView itsView)
        {
            _ItsView = itsView;
            SwitchEducationPresenter();
            SwitchWorkPresenter();
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            //通过2个对象管理起来事件处理的程序
            new WorkExperienceEventHandler(_ItsView);
            new EducationExperienceEventsHandler(_ItsView);
        }

        /// <summary>
        /// 界面确定按钮绑定哪个Presenter
        /// </summary>
        private void SwitchEducationPresenter()
        {
            if (string.IsNullOrEmpty(_ItsView.ResumeEducationExperienceView.Id))
            {
                new AddResumeEducationExperiencePresenter(_ItsView.ResumeEducationExperienceView);
            }
            else
            {
                new UpdateResumeEducationExperiencePresenter(_ItsView.ResumeEducationExperienceView, _ItsView.ResumeEducationExperienceView.Id);
            }
        }

        /// <summary>
        /// 界面确定按钮绑定哪个Presenter
        /// </summary>
        private void SwitchWorkPresenter()
        {
            if (string.IsNullOrEmpty(_ItsView.ResumeWorkExperienceView.Id))
            {
                new AddResumeWorkExperiencePresenter(_ItsView.ResumeWorkExperienceView);
            }
            else
            {
                new UpdateResumeWorkExperiencePresenter(_ItsView.ResumeWorkExperienceView, _ItsView.ResumeWorkExperienceView.Id);
            }
        }
    }
}