//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: InsertReadDataHistory.cs
// 创建者: 刘丹
// 创建日期: 2008-10-16
// 概述: 插入读取数据记录
// ----------------------------------------------------------------


using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    public class InsertReadDataHistory:Transaction
    {
        private readonly IReadDataHistory _DalHistory = new ReadDataHistoryDal();
        private readonly ReadDataHistory _History;
        private int _ReadDataHistoryID;
        private readonly Account _LoginUser;
        public InsertReadDataHistory(ReadDataHistory history, Account loginUser)
        {
            _LoginUser = loginUser;
            _History = history;
        }

        public InsertReadDataHistory(ReadDataHistory history, IReadDataHistory historyMock, Account loginUser)
        {
            _LoginUser = loginUser;
            _History = history;
            _DalHistory = historyMock;
        }

        protected override void Validation()
        {
        }
        public int ReadDataHistoryID
        {
            get
            {
                return _ReadDataHistoryID;
            }
        }
        protected override void ExcuteSelf()
        {
            try
            {
                _ReadDataHistoryID=_DalHistory.InsertReadDataHistory(_History);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}
