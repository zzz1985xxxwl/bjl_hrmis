using System;
using SEP.HRMIS.Presenter.IPresenter.IDiyProcess;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.DiyProcesses
{
    public class DiyProcessDetailPresenter: DiyProcessBasePresenter
    {
        protected readonly IDiyProcessView _View;
        public DiyProcessDetailPresenter(IDiyProcessView view)
            : base(view)
        {
            _View = view;
        }

        protected override void AttachViewEvent()
        {
            _ItsView.btnOKClick += CancelEvent;
            _ItsView.btnSubmitClick += CancelEvent;
        }

        protected override void InitPresenter()
        {
            _ItsView.OperationType = "自定义流程详情";
            new DiyProcessDataBinder(_ItsView).DataBind(DiyProcessID);
            ddlTypeSelected(null, null);
            new DiyProcessDataBinder(_ItsView).DataBindDiyStepList(DiyProcessID);
            _ItsView.SetFormReadOnly = true;
        }

        public event DelegateNoParameter GoToListPage;
        public void CancelEvent(object source, EventArgs e)
        {
            GoToListPage();
        }
    }
}
