//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteFileCargoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-26
// ����: ɾ����ְ��Ϣ�ĵ���С�����Presenter
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FileCargosInformations.FileCargoInfo
{
    public class DeleteFileCargoPresenter
    {
        private readonly IFileCargoView _ItsView;
        private readonly IFileCargoFacade _IFileCargoFacade = InstanceFactory.CreateFileCargoFacade();
        public DeleteFileCargoPresenter(IFileCargoView itsView)
        {
            _ItsView = itsView;
        }

        public void Delete(string id)
        {
            _IFileCargoFacade.DeleteFileCargo(Convert.ToInt32(id));
        }
    }
}