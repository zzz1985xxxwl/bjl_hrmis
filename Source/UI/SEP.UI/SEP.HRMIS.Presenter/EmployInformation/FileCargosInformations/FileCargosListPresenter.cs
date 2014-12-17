//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FileCargosListPresenter.cs
// 创建者: liudan
// 创建日期: 200-07-06
// 概述: 档案列表
// ----------------------------------------------------------------
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FileCargosInformations
{
    public class FileCargosListPresenter
    {
        private readonly IFileCargoListView _ItsView;
        private readonly IFileCargoFacade _IFileCargoFacade = InstanceFactory.CreateFileCargoFacade();
        public FileCargosListPresenter(IFileCargoListView itsView)
        {
            _ItsView = itsView;
            Init();
            AttachEvent();
        }

        private void AttachEvent()
        {
            _ItsView.GetFileList += Init;
        }

        private void Init()
        {
            _ItsView.FileCargoDataView = _IFileCargoFacade.GetFileCargoByAccountID(_ItsView.AccountID);
        }

        public void InitView(bool showbutton)
        {

                _ItsView.BtnAddFileCargoVisible = showbutton;
                _ItsView.BtnUpdateFileCargoVisible = showbutton;
                _ItsView.BtnDeleteFileCargoVisible = showbutton;
        }
    }
}
