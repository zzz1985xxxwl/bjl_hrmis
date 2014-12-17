using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ����״��
    /// </summary>
    [Serializable]
    public class MaritalStatus : ParameterBase
    {
        /// <summary>
        /// ����״�����캯��
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public MaritalStatus(int id, string name)
            : base(id, name)
        {
        }

        public static MaritalStatus UnMarried = new MaritalStatus(0, "δ��");
        public static MaritalStatus Married = new MaritalStatus(1, "�ѻ�");
        public static MaritalStatus Devoice = new MaritalStatus(2, "����");
        public static MaritalStatus SangOu = new MaritalStatus(3, "ɥż");
        public static MaritalStatus UnKnow = new MaritalStatus(4, "����ȷ");
        /// <summary>
        /// ����ID�������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MaritalStatus GetById(int id)
        {
            switch (id)
            {
                case 0:
                    return UnMarried;
                case 1:
                    return Married;
                case 2:
                    return Devoice;
                case 3:
                    return SangOu;
                case 4:
                    return UnKnow;
                default:
                    return null;
            }
        }
        /// <summary>
        /// ������е������б�
        /// </summary>
        /// <returns></returns>
        public static List<MaritalStatus> GetAllMaritalStatus()
        {
            List<MaritalStatus> retVal = new List<MaritalStatus>();
            retVal.Add(UnMarried);
            retVal.Add(Married);
            retVal.Add(Devoice);
            retVal.Add(SangOu);
            retVal.Add(UnKnow);
            return retVal;
        }
    }
}