//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateFamilyMemberPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-26
// ����: �޸ļ�ͥ��Ϣ�ļ�ͥ��ԱС����Ľ����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyMemberInfo
{
    public class UpdateFamilyMemberPresenter
    {
        private readonly IFamilyMemberView _ItsView;
        private readonly string _Id;

        public UpdateFamilyMemberPresenter(IFamilyMemberView itsView, string id)
        {
            _ItsView = itsView;
            _Id = id;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.BtnActionEvent += UpdateEducationExperienceEvent;
        }

        public void InitView()
        {
            _ItsView.Title = EmployeePresenterUtilitys._FamilyMebmerUpdate;
            new FamilyMemberViewIniter(_ItsView).InitTheViewToDefault();

            int id;
            if (!int.TryParse(_Id, out id))
            {
                return;
            }
            FamilyMember theObject = FindFamilyMemberById(id);
            new FamilyMemberDataBinder(_ItsView).DataBind(theObject);
        }

        private FamilyMember FindFamilyMemberById(int id)
        {
            if (_ItsView.FamilyMemberDataSource != null)
            {
                foreach (FamilyMember fm in _ItsView.FamilyMemberDataSource)
                {
                    if (fm.HashCode.Equals(id))
                    {
                        return fm;
                    }
                }
            }
            return null;
        }

        public void UpdateEducationExperienceEvent()
        {
            if (!new FamilyMemberVaildater(_ItsView).Vaildate())
            {
                return;
            }

            int theId;
            if (!int.TryParse(_Id, out theId))
            {
                return;
            }
            new FamilyMemberDataCollector(_ItsView).CompleteTheObject(FindFamilyMemberById(theId));
            _ItsView.ActionSuccess = true;
        }
    }
}