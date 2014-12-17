//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddDimissionInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: ������ְ��Ϣ���ܽ����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FileCargosInformations
{
    public class AddFileCargosInfoPresenter : AddFileCargosPresenterBase
    {
        private readonly FileCargosListPresenter _ListPresenter;

        /// <summary>
        /// �̳�AddUpdateDimissionPresenterBase����С����֮��Ĳ���
        /// </summary>
        public AddFileCargosInfoPresenter(IFileCargoInfoView itsView, int accountid)
            : base(itsView)
        {
            itsView.AccountID = accountid;
            _ListPresenter = new FileCargosListPresenter(itsView.FileCargoListView);
            InitView();
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        public void InitView()
        {
            _ListPresenter.InitView(true);
        }
    }
}