//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: deleteEmployeeContractTest.cs
// ������: ����
// ��������: 2008-05-21
// ����: ɾ��Ա����ͬ����
// ----------------------------------------------------------------

using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class DeleteEmployeeContractTest
    {
        [Test, Description("ɾ��Ա����ͬ")]
        public void DeleteEmployeeContractSuccess()
        {
            MockRepository mocks = new MockRepository();
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            IContract iContract = (IContract)mocks.CreateMock(typeof(IContract));
            IEmployeeContractBookMark iEmployeeContractBookMark = (IEmployeeContractBookMark)mocks.CreateMock(typeof(IEmployeeContractBookMark));
            ContractType contracttype = new ContractType(1, "contracttypetest");
            Contract contract = new Contract(1, contracttype, Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2010-1-1"));

            Employee employee = new Employee(new Account(1, "", "test"), "", "", new EmployeeTypeEnum(), null, null);

            Expect.Call(iEmployee.GetEmployeeByAccountID(employee.Account.Id)).Return(employee);
            Expect.Call(iContract.GetEmployeeContractByContractId(contract.ContractID)).Return(contract);
            Expect.Call(iEmployeeContractBookMark.DeleteEmployeeContractBookMarkByContractID(contract.ContractID)).Return(1);
            Expect.Call(iContract.DeleteEmployeeContract(contract.ContractID)).Return(1);
            Expect.Call(iContract.DeleteApplyAssessConditionsByEmployeeContractID(contract.ContractID)).Return(1);
            mocks.ReplayAll();

            DeleteEmployeeContract target = new DeleteEmployeeContract(contract.ContractID, employee.Account.Id, iContract, iEmployee, iEmployeeContractBookMark);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("Ҫɾ����ͬ��Ա��������")]
        [ExpectedException(typeof(ApplicationException))]
        public void DeleteEmployeeContractEmployeeNotExist()
        {
            MockRepository mocks = new MockRepository();
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            IContract iContract = (IContract)mocks.CreateMock(typeof(IContract));

            int contractID = 1;
            int employeeID = 1;

            Expect.Call(iEmployee.GetEmployeeByAccountID(employeeID)).Return(null);
            mocks.ReplayAll();

            DeleteEmployeeContract target = new DeleteEmployeeContract(contractID, employeeID, iContract, iEmployee, null);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("Ҫɾ���ĺ�ͬ������")]
        [ExpectedException(typeof(ApplicationException))]
        public void DeleteEmployeeContractContractNotExist()
        {
            MockRepository mocks = new MockRepository();
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            IContract iContract = (IContract)mocks.CreateMock(typeof(IContract));

            int contractID = 1;

            Employee employee = new Employee(new Account(1, "", "test"), "", "", new EmployeeTypeEnum(), null, null);

            Expect.Call(iEmployee.GetEmployeeByAccountID(employee.Account.Id)).Return(employee);
            Expect.Call(iContract.GetEmployeeContractByContractId(contractID)).Return(null);
            mocks.ReplayAll();

            DeleteEmployeeContract target = new DeleteEmployeeContract(contractID, employee.Account.Id, iContract, iEmployee, null);
            target.Excute();
            mocks.VerifyAll();
        }
    }
}
