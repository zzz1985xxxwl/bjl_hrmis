using System;
using System.Collections.Generic;


namespace SEP.HRMIS.Model.TraineeApplications
{
    public class TraineeApplicationStatus : ParameterBase
    {
        /// <summary>
        /// 培训申请状态
        /// -1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4  审核中
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public TraineeApplicationStatus(int id, string name)
            : base(id, name)
        {
        }

        public static TraineeApplicationStatus All = new TraineeApplicationStatus(-1, "全部");
        public static TraineeApplicationStatus New = new TraineeApplicationStatus(0, "新增");
        public static TraineeApplicationStatus Submit = new TraineeApplicationStatus(1, "提交");
        public static TraineeApplicationStatus ApproveFail = new TraineeApplicationStatus(2, "审核不通过");
        public static TraineeApplicationStatus ApprovePass = new TraineeApplicationStatus(3, "审核通过");
        public static TraineeApplicationStatus Approving = new TraineeApplicationStatus(4, "审核中");

        /// <summary>
        /// 所有的培训申请状态
        /// </summary>
        public static List<TraineeApplicationStatus> AllTraineeApplicationStatuss
        {
            get
            {
                List<TraineeApplicationStatus> allTypes = new List<TraineeApplicationStatus>();
                allTypes.Add(All);
                allTypes.Add(New);
                allTypes.Add(Submit);
                allTypes.Add(ApproveFail);
                allTypes.Add(ApprovePass);
                allTypes.Add(Approving);
                return allTypes;
            }
        }

        /// <summary>
        /// 根据ID查找TraineeApplicationStatus
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static TraineeApplicationStatus FindTraineeApplicationStatus(int id)
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
                    return Approving;
                default:
                    return All;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveTraineeApplicationStatus"></param>
        /// <returns></returns>
        public static string LeaveTraineeApplicationStatusDisplay(TraineeApplicationStatus leaveTraineeApplicationStatus)
        {
            //-1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4 审核中
            switch (leaveTraineeApplicationStatus.Id)
            {
                case 0:
                    return "新增";
                case 1:
                    return "提交";
                case 2:
                    return "审核不通过";
                case 3:
                    return "审核通过";
                case 4:
                    return "审核中";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 是否可以被审批
        /// </summary>
        public static bool CanApproveStatus(TraineeApplicationStatus status)
        {
            if (status.Id == 1 || status.Id == 4)
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
