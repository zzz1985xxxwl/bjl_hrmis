//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: EmployeeContractsFrontList.cs
// ������: ����
// ��������: 2008-06-24
// ����: Ա��ǰ̨��ͬlistPresenter
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
                _View.ResultMessage = "��ʼ����";
                return;
            }
            Employee employee = _IEmployeeFacade.GetEmployeeBasicInfoByAccountID(_EmployeeeId);
            List<Contract> employeeContract = _IEmployeeContractFacade.GetEmployeeContractByAccountID(_EmployeeeId);
            _View.EmployeeContract = employeeContract;
            _View.ResultMessage = "<span class='font14b'>���� </span>"
                     + "<span class='fontred'>" + employeeContract.Count +"</span>"
                     + "<span class='font14b'> ����ͬ��Ϣ</span>"; employeeContract.Count.ToString();
            if(employeeContract.Count==0)
            {
                _View.EmployeeName = string.Empty;
            }
            else
            {
                _View.EmployeeName = "Ա������: " + employee.Account.Name;
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
