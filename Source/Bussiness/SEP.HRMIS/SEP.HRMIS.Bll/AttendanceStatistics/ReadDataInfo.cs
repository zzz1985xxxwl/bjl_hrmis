//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetAttendanceRule.cs
// 创建者:刘丹
// 创建日期: 2008-10-10
// 概述: 实现AttendanceRule接口
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    ///<summary>
    ///</summary>
    public class ReadDataInfo
    {
        private readonly IAttendanceReadRule _DalReadRule = new AttendanceReadRuleDal();
        private readonly IReadDataHistory _DalReadHistory = new ReadDataHistoryDal();
        private readonly Account _LoginUser;

        public ReadDataInfo(Account loginUser)
        {
            _LoginUser = loginUser;
        }
        /// <summary>
        /// 通过pkid查找读取考勤的规则
        /// </summary>
        public AttendanceReadRule GetAttendanceReadRuleByPkid(int pkid)
        {
            return _DalReadRule.GetAttendanceReadRuleByPkid(pkid);
        }
        /// <summary>
        /// 得到所有的读取考勤数据的历史
        /// </summary>
        public List<ReadDataHistory> GetAllReadDataHistory()
        {
            return _DalReadHistory.GetAllReadDataHistory();
        }
        /// <summary>
        /// 通过pkid查找读取考勤数据的历史
        /// </summary>
        public ReadDataHistory GetReadDataHistoryByPkid(int pkid)
        {
            return _DalReadHistory.GetReadDataHistoryByPkid(pkid);
        }
        /// <summary>
        /// 得到最后一次的读取考勤数据的历史
        /// </summary>
        public ReadDataHistory GetLastReadDataHistory()
        {
            return _DalReadHistory.GetLastReadDataHistory();
        }
    }
}
