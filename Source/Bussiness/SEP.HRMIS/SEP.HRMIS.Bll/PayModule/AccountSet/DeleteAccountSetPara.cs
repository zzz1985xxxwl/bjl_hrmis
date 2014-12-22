//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteAccountSetPara.cs
// ������: wang.shali
// ��������: 2008-12
// ����: ɾ�����ײ���
// ----------------------------------------------------------------


using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.SqlServerDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.AccountSet
{
    public class DeleteAccountSetPara: Transaction
    {
        private static IAccountSet _DalAccountSet = new AccountSetDal();
        private int _AccountSetParaID;
        public DeleteAccountSetPara(int accountSetParaID)
        {
            _AccountSetParaID = accountSetParaID;
        }
        public DeleteAccountSetPara(int accountSetParaID,IAccountSet iMockAccountSet)
        {
            _AccountSetParaID = accountSetParaID;
            _DalAccountSet = iMockAccountSet;
        }

        protected override void Validation()
        {
            if (_DalAccountSet.GetAccountSetParaByPKID(_AccountSetParaID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._AccountSetPara_IsNotExist);
            }
            if (_DalAccountSet.CountAccountSetItemByAccountSetParaID(_AccountSetParaID) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._AccountSetParaName_HasUsed);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _DalAccountSet.DeleteAccountSetParaByPKID(_AccountSetParaID);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

    }
}