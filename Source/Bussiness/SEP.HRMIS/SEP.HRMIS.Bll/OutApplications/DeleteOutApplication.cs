//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: DeleteOutApplication.cs
// Creater:  Xue.wenlong
// Date:  2009-04-13
// Resume:
// ---------------------------------------------------------------

using System.Transactions;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.OutApplications
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteOutApplication : Transaction
    {
        private static readonly IOutApplication _OutApplicationDal = DalFactory.DataAccess.CreateOutApplication();
        private readonly int _ApplicationID;

        /// <summary>
        /// 
        /// </summary>
        public DeleteOutApplication(int applicationID)
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
                    _OutApplicationDal.DeleteOutApplicationByPKID(_ApplicationID);
                    _OutApplicationDal.DeleteOutApplicationItemByOutApplicationID(_ApplicationID);
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