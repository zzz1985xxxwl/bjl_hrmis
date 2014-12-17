//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: FamilyMemberDataBinder.cs
// ������: �ߺ�
// ��������: 2008-09-04
// ����: ��ͥ��Ա��ϢС��������ݰ���
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;
using System;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyMemberInfo
{
    public class FamilyMemberDataBinder : IDataBinder<FamilyMember>
    {
        private readonly IFamilyMemberView _ItsView;

        public FamilyMemberDataBinder(IFamilyMemberView itsView)
        {
            _ItsView = itsView;
        }

        public bool DataBind(FamilyMember theDataToBind)
        {
            if (theDataToBind == null)
            {
                return false;
            }
            _ItsView.Id = theDataToBind.HashCode.ToString();
            _ItsView.Age = theDataToBind.Age.ToString();
            _ItsView.Birthday = theDataToBind.Birthday != null ? theDataToBind.Birthday.GetValueOrDefault().ToShortDateString() : "";
            _ItsView.Company = theDataToBind.Company;
            _ItsView.Name = theDataToBind.Name;
            _ItsView.Relationship = theDataToBind.Relationship;
            _ItsView.Remark = theDataToBind.Remark;
            return true;
        }
    }
}