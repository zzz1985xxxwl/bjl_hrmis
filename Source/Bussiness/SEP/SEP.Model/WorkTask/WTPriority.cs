using System.Collections.Generic;

namespace SEP.Model
{
    public class WTPriority : ParameterBase
    {
        public WTPriority(int id, string name)
            : base(id, name)
        {
        }

        public static WTPriority All = new WTPriority(-1, "");
        public static WTPriority A = new WTPriority(1, "A");
        public static WTPriority B = new WTPriority(2, "B");
        public static WTPriority C = new WTPriority(3, "C");

        public static WTPriority GetById(int id)
        {
            switch (id)
            {
                case -1:
                    return All;
                case 1:
                    return A;
                case 2:
                    return B;
                case 3:
                    return C;
                default:
                    return All;
            }
        }

        public static List<WTPriority> AllWTPriority
        {
            get
            {
                List<WTPriority> allWTPriority = new List<WTPriority>();
                allWTPriority.Add(All);
                allWTPriority.Add(A);
                allWTPriority.Add(B);
                allWTPriority.Add(C);
                return allWTPriority;
            }
        }

        public static List<WTPriority> GetWTPriority
        {
            get
            {
                List<WTPriority> allWTPriority = new List<WTPriority>();
                allWTPriority.Add(A);
                allWTPriority.Add(B);
                allWTPriority.Add(C);
                return allWTPriority;
            }
        }
    }
}