//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteCustomerInfoPresenter.cs
// 创建者: 刘丹
// 创建日期: 2009-08-17
// 概述: 新增客户信息Presenter
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IParamter.ICustomerInfo;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.Parameter.CustomerInfos
{
    public class DeleteCustomerInfoPresenter
    {
        private readonly ICustomerInfoView _ItsView;
        private readonly ICustomerInfoFacade _IFacade = InstanceFactory.CreateCustomerInfoFacade();

        public DeleteCustomerInfoPresenter(ICustomerInfoView view)
        {
            _ItsView = view;
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += DeleteEvent;
        }

        public void InitView(string id)
        {
            _ItsView.Message = string.Empty;
            _ItsView.CompanyName = string.Empty;
            _ItsView.CustomerInfoID = id;
            _ItsView.NameMsg = string.Empty;
            _ItsView.OperationTitle = "删除客户信息";
            _ItsView.OperationType = "Delete";
            DataBind();
        }

        private void DataBind()
        {
            int _ID;
            if (!VaildateId(_ItsView.CustomerInfoID, out _ID))
            {
                return;
            }
            try
            {
               CustomerInfo info= _IFacade.GetCustomerInfoByID(_ID);
                _ItsView.CompanyName = info.CompanyName;
            }
            catch (ApplicationException ex)
            {
                _ItsView.Message = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        public void DeleteEvent()
        {
            int _ID;
            if (!VaildateId(_ItsView.CustomerInfoID, out _ID))
            {
                return;
            }
            try
            {
                _IFacade.DeleteCustomerInfo(_ID);
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ex)
            {
                _ItsView.Message = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        private bool VaildateId(string id, out int Id)
        {
            if (!int.TryParse(id, out Id))
            {
                _ItsView.Message = "删除的记录ID不正确";
                return false;
            }
            return true;
        }


        public ICustomerInfoFacade CustomerInfoFacade
        {
            get { return _IFacade; }
        }
    }
}
