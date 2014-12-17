using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using PresenterCore = SEP.Presenter.Core;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;
using SEP.HRMIS.Model.TraineeApplications;

namespace SEP.HRMIS.Presenter.TrainApplication
{
    public class TrainApplicationInfoPresenter : BasePresenter
    {
        private readonly IMyTrainApplicationInfoView _View;
        private MyTrainApplicationPresenter myTrainApplicationPresenter;
        private TrainApplicationConfirmListPresenter myConfirmListPresenter;
        private TrainApplicationConfirmHistoryPresenter myConfirmHistoryListPresenter;
        private TrainApplicationOperationPresenter operationPresenter;
        private readonly ITraineeApplicationFacade _ITrainFacade = InstanceFactory.CreateTraineeApplicationFacade();

        public TrainApplicationInfoPresenter(IMyTrainApplicationInfoView view, Account loginUser)
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

            InitMyTrainApplicationListPresenter(isPostBack);

            InitConfirmListPresenter(isPostBack);

            InitMyTrainApplicationConfirmHistoryListPresenter(isPostBack);

            InitOperationPresenter();

            ShowMessage();
        }

        private void InitMyTrainApplicationListPresenter(bool isPostBack)
        {
            myTrainApplicationPresenter = new MyTrainApplicationPresenter(_View.MyTrainApplicationListView);
            myTrainApplicationPresenter.InitView(isPostBack, LoginUser.Id);
            //_View.MyTrainApplicationListView. += ShowWindowForCancel;
        }

        private void InitMyTrainApplicationConfirmHistoryListPresenter(bool isPostBack)
        {
            myConfirmHistoryListPresenter =
                new TrainApplicationConfirmHistoryPresenter(_View.ConfirmHistoryListView, LoginUser);
            myConfirmHistoryListPresenter.Initialize(isPostBack);
        }

        private void InitConfirmListPresenter(bool isPostBack)
        {
            myConfirmListPresenter =
                new TrainApplicationConfirmListPresenter(_View.ConfirmListView, LoginUser);
            myConfirmListPresenter.Initialize(isPostBack);
            _CompleteEvent += UpdatePanel;
            _View.ConfirmListView.QuickPassEvent += QuickPass;
        }

        private void InitOperationPresenter()
        {
            operationPresenter = new TrainApplicationOperationPresenter(_View.OperationView, LoginUser);
            _ShowUpdatePanel += ShowUpdatePanel;
            _View.OperationView.btnOKClick += ConfirmLeaveRequestEvent;

            _View.ConfirmListView._ShowWindowForConfirmOperation += ShowWindowForConfirm;
        }

        private void ShowWindowForConfirm(string applicationId)
        {
            operationPresenter.EmployeeID = LoginUser.Id;
            operationPresenter.EmployeeName = LoginUser.Name;
            operationPresenter.ApplicationID = applicationId;
            operationPresenter.Initialize(true);
            _View.OperationViewVisible = true;
        }

        //private void ShowWindowForCancel(string leaveRequestID)
        //{
        //    operationPresenter.EmployeeID = LoginUser.Id;
        //    operationPresenter.EmployeeName = LoginUser.Name;
        //    operationPresenter.LeaveRequestID = leaveRequestID;
        //    operationPresenter.InitView(false);
        //    _View.LeaveRequestOperationViewVisible = true;
        //}

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
            _View.OperationViewVisible = true;
        }

        private void UpdatePanel()
        {
            Initialize(false);
            InitConfirmListPresenter(false);
        }

        private void ShowMessage()
        {
            _View.TrainApplicationConfirmCount = _View.ConfirmListView.ListCount.ToString();
            _View.MyTrainApplicationCount
                = _View.MyTrainApplicationListView.ListCount.ToString();
            _View.TrainApplicationConfirmHistoryCount = _View.ConfirmHistoryListView.ListCount.ToString();
        }

        public event DelegateNoParameter _CompleteEvent;
        public event DelegateNoParameter _ShowUpdatePanel;
        public void QuickPass(object sender, CommandEventArgs e)
        {
            try
            {
                _ITrainFacade.ApproveTraineeApplication(LoginUser, Convert.ToInt32(e.CommandArgument));
            }
            catch(Exception ex)
            {
                _View.ResultMessage = ex.Message;
            }
            _CompleteEvent();
        }

        public void ConfirmLeaveRequestEvent(object source, EventArgs e)
        {
            if (CheckValidate())
            {
                try
                {
                     _ITrainFacade.ApproveTraineeApplicationWhole(LoginUser, Convert.ToInt32(_View.OperationView.TrainApplicationID), TraineeApplicationStatus.FindTraineeApplicationStatus(Convert.ToInt32(_View.OperationView.Status)), _View.OperationView.Remark);
                }
                catch (ApplicationException ae)
                {
                    _View.OperationView.ResultMessage = ae.Message;
                }
            }
            else
            {
                _View.ResultMessage = string.Empty;
                _ShowUpdatePanel();
            }
            _CompleteEvent();
        }

        /// <summary>
        /// 验证界面填写的信息
        /// </summary>
        /// <returns></returns>
        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(_View.OperationView.Remark))
            {
                _View.OperationView.RemarkMessage = TrainApplicationUtilityPresenter._IsEmpty;
                return false;
            }

            _View.OperationView.RemarkMessage = string.Empty;
            return true;
        }
    }
}
