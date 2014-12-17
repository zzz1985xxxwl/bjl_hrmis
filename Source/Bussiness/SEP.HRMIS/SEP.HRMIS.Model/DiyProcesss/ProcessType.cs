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
        /// ���
        /// </summary>
        public static ProcessType LeaveRequest = new ProcessType(0, "�������");

        /// <summary>
        /// �������
        /// </summary>
        public static ProcessType ApplicationTypeOut = new ProcessType(1, "�����������");

        /// <summary>
        /// �Ӱ�����
        /// </summary>
        public static ProcessType ApplicationTypeOverTime = new ProcessType(2, "�Ӱ���������");

        /// <summary>
        /// ����
        /// </summary>
        public static ProcessType Assess = new ProcessType(3, "��Ч��������");

        /// <summary>
        /// ���¸�����
        /// </summary>
        public static ProcessType HRPrincipal = new ProcessType(4, "���¸�����");

        /// <summary>
        /// ְλ��������
        /// </summary>
        public static ProcessType PositionApp = new ProcessType(14, "ְλ��������");

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
        ///// ����
        ///// </summary>
        //public static ProcessType Reimburse = new ProcessType(5, "��������");

        /// <summary>
        /// ��ѵ����
        /// </summary>
        public static ProcessType TraineeApplication = new ProcessType(6, "��ѵ��������");

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
                    return "�������";
                case 1:
                    return "�����������";
                case 2:
                    return "�Ӱ���������";
                case 3:
                    return "��Ч��������";
                case 4:
                    return "���¸�����";
                //case 5:
                //    return "��������";
                case 6:
                    return "��ѵ��������";
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
                case "�������":
                    return 0;
                case "�����������":
                    return 1;
                case "�Ӱ���������":
                    return 2;
                case "��Ч��������":
                    return 3;
                case "���¸�����":
                    return 4;
                //case "��������":
                //    return 5;
                case "��ѵ��������":
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