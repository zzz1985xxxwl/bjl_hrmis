using System;
using SEP.HRMIS.Presenter.EmployeeReimburse.Reimburse;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class DeleteEmployeeReimbursePresenter
    {
        private readonly ReimburseDeletePresenter _ReimburseDeletePresenter;
        private IEmployeeReimburseView _IEmployeeReimburseView;

        public DeleteEmployeeReimbursePresenter(int reimburseID, Account loginUser, IEmployeeReimburseView iEmployeeReimburseView)
        {
            _ReimburseDeletePresenter = new ReimburseDeletePresenter(reimburseID, loginUser, iEmployeeReimburseView.IReimburseView);
            _IEmployeeReimburseView = iEmployeeReimburseView;
        }
        public void InitView(bool pageIsPostBack)
        {
            AttachViewEvent();

            _ReimburseDeletePresenter.Init(pageIsPostBack);
        }

        private void AttachViewEvent()
        {
            _ReimburseDeletePresenter.ToMyReimbursePage += ToMyReimbursePage;
            new ReimburseItemEventsHandler(_IEmployeeReimburseView);
        }

        public event EventHandler ToMyReimbursePage;
    }
}
