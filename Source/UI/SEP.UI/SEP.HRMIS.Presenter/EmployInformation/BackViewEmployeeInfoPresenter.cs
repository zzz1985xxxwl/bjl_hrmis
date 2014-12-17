//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BackViewEmployeeInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-10-09
// 概述: 后台查看员工总界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.WorkInformation;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation
{
    public class BackViewEmployeeInfoPresenter : ViewEmployeeInfoPresenterBase
    {
        public BackViewEmployeeInfoPresenter(IEmployeeInfoView itsView, string employeeId)
            : base(itsView, employeeId)
        {
            _ThePresenters.Add(new ViewWorkInfoPresenter(itsView.WorkInfoView, false));
        }
        /// <summary>
        /// 定义后台显示员工详情时，哪些信息不可见
        /// </summary>
        /// <param name="pageIsPostBack"></param>
        protected override void InitOthers(bool pageIsPostBack)
        {
            _ItsView.DimissionInfoVisible = true;
            _ItsView.VocationInfoVisible = true;
            _ItsView.MailToHRVisible = false;
            _ItsView.BtnExportVisible = false;
        }
    }
}
