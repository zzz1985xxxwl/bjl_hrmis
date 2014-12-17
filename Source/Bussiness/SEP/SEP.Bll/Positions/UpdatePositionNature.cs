//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdatePositionNature.cs
// ������: yyb
// ��������: 2010-8-10
// ����: �޸ĸ�λ����
// ----------------------------------------------------------------
using SEP.IDal;
using SEP.Model;
using SEP.Model.Positions;

namespace SEP.Bll.Positions
{
    internal class UpdatePositionNature : Transaction
    {
        private readonly PositionNature _PositionNature;

        public UpdatePositionNature(PositionNature PositionNature)
        {
            _PositionNature = PositionNature;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.PositionDalInstance.UpdatePositionNature(_PositionNature);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }

        /// <summary>
        /// �޸�ְλ�㼶��Ч���жϣ�
        /// 1���޸ĵ�ְλ�㼶�Ѿ�����
        /// 2��ְλ�㼶���������е�����ְλ�㼶����
        /// 3��ְλ�㼶��ʹ����
        /// </summary>
        protected override void Validation()
        {
            if (DalInstance.PositionDalInstance.CountPositionNatureByNameDiffPKID(_PositionNature.Pkid, _PositionNature.Name) > 0)
            {
                throw MessageKeys.AppException(MessageKeys._PositionNature_Name_Repeat);
            }
        }
    }
}