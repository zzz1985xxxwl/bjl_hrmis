using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class MyLeaveRequestListPresenter
    {
        private readonly ILeaveRequestFacade _ILeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();

        private readonly IMyLeaveRequestListView _View;
        public MyLeaveRequestListPresenter(IMyLeaveRequestListView view)
        {
            _View = view;
        }

        public void InitView(bool isPostBack, int employeeID)
        {
            AttachViewEvent();
            _View.EmployeeID = employeeID;

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
            _View.LeaveRequestSource = _ILeaveRequestFacade.GetLeaveRequestByAccountID(_View.EmployeeID);
        }

        private void AttachViewEvent()
        {
            _View.BindLeaveRequestSource += BindLeaveRequestSource;
        }
    }
}
