//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: PlanDutyDetail.cs
// 创建者: 王玥琦
// 创建日期: 2008-4-16
// 概述: 排班表内每天的排班详情
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel
{
    ///<summary>
    /// 排班表内每天的排班详情
    ///</summary>
    [Serializable]
    public class PlanDutyDetail
    {
        private int _PlanDutyDetailID;
        private DateTime _Date;
        private DutyClass _PlanDutyClass;

        ///<summary>
        /// 排班详情PKID
        ///</summary>
        public int PlanDutyDetailID
        {
            get { return _PlanDutyDetailID; }
            set { _PlanDutyDetailID = value; }
        }

        ///<summary>
        /// 排班详情中的日期
        ///</summary>
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        ///<summary>
        /// 每天的班别
        ///</summary>
        public DutyClass PlanDutyClass
        {
            get { return _PlanDutyClass; }
            set { _PlanDutyClass = value; }
        }

        /// <summary>
        /// 找到某天的PlanDuty
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
