//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: WorkType.cs
// ������: �ߺ�
// ��������: 2008-08-26
// ����: �ù�����
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class WorkType:ParameterBase
    {
        public WorkType(int id,string name)
            :base(id,name)
        {
        }

        public static WorkType Contract = new WorkType(1,"��ͬ��");
        public static WorkType ExternalContract = new WorkType(2, "��������ͬ��");
        public static WorkType ResidenceContract = new WorkType(3, "��ס֤��ͬ��");
        public static WorkType Practicer = new WorkType(4, "ʵϰ��");
        public static WorkType PartTimer = new WorkType(5, "��ְ");
        public static WorkType WorkContract = new WorkType(6, "����");

        public static WorkType GetById(int id)
        {
            switch(id)
            {
                case 1:
                    return Contract;
                case 2:
                    return ExternalContract;
                case 3:
                    return ResidenceContract;
                case 4:
                    return Practicer;
                case 5:
                    return PartTimer;
                case 6:
                    return WorkContract;
                default:
                    return null;
            }
        }

        public static List<WorkType> GetAll()
        {
            List<WorkType> allTypes = new List<WorkType>();
            allTypes.Add(Contract);
            allTypes.Add(ExternalContract);
            allTypes.Add(ResidenceContract);
            allTypes.Add(Practicer);
            allTypes.Add(PartTimer);
            allTypes.Add(WorkContract);

            return allTypes;
        }
    }
}