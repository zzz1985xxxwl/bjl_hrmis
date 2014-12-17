//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetInAndOutRecordLog.cs
// 创建者: 刘丹
// 创建日期: 2008-10-23
// 概述: 实现IGetInAndOutRecordLog
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    ///<summary>
    /// 获取员工打卡修改日志信息
    ///</summary>
    public class GetInAndOutRecordLog 
    {
        private readonly Account _LoginUser;
        private readonly IInAndOutRecordLog _DalLog;
        private readonly IAccountBll _IAccountBll;

        ///<summary>
        ///  获取员工打卡修改日志信息
        ///</summary>
        public GetInAndOutRecordLog(Account loginUser)
        {
            _LoginUser = loginUser;
            _IAccountBll = BllInstance.AccountBllInstance;
            _DalLog = DalFactory.DataAccess.CreateInAndOutRecordLog();
        }

        ///<summary>
        /// 条件查询员工打卡修改日志信息
        ///</summary>
        public List<AttendanceInAndOutRecordLog> GetInAndOutLogByCondition(string employeeName, int DempartmentId,
                                                                           DateTime operateTiemFrom,
                                                                           DateTime operateTimeTo, string operatorName,
                                                                           DateTime oldIOTimeFrom, DateTime oldIOTimeTo)
        {
            List<Account> accountList = _IAccountBll.GetAccountByBaseCondition(employeeName, DempartmentId, -1, null, true, null);
            if (DempartmentId == -1)
            {
                accountList = Tools.RemoteUnAuthAccount(accountList, AuthType.HRMIS, _LoginUser, HrmisPowers.A508);
            }

            List<AttendanceInAndOutRecordLog> logs = _DalLog.GetInAndOutLogByCondition(operateTiemFrom, operateTimeTo,
                                                                                       operatorName, oldIOTimeFrom,
                                                                                       oldIOTimeTo);
            for (int i = logs.Count - 1; i >= 0; i--)
            {
                Account temp = Tools.FindAccountById(accountList, logs[i].EmployeeID);

                if (temp == null)
                    logs.RemoveAt(i);
                else
                {
                    logs[i].EmployeeName = temp.Name;
                }
            }
            return logs;
        }
    }
}
