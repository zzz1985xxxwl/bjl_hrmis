//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FamilyMemberDataBinder.cs
// 创建者: 倪豪
// 创建日期: 2008-09-04
// 概述: 家庭成员信息小界面的数据收集类
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyMemberInfo
{
    public class FamilyMemberDataCollector : IDataCollector<FamilyMember>
    {
        private readonly IFamilyMemberView _ItsView;

        public FamilyMemberDataCollector(IFamilyMemberView itsView)
        {
            _ItsView = itsView;
        }

        public void CompleteTheObject(FamilyMember theObjectToComplete)
        {
            if (theObjectToComplete != null)
            {
                //theObjectToComplete.Age = int.Parse(_ItsView.Age);
                if (string.IsNullOrEmpty(_ItsView.Birthday))
                {
                    theObjectToComplete.Birthday = null;
                }
                else
                {
                    theObjectToComplete.Birthday = DateTime.Parse(_ItsView.Birthday);
                }
                theObjectToComplete.Company = _ItsView.Company;
                theObjectToComplete.Name = _ItsView.Name;
                theObjectToComplete.Relationship = _ItsView.Relationship;
                theObjectToComplete.Remark = _ItsView.Remark;
            }
        }
    }
}