//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: DeletePositionNature.cs
// ������: yyb
// ��������: 2010-8-10
// ����: ɾ����λ����
// ----------------------------------------------------------------

using SEP.IDal;
using SEP.Model;

namespace SEP.Bll.Positions
{
    internal class DeletePositionNature : Transaction
    {
        private readonly int _PositionNatureId;

        public DeletePositionNature(int PositionNatureId)
        {
            _PositionNatureId = PositionNatureId;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.PositionDalInstance.DeletePositionNature(_PositionNatureId);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }

        protected override void Validation()
        {
            if (DalInstance.PositionDalInstance.CountPositionByNatureId(_PositionNatureId) > 0)
            {
                throw MessageKeys.AppException(MessageKeys._PositionNature_HasPosition);
            }
        }
    }
}
