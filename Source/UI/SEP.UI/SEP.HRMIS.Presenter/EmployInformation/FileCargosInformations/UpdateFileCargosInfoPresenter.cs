//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateDimissionInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: �޸���ְ��Ϣ���ܽ����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FileCargosInformations
{
    public class UpdateFileCargosInfoPresenter : AddFileCargosPresenterBase
    {
        private readonly FileCargosListPresenter _ListPresenter;

        public UpdateFileCargosInfoPresenter(IFileCargoInfoView itsView,int accountid)
            :base(itsView)
        {
            itsView.AccountID = accountid;
            _ListPresenter = new FileCargosListPresenter(itsView.FileCargoListView);
            InitView();
        }


        private void InitView()
        {
            _ListPresenter.InitView(true);
        }

    }
}