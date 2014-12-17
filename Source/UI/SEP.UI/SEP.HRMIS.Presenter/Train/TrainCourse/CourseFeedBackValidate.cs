//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CourseFeedBackValidate.cs
// 创建者: 张燕
// 创建日期: 2008-11-20
// 概述:查询培训课程反馈界面的信息验证
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class CourseFeedBackValidate
    {
        private readonly IFeedBackBackSearchView _ItsView;

        public CourseFeedBackValidate(IFeedBackBackSearchView itsView)
        {
            _ItsView = itsView;
        }


        public bool Validate()
        {
            return VaildateFBST() && VaildateFBET();

        }

        public DateTime? _OutStartFrom;
        public bool VaildateFBST()
        {
            DateTime temp;
            if (string.IsNullOrEmpty(_ItsView.FBTimeFrom))
            {
                _OutStartFrom = null;
                return true;
            }
            if (!DateTime.TryParse(_ItsView.FBTimeFrom, out temp))
            {
                _ItsView.ResultMessage = "时间格式输入不正确";
                return false;
            }
            else
            {
                _OutStartFrom = temp;
                return true;
            }
        }
        public DateTime? _OutStartTo;
        public bool VaildateFBET()
        {
            DateTime temp;
            if (string.IsNullOrEmpty(_ItsView.FBTimeTo))
            {
                _OutStartTo = null;
                return true;
            }
            if (!DateTime.TryParse(_ItsView.FBTimeTo, out temp))
            {
                _ItsView.ResultMessage = "时间格式输入不正确";
                return false;
            }
            else
            {
                _OutStartTo = temp;
                return true;
            }
        }
    }
}
