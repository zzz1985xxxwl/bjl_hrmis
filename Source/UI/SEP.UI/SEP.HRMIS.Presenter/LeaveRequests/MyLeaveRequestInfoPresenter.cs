using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class MyLeaveRequestInfoPresenter : PresenterCore.BasePresenter
    {
        private readonly IMyLeaveRequestInfoView _View;
        private MyLeaveRequestListPresenter myLeaveRequestListPresenter;
        private CancelLeaveRequestPresenter cancelLeaveRequestPresenter;
        private MyLeaveRequestConfirmListPresenter myLeaveRequestConfirmListPresenter;
        private MyLeaveRequestConfirmHistoryListPresenter myLeaveRequestConfirmHistoryListPresenter;
        private LeaveRequestConfirmPresenter leaveRequestConfirmPresenter;
        private readonly ILeaveRequestFacade _ILeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();

        public MyLeaveRequestInfoPresenter(IMyLeaveRequestInfoView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;
        }

        #region Initialize

        public override void Initialize(bool isPostBack)
        {
            //if(!isPostBack)
            //{
            //    _View.ResultMessage = string.Empty;
            //}

            InitMyLeaveRequestListPresenter(isPostBack);

            InitMyLeaveRequestConfirmListPresenter(isPostBack);

            InitMyLeaveRequestConfirmHistoryListPresenter(isPostBack);

            InitCancelLeaveRequestPresenter();

            InitLeaveRequestConfirmPresenter();

            ShowMessage();
        }

        private void InitCancelLeaveRequestPresenter()
        {
            cancelLeaveRequestPresenter = new CancelLeaveRequestPresenter(_View.LeaveRequestOperationView);
        }

        private void InitMyLeaveRequestListPresenter(bool isPostBack)
        {
            myLeaveRequestListPresenter = new MyLeaveRequestListPresenter(_View.MyLeaveRequestListView);
            myLeaveRequestListPresenter.InitView(isPostBack, LoginUser.Id);
            _View.MyLeaveRequestListView.btnCancelClick += ShowWindowForCancel;
        }

        private void InitMyLeaveRequestConfirmHistoryListPresenter(bool isPostBack)
        {
            myLeaveRequestConfirmHistoryListPresenter =
                new MyLeaveRequestConfirmHistoryListPresenter(_View.MyLeaveRequestConfirmHistoryListView, LoginUser);
            myLeaveRequestConfirmHistoryListPresenter.Initialize(isPostBack);
        }

        private void InitMyLeaveRequestConfirmListPresenter(bool isPostBack)
        {
            myLeaveRequestConfirmListPresenter =
                new MyLeaveRequestConfirmListPresenter(_View.MyLeaveRequestConfirmListView, LoginUser);
            myLeaveRequestConfirmListPresenter.Initialize(isPostBack);
            _CompleteEvent += UpdatePanel;
            _View.MyLeaveRequestConfirmListView.QuickPassEvent += QuickPass;
        }

        private void InitLeaveRequestConfirmPresenter()
        {
            leaveRequestConfirmPresenter = new LeaveRequestConfirmPresenter(_View.LeaveRequestOperationView, LoginUser);
            _ShowUpdatePanel += ShowUpdatePanel;

            switch (_View.LeaveRequestOperationView.OperationType)
            {
                case "取消请假单":
                    _View.LeaveRequestOperationView.btnOKClick += CancelLeaveRequestEvent;
                    break;
                case "审核请假单":
                    _View.LeaveRequestOperationView.btnOKClick += ConfirmLeaveRequestEvent;
                    break;
                default:
                    break;
            }
            _View.MyLeaveRequestConfirmListView._ShowWindowForConfirmOperation += ShowWindowForConfirm;
        }

        private void ShowWindowForConfirm(string leaveRequestID)
        {
            leaveRequestConfirmPresenter.EmployeeID = LoginUser.Id;
            leaveRequestConfirmPresenter.EmployeeName = LoginUser.Name;
            leaveRequestConfirmPresenter.LeaveRequestID = leaveRequestID;
            leaveRequestConfirmPresenter.Initialize(true);
            _View.LeaveRequestOperationViewVisible = true;
        }

        private void ShowWindowForCancel(string leaveRequestID)
        {
            cancelLeaveRequestPresenter.EmployeeID = LoginUser.Id;
            cancelLeaveRequestPresenter.EmployeeName = LoginUser.Name;
            cancelLeaveRequestPresenter.LeaveRequestID = leaveRequestID;
            cancelLeaveRequestPresenter.InitView(false);
            _View.LeaveRequestOperationViewVisible = true;
        }

        #endregion

        //private void UpdateListWindow()
        //{
        //    if(string.IsNullOrEmpty(_View.LeaveRequestOperationView.ResultMessage))
        //    {
        //        _View.LeaveRequestOperationViewVisible = false;
        //        Initialize(true);
        //        InitMyLeaveRequestConfirmListPresenter(false);
        //    }
        //    else
        //    {
        //        _View.LeaveRequestOperationViewVisible = true;
        //    }
        //}

        private void ShowUpdatePanel()
        {
            _View.LeaveRequestOperationViewVisible = true;
        }

        private void UpdatePanel()
        {
            Initialize(false);
            InitMyLeaveRequestConfirmListPresenter(false);
        }

        private void ShowMessage()
        {
            _View.LeaveRequestConfirmCount = _View.MyLeaveRequestConfirmListView.ListCount.ToString();
            _View.MyLeaveRequestCount = _View.MyLeaveRequestListView.ListCount.ToString();
            _View.MyLeaveRequestConfirmHistoryCount = _View.MyLeaveRequestConfirmHistoryListView.ListCount.ToString();
        }

        public event DelegateNoParameter _CompleteEvent;
        public event DelegateNoParameter _ShowUpdatePanel;
        public void QuickPass(object sender, CommandEventArgs e)
        {
            _View.ResultMessage =
                _ILeaveRequestFacade.FastApproveWholeLeaveRequest(Convert.ToInt32(e.CommandArgument), LoginUser.Id, "OK");      
            _CompleteEvent();
        }

        public void ConfirmLeaveRequestEvent(object source, EventArgs e)
        {
            if (CheckValidate())
            {
                try
                {
                    string resultMessage =
                        _ILeaveRequestFacade.ApproveWholeLeaveRequest(
                            Convert.ToInt32(_View.LeaveRequestOperationView.LeaveRequestID), LoginUser.Id,
                            RequestStatus.FindRequestStatus(
                                Convert.ToInt32(_View.LeaveRequestOperationView.Status)),
                            _View.LeaveRequestOperationView.Remark);
                   
                    if (!string.IsNullOrEmpty(resultMessage))
                    {
                        _View.ResultMessage =resultMessage ;
                    }
                    else
                    {
                        _View.ResultMessage = string.Empty;
                    }
                    _CompleteEvent();
                }
                catch (ApplicationException ae)
                {
                    _View.LeaveRequestOperationView.ResultMessage = //LeaveRequestUtility._ErrorImage + 
                        ae.Message;
                }
            }
            else
            {
                _View.ResultMessage = string.Empty;
                _ShowUpdatePanel();
            }
        }

        /// <summary>
        /// 验证界面填写的信息
        /// </summary>
        /// <returns></returns>
        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(_View.LeaveRequestOperationView.Remark))
            {
                _View.LeaveRequestOperationView.RemarkMessage = LeaveRequestUtility._ErrorNullRemark;
                return false;
            }
            else
            {
                _View.LeaveRequestOperationView.RemarkMessage = string.Empty;
                return true;
            }
        }

        public void CancelLeaveRequestEvent(object source, EventArgs e)
        {
            if (CheckValidate())
            {
                try
                {
                    string resultMessage = _ILeaveRequestFacade.CancelAllLeaveRequest(_View.LeaveRequestOperationView.LeaveRequestID,
                                                               RequestStatus.FindRequestStatus(Convert.ToInt32(_View.LeaveRequestOperationView.Status)),
                                                               _View.LeaveRequestOperationView.Remark);
                    if (!string.IsNullOrEmpty(resultMessage))
                    {
                        _View.ResultMessage = resultMessage;
                    }
                    else
                    {
                        _View.ResultMessage = string.Empty;
                    }
                    //if (!string.IsNullOrEmpty(resultMessage))
                    //{
                    //    _View.LeaveRequestOperationView.ResultMessage = LeaveRequestUtility._ErrorImage + resultMessage;
                    //}
                    _CompleteEvent();
                }
                catch (ApplicationException ae)
                {
                    _View.LeaveRequestOperationView.ResultMessage = //LeaveRequestUtility._ErrorImage + 
                        ae.Message;
                }
            }
            else
            {
                _View.ResultMessage = string.Empty;
                _ShowUpdatePanel();
            }
        }
    }
}
