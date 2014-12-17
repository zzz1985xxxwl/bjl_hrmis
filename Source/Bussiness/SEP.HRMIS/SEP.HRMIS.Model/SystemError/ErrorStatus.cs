//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ErrorStatus.cs
// Creater:  Xue.wenlong
// Date:  2009-09-28
// Resume:
// ----------------------------------------------------------------

namespace SEP.HRMIS.Model.SystemError
{
    /// <summary>
    /// </summary>
    public class ErrorStatus
    {
         private int _ID;
        private string _Name;
        /// <summary>
        /// </summary>
        public ErrorStatus(int id, string name)
        {
            _ID = id;
            _Name = name;
        }

        public static ErrorStatus ToHandle = new ErrorStatus(0, "´ý´¦Àí");
        public static ErrorStatus Ignore = new ErrorStatus(1, "ºöÂÔ");
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
        public static ErrorStatus GetErrorStatusByID(int id)
        {
            switch (id)
            {
                case 0:
                    return ToHandle;
                case 1:
                    return Ignore;
                default:
                    return null;
            }
        }
    }
}