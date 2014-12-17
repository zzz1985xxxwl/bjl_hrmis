//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: CalculateOutCityHourDesType.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-04
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Model.OutApplication;
using SEP.IBll;
using SEP.Model.Calendar;
using SEP.Model.SpecialDates;

namespace SEP.HRMIS.Bll.OutApplications
{
    /// <summary>
    /// 
    /// </summary>
    public class CalculateOutCityHourDesType
    {
        private CalculateDays _CalculateDays;
        private readonly IPlanDutyDal _PlanDutyDal = DalFactory.DataAccess.CreatePlanDutyDal();
        private List<PlanDutyDetail> _PlanDutyDetailList;


        ///<summary>
        ///</summary>
        public void GetHourDesType(OutApplicationItem item, int accountid, out decimal putong, out decimal shuangxiu,
                                   out decimal jieri)
        {
            jieri = 0m;
            putong = 0m;
            shuangxiu = 0m;
            DateTime from = item.FromDate;
            DateTime to = item.ToDate;
            _CalculateDays = new CalculateDays(BllInstance.SpecialDateBllInstance.GetAllSpecialDate(null));
            _PlanDutyDetailList = _PlanDutyDal.GetPlanDutyDetailByAccount(accountid, from, to);

            CalculateOutCityHour calculateOutCityHour = new CalculateOutCityHour(from, to, accountid);
            calculateOutCityHour.Excute();
            foreach (DayAttendance attendance in calculateOutCityHour.DayAttendanceList)
            {
                PlanDutyDetail planDutyDetail =
                    PlanDutyDetail.GetPlanDutyDetailByDate(_PlanDutyDetailList, attendance.Date);
                if (_CalculateDays.IsNationalHoliday(attendance.Date))
                {
                    jieri += attendance.Hours;
                }

                else if (planDutyDetail.PlanDutyClass.IsWeek)
                {
                    shuangxiu += attendance.Hours;
                }
                else
                {
                    putong += attendance.Hours;
                }
            }
        }
    }
}