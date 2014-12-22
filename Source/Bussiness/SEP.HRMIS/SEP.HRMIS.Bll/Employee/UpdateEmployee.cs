//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateEmployee.cs
// ������: �����
// ��������: 2008-05-22
// ����: �޸�Ա��
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
    /// �޸�Ա����Ϣ
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
        /// ����ר��
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
        /// �޸�Ա�����캯��
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
                //����㼶��Ϣ
                PositionGrade grade = _Employee.Account.Position.Grade;
                _Employee.Account = _IAccountBll.GetAccountById(_Employee.Account.Id);
                _Employee.Account.Position.Grade = grade;
                //�õ���̨�ʺ�
                Account accountOperator = _IAccountBll.GetAccountById(_Operatoraccount.Id);
                //����Ա��������Ϣ
                _DalEmployee.UpdateEmployee(_Employee);
                //Ա���ļ���
                _DalEmployeeSkill.UpdateEmployeeSkill(_Employee);
                //Ա������������ʷ������
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

                //Ա���Զ�������
                if (_Employee.DiyProcessList != null)
                {
                    SaveEmployeeDiyProcess saveProcess = new SaveEmployeeDiyProcess(_Employee.Account.Id, _Employee.DiyProcessList);
                    saveProcess.Excute();
                }
                //Ա�����ݹ���
                if (_Employee.AdjustRule != null)
                {
                    new EditEmployeeAdjustRule(_Employee.Account.Id, _Employee.AdjustRule).Excute();
                }
                //��¼Ա������ʷ,�ٴμ�����Ϣ��Ϊ�����µ�ʱ�Ĳ�����Ϣ���������֣��������ܣ�
                _Employee.Account.Dept = _IDepartmentBll.GetDepartmentById(_Employee.Account.Dept.Id, null);
                EmployeeHistory employeeHistory =
                    new EmployeeHistory(_Employee, DateTime.Now, accountOperator, "");
                _DalEmployeeHistory.CreateEmployeeHistory(employeeHistory);

                #region SEP���

                //�޸�Ϊ��ְ��Ҫ����SEP��Ϣ
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
            //��ְԱ����Ҫ��ְ��Ϣ
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
