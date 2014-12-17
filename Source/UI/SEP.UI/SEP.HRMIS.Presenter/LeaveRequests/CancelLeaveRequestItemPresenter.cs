using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class CancelLeaveRequestItemPresenter : BasePresenter
    {
        private readonly ILeaveRequestTypeFacade _ILeaveRequestTypeFacade = InstanceFactory.CreateLeaveRequestTypeFacade();
        private readonly ILeaveRequestFacade _ILeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();

        private readonly ICancelLeaveRequestItemView _ItsView;
        public CancelLeaveRequestItemPresenter(ICancelLeaveRequestItemView itsView, Account loginUser)
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
            _ItsView.OperationType = "取消请假";

            _ItsView.LeaveRequestTypeSource = _ILeaveRequestTypeFacade.GetAllLeaveRequestType();
            _ItsView.ResultMessage = string.Empty;

            LeaveRequest theDataToBind = _ILeaveRequestFacade.GetLeaveRequestByPKID(_LeaveRequestID);
            if (theDataToBind != null)
            {
                _ItsView.OperationID = theDataToBind.Account.Id;

                _ItsView.LeaveRequestID = theDataToBind.PKID.ToString();
                _ItsView.EmployeeID = theDataToBind.Account.Id.ToString();
                _ItsView.EmployeeName = theDataToBind.Account.Name;
                _ItsView.Remark = theDataToBind.Reason;
                _ItsView.LeaveRequestType = theDataToBind.LeaveRequestType;
                _ItsView.CostTime = theDataToBind.CostTime.ToString();
                _ItsView.TimeSpan = theDataToBind.FromDate + " ～ " + theDataToBind.ToDate;
            }

            if (!isPostBack && theDataToBind != null)
            {
                _ItsView.LeaveRequestItemList = theDataToBind.LeaveRequestItems;
            }

            if(!string.IsNullOrEmpty(Message))
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
            //-1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;
            //5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
            _ItsView.ApproveCancelStatusSource = LeaveRequestUtility.GetLeaveRequestStatusForCancel();
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
                        _ILeaveRequestFacade.CancelLeaveRequestItem(Convert.ToInt32(_ItsView.LeaveRequestID),
                                                                    item.LeaveRequestItemID,
                                                                    _ItsView.OperationID, item.Status,
                                                                    item.Remark);
                        successCount++;
                    }
                    catch
                    {
                        failCount++;
                    }

                    if (failCount > 0)
                    {
                        Message = //LeaveRequestUtility._SuccessImage +
                            successCount + "个请假项成功取消，" + failCount + "个请假项取消失败";
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
                    if (string.IsNullOrEmpty(item.Remark))
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