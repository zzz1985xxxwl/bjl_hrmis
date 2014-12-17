using System;
using SEP.HRMIS.Presenter.EmployeeReimburse.Reimburse;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class DetailEmployeeReimbursePresenter
    {
        private readonly IEmployeeReimburseView _IEmployeeReimburseView;
        private readonly ReimburseDetailPresenter _ReimburseDetailPresenter;

        public DetailEmployeeReimbursePresenter(int reimburseID, IEmployeeReimburseView iEmployeeReimburseView)
        {
            _ReimburseDetailPresenter = new ReimburseDetailPresenter(reimburseID, iEmployeeReimburseView.IReimburseView);
            _IEmployeeReimburseView = iEmployeeReimburseView;
        }
        public void InitView(bool pageIsPostBack)
        {
            AttachViewEvent();

            _ReimburseDetailPresenter.Init(pageIsPostBack);
        }

        private void AttachViewEvent()
        {
            _ReimburseDetailPresenter.ToMyReimbursePage += ToMyReimbursePage;
            new ReimburseItemEventsHandler(_IEmployeeReimburseView);
        }

        public event EventHandler ToMyReimbursePage;
    }
}
