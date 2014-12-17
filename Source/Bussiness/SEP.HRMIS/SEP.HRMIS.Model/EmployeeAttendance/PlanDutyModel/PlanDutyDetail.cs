//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: PlanDutyDetail.cs
// ������: ���h��
// ��������: 2008-4-16
// ����: �Ű����ÿ����Ű�����
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel
{
    ///<summary>
    /// �Ű����ÿ����Ű�����
    ///</summary>
    [Serializable]
    public class PlanDutyDetail
    {
        private int _PlanDutyDetailID;
        private DateTime _Date;
        private DutyClass _PlanDutyClass;

        ///<summary>
        /// �Ű�����PKID
        ///</summary>
        public int PlanDutyDetailID
        {
            get { return _PlanDutyDetailID; }
            set { _PlanDutyDetailID = value; }
        }

        ///<summary>
        /// �Ű������е�����
        ///</summary>
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        ///<summary>
        /// ÿ��İ��
        ///</summary>
        public DutyClass PlanDutyClass
        {
            get { return _PlanDutyClass; }
            set { _PlanDutyClass = value; }
        }

        /// <summary>
        /// �ҵ�ĳ���PlanDuty
        /// </summary>
        public static PlanDutyDetail GetPlanDutyDetailByDate(List<PlanDutyDetail> planDetailList,DateTime date)
        {
            if(planDetailList!=null)
            {
                foreach (PlanDutyDetail detail in planDetailList)
                {
                    if(detail.Date.Date==date.Date)
                    {
                        return detail;
                    }
                }
            }
            return null;
        }
    }
}
