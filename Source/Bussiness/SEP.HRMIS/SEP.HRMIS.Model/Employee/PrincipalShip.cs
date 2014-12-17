using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ְ���ܾ������ܾ����������ܡ�����Ա����Ա��
    /// </summary>
   [Serializable]
    public class PrincipalShip : ParameterBase
    {
        /// <summary>
        /// ְ���캯��
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public PrincipalShip(int id, string name) : base(id, name)
        {
        }

        public static PrincipalShip GeneralManager = new PrincipalShip(0, "�ܾ���");
        public static PrincipalShip ViceGeneralManager = new PrincipalShip(1, "���ܾ���");
        public static PrincipalShip Manager = new PrincipalShip(2, "����");
        public static PrincipalShip Supervisor = new PrincipalShip(3, "����");
        public static PrincipalShip SeniorStaff = new PrincipalShip(4, "����Ա��");
        public static PrincipalShip Staff = new PrincipalShip(5, "Ա��");

        /// <summary>
        /// ����ID�������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PrincipalShip GetById(int id)
        {
            switch (id)
            {
                case 0:
                    return GeneralManager;
                case 1:
                    return ViceGeneralManager;
                case 2:
                    return Manager;
                case 3:
                    return Supervisor;
                case 4:
                    return SeniorStaff;
                case 5:
                    return Staff;
                default:
                    return null;
            }
        }
        /// <summary>
        /// ������е������б�
        /// </summary>
        /// <returns></returns>
        public static List<PrincipalShip> GetAllPrincipalShip()
        {
            List<PrincipalShip> retVal = new List<PrincipalShip>();
            retVal.Add(GeneralManager);
            retVal.Add(ViceGeneralManager);
            retVal.Add(Manager);
            retVal.Add(Supervisor);
            retVal.Add(SeniorStaff);
            retVal.Add(Staff);
            return retVal;
        }
    }
}
