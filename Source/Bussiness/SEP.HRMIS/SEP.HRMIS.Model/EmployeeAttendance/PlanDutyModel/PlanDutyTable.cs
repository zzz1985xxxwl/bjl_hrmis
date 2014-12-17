//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: PlanDutyTable.cs
// 创建者: 王玥琦
// 创建日期: 2008-4-16
// 概述: 排班表
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel
{
    ///<summary>
    /// 排班表
    ///</summary>
    [Serializable]
    public class PlanDutyTable
    {
        private int _PlanDutyTableID;
        private string _PlanDutyTableName;
        private int _Period;
        private List<PlanDutyDetail> _PlanDutyDetailList;
        private string _PlanDutyEmployeeNameList;
        private DateTime _FromTime;
        private DateTime _ToTime;
        private List<Account> _PlanDutyAccountList;

        ///<summary>
        /// 排班表PKID
        ///</summary>
        public int PlanDutyTableID
        {
            get { return _PlanDutyTableID; }
            set { _PlanDutyTableID = value; }
        }
        ///<summary>
        /// 排班表名称
        ///</summary>
        public string PlanDutyTableName
        {
            get { return _PlanDutyTableName; }
            set { _PlanDutyTableName = value; }
        }
        ///<summary>
        /// 排班表周期
        ///</summary>
        public int Period
        {
            get { return _Period; }
            set { _Period = value; }
        }
        ///<summary>
        /// 排班表内每天的排班详情列表
        ///</summary>
        public List<PlanDutyDetail> PlanDutyDetailList
        {
            get { return _PlanDutyDetailList; }
            set { _PlanDutyDetailList = value; }
        }

        ///<summary>
        ///应用该排班的所有员工姓名；为查询时界面的显示
        ///</summary>
        public string PlanDutyEmployeeNameList
        {
            get { return _PlanDutyEmployeeNameList; }
            set { _PlanDutyEmployeeNameList = value; }
        }

        ///<summary>
        /// 开始时间
        ///</summary>
        public DateTime FromTime
        {
            get { return _FromTime; }
            set { _FromTime = value; }
        }

        ///<summary>
        /// 结束时间
        ///</summary>
        public DateTime ToTime
        {
            get { return _ToTime; }
            set { _ToTime = value; }
        }

        ///<summary>
        /// 排班表内每天的排班详情列表
        ///</summary>
        public List<Account> PlanDutyAccountList
        {
            get { return _PlanDutyAccountList; }
            set { _PlanDutyAccountList = value; }
        }
    }
}
