//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CouserDataCollecter.cs
// 创建者: ZZ
// 创建日期: 2008-11-13
// 概述:培训课程数据收集
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class CouserDataCollecter
    {
        private readonly ICourseView _ItsView;

        public CouserDataCollecter(ICourseView itsView)
        {
            _ItsView = itsView;
        }

        public void CompleteTheObject(Course theObjectToComplete)
        {
            if (theObjectToComplete != null)
            {
                theObjectToComplete.CourseName = _ItsView.CourseName;
                theObjectToComplete.TrainPlace = _ItsView.Place;
                Account account = new Account();
                account.Name = _ItsView.Coordinator;
                theObjectToComplete.Coordinator = account;
                theObjectToComplete.Trainer = _ItsView.Trainer;

                theObjectToComplete.Scope = (TrainScopeEnum)Convert.ToInt32(_ItsView.TrainScope);
                theObjectToComplete.Status = (TrainStatusEnum)Convert.ToInt32(_ItsView.TrainStatus);
                theObjectToComplete.ExpectST = Convert.ToDateTime(_ItsView.ExpectST);
                theObjectToComplete.ExpectET = Convert.ToDateTime(_ItsView.ExpectET);
                theObjectToComplete.ExpectHour = Convert.ToDecimal(_ItsView.ExpectHour);
                theObjectToComplete.ExpectCost = Convert.ToDecimal(_ItsView.ExpectCost);
                theObjectToComplete.ActualST = Convert.ToDateTime(_ItsView.ActualST);
                theObjectToComplete.ActualET = Convert.ToDateTime(_ItsView.ActualET);

                theObjectToComplete.ActualHour = Convert.ToDecimal(_ItsView.ActualHour);
                theObjectToComplete.ActualCost = Convert.ToDecimal(_ItsView.ActualCost);
                theObjectToComplete.CourseFeedBackPaper=new FeedBackPaper();
                theObjectToComplete.CourseFeedBackPaper.FeedBackPaperId = _ItsView.PaperId;
                if(_ItsView.HasCertifaction)
                {
                    theObjectToComplete.HasCertification = 1;
                }
                else
                {
                    theObjectToComplete.HasCertification = 0;
                }
            }
        }
    }
}
