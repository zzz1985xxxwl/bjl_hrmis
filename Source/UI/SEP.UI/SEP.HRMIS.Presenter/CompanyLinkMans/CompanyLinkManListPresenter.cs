//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PersonalInAndOutListPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-10-14
// 概述: 个人考勤信息列表Presenter
// ----------------------------------------------------------------

using System;
using PresenterCore = SEP.Presenter.Core;
using SEP.Model.Accounts;
using SEP.HRMIS.Presenter.IPresenter.ICompanyLinkMan;
using ComService.ServiceContracts;
using System.ServiceModel.Channels;
using SEP.Model.Utility;
using System.ServiceModel;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter
{
    public class CompanyLinkManListPresenter:IDisposable
    {
        private readonly ICompanyLinkListView _View;
        private readonly Account _LoginUser;
        private readonly  IContactServices _contactService;
        private readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();

        public CompanyLinkManListPresenter(ICompanyLinkListView listView, Account loginUser)
        {
            _contactService = new ChannelFactory<IContactServices>("BasicHttpBinding_ContactServices").CreateChannel();
            _View = listView;
            _LoginUser = loginUser;
            AttachViewEvent();
        }

        public void Initialize(bool isPostBack)
        {
       if (!isPostBack)
            DataBind();
        }

        public void DataBind()
        {
            _View.Message = string.Empty;
            int companyId = _IEmployeeFacade.GetEmployeeByAccountID(_LoginUser.Id).EmployeeDetails.Work.Company.DepartmentID;
            _View.Linkmans = _contactService.LoadSomeContactByName(CompanyConfig.SYSTEMID,0,companyId, _View.ContactName).Linkmans;

        }


        private void AttachViewEvent()
        {
            _View.BtnSearchEvent += DataBind;
        }

        #region IDisposable 成员

        public void Dispose()
        {
            if (_contactService != null)
            {
                IChannelFactory channel = _contactService as IChannelFactory;
                if (channel != null && channel.State != CommunicationState.Closed)
                {
                    channel.Close();
                }
            }
        }

        #endregion

        #region use for tests

        //note colbert 2
        //public IGetEmployee  GetEmployee
        //{
        //    set { _GetEmployee = value; }
        //}

        //public IAttendanceOutInRecord GetRecord
        //{
        //    set { _GetRecord = value; }
        //}

        //public IGetDepartment SetGetDepartment
        //{
        //    set
        //    {
        //        _Department = value;
        //    }
        //}
        #endregion
    }
}
