//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeContractListPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-06-20
// 概述: 员工合同更新Presenter
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class EmployeeContractUpdatePresenter : EmployeeContractBasePresenter
    {
        private IContractTypeFacade _IContractTypeFacade = InstanceFactory.CreateContractTypeFacade();
        private IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        private IEmployeeContractFacade _IEmployeeContractFacade = InstanceFactory.CreateEmployeeContractFacade();
        private IApplyAssessConditionFacade _IApplyAssessConditionFacade = InstanceFactory.CreateApplyAssessConditionFacade();
        
         private int _EmployeeId,_ContractId;

        public EmployeeContractUpdatePresenter(IEmployeeContractView view)
            : base(view)
        {
        }

        public void InitView(string employeeId, string ContractId, bool isPostBack)
        {
            _View.ResultMessage = string.Empty;
            if (!int.TryParse(employeeId, out _EmployeeId))
            {
                _View.ResultMessage = "初始错误";
                return;
            }
            _View.EmployeeId = _EmployeeId.ToString();
            if (!int.TryParse(ContractId, out _ContractId))
            {
                _View.ResultMessage = "初始错误";
                return;
            }
            if (!isPostBack)
            {
                _View.ContractTypeSource = _IContractTypeFacade.GetContractTypeByCondition(-1, string.Empty);
                Contract conta = _IEmployeeContractFacade.GetEmployeeContractByContractId(_ContractId);
                if (conta == null)
                {
                    _View.ResultMessage = "<span class='fontred'>当前合同已不存在</span>";
                    return;
                }

                _View.ContractStartTime = conta.StartDate.ToShortDateString();
                if (!conta.EndDate.Equals(Convert.ToDateTime("2999-12-31")))
                {
                    _View.ContractEndTime = conta.EndDate.ToShortDateString();

                }
                _View.ContractTypeId = conta.ContractType.ContractTypeID.ToString();
                _View.Attachment = conta.Attachment;
                _View.Remark = conta.Remark;
                _View.ConditionSource =
                    _IApplyAssessConditionFacade.GetApplyAssessConditionByEmployeeContractID(_ContractId);
                _View.SetTypeReadonly = true;
                Employee employee = _IEmployeeFacade.GetEmployeeBasicInfoByAccountID(_EmployeeId);
                _View.Title = "修改" + employee.Account.Name + "的合同";
            }
            InitEmployeeContractTypeList();
        }

        public EventHandler ToContractListPage;
        public void UpdateContractEvent(object sender, EventArgs eventArgs)
        {
            if (Validate())
            {
                Employee employee = _IEmployeeFacade.GetEmployeeByAccountID(_EmployeeId);
                ContractType type = _IContractTypeFacade.GetContractTypeByPKID(Convert.ToInt32((_View.ContractTypeId)));
                Contract contract=new Contract(_ContractId,type,_StartTime,_EndTime);
                contract.Attachment = _View.Attachment;
                contract.Remark = _View.Remark;
                contract.EmployeeContractBookMark = _View.EmployeeContractBookMarkList;
                contract.ApplyAssessConditions = _View.ConditionSource;
                try
                {
                    _IEmployeeContractFacade.UpdateEmployeeContract(contract, employee);
                    ToContractListPage(sender, null);
                }
                catch (Exception ex)
                {
                    _View.ResultMessage = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

        public void CancleEvent(object sender, EventArgs eventArgs)
        {
            ToContractListPage(sender, null);
        }

        //public void SelectChange(object sender, EventArgs eventArgs)
        //{
        //    InitEmployeeContractTypeList();
        //}

        private void InitEmployeeContractTypeList()
        {
            _View.EmployeeContractBookMarkList = _IEmployeeContractFacade.GetRealEmployeeContractBookMarkByContractID(_ContractId);
        }

        #region user for tests

        public IContractTypeFacade SetGetContractType
        {
            set
            {
                _IContractTypeFacade = value;
            }
        }

        public IEmployeeContractFacade SetEmployeeContract
        {
            set
            {
                _IEmployeeContractFacade = value;
            }
        }
        public IEmployeeFacade SetEmployee
        {
            set
            {
                _IEmployeeFacade = value;
            }
        }
        public IApplyAssessConditionFacade SetApplyAssessCondition
        {
            set
            {
                _IApplyAssessConditionFacade = value;
            }
        }
        #endregion
    }
}
