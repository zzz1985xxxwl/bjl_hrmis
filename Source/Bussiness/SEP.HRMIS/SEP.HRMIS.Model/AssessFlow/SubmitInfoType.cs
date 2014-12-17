using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model.AssessFlow
{
    /// <summary>
    /// ��������д����
    /// </summary>
    [Serializable]
    public class SubmitInfoType : ParameterBase
    {
        /// <summary>
        /// ��������д����
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public SubmitInfoType(int id, string name)
            : base(id, name)
        {
        }

        /// <summary>
        /// ������Դ����
        /// </summary>
        public static SubmitInfoType HRAssess = new SubmitInfoType(0, "������Դ����");

        /// <summary>
        /// ��������
        /// </summary>
        public static SubmitInfoType MyselfAssess = new SubmitInfoType(1, "��������");

        /// <summary>
        /// ��������
        /// </summary>
        public static SubmitInfoType ManagerAssess = new SubmitInfoType(2, "��������");

        /// <summary>
        /// ����
        /// </summary>
        public static SubmitInfoType Approve = new SubmitInfoType(3, "����");

        /// <summary>
        /// �ս�����
        /// </summary>
        public static SubmitInfoType SummarizeCommment = new SubmitInfoType(4, "�ս�����");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SubmitInfoType RechieveSubmitInfoTypeByID(int id)
        {
            switch (id)
            {
                case 0:
                    return HRAssess;
                case 1:
                    return MyselfAssess;
                case 2:
                    return ManagerAssess;
                case 3:
                    return Approve;
                case 4:
                    return SummarizeCommment;
                default:
                    return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string FindSubmitInfoTypeByID(int id)
        {
            switch (id)
            {
                case 0:
                    return "������Դ����";
                case 1:
                    return "��������";
                case 2:
                    return "��������";
                case 3:
                    return "����";
                case 4:
                    return "�ս�����";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int FindSubmitInfoTypeByName(string name)
        {
            switch (name)
            {
                case "������Դ����":
                    return 0;
                case "��������":
                    return 1;
                case "��������":
                    return 2;
                case "����":
                    return 3;
                case "�ս�����":
                    return 4;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetSubmitInfoType()
        {
            Dictionary<string, string> processType = new Dictionary<string, string>();
            processType.Add(HRAssess.Id.ToString(), HRAssess.Name);
            processType.Add(MyselfAssess.Id.ToString(), MyselfAssess.Name);
            processType.Add(ManagerAssess.Id.ToString(), ManagerAssess.Name);
            processType.Add(Approve.Id.ToString(), Approve.Name);
            processType.Add(SummarizeCommment.Id.ToString(), SummarizeCommment.Name);
            return processType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllSubmitInfoType()
        {
            Dictionary<string, string> processType = new Dictionary<string, string>();
            processType.Add("-1", "");
            processType.Add(HRAssess.Id.ToString(), HRAssess.Name);
            processType.Add(MyselfAssess.Id.ToString(), MyselfAssess.Name);
            processType.Add(ManagerAssess.Id.ToString(), ManagerAssess.Name);
            processType.Add(Approve.Id.ToString(), Approve.Name);
            processType.Add(SummarizeCommment.Id.ToString(), SummarizeCommment.Name);

            return processType;
        }
    }
}