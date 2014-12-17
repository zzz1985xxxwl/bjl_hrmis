//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateEmployeeContractTest.cs
// ������: ����
// ��������: 2008-05-21
// ����: �޸�Ա����ͬ����
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class UpdateEmployeeContractTest
    {
        [Test, Description("�޸�Ա����ͬ,�޷�����������")]
        public void UpdateEmployeeContractSuccess1()
        {
            MockRepository mocks = new MockRepository();
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            IContract iContract = (IContract)mocks.CreateMock(typeof(IContract));
            IContractType iContractType = (IContractType)mocks.CreateMock(typeof(IContractType));
            IEmployeeContractBookMark iEmployeeContractBookMark =
(IEmployeeContractBookMark)mocks.CreateMock(typeof(IEmployeeContractBookMark));

            ContractType contracttype = new ContractType(1, "contracttypetest");
            Contract contract = new Contract(1, contracttype, Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2010-1-1"));
            List<EmployeeContractBookMark> employeeContractBookMarkList = new List<EmployeeContractBookMark>();
            EmployeeContractBookMark employeeContractBookMark = new EmployeeContractBookMark(1, 1, "Ա������", "aa");
            employeeContractBookMarkList.Add(employeeContractBookMark);
            contract.EmployeeContractBookMark = employeeContractBookMarkList;

            Employee employee = new Employee(new Account(1, "", "test"), "", "", new EmployeeTypeEnum(), null, null);
            employee.Account.Id = 1;
            employee.EmployeeType = EmployeeTypeEnum.NormalEmployee;

            Expect.Call(iEmployee.GetEmployeeByAccountID(employee.Account.Id)).Return(employee);
            Expect.Call(iContract.GetEmployeeContractByContractId(contract.ContractID)).Return(contract);
            Expect.Call(iContractType.GetContractTypeByPkid(contracttype.ContractTypeID)).Return(contracttype);

            Expect.Call(iContract.UpdateEmployeeContract(contract)).Return(1);
            Expect.Call(iEmployeeContractBookMark.DeleteEmployeeContractBookMarkByContractID(1)).Return(1);
            Expect.Call(iEmployeeContractBookMark.InsertEmployeeContractBookMark(employeeContractBookMark)).Return(1);

            Expect.Call(iContract.DeleteApplyAssessConditionsByEmployeeContractID(contract.ContractID)).Return(1);
            mocks.ReplayAll();

            UpdateEmployeeContract target = new UpdateEmployeeContract(contract, employee, iContract, iEmployee, iContractType, iEmployeeContractBookMark);
            target.Excute();
            mocks.VerifyAll();
        }
        [Test, Description("�޸�Ա����ͬ,�з�����������")]
        public void UpdateEmployeeContractSuccess2()
        {
            MockRepository mocks = new MockRepository();
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            IContract iContract = (IContract)mocks.CreateMock(typeof(IContract));
            IContractType iContractType = (IContractType)mocks.CreateMock(typeof(IContractType));
            IEmployeeContractBookMark iEmployeeContractBookMark =
(IEmployeeContractBookMark)mocks.CreateMock(typeof(IEmployeeContractBookMark));

            ContractType contracttype = new ContractType(1, "contracttypetest");
            Contract contract = new Contract(1, contracttype, Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2010-1-1"));
            contract.ApplyAssessConditions = new List<ApplyAssessCondition>();
            contract.ApplyAssessConditions.Add(new ApplyAssessCondition(1));
            contract.ApplyAssessConditions.Add(new ApplyAssessCondition(2));
            List<EmployeeContractBookMark> employeeContractBookMarkList = new List<EmployeeContractBookMark>();
            EmployeeContractBookMark employeeContractBookMark = new EmployeeContractBookMark(1, 1, "Ա������", "aa");
            employeeContractBookMarkList.Add(employeeContractBookMark);
            contract.EmployeeContractBookMark = employeeContractBookMarkList;

            Employee employee = new Employee(new Account(1, "", "test"), "", "", new EmployeeTypeEnum(), null, null);
            employee.EmployeeType = EmployeeTypeEnum.NormalEmployee;

            Expect.Call(iEmployee.GetEmployeeByAccountID(employee.Account.Id)).Return(employee);
            Expect.Call(iContract.GetEmployeeContractByContractId(contract.ContractID)).Return(contract);
            Expect.Call(iContractType.GetContractTypeByPkid(contracttype.ContractTypeID)).Return(contracttype);

            Expect.Call(iContract.UpdateEmployeeContract(contract)).Return(1);
            Expect.Call(iEmployeeContractBookMark.DeleteEmployeeContractBookMarkByContractID(1)).Return(1);
            Expect.Call(iEmployeeContractBookMark.InsertEmployeeContractBookMark(employeeContractBookMark)).Return(1);
            Expect.Call(iContract.DeleteApplyAssessConditionsByEmployeeContractID(contract.ContractID)).Return(1);
            Expect.Call(iContract.InsertApplyAssessCondition(contract.ApplyAssessConditions[0])).Return(1);
            Expect.Call(iContract.InsertApplyAssessCondition(contract.ApplyAssessConditions[1])).Return(1);
            mocks.ReplayAll();

            UpdateEmployeeContract target = new UpdateEmployeeContract(contract, employee, iContract, iEmployee, iContractType, iEmployeeContractBookMark);
            target.Excute();
            mocks.VerifyAll();
        }
        //   �޸�Ա����ͬ��Ч���жϣ�
        //1����Ա�����Ѿ����ڵ�Ա��
        //2����ְ��Ա������ǩ��ͬ
        //3���ú�ͬ���Ѿ����ڵĺ�ͬ
        //4����ͬ���ͱ������Ѿ����ڵĺ�ͬ����
        [Test, Description("�޸ĺ�ͬ,Ա��������")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateEmployeeContractEmployeeNotExist()
        {
            MockRepository mocks = new MockRepository();
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            IContract iContract = (IContract)mocks.CreateMock(typeof(IContract));
            IContractType iContractType = (IContractType)mocks.CreateMock(typeof(IContractType));

            ContractType contracttype = new ContractType(1, "contracttypetest");
            Contract contract = new Contract(1, contracttype, Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2010-1-1"));

            Employee employee = new Employee(new Account(1, "", "test"), "", "", new EmployeeTypeEnum(), null, null);

            Expect.Call(iEmployee.GetEmployeeByAccountID(employee.Account.Id)).Return(null);
            mocks.ReplayAll();

            UpdateEmployeeContract target = new UpdateEmployeeContract(contract, employee, iContract, iEmployee, iContractType, null);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("�޸���ְԱ����ͬ")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateEmployeeContractEmployeeHasLeft()
        {
            MockRepository mocks = new MockRepository();
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            IContract iContract = (IContract)mocks.CreateMock(typeof(IContract));
            IContractType iContractType = (IContractType)mocks.CreateMock(typeof(IContractType));

            ContractType contracttype = new ContractType(1, "contracttypetest");
            Contract contract = new Contract(1, contracttype, Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2010-1-1"));

            Employee employee = new Employee(new Account(1, "", "test"), "", "", new EmployeeTypeEnum(), null, null);
            employee.EmployeeType = EmployeeTypeEnum.DimissionEmployee;

            Expect.Call(iEmployee.GetEmployeeByAccountID(employee.Account.Id)).Return(employee);
            mocks.ReplayAll();

            UpdateEmployeeContract target = new UpdateEmployeeContract(contract, employee, iContract, iEmployee, iContractType, null);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("�޸Ĳ����ں�ͬ")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateEmployeeContractContractNotExist()
        {
            MockRepository mocks = new MockRepository();
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            IContract iContract = (IContract)mocks.CreateMock(typeof(IContract));
            IContractType iContractType = (IContractType)mocks.CreateMock(typeof(IContractType));

            ContractType contracttype = new ContractType(1, "contracttypetest");
            Contract contract = new Contract(1, contracttype, Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2010-1-1"));

            Employee employee = new Employee(new Account(1, "", "test"), "", "", new EmployeeTypeEnum(), null, null);
            employee.EmployeeType = EmployeeTypeEnum.NormalEmployee;

            Expect.Call(iEmployee.GetEmployeeByAccountID(employee.Account.Id)).Return(employee);
            Expect.Call(iContract.GetEmployeeContractByContractId(contract.ContractID)).Return(null);
            mocks.ReplayAll();

            UpdateEmployeeContract target = new UpdateEmployeeContract(contract, employee, iContract, iEmployee, iContractType, null);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("�޸ĺ�ͬ�����Ͳ�����")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateEmployeeContractContractTypeNotExist()
        {
            MockRepository mocks = new MockRepository();
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            IContract iContract = (IContract)mocks.CreateMock(typeof(IContract));
            IContractType iContractType = (IContractType)mocks.CreateMock(typeof(IContractType));

            ContractType contracttype = new ContractType(1, "contracttypetest");
            Contract contract = new Contract(1, contracttype, Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2010-1-1"));

            Employee employee = new Employee(new Account(1, "", "test"), "", "", new EmployeeTypeEnum(), null, null);
            employee.EmployeeType = EmployeeTypeEnum.NormalEmployee;

            Expect.Call(iEmployee.GetEmployeeByAccountID(employee.Account.Id)).Return(employee);
            Expect.Call(iContract.GetEmployeeContractByContractId(contract.ContractID)).Return(contract);
            Expect.Call(iContractType.GetContractTypeByPkid(contracttype.ContractTypeID)).Return(null);
            mocks.ReplayAll();

            UpdateEmployeeContract target = new UpdateEmployeeContract(contract, employee, iContract, iEmployee, iContractType, null);
            target.Excute();
            mocks.VerifyAll();
        }
    }
}