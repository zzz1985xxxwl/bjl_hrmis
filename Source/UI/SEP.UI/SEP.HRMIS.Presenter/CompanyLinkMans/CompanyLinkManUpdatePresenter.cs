//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: PersonalInAndOutUpdatePresenter.cs
// ������: ����
// ��������: 2008-10-21
// ����: ���˿��������޸�
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
            _View.OperationTitle = "�޸Ĺ�����ϵ��";
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
                //��ȡ��˾id
                int companyId = _IEmployeeFacade.GetEmployeeByAccountID(LoginUser.Id).EmployeeDetails.Work.Company.DepartmentID;
                //useridΪ0������Ϊ��˾
                _contactService.SaveLinkman(CompanyConfig.SYSTEMID, 0,companyId, CompleteLogData());

                _View.ActionSuccess = true;
            }
            catch (Exception ae)
            {
                _View.Message = ae.Message;
            }
        }

        /// <summary>
        /// �ռ���־����
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
