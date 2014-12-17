//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: Vacation.cs
// 创建者: 王玥琦
// 创建日期: 2008-05-14
// 概述: 年假类
// ----------------------------------------------------------------
using System;
using System.Text;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 员工年假类
    /// </summary>
    [Serializable]
    public class Vacation
    {
        private Employee _Employee;
        private int _VacationID;
        private decimal _SurplusDayNum;
        private decimal _UsedDayNum;
        private string _Remark;
        private decimal _VacationDayNum;
        private DateTime _VacationEndDate;
        private DateTime _VacationStartDate;
        /// <summary>
        /// 员工年假构造函数
        /// </summary>
        public Vacation(){}
        /// <summary>
        /// 员工年假构造函数
        /// </summary>
        /// <param name="vacationID"></param>
        /// <param name="employee"></param>
        /// <param name="vacationDayNum"></param>
        /// <param name="vacationStartDate"></param>
        /// <param name="vacationEndDate"></param>
        /// <param name="usedDayNum"></param>
        /// <param name="surplusDayNum"></param>
        /// <param name="remark"></param>
        public Vacation(int vacationID, Employee employee, decimal vacationDayNum, DateTime vacationStartDate,
                        DateTime vacationEndDate, decimal usedDayNum, decimal surplusDayNum,string remark)
        {
            _Employee = employee;
            if (vacationID < 1)
            {
                _VacationID = base.GetHashCode();
            }
            else
            {
                _VacationID = vacationID;
            }
            
            _SurplusDayNum = surplusDayNum;
            _UsedDayNum = usedDayNum;
            _Remark = remark;
            _VacationDayNum = vacationDayNum;
            _VacationEndDate = vacationEndDate;
            _VacationStartDate = vacationStartDate;
        }
        /// <summary>
        /// 编号
        /// </summary>
        public int VacationID
        {
            get
            {
                return _VacationID;
            }
            set
            {
                _VacationID = value;
            }
        }
        /// <summary>
        /// 年假总天数
        /// </summary>
        public decimal VacationDayNum
        {
            get 
            {
                return _VacationDayNum;
            }
            set
            {
                 _VacationDayNum = value;
            }
        }
        /// <summary>
        /// 年假起始时间
        /// </summary>
        public DateTime VacationStartDate
        {
            get
            {
                return _VacationStartDate;
            }
            set
            {
                 _VacationStartDate = value;
            }
        }
        /// <summary>
        /// 年假结束时间
        /// </summary>
        public DateTime VacationEndDate
        {
            get
            {
                return _VacationEndDate;
            }
            set
            {
                _VacationEndDate = value;
            }
        }
        /// <summary>
        /// 使用天数
        /// </summary>
        public decimal UsedDayNum
        {
            get
            {
                return _UsedDayNum;
            }
            set
            {
                 _UsedDayNum = value;
            }
        }
        /// <summary>
        /// 剩余天数
        /// </summary>
        public decimal SurplusDayNum
        {
            get
            {
                return _SurplusDayNum;
            }
            set
            {
                 _SurplusDayNum = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
            }
        }
        /// <summary>
        /// 员工，包括ID和姓名
        /// </summary>
        public Employee Employee
        {
            get
            {
                return _Employee;
            }
            set
            {
                _Employee = value;
            }
        }

        /// <summary>
        /// HashCode
        /// </summary>
        public int HashCode
        {
            get
            {
                return _VacationID;
            }
        }
        /// <summary>
        /// 年假导出
        /// </summary>
        /// <returns></returns>
        public string StatVacationInfo()
        {
            StringBuilder theVationInfo = new StringBuilder();
            theVationInfo.Append(_VacationStartDate.ToShortDateString()).Append("\t").Append(_VacationEndDate.ToShortDateString()).Append("\t").Append(
                _VacationDayNum).Append("\t").Append(_UsedDayNum).Append("\t").Append(_SurplusDayNum).Append("\t").Append(_Remark.Replace("\r",@"\r").Replace("\n",@"\n")).Append("\t");
            return theVationInfo.ToString();
        }
        
    }
}