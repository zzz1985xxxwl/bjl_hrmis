//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FamilyMemberVaildater.cs
// 创建者: 倪豪
// 创建日期: 2008-09-26
// 概述: 家庭成员信息小界面的数据验证类
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyMemberInfo
{
    public class FamilyMemberVaildater : IVaildater
    {
        private readonly IFamilyMemberView _ItsView;

        public FamilyMemberVaildater(IFamilyMemberView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            bool MemberName = ValidateMemberName();
            bool MemberRelationship = ValidateRelationship();
            //bool MemberAge = ValidateAge();
            bool MemberBirthday = ValidateBirthday();
            return MemberName && MemberRelationship  //&& MemberAge 
                && MemberBirthday;
        }

        private bool ValidateBirthday()
        {
            if (!string.IsNullOrEmpty(_ItsView.Birthday))
            {
                DateTime dt;
                if (!DateTime.TryParse(_ItsView.Birthday, out dt))
                {
                    _ItsView.BirthdayMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                    return false;
                }
                _ItsView.BirthdayMessage = "";
            }
            return true;
        }

        public bool ValidateMemberName()
        {
            if (string.IsNullOrEmpty(_ItsView.Name))
            {
                _ItsView.NameMessage = EmployeePresenterUtilitys._FieldNotEmpty;
                return false;
            }
            _ItsView.NameMessage = "";
            return true;
        }

        public bool ValidateRelationship()
        {
            if (string.IsNullOrEmpty(_ItsView.Relationship))
            {
                _ItsView.RelationshipMessage = EmployeePresenterUtilitys._FieldNotEmpty;
                return false;
            }
            _ItsView.RelationshipMessage = "";
            return true;
        }

        //public bool ValidateAge()
        //{
        //    int _Age;
        //    if (string.IsNullOrEmpty(_ItsView.Age))
        //    {
        //        _ItsView.AgeMessage = EmployeePresenterUtilitys._FieldNotEmpty;
        //        return false;
        //    }
        //    if (!int.TryParse(_ItsView.Age, out _Age))
        //    {
        //        _ItsView.AgeMessage = EmployeePresenterUtilitys._FieldWrongFormat;
        //        return false;
        //    }
        //    _ItsView.AgeMessage = "";
        //    return true;
        //}
    }
}