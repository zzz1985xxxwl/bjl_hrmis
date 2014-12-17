//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ISendMail.cs
// Creater:  Xue.wenlong
// Date:  2009-03-19
// Resume:
// ---------------------------------------------------------------

using Mail.Model;

namespace Mail
{
    public interface ISendMail
    {
        string Send(MailBody mailBody, MailSettings mailSettings);
    }
}