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
        private static readonly string _Template = "��ٻ�qj ������� ��ʼʱ�� ����ʱ�� ԭ��";
        private static readonly string _Example = "��� ĳ�� 200909160900 200909161730 ��Ϣ";
        private decimal _CostTime;
        private LeaveRequestType _LeaveRequestType;

        /// <summary>
        /// 
        /// </summary>
        public static string TemplageAndExample
        {
            get { return string.Format("����:{0} ����:{1}", _Template, _Example); }
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

        #region �ж϶��Ÿ�ʽ����ֵ

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