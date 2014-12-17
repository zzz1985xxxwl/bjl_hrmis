using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class ApproveLeaveRequestItemPresenter : BasePresenter
    {
         private readonly ILeaveRequestTypeFacade _ILeaveRequestTypeFacade = InstanceFactory.CreateLeaveRequestTypeFacade();
        private readonly ILeaveRequestFacade _ILeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();

        private readonly ICancelLeaveRequestItemView _ItsView;
        public ApproveLeaveRequestItemPresenter(ICancelLeaveRequestItemView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
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

        private int _OperatorID;
        public int OperatorID
        {
            get
            {
                return _OperatorID;
            }
            set
            {
                _OperatorID = value;
            }
        }

        private string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        public override void Initialize(bool isPostBack)
        {
            AttachViewEvent();
            GetDataSource();
            _ItsView.btnCancelText = "取消";
            _ItsView.btnOKText = "确定";
            _ItsView.OperationType = "审核请假";
            _ItsView.LeaveRequestTypeSource = _ILeaveRequestTypeFacade.GetAllLeaveRequestType();
            _ItsView.ResultMessage = string.Empty;
            _ItsView.OperationID = _OperatorID;

            LeaveRequest theDataToBind = _ILeaveRequestFacade.GetLeaveRequestByPKID(_LeaveRequestID);

            if (theDataToBind != null)
            {
                _ItsView.LeaveRequestID = theDataToBind.PKID.ToString();
                _ItsView.EmployeeID = theDataToBind.Account.Id.ToString();
                _ItsView.EmployeeName = theDataToBind.Account.Name;
                _ItsView.Remark = theDataToBind.Reason;
                _ItsView.LeaveRequestType = theDataToBind.LeaveRequestType;
                _ItsView.CostTime = theDataToBind.CostTime.ToString();
                _ItsView.TimeSpan = theDataToBind.FromDate + " ～ " + theDataToBind.ToDate;
                if (!isPostBack)
                {
                    _ItsView.LeaveRequestItemList = theDataToBind.LeaveRequestItems;
                }
            }

            if (!string.IsNullOrEmpty(Message))
            {
                _ItsView.ResultMessage = Message;
            }

            _ItsView.SetFormReadOnly = true;
            _ItsView.SetFormCancel = true;
        }

        /// <summary>
        /// 根据请假单状态判断操作的数据源
        /// </summary>
        private void GetDataSource()
        {
            _ItsView.ApproveCancelStatusSource = LeaveRequestUtility.GetLeaveRequestStatusForApproveCancel();
            _ItsView.ApproveSubmitStatusSource = LeaveRequestUtility.GetLeaveRequestStatusForApproveSubmit();
        }

        public event DelegateNoParameter GoToListPage;
        private void AttachViewEvent()
        {
            _ItsView.btnOKClick += CancelLeaveRequestItem;
            _ItsView.btnCancelClick += CancelClick;
        }

        public void CancelClick(object source, EventArgs e)
        {
            GoToListPage();
        }

        public void CancelLeaveRequestItem(object source, EventArgs e)
        {
            if (CheckValidate())
            {
                int failCount = 0;
                int successCount = 0;
                foreach (LeaveRequestItem item in _ItsView.LeaveRequestItemList)
                {
                    try
                    {
                        _ILeaveRequestFacade.ApproveLeaveRequestItem(Convert.ToInt32(_ItsView.LeaveRequestID),
                                                                     item.LeaveRequestItemID,
                                                                     _ItsView.OperationID, item.Status,
                                                                     item.Remark);
                        successCount++;
                    }
                    catch
                    {
                        failCount++;
                    }

                    if(failCount > 0)
                    {
                        Message = successCount + "个请假项成功审核，" + failCount + "个请假项审核失败";
                        Initialize(false);
                    }
                    else
                    {
                        GoToListPage();
                    }
                }
            }
        }

        private bool CheckValidate()
        {
            bool result = true;
            try
            {
                foreach (LeaveRequestItem item in _ItsView.LeaveRequestItemList)
                {
                    if ((item.Status.Id == RequestStatus.ApproveCancelFail.Id || item.Status.Id == RequestStatus.ApproveFail.Id) &&
                        string.IsNullOrEmpty(item.Remark))
                    {
                        _ItsView.ResultMessage = //LeaveRequestUtility._ErrorImage +
                            LeaveRequestUtility._ErrorNullRemarkLong;
                        result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("格式"))
                {
                    _ItsView.ResultMessage = //LeaveRequestUtility._ErrorImage +
                        "请选择一种操作";
                    result = false;
                }
            }
            if (result)
            {
                _ItsView.ResultMessage = string.Empty;
            }
            return result;
        }
    }
}
