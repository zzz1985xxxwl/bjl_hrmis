//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteFamilyMemberPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-26
// ����: ɾ����ͥ��Ϣ�ļ�ͥ��Ա
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyMemberInfo
{
    public class DeleteFamilyMemberPresenter
    {
        private readonly IFamilyMemberView _ItsView;

        public DeleteFamilyMemberPresenter(IFamilyMemberView itsView)
        {
            _ItsView = itsView;
        }

        public void Delete(string id)
        {
            if (_ItsView.FamilyMemberDataSource != null)
            {
                int index = 0;
                foreach (FamilyMember ee in _ItsView.FamilyMemberDataSource)
                {
                    if (ee.HashCode.ToString().Equals(id))
                    {
                        _ItsView.FamilyMemberDataSource.RemoveAt(index);
                        break;
                    }
                    index++;
                }
            }
        }
    }
}