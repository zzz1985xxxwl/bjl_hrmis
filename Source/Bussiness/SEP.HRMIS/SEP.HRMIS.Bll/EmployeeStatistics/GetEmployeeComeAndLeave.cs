//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: GetEmployeeComeAndLeave.cs
// ������: �����
// ��������: 2008-11-13
// ����: Ա��ͳ��
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ����Ա����ְ��ְͳ��
    /// </summary>
    public class GetEmployeeComeAndLeave
    {
        private static GetEmployeeHistory _BllEmployeeHistory = new GetEmployeeHistory();
        /// <summary>
        /// ����
        /// </summary>
        public GetEmployeeHistory MockGetEmployeeHistory
        {
            set { _BllEmployeeHistory = value; }
        }

        /// <summary>
        /// ͳ����Ա�������
        /// </summary>
        /// <param name="dt">ͳ��ʱ�䣬�Ը�ʱ��Ϊ��׼��ͳ�ư����������ڵĽ�һ������</param>
        /// <param name="departmentID">���ű��</param>
        /// <returns>��ͳ��ʱ��Ϊֹ����һ�����Ա�������</returns>
        /// <param name="accountoperator"></param>
        public List<EmployeeComeAndLeave> ComeAndLeaveStatistics(DateTime dt, int departmentID, Account accountoperator)
        {
            List<Employee> allEmployeeSource = new GetEmployee().GetAllEmployeeBasicInfo();
            List<EmployeeComeAndLeave> employeeComeAndLeaveList = new List<EmployeeComeAndLeave>();
            dt = new DateTime(dt.Year, dt.Month, 1); //��λ��dt���µ�һ�죬��2009-3-1
            List<Employee> endDtEmployeeList = null;
            for (int i = 11; i >= 0; i--) //��ǰ���11���¿�ʼ����
            {
                DateTime thisMonthlastDate = dt.AddMonths(-i).AddMonths(1).AddDays(-1); //��������һ��

                List<Employee> outEndDtEmployeeList;
                EmployeeComeAndLeave employeeComeAndLeave =
                    ComeAndLeaveStatisticsOnlyOneMonth(thisMonthlastDate, departmentID, accountoperator,
                                                       endDtEmployeeList, out outEndDtEmployeeList, allEmployeeSource);
                endDtEmployeeList = outEndDtEmployeeList;//Ϊ��֧��ComeAndLeaveStatisticsOnlyOneMonth���������ã���endDtEmployeeList��Ҫ�ظ���ȡ����
                //endDtEmployeeList ��ֵҪ��������һ��ѭ����

                employeeComeAndLeaveList.Add(employeeComeAndLeave);
            }
            return employeeComeAndLeaveList;
        }

        /// <summary>
        /// ͳ����Ա�������
        /// </summary>
        /// <param name="dt">ͳ��ʱ�䣬�Ը�ʱ��Ϊ��׼��ͳ�ư����������ڵĽ�һ������</param>
        /// <param name="departmentID">���ű��</param>
        /// <returns>��ͳ��ʱ��Ϊֹ����һ�����Ա�������</returns>
        /// <param name="accountoperator"></param>
        /// <param name="endDtEmployeeList">����Ϊnull</param>
        /// <param name="outEndDtEmployeeList">����Ϊnull</param>
        /// <param name="allEmployeeSource">����Ϊnull</param>
        public EmployeeComeAndLeave ComeAndLeaveStatisticsOnlyOneMonth(DateTime dt, int departmentID, Account accountoperator,
            List<Employee> endDtEmployeeList, out List<Employee> outEndDtEmployeeList, List<Employee> allEmployeeSource)
        {
            allEmployeeSource = allEmployeeSource ?? new GetEmployee().GetAllEmployeeBasicInfo();
            dt = new DateTime(dt.Year, dt.Month, 1); //��λ��dt���µ�һ�죬��2009-3-1
            DateTime lastMonthlastDate = dt.AddDays(-1); //�ϸ������һ��
            DateTime thisMonthlastDate = dt.AddMonths(1).AddDays(-1); //��������һ��
            List<Employee> startDtEmployeeList = endDtEmployeeList ??
                                                 _BllEmployeeHistory.GetEmployeeOnDutyByDepartmentAndDateTime(departmentID,
                                                                                                              lastMonthlastDate,
                                                                                                              true, accountoperator,
                                                                                                              HrmisPowers.A405, allEmployeeSource);
            endDtEmployeeList = //��ֵҪ��������һ��ѭ����
                _BllEmployeeHistory.GetEmployeeOnDutyByDepartmentAndDateTime(departmentID, thisMonthlastDate, true,
                                                                             accountoperator, HrmisPowers.A405, allEmployeeSource);

            EmployeeComeAndLeave employeeComeAndLeave =
                new EmployeeComeAndLeave(lastMonthlastDate.AddDays(1), startDtEmployeeList, endDtEmployeeList);
            outEndDtEmployeeList = endDtEmployeeList;
            return employeeComeAndLeave;
        }
    }
}
