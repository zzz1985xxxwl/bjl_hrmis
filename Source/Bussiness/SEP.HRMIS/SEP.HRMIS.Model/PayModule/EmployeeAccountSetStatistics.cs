//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: EmployeeAccountSetStatistics.cs
// ������: yyb
// ��������: 2009-1-14
// ����: Ա��н��ͳ��
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.Model.PayModule
{
    public class EmployeeSalaryStatistics
    {
        private Department _Department;
        private Position _Position;
        private DateTime _SalaryDay;
        private List<EmployeeSalaryStatisticsItem> _EmployeeSalaryStatisticsItemList;

        public Department Department
        {
            get { return _Department; }
            set { _Department = value; }
        }

        public Position Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        public List<EmployeeSalaryStatisticsItem> EmployeeSalaryStatisticsItemList
        {
            get { return _EmployeeSalaryStatisticsItemList; }
            set { _EmployeeSalaryStatisticsItemList = value; }
        }

        public DateTime SalaryDay
        {
            get { return _SalaryDay; }
            set { _SalaryDay = value; }
        }
    }
}
