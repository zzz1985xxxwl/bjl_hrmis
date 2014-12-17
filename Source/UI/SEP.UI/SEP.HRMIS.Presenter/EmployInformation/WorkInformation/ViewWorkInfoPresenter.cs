//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ViewWorkInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-10-09
// 概述:查看工作信息界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.WorkInformation
{
    public class ViewWorkInfoPresenter : WorkInfoPresenterBase,IViewEmployeePresenter
    {
        /// <summary>
        /// 是否前台
        /// </summary>
        private readonly bool _IsFront;
        public ViewWorkInfoPresenter(IWorkInfoView itsView,bool isFront)
            :base(itsView)
        {
            _IsFront = isFront;
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            _ItsView.AccountIdForProcess = theDataToBind.Account.Id;
            bool retVal = new WorkInfoDataBinder(_ItsView, _IsFront).DataBind(theDataToBind);
            //_ItsView.DepartmentLeader = theDataToBind.Account.Dept.Leader.Name;
            //todo wsl
            FatherSelectChangeEvent();
            DepartmentSelectChangeEvent();
            return retVal;
        }

        public void AttachViewEvent()
        {
        }
        
        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                _ItsView.ContractManageVisible = false;
                new WorkInfoViewIniter(_ItsView).InitTheViewToDefault();
                //FatherSelectChangeEvent();
                //DepartmentSelectChangeEvent();
            }
            _ItsView.EmployeeContract = _ItsView.EmployeeContractDataSource;
        }
    }
}