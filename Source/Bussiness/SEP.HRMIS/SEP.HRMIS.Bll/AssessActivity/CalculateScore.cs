//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: CalculateScore.cs
// ������: �ߺ�
// ��������: 2008-05-23
// ����: ���㿼���ķ�ֵ
//  �����ֵΪ����100���ƣ�����С��ֵ��
//  ����ÿһ����������1~5�ֵĵȼ���Ա����д��ռ30%������ռ70%
//  ��ֵ�� = (����������÷�+����Ա����÷�*0.3+����������÷�*0.7)/(�ܹ�����*5)
//  �ܷ� = ��ֵ��*100
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class CalculateScore:ICalculateScore
    {
        protected static IAssessActivity _IAssessActivity = DalFactory.DataAccess.AssessActivityDal;
        #region ICalculateScore ��Ա
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assessActivity"></param>
        /// <returns></returns>
        public decimal CalculateScores(Model.AssessActivity assessActivity)
        {
            return NewCalculateScores(assessActivity);
            //double count = 0;
            //double totalScore = 0;
            //foreach (AssessActivityItem item in assessActivity.ItsAssessActivityPaper.ItsAssessActivityItems)
            //{
            //    if(item.AssessTemplateItemType==AssessTemplateItemType.Option)
            //    {
            //        if (item is HRItem)
            //        {
            //            count++;
            //            totalScore += item.Grade;
            //        }
            //        else if (item is PersonalItem)
            //        {
            //            count += 0.5;
            //            totalScore += (item.Grade * 0.3);
            //        }
            //        else if (item is ManagerItem)
            //        {
            //            count += 0.5;
            //            totalScore += (item.Grade * 0.7);
            //        }
            //    }
            //}
            //if(count.Equals(0))
            //{
            //    return 0;
            //}
            //else
            //{
            //    double score = totalScore / (count * 5);
            //    return Convert.ToDecimal(Math.Round(score * 100));    
            //}
        }

        private static decimal NewCalculateScores(Model.AssessActivity assessActivity)
        {
            Model.AssessActivity assess = _IAssessActivity.GetAssessActivityById(assessActivity.AssessActivityID);
            double totalScore = 0;
            foreach (SubmitInfo submitInfo in assess.ItsAssessActivityPaper.SubmitInfoes)
            {
                foreach (AssessActivityItem item in submitInfo.ItsAssessActivityItems)
                {
                    if (item.AssessActivityItemType == AssessActivityItemType.HrItem)
                    {
                        totalScore += ((double)item.Grade * (double)item.Weight);
                    }
                    //else if (item.AssessActivityItemType == AssessActivityItemType.PersonalItem)
                    //{
                    //    totalScore += ((double)item.Grade * (double)item.Weight * 0.3);
                    //}
                    else if (item.AssessActivityItemType == AssessActivityItemType.ManagerItem)
                    {
                        totalScore += ((double)item.Grade * (double)item.Weight);
                    }
                }
               
            }
            decimal totle = Convert.ToDecimal(Math.Round(totalScore, 2));
            assess.ItsAssessActivityPaper.Score = totle;
            _IAssessActivity.UpdateAssessActivity(assess);
            return totle;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public IAssessActivity MockAssessActivity
        {
            set { _IAssessActivity = value; }
        }
    }
}
