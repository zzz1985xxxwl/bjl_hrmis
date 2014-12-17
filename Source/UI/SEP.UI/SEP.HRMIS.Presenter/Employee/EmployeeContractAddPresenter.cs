//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeContractListPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-06-20
// 概述: 员工合同新增Presenter
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;


using SEP.HRMIS.Presenter;

namespace SEP.HRMIS.Presenter
{
    public class EmployeeContractAddPresenter : EmployeeContractBasePresenter
    {
        private IContractTypeFacade _IContractTypeFacade = InstanceFactory.CreateContractTypeFacade();
        private IEmployeeContractFacade _IEmployeeContractFacade = InstanceFactory.CreateEmployeeContractFacade();
        private IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        private int _EmployeeId;

        public EmployeeContractAddPresenter(IEmployeeContractView view)
            : base(view)
        {
        }

        public void InitView(string employeeId,bool isPostBack)
        {
            _View.ResultMessage = string.Empty;
            if (!int.TryParse(employeeId, out _EmployeeId))
            {
                _View.ResultMessage = "初始错误";
                return;
            }
            _View.EmployeeId = _EmployeeId.ToString();
            if (!isPostBack)
            {
                _View.Attachment = string.Empty;
                _View.Remark = string.Empty;
                _View.ContractTypeSource = _IContractTypeFacade.GetContractTypeByCondition(-1, string.Empty);
                _View.ConditionSource = new List<ApplyAssessCondition>();
                Employee employee = _IEmployeeFacade.GetEmployeeBasicInfoByAccountID(_EmployeeId);
                _View.Title = "新增" + employee.Account.Name + "的合同";
            }
            InitEmployeeContractTypeList();
        }

        private void InitEmployeeContractTypeList()
        {
            _View.EmployeeContractBookMarkList = _IEmployeeContractFacade.GetEmployeeContractBookMarkByContractTypeID(Convert.ToInt32(_View.ContractTypeId), _EmployeeId);
        }

        public EventHandler ToContractListPage;
        public void AddContractEvent(object sender, EventArgs eventArgs)
        {
            if (Validate())
            {
                Employee employee = _IEmployeeFacade.GetEmployeeByAccountID(_EmployeeId);
                ContractType type = _IContractTypeFacade.GetContractTypeByPKID(Convert.ToInt32((_View.ContractTypeId)));
                Contract contract = new Contract(1, type, _StartTime, _EndTime);
                contract.Attachment = _View.Attachment;
                contract.Remark = _View.Remark;
                contract.EmployeeContractBookMark = _View.EmployeeContractBookMarkList;

                contract.ApplyAssessConditions = _View.ConditionSource;
                try
                {
               _IEmployeeContractFacade.AddEmployeeContract(contract, employee);
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

        #region user for tests

        public IContractTypeFacade SetGetContractType
        {
            set
            {
                _IContractTypeFacade = value;
            }
        }

        public IEmployeeFacade SetEmployee
        {
            set
            {
                _IEmployeeFacade = value;
            }
        }
        public IEmployeeContractFacade SetEmployeeContract
        {
            set
            {
                _IEmployeeContractFacade = value;
            }
        }

        #endregion
    }
}
