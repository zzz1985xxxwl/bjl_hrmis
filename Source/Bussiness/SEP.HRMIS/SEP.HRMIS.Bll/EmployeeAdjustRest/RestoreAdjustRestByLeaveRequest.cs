//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: RestoreAdjustRestByLeaveRequest.cs
// Creater: Xue.wenlong
// CreateDate: 2009-09-04
// Resume:
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Model.Enum;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Bll.EmployeeAdjustRest
{
    /// <summary>
    /// 当申请的调休取消后，还原调休 
    /// </summary>
    public class RestoreAdjustRestByLeaveRequest
    {
        private readonly LeaveRequestItem _LeaveRequestItem;
        private readonly IAdjustRest _IAdjustRest = DalFactory.DataAccess.CreateAdjustRest();
        private readonly IAdjustRestHistory _IAdjustRestHistory = DalFactory.DataAccess.CreateAdjustRestHistory();
        private readonly int _AccountID;
        private readonly int _LeaveRequestID;

        /// <summary>
        /// 
        /// </summary>
        public RestoreAdjustRestByLeaveRequest(LeaveRequestItem item, int accountid, int leaveRequestID)
        {
            _LeaveRequestItem = item;
            _AccountID = accountid;
            _LeaveRequestID = leaveRequestID;
        }

        /// <summary>
        /// for test
        /// </summary>
        public RestoreAdjustRestByLeaveRequest(LeaveRequestItem item, int accountid, int leaveRequestID,
                                               IAdjustRest mockIAdjustRest, IAdjustRestHistory mockIAdjustRestHistory)
            : this(item, accountid, leaveRequestID)
        {
            _IAdjustRest = mockIAdjustRest;
            _IAdjustRestHistory = mockIAdjustRestHistory;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Excute()
        {
            if (!string.IsNullOrEmpty(_LeaveRequestItem.UseList))
            {
                string[] detail = _LeaveRequestItem.UseList.Split('/');
                if (detail != null)
                {
                    foreach (string s in detail)
                    {
                        string[] use = s.Split(',');
                        if (use != null && use.Length == 2)
                        {
                            int adjustid = Convert.ToInt32(use[0]);
                            decimal deletehour = Convert.ToDecimal(use[1]);
                            AdjustRest adjustrest = _IAdjustRest.GetAdjustRestByPKID(adjustid);
                            if (adjustrest != null)
                            {
                                adjustrest.SurplusHours += deletehour;
                                _IAdjustRest.UpdateAdjustRest(adjustrest);
                            }
                        }
                    }
                    CreateHistory();
                }
            }
        }

        /// <summary>
        /// 记录历史
        /// </summary>
        private void CreateHistory()
        {
            string remark;
            AdjustRestHistory _AdjustRestHistory =
                UpdateAdjustRestByOperator.GetNewAdjustRestHistory(AdjustRestHistoryTypeEnum.AdjustRestRequest,
                                                                   _AccountID);
            remark = _LeaveRequestItem.FromDate + " - " + _LeaveRequestItem.ToDate + " 取消调休" +
                     _LeaveRequestItem.CostTime +
                     "小时";
            _AdjustRestHistory.ChangeHours = _LeaveRequestItem.CostTime;
            _AdjustRestHistory.Remark = remark;
            _AdjustRestHistory.RelevantID = _LeaveRequestID;
            _IAdjustRestHistory.InsertAdjustRestHistory(_AccountID, _AdjustRestHistory);
        }
    }
}