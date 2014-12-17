//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeSkillDataCollector.cs
// 创建者: 顾艳娟
// 创建日期: 2008-11-06
// 概述: 员工技能小界面的数据收集类
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.SkillInformation
{
    public class EmployeeSkillDataCollector : IDataCollector<EmployeeSkill>
    {
        private readonly IEmpSkillView _ItsView;
        private ISkillTypeFacade _ISkillTypeFacade = InstanceFactory.CreateSkillTypeFacade();
        private ISkillFacade _ISkillFacade = InstanceFactory.CreateSkillFacade();


        public EmployeeSkillDataCollector(IEmpSkillView itsView)
        {
            _ItsView = itsView;
        }

        public void CompleteTheObject(EmployeeSkill theObjectToComplete)
        {
            if (theObjectToComplete != null)
            {
                if (theObjectToComplete.Skill == null)
                {
                    theObjectToComplete.Skill = new Skill(1, "", null);
                    if(theObjectToComplete.Skill.SkillType==null)
                    {
                        theObjectToComplete.Skill.SkillType=new  SkillType(1,"");
                    }
                }
                theObjectToComplete.Skill.SkillType.ParameterID = _ISkillTypeFacade.GetSkillTypeByPKID(Convert.ToInt32(_ItsView.SkillType)).ParameterID;
                theObjectToComplete.Skill.SkillType.Name = _ISkillTypeFacade.GetSkillTypeByPKID(Convert.ToInt32(_ItsView.SkillType)).Name;

                theObjectToComplete.Skill.SkillID =
                    _ISkillFacade.GetSkillByPKID(Convert.ToInt32(_ItsView.Skill)).SkillID;
                theObjectToComplete.Skill.SkillName =
                    _ISkillFacade.GetSkillByPKID(Convert.ToInt32(_ItsView.Skill)).SkillName;

                theObjectToComplete.SkillLevelType = SkillLevelType.GetById(int.Parse(_ItsView.SkillLevel));
                theObjectToComplete.SkillLevel = (SkillLevelEnum)int.Parse(_ItsView.SkillLevel);

                theObjectToComplete.Remark = _ItsView.Remark;
                theObjectToComplete.Score = Convert.ToDecimal(_ItsView.Score);
            }
        
        }
    }
}
