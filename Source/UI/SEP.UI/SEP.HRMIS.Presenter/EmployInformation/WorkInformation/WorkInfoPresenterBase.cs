//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: WorkInfoPresenterBase.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: ������Ϣ������¼�����ר����,��/��/�� ��Ӧ���̳��Ի�ȡ�¼�
//       ��
// ----------------------------------------------------------------


using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;
using SEP.IBll;
using SEP.IBll.Departments;

namespace SEP.HRMIS.Presenter.EmployInformation.WorkInformation
{
    public class WorkInfoPresenterBase
    {
        protected readonly IWorkInfoView _ItsView;
        private IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        private IEmployeeContractFacade _IEmployeeContractFacade = InstanceFactory.CreateEmployeeContractFacade();
        private IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private IContractTypeFacade _IContractTypeFacade = InstanceFactory.CreateContractTypeFacade();
        private IDiyProcessFacade _DiyProcessFacade = InstanceFactory.CreateDiyProcessFacade();

        public WorkInfoPresenterBase(IWorkInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            //_ItsView.DepartmentSelectChangeEvent += DepartmentSelectChangeEvent;
            _ItsView.FatherSelectChangeEvent += FatherSelectChangeEvent;
            _ItsView.IsDownLoadEnable += IsDownEnable;
            _ItsView.ContractDownLoadEvent += ContractDownLoadEvent;
            _ItsView.DiyProcessSelectChangeEvent += DiyProcessSelectChangeEvent;
        }
        public bool IsDownEnable(int contractID)
        {
            return _IContractTypeFacade.GetContractTypeByContractID(contractID).HasTemplate;
        }
        public string ContractDownLoadEvent(int contractID)
        {
            return _IEmployeeContractFacade.ExportEmployeeContract(contractID);
        }
        protected void DepartmentSelectChangeEvent()
        {
            string theName = GetLeaderNameByDepartmentId(_ItsView.DepartmentID.ToString());

            if (!string.IsNullOrEmpty(theName))
            {
                _ItsView.DepartmentLeader = theName;
            }
        }

        protected void FatherSelectChangeEvent()
        {
            GetLeaderNameByDepartmentId(_ItsView.Company);
        }

        private string GetLeaderNameByDepartmentId(string id)
        {
            string retVal = null;
            int theId;
            if (!int.TryParse(id, out theId))
            {
                return retVal;
            }
            return _IDepartmentBll.GetDepartmentById(theId, null).DepartmentLeader.Name;
        }

        /// <summary>
        ///  for dropdwonlist about diy process index change event
        /// </summary>
        /// <param name="id">dropdwonlist id</param>
        public void DiyProcessSelectChangeEvent(string id)
        {
            switch (id)
            {
                case "ddlLeaveRequest":
                    GetLeaveProcessString();
                    break;
                case "ddlOut":
                    GetOutProcessString();
                    break;
                case "ddlOverTime":
                    GetOverTimeProcessString();
                    break;
                case "ddlAssess":
                    GetAssessProcessString();
                    break;
                case "ddlHRPrincipal":
                    GetHRPrincipalProcessString();
                    break;
                //case "ddlReimburse":
                //    GetReimburseProcessString();
                //    break;
                case "ddlTraineeApplication":
                    GetTraineeApplicationProcessString();
                    break;
                default:
                    GetLeaveProcessString();
                    GetOutProcessString();
                    GetOverTimeProcessString();
                    GetAssessProcessString();
                    GetHRPrincipalProcessString();
                    //GetReimburseProcessString();
                    GetTraineeApplicationProcessString();
                    break;
            }

        }

        /// <summary>
        /// ��ȡ�������
        /// </summary>
        private void GetLeaveProcessString()
        {
            _ItsView.LeaveProcessString = _DiyProcessFacade.GetDiyProcessStepString(_ItsView.AccountIdForProcess, _ItsView.leaveProcessId);
        }

        /// <summary>
        /// ��ȡ�������
        /// </summary>
        private void GetOutProcessString()
        {
            _ItsView.OutProcessString = _DiyProcessFacade.GetDiyProcessStepString(_ItsView.AccountIdForProcess, _ItsView.outProcessId);
        }

        /// <summary>
        /// ��ȡ�Ӱ�����
        /// </summary>
        private void GetOverTimeProcessString()
        {
            _ItsView.OverTimeString = _DiyProcessFacade.GetDiyProcessStepString(_ItsView.AccountIdForProcess, _ItsView.OverTimeProcessId);
        }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        private void GetAssessProcessString()
        {
            _ItsView.AssessProcessString = _DiyProcessFacade.GetDiyProcessStepString(_ItsView.AccountIdForProcess, _ItsView.AssessProcessId);
        }

        /// <summary>
        /// ��ȡ���¸������ʼ���Ա
        /// </summary>
        private void GetHRPrincipalProcessString()
        {
            _ItsView.HRPrincipalProcessString = _DiyProcessFacade.GetDiyProcessStepString(_ItsView.AccountIdForProcess, _ItsView.HRPrincipalProcessId);
        }

        ///// <summary>
        ///// ��ȡ��������
        ///// </summary>
        //private void GetReimburseProcessString()
        //{
        //    _ItsView.ReimburseProcessString = _DiyProcessFacade.GetDiyProcessStepString(_ItsView.AccountIdForProcess, _ItsView.ReimburseProcessId);
        //}

        /// <summary>
        /// ��ȡ��ѵ��������
        /// </summary>
        private void GetTraineeApplicationProcessString()
        {
            _ItsView.TraineeApplicationString = 
                _DiyProcessFacade.GetDiyProcessStepString(_ItsView.AccountIdForProcess, _ItsView.TraineeApplicationProcessId);
        }
        #region ������

        public IDepartmentBll SetDepartmentSource
        {
            set { _IDepartmentBll = value; }
        }

        #endregion
    }
}