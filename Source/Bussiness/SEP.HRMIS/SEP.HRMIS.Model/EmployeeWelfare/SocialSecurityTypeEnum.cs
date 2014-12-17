//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: SocialSecurityTypeEnum.cs
// Creater:  Xue.wenlong
// Date:  2008-12-23
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class SocialSecurityTypeEnum : ParameterBase
    {
        public SocialSecurityTypeEnum(int id, string name) : base(id, name)
        {
        }

        public static SocialSecurityTypeEnum Null = new SocialSecurityTypeEnum(0, string.Empty);
        /// <summary>
        /// 城市保险
        /// </summary>
        public static SocialSecurityTypeEnum CityInsurance = new SocialSecurityTypeEnum(1, "城市保险");
        /// <summary>
        /// 城镇保险
        /// </summary>
        public static SocialSecurityTypeEnum TownInsurance = new SocialSecurityTypeEnum(2, "城镇保险");
        /// <summary>
        /// 综合保险
        /// </summary>
        public static SocialSecurityTypeEnum ComprehensiveInsurance = new SocialSecurityTypeEnum(3, "综合保险");

        /// <summary>
        /// 
        /// </summary>
        public static SocialSecurityTypeEnum GetById(int id)
        {
            switch (id)
            {
                case 0:
                    return Null;
                case 1:
                    return CityInsurance;
                case 2:
                    return TownInsurance;
                case 3:
                    return ComprehensiveInsurance;
                default:
                    return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static List<SocialSecurityTypeEnum> GetAll()
        {
            return
                new List<SocialSecurityTypeEnum>(
                    new SocialSecurityTypeEnum[] {Null, CityInsurance, TownInsurance, ComprehensiveInsurance});
        }
        /// <summary>
        /// 
        /// </summary>
        public static SocialSecurityTypeEnum GetByName(string name)
        {
            switch (name)
            {
                case "":
                    return Null;
                case "城市保险":
                    return CityInsurance;
                case "城镇保险":
                    return TownInsurance;
                case "综合保险":
                    return ComprehensiveInsurance;
                default:
                    return null;
            }
        }
    }
}