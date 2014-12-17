using System;
using SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseItem;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class ReimburseItemEventsHandler
    {
        private readonly IEmployeeReimburseView _IEmployeeReimburseView;

        public ReimburseItemEventsHandler(IEmployeeReimburseView iEmployeeReimburseView)
        {
            _IEmployeeReimburseView = iEmployeeReimburseView;
            SwitchReimburseItemPresenter();
            AttachViewEvent();
        }

        private void SwitchReimburseItemPresenter()
        {
            switch (_IEmployeeReimburseView.IReimburseItemView.OperationType)
            {
                case "add":
                    new ReimburseItemAddPresenter(_IEmployeeReimburseView.IReimburseItemView, _IEmployeeReimburseView.IReimburseView.IsTravelReimburse);
                    break;
                case "update":
                    new ReimburseItemUpdatePresenter(_IEmployeeReimburseView.IReimburseItemView,
                                                     _IEmployeeReimburseView.IReimburseItemView.ReimburseItemID, _IEmployeeReimburseView.IReimburseView.IsTravelReimburse);
                    break;
                case "delete":
                    new ReimburseItemDeletePresenter(_IEmployeeReimburseView.IReimburseItemView,
                                                     _IEmployeeReimburseView.IReimburseItemView.ReimburseItemID, _IEmployeeReimburseView.IReimburseView.IsTravelReimburse);
                    break;
                case "detail":
                    new ReimburseItemDetailPresenter(_IEmployeeReimburseView.IReimburseItemView,
                                                     _IEmployeeReimburseView.IReimburseItemView.ReimburseItemID, _IEmployeeReimburseView.IReimburseView.IsTravelReimburse);
                    break;
                default:
                    break;
            }
        }

        private void AttachViewEvent()
        {
            //(大界面)
            _IEmployeeReimburseView.IReimburseView.btnAddClick += btnAddClickEvent;
            _IEmployeeReimburseView.IReimburseView.btnUpdateClick += btnUpdateClickEvent;
            _IEmployeeReimburseView.IReimburseView.btnDeleteClick += btnDeleteClickEvent;
            _IEmployeeReimburseView.IReimburseView.btnDetailClick += btnDetailClickEvent;
            //(小界面)
            _IEmployeeReimburseView.IReimburseItemView.btnOKClick += btnOKClickEvent;
            _IEmployeeReimburseView.IReimburseItemView.btnCustomerCodeChange += btnCustomerCodeChangeEvent;
            _IEmployeeReimburseView.IReimburseItemView.btnCancelOnClientClick = "return CloseModalPopupExtender('" + _IEmployeeReimburseView.divMPEReimburseClientID +
                                               "');";
            _IEmployeeReimburseView.IReimburseItemView.btnCancelClick += btnCancelClickEvent;
        }

        private void btnDetailClickEvent(string e)
        {
            _IEmployeeReimburseView.IReimburseItemView.OperationType = "detail";
            _IEmployeeReimburseView.IReimburseItemView.ReimburseItemID = e;
            new ReimburseItemDetailPresenter(_IEmployeeReimburseView.IReimburseItemView, e, _IEmployeeReimburseView.IReimburseView.IsTravelReimburse).InitView();
            _IEmployeeReimburseView.ReimburseItemVisiable = true;
        }

        private void btnCancelClickEvent(object sender, EventArgs e)
        {
            _IEmployeeReimburseView.ReimburseItemVisiable = false;
        }

        private void btnOKClickEvent(object sender, EventArgs e)
        {
            if (_IEmployeeReimburseView.IReimburseItemView.ActionSuccess)
            {
                _IEmployeeReimburseView.ReimburseItemVisiable = false;
                _IEmployeeReimburseView.IReimburseView.ReimburseItemSource = _IEmployeeReimburseView.IReimburseItemView.ReimburseItemSource;
            }
            else
            {
                _IEmployeeReimburseView.ReimburseItemVisiable = true;
            }
        }
        private void btnCustomerCodeChangeEvent(object sender, EventArgs e)
        {
            _IEmployeeReimburseView.ReimburseItemVisiable = true;
        }


        private void btnDeleteClickEvent(string e)
        {
            _IEmployeeReimburseView.IReimburseItemView.OperationType = "delete";
            _IEmployeeReimburseView.IReimburseItemView.ReimburseItemID = e;
            new ReimburseItemDeletePresenter(_IEmployeeReimburseView.IReimburseItemView, e, _IEmployeeReimburseView.IReimburseView.IsTravelReimburse).InitView();
            _IEmployeeReimburseView.ReimburseItemVisiable = true;
        }

        private void btnUpdateClickEvent(string e)
        {
            _IEmployeeReimburseView.IReimburseItemView.OperationType = "update";
            _IEmployeeReimburseView.IReimburseItemView.ReimburseItemID = e;
            new ReimburseItemUpdatePresenter(_IEmployeeReimburseView.IReimburseItemView, e, _IEmployeeReimburseView.IReimburseView.IsTravelReimburse).InitView();
            _IEmployeeReimburseView.ReimburseItemVisiable = true;
        }

        private void btnAddClickEvent()
        {
            // add bjl start
            _IEmployeeReimburseView.IReimburseItemView.OperationType = "add";
            new ReimburseItemAddPresenter(_IEmployeeReimburseView.IReimburseItemView, _IEmployeeReimburseView.IReimburseView.IsTravelReimburse).InitView();
            _IEmployeeReimburseView.ReimburseItemVisiable = true;
        }
    }
}
