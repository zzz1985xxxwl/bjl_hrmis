using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class DeleteLeaveRequestPresenter : LeaveRequestPresenterBase
    {
        private readonly ILeaveRequestFacade _ILeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();

        public DeleteLeaveRequestPresenter(ILeaveRequestInfoView itsView)
            : base(itsView)
        {
        }

        public event DelegateNoParameter GoToListPage;
        public void DeleteEvent(object source, EventArgs e)
        {
            try
            {
                _ItsView.ResultMessage = string.Empty;
                _ILeaveRequestFacade.DeleteLeaveRequest(Convert.ToInt32(_ItsView.LeaveRequestID));

                GoToListPage();
            }
            catch (Exception ex)
            {
                _ItsView.ResultMessage =ex.Message;
            }
        }

        public void CancelEvent(object source, EventArgs e)
        {
            GoToListPage();
        }

        protected override void SetBtnStatus()
        {
            _ItsView.OperationType = "删除请假";
            _ItsView.btnOKText = "确  定";
            _ItsView.btnCancelText = "取　消";
        }

        protected override void InitPresenter()
        {
            new LeaveRequestDataBinder(_ItsView).DataBind(LeaveRequestID);
            _ItsView.SetFormReadOnly = true;
            //_ItsView.SetFormCancel = false;
            ddlAbsentTypeSelected(null, null);
        }

        protected override void AttachViewEvent()
        {
            _ItsView.btnOKClick += DeleteEvent;
            _ItsView.btnSubmitClick += CancelEvent;
        }
    }
}
