using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class LeaveRequestConfirmPresenter : PresenterCore.BasePresenter
    {
        private readonly ILeaveRequestFacade _ILeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();
        private readonly ILeaveRequestOperationView _ItsView;

        public LeaveRequestConfirmPresenter(ILeaveRequestOperationView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
        }

        /// <summary>
        /// 公开属性，操作人编号
        /// </summary>
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

        /// <summary>
        /// 公开属性，操作人姓名
        /// </summary>
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

        /// <summary>
        /// 操作的请假单id
        /// </summary>
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

        //页面跳转事件
        public event EventHandler GoToLeaveRequestConfirmListPage;
        private void AttachViewEvent()
        {
            //_ItsView.btnOKClick += ConfirmLeaveRequestEvent;
            _ItsView.btnCancelClick += GoToLeaveRequestConfirmListPage;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="isPostBack"></param>
        public override void Initialize(bool isPostBack)
        {
            AttachViewEvent();
            _ItsView.OperationType = "审核请假单";
            _ItsView.ResultMessage = string.Empty;
            //if (!isPostBack)
            //{
                _ItsView.EmployeeName = _EmployeeName;
                _ItsView.EmployeeID = _EmployeeID;
                _ItsView.LeaveRequestID = _LeaveRequestID;
                _ItsView.Remark = string.Empty;
                _ItsView.RemarkMessage = string.Empty;
                _ItsView.SetStatusReadOnly = false;
                GetDataSource();
            //}
        }

        /// <summary>
        /// 根据请假单状态判断操作的数据源
        /// </summary>
        private void GetDataSource()
        {
            LeaveRequest leaveRequest = _ILeaveRequestFacade.GetLeaveRequestByPKID(Convert.ToInt32(LeaveRequestID));

            //-1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;
            //5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
            switch (leaveRequest.LeaveRequestItems[0].Status.Id)
            {
                case 1:
                case 7:
                    _ItsView.StatusSource = LeaveRequestUtility.GetLeaveRequestStatusForApproveSubmit();
                    break;
                case 4:
                case 8:
                    _ItsView.StatusSource = LeaveRequestUtility.GetLeaveRequestStatusForApproveCancel();
                    break;
            }
        }
    }
}
