using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class UpdateLeaveRequestPresenter : LeaveRequestPresenterBase
    {
        private readonly ILeaveRequestFacade _ILeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();

        public UpdateLeaveRequestPresenter(ILeaveRequestInfoView itsView)
            : base(itsView)
        {
        }

        public event DelegateNoParameter GoToListPage;
        public void UpdateEvent(object source, EventArgs e)
        {
            LeaveRequestValidater leaveRequestValidater = new LeaveRequestValidater(_ItsView);
            if (leaveRequestValidater.Vaildate())
            {
                try
                {
                    _ItsView.ResultMessage = string.Empty;
                    LeaveRequestDataCollector dataCollector = new LeaveRequestDataCollector(_ItsView);
                    LeaveRequest leaveRequest = new LeaveRequest();
                    dataCollector.CompleteTheObject(ref leaveRequest);

                    _ILeaveRequestFacade.UpdateLeaveRequest(leaveRequest);

                    GoToListPage();
                }
                catch (Exception ex)
                {
                    _ItsView.ResultMessage =ex.Message ;
                }
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public void SubmitExecutEvent(object source, EventArgs e)
        {
            LeaveRequestValidater leaveRequestValidater = new LeaveRequestValidater(_ItsView);
            if (leaveRequestValidater.Vaildate())
            {
                try
                {
                    _ItsView.ResultMessage = string.Empty;
                    LeaveRequestDataCollector dataCollector = new LeaveRequestDataCollector(_ItsView);
                    LeaveRequest leaveRequest = new LeaveRequest();
                    dataCollector.CompleteTheObject(ref leaveRequest);
                    _ILeaveRequestFacade.UpdateSubmitLeaveRequest(leaveRequest);

                    GoToListPage();
                }
                catch (Exception ex)
                {
                    _ItsView.ResultMessage =ex.Message ;
                }
            }
        }

        protected override void SetBtnStatus()
        {
            _ItsView.OperationType = "修改请假";
            _ItsView.btnOKText = "暂  存";
            _ItsView.btnCancelText = "提　交";
        }

        protected override void InitPresenter()
        {
            new LeaveRequestDataBinder(_ItsView).DataBind(LeaveRequestID);
            _ItsView.SetFormReadOnly = false;
            ddlAbsentTypeSelected(null, null);
        }

        protected override void AttachViewEvent()
        {
            _ItsView.btnOKClick += UpdateEvent;
            _ItsView.btnSubmitClick += SubmitExecutEvent;
            _ItsView.LeaveRequestItemForAddAtEvent += LeaveRequestItemForAddAtEvent;
            _ItsView.LeaveRequestItemForDeleteAtEvent += LeaveRequestItemForDeleteEvent;
        }
    }
}