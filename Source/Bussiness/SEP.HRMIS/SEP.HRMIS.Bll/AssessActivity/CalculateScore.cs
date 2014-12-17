//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: CalculateScore.cs
// 创建者: 倪豪
// 创建日期: 2008-05-23
// 概述: 计算考评的分值
//  计算分值为满分100分制，舍弃小数值，
//  对于每一项，假设可以有1~5分的等级，员工填写的占30%，主管占70%
//  分值比 = (所有人事项得分+所有员工项得分*0.3+所有主管项得分*0.7)/(总共项数*5)
//  总分 = 分值比*100
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
        #region ICalculateScore 成员
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
