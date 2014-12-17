using System.Collections.Generic;
using System;

namespace SEP.HRMIS.Model.DiyProcesss
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ProcessType : ParameterBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public ProcessType(int id, string name)
            : base(id, name)
        {
        }

        /// <summary>
        /// 请假
        /// </summary>
        public static ProcessType LeaveRequest = new ProcessType(0, "请假流程");

        /// <summary>
        /// 外出申请
        /// </summary>
        public static ProcessType ApplicationTypeOut = new ProcessType(1, "外出申请流程");

        /// <summary>
        /// 加班申请
        /// </summary>
        public static ProcessType ApplicationTypeOverTime = new ProcessType(2, "加班申请流程");

        /// <summary>
        /// 考评
        /// </summary>
        public static ProcessType Assess = new ProcessType(3, "绩效考核流程");

        /// <summary>
        /// 人事负责人
        /// </summary>
        public static ProcessType HRPrincipal = new ProcessType(4, "人事负责人");

        /// <summary>
        /// 职位申请流程
        /// </summary>
        public static ProcessType PositionApp = new ProcessType(14, "职位申请流程");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ProcessType FindProcessTypeByProcessTypeID(int id)
        {
            switch (id)
            {
                case 0:
                    return LeaveRequest;
                case 1:
                    return ApplicationTypeOut;
                case 2:
                    return ApplicationTypeOverTime;
                case 3:
                    return Assess;
                case 4:
                    return HRPrincipal;
                case 14:
                    return PositionApp;
                default:
                    return null;
            }
        }

        ///// <summary>
        ///// 报销
        ///// </summary>
        //public static ProcessType Reimburse = new ProcessType(5, "报销流程");

        /// <summary>
        /// 培训申请
        /// </summary>
        public static ProcessType TraineeApplication = new ProcessType(6, "培训申请流程");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string FindProcessTypeByID(int id)
        {
            switch (id)
            {
                case 0:
                    return "请假流程";
                case 1:
                    return "外出申请流程";
                case 2:
                    return "加班申请流程";
                case 3:
                    return "绩效考核流程";
                case 4:
                    return "人事负责人";
                //case 5:
                //    return "报销流程";
                case 6:
                    return "培训申请流程";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int FindProcessTypeByName(string name)
        {
            switch (name)
            {
                case "请假流程":
                    return 0;
                case "外出申请流程":
                    return 1;
                case "加班申请流程":
                    return 2;
                case "绩效考核流程":
                    return 3;
                case "人事负责人":
                    return 4;
                //case "报销流程":
                //    return 5;
                case "培训申请流程":
                    return 6;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetProcessType()
        {
            Dictionary<string, string> processType = new Dictionary<string, string>();
            processType.Add(LeaveRequest.Id.ToString(), LeaveRequest.Name);
            processType.Add(ApplicationTypeOut.Id.ToString(), ApplicationTypeOut.Name);
            processType.Add(ApplicationTypeOverTime.Id.ToString(), ApplicationTypeOverTime.Name);
            processType.Add(Assess.Id.ToString(), Assess.Name);
            processType.Add(HRPrincipal.Id.ToString(), HRPrincipal.Name);
            //processType.Add(Reimburse.Id.ToString(), Reimburse.Name);
            processType.Add(TraineeApplication.Id.ToString(), TraineeApplication.Name);
            return processType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllProcessType()
        {
            Dictionary<string, string> processType = new Dictionary<string, string>();
            processType.Add("-1", "");
            processType.Add(LeaveRequest.Id.ToString(), LeaveRequest.Name);
            processType.Add(ApplicationTypeOut.Id.ToString(), ApplicationTypeOut.Name);
            processType.Add(ApplicationTypeOverTime.Id.ToString(), ApplicationTypeOverTime.Name);
            processType.Add(Assess.Id.ToString(), Assess.Name);
            processType.Add(HRPrincipal.Id.ToString(), HRPrincipal.Name);
            //processType.Add(Reimburse.Id.ToString(), Reimburse.Name);
            processType.Add(TraineeApplication.Id.ToString(), TraineeApplication.Name);

            return processType;
        }
    }
}