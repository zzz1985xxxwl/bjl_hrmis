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
        /// �������ԣ������˱��
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
        /// �������ԣ�����������
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
        /// ��������ѵ����id
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

        //ҳ����ת�¼�
        public event EventHandler GoToTrainApplicationInfoPage;
        private void AttachViewEvent()
        {
            //_ItsView.btnOKClick += ConfirmLeaveRequestEvent;
            _ItsView.btnCancelClick += GoToTrainApplicationInfoPage;
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="isPostBack"></param>
        public override void Initialize(bool isPostBack)
        {
            AttachViewEvent();
            _ItsView.OperationType = "�����ѵ����";
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
        /// ������ٵ�״̬�жϲ���������Դ
        /// </summary>
        private void GetDataSource()
        {
            _ItsView.StatusSource = TrainApplicationUtilityPresenter.GetStatusForApproveSubmit();
        }
    }
}
