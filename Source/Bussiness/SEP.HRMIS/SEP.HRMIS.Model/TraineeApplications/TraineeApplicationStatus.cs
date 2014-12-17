using System;
using System.Collections.Generic;


namespace SEP.HRMIS.Model.TraineeApplications
{
    public class TraineeApplicationStatus : ParameterBase
    {
        /// <summary>
        /// ��ѵ����״̬
        /// -1 ȫ��;0 ����;1 �ύ;2 ��˲�ͨ��;3 ���ͨ��;4  �����
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public TraineeApplicationStatus(int id, string name)
            : base(id, name)
        {
        }

        public static TraineeApplicationStatus All = new TraineeApplicationStatus(-1, "ȫ��");
        public static TraineeApplicationStatus New = new TraineeApplicationStatus(0, "����");
        public static TraineeApplicationStatus Submit = new TraineeApplicationStatus(1, "�ύ");
        public static TraineeApplicationStatus ApproveFail = new TraineeApplicationStatus(2, "��˲�ͨ��");
        public static TraineeApplicationStatus ApprovePass = new TraineeApplicationStatus(3, "���ͨ��");
        public static TraineeApplicationStatus Approving = new TraineeApplicationStatus(4, "�����");

        /// <summary>
        /// ���е���ѵ����״̬
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
        /// ����ID����TraineeApplicationStatus
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
            //-1 ȫ��;0 ����;1 �ύ;2 ��˲�ͨ��;3 ���ͨ��;4 �����
            switch (leaveTraineeApplicationStatus.Id)
            {
                case 0:
                    return "����";
                case 1:
                    return "�ύ";
                case 2:
                    return "��˲�ͨ��";
                case 3:
                    return "���ͨ��";
                case 4:
                    return "�����";
                default:
                    return "";
            }
        }

        /// <summary>
        /// �Ƿ���Ա�����
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
