//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: DetailOutApplicationPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-04-15
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Presenter.IPresenter.IOutApplication;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.OutApplications
{
    public class DetailOutApplicationPresenter
    {
       private readonly IOutApplicationEditView _View;
        private readonly IOutApplicationFlowListView _OutApplicationFlowListView;
        private readonly IOutApplicationFacade _IOutApplication = InstanceFactory.CreateOutApplicationFacade();
        public DelegateNoParameter _CompleteEvent;

        public DetailOutApplicationPresenter(IOutApplicationEditView view,IOutApplicationFlowListView outApplicationFlowListView ,bool ispostBack)
        {
            _View = view;
            _OutApplicationFlowListView = outApplicationFlowListView;
            _View.ResultMessage = string.Empty;
            InitPresenter(ispostBack);
        }

        private void AttachViewEvent()
        {
            _OutApplicationFlowListView.BindOutApplicationFlowSource += GetFlowList;
        }

        private void InitPresenter(bool ispostback)
        {
            AttachViewEvent();
            _View.ReasonMessage = string.Empty;
            _View.ResultMessage = string.Empty;
            _View.OutLocationMessage = string.Empty;
            _View.NotCalculate = true;
            if (!ispostback)
            {
                GetFlowList();
                OutApplication outApplication =
                    _IOutApplication.GetOutApplicationByOutApplicationID(_View.ApplicationID);
                _View.EmployeeName = outApplication.Account.Name;
                _View.EmployeeID = outApplication.Account.Id;
                _View.ApplicationItemList = outApplication.Item;
                _View.TimeSpan = outApplication.FromDate + " ～ " + outApplication.ToDate;
                _View.CostTime = outApplication.CostTime.ToString();
                _View.OutLocation = outApplication.OutLocation;
                _View.Reason = outApplication.Reason;
                _View.SubmitDate = outApplication.SubmitDate;
                _View.OutType = outApplication.OutType;
                _View.OperationType = "外出详情";
                _View.btnOKText = "确  定";
                _View.btnCancelText = "取  消";
                _View.SetReadOnly = true;
            }
        }


        private void GetFlowList()
        {
            _OutApplicationFlowListView.OutApplicationFlowSource =
                _IOutApplication.GetOutApplicationFlowList(_View.ApplicationID);
        }
    }
}