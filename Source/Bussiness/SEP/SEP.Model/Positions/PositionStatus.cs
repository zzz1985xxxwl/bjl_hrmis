using System;
using System.Collections.Generic;

namespace SEP.Model.Positions
{
    [Serializable]
    public class PositionStatus : ParameterBase
    {
        public PositionStatus(int id, string name)
            : base(id, name)
        {
        }

        public static PositionStatus All = new PositionStatus(-1, "");
        public static PositionStatus Approve = new PositionStatus(1, "批准");
        public static PositionStatus Publish = new PositionStatus(2, "发布");

        public static PositionStatus GetById(int id)
        {
            switch (id)
            {
                case -1:
                    return All;
                case 1:
                    return Approve;
                case 2:
                    return Publish;
                default:
                    return All;
            }
        }

        public static List<PositionStatus> AllPositionStatus
        {
            get
            {
                List<PositionStatus> allGenders = new List<PositionStatus>();
                allGenders.Add(All);
                allGenders.Add(Approve);
                allGenders.Add(Publish);
                return allGenders;
            }
        }
        public static PositionStatus GetByName(string name)
        {
            List<PositionStatus> list = AllPositionStatus;
            foreach (PositionStatus item in list)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return All;
        }
    }

}
