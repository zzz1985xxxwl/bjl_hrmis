using System;
using System.Collections.Generic;

namespace SEP.Model.Positions
{
    [Serializable]
    public class PositionNature
    {
        private int _pkid;
        private string _name = string.Empty;
        private string _description = string.Empty;

        public int Pkid
        {
            get
            {
                return _pkid;
            }
            set
            {
                _pkid = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public static PositionNature FindPositionNature(List<PositionNature> positionNatures, int positionNatureid)
        {
            foreach (PositionNature positionNature in positionNatures)
            {
                if (positionNature.Pkid == positionNatureid)
                    return positionNature;
            }
            return null;
        }
        public static bool PositionNaturesIsEqual(List<PositionNature> naturelist1, List<PositionNature> naturelist2)
        {
            if (naturelist2.Count != naturelist1.Count)
            {
                return false;
            }
            foreach (PositionNature pn in naturelist1)
            {
                if (FindPositionNature(naturelist2, pn.Pkid) == null)
                {
                    return false;
                }
            }
            foreach (PositionNature pn in naturelist2)
            {
                if (FindPositionNature(naturelist1, pn.Pkid) == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}