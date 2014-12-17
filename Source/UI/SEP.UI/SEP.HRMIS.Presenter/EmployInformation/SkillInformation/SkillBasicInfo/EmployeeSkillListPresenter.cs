//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeSkillListPresenter.cs
// 创建者: 顾艳娟
// 创建日期: 2008-11-06
// 概述: 员工技能的Presenter
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.EmployInformation.SkillInformation.SkillBasicInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView;

namespace SEP.HRMIS.Presenter.EmployInformation.SkillInformation
{
    public class EmployeeSkillListPresenter : IAddEmployeePresenter
    {
        private readonly IEmployeeSkillView _ItsView;


        public EmployeeSkillListPresenter(IEmployeeSkillView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void InitView(bool isPostBack)
        {           

            if (!isPostBack)
            {
                //Session数据为空
                _ItsView.EmployeeSkillSource = new List<EmployeeSkill>();

                _ItsView.btnAddClickVisible = true;
                _ItsView.btnUpdateClickVisible = true;
                _ItsView.btnDeleteClickVisible = true;
            }
            _ItsView.EmployeeSkill = _ItsView.EmployeeSkillSource;
        }

        public bool Vaildate()
        {
            return true;
        }


        public void CompleteTheObject(Employee theObjectToComplete)
        {
            new SkillBasicInfoDataCollector(_ItsView).CompleteTheObject(theObjectToComplete);
        }


        public void AttachViewEvent()
        {
        }

    }
}
