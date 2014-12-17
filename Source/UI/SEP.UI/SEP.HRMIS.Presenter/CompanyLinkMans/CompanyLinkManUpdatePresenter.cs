//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PersonalInAndOutUpdatePresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-10-21
// 概述: 个人考勤详情修改
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
    public class CompanyLinkManUpdatePresenter : PresenterCore.BasePresenter
    {
        private readonly ICompnayLinkManView _View;
        private readonly CompanyLinkManUtilityPresenter _Utility;
        private readonly IContactServices _contactService;
        private readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();

        public CompanyLinkManUpdatePresenter(ICompnayLinkManView view, Account loginUser)
            : base(loginUser)
        {
            _contactService = new ChannelFactory<IContactServices>("BasicHttpBinding_ContactServices").CreateChannel();
            _View = view;
            _Utility = new CompanyLinkManUtilityPresenter(_View, loginUser);
            AttachViewEvent();
        }

        public void InitView(Guid id)
        {
            _Utility.InitTheViewToDefault();
            _View.OperationTitle = "修改共享联系人";
            _View.OperationType = "Update";
            _View.SetReadonly = false;
            _Utility.DataBind(id);
        }

        public void AttachViewEvent()
        {
            _View.ActionButtonEvent += UpdateEvent;
        }

        public void UpdateEvent()
        {
            try
            {
                //获取公司id
                int companyId = _IEmployeeFacade.GetEmployeeByAccountID(LoginUser.Id).EmployeeDetails.Work.Company.DepartmentID;
                //userid为0，代表为公司
                _contactService.SaveLinkman(CompanyConfig.SYSTEMID, 0,companyId, CompleteLogData());

                _View.ActionSuccess = true;
            }
            catch (Exception ae)
            {
                _View.Message = ae.Message;
            }
        }

        /// <summary>
        /// 收集日志数据
        /// </summary>
        /// <returns></returns>
        private Linkman CompleteLogData()
        {
            Linkman link = new Linkman(_View.LinkManId);
            link.Name = _View.LinkManName;
            LinkmanDetail temp;

            temp = new LinkmanDetail(InfoType.Num_Mobile, _View.MobileNo);
            link.Details.Add(temp);

            temp = new LinkmanDetail(InfoType.Addr_Home, _View.HomeNo);
            link.Details.Add(temp);
            temp = new LinkmanDetail(InfoType.Addr_Work, _View.OfficeNo);
            link.Details.Add(temp);
            temp = new LinkmanDetail(InfoType.Addr_Email, _View.EmailAddr);
            link.Details.Add(temp);
            return link;
        }

        public override void Initialize(bool isPostBack)
        {
       
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
    }
}
