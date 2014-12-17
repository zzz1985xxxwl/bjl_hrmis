//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeComeAndLeave.cs
// 创建者: yyb
// 创建日期: 2008-11-13
// 概述: 员工流动率
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class EmployeeComeAndLeave
    {
        #region 私有变量

        private readonly List<Employee> _EntryEmployeeList = new List<Employee>();
        private readonly List<Employee> _DimissionEmployeeList = new List<Employee>();
        private List<Employee> _MonthLastEmployeeList = new List<Employee>();
        private List<Employee> _MonthFirstEmployeeList = new List<Employee>();
        private decimal _DimissionRate;
        private readonly DateTime _StatisticsTime;
        /// <summary>
        /// 
        /// </summary>
        public EmployeeComeAndLeave()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public EmployeeComeAndLeave(DateTime statisticTime, List<Employee> monthFirstEmployeeList, List<Employee> monthLastEmployeeList)
        {
            _StatisticsTime = statisticTime;
            _MonthFirstEmployeeList = monthFirstEmployeeList;
            _MonthLastEmployeeList = monthLastEmployeeList;
            SetEntryAndDimissionInfo();
        }

        private void SetEntryAndDimissionInfo()
        {
            _MonthLastEmployeeList = _MonthLastEmployeeList ?? new List<Employee>();
            _MonthFirstEmployeeList = _MonthFirstEmployeeList ?? new List<Employee>();
            for (int firstindex = 0; firstindex < _MonthFirstEmployeeList.Count; firstindex++)
            {
                if (
                    Employee.FindEmployeeByAccountID(_MonthLastEmployeeList,
                                                     _MonthFirstEmployeeList[firstindex].Account.Id) == null)
                {
                    //月头还在的人月末不在了
                    _DimissionEmployeeList.Add(_MonthFirstEmployeeList[firstindex]);
                }
            }
            for (int lastindex = 0; lastindex < _MonthLastEmployeeList.Count; lastindex++)
            {
                if (
                    Employee.FindEmployeeByAccountID(_MonthFirstEmployeeList,
                                                     _MonthLastEmployeeList[lastindex].Account.Id) == null)
                {
                    //月头没有出现的人月末出现了
                    _EntryEmployeeList.Add(_MonthLastEmployeeList[lastindex]);
                }
            }
        }

        #endregion

        #region 属性

        /// <summary>
        /// 年
        /// </summary>
        public int Year
        {
            get
            {
                return StatisticsTime.Year;
            }
        }

        /// <summary>
        /// 月
        /// </summary>
        public int Month
        {
            get
            {
                return StatisticsTime.Month;
            }
        }

        /// <summary>
        /// 入职人数
        /// </summary>
        public int Entry
        {
            get
            {
                return _EntryEmployeeList.Count;
            }
        }
        /// <summary>
        /// 入职人员
        /// </summary>
        public List<Employee> EntryEmployeeList
        {
            get { return _EntryEmployeeList; }
        }
        /// <summary>
        /// 离职人数
        /// </summary>
        public int Dimission
        {
            get
            {
                return DimissionEmployeeList.Count;
            }
        }
        /// <summary>
        /// 离职人员
        /// </summary>
        public List<Employee> DimissionEmployeeList
        {
            get { return _DimissionEmployeeList; }
        }
        /// <summary>
        /// 真正的离职人数
        /// </summary>
        public int RealDimission
        {
            get
            {
                return RealDimissionEmployeeList.Count;
            }
        }
        /// <summary>
        /// 真正的离职人数
        /// </summary>
        public List<Employee> RealDimissionEmployeeList
        {
            get
            {
                List<Employee> employeelist = new List<Employee>();
                for (int i = 0; i < _DimissionEmployeeList.Count; i++)
                {
                    if (_DimissionEmployeeList[i] != null
                        && _DimissionEmployeeList[i].EmployeeDetails != null
                        && _DimissionEmployeeList[i].EmployeeDetails.Work != null
                        && _DimissionEmployeeList[i].EmployeeDetails.Work.DimissionInfo != null
                        && _DimissionEmployeeList[i].EmployeeDetails.Work.DimissionInfo.DimissionDate.Year == Year
                        && _DimissionEmployeeList[i].EmployeeDetails.Work.DimissionInfo.DimissionDate.Month == Month)
                    {
                        employeelist.Add(_DimissionEmployeeList[i]);
                    }
                }
                return employeelist;
            }
        }
        /// <summary>
        /// 离职率 = 离职人数/((月初人数+月末人数)/2)
        /// </summary>
        public decimal DimissionRate
        {
            get
            {
                if ((MonthFirstTotal + MonthLastTotal) == 0)
                {
                    _DimissionRate = 0;
                }
                else
                {
                    if ((MonthFirstTotal + MonthLastTotal) == 0)
                    {
                        _DimissionRate = 0;
                    }
                    else
                    {
                        _DimissionRate = RealDimission / ((MonthFirstTotal + MonthLastTotal) / (decimal)2.00);
                    }
                }
                return _DimissionRate;
            }
        }

        /// <summary>
        /// 月末人数
        /// </summary>
        public int MonthLastTotal
        {
            get
            {
                return _MonthLastEmployeeList.Count;
            }
        }
        /// <summary>
        /// 月末人
        /// </summary>
        public List<Employee> MonthLastEmployeeList
        {
            get
            {
                return _MonthLastEmployeeList;
            }
            set
            {
                _MonthLastEmployeeList = value;
            }
        }

        /// <summary>
        /// 月初人
        /// </summary>
        public List<Employee> MonthFirstEmployeeList
        {
            get
            {
                return _MonthFirstEmployeeList;
            }
            set
            {
                _MonthFirstEmployeeList = value;
            }
        }

        /// <summary>
        /// 月初人数 = 月末人数 - 入职人数 + 离职人数 
        /// </summary>
        public int MonthFirstTotal
        {
            get
            {
                return MonthFirstEmployeeList.Count;
            }
        }

        public DateTime StatisticsTime
        {
            get { return _StatisticsTime; }
        }



        #endregion
    }
}
