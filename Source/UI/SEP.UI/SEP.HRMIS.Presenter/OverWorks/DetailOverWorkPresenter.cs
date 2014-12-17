//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: DetailOverWorkPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-04-15
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.OverWorks
{
    public class DetailOverWorkPresenter
    {
       private readonly IOverWorkEditView _View;
        private readonly IOverWorkFlowListView _OverWorkFlowListView;
        private readonly IOverWorkFacade _IOverWork = InstanceFactory.CreateOverWorkFacade();
        public DelegateNoParameter _CompleteEvent;

        public DetailOverWorkPresenter(IOverWorkEditView view,IOverWorkFlowListView OverWorkFlowListView ,bool ispostBack)
        {
            _View = view;
            _OverWorkFlowListView = OverWorkFlowListView;
            _View.ResultMessage = string.Empty;
            InitPresenter(ispostBack);
        }

        private void AttachViewEvent()
        {
            _OverWorkFlowListView.BindOverWorkFlowSource += GetFlowList;
        }

        private void InitPresenter(bool ispostback)
        {
            AttachViewEvent();
            _View.ReasonMessage = string.Empty;
            _View.ResultMessage = string.Empty;
            _View.ProjectNameMessage = string.Empty;
            _View.NotCalculate = true;
            if (!ispostback)
            {
                GetFlowList();
                OverWork OverWork =
                    _IOverWork.GetOverWorkByOverWorkID(_View.ApplicationID);
                _View.EmployeeName = OverWork.Account.Name;
                _View.EmployeeID = OverWork.Account.Id;
                _View.ApplicationItemList = OverWork.Item;
                _View.TimeSpan = OverWork.FromDate + " ～ " + OverWork.ToDate;
                _View.CostTime = OverWork.CostTime.ToString();
                _View.ProjectName = OverWork.ProjectName;
                _View.Reason = OverWork.Reason;
                _View.SubmitDate = OverWork.SubmitDate;
                _View.OperationType = "加班详情";
                _View.btnOKText = "确  定";
                _View.btnCancelText = "取  消";
                _View.SetReadOnly = true;
            }
        }


        private void GetFlowList()
        {
            _OverWorkFlowListView.OverWorkFlowSource =
                _IOverWork.GetOverWorkFlowList(_View.ApplicationID);
        }
    }
}