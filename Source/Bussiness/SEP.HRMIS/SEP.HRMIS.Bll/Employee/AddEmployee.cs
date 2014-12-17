//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddEmployee.cs
// 创建者: 杨俞彬
// 创建日期: 2008-05-22
// 概述: 新增员工
// ----------------------------------------------------------------

using System;
using System.Transactions;
using SEP.HRMIS.Bll.EmployeeAdjustRules;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 新增员工信息
    /// </summary>
    public class AddEmployee : Transaction
    {
        private static IEmployee _DalEmployee = DalFactory.DataAccess.CreateEmployee();
        private static IEmployeeHistory _DalEmployeeHistory = DalFactory.DataAccess.CreateEmployeeHistory();
        private static IEmployeeWelfareHistory _DalEmployeeWelfareHistory = DalFactory.DataAccess.CreateEmployeeWelfareHistory();
        private static IEmployeeWelfare _DalEmployeeWelfare = DalFactory.DataAccess.CreateEmployeeWelfare();
        private static IAccountBll _IAccountBll;
        private static IDepartmentBll _IDepartmentBll;
        private static IEmployeeSkill _DalEmployeeSkill = DalFactory.DataAccess.CreateEmployeeSkill();
        private readonly Account _Operatoraccount;

        protected readonly Employee _Employee;

        /// <summary>
        /// AddEmployee的构造函数，专为测试提供
        /// </summary>
        public AddEmployee(Employee employee, Account operatoraccount, IEmployee mockDalEmployee,
                           IAccountBll mockDalAccounts,
                           IEmployeeHistory mochEmployeeHistory, IEmployeeSkill mockEmployeeSkill,
             IDepartmentBll mockDepartments,IEmployeeWelfare mockEmployeeWelfare,
            IEmployeeWelfareHistory mockEmployeeWelfareHistory)
        {
            _Employee = employee;
            _Operatoraccount = operatoraccount;
            _DalEmployee = mockDalEmployee;
            _DalEmployeeHistory = mochEmployeeHistory;
            _IAccountBll = mockDalAccounts;
            _DalEmployeeSkill = mockEmployeeSkill;
            _IDepartmentBll = mockDepartments;
            _DalEmployeeWelfare = mockEmployeeWelfare;
            _DalEmployeeWelfareHistory = mockEmployeeWelfareHistory;
        }

        /// <summary>
        /// 为AddEmployeeProxy调用
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="operatoraccount"></param>
        public AddEmployee(Employee employee, Account operatoraccount)
        {
            _IAccountBll = BllInstance.AccountBllInstance;
            _IDepartmentBll = BllInstance.DepartmentBllInstance;
            _Employee = employee;
            _Operatoraccount = operatoraccount;
        }
        /// <summary>
        /// 为InitEmployeeProxy调用
        /// </summary>
        /// <param name="newEmployeeAccountID"></param>
        /// <param name="operatoraccount"></param>
        public AddEmployee(int newEmployeeAccountID, Account operatoraccount)
        {
            _IAccountBll = BllInstance.AccountBllInstance;
            _IDepartmentBll = BllInstance.DepartmentBllInstance;
            _Operatoraccount = operatoraccount;
            
            _Employee = new Employee(newEmployeeAccountID, EmployeeTypeEnum.All);
            #region default EmployeeDetails

            _Employee.EmployeeDetails = null;
            #endregion
        }

        protected override void ExcuteSelf()
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                _Employee.Account = _IAccountBll.GetAccountById(_Employee.Account.Id);
                if (_Employee.Account != null
                    && _Employee.Account.Position != null
                    && _Employee.Account.Position.Description != null)
                {
                    _Employee.EmployeeDetails = _Employee.EmployeeDetails ?? new EmployeeDetails();
                    _Employee.EmployeeDetails.Work = _Employee.EmployeeDetails.Work ?? new Work();
                    _Employee.EmployeeDetails.Work.Responsibility = _Employee.Account.Position.Description;
                }

                //得到后台帐号
                Account accountOperator = _IAccountBll.GetAccountById(_Operatoraccount.Id);
                _DalEmployee.CreateEmployee(_Employee);
                //新增员工技能
                _DalEmployeeSkill.InsertEmployeeSkill(_Employee);
                //员工福利包括历史的新增
                if (_Employee.EmployeeWelfare != null)
                {
                    SaveEmployeeWelfare SaveEmployeeWelfare =
                        new SaveEmployeeWelfare(_Employee.Account.Id, _Employee.EmployeeWelfare.SocialSecurity.Type,
                                                _Employee.EmployeeWelfare.SocialSecurity.Base,
                                                _Employee.EmployeeWelfare.SocialSecurity.EffectiveYearMonth,
                                                _Employee.EmployeeWelfare.AccumulationFund.Account,
                                                _Employee.EmployeeWelfare.AccumulationFund.EffectiveYearMonth,
                                                _Employee.EmployeeWelfare.AccumulationFund.Base,
                                                accountOperator.Name,
                                                _Employee.EmployeeWelfare.AccumulationFund.SupplyAccount,
                                                _Employee.EmployeeWelfare.AccumulationFund.SupplyBase,
                                                _Employee.EmployeeWelfare.SocialSecurity.YangLaoBase,
                                                _Employee.EmployeeWelfare.SocialSecurity.ShiYeBase,
                                                _Employee.EmployeeWelfare.SocialSecurity.YiLiaoBase,
                                                _DalEmployeeWelfare, _DalEmployeeWelfareHistory);
                    SaveEmployeeWelfare.Excute();
                }

                //员工自定义流程
                if (_Employee.DiyProcessList != null)
                {
                    SaveEmployeeDiyProcess saveProcess =
                        new SaveEmployeeDiyProcess(_Employee.Account.Id, _Employee.DiyProcessList);
                    saveProcess.Excute();
                }
                //员工调休规则
                if (_Employee.AdjustRule != null)
                {
                    new EditEmployeeAdjustRule(_Employee.Account.Id, _Employee.AdjustRule).Excute();
                }
                //记录员工的历史,再次加载信息，为了拍下当时的部门信息（部门名字，部门主管）
                _Employee.Account.Dept = _IDepartmentBll.GetDepartmentById(_Employee.Account.Dept.Id, null);
                //记录员工的历史
                EmployeeHistory employeeHistory =
                    new EmployeeHistory(_Employee, DateTime.Now, accountOperator, "");
                _DalEmployeeHistory.CreateEmployeeHistory(employeeHistory);
                ts.Complete();
            }
        }

        protected override void Validation()
        {
            //离职员工需要离职信息
            if (_Employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee)
            {
                if (_Employee.EmployeeDetails == null || _Employee.EmployeeDetails.Work == null ||
                    _Employee.EmployeeDetails.Work.DimissionInfo == null)
                {
                    BllUtility.ThrowException(BllExceptionConst._Employee_NeedDimissionInformation);
                }
            }
        }
    }
}