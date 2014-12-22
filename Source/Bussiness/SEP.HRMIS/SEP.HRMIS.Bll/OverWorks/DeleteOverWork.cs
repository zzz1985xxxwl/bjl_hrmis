//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: DeleteOverWork.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using System.Transactions;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.OverWorks
{
    /// <summary>
    /// </summary>
    public class DeleteOverWork:Transaction
    {
        private static readonly IOverWork _OverWorkDal = new OverWorkDal();
        private readonly int _ApplicationID;

        /// <summary>
        /// 
        /// </summary>
        public DeleteOverWork(int applicationID)
        {
            _ApplicationID = applicationID;
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _OverWorkDal.DeleteOverWorkByPKID(_ApplicationID);
                    _OverWorkDal.DeleteOverWorkItemByOverWorkID(_ApplicationID);
                    ts.Complete();
                }
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
        }
    }
}