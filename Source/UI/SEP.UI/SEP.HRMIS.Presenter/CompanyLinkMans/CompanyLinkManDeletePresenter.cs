//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: PersonalInAndOutDeletePresenter.cs
// ������: ����
// ��������: 2008-10-21
// ����: ���˿���ɾ��
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
            _View.OperationTitle = "ɾ��������ϵ��";
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

        #region IDisposable ��Ա

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
