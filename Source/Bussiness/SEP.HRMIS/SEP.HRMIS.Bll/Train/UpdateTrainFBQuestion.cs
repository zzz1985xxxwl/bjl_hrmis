//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateTrainFBQuestion.cs
// ������: ����
// ��������: 2008-11-06
// ����: �޸���ѵ��������
// ----------------------------------------------------------------

using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
   public class UpdateTrainFBQuestion:Transaction
    {
       private static IFBQuestion _DalFBQuestion = new FBQuestionDal();
       private readonly TrainFBQuestion _TrainFBQuesiton;




       public UpdateTrainFBQuestion(TrainFBQuestion fbquestion)
       {
           _TrainFBQuesiton = fbquestion;
          
       }


       public UpdateTrainFBQuestion(TrainFBQuestion fbquestion, IFBQuestion dalFBQuestion)
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
                    _DalFBQuestion.UpdateFBQuestion(_TrainFBQuesiton);
                    ts.Complete();
                }
            }

            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }


        /// <summary>
        /// ������ѵ����������Ч���ж�
        /// </summary>
       protected override void Validation()
        {
            if (_DalFBQuestion.CountFBQuestionByNameDiffPKID(_TrainFBQuesiton.FBQuestioniD, _TrainFBQuesiton.Description)>0)
            {
                BllUtility.ThrowException(BllExceptionConst._TrainFBQuesiton_Repeate);
            }


            //foreach (TrainFBItem item in _TrainFBItems)
            //{
            //    if (!_TrainFBQuesiton.FindNotExistItems(item.Description))
            //    {
            //        BllUtility.ThrowException(BllExceptionConst._TrainFBItem_Repeate);
            //    }
            //}
            
        }
    }
    
}
