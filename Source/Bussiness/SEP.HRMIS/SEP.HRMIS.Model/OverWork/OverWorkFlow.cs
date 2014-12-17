//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkFlow.cs
// Creater:  Xue.wenlong
// Date:  2009-05-08
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.OverWork
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class OverWorkFlow
    {
        private int _OverWorkFlowID;
        private Account _Account;
        private DateTime _OperationTime;
        private string _Remark;
        private RequestStatus _OverWorkOperation;
        private int _Step;

        /// <summary>
        /// 
        /// </summary>
        public OverWorkFlow(int pkid, Account account, DateTime operationTime, string remark, RequestStatus operation,
                            int step)
        {
            _OverWorkFlowID = pkid;
            _Account = account;
            _OperationTime = operationTime;
            _Remark = remark;
            _OverWorkOperation = operation;
            _Step = step;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remark"></param>
        public OverWorkFlow(string remark)
        {
            _Remark = remark;
        }

        #region 属性

        /// <summary>
        /// 外出流程编号
        /// </summary>
        public int OverWorkFlowID
        {
            get { return _OverWorkFlowID; }
            set { _OverWorkFlowID = value; }
        }

        /// <summary>
        /// 操作人
        /// </summary>
        public Account Account
        {
            get { return _Account; }
            set { _Account = value; }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime
        {
            get { return _OperationTime; }
            set { _OperationTime = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        /// <summary>
        /// 操作
        /// </summary>
        public RequestStatus Operation
        {
            get { return _OverWorkOperation; }
            set { _OverWorkOperation = value; }
        }

        /// <summary>
        /// 当前状态
        /// </summary>
        public int Step
        {
            get { return _Step; }
            set { _Step = value; }
        }


        private OverWorkItem _Item;

        /// <summary>
        /// 仅仅用于界面显示
        /// </summary>
        public OverWorkItem Item
        {
            get { return _Item; }
            set { _Item = value; }
        }
        /// <summary>
        ///  判断OutApplicationFlows中是否有过RequestStatus的状态
        /// </summary>
        /// <param name="OverWorkFlows"></param>
        /// <param name="RequestStatus"></param>
        /// <returns></returns>
        public static bool IsContainByRequestStatus(List<OverWorkFlow> OverWorkFlows, RequestStatus RequestStatus)
        {
            foreach (OverWorkFlow flow in OverWorkFlows)
            {
                if (flow.Operation.Id == RequestStatus.Id)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}