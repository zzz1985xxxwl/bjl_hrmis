using System;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class CancelLeaveRequestPresenter
    {
        //private readonly ILeaveRequestFacade _ILeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();
        private readonly ILeaveRequestOperationView _ItsView;

        public CancelLeaveRequestPresenter(ILeaveRequestOperationView itsView)
        {
            _ItsView = itsView;
        }

        private int _EmployeeID;
        public int EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
            }
        }

        private string _EmployeeName;
        public string EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
            set
            {
                _EmployeeName = value;
            }
        }

        private int _LeaveRequestID;
        public string LeaveRequestID
        {
            get
            {
                return _LeaveRequestID.ToString();
            }
            set
            {
                if (!int.TryParse(value, out _LeaveRequestID))
                {
                    _ItsView.ResultMessage = LeaveRequestUtility._ErrorLeaveRequestID +
                                             LeaveRequestUtility._ErrorLeaveRequest;
                    return;
                }
            }
        }

        public event EventHandler GoToLeaveRequestConfirmListPage;
        private void AttachViewEvent()
        {
            //_ItsView.btnOKClick += ConfirmLeaveRequestEvent;
            _ItsView.btnCancelClick += GoToLeaveRequestConfirmListPage;
        }
        public void InitView(bool isPagePostBack)
        {
            AttachViewEvent();
            _ItsView.OperationType = "È¡ÏûÇë¼Ùµ¥";
            _ItsView.ResultMessage = string.Empty;
            if (!isPagePostBack)
            {
                GetDataSource();
                _ItsView.EmployeeName = _EmployeeName;
                _ItsView.EmployeeID = _EmployeeID;
                _ItsView.LeaveRequestID = _LeaveRequestID;
                _ItsView.Remark = string.Empty;
                _ItsView.RemarkMessage = string.Empty;
                _ItsView.Status = "4";
                _ItsView.SetStatusReadOnly = true;
            }
        }

        private void GetDataSource()
        {
            _ItsView.StatusSource = LeaveRequestUtility.GetLeaveRequestStatus();
        }

        //public event DelegateNoParameter _ShowUpdatePanel;
        //public event DelegateNoParameter _CompleteEvent;
        //public void ConfirmLeaveRequestEvent(object source, EventArgs e)
        //{
        //    if (CheckValidate())
        //    {
        //        try
        //        {
        //            string resultMessage = _ILeaveRequestFacade.CancelAllLeaveRequest(_ItsView.LeaveRequestID,
        //                                                       LeaveRequestUtility.GetLeaveRequestStatusByID(_ItsView.Status),
        //                                                       _ItsView.Remark);
        //            if(!string.IsNullOrEmpty(resultMessage))
        //            {
        //                _ItsView.ResultMessage = LeaveRequestUtility._ErrorImage + resultMessage;
        //            }
        //            _CompleteEvent();
        //        }
        //        catch (ApplicationException ae)
        //        {
        //            _ItsView.ResultMessage = LeaveRequestUtility._ErrorImage + ae.Message;
        //        }
        //    }
        //    else
        //    {
        //        _ShowUpdatePanel();
        //    }
        //}

        //private bool CheckValidate()
        //{
        //    if (string.IsNullOrEmpty(_ItsView.Remark))
        //    {
        //        _ItsView.RemarkMessage = LeaveRequestUtility._ErrorNullRemark;
        //        return false;
        //    }
        //    else
        //    {
        //        _ItsView.RemarkMessage = string.Empty;
        //        return true;
        //    }
        //}
    }
}