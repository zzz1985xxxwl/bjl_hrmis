//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: PhoneMessageFacade.cs
// Creater:  Xue.wenlong
// Date:  2009-11-23
// Resume:
// ----------------------------------------------------------------

using SEP.HRMIS.IDal;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// </summary>
    public class PhoneMessageFacade : IPhoneMessageFacade
    {
        private static readonly IPhoneMessage _PhoneMessageDal = new PhoneMessageDal();
        //public List<PhoneMessage> GetPhoneMessageByCondition(string name, PhoneMessageStatus status)
        //{
        //   return new GetPhoneMessage().GetPhoneMessageByCondition(name, status);
        //}

        public void FinishPhoneMessageByPKID(int pkid)
        {
            _PhoneMessageDal.FinishPhoneMessageByPKID(pkid);
        }
    }
}