//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: EmployeeContractListPresenter.cs
// ������: ����
// ��������: 2008-06-20
// ����: Ա����ͬlistPresenter
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
                _View.ResultMessage = "��ʼ����";
                _View.ButtonEnable = false;
                return;
            }
            Employee employee = _IEmployeeFacade.GetEmployeeBasicInfoByAccountID(_EmployeeeId);
            List<Contract> employeeContract = _IEmployeeContractFacade.GetEmployeeContractByAccountID(_EmployeeeId);
            _View.EmployeeContract = employeeContract;
            _View.ResultMessage = "<span class='font14b'>��Ա����</span>"
                                  + "<span class='fontred'>" + employeeContract.Count + "</span>"
                                  + "<span class='font14b'> ����ͬ��Ϣ</span>";
            if (employeeContract.Count == 0)
            {
                _View.EmployeeName = string.Empty;
            }
            else
            {
                _View.EmployeeName = "Ա������:" + employee.Account.Name;
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
                _View.ResultMessage = "��ͬ��Ų�����";
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
                _View.ResultMessage = "��ͬ��Ų�����";
                return;
            }
            ToContractDeletePage(sender, null);
        }

        public EventHandler ToContractUpdatePage;
        public void UpdateContractEvent(object sender, CommandEventArgs e)
        {
            if (!int.TryParse(e.CommandArgument.ToString(), out _ContractID))
            {
                _View.ResultMessage = "��ͬ��Ų�����";
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
