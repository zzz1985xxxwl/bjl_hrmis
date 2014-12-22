//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateEmployee.cs
// 创建者: 杨俞彬
// 创建日期: 2008-05-22
// 概述: 修改员工
// ----------------------------------------------------------------

using System;
using System.Transactions;
using SEP.HRMIS.Bll.EmployeeAdjustRules;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Positions;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 修改员工信息
    /// </summary>
    public class UpdateEmployee : Transaction
    {
        private static IEmployee _DalEmployee = new EmployeeDal();
        private static IEmployeeHistory _DalEmployeeHistory = new EmployeeHistoryDal();
        private static IEmployeeWelfareHistory _DalEmployeeWelfareHistory = new EmployeeWelfareHistoryDal();
        private static IEmployeeWelfare _DalEmployeeWelfare = new EmployeeWelfareDal();
        private static IAccountBll _IAccountBll;
        private static IDepartmentBll _IDepartmentBll;
        private static IEmployeeSkill _DalEmployeeSkill = new EmployeeSkillDal();
        private readonly Account _Operatoraccount;

        private readonly Employee _Employee;

        /// <summary>
        /// 测试专用
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="operatoraccount"></param>
        /// <param name="mockDalEmployee"></param>
        /// <param name="mockDalAccounts"></param>
        /// <param name="mochEmployeeHistory"></param>
        /// <param name="mockEmployeeSkill"></param>
        /// <param name="mockDepartments"></param>
        /// <param name="mockEmployeeWelfare"></param>
        /// <param name="mockEmployeeWelfareHistory"></param>
        public UpdateEmployee(Employee employee, Account operatoraccount, IEmployee mockDalEmployee,
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
        /// 修改员工构造函数
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="operatoraccount"></param>
        public UpdateEmployee(Employee employee, Account operatoraccount)
        {
            _Employee = employee;
            _Operatoraccount = operatoraccount;

            _IAccountBll = BllInstance.AccountBllInstance;
            _IDepartmentBll = BllInstance.DepartmentBllInstance;
        }

        protected override void ExcuteSelf()
        {
            Employee oldemployee = _DalEmployee.GetEmployeeBasicInfoByAccountID(_Employee.Account.Id);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                //保存层级信息
                PositionGrade grade = _Employee.Account.Position.Grade;
                _Employee.Account = _IAccountBll.GetAccountById(_Employee.Account.Id);
                _Employee.Account.Position.Grade = grade;
                //得到后台帐号
                Account accountOperator = _IAccountBll.GetAccountById(_Operatoraccount.Id);
                //更新员工基本信息
                _DalEmployee.UpdateEmployee(_Employee);
                //员工的技能
                _DalEmployeeSkill.UpdateEmployeeSkill(_Employee);
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
                    SaveEmployeeDiyProcess saveProcess = new SaveEmployeeDiyProcess(_Employee.Account.Id, _Employee.DiyProcessList);
                    saveProcess.Excute();
                }
                //员工调休规则
                if (_Employee.AdjustRule != null)
                {
                    new EditEmployeeAdjustRule(_Employee.Account.Id, _Employee.AdjustRule).Excute();
                }
                //记录员工的历史,再次加载信息，为了拍下当时的部门信息（部门名字，部门主管）
                _Employee.Account.Dept = _IDepartmentBll.GetDepartmentById(_Employee.Account.Dept.Id, null);
                EmployeeHistory employeeHistory =
                    new EmployeeHistory(_Employee, DateTime.Now, accountOperator, "");
                _DalEmployeeHistory.CreateEmployeeHistory(employeeHistory);

                #region SEP相关

                //修改为离职后，要更新SEP信息
                if (_Employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee
                    && oldemployee.EmployeeType != EmployeeTypeEnum.DimissionEmployee)
                {
                    _IAccountBll.SetAccountType(_Employee.Account.Id, VisibleType.None, accountOperator);
                }

                #endregion

                ts.Complete();
            }
        }

        protected override void Validation()
        {
            //离职员工需要离职信息
            if (_Employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee)
            {
                if (_Employee.EmployeeDetails == null || _Employee.EmployeeDetails.Work == null || _Employee.EmployeeDetails.Work.DimissionInfo == null)
                {
                    BllUtility.ThrowException(BllExceptionConst._Employee_NeedDimissionInformation);
                }
            }
        }
    }
}
