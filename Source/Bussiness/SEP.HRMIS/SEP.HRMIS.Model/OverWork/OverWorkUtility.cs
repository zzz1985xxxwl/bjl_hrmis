//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkUtility.cs
// Creater:  Xue.wenlong
// Date:  2009-05-08
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Model.OverWork
{
    /// <summary>
    /// 
    /// </summary>
    public class OverWorkUtility
    {
        /// <summary>
        /// </summary>
        public static string GetOverWorkTypeName(OverWorkType type)
        {
            if (type == OverWorkType.JieRi)
            {
                return "节日加班";
            }
            else if (type == OverWorkType.ShuangXiu)
            {
                return "休息日加班";
            }
            else if (type == OverWorkType.PuTong)
            {
                return "普通加班";
            }
            else if (type == OverWorkType.PuTongNotAdjust)
            {
                return "普通加班(未调休)";
            }
            else if (type == OverWorkType.JieRiNotAdjust)
            {
                return "节日加班(未调休)";
            }
            else if (type == OverWorkType.ShuangXiuNotAdjust)
            {
                return "休息日加班(未调休)";
            }
            return "";
        }

        /// <summary>
        /// </summary>
        public static string GetOverWorkTypeNotAdjustName(OverWorkType type)
        {

                if (type == OverWorkType.JieRi)
                {
                    return "节日加班(未调休)";
                }
                else if (type == OverWorkType.ShuangXiu)
                {
                    return "休息日加班(未调休)";
                }
                else if (type == OverWorkType.PuTong)
                {
                    return "普通加班(未调休)";
                }
            return "";
        }

        /// <summary>
        /// </summary>
        public static OverWorkType GetOverWorkTypeByName(string type)
        {
            if (type == "节日加班")
            {
                return OverWorkType.JieRi;
            }
            else if (type == "休息日加班")
            {
                return OverWorkType.ShuangXiu;
            }
            else if (type == "普通加班(未调休)")
            {
                return OverWorkType.PuTongNotAdjust;
            }
            else if (type == "节日加班(未调休)")
            {
                return OverWorkType.JieRiNotAdjust;
            }
            else if (type == "休息日加班(未调休)")
            {
                return OverWorkType.ShuangXiuNotAdjust;
            }
            else
            {
                return OverWorkType.PuTong;
            }
        }

        ///<summary>
        ///</summary>
        public static bool IsAgreed(OverWorkItem overWorkItem)
        {
            foreach (OverWorkFlow flow in overWorkItem.OverWorkFlow)
            {
                if (flow.Operation == RequestStatus.ApprovePass) return true;
            }
            return false;
        }

        ///<summary>
        ///</summary>
        public static bool IsContainAgreed(OverWork overWork)
        {
            foreach (OverWorkItem item in overWork.Item)
            {
                if (IsAgreed(item))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsItemFlowContainStatus(OverWorkItem OverWorkItemItem,RequestStatus requeststatus)
        {
            foreach (OverWorkFlow flow in OverWorkItemItem.OverWorkFlow)
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