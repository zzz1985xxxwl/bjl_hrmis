//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddDimissionInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 新增离职信息的总界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FileCargosInformations
{
    public class AddFileCargosInfoPresenter : AddFileCargosPresenterBase
    {
        private readonly FileCargosListPresenter _ListPresenter;

        /// <summary>
        /// 继承AddUpdateDimissionPresenterBase，大小界面之间的操作
        /// </summary>
        public AddFileCargosInfoPresenter(IFileCargoInfoView itsView, int accountid)
            : base(itsView)
        {
            itsView.AccountID = accountid;
            _ListPresenter = new FileCargosListPresenter(itsView.FileCargoListView);
            InitView();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void InitView()
        {
            _ListPresenter.InitView(true);
        }
    }
}