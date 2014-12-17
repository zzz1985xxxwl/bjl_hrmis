//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: PhoneMessageType.cs
// Creater:  Xue.wenlong
// Date:  2009-05-22
// Resume:
// ---------------------------------------------------------------

namespace SEP.HRMIS.Model.PhoneMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class PhoneMessageType
    {
        private int _PKID;
        private PhoneMessageEnumType _PhoneMessageEnumType;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneMessageEnumType"></param>
        /// <param name="pkid"></param>
        public PhoneMessageType(PhoneMessageEnumType phoneMessageEnumType, int pkid)
        {
            _PhoneMessageEnumType = phoneMessageEnumType;
            _PKID = pkid;
        }
        /// <summary>
        /// 
        /// </summary>
        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public PhoneMessageEnumType PhoneMessageEnumType
        {
            get { return _PhoneMessageEnumType; }
            set { _PhoneMessageEnumType = value; }
        }

        public override bool Equals(object obj)
        {
            PhoneMessageType phoneMessageType = obj as PhoneMessageType;
            if (phoneMessageType == null)
            {
                return false;
            }
            else
            {
                if (
                    phoneMessageType.PhoneMessageEnumType.Equals(_PhoneMessageEnumType) &&
                    phoneMessageType.PKID.Equals(_PKID)
                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}