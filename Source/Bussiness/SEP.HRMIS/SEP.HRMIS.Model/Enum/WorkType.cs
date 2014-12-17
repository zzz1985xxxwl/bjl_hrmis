//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: WorkType.cs
// 创建者: 倪豪
// 创建日期: 2008-08-26
// 概述: 用工性质
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

        public static WorkType Contract = new WorkType(1,"合同工");
        public static WorkType ExternalContract = new WorkType(2, "外劳力合同工");
        public static WorkType ResidenceContract = new WorkType(3, "居住证合同工");
        public static WorkType Practicer = new WorkType(4, "实习生");
        public static WorkType PartTimer = new WorkType(5, "兼职");
        public static WorkType WorkContract = new WorkType(6, "劳务工");

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