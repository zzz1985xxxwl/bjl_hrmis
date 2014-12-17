//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ViewSkillBasicInfoPresenter.cs
// 创建者: 顾艳娟
// 创建日期: 2008-11-06
// 概述: 员工技能的Presenter
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView;

namespace SEP.HRMIS.Presenter.EmployInformation.SkillInformation.SkillBasicInfo
{
    public class ViewSkillBasicInfoPresenter : IViewEmployeePresenter
    {
        private readonly IEmployeeSkillView _ItsView;

        public ViewSkillBasicInfoPresenter(IEmployeeSkillView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            return new SkillBasicInfoDataBinder(_ItsView).DataBind(theDataToBind);
        }
        
        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                //Initer
                _ItsView.EmployeeSkillSource = new List<EmployeeSkill>();
                //_ItsView.SkillLevelTypeSource = SkillLevelType.AllSkillLevelTypes;

                _ItsView.btnAddClickVisible = false;
                _ItsView.btnUpdateClickVisible = false;
                _ItsView.btnDeleteClickVisible = false;
            }
            _ItsView.EmployeeSkill = _ItsView.EmployeeSkillSource;

        }

    }
}
