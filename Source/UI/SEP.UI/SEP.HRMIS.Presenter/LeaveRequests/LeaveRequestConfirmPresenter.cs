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
        /// ��������ٵ�id
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

        //ҳ����ת�¼�
        public event EventHandler GoToLeaveRequestConfirmListPage;
        private void AttachViewEvent()
        {
            //_ItsView.btnOKClick += ConfirmLeaveRequestEvent;
            _ItsView.btnCancelClick += GoToLeaveRequestConfirmListPage;
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="isPostBack"></param>
        public override void Initialize(bool isPostBack)
        {
            AttachViewEvent();
            _ItsView.OperationType = "�����ٵ�";
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
        /// ������ٵ�״̬�жϲ���������Դ
        /// </summary>
        private void GetDataSource()
        {
            LeaveRequest leaveRequest = _ILeaveRequestFacade.GetLeaveRequestByPKID(Convert.ToInt32(LeaveRequestID));

            //-1 ȫ��;0 ����;1 �ύ;2 ��˲�ͨ��;3 ���ͨ��;4 ȡ�����;
            //5 �ܾ�ȡ������;6 ��׼ȡ������;7 �����;8 ���ȡ����
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
