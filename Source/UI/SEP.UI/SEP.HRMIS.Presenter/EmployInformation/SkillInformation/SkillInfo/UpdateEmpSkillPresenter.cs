//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateEmpSkillPresenter.cs
// 创建者: 顾艳娟
// 创建日期: 2008-11-06
// 概述: 修改员工技能小界面的Presenter
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.SkillInformation
{
    public class UpdateEmpSkillPresenter
    {
        private readonly IEmpSkillView _ItsView;
        private readonly string _Id;

        private ISkillFacade _ISkillFacade = InstanceFactory.CreateSkillFacade();
        private ISkillTypeFacade _ISkillTypeFacade = InstanceFactory.CreateSkillTypeFacade();
        private List<Skill> _Skills = new List<Skill>();


        public UpdateEmpSkillPresenter(IEmpSkillView itsView, string id)
        {
            _ItsView = itsView;
            AttachViewEvent();
            _Id = id;
        }

        public void Init()
        {
            _ItsView.Title = "修改技能";
            _ItsView.Id = string.Empty;
            new EmployeeSkillViewIniter(_ItsView).InitTheViewToDefault();

            int id;
            if (!int.TryParse(_Id, out id))
            {
                return;
            }
            EmployeeSkill theObject = FindEmployeeSkillById(id);
            if(theObject!=null)
            {
                _ItsView.Id = theObject.HashCode.ToString();
                //Source Info.
                _ItsView.SkillTypeSource = _ISkillTypeFacade.GetSkillTypeByCondition(-1, string.Empty);
                _ItsView.SkillLevelTypeSource = SkillLevelType.AllSkillLevelTypes;
                _ItsView.SkillSource = _ISkillFacade.GetSkillByCondition(string.Empty, theObject.Skill.SkillType.ParameterID);
                //Basic Info.
                _ItsView.SkillType =theObject.Skill.SkillType.ParameterID.ToString();
                _ItsView.Skill = theObject.Skill.SkillID.ToString();
                _ItsView.SkillLevel = ((Int32)theObject.SkillLevel).ToString();
                _ItsView.Score = theObject.Score.ToString();
                _ItsView.Remark = theObject.Remark;
            }

        }

        private EmployeeSkill FindEmployeeSkillById(int id)
        {
            if (_ItsView.EmployeeSkillSource != null)
            {
                foreach (EmployeeSkill sk in _ItsView.EmployeeSkillSource)
                {
                    if (sk.HashCode.Equals(id))
                    {
                        return sk;
                    }
                }
            }
            return null;

        }

        private void AttachViewEvent()
        {
            _ItsView.btnOKClick += UpdateEvent;
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

        private void UpdateEvent()
        {
            if (!new EmployeeSkillVaildater(_ItsView).Vaildate())
            {
                return;
            }

            if (VaildateSkill())
            {
                int theId;
                if (!int.TryParse(_Id, out theId))
                {
                    return;
                }
                new EmployeeSkillDataCollector(_ItsView).CompleteTheObject(FindEmployeeSkillById(theId));

                _ItsView.ActionSuccess = true;
            }
        }

        private bool VaildateSkill()
        {
            if (_ItsView.EmployeeSkillSource != null && _ItsView.EmployeeSkillSource.Count > 0)
            {
                foreach (EmployeeSkill ee in _ItsView.EmployeeSkillSource)
                {
                    if (ee.Skill.SkillID.ToString().Equals(_ItsView.Skill) && ee.HashCode != Convert.ToInt32(_ItsView.Id))
                    {
                        _ItsView.SkillMsg = EmployeePresenterUtilitys._SkillNameRepeat;
                        return false;

                    }
                }

            }
            return true;
        }
    }
}
