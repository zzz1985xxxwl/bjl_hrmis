using System.Collections.Generic;
using System.Transactions;

using SEP.HRMIS.IDal;
using SEP.HRMIS.SqlServerDal;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.HRMIS.Model.AccountAuth;

namespace SEP.HRMIS.Bll.AccountAuth
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAuth
    {
        private readonly IAuthDal _IAuthDal = new AuthDal();

        /// <summary>
        /// 为账号赋予权限，先取消所有权限，然后新增
        /// </summary>
        /// <param name="newAuths"></param>
        /// <param name="user"></param>
        /// <param name="loginUser"></param>
        public void SetAccountAuths(List<Auth> newAuths, Account user, Account loginUser)
        {
            if (!Powers.HasAuth(loginUser.Auths, AuthType.HRMIS, HrmisPowers.A201))
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                _IAuthDal.CancelAccountAllAuth(user.Id);
                SetAuth(newAuths, user.Id);
                ts.Complete();
            }
        }

        private void SetAuth(List<Auth> auths, int accountId)
        {
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

        /// <summary>
        /// 获取用户权限，是树形结构
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public List<Auth> GetAccountAllAuth(int accountId, Account loginUser)
        {
            return _IAuthDal.GetAccountAuth(accountId);
        }

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public List<Auth> GetAccountAllAuthList(int accountId, Account loginUser)
        {
            List<Auth> iRet = _IAuthDal.GetAccountAuthList(accountId);
            foreach (Auth auth in iRet)
            {
                if(auth.IfHasDepartment)
                {
                    auth.Departments = _IAuthDal.GetDepartmentByBackAccontsID(accountId, auth.Id);
                }
            }
            return iRet;
        }
    }
}
