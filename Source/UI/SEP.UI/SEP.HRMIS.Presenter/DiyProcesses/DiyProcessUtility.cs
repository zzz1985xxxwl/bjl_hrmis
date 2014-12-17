using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;

namespace SEP.HRMIS.Presenter.DiyProcesses
{
    public class DiyProcessUtility
    {
        //public const string _SuccessImage =
        //    "&nbsp;&nbsp;&nbsp;<img src='../../image/cg.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;";
        //public const string _ErrorImage =
        //    "&nbsp;&nbsp;&nbsp;<img src='../../image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;";

        public const string _IsEmpty = "不能为空";
        public const string _ItemNone = " 每个步骤的操作、操作人类型不能为空";
        public const string _OperatorNone = " 操作人不能为空";
        public const string _ItemMoreThanOne = " 该流程至少有一个步骤";
        public const string _ItemMoreThanTwo = " 该流程至少有两个步骤";
        public const string _ItemOnlyOne = " 该流程有且只有一个步骤";
        public const string _WrongStatus = " 操作错误";
        public const string _ReviewStatus = " 提交后至少有一步操作为审核";
        public const string _CancelReviewStatus = " 取消后至少有一步操作为审核";
        public const string _SummarizeCommmentNotLase = " 终结评语只能在最后一个步骤";

        /// <summary>
        /// 为diyStepList在最后一行添加空的item项，DiyStepID为-1
        /// </summary>
        /// <param name="diyProcessTypeID"></param>
        /// <param name="diyStepList"></param>
        /// <returns></returns>
        public static List<DiyStep> AddNullItem(int diyProcessTypeID,List<DiyStep> diyStepList)
        {
            switch (diyProcessTypeID)
            {
                //请假流程
                case 0:
                    DiyStep item1 = new DiyStep(-1, "提交", OperatorType.YourSelf, 0);
                    item1.IfSystem = true;
                    diyStepList.Add(item1);
                    DiyStep item2 = new DiyStep(-1, "审核", OperatorType.DepartmentLeader, 0);
                    diyStepList.Add(item2);
                    DiyStep item3 = new DiyStep(-1, "取消", OperatorType.YourSelf, 0);
                    item3.IfSystem = true;
                    diyStepList.Add(item3);
                    DiyStep item4 = new DiyStep(-1, "审核", OperatorType.DepartmentLeader, 0);
                    diyStepList.Add(item4);
                    break;
                //外出申请流程
                case 1:
                    DiyStep item11 = new DiyStep(-1, "提交", OperatorType.YourSelf, 0);
                    item11.IfSystem = true;
                    diyStepList.Add(item11);
                    DiyStep item12 = new DiyStep(-1, "审核", OperatorType.DepartmentLeader, 0);
                    diyStepList.Add(item12);
                    break;
                //加班申请流程
                case 2:
                    DiyStep item21 = new DiyStep(-1, "提交", OperatorType.YourSelf, 0);
                    item21.IfSystem = true;
                    diyStepList.Add(item21);
                    DiyStep item22 = new DiyStep(-1, "审核", OperatorType.DepartmentLeader, 0);
                    diyStepList.Add(item22);
                    break;
                //考评流程 人力资源评定->个人评定->主管评定->批阅->终结评语
                case 3:
                    DiyStep item31 = new DiyStep(-1, "人力资源评定", OperatorType.Others, 0);
                    diyStepList.Add(item31);
                    DiyStep item32 = new DiyStep(-1, "个人评定", OperatorType.YourSelf, 0);
                    diyStepList.Add(item32);
                    DiyStep item33 = new DiyStep(-1, "主管评定", OperatorType.DepartmentLeader, 0);
                    diyStepList.Add(item33);
                    DiyStep item34 = new DiyStep(-1, "批阅", OperatorType.GrandDepartmentLeader, 0);
                    diyStepList.Add(item34);
                    DiyStep item35 = new DiyStep(-1, "终结评语", OperatorType.Others, 0);
                    diyStepList.Add(item35);
                    break;
                //人事负责人
                case 4:
                    DiyStep item41 = new DiyStep(-1, "发信", OperatorType.YourSelf, 0);
                    item41.IfSystem = true;
                    diyStepList.Add(item41);
                    break;
                //报销流程
                case 5:
                    DiyStep item51 = new DiyStep(-1, "审核", OperatorType.DepartmentLeader, 0);
                    diyStepList.Add(item51);
                    break;

                //培训申请流程
                case 6:
                    DiyStep item61 = new DiyStep(-1, "提交", OperatorType.YourSelf, 0);
                    item61.IfSystem = true;
                    diyStepList.Add(item61);
                    DiyStep item62 = new DiyStep(-1, "审核", OperatorType.DepartmentLeader, 0);
                    diyStepList.Add(item62);
                    break;

                    //其他
                default:
                    DiyStep item5 = new DiyStep(-1, "", OperatorType.YourSelf, 0);
                    diyStepList.Add(item5);
                    break;

            }
            return diyStepList;
        }

        public static Dictionary<string, string> GetProcessTypeSource()
        {
            return ProcessType.GetProcessType();
        }

        public static Dictionary<string, string> GetAllProcessType()
        {
            return ProcessType.GetAllProcessType();
        }

        public static Dictionary<string, string> GetSystemStatusSource(int processTypeID)
        {
            Dictionary<string, string> statusSource = new Dictionary<string, string>();
            //0 请假流程; 1 外出申请流程; 2 加班申请流程; 3 考评流程; 4 人事负责人
            switch(processTypeID)
            {
                case 0:
                    //提交->审核->取消->审核
                    statusSource.Add("0", "提交");
                    statusSource.Add("1", "审核");
                    statusSource.Add("2", "取消");
                    statusSource.Add("3", "审核");
                    break;
                case 1:
                    //提交->审核
                    statusSource.Add("0", "提交");
                    statusSource.Add("1", "审核");
                    statusSource.Add("2", "可以改调休");
                    break;
                case 2:
                    //提交->审核，且提交只能是本人操作。审核又分审核和可以改调休
                    statusSource.Add("0", "提交");
                    statusSource.Add("1", "审核");
                    statusSource.Add("2", "可以改调休");
                    break;
                case 3:
                    //人事评定->个人评定->主管评定->批阅
                    statusSource.Add("0", "人力资源评定");
                    statusSource.Add("1", "个人评定");
                    statusSource.Add("2", "主管评定");
                    statusSource.Add("3", "批阅");
                    statusSource.Add("4", "终结评语");
                    break;
                case 4:
                    //发信
                    statusSource.Add("0", "发信");
                    break;
                case 5:
                    //报销流程
                    statusSource.Add("0", "审核");
                    statusSource.Add("1", "部门领导电子签名");
                    statusSource.Add("2", "财务电子签名");
                    statusSource.Add("3", "CEO电子签名");
                    break;
                case 6:
                    //培训申请流程
                    statusSource.Add("0", "提交");
                    statusSource.Add("1", "审核");
                    break;
            }
            return statusSource;
        }

        public static Dictionary<string, string> GetStatusSource(int processTypeID)
        {
            Dictionary<string, string> statusSource = new Dictionary<string, string>();
            //0 请假流程; 1 外出申请流程; 2 加班申请流程; 3 考评流程; 4 人事负责人
            switch (processTypeID)
            {
                case 0:
                    //提交->审核->取消->审核
                    statusSource.Add("1", "审核");
                    break;
                case 1:
                    //提交->审核
                    statusSource.Add("1", "审核");
                    statusSource.Add("2", "可以改调休");
                    break;
                case 2:
                    //提交->审核，且提交只能是本人操作。审核又分审核和可以改调休
                    statusSource.Add("1", "审核");
                    statusSource.Add("2", "可以改调休");
                    break;
                case 3:
                    //人事评定->个人评定->主管评定->批阅
                    statusSource.Add("0", "人力资源评定");
                    statusSource.Add("1", "个人评定");
                    statusSource.Add("2", "主管评定");
                    statusSource.Add("3", "批阅");
                    statusSource.Add("4", "终结评语");
                    break;
                case 4:
                    //发信
                    statusSource.Add("0", "发信");
                    break;
                case 5:
                    //报销流程
                    statusSource.Add("0", "审核");
                    statusSource.Add("1", "部门领导电子签名");
                    statusSource.Add("2", "财务电子签名");
                    statusSource.Add("3", "CEO电子签名");
                    break;
                case 6:
                    //培训申请流程
                    statusSource.Add("1", "审核");
                    break;
            }
            return statusSource;
        }

        public static Dictionary<string, string> GetOperatorSource()
        {
            return OperatorType.GetOperatorType();
        }
    }
}
