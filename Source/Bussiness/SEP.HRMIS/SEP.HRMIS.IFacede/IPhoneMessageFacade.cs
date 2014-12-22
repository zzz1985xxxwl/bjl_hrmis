using System.Collections.Generic;
using SEP.HRMIS.Model.PhoneMessage;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPhoneMessageFacade
    {

        /// <summary>
        /// 
        /// </summary>
        void FinishPhoneMessageByPKID(int pkid);
    }
}