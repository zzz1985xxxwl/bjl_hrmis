//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeSkillViewIniter.cs
// 创建者: 顾艳娟
// 创建日期: 2008-11-06
// 概述: 员工技能的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.SkillInformation.SkillInfo
{
    public class DeleteEmpSkillPresenter
    {
        private readonly IEmpSkillView _ItsView;

        public DeleteEmpSkillPresenter(IEmpSkillView itsView)
        {
            _ItsView = itsView;
        }

        public void Delete(string id)
        {
            if (_ItsView.EmployeeSkillSource != null)
            {
                int index = 0;
                foreach (EmployeeSkill ee in _ItsView.EmployeeSkillSource)
                {
                    if (ee.HashCode.ToString().Equals(id))
                    {
                        _ItsView.EmployeeSkillSource.RemoveAt(index);
                        break;
                    }
                    index++;
                }
            }

        }


    }
}
