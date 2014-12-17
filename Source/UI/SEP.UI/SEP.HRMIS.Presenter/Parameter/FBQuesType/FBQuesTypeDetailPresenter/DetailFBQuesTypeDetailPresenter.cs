//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: DetailPositionDetailPresenter.cs
// 创建者: 张燕
// 创建日期: 2008-11-12
// 概述: 查看后台反馈问题类型详情小界面的Presenter
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IFBQuesType;

namespace SEP.HRMIS.Presenter.Parameter.FBQuesType.FBQuesTypeDetailPresenter
{
    public class DetailFBQuesTypeDetailPresenter
    {
        private readonly IFBQuesTypeView _ItsView;
        private TrainFBQuesType _TrainFBQuesType;
        //private readonly IGetTrainQuesType _GetTrainQuesType = new GetTrainFBQuesType();
        private ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        public DetailFBQuesTypeDetailPresenter(IFBQuesTypeView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void InitView(bool IsPostBack, string id)
        {
            _ItsView.ResultMessage = string.Empty;
            _TrainFBQuesType = _ITrainFacade.GetTrainFBQuesTypeByPKID(Convert.ToInt32(id));
            if (!IsPostBack)
            {
                _ItsView.Title = "反馈问题类型详情";
                _ItsView.OperationType = "Detail";
                _ItsView.FBQuesTypeID = _TrainFBQuesType.ParameterID.ToString();
                _ItsView.FBQuesTypeName = _TrainFBQuesType.Name;
                _ItsView.SetIDReadonly = true;
                _ItsView.SetNameReadonly = true;

            }
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += DetailEvent;
        }

        public void DetailEvent()
        {
            _ItsView.ActionSuccess = true;
        }
    }
}
