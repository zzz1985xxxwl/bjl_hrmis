//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PoliticalAffiliation.cs
// 创建者: 倪豪
// 创建日期: 2008-08-27
// 概述: 政治面貌
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 政治面貌
    /// </summary>
    [Serializable]
    public class PoliticalAffiliation:ParameterBase
    {
        public PoliticalAffiliation(int id, string name)
            : base(id,name)
        {
        }

        /// <summary>
        /// 党员
        /// </summary>
        public static PoliticalAffiliation Party = new PoliticalAffiliation(1, "党员");
        /// <summary>
        /// 团员
        /// </summary>
        public static PoliticalAffiliation Member = new PoliticalAffiliation(2, "团员");
        /// <summary>
        /// 群众
        /// </summary>
        public static PoliticalAffiliation Mass = new PoliticalAffiliation(3, "群众");
        /// <summary>
        /// 预备党员
        /// </summary>
        public static PoliticalAffiliation PrepParty = new PoliticalAffiliation(4, "预备党员");

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