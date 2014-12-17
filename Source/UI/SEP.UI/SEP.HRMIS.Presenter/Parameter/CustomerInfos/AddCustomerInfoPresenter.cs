//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddCustomerInfoPresenter.cs
// ������: ����
// ��������: 2009-08-17
// ����: �����ͻ���ϢPresenter
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IParamter.ICustomerInfo;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.Parameter.CustomerInfos
{
    public class AddCustomerInfoPresenter
    {
        private readonly ICustomerInfoView _ItsView;
        private readonly ICustomerInfoFacade _IFacade = InstanceFactory.CreateCustomerInfoFacade();

        public AddCustomerInfoPresenter(ICustomerInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += AddEvent;
        }

        public void InitView()
        {
            _ItsView.Message = string.Empty;
            _ItsView.CompanyName = string.Empty;
            _ItsView.CustomerInfoID = string.Empty;
            _ItsView.NameMsg = string.Empty;
            _ItsView.OperationTitle = "�����ͻ���Ϣ";
            _ItsView.OperationType = "Add";
        }

        public void AddEvent()
        {
            if (Vaildation())
            {
                try
                {
                    CustomerInfo info = new CustomerInfo(0, _ItsView.CompanyName);
                    _IFacade.InsertCustomerInfo(info);
                    _ItsView.ActionSuccess = true;
                }
                catch (Exception ex)
                {
                    _ItsView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

        public bool Vaildation()
        {
            if (string.IsNullOrEmpty(_ItsView.CompanyName.Trim()))
            {
                _ItsView.NameMsg = "����Ϊ��";
                return false;
            }
            _ItsView.NameMsg = string.Empty;
            return true;
        }

        public ICustomerInfoFacade CustomerInfoFacade
        {
            get { return _IFacade; }
        }
    }
}
