using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model.DiyProcesss
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class OperatorType : ParameterBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public OperatorType(int id, string name)
            : base(id, name)
        {
        }

        /// <summary>
        /// 本人
        /// </summary>
        public static OperatorType YourSelf = new OperatorType(0, "本人");

        /// <summary>
        /// 部门经理
        /// </summary>
        public static OperatorType DepartmentLeader = new OperatorType(1, "部门经理");

        /// <summary>
        /// 上级部门经理
        /// </summary>
        public static OperatorType ParentDepartmentLeader = new OperatorType(2, "上级部门经理");

        /// <summary>
        /// 上上级部门经理
        /// </summary>
        public static OperatorType GrandDepartmentLeader = new OperatorType(3, "上上级部门经理");

        /// <summary>
        /// 上上上级部门经理
        /// </summary>
        public static OperatorType GrandGrandDepartmentLeader = new OperatorType(4, "上上上级部门经理");

        /// <summary>
        /// 上上上上级部门经理
        /// </summary>
        public static OperatorType GrandGrandGrandDepartmentLeader = new OperatorType(5, "上上上上级部门经理");

        /// <summary>
        /// 其他
        /// </summary>
        public static OperatorType Others = new OperatorType(6, "其他");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string FindOperatorTypeByID(int id)
        {
            switch (id)
            {
                case 0:
                    return "本人";
                case 1:
                    return "部门经理";
                case 2:
                    return "上级部门经理";
                case 3:
                    return "上上级部门经理";
                case 4:
                    return "上上上级部门经理";
                case 5:
                    return "上上上上级部门经理";
                case 6:
                    return "其他";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int FindOperatorTypeByName(string name)
        {
            switch (name)
            {
                case "本人":
                    return 0;
                case "部门经理":
                    return 1;
                case "上级部门经理":
                    return 2;
                case "上上级部门经理":
                    return 3;
                case "上上上级部门经理":
                    return 4;
                case "上上上上级部门经理":
                    return 5;
                case "其他":
                    return 6;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetOperatorType()
        {
            Dictionary<string, string> processType = new Dictionary<string, string>();
            processType.Add(YourSelf.Id.ToString(), YourSelf.Name);
            processType.Add(DepartmentLeader.Id.ToString(), DepartmentLeader.Name);
            processType.Add(ParentDepartmentLeader.Id.ToString(), ParentDepartmentLeader.Name);
            processType.Add(GrandDepartmentLeader.Id.ToString(), GrandDepartmentLeader.Name);
            processType.Add(GrandGrandDepartmentLeader.Id.ToString(), GrandGrandDepartmentLeader.Name);
            processType.Add(GrandGrandGrandDepartmentLeader.Id.ToString(), GrandGrandGrandDepartmentLeader.Name);
            processType.Add(Others.Id.ToString(), Others.Name);
            return processType;
        }
    }
}