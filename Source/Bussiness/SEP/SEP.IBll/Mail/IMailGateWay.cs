//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IMailGateWay.cs
// Creater:  Xue.wenlong
// Date:  2009-03-23
// Resume:
// ---------------------------------------------------------------

using Mail.Model;

namespace SEP.IBll.Mail
{
    public interface IMailGateWay
    {
        void Send(MailBody mailBody);
        void Send(MailBody mailBody, bool addLoginAddress);
    }
}