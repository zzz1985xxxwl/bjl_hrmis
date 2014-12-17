//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: HandleConfirm.cs
// Creater:  Xue.wenlong
// Date:  2009-05-25
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.Model.PhoneMessage;

namespace SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages
{
    /// <summary>
    /// 
    /// </summary>
    public class HandleConfirm
    {
        /// <summary>
        /// 
        /// </summary>
        public void Excute(PhoneMessage phoneMessage)
        {
            BasicConfirm handleConfirm;
            switch (phoneMessage.PhoneMessageType.PhoneMessageEnumType)
            {

                case PhoneMessageEnumType.LeaveRequest:
                    {
                        handleConfirm = new LeaveRequestConfirm(phoneMessage);
                        handleConfirm.Excute();
                        break;
                    }

                case PhoneMessageEnumType.OutApplication:
                    {
                        handleConfirm = new OutApplicationConfirm(phoneMessage);
                        handleConfirm.Excute();
                        break;
                    }

                case PhoneMessageEnumType.OverWork:
                    {
                        handleConfirm = new OverWorkConfirm(phoneMessage);
                        handleConfirm.Excute();
                        break;

                    }
            }
        }
    }
}