//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddFBQuesType.cs
// ������: ����
// ��������: 2008-11-06
// ����: ����������������
// ----------------------------------------------------------------

using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    public class AddFBQuesType : Transaction
    {
        private static IParameter _DalFBQuesType = DalFactory.DataAccess.CreateParameter();
        private readonly TrainFBQuesType _TrainFBQuesType;

        public AddFBQuesType(TrainFBQuesType trainfbquestype)
        {
            _TrainFBQuesType = trainfbquestype;
        }

        public AddFBQuesType(TrainFBQuesType trainfbquestype,IParameter dalfbquestype)
        {
            _TrainFBQuesType = trainfbquestype;
            _DalFBQuesType = dalfbquestype;
        }

        protected override void ExcuteSelf()
        {
            
            try
            {
                _DalFBQuesType.InsertFBQuesType(_TrainFBQuesType);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        /// <summary>
        /// ������������������Ч���ж�
        /// </summary>
        protected override void Validation()
        {
            if(_DalFBQuesType.CountFBQuesTypeByName(_TrainFBQuesType.Name)>0)
            {
                BllUtility.ThrowException(BllExceptionConst._FBQuesType_Repeat);
            }
        }
    }
}
