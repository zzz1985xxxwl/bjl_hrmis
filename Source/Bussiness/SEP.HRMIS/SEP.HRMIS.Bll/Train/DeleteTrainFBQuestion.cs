//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteTrainFBQuestion.cs
// ������: ����
// ��������: 2008-11-06
// ����: ɾ����ѵ��������
// ----------------------------------------------------------------
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    public class DeleteTrainFBQuestion : Transaction
    {
        private static IFBQuestion _DalFBQuestion = DalFactory.DataAccess.CreateFBQues();
        private readonly TrainFBQuestion _TrainFBQuesiton;


        public DeleteTrainFBQuestion(TrainFBQuestion fbquestion)
        {
            _TrainFBQuesiton = fbquestion;
        }

        public DeleteTrainFBQuestion(TrainFBQuestion fbquestion, IFBQuestion dalFBQuestion)
        {
            _TrainFBQuesiton = fbquestion;
            _DalFBQuestion = dalFBQuestion;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    //foreach (TrainFBItem items in _TrainFBQuesiton.FBItems)
                    //{
                    //    _TrainFBQuesiton.FBItems.Remove(items);
                    //}

                    _DalFBQuestion.DeleteFBQuestion(_TrainFBQuesiton.FBQuestioniD);
                    ts.Complete();
                }
            }

            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }



        protected override void Validation()
        {

        }
    }
}
    

