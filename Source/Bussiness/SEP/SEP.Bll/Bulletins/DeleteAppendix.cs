//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteAppendix.cs
// ������: colbert
// ��������: 2009-02-02
// ����: ɾ�����渽��
// ----------------------------------------------------------------
using SEP.IDal;
using SEP.Model;

namespace SEP.Bll.Bulletins
{
    internal class DeleteAppendix : Transaction
    {
        private readonly int _AppendixID;

        public DeleteAppendix(int appendixID)
        {
            _AppendixID = appendixID;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.BulletinDalInstance.DeleteAppendixByPKID(_AppendixID);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }
        protected override void Validation()
        {
            //�ø����Ƿ����
            if (DalInstance.BulletinDalInstance.GetAppendixByPKID(_AppendixID) == null)
            {
                throw MessageKeys.AppException(MessageKeys._Appendix_Not_Exist);
            }
        }
    }
}
