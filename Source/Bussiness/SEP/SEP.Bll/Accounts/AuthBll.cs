//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: AuthBll.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 权限业务实现
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;

using System.Transactions;
using SEP.IBll.Accounts;
using SEP.IDal.Accounts;
using SEP.Model.Accounts;
using SEP.Model;
using SEP.IDal;
using SEP.Model.Departments;

namespace SEP.Bll
{
    internal class AuthBll : IAuthBll
    {
        #region IAuthBll 成员

        public List<Auth> GetAllAuth()
        {
            return DalInstance.AuthDalInstance.GetAllAuthTree();
        }

        public List<Auth> GetAllAuth(Account loginUser)
        {
            if (!Powers.HasAuth(loginUser.Auths, AuthType.SEP, Powers.A103))
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            return GetAllAuth();
        }

        public List<Auth> GetAccountAllAuth(int accountId, Account loginUser)
        {
            if (!Powers.HasAuth(loginUser.Auths, AuthType.SEP, Powers.A103) && accountId != loginUser.Id)
                throw MessageKeys.AppException(MessageKeys._NoAuth);
            return DalInstance.AuthDalInstance.GetAccountAuthTree(accountId);
        }

        public List<Auth> GetAccountAllAuthList(int accountId, Account loginUser)
        {
            if (!Powers.HasAuth(loginUser.Auths, AuthType.SEP, Powers.A103) && accountId != loginUser.Id)
                throw MessageKeys.AppException(MessageKeys._NoAuth);
            IAuthDal _IAuthDal = DalInstance.AuthDalInstance;
            List<Auth> iRet = _IAuthDal.GetAccountAuthList(accountId);
            foreach (Auth auth in iRet)
            {
                if (auth.IfHasDepartment)
                {
                    auth.Departments = _IAuthDal.GetDepartmentByBackAccontsID(accountId, auth.Id);
                }
            }
            return iRet;
        }

        public void SetAccountAuths(List<Auth> newAuths, Account user, Account loginUser)
        {
            if (!Powers.HasAuth(loginUser.Auths, AuthType.SEP, Powers.A103))
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    DalInstance.AuthDalInstance.CancelAccountAllAuth(user.Id);
                    SetAuth(newAuths, user.Id);
                    ts.Complete();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion

        private void SetAuth(List<Auth> auths, int accountId)
        {
            IAuthDal _IAuthDal = DalInstance.AuthDalInstance;
            //foreach (Auth auth in auths)
            //{
            //    if (auth.Type != AuthType.SEP)
            //        continue;

            //    DalInstance.AuthDalInstance.SetAccountAuth(accountId, auth.Id);

            //    if (auth.ChildAuths != null && auth.ChildAuths.Count != 0)
            //        SetAuth(auth.ChildAuths, accountId);
            //}

            foreach (Auth auth in auths)
            {
                if (auth.Departments == null || auth.Departments.Count == 0)
                {
                    _IAuthDal.SetAccountAuth(accountId, auth.Id, 0);
                }
                else
                {
                    foreach (Department department in auth.Departments)
                    {
                        _IAuthDal.SetAccountAuth(accountId, auth.Id, department.DepartmentID);
                    }
                }

                if (auth.ChildAuths != null && auth.ChildAuths.Count != 0)
                    SetAuth(auth.ChildAuths, accountId);
            }

        }
    }
}
