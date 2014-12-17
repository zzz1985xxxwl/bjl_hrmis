//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeContractsFrontList.cs
// 创建者: 刘丹
// 创建日期: 2008-06-24
// 概述: 员工前台合同listPresenter
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class EmployeeContractsFrontList
    {
        private IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        private IEmployeeContractFacade _IEmployeeContractFacade = InstanceFactory.CreateEmployeeContractFacade();
        private readonly IEmployeeContractListView _View;
        private int _EmployeeeId;

        public EmployeeContractsFrontList(IEmployeeContractListView view)
        {
            _View = view;   
        }

        public void InitView(string employeeId)
        {
            _View.ButtonEnable = false;
            _View.setGirdViewConlumn = true;
            if (!int.TryParse(employeeId, out _EmployeeeId))
            {
                _View.ResultMessage = "初始错误";
                return;
            }
            Employee employee = _IEmployeeFacade.GetEmployeeBasicInfoByAccountID(_EmployeeeId);
            List<Contract> employeeContract = _IEmployeeContractFacade.GetEmployeeContractByAccountID(_EmployeeeId);
            _View.EmployeeContract = employeeContract;
            _View.ResultMessage = "<span class='font14b'>你有 </span>"
                     + "<span class='fontred'>" + employeeContract.Count +"</span>"
                     + "<span class='font14b'> 条合同信息</span>"; employeeContract.Count.ToString();
            if(employeeContract.Count==0)
            {
                _View.EmployeeName = string.Empty;
            }
            else
            {
                _View.EmployeeName = "员工姓名: " + employee.Account.Name;
            }
            
        }

        #region user for tests

        public IEmployeeContractFacade SetGetEmployeeContract
        {
            set
            {
                _IEmployeeContractFacade = value;
            }
        }
        public IEmployeeFacade SetGetEmployee
        {
            set
            {
                _IEmployeeFacade = value;
            }
        }

        #endregion
    }
}
