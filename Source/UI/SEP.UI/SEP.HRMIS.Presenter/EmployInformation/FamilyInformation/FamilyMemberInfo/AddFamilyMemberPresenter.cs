//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddFamilyMemberPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-26
// ����: ������ͥ��Ա��ϢС�����Presenter
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyMemberInfo
{
    public class AddFamilyMemberPresenter
    {
        private readonly IFamilyMemberView _ItsView;

        public AddFamilyMemberPresenter(IFamilyMemberView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.BtnActionEvent += AddEducationExperienceEvent;
        }

        public void InitView()
        {
            _ItsView.Title = EmployeePresenterUtilitys._FamilyMebmerAdd;
            new FamilyMemberViewIniter(_ItsView).InitTheViewToDefault();
        }

        public void AddEducationExperienceEvent()
        {
            if (!new FamilyMemberVaildater(_ItsView).Vaildate())
            {
                return;
            }
            FamilyMember aNewObject = new FamilyMember(null,null,null,0,null,null);
            new FamilyMemberDataCollector(_ItsView).CompleteTheObject(aNewObject);

            if(_ItsView.FamilyMemberDataSource == null)
            {
                _ItsView.FamilyMemberDataSource = new List<FamilyMember>();
            }
            _ItsView.FamilyMemberDataSource.Add(aNewObject);
            _ItsView.ActionSuccess = true;
        }
    }
}