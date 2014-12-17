//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutApplicationFlow.cs
// Creater:  Xue.wenlong
// Date:  2009-04-16
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.OutApplication
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class OutApplicationFlow
    {
        private int _OutApplicationFlowID;
        private Account _Account;
        private DateTime _OperationTime;
        private string _Remark;
        private RequestStatus _OutApplicationOperation;
        private int _Step;

        /// <summary>
        /// 
        /// </summary>
        public OutApplicationFlow(int pkid,Account account,DateTime operationTime,string remark,RequestStatus operation,int step)
        {
            _OutApplicationFlowID = pkid;
            _Account = account;
            _OperationTime = operationTime;
            _Remark = remark;
            _OutApplicationOperation = operation;
            _Step = step;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="remark"></param>
        public OutApplicationFlow(string remark)
        {
            _Remark = remark;
        }

        #region ����

        /// <summary>
        /// ������̱��
        /// </summary>
        public int OutApplicationFlowID
        {
            get { return _OutApplicationFlowID; }
            set { _OutApplicationFlowID = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public Account Account
        {
            get { return _Account; }
            set { _Account = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime OperationTime
        {
            get { return _OperationTime; }
            set { _OperationTime = value; }
        }

        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public RequestStatus Operation
        {
            get { return _OutApplicationOperation; }
            set { _OutApplicationOperation = value; }
        }

        /// <summary>
        /// ��ǰ״̬
        /// </summary>
        public int Step
        {
            get { return _Step; }
            set { _Step = value; }
        }

        private OutApplicationItem _Item;
        /// <summary>
        /// �������ڽ�����ʾ
        /// </summary>
        public OutApplicationItem Item
        {
            get { return _Item; }
            set { _Item = value; }
        }
        /// <summary>
        ///  �ж�OutApplicationFlows���Ƿ��й�RequestStatus��״̬
        /// </summary>
        /// <param name="OutApplicationFlows"></param>
        /// <param name="RequestStatus"></param>
        /// <returns></returns>
        public static bool IsContainByRequestStatus(List<OutApplicationFlow> OutApplicationFlows, RequestStatus RequestStatus)
        {
            foreach (OutApplicationFlow flow in OutApplicationFlows)
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