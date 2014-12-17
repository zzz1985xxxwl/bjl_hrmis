//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: OutType.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-30
// Resume: 
// ----------------------------------------------------------------

using System.Collections.Generic;

namespace SEP.HRMIS.Model.OutApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class OutType
    {
        private int _ID;
        private string _Name;

        /// <summary>
        /// 
        /// </summary>
        public OutType(int id, string name)
        {
            _ID = id;
            _Name = name;
        }

        public static OutType All = new OutType(-1, "");
        public static OutType InCity = new OutType(0, "市内");
        public static OutType OutCity = new OutType(1, "出差");
        public static OutType Train = new OutType(2, "培训");//同市内

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static OutType GetOutTypeByID(int id)
        {
            if (id == OutCity.ID)
            {
                return OutCity;
            }
            else if (id == InCity.ID)
            {
                return InCity;
            }
            else
            {
                return Train;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static OutType GetOutTypeByName(string name)
        {
            if (name == OutCity.Name)
            {
                return OutCity;
            }
            else if (name == InCity.Name)
            {
                return InCity;
            }
            else
            {
                return Train;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<OutType> GetAllOutType()
        {
            List<OutType> outTypes = new List<OutType>();
            outTypes.Add(InCity);
            outTypes.Add(OutCity);
            outTypes.Add(Train);
            return outTypes;
        }
    }
}