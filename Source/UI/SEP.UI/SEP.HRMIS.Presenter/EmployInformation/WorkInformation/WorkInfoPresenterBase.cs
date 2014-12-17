//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: WorkInfoPresenterBase.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 工作信息界面的事件处理专门类,增/改/看 都应当继承以获取事件
//       绑定
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
        /// 获取请假流程
        /// </summary>
        private void GetLeaveProcessString()
        {
            _ItsView.LeaveProcessString = _DiyProcessFacade.GetDiyProcessStepString(_ItsView.AccountIdForProcess, _ItsView.leaveProcessId);
        }

        /// <summary>
        /// 获取外出流程
        /// </summary>
        private void GetOutProcessString()
        {
            _ItsView.OutProcessString = _DiyProcessFacade.GetDiyProcessStepString(_ItsView.AccountIdForProcess, _ItsView.outProcessId);
        }

        /// <summary>
        /// 获取加班流程
        /// </summary>
        private void GetOverTimeProcessString()
        {
            _ItsView.OverTimeString = _DiyProcessFacade.GetDiyProcessStepString(_ItsView.AccountIdForProcess, _ItsView.OverTimeProcessId);
        }

        /// <summary>
        /// 获取考评流程
        /// </summary>
        private void GetAssessProcessString()
        {
            _ItsView.AssessProcessString = _DiyProcessFacade.GetDiyProcessStepString(_ItsView.AccountIdForProcess, _ItsView.AssessProcessId);
        }

        /// <summary>
        /// 获取人事负责人邮件人员
        /// </summary>
        private void GetHRPrincipalProcessString()
        {
            _ItsView.HRPrincipalProcessString = _DiyProcessFacade.GetDiyProcessStepString(_ItsView.AccountIdForProcess, _ItsView.HRPrincipalProcessId);
        }

        ///// <summary>
        ///// 获取报销流程
        ///// </summary>
        //private void GetReimburseProcessString()
        //{
        //    _ItsView.ReimburseProcessString = _DiyProcessFacade.GetDiyProcessStepString(_ItsView.AccountIdForProcess, _ItsView.ReimburseProcessId);
        //}

        /// <summary>
        /// 获取培训申请流程
        /// </summary>
        private void GetTraineeApplicationProcessString()
        {
            _ItsView.TraineeApplicationString = 
                _DiyProcessFacade.GetDiyProcessStepString(_ItsView.AccountIdForProcess, _ItsView.TraineeApplicationProcessId);
        }
        #region 测试用

        public IDepartmentBll SetDepartmentSource
        {
            set { _IDepartmentBll = value; }
        }

        #endregion
    }
}