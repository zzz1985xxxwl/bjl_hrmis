//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: PlanDutyTable.cs
// ������: ���h��
// ��������: 2008-4-16
// ����: �Ű��
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel
{
    ///<summary>
    /// �Ű��
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
        /// �Ű��PKID
        ///</summary>
        public int PlanDutyTableID
        {
            get { return _PlanDutyTableID; }
            set { _PlanDutyTableID = value; }
        }
        ///<summary>
        /// �Ű������
        ///</summary>
        public string PlanDutyTableName
        {
            get { return _PlanDutyTableName; }
            set { _PlanDutyTableName = value; }
        }
        ///<summary>
        /// �Ű������
        ///</summary>
        public int Period
        {
            get { return _Period; }
            set { _Period = value; }
        }
        ///<summary>
        /// �Ű����ÿ����Ű������б�
        ///</summary>
        public List<PlanDutyDetail> PlanDutyDetailList
        {
            get { return _PlanDutyDetailList; }
            set { _PlanDutyDetailList = value; }
        }

        ///<summary>
        ///Ӧ�ø��Ű������Ա��������Ϊ��ѯʱ�������ʾ
        ///</summary>
        public string PlanDutyEmployeeNameList
        {
            get { return _PlanDutyEmployeeNameList; }
            set { _PlanDutyEmployeeNameList = value; }
        }

        ///<summary>
        /// ��ʼʱ��
        ///</summary>
        public DateTime FromTime
        {
            get { return _FromTime; }
            set { _FromTime = value; }
        }

        ///<summary>
        /// ����ʱ��
        ///</summary>
        public DateTime ToTime
        {
            get { return _ToTime; }
            set { _ToTime = value; }
        }

        ///<summary>
        /// �Ű����ÿ����Ű������б�
        ///</summary>
        public List<Account> PlanDutyAccountList
        {
            get { return _PlanDutyAccountList; }
            set { _PlanDutyAccountList = value; }
        }
    }
}
