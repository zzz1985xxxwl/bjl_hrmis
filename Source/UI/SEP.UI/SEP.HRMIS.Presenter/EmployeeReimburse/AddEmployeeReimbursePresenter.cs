using System;
using PresenterCore = SEP.Presenter.Core;
using SEP.HRMIS.Presenter.EmployeeReimburse.Reimburse;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class AddEmployeeReimbursePresenter : PresenterCore.BasePresenter
    {
        private readonly ReimburseAddPresenter _ReimburseAddPresenter;
        private readonly IEmployeeReimburseView _IEmployeeReimburseView;

        public AddEmployeeReimbursePresenter(Account loginUser, IEmployeeReimburseView iEmployeeReimburseView) : base(loginUser)
        {
            _ReimburseAddPresenter = new ReimburseAddPresenter(loginUser, iEmployeeReimburseView.IReimburseView);
            _IEmployeeReimburseView = iEmployeeReimburseView;
        }
        public void InitView(bool pageIsPostBack)
        {
            AttachViewEvent();

            _ReimburseAddPresenter.Init(pageIsPostBack);
        }

        private void AttachViewEvent()
        {
            _ReimburseAddPresenter.ToMyReimbursePage += ToMyReimbursePage;
            new ReimburseItemEventsHandler(_IEmployeeReimburseView);
        }

        public event EventHandler ToMyReimbursePage;

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
