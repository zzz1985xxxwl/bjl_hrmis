//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutApplicationUtility.cs
// Creater:  Xue.wenlong
// Date:  2009-04-14
// Resume:
// ---------------------------------------------------------------


using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Model.OutApplication
{
    ///<summary>
    ///</summary>
    public class OutApplicationUtility
    {
        ///<summary>
        ///</summary>
        public static bool IsAgreed(OutApplicationItem outApplicationItem)
        {
            foreach (OutApplicationFlow flow in outApplicationItem.OutApplicationFlow)
            {
                if (flow.Operation == RequestStatus.ApprovePass)
                {
                    return true;
                }
            }
            return false;
        }

        ///<summary>
        ///</summary>
        public static bool IsContainAgreed(OutApplication outApplication)
        {
            foreach (OutApplicationItem item in outApplication.Item)
            {
                if (IsAgreed(item))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// </summary>
        public bool CanChangeAdjust(DiyProcess diyProcess, OutApplicationItem item)
        {
            if (item.Status.Id == RequestStatus.Cancelled.Id || item.Status.Id == RequestStatus.CancelApproving.Id)
            {
                return false;
            }
            List<OutApplicationFlow> flowList = item.OutApplicationFlow;
            if (flowList != null && diyProcess != null && diyProcess.DiySteps != null && flowList.Count > 0)
            {
                int step = flowList[flowList.Count - 1].Step;
                if (step == -1)
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

        public static bool IsItemFlowContainStatus(OutApplicationItem outApplicationItem, RequestStatus requeststatus)
        {
            foreach (OutApplicationFlow flow in outApplicationItem.OutApplicationFlow)
            {
                if (flow.Operation.Id == requeststatus.Id)
                {
                    return true;
                }
            }
            return false;
        }

    }
}