//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: InsertInAndOutRecordLog.cs
// 创建者: 刘丹
// 创建日期: 2008-10-23
// 概述: 修改考勤记录日志
// ----------------------------------------------------------------


using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    using IDal;
    using Model.EmployeeAttendance.AttendanceInAndOutRecord;

    public class InsertInAndOutRecordLog:Transaction
    {
        private readonly IInAndOutRecordLog _DalLog = new AttendanceInAndOutRecordLogDal();
        private readonly AttendanceInAndOutRecordLog _Log;
        private readonly Account _LoginUser;

        public InsertInAndOutRecordLog(AttendanceInAndOutRecordLog log, Account loginUser)
        {
            _LoginUser = loginUser;
            _Log = log;
        }

        public InsertInAndOutRecordLog(AttendanceInAndOutRecordLog log, IInAndOutRecordLog logMock, Account loginUser)
        {
            _LoginUser = loginUser;
            _Log = log;
            _DalLog = logMock;
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _DalLog.InsertInAndOutRecordLog(_Log);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

    }
}
