//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PersonalInAndOutDeletePresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-10-21
// 概述: 个人考勤删除
// ----------------------------------------------------------------

using System;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;
using SEP.HRMIS.Presenter.IPresenter.ICompanyLinkMan;
using ComService.ServiceContracts;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SEP.HRMIS.Presenter
{
    public class CompanyLinkManDeletePresenter : PresenterCore.BasePresenter, IDisposable
    {
        private readonly ICompnayLinkManView _View;
        private readonly CompanyLinkManUtilityPresenter _Utility;
        private readonly IContactServices _contactService;

        public CompanyLinkManDeletePresenter(ICompnayLinkManView view, Account loginUser)
            : base(loginUser)
        {
            _contactService = new ChannelFactory<IContactServices>("BasicHttpBinding_ContactServices").CreateChannel();
            _View = view;
            _Utility = new CompanyLinkManUtilityPresenter(_View, loginUser);
            AttachViewEvent();
        }

        public void InitView(Guid guid)
        {
            _View.LinkManId = guid;
            _View.OperationTitle = "删除共享联系人";
            _View.OperationType = "Delete";
            _View.SetReadonly = true;
            _Utility.DataBind(guid);
        }


        public void AttachViewEvent()
        {
            _View.ActionButtonEvent += DeleteEvent;
        }

        public void DeleteEvent()
        {
             try
             {
                 _contactService.DeleteLinkman(_View.LinkManId);
                 _View.ActionSuccess = true;
             }
             catch (Exception ae)
             {
                 _View.Message = ae.Message;
             }
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
