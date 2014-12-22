//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateFBQuesType.cs
// ������: ����
// ��������: 2008-11-06
// ����: �޸ķ�����������
// ----------------------------------------------------------------
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    public class UpdateFBQuesType:Transaction
    {
        private static IParameter _DalFBQuesType = new ParameterDal();
        private readonly TrainFBQuesType _TrainFBQuesType;

        public UpdateFBQuesType(TrainFBQuesType fbQuesType)
        {
            _TrainFBQuesType = fbQuesType;

        }

        public UpdateFBQuesType(TrainFBQuesType fbQuesType,IParameter dalfbQuesType)
        {
            _TrainFBQuesType = fbQuesType;
            _DalFBQuesType = dalfbQuesType;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _DalFBQuesType.UpdateFBQuesType(_TrainFBQuesType);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        /// <summary>
        /// �޸���ѵ�����������͵���Ч���ж�
        /// </summary>
        protected override void Validation()
        {
            if(_DalFBQuesType.CountFBQuesTypeByNameDiffPKID(_TrainFBQuesType.ParameterID,_TrainFBQuesType.Name)>0)
            {
                BllUtility.ThrowException(BllExceptionConst._FBQuesType_Repeat);
            }
        }
    }
}
