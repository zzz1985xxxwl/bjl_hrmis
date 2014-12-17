//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeSkillViewIniter.cs
// 创建者: 顾艳娟
// 创建日期: 2008-11-06
// 概述: 员工技能的Presenter
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.SkillInformation
{
    public class EmployeeSkillViewIniter : IViewIniter
    {
        private readonly IEmpSkillView _ItsView;
        private ISkillFacade _ISkillFacade = InstanceFactory.CreateSkillFacade();
        private ISkillTypeFacade _ISkillTypeFacade = InstanceFactory.CreateSkillTypeFacade();
        private List<Skill> _Skills=new List<Skill>( );

        public EmployeeSkillViewIniter(IEmpSkillView itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheViewToDefault()
        {
            //字段消息为空
            SetFiledAndMessageEmpty();
            //类型数据源绑定
            BindTypesSource();
        }

        private void BindTypesSource()
        {
            //技能类型
            List<SkillType> skillTypeSource = _ISkillTypeFacade.GetSkillTypeByCondition(-1, "");
            //技能
            if (skillTypeSource != null && skillTypeSource.Count>0)
            {
                _ItsView.SkillTypeSource = skillTypeSource;
                if (skillTypeSource.Count > 0)
                {
                    _ItsView.SkillType = skillTypeSource[0].ParameterID.ToString();
                    _Skills = _ISkillFacade.GetSkillByCondition("", Convert.ToInt32(_ItsView.SkillType));
                    _ItsView.SkillSource = _Skills;
                }
            }
            //技能等级
            _ItsView.SkillLevelTypeSource = SkillLevelType.AllSkillLevelTypes;
        }

        private void SetFiledAndMessageEmpty()
        {
            _ItsView.Id = string.Empty;
            _ItsView.SkillMsg = string.Empty;
            _ItsView.SkillTypeMsg = string.Empty;
            _ItsView.SkillLevelMsg = string.Empty;
            _ItsView.ScoreMsg = string.Empty;
        }

        #region user for tests

        public ISkillTypeFacade GetSkillType
        {
            set
            {
                _ISkillTypeFacade = value;
            }
        }

        public ISkillFacade GetSkill
        {
            set
            {
                _ISkillFacade = value;
            }
        }

        #endregion
    }
}
