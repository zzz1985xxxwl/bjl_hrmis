//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddEmployeeContractTest.cs
// 创建者: 张燕
// 创建日期: 2008-05-21
// 概述: 新增员工合同测试
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
    public class AddEmployeeContractTest
    {
        [Test, Description("新增员工合同,无发起条件设置")]
        public void AddEmployeeContractSuccess1()
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
            EmployeeContractBookMark employeeContractBookMark = new EmployeeContractBookMark(1,1,"员工姓名","aa");
            employeeContractBookMarkList.Add(employeeContractBookMark);
            contract.EmployeeContractBookMark = employeeContractBookMarkList;
            Employee employee = new Employee(new Account(1, "", "test"), "", "", new EmployeeTypeEnum(), null, null);
            employee.EmployeeType = EmployeeTypeEnum.NormalEmployee;

            Expect.Call(iEmployee.GetEmployeeByAccountID(employee.Account.Id)).Return(employee);
            Expect.Call(iContractType.GetContractTypeByPkid(contracttype.ContractTypeID)).Return(contracttype);
            Expect.Call(iEmployeeContractBookMark.DeleteEmployeeContractBookMarkByContractID(1)).Return(1);
            Expect.Call(iEmployeeContractBookMark.InsertEmployeeContractBookMark(employeeContractBookMark)).Return(1);
            Expect.Call(iContract.InsertEmployeeContract(employee.Account.Id, contract)).Return(1);
            mocks.ReplayAll();

            AddEmployeeContract target = new AddEmployeeContract(contract, employee, iContract, iEmployee, iContractType, iEmployeeContractBookMark);
            target.Excute();
            mocks.VerifyAll();
        }
        [Test, Description("新增员工合同,有发起条件设置")]
        public void AddEmployeeContractSuccess2()
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
            EmployeeContractBookMark employeeContractBookMark = new EmployeeContractBookMark(1, 1, "员工姓名", "aa");
            employeeContractBookMarkList.Add(employeeContractBookMark);
            contract.EmployeeContractBookMark = employeeContractBookMarkList;

            contract.ApplyAssessConditions = new List<ApplyAssessCondition>();
            contract.ApplyAssessConditions.Add(new ApplyAssessCondition(1));
            contract.ApplyAssessConditions.Add(new ApplyAssessCondition(2));

            Employee employee = new Employee(new Account(1, "", "test"), "", "", new EmployeeTypeEnum(), null, null);
            employee.EmployeeType = EmployeeTypeEnum.NormalEmployee;

            Expect.Call(iEmployee.GetEmployeeByAccountID(employee.Account.Id)).Return(employee);
            Expect.Call(iContractType.GetContractTypeByPkid(contracttype.ContractTypeID)).Return(contracttype);
            Expect.Call(iContract.InsertEmployeeContract(employee.Account.Id, contract)).Return(1);
            Expect.Call(iEmployeeContractBookMark.DeleteEmployeeContractBookMarkByContractID(1)).Return(1);
            Expect.Call(iEmployeeContractBookMark.InsertEmployeeContractBookMark(employeeContractBookMark)).Return(1);
            Expect.Call(iContract.InsertApplyAssessCondition(contract.ApplyAssessConditions[0])).Return(1);
            Expect.Call(iContract.InsertApplyAssessCondition(contract.ApplyAssessConditions[1])).Return(1);
            mocks.ReplayAll();

            AddEmployeeContract target = new AddEmployeeContract(contract, employee, iContract, iEmployee, iContractType, iEmployeeContractBookMark);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("要签合同的员工不存在")]
        [ExpectedException(typeof(ApplicationException))]
        public void AddEmployeeContractEmployeeNotExist()
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

            AddEmployeeContract target = new AddEmployeeContract(contract, employee, iContract, iEmployee, iContractType,null);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("要签合同的员工已离职")]
        [ExpectedException(typeof(ApplicationException))]
        public void AddEmployeeContractEmployeeHasLeft()
        {
            MockRepository mocks = new MockRepository();
            IEmployee iEmployee = (IEmployee) mocks.CreateMock(typeof (IEmployee));
            IContract iContract = (IContract) mocks.CreateMock(typeof (IContract));
            IContractType iContractType = (IContractType)mocks.CreateMock(typeof(IContractType));

            ContractType contracttype = new ContractType(1, "contracttypetest");
            Contract contract =
                new Contract(1, contracttype, Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2010-1-1"));

            Employee employee = new Employee(new Account(1, "", "test"), "", "", new EmployeeTypeEnum(), null, null);
            employee.EmployeeType = EmployeeTypeEnum.DimissionEmployee;

            Expect.Call(iEmployee.GetEmployeeByAccountID(employee.Account.Id)).Return(employee);
   ;
            mocks.ReplayAll();

            AddEmployeeContract target = new AddEmployeeContract(contract, employee, iContract, iEmployee, iContractType,null);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("要签合同的合同类型不存在")]
        [ExpectedException(typeof(ApplicationException))]
        public void AddEmployeeContractContractTypeNotExist()
        {
            MockRepository mocks = new MockRepository();
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            IContract iContract = (IContract)mocks.CreateMock(typeof(IContract));
            IContractType iContractType = (IContractType)mocks.CreateMock(typeof(IContractType));

            ContractType contracttype = new ContractType(1, "contracttypetest");
            Contract contract =
                new Contract(1, contracttype, Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2010-1-1"));

            Employee employee = new Employee(new Account(1, "", "test"), "", "", new EmployeeTypeEnum(), null, null);
            employee.EmployeeType = EmployeeTypeEnum.NormalEmployee;

            Expect.Call(iEmployee.GetEmployeeByAccountID(employee.Account.Id)).Return(employee);
            Expect.Call(iContractType.GetContractTypeByPkid(contracttype.ContractTypeID)).Return(null);
            mocks.ReplayAll();

            AddEmployeeContract target = new AddEmployeeContract(contract, employee, iContract, iEmployee, iContractType,null);
            target.Excute();
            mocks.VerifyAll();
        }
    }
}
