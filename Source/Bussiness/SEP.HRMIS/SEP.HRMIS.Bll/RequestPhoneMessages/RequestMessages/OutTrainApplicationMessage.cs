//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutTrainApplicationMessage.cs
// Creater:  Xue.wenlong
// Date:  2009-10-15
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.OutApplications;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;
using SmsDataContract;

namespace SEP.HRMIS.Bll.RequestPhoneMessages.RequestMessages
{
    /// <summary>
    /// </summary>
    public class OutTrainApplicationMessage: RequestMessageBase
    {
        private static readonly string _Template = "外出培训或wcpx 起始时间 结束时间  地点 原因";
        private static readonly string _Example = "外出培训 200809160900 200809161730  某地 某事";
        private decimal _CostTime;
        private string _Place;

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
        /// <param name="employee"></param>
        /// <param name="message"></param>
        public OutTrainApplicationMessage(Account employee, ReceiveMessageDataModel message)
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
                    ValidateAndInitFromTo(strList[1], strList[2]) &&
                    ValidateAndInitCostTime()  && InitPlace(strList[3]) && InitReason(strList[4]);
            }
        }


        private bool InitPlace(string place)
        {
            _Place = place;
            return true;
        }


        private bool ValidateAndInitCostTime()
        {
            try
            {
                _CostTime = new CalculateOutHour(_From, _To, _Account.Id).Excute();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        private OutApplication BuildOutApplication
        {
            get
            {
                OutApplicationItem outApplicationItem =
                    new OutApplicationItem(0, _From, _To, _CostTime, RequestStatus.Submit,false,0);
                List<OutApplicationItem> items = new List<OutApplicationItem>();
                items.Add(outApplicationItem);
                OutApplication outapplication =
                    new OutApplication(0, _Account, DateTime.Now, _Reason, _From, _To, _CostTime, items, _Place, OutType.Train);
                return outapplication;
            }
        }

        protected override void ExcuteSelf()
        {
            //调用bll层新增方法
            new AddOutApplication(BuildOutApplication, null).Excute();
        }
    }
}