//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: LeaveRequestMessage.cs
// Creater:  Xue.wenlong
// Date:  2009-05-31
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.LeaveRequests;
using SEP.HRMIS.Bll.LeaveRequestTypes;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;
using SmsDataContract;

namespace SEP.HRMIS.Bll.RequestPhoneMessages.RequestMessages
{
    /// <summary>
    /// 
    /// </summary>
    public class LeaveRequestMessage : RequestMessageBase
    {
        private readonly GetLeaveRequestType _GetLeaveRequestType = new GetLeaveRequestType();
        private static readonly string _Template = "请假或qj 请假类型 起始时间 结束时间 原因";
        private static readonly string _Example = "请假 某假 200909160900 200909161730 休息";
        private decimal _CostTime;
        private LeaveRequestType _LeaveRequestType;

        /// <summary>
        /// 
        /// </summary>
        public static string TemplageAndExample
        {
            get { return string.Format("发送:{0} 例如:{1}", _Template, _Example); }
        }

        protected override string GetTemplageAndExample()
        {
            return TemplageAndExample;
        }

        /// <summary>
        /// 
        /// </summary>
        public LeaveRequestMessage(Account employee, ReceiveMessageDataModel message)
            : base(employee, message)
        {
        }

        #region 判断短信格式并赋值

        protected override bool ValidationAndInit()
        {
            List<string> strList = RequestMessageUtility.GetElement(_Message.Content);
            if (strList == null || strList.Count < 1)
            {
                return false;
            }
            else if (strList.Count != RequestMessageUtility.GetElement(_Template).Count)
            {
                return false;
            }
            else
            {
                return
                    ValidateAndInitLeaveType(strList[1]) && ValidateAndInitFromTo(strList[2], strList[3]) &&
                    ValidateAndInitCostTime() && InitReason(strList[4]);
            }
        }

        private bool ValidateAndInitLeaveType(string type)
        {
            List<LeaveRequestType> allLeaveType = _GetLeaveRequestType.GetAllLeaveRequestType();
            if (allLeaveType == null || allLeaveType.Count < 1)
            {
                return false;
            }
            else
            {
                foreach (LeaveRequestType leaveType in allLeaveType)
                {
                    if (leaveType.Name == type)
                    {
                        _LeaveRequestType = leaveType;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ValidateAndInitCostTime()
        {
            try
            {
                CalculateCostHour calculateCostHour =
                    new CalculateCostHour(_From, _To, _Account.Id, _LeaveRequestType.LeaveRequestTypeID);
                _CostTime = calculateCostHour.Excute();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        private LeaveRequest BulidLeaveRequest
        {
            get
            {
                LeaveRequest leaveRequest=new LeaveRequest(0,_Account,_LeaveRequestType,DateTime.Now,_Reason);
                leaveRequest.LeaveRequestItems=new List<LeaveRequestItem>();
                LeaveRequestItem item=new LeaveRequestItem(0,_From,_To,_CostTime,RequestStatus.Submit);
                leaveRequest.LeaveRequestItems.Add(item);
                return leaveRequest;
            }
        }

        protected override void ExcuteSelf()
        {
            new AddLeaveRequest(BulidLeaveRequest,true).Excute();
        }
    }
}