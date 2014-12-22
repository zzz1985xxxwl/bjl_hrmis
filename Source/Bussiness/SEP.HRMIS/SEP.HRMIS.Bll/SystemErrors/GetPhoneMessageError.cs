//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: GetPhoneMessageError.cs
// Creater:  Xue.wenlong
// Date:  2009-11-23
// Resume:
// ----------------------------------------------------------------

using System.Collections.Generic;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.HRMIS.Model.SystemError;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.HRMIS.Bll.SystemErrors
{
    /// <summary>
    /// </summary>
    public class GetPhoneMessageError : Transaction
    {
        private List<SystemError> _SystemErrorList;
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private static readonly IPhoneMessage _PhoneMessageDal = new PhoneMessageDal();
        private readonly GetEmployee _GetEmployee = new GetEmployee();
        private string _Name;
        private PhoneMessageStatus _Status;
        private Account _LoginUser;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        public GetPhoneMessageError(string name, PhoneMessageStatus status, Account loginuser)
        {
            _Name = name;
            _Status = status;
            _LoginUser = loginuser;
            _SystemErrorList = new List<SystemError>();
        }

        /// <summary>
        /// 
        /// </summary>
        public List<SystemError> SystemErrorList
        {
            get { return _SystemErrorList; }
            set { _SystemErrorList = value; }
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            SystemErrorList = GetPhoneMessageByCondition();
        }


        /// <summary>
        /// 
        /// </summary>
        private List<SystemError> GetPhoneMessageByCondition()
        {
            List<PhoneMessage> phonemessage = new List<PhoneMessage>();
            List<SystemError> errors = new List<SystemError>();
            Auth myAuth = _LoginUser.FindAuth(AuthType.HRMIS, HrmisPowers.A401);

            if (myAuth == null)
            {
                return new List<SystemError>();
            }
            if (string.IsNullOrEmpty(_Name))
            {
                phonemessage = _PhoneMessageDal.GetPhoneMessageByCondition(-1, _Status);
            }
            else
            {
                List<Account> accounts = _AccountBll.GetAccountByCondition(_Name, null, null, null);
                foreach (Account account in accounts)
                {
                    phonemessage.AddRange(_PhoneMessageDal.GetPhoneMessageByCondition(account.Id, _Status));
                }
            }
            foreach (PhoneMessage message in phonemessage)
            {
                SystemError error = new SystemError(message.PKID, message.Message, ErrorType.All, -1);
                error.ErrorEmployee = _GetEmployee.GetEmployeeByAccountID(message.Assessor.Id);
                if (myAuth.Departments.Count == 0 || Tools.IsDeptListContainsDept(myAuth.Departments, error.ErrorEmployee.Account.Dept))
                {
                    errors.Add(error);
                }
            }
            return errors;
        }
    }
}