//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeSkillVaildater.cs
// 创建者: 顾艳娟
// 创建日期: 2008-11-06
// 概述: 员工技能的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.SkillInformation
{
    public class EmployeeSkillVaildater : IVaildater
    {
        private readonly IEmpSkillView _ItsView;

        public EmployeeSkillVaildater(IEmpSkillView itsView)
        {
            _ItsView = itsView;
        }


        public bool Vaildate()
        {
            bool SkillType = VaildateSkillType();
            bool Skill = VaildateSkill();
            bool SkillLevel = VaildateSkillLevel();
            return SkillType && Skill && SkillLevel;
        }

        private bool VaildateSkillType()
        {
            if(string.IsNullOrEmpty(_ItsView.SkillType))
            {
                _ItsView.SkillTypeMsg = EmployeePresenterUtilitys._FieldNotEmpty;
                return false;
            }
            return true;
        }

        private bool VaildateSkill()
        {
            if (string.IsNullOrEmpty(_ItsView.Skill))
            {
                _ItsView.SkillMsg = EmployeePresenterUtilitys._FieldNotEmpty;
                return false;
            }
            return true;
        }

        private bool VaildateSkillLevel()
        {
            bool ret = true;
            if (string.IsNullOrEmpty(_ItsView.SkillLevel))
            {
                _ItsView.SkillLevelMsg = EmployeePresenterUtilitys._FieldNotEmpty;
                ret = false;
            }
            int i;
            if (!int.TryParse(_ItsView.Score, out i))
            {
                _ItsView.ScoreMsg = EmployeePresenterUtilitys._FieldWrongFormat;
                ret = false;
            }
            return ret;
        }
    }
}
