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

        #region ����

        /// <summary>
        /// ������̱��
        /// </summary>
        public int OverWorkFlowID
        {
            get { return _OverWorkFlowID; }
            set { _OverWorkFlowID = value; }
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
            get { return _OverWorkOperation; }
            set { _OverWorkOperation = value; }
        }

        /// <summary>
        /// ��ǰ״̬
        /// </summary>
        public int Step
        {
            get { return _Step; }
            set { _Step = value; }
        }


        private OverWorkItem _Item;

        /// <summary>
        /// �������ڽ�����ʾ
        /// </summary>
        public OverWorkItem Item
        {
            get { return _Item; }
            set { _Item = value; }
        }
        /// <summary>
        ///  �ж�OutApplicationFlows���Ƿ��й�RequestStatus��״̬
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