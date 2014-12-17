using System;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class LeaveRequestDetailPresenter : LeaveRequestPresenterBase
    {
        public LeaveRequestDetailPresenter(ILeaveRequestInfoView itsView)
            : base(itsView)
        {
            _ItsView.NotCalculate = true;
        }

        protected override void SetBtnStatus()
        {
            _ItsView.OperationType = "�������";
            _ItsView.btnOKText = "ȷ  ��";
            _ItsView.btnCancelText = "ȡ����";
        }

        protected override void InitPresenter()
        {
            new LeaveRequestDataBinder(_ItsView).DataBind(LeaveRequestID);
            _ItsView.SetFormReadOnly = true;
            //_ItsView.SetFormCancel = false;
            ddlAbsentTypeSelected(null, null);
        }

        public event DelegateNoParameter GoToListPage;
        public void CancelEvent(object source, EventArgs e)
        {
            GoToListPage();
        }

        protected override void AttachViewEvent()
        {
            _ItsView.btnOKClick += CancelEvent;
            _ItsView.btnSubmitClick += CancelEvent;
        }
    }
}
