using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Presenter.IPresenter.IDiyProcess;
using SEP.IBll;
using SEP.IBll.Accounts;

namespace SEP.HRMIS.Presenter.DiyProcesses
{
    public abstract class DiyProcessBasePresenter
    {
        protected abstract void AttachViewEvent();
        protected abstract void InitPresenter();

        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;

        protected readonly IDiyProcessView _ItsView;
        public DiyProcessBasePresenter(IDiyProcessView view)
        {
            _ItsView = view;
        }

        private int _DiyProcessID;
        public int DiyProcessID
        {
            get
            {
                return _DiyProcessID;
            }
            set
            {
                _DiyProcessID = value;
            }
        }

        public void InitView(bool isPagePostBack)
        {
            _ItsView.ddlTypeSelected += ddlTypeSelected;
            AttachViewEvent();
            GetAllSource();

            _ItsView.ResultMessage = string.Empty;

            if (!isPagePostBack)
            {
                _ItsView.NameMessage = string.Empty;
                GetProcessTypeSource();
            }
            _ItsView.SystemStatusSource = DiyProcessUtility.GetSystemStatusSource(_ItsView.ProcessType.Id);
            _ItsView.StatusSource = DiyProcessUtility.GetStatusSource(_ItsView.ProcessType.Id);
            if (!isPagePostBack)
            {
                InitPresenter();
            }
        }

        private void GetProcessTypeSource()
        {
            _ItsView.ProcessTypeSource = DiyProcessUtility.GetProcessTypeSource();
        }

        private void GetAllSource()
        {
            _ItsView.OperatorSource = DiyProcessUtility.GetOperatorSource();
            _ItsView.AccountList = _AccountBll.GetAllHRMisAccount();
        }

        public void ddlTypeSelected(object source, EventArgs e)
        {
            _ItsView.StatusSource = DiyProcessUtility.GetStatusSource(_ItsView.ProcessType.Id);
            _ItsView.SystemStatusSource = DiyProcessUtility.GetSystemStatusSource(_ItsView.ProcessType.Id);
            List<DiyStep> items = new List<DiyStep>();
            DiyProcessUtility.AddNullItem(_ItsView.ProcessType.Id,items);
            _ItsView.DiyStepList = items;
        }
    }
}
