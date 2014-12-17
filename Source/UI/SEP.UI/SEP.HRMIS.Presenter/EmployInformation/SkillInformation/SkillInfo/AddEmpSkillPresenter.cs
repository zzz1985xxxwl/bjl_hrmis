//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddEmployeeSkillPresenter.cs
// 创建者: 顾艳娟
// 创建日期: 2008-11-06
// 概述: 新增员工技能的Presenter
// ----------------------------------------------------------------


using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.SkillInformation
{
    public class AddEmpSkillPresenter
    {
        private readonly IEmpSkillView _ItsView;

        private ISkillFacade _ISkillFacade = InstanceFactory.CreateSkillFacade();
        private List<Skill> _Skills = new List<Skill>();


        public AddEmpSkillPresenter(IEmpSkillView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void Init()
        {
            _ItsView.Score = "0";
            _ItsView.Remark = string.Empty;
            _ItsView.Title = "新增技能";
            new EmployeeSkillViewIniter(_ItsView).InitTheViewToDefault();
        }

        private void AttachViewEvent()
        {
            _ItsView.btnOKClick += btnOKClick;
            _ItsView.SkillTypeSelectChangeEvent += SelectChangeEvent;
        }

        private void SelectChangeEvent()
        {
            _ItsView.SkillMsg = string.Empty;

            _Skills = _ISkillFacade.GetSkillByCondition("", Convert.ToInt32(_ItsView.SkillType));
            _ItsView.SkillSource = _Skills;
            if (_Skills != null && _Skills.Count > 0)
            {
                _ItsView.Skill = _Skills[0].SkillID.ToString();
            }
            else
            {
                _ItsView.SkillMsg = EmployeePresenterUtilitys._SkillSourceNull;
            }
            _ItsView.ActionSuccess = false;
        }


        private void btnOKClick()
        {
            if (!new EmployeeSkillVaildater(_ItsView).Vaildate())
            {
                return;
            }

            EmployeeSkill aNewObject = new EmployeeSkill(null, SkillLevelEnum.All);
            new EmployeeSkillDataCollector(_ItsView).CompleteTheObject(aNewObject);

            if (_ItsView.EmployeeSkillSource == null)
            {
                _ItsView.EmployeeSkillSource = new List<EmployeeSkill>();
            }
            _ItsView.EmployeeSkillSource.Add(aNewObject);
            _ItsView.ActionSuccess = true;

        }


    }
}
