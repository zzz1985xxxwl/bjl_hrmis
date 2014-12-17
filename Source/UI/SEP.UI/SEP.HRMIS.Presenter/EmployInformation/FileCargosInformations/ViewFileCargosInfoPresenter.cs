//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ViewDimissionInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: �鿴��ְ��Ϣ���ܽ����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FileCargosInformations
{
    public class ViewFileCargosInfoPresenter 
    {
        private readonly FileCargosListPresenter _ListPresenter;

        public ViewFileCargosInfoPresenter(IFileCargoInfoView itsView, int accountid)
        {
            itsView.AccountID = accountid;
            _ListPresenter = new FileCargosListPresenter(itsView.FileCargoListView);
            InitView();
        }


        private void InitView()
        {
            _ListPresenter.InitView(false);
        }
    }
}