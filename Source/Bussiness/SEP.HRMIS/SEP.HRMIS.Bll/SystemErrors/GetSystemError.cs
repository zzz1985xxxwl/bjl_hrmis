//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: GetSystemError.cs
// Creater:  Xue.wenlong
// Date:  2009-10-09
// Resume:
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.SystemError;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.HRMIS.Bll.SystemErrors
{
    /// <summary>
    /// </summary>
    public class GetSystemError
    {
        private readonly ISystemError _ISystemError = DalFactory.DataAccess.CreateSystemError();
        private readonly GetEmployee _GetEmployee = new GetEmployee();
        private readonly Account _LoginUser;

        ///<summary>
        ///</summary>
        public GetSystemError(Account loginUser)
        {
            _LoginUser = loginUser;
        }

        /// <summary>
        /// for test
        /// </summary>
        public GetSystemError(Account loginUser, ISystemError iSystemError, GetEmployee iAccountBll)
            : this(loginUser)
        {
            _ISystemError = iSystemError;
            _GetEmployee = iAccountBll;
        }

        /// <summary>
        /// 得到自定义流程错误
        /// </summary>
        public List<SystemError> GetDiyProcessError(bool showIgnore, ErrorType type)
        {
            List<ErrorType> errorTypeList = new List<ErrorType>();
            if (type == ErrorType.All)
            {
                errorTypeList.AddRange(ErrorType.GetDiyErrorType);
            }
            else
            {
                errorTypeList.Add(type);
            }
            return GetError(showIgnore, errorTypeList, HrmisPowers.A401);
        }

        ///<summary>
        ///得到没有门禁卡的用户 
        ///</summary>
        ///<param name="showIgnore"></param>
        ///<returns></returns>
        public List<SystemError> GetDoorCardError(bool showIgnore)
        {
            List<ErrorType> errorTypeList = new List<ErrorType>();
            errorTypeList.Add(ErrorType.DoorCardNoError);
            return GetError(showIgnore, errorTypeList, HrmisPowers.A401);
        }

        ///<summary>
        /// 得到没有排班的用户
        ///</summary>
        ///<param name="showIgnore"></param>
        ///<returns></returns>
        public List<SystemError> GetDutyCalssErrorError(bool showIgnore)
        {
            List<ErrorType> errorTypeList = new List<ErrorType>();
            errorTypeList.Add(ErrorType.DutyCalssError);
            return GetError(showIgnore, errorTypeList, HrmisPowers.A502);
        }

        private List<SystemError> GetError(bool showIgnore, IEnumerable<ErrorType> errorTypeList, int power)
        {
            List<SystemError> errors = _ISystemError.GetAcBaseSystemError();
            List<SystemError> ignoreErrors = _ISystemError.GetAllIgnoreSystemError();
            List<SystemError> reterrors = new List<SystemError>();
            foreach (SystemError error in errors)
            {
                if (TypeRight(errorTypeList, error.ErrorType))
                {
                    error.ErrorStatus = ErrorStatus.ToHandle;
                    if (ContinusIgnore(ignoreErrors, error.ErrorType.ID, error.MarkID))
                    {
                        error.ErrorStatus = ErrorStatus.Ignore;
                    }

                    if (!showIgnore)
                    {
                        if (error.ErrorStatus != ErrorStatus.Ignore)
                        {
                            reterrors.Add(error);
                        }
                    }
                    else
                    {
                        reterrors.Add(error);
                    }
                }
            }
            return RemoteUnAuthSystemErrorAndInitName(reterrors, AuthType.HRMIS, _LoginUser, power);
        }

        private static bool ContinusIgnore(IEnumerable<SystemError> systemerror, int typeid, int markid)
        {
            if (systemerror != null)
            {
                foreach (SystemError error in systemerror)
                {
                    if (error.ErrorType.ID == typeid && error.MarkID == markid)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        private List<SystemError> RemoteUnAuthSystemErrorAndInitName(IEnumerable<SystemError> oldSystemErrorList,
                                                                     AuthType authType, Account loginUser,
                                                                     int powersID)
        {
            Auth myAuth = loginUser.FindAuth(authType, powersID);

            if (myAuth == null)
            {
                return new List<SystemError>();
            }
            List<SystemError> newSystemErrorList = new List<SystemError>();
            foreach (SystemError error in oldSystemErrorList)
            {
                Employee employee = _GetEmployee.GetEmployeeByAccountID(error.MarkID);
                error.ErrorEmployee = employee;
                error.Description =
                    string.Format("{0}{1}", employee.Account.Name, error.Description);
                if (myAuth.Departments.Count == 0)
                {
                    newSystemErrorList.Add(error);
                }
                else if (Tools.IsDeptListContainsDept(myAuth.Departments, employee.Account.Dept))
                {
                    newSystemErrorList.Add(error);
                }
            }
            return newSystemErrorList;
        }

        private static bool TypeRight(IEnumerable<ErrorType> errorTypeList, ErrorType errorType)
        {
            foreach (ErrorType type in errorTypeList)
            {
                if (type.ID == errorType.ID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}