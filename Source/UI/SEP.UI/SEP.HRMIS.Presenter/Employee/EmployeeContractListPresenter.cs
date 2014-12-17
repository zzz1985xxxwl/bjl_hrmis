//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeContractListPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-06-20
// 概述: 员工合同listPresenter
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using System.Web.UI.WebControls;
namespace SEP.HRMIS.Presenter
{
    public class EmployeeContractListPresenter
    {
        private IContractTypeFacade _IContractTypeFacade = InstanceFactory.CreateContractTypeFacade();
        private IEmployeeContractFacade _IEmployeeContractFacade = InstanceFactory.CreateEmployeeContractFacade();
        private IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        private readonly IEmployeeContractListView _View;
        //private DeleteEmployeeContract _DeleteContract;
        private int _EmployeeeId;
        private int _ContractID; 

        public EmployeeContractListPresenter(IEmployeeContractListView view)
        {
            _View = view;   
        }

        public void InitView(string employeeId)
        {
            _View.ButtonEnable = true;
            _View.setGirdViewConlumn = false;
            if (!int.TryParse(employeeId, out _EmployeeeId))
            {
                _View.ResultMessage = "初始错误";
                _View.ButtonEnable = false;
                return;
            }
            Employee employee = _IEmployeeFacade.GetEmployeeBasicInfoByAccountID(_EmployeeeId);
            List<Contract> employeeContract = _IEmployeeContractFacade.GetEmployeeContractByAccountID(_EmployeeeId);
            _View.EmployeeContract = employeeContract;
            _View.ResultMessage = "<span class='font14b'>该员工有</span>"
                                  + "<span class='fontred'>" + employeeContract.Count + "</span>"
                                  + "<span class='font14b'> 条合同信息</span>";
            if (employeeContract.Count == 0)
            {
                _View.EmployeeName = string.Empty;
            }
            else
            {
                _View.EmployeeName = "员工姓名:" + employee.Account.Name;
            }
        }

        public EventHandler ToContractAddPage;
        public void AddContractEvent(object sender, EventArgs e)
        {
            ToContractAddPage(sender, e);
        }

        public EventHandler ToContractDetailPage;
        public void DetailContractEvent(object sender, CommandEventArgs e)
        {
            if (!int.TryParse(e.CommandArgument.ToString(), out _ContractID))
            {
                _View.ResultMessage = "合同编号不存在";
                return;
            }
            ToContractDetailPage(sender, null);
        }

        public string  ContractDownLoadEvent(int contractID)
        {
            return _IEmployeeContractFacade.ExportEmployeeContract(contractID);
        }
        public bool IsDownEnable(int contractID)
        {
            return _IContractTypeFacade.GetContractTypeByContractID(contractID).HasTemplate;
        }

        public EventHandler ToContractDeletePage;
        public void DeleteContractEvent(object sender, CommandEventArgs e)
        {
            if (!int.TryParse(e.CommandArgument.ToString(), out _ContractID))
            {
                _View.ResultMessage = "合同编号不存在";
                return;
            }
            ToContractDeletePage(sender, null);
        }

        public EventHandler ToContractUpdatePage;
        public void UpdateContractEvent(object sender, CommandEventArgs e)
        {
            if (!int.TryParse(e.CommandArgument.ToString(), out _ContractID))
            {
                _View.ResultMessage = "合同编号不存在";
                return;
            }
            ToContractUpdatePage(sender, null);
        }

        public int ContractID
        {
            get { return _ContractID; }
            set { _ContractID = value; }
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
