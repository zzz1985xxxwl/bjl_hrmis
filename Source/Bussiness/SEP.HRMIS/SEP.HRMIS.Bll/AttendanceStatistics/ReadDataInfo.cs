//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: GetAttendanceRule.cs
// ������:����
// ��������: 2008-10-10
// ����: ʵ��AttendanceRule�ӿ�
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
        /// ͨ��pkid���Ҷ�ȡ���ڵĹ���
        /// </summary>
        public AttendanceReadRule GetAttendanceReadRuleByPkid(int pkid)
        {
            return _DalReadRule.GetAttendanceReadRuleByPkid(pkid);
        }
        /// <summary>
        /// �õ����еĶ�ȡ�������ݵ���ʷ
        /// </summary>
        public List<ReadDataHistory> GetAllReadDataHistory()
        {
            return _DalReadHistory.GetAllReadDataHistory();
        }
        /// <summary>
        /// ͨ��pkid���Ҷ�ȡ�������ݵ���ʷ
        /// </summary>
        public ReadDataHistory GetReadDataHistoryByPkid(int pkid)
        {
            return _DalReadHistory.GetReadDataHistoryByPkid(pkid);
        }
        /// <summary>
        /// �õ����һ�εĶ�ȡ�������ݵ���ʷ
        /// </summary>
        public ReadDataHistory GetLastReadDataHistory()
        {
            return _DalReadHistory.GetLastReadDataHistory();
        }
    }
}
