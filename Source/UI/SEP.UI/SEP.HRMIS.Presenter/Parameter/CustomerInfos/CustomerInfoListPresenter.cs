//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: CustomerInfoListPresenter.cs
// ������: ����
// ��������: 2009-08-17
// ����: �ͻ���Ϣ�б�Presenter
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IParamter.ICustomerInfo;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.Parameter.CustomerInfos
{
    public class CustomerInfoListPresenter
    {
        private readonly ICustomerInfoListView _View;
        private readonly ICustomerInfoFacade _IFacade = InstanceFactory.CreateCustomerInfoFacade();


        public CustomerInfoListPresenter(ICustomerInfoListView view)
        {
            _View = view;
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            _View.BtnSearchEvent += SearchEvent;
        }

        public void InitView(bool isPostBack)
        {
            _View.Message = string.Empty;
            if (!isPostBack)
            {
                SearchEvent();
            }
        }

        public void SearchEvent()
        {
            List<CustomerInfo> itsSource = _IFacade.GetCustomerInfoByNameLike( _View.CompnayName);
            _View.CustomerInfos = itsSource;
        }
    }
}
