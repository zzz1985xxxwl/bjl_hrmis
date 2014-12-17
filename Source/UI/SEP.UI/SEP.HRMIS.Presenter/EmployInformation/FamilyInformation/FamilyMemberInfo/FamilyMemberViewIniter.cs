//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: FamilyMemberViewIniter.cs
// ������: �ߺ�
// ��������: 2008-09-26
// ����: ��ͥ��Ա��ϢС����Ľ����ʼ����
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyMemberInfo
{
    public class FamilyMemberViewIniter : IViewIniter
    {
        private readonly IFamilyMemberView _ItsView;

        public FamilyMemberViewIniter(IFamilyMemberView itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheViewToDefault()
        {
            _ItsView.Id = string.Empty;
            _ItsView.Age = string.Empty;
            _ItsView.AgeMessage = string.Empty;
            _ItsView.Birthday = string.Empty;
            _ItsView.BirthdayMessage = string.Empty;
            _ItsView.Company = string.Empty;
            _ItsView.Name = string.Empty;
            _ItsView.NameMessage = string.Empty;
            _ItsView.Relationship = string.Empty;
            _ItsView.RelationshipMessage = string.Empty;
            _ItsView.Remark = string.Empty;
        }
    }
}