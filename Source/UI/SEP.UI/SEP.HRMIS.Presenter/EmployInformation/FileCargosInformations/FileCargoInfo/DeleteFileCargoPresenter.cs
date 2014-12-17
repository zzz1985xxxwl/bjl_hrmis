//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteFileCargoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-26
// 概述: 删除离职信息的档案小界面的Presenter
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