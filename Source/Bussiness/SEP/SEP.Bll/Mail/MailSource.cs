//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: MailSource.cs
// Creater:  Xue.wenlong
// Date:  2009-03-26
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using SEP.IBll.Mail;
using SEP.IDal;
using SEP.IDal.Accounts;
using SEP.IDal.Departments;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.Bll.Mail
{
    public class MailSource : IMailSource
    {
        private readonly IAccountDal _IAccountDal = DalInstance.AccountDalInstance;
        private readonly IDepartmentDal _IDepartmentDal = DalInstance.DeptDalInstance;

        public string GetHrLeaderMail()
        {
            return GetDepartmentLeaderByDepartmentID((int)DepartmentEnum.HRDepartment).Email1;
        }

        public List<string> GetHrManagerMails()
        {
            List<string> mailCc = new List<string>();

            foreach (Account e in _IAccountDal.GetAccountByCondition("", null, (int)PositionEnum.HRManager, null, true))
            {
                string mailAddress = e.Email1;
                mailCc.Add(mailAddress);
                if (!string.IsNullOrEmpty(e.Email2))
                {
                    mailCc.Add(e.Email2);
                }
            }

            return mailCc;
        }

        public List<string> GetHrAssistantMails()
        {
            List<string> mailCc = new List<string>();

            foreach (Account e in _IAccountDal.GetAccountByCondition("", null, (int)PositionEnum.HRAssistant,null, true))
            {
                string mailAddress = e.Email1;
                mailCc.Add(mailAddress);
                if (!string.IsNullOrEmpty(e.Email2))
                {
                    mailCc.Add(e.Email2);
                }
            }

            return mailCc;
        }

        public List<string> GetHrCommissionerMails()
        {
            List<string> mailCc = new List<string>();

            foreach (Account e in _IAccountDal.GetAccountByCondition("", null, (int)PositionEnum.HRCommissioner,null, true))
            {
                string mailAddress = e.Email1;
                mailCc.Add(mailAddress);
                if (!string.IsNullOrEmpty(e.Email2))
                {
                    mailCc.Add(e.Email2);
                }
            }

            return mailCc;
        }

        public string GetCeoMail()
        {
            return GetDepartmentLeaderByDepartmentID((int)DepartmentEnum.Root).Email1;
        }

        //public MailAddress GetDirectMail(int empId)
        //{
        //    Employee direct = _IGetDirectorByEmployeeId.GetDirectorByEmployeeID(empId);
        //    return new MailAddress(direct.Email);
        //}

        public string GetManagerMail(int empId)
        {
            return GetDepartmentLeaderByEmployeeId(empId).Email1;
        }

        public string GetEmployeeMailByName(string empName)
        {
            return _IAccountDal.GetAccountByName(empName).Email1;
        }

        public string GetHrLeaderMail2()
        {
            return GetDepartmentLeaderByDepartmentID((int)DepartmentEnum.HRDepartment).Email2;
        }

        public string GetCeoMail2()
        {
            return GetDepartmentLeaderByDepartmentID((int)DepartmentEnum.Root).Email2;
        }

        //public MailAddress GetDirectMail2(int empId)
        //{
        //    Employee direct = _IGetDirectorByEmployeeId.GetDirectorByEmployeeID(empId);
        //    string directMail2 = direct.Email2;
        //    if (string.IsNullOrEmpty(directMail2))
        //    {
        //        return new MailAddress(BllUtility._EmptyMailAddress);
        //    }
        //    return new MailAddress(directMail2);
        //}

        public string GetManagerMail2(int empId)
        {
            return GetDepartmentLeaderByEmployeeId(empId).Email2;
        }

        public string GetEmployeeMailByName2(string empName)
        {
            Account employee = _IAccountDal.GetAccountByName(empName);
            return employee.Email2;
        }

        private Account GetDepartmentLeaderByEmployeeId(int accoutID)
        {
            Account account = _IAccountDal.GetAccountById(accoutID);
            return _IAccountDal.GetAccountById(account.Dept.Leader.Id);
        }

        private Account GetDepartmentLeaderByDepartmentID(int id)
        {
            return _IAccountDal.GetAccountById(_IDepartmentDal.GetDepartmentById(id).Leader.Id);
        }
    }
}