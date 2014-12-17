//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ContractType.cs
// 创建者: 倪豪
// 创建日期: 2008-08-27
// 概述: 性别
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 性别
    /// </summary>
    [Serializable]
    public class Gender:ParameterBase
    {
        public Gender(int id, string name)
            : base(id, name)
        {
        }

        public static Gender Man = new Gender(1, "男");
        public static Gender Woman = new Gender(2, "女");

        public static Gender GetById(int id)
        {
            switch (id)
            {
                case 1:
                    return Man;
                case 2:
                    return Woman;
                default:
                    return null;
            }
        }

        public static List<Gender> AllGenders
        {
            get
            {
                List<Gender> allGenders = new List<Gender>();
                allGenders.Add(Man);
                allGenders.Add(Woman);
                return allGenders;
            }
        }
    }
}