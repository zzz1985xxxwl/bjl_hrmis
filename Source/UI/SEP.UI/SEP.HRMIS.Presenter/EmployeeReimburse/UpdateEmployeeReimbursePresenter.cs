using System;
using SEP.HRMIS.Presenter.EmployeeReimburse.Reimburse;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class UpdateEmployeeReimbursePresenter
    {
        private readonly ReimburseUpdatePresenter _ReimburseUpdatePresenter;
        private readonly IEmployeeReimburseView _IEmployeeReimburseView;

        public UpdateEmployeeReimbursePresenter(int reimburseID, Account  loginUser, IEmployeeReimburseView iEmployeeReimburseView)
        {
            _ReimburseUpdatePresenter = new ReimburseUpdatePresenter(reimburseID, loginUser, iEmployeeReimburseView.IReimburseView);
            _IEmployeeReimburseView = iEmployeeReimburseView;
        }
        public void InitView(bool pageIsPostBack)
        {
            AttachViewEvent();

            _ReimburseUpdatePresenter.Init(pageIsPostBack);
        }

        private void AttachViewEvent()
        {
            _ReimburseUpdatePresenter.ToMyReimbursePage += ToMyReimbursePage;
            new ReimburseItemEventsHandler(_IEmployeeReimburseView);
        }

        public event EventHandler ToMyReimbursePage;
    }
}
