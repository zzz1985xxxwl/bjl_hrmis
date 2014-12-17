using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model.Request
{
    /// <summary>
    /// 请假状态
    /// </summary>
    [Serializable]
    public class RequestStatus : ParameterBase
    {
        /// <summary>
        /// 请假状态
        /// -1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public RequestStatus(int id, string name)
            : base(id, name)
        {
        }

        public static RequestStatus All = new RequestStatus(-1, "全部");
        public static RequestStatus New = new RequestStatus(0, "新增");
        public static RequestStatus Submit = new RequestStatus(1, "提交");
        public static RequestStatus ApproveFail = new RequestStatus(2, "审核不通过");
        public static RequestStatus ApprovePass = new RequestStatus(3, "审核通过");
        public static RequestStatus Cancelled = new RequestStatus(4, "取消申请");
        public static RequestStatus ApproveCancelFail = new RequestStatus(5, "拒绝取消申请");
        public static RequestStatus ApproveCancelPass = new RequestStatus(6, "批准取消申请");
        public static RequestStatus Approving = new RequestStatus(7, "审核中");
        public static RequestStatus CancelApproving = new RequestStatus(8, "审核取消中");

        /// <summary>
        /// 所有的请假类型
        /// </summary>
        public static List<RequestStatus> AllRequestStatuss
        {
            get
            {
                List<RequestStatus> allTypes = new List<RequestStatus>();
                allTypes.Add(All);
                allTypes.Add(New);
                allTypes.Add(Submit);
                allTypes.Add(ApproveFail);
                allTypes.Add(ApprovePass);
                allTypes.Add(Cancelled);
                allTypes.Add(ApproveCancelFail);
                allTypes.Add(ApproveCancelPass);
                allTypes.Add(Approving);
                allTypes.Add(CancelApproving);
                return allTypes;
            }
        }

        /// <summary>
        /// 根据ID查找RequestStatus
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static RequestStatus FindRequestStatus(int id)
        {
            switch (id)
            {
                case 0:
                    return New;
                case 1:
                    return Submit;
                case 2:
                    return ApproveFail;
                case 3:
                    return ApprovePass;
                case 4:
                    return Cancelled;
                case 5:
                    return ApproveCancelFail;
                case 6:
                    return ApproveCancelPass;
                case 7:
                    return Approving;
                case 8:
                    return CancelApproving;
                default:
                    return All;
            }
        }

        /// <summary>
        /// 判断该状态是否可以被取消
        /// </summary>
        public static bool CanCancelStatus(RequestStatus status)
        {
            bool iRet = false;
            switch (status.Id)
            {
                case 1:
                case 3:
                case 7:
                    iRet = true;
                    break;
            }
            return iRet;
        }

        /// <summary>
        /// 是否可以被审批
        /// </summary>
        public static bool CanApproveStatus(RequestStatus status)
        {
            if (status.Id == 1 || status.Id == 4 || status.Id == 7 || status.Id == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}