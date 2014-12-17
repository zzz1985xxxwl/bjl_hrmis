using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class AddLeaveRequestPresenter : LeaveRequestPresenterBase
    {
        private readonly ILeaveRequestFacade _ILeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();

        public AddLeaveRequestPresenter(ILeaveRequestInfoView view)
            : base(view)
        {
        }

        protected override void InitPresenter()
        {
            _ItsView.LeaveRequestItemList = LeaveRequestUtility.AddNullItem(new List<LeaveRequestItem>());
            _ItsView.EmployeeName = EmployeeName;
            _ItsView.SetFormReadOnly = false;
            //_ItsView.SetFormCancel = false;
            DateTime now = DateTime.Now;
            DateTime show=new DateTime(now.Year,now.Month,now.Day,now.Hour,now.Minute,0);
            _ItsView.TimeSpan = show + " ～ " + show;
            _ItsView.CostTime = "0";
        }

        protected override void AttachViewEvent()
        {
            _ItsView.btnOKClick += SaveExecutEvent;
            _ItsView.btnSubmitClick += SubmitExecutEvent;
            _ItsView.LeaveRequestItemForAddAtEvent += LeaveRequestItemForAddAtEvent;
            _ItsView.LeaveRequestItemForDeleteAtEvent += LeaveRequestItemForDeleteEvent;
        }

        protected override void SetBtnStatus()
        {
            _ItsView.OperationType = "新增请假";
            _ItsView.btnOKText = "暂  存";
            _ItsView.btnCancelText = "提　交";
        }

        public event DelegateNoParameter GoToListPage;
        /// <summary>
        /// 新增
        /// </summary>
        private void SaveExecutEvent(object source, EventArgs e)
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

                    _ILeaveRequestFacade.AddLeaveRequest(leaveRequest);

                    GoToListPage();
                }
                catch (Exception ex)
                {
                    _ItsView.ResultMessage =ex.Message;
                }
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        private void SubmitExecutEvent(object source, EventArgs e)
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
                    _ILeaveRequestFacade.SubmitLeaveRequest(leaveRequest);

                    GoToListPage();
                }
                catch (Exception ex)
                {
                    _ItsView.ResultMessage =ex.Message;
                }
            }
        }
    }
}
