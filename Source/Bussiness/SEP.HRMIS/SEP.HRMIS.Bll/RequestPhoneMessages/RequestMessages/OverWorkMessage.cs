//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkMessage.cs
// Creater:  Xue.wenlong
// Date:  2009-05-31
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.EmployeeAdjustRest;
using SEP.HRMIS.Bll.OverWorks;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;
using SmsDataContract;

namespace SEP.HRMIS.Bll.RequestPhoneMessages.RequestMessages
{
    /// <summary>
    /// 
    /// </summary>
    public class OverWorkMessage : RequestMessageBase
    {
        private static readonly string _Template = "加班或jb 起始时间 结束时间 项目 原因";
        private static readonly string _Example = "加班 200809160900 200809161730 X项目 赶工";
        private decimal _CostTime;
        private string _Project;
        private OverWorkType _OverWorkType;

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
        public OverWorkMessage(Account account, ReceiveMessageDataModel message)
            : base(account, message)
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
                    ValidateAndInitOverTypeAndCostTime() && ValidateAndInitFromTo(strList[1], strList[2]) &&
                     InitProject(strList[3]) && InitReason(strList[4]);
            }
        }


        private bool InitProject(string project)
        {
            _Project = project;
            return true;
        }

        private bool ValidateAndInitOverTypeAndCostTime()
        {
            try
            {
                CalculateOverWorkHour calculateOverWorkHour = new CalculateOverWorkHour(_From, _To, _Account.Id);
                _CostTime = calculateOverWorkHour.Excute();
                _OverWorkType = calculateOverWorkHour.OverWorkType;
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        private OverWork BuildOverWork
        {
            get
            {
                List<OverWorkItem> overWorkItems = new List<OverWorkItem>();
                OverWorkItem item=new OverWorkItem(0,_From,_To,_CostTime,RequestStatus.Submit,_OverWorkType,true,0);
                item.AdjustHour = new UpdateAdjustRestByOverWork(item, _Account.Id).GetItemAdjustHour();
                overWorkItems.Add(item);
                OverWork overWork =
                    new OverWork(0, _Account, DateTime.Now, _Reason, _From, _To, _CostTime, overWorkItems, _Project);
                return overWork;
            }
        }

        protected override void ExcuteSelf()
        {
            //调用bll层新增方法
            new AddOverWork(BuildOverWork,null).Excute();
        }
    }
}