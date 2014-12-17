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
                return "���ռӰ�";
            }
            else if (type == OverWorkType.ShuangXiu)
            {
                return "��Ϣ�ռӰ�";
            }
            else if (type == OverWorkType.PuTong)
            {
                return "��ͨ�Ӱ�";
            }
            else if (type == OverWorkType.PuTongNotAdjust)
            {
                return "��ͨ�Ӱ�(δ����)";
            }
            else if (type == OverWorkType.JieRiNotAdjust)
            {
                return "���ռӰ�(δ����)";
            }
            else if (type == OverWorkType.ShuangXiuNotAdjust)
            {
                return "��Ϣ�ռӰ�(δ����)";
            }
            return "";
        }

        /// <summary>
        /// </summary>
        public static string GetOverWorkTypeNotAdjustName(OverWorkType type)
        {

                if (type == OverWorkType.JieRi)
                {
                    return "���ռӰ�(δ����)";
                }
                else if (type == OverWorkType.ShuangXiu)
                {
                    return "��Ϣ�ռӰ�(δ����)";
                }
                else if (type == OverWorkType.PuTong)
                {
                    return "��ͨ�Ӱ�(δ����)";
                }
            return "";
        }

        /// <summary>
        /// </summary>
        public static OverWorkType GetOverWorkTypeByName(string type)
        {
            if (type == "���ռӰ�")
            {
                return OverWorkType.JieRi;
            }
            else if (type == "��Ϣ�ռӰ�")
            {
                return OverWorkType.ShuangXiu;
            }
            else if (type == "��ͨ�Ӱ�(δ����)")
            {
                return OverWorkType.PuTongNotAdjust;
            }
            else if (type == "���ռӰ�(δ����)")
            {
                return OverWorkType.JieRiNotAdjust;
            }
            else if (type == "��Ϣ�ռӰ�(δ����)")
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