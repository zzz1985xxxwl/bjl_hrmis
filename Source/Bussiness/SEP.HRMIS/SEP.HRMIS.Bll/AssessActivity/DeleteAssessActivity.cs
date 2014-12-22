//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteAssessActivity.cs
// ������: ����
// ��������: 2009-09-03
// ����: ɾ�����˻
// ----------------------------------------------------------------

using SEP.HRMIS.IDal;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.AssessActivity
{
    ///<summary>
    /// ɾ�������
    ///</summary>
    public class DeleteAssessActivity: Transaction
    {
        /// <summary>
        /// �����๤��
        /// </summary>
        private static IAssessActivity _Dal = new AssessActivityDal();

        private readonly int _AssessActivityID;
        private Model.AssessActivity _AssessActivity;

        /// <summary>
        /// InterruptActivity�Ĺ��캯��
        /// </summary>
        public DeleteAssessActivity(int assessActivityID)
        {
            _AssessActivityID = assessActivityID;
        }
        /// <summary>
        /// SystemAssess�Ĺ��캯����רΪ�����ṩ
        /// </summary>
        public DeleteAssessActivity(int assessActivityID, IAssessActivity mockDal)
        {
            _AssessActivityID = assessActivityID;
            _Dal = mockDal;
        }
        protected override void ExcuteSelf()
        {
            _Dal.DeleteAssessActivity(_AssessActivityID);
        }
        protected override void Validation()
        {
            _AssessActivity = _Dal.GetAssessActivityById(_AssessActivityID);
            if (_AssessActivity == null)
            {
                BllUtility.ThrowException(BllExceptionConst._InvalidActivityId);
            }
        }
    }
}
