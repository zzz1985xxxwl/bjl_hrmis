using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class LeaveRequestItemHistoryPresenter
    {
        private readonly ILeaveRequestFacade _ILeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();

        private readonly ILeaveRequestItemHistoryView _View;
        public LeaveRequestItemHistoryPresenter(ILeaveRequestItemHistoryView view)
        {
            _View = view;
        }

        private int _LeaveRequestID;

        public int LeaveRequestID
        {
            get { return _LeaveRequestID; }
            set { _LeaveRequestID = value; }
        }

        public void InitView(bool isPostBack)
        {
            AttachViewEvent();

            if (!isPostBack)
            {
                BindLeaveRequestSource(null, null);
            }
        }

        /// <summary>
        /// 数据源绑定
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void BindLeaveRequestSource(object source, EventArgs e)
        {
            _View.LeaveRequestSource = _ILeaveRequestFacade.GetLeaveRequestFlowByLeaveRequestID(LeaveRequestID);
        }

        private void AttachViewEvent()
        {
            _View.BindLeaveRequestSource += BindLeaveRequestSource;
        }
    }
}
