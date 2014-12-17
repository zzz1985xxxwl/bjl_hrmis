using System;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;

namespace SEP.HRMIS.Presenter.TrainApplication
{

    public class TrainApplicationOperationPresenter : PresenterCore.BasePresenter
    {
        private readonly ITrainApplicationOperatorView _ItsView;

        public TrainApplicationOperationPresenter(ITrainApplicationOperatorView itsView, Account loginUser)
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
        /// 操作的培训申请id
        /// </summary>
        private int _AppID;
        public string ApplicationID
        {
            get
            {
                return _AppID.ToString();
            }
            set
            {
                if (!int.TryParse(value, out _AppID))
                {
                    _ItsView.ResultMessage = TrainApplicationUtilityPresenter._InitialWrong;
                    return;
                }
            }
        }

        //页面跳转事件
        public event EventHandler GoToTrainApplicationInfoPage;
        private void AttachViewEvent()
        {
            //_ItsView.btnOKClick += ConfirmLeaveRequestEvent;
            _ItsView.btnCancelClick += GoToTrainApplicationInfoPage;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="isPostBack"></param>
        public override void Initialize(bool isPostBack)
        {
            AttachViewEvent();
            _ItsView.OperationType = "审核培训申请";
            _ItsView.ResultMessage = string.Empty;
            _ItsView.EmployeeName = _EmployeeName;
            _ItsView.EmployeeID = _EmployeeID;
            _ItsView.TrainApplicationID = _AppID;
            _ItsView.Remark = string.Empty;
            _ItsView.RemarkMessage = string.Empty;
            _ItsView.SetStatusReadOnly = false;
            GetDataSource();
        }

        /// <summary>
        /// 根据请假单状态判断操作的数据源
        /// </summary>
        private void GetDataSource()
        {
            _ItsView.StatusSource = TrainApplicationUtilityPresenter.GetStatusForApproveSubmit();
        }
    }
}
