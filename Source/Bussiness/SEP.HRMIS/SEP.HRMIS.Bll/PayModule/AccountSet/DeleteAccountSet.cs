//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteAccountSet.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 删除帐套
// ----------------------------------------------------------------
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.AccountSet
{
    public class DeleteAccountSet : Transaction
    {
        private static IAccountSet _DalAccountSet = PayModuleDataAccess.CreateAccountSet();
        private static IEmployeeAccountSet _DalEmployeeAccountSet = PayModuleDataAccess.CreateEmployeeAccountSet();
        private int _AccountSetID;
        public DeleteAccountSet(int accountSetID)
        {
            _AccountSetID = accountSetID;
        }
        public DeleteAccountSet(int accountSetID, IAccountSet iMockAccountSet,IEmployeeAccountSet iMockEmployeeAccountSet)
        {
            _AccountSetID = accountSetID;
            _DalAccountSet = iMockAccountSet;
            _DalEmployeeAccountSet = iMockEmployeeAccountSet;
        }

        protected override void Validation()
        {
            if (_DalAccountSet.GetWholeAccountSetByPKID(_AccountSetID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._AccountSet_IsNotExist);
            }
            if (_DalEmployeeAccountSet.CountEmployeeAccountSetByAccountSetID(_AccountSetID) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._AccountSet_EmployeeAccountSet_HasUsed);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _DalAccountSet.DeleteWholeAccountSetByPKID(_AccountSetID);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}
