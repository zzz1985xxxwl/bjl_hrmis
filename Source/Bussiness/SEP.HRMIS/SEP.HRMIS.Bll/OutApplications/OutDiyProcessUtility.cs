//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutDiyProcessUtility.cs
// Creater:  Xue.wenlong
// Date:  2009-04-29
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Bll.Requests;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OutApplications
{
    /// <summary>
    /// 
    /// </summary>
    public class OutDiyProcessUtility
    {
        private readonly IEmployeeDiyProcessDal _EmployeeDiyProcessDal = new EmployeeDiyProcessDal();
        private readonly RequestFindOperator _RequestFindOperator = new RequestFindOperator();

       /// <summary>
       /// 
       /// </summary>
       /// <param name="diyProcess"></param>
       /// <param name="item"></param>
       /// <param name="accountId">谁都流程</param>
       /// <returns></returns>
        public Account GetNextOperator(DiyProcess diyProcess, OutApplicationItem item, int accountId)
        {
            int nowStep = item.OutApplicationFlow[item.OutApplicationFlow.Count - 1].Step;
            return _RequestFindOperator.GetNextOperator(diyProcess, nowStep, accountId);
        }


        /// <summary>
        /// 得到当前这部的下一步审核人
        /// </summary>
        public Account GetNextOperator(DiyProcess diyProcess, int step, int accountId)
        {
            return _RequestFindOperator.GetNextOperator(diyProcess, step, accountId);
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public DiyProcess GetOutDiyProcessByAccountID(int accountId)
        {
            return _EmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.ApplicationTypeOut, accountId);
        }

        /// <summary> 
        /// </summary>
        public int GetNextStep(List<OutApplicationFlow> flowList, DiyProcess diyprocess)
        {
            int step = flowList[flowList.Count - 1].Step + 1;
            return _RequestFindOperator.GetNextStep(step, diyprocess);
        }
        /// <summary>
        /// 
        /// </summary>
        public List<Account> GetMailCC(List<OutApplicationFlow> flowList, DiyProcess diyprocess)
        {
            int step = flowList[flowList.Count - 1].Step;
            return diyprocess.DiySteps[step-1].MailAccount;
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