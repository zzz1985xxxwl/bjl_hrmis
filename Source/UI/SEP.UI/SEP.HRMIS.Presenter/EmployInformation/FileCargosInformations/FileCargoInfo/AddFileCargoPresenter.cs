//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddFileCargoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-26
// ����: ������ְ��Ϣ�ĵ���С�����Presenter
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.EmployInformation.FileCargosInformations.FileCargoInfo
{
    public class AddFileCargoPresenter
    {
        private readonly IFileCargoView _ItsView;
        private readonly IFileCargoFacade _IFileCargoFacade = InstanceFactory.CreateFileCargoFacade();
        public AddFileCargoPresenter(IFileCargoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            _ItsView.BtnActionEvent += AddFileCargoEvent;
        }

        public void InitView()
        {
            _ItsView.Title = EmployeePresenterUtilitys._DimissionInfoFileCargoAdd;
            _ItsView.Id = string.Empty;
            _ItsView.Remark = string.Empty;
            _ItsView.FileCargoNameSource = FileCargoName.GetAll();
        }

        public void AddFileCargoEvent()
        {
            FileCargo aNewObject = new FileCargo(0, FileCargoName.FindFileCargoName(int.Parse(_ItsView.FileCargoName)), _ItsView.Remark, _ItsView.File,new Account(_ItsView.AccountID,"",""));
            _IFileCargoFacade.AddFileCargo(aNewObject);
            _ItsView.ActionSuccess = true;
        }
    }
}