using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class MyLeaveRequestConfirmListPresenter : PresenterCore.BasePresenter
    {
        private readonly ILeaveRequestFacade _ILeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();
        private readonly IMyLeaveRequestConfirmListView _ItsView;

        public MyLeaveRequestConfirmListPresenter(IMyLeaveRequestConfirmListView view, Account loginUser)
            : base(loginUser)
        {
            _ItsView = view;
        }

        public override void Initialize(bool isPostBack)
        {
            AttachViewEvent();

            if (!isPostBack)
            {
                BindLeaveRequestSource(null, null);
            }
        }

        public event CommandEventHandler btnViewClick;
        private void AttachViewEvent()
        {
            _ItsView.btnViewClick += btnViewClick;
            _ItsView.BindLeaveRequestSource += BindLeaveRequestSource;
        }

        private void BindLeaveRequestSource(object sender, EventArgs e)
        {
            _ItsView.LeaveRequestSource = _ILeaveRequestFacade.GetConfirmLeaveRequest(LoginUser.Id);
        }
    }
}