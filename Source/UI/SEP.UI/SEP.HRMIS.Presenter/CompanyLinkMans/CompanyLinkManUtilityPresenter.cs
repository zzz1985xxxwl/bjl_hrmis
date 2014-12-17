//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PersonalInAndOutUtilityPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-10-21
// 概述: 个人考勤详情的公共方法
// ----------------------------------------------------------------

using System;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;
using SEP.HRMIS.Presenter.IPresenter.ICompanyLinkMan;
using ComService.ServiceContracts;
using System.ServiceModel;
using System.ServiceModel.Channels;
using SEP.Model.Utility;
using ComService.ServiceModels;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter
{
    public class CompanyLinkManUtilityPresenter : PresenterCore.BasePresenter, IDisposable
    {
        private readonly ICompnayLinkManView _View;
        private readonly IContactServices _contactService;
        private readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();

        public CompanyLinkManUtilityPresenter(ICompnayLinkManView view, Account loginUser)
            : base(loginUser)
        {
            _contactService = new ChannelFactory<IContactServices>("BasicHttpBinding_ContactServices").CreateChannel();
            _View = view;
        }

        public void InitTheViewToDefault()
        {
            _View.HomeNo = string.Empty;
            _View.LinkManName = string.Empty;
            _View.Message = string.Empty;
            _View.MobileNo = string.Empty;
            _View.HomeNo = string.Empty;
            _View.OfficeNo = string.Empty;
            _View.EmailAddr = string.Empty;
        }

        public void DataBind(Guid guid)
        {
            //获取登录员工公司id
            int companyId = _IEmployeeFacade.GetEmployeeByAccountID(LoginUser.Id).EmployeeDetails.Work.Company.DepartmentID;
            Linkman linkman = _contactService.LoadSomeContactByName(CompanyConfig.SYSTEMID, 0, companyId, string.Empty).GetLinkmanById(guid);

            _View.LinkManId = linkman.Id;
            _View.LinkManName = linkman.Name;
            LinkmanDetail temp = linkman.GetLinkmanDetailByType(InfoType.Num_Mobile);
            _View.MobileNo = temp.Value;

            temp = linkman.GetLinkmanDetailByType(InfoType.Addr_Home);
            _View.HomeNo = temp.Value;
            //ViewState["home"] = temp.Id;

            temp = linkman.GetLinkmanDetailByType(InfoType.Addr_Work);
            _View.OfficeNo = temp.Value;
            //ViewState["work"] = temp.Id;

            temp = linkman.GetLinkmanDetailByType(InfoType.Addr_Email);
            _View.EmailAddr = temp.Value;
            //ViewState["email"] = temp.Id;
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


        public override void Initialize(bool isPostBack)
        {
        }
    }
}
