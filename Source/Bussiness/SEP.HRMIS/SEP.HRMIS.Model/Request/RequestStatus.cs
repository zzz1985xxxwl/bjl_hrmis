using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model.Request
{
    /// <summary>
    /// ���״̬
    /// </summary>
    [Serializable]
    public class RequestStatus : ParameterBase
    {
        /// <summary>
        /// ���״̬
        /// -1 ȫ��;0 ����;1 �ύ;2 ��˲�ͨ��;3 ���ͨ��;4 ȡ�����;5 �ܾ�ȡ������;6 ��׼ȡ������;7 �����;8 ���ȡ����
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public RequestStatus(int id, string name)
            : base(id, name)
        {
        }

        public static RequestStatus All = new RequestStatus(-1, "ȫ��");
        public static RequestStatus New = new RequestStatus(0, "����");
        public static RequestStatus Submit = new RequestStatus(1, "�ύ");
        public static RequestStatus ApproveFail = new RequestStatus(2, "��˲�ͨ��");
        public static RequestStatus ApprovePass = new RequestStatus(3, "���ͨ��");
        public static RequestStatus Cancelled = new RequestStatus(4, "ȡ������");
        public static RequestStatus ApproveCancelFail = new RequestStatus(5, "�ܾ�ȡ������");
        public static RequestStatus ApproveCancelPass = new RequestStatus(6, "��׼ȡ������");
        public static RequestStatus Approving = new RequestStatus(7, "�����");
        public static RequestStatus CancelApproving = new RequestStatus(8, "���ȡ����");

        /// <summary>
        /// ���е��������
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
        /// ����ID����RequestStatus
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
        /// �жϸ�״̬�Ƿ���Ա�ȡ��
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
        /// �Ƿ���Ա�����
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