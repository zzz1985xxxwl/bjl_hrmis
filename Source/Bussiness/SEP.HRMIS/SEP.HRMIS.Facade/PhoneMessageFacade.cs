//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: PhoneMessageFacade.cs
// Creater:  Xue.wenlong
// Date:  2009-11-23
// Resume:
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Bll.RequestPhoneMessages;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.PhoneMessage;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// </summary>
    public class PhoneMessageFacade : IPhoneMessageFacade
    {
        private static readonly IPhoneMessage _PhoneMessageDal =DataAccess.CreatePhoneMessage();
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