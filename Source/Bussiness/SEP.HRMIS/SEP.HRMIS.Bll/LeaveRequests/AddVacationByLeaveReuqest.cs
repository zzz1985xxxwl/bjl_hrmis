//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: AddVacationByLeaveReuqest.cs
// Creater: Xue.wenlong
// CreateDate: 2009-09-02
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Bll.LeaveRequests
{
    /// <summary>
    /// 
    /// </summary>
    public class AddVacationByLeaveReuqest
    {
        private static readonly IVacation _VacationDal = DalFactory.DataAccess.CreateVacation();
        private readonly List<LeaveRequestItem> _LeaveRequestItems;

        /// <summary>
        /// 
        /// </summary>
        public AddVacationByLeaveReuqest(List<LeaveRequestItem> leaveRequestitems)
        {
            _LeaveRequestItems = leaveRequestitems;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Excute()
        {
            foreach (LeaveRequestItem item in _LeaveRequestItems)
            {
                if (!string.IsNullOrEmpty(item.UseList))
                {
                    string[] detail = item.UseList.Split('/');
                    if (detail != null)
                    {
                        foreach (string s in detail)
                        {
                            string[] use = s.Split(',');
                            if (use != null && use.Length == 2)
                            {
                                int vacationid = Convert.ToInt32(use[0]);
                                decimal deletehour = Convert.ToDecimal(use[1]);
                                Vacation vacation = _VacationDal.GetVacationByVacationID(vacationid);
                                if (vacation != null)
                                {
                                    vacation.UsedDayNum -= (deletehour/8);
                                    vacation.SurplusDayNum += (deletehour/8);
                                    _VacationDal.Update(vacation);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}