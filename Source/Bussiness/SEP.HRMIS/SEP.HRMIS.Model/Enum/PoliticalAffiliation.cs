//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: PoliticalAffiliation.cs
// ������: �ߺ�
// ��������: 2008-08-27
// ����: ������ò
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ������ò
    /// </summary>
    [Serializable]
    public class PoliticalAffiliation:ParameterBase
    {
        public PoliticalAffiliation(int id, string name)
            : base(id,name)
        {
        }

        /// <summary>
        /// ��Ա
        /// </summary>
        public static PoliticalAffiliation Party = new PoliticalAffiliation(1, "��Ա");
        /// <summary>
        /// ��Ա
        /// </summary>
        public static PoliticalAffiliation Member = new PoliticalAffiliation(2, "��Ա");
        /// <summary>
        /// Ⱥ��
        /// </summary>
        public static PoliticalAffiliation Mass = new PoliticalAffiliation(3, "Ⱥ��");
        /// <summary>
        /// Ԥ����Ա
        /// </summary>
        public static PoliticalAffiliation PrepParty = new PoliticalAffiliation(4, "Ԥ����Ա");

        public static PoliticalAffiliation GetById(int id)
        {
                 switch(id)
                 {
                     case 1:
                         return Party;
                     case 2:
                         return Member;
                     case 3:
                         return Mass;
                     case 4:
                         return PrepParty;
                     default:
                         return null;
                 }
        }

        public static List<PoliticalAffiliation> AllPoliticalAffiliations
        {
            get
            {
                List<PoliticalAffiliation> allPoliticalAffiliations = new List<PoliticalAffiliation>();
                allPoliticalAffiliations.Add(Party);
                allPoliticalAffiliations.Add(Member);
                allPoliticalAffiliations.Add(Mass);
                allPoliticalAffiliations.Add(PrepParty);
                return allPoliticalAffiliations;
            }
        }
    }
}