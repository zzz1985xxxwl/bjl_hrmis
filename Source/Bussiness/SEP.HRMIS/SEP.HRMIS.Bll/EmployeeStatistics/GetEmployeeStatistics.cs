//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: GetEmployeeStatistics.cs
// ������: �����
// ��������: 2008-11-13
// ����: Ա��ͳ��
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Accounts;
using SEP.Model.Positions;
using SEP.IBll;

namespace SEP.HRMIS.Bll
{
    using SEP.IBll.Positions;

    /// <summary>
    /// ��ȡԱ��ͳ��
    /// </summary>
    public class GetEmployeeStatistics 
    {
        private static GetEmployeeHistory _GetEmployeeHistory = new GetEmployeeHistory();
        private static IPositionHistory _DalPositionHistory = DalFactory.DataAccess.CreatePositionHistory();
        private static IVacation _DalVacation = DalFactory.DataAccess.CreateVacation();
        private static IEmployeeWelfareHistory _DalEmployeeWelfareHistroy = DalFactory.DataAccess.CreateEmployeeWelfareHistory();
        private IPositionBll _IPositionBll = BllInstance.PositionBllInstance;
        private List<Employee> _Employeesource;
        private DateTime _Date;
        private int _DepartmentID;
        private Account _AccountOperator;
        /// <summary>
        /// 
        /// </summary>
        public GetEmployeeStatistics(DateTime dt, int departmentID, Account accountoperator, List<Employee> employeeSource)
        {
            _Date = dt;
            _DepartmentID = departmentID;
            _AccountOperator = accountoperator;
            _Employeesource = employeeSource;
        }
        /// <summary>
        /// ���캯��������
        /// </summary>
        public GetEmployeeStatistics(IVacation iVacation, IPositionHistory iPositionHistory)
        {
            _DalVacation = iVacation;
            _DalPositionHistory = iPositionHistory;
        }


        /// <summary>
        /// ����
        /// </summary>
        public IPositionBll MockPositionBll
        {
            set { _IPositionBll = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public GetEmployeeHistory MockGetEmployeeHistory
        {
            set { _GetEmployeeHistory = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public EmployeeStatistics BindEmployeeStatistics()
        {
            _Employeesource = _Employeesource ??
                              _GetEmployeeHistory.GetEmployeeOnDutyByDepartmentAndDateTime(_DepartmentID, _Date, true,
                                                                                           _AccountOperator,
                                                                                           HrmisPowers.A405, null);
            List<Employee> employeeList = Employee.CopyEmployeeList(_Employeesource);
            EmployeeStatistics employeeStatistics = new EmployeeStatistics(employeeList);
            employeeStatistics.GenderStatistics();
            employeeStatistics.WorkTypeStatistics();
            employeeStatistics.EducationalBackgroundStatistics();
            employeeStatistics.AgeStatistics();
            employeeStatistics.WorkAgeStatistics();
            return employeeStatistics;
        }
        /// <summary>
        /// ����ͳ�ƣ���ס֤ͳ��
        /// </summary>
        public EmployeeOtherStatistics ResidenceStatistics()
        {
            _Employeesource = _Employeesource ??
                              _GetEmployeeHistory.GetEmployeeOnDutyByDepartmentAndDateTime(_DepartmentID, _Date, true,
                                                                                           _AccountOperator,
                                                                                           HrmisPowers.A405, null);
            List<Employee> employeeList = Employee.CopyEmployeeList(_Employeesource);
            foreach (Employee employee in employeeList)
            {
                employee.EmployeeDetails.StatisticsTime = _Date;
            }
            EmployeeOtherStatistics employeeOtherStatistics = new EmployeeOtherStatistics(employeeList);
            employeeOtherStatistics.ResidencePermitStatistics();
            return employeeOtherStatistics;
        }
        /// <summary>
        /// ����ͳ�ƣ����ͳ��
        /// </summary>
        public EmployeeOtherStatistics VocationStatistics()
        {
            _Employeesource = _Employeesource ??
                              _GetEmployeeHistory.GetEmployeeOnDutyByDepartmentAndDateTime(_DepartmentID, _Date, true,
                                                                                           _AccountOperator,
                                                                                           HrmisPowers.A405, null);
            List<Employee> employeeList = Employee.CopyEmployeeList(_Employeesource);
            foreach (Employee employee in employeeList)
            {
                employee.SocWorkAgeAndVacationList = new SocWorkAgeAndVacationList();
                employee.SocWorkAgeAndVacationList.EmployeeVacations = _DalVacation.GetVacationByAccountID(employee.Account.Id);
                //����籣ͳ��
                employee.EmployeeWelfareHistory = _DalEmployeeWelfareHistroy.GetEmployeeWelfareHistoryByAccountID(employee.Account.Id);
                employee.EmployeeDetails.StatisticsTime = _Date;
            }
            EmployeeOtherStatistics employeeOtherStatistics = new EmployeeOtherStatistics(employeeList);
            employeeOtherStatistics.VocationStatistics();
            //����籣ͳ��
            employeeOtherStatistics.InsuranceStatistics();
            return employeeOtherStatistics;
        }
     

        /// <summary>
        /// ����ͳ�ƣ�ְλ�㼶ͳ��
        /// </summary>
        public List<PositionGradeStatistics> PositionGradeStatistics()
        {
            //List<Position> positions = _DalPositionHistory.GetPositionByDateTime(dt);
            List<PositionGrade> grades = _IPositionBll.GetAllPositionGrade();
            //List<PositionGradeStatistics> positionGradeStatisticsList = TurnToPositionGradeStatisticsList(positions);
             List<PositionGradeStatistics> positionGradeStatisticsList = TurnToGradeStatisticsList(grades);
            OrderPositionGradeStatisticsBySequence(positionGradeStatisticsList);
            foreach (PositionGradeStatistics positionGradeStatistics in positionGradeStatisticsList)
            {
                positionGradeStatistics.Employees = new List<Employee>();
            }
            _Employeesource = _Employeesource ??
                              _GetEmployeeHistory.GetEmployeeOnDutyByDepartmentAndDateTime(_DepartmentID, _Date, true,
                                                                                           _AccountOperator,
                                                                                           HrmisPowers.A405, null);
            List<Employee> employeeList = Employee.CopyEmployeeList(_Employeesource);
            foreach (Employee employee in employeeList)
            {
                //employee.Account.Position.Grade =
                //    _DalPositionHistory.GetPositionByPositionIDAndDateTime(employee.Account.Position.Id, dt).Grade;
                for (int i = 0; i < positionGradeStatisticsList.Count; i++)
                {
                    if ((employee.Account.Position != null && employee.Account.Position.Grade != null)
                        && (employee.Account.Position.Grade.Id == positionGradeStatisticsList[i].PositionGrade.Id))
                    {
                        positionGradeStatisticsList[i].Employees.Add(employee);
                    }
                }
            }
            return positionGradeStatisticsList;

        }

        private static void OrderPositionGradeStatisticsBySequence(List<PositionGradeStatistics> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i].PositionGrade.Sequence > list[j].PositionGrade.Sequence)
                    {
                        PositionGradeStatistics temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

        private static List<PositionGradeStatistics> TurnToPositionGradeStatisticsList(List<Position> positions)
        {
            List<PositionGradeStatistics> iRet = new List<PositionGradeStatistics>();
            for (int i = 0; i < positions.Count; i++)
            {
                if (!ContainPositionGrade(positions[i].Grade, iRet))
                {
                    iRet.Add(new PositionGradeStatistics(positions[i].Grade));
                }
            }

            return iRet;
        }

        private static List<PositionGradeStatistics> TurnToGradeStatisticsList(List<PositionGrade> grades)
        {
            List<PositionGradeStatistics> iRet = new List<PositionGradeStatistics>();
            for (int i = 0; i < grades.Count; i++)
            {
                if (!ContainPositionGrade(grades[i], iRet))
                {
                    iRet.Add(new PositionGradeStatistics(grades[i]));
                }
            }

            return iRet;
        }
        /// <summary>
        /// �Ƿ����positionGrade
        /// </summary>
        /// <param name="positionGrade"></param>
        /// <param name="positionGradeStatisticsList"></param>
        /// <returns></returns>
        private static bool ContainPositionGrade(PositionGrade positionGrade, List<PositionGradeStatistics> positionGradeStatisticsList)
        {
            bool iRet = false;
            foreach (PositionGradeStatistics positionGradeStatistics in positionGradeStatisticsList)
            {
                if (positionGradeStatistics.PositionGrade.Name == positionGrade.Name)
                {
                    iRet = true;
                    break;
                }
            }
            return iRet;
        }
        
    }
}
