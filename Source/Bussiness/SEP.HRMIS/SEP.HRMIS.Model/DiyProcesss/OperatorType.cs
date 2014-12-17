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
        /// ����
        /// </summary>
        public static OperatorType YourSelf = new OperatorType(0, "����");

        /// <summary>
        /// ���ž���
        /// </summary>
        public static OperatorType DepartmentLeader = new OperatorType(1, "���ž���");

        /// <summary>
        /// �ϼ����ž���
        /// </summary>
        public static OperatorType ParentDepartmentLeader = new OperatorType(2, "�ϼ����ž���");

        /// <summary>
        /// ���ϼ����ž���
        /// </summary>
        public static OperatorType GrandDepartmentLeader = new OperatorType(3, "���ϼ����ž���");

        /// <summary>
        /// �����ϼ����ž���
        /// </summary>
        public static OperatorType GrandGrandDepartmentLeader = new OperatorType(4, "�����ϼ����ž���");

        /// <summary>
        /// �������ϼ����ž���
        /// </summary>
        public static OperatorType GrandGrandGrandDepartmentLeader = new OperatorType(5, "�������ϼ����ž���");

        /// <summary>
        /// ����
        /// </summary>
        public static OperatorType Others = new OperatorType(6, "����");

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
                    return "����";
                case 1:
                    return "���ž���";
                case 2:
                    return "�ϼ����ž���";
                case 3:
                    return "���ϼ����ž���";
                case 4:
                    return "�����ϼ����ž���";
                case 5:
                    return "�������ϼ����ž���";
                case 6:
                    return "����";
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
                case "����":
                    return 0;
                case "���ž���":
                    return 1;
                case "�ϼ����ž���":
                    return 2;
                case "���ϼ����ž���":
                    return 3;
                case "�����ϼ����ž���":
                    return 4;
                case "�������ϼ����ž���":
                    return 5;
                case "����":
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