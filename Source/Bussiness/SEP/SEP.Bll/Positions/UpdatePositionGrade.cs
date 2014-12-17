//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdatePositionGrade.cs
// ������: yyb
// ��������: 2009-02-22
// ����: �޸�ְλ�ȼ�
// ----------------------------------------------------------------
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Positions;
namespace SEP.Bll.Positions
{
    internal class UpdatePositionGrade : Transaction
    {
        private Account _LoginUser;
        private readonly PositionGrade _PositionGrade;

        public UpdatePositionGrade(PositionGrade PositionGrade, Account loginUser)
        {
            _PositionGrade = PositionGrade;
            _LoginUser = loginUser;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.PositionDalInstance.UpdatePositionGrade(_PositionGrade);
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
            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A203))
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            PositionGrade grade = DalInstance.PositionDalInstance.GetPositionGradeByName(_PositionGrade.Name);
            if (grade != null && grade.Id != _PositionGrade.Id)
            {
                throw MessageKeys.AppException(MessageKeys._PositionGrade_Name_Repeat);
            }
        }
    }
}
