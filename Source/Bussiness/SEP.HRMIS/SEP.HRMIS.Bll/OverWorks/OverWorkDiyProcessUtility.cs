//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverDiyProcessUtiltiy.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Bll.Requests;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OverWorks
{
    /// <summary>
    /// </summary>
    public class OverWorkDiyProcessUtility
    {
        private readonly IEmployeeDiyProcessDal _EmployeeDiyProcessDal = DalFactory.DataAccess.CreateEmployeeDiyProcessDal();
        private readonly RequestFindOperator _RequestFindOperator = new RequestFindOperator();

        /// <summary>
        /// 
        /// </summary>
        public Account GetNextOperator(DiyProcess diyProcess, OverWorkItem item, int accountId)
        {
            int nowStep = item.OverWorkFlow[item.OverWorkFlow.Count - 1].Step;
            return _RequestFindOperator.GetNextOperator(diyProcess, nowStep, accountId);
        }
        /// <summary>
        /// 
        /// </summary>
        public Account GetNextOperator(DiyProcess diyProcess, int step, int accountId)
        {
            return _RequestFindOperator.GetNextOperator(diyProcess, step, accountId);
        }

        /// <summary>
        /// </summary>
        public DiyProcess GetOverWorkDiyProcessByAccountID(int accountId)
        {
            return _EmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.ApplicationTypeOverTime, accountId);
        }

        /// <summary> 
        /// </summary>
        public int GetNextStep(List<OverWorkFlow> flowList, DiyProcess diyprocess)
        {
            int step = flowList[flowList.Count - 1].Step + 1;
            return _RequestFindOperator.GetNextStep(step, diyprocess);
        }


        /// <summary>
        /// </summary>
        public bool CanChangeAdjust(DiyProcess diyProcess, OverWorkItem item)
        {
            if(item.Status.Id==RequestStatus.Cancelled.Id||item.Status.Id==RequestStatus.CancelApproving.Id)
            {
                return false;
            }
            List<OverWorkFlow> flowList = item.OverWorkFlow;
            if (flowList != null && diyProcess != null && diyProcess.DiySteps != null && flowList.Count > 0)
            {
                int step = flowList[flowList.Count - 1].Step;
                if(step==-1)
                {
                    return false;
                }
                int nowStep = step + 1;
                if (diyProcess.DiySteps[nowStep - 1].Status.Contains("Еїан"))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Account> GetMailCC(List<OverWorkFlow> flowList, DiyProcess diyprocess)
        {
            int step = flowList[flowList.Count - 1].Step;
            return diyprocess.DiySteps[step - 1].MailAccount;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Account> GetLastMailCC(DiyProcess diyprocess)
        {
            return diyprocess.DiySteps[diyprocess.DiySteps.Count - 1].MailAccount;
        } 
    }
}