//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteFBQuesTypeDetailPresenter.cs
// ������: ����
// ��������: 2008-11-12
// ����: ɾ����̨������������С�����Presenter
// ----------------------------------------------------------------;

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IFBQuesType;

namespace SEP.HRMIS.Presenter.Parameter.FBQuesType.FBQuesTypeDetailPresenter
{
    public class DeleteFBQuesTypeDetailPresenter
    {
        private readonly IFBQuesTypeView _ItsView;
        //private DeleteFBQuesType _DeleteFBQuesType;
        private ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        private TrainFBQuesType _TrainFBQuesType;
        //private readonly IGetTrainQuesType _GetTrainQuesType = new GetTrainFBQuesType();

        public DeleteFBQuesTypeDetailPresenter(IFBQuesTypeView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }
        public void InitView(bool IspostBack, string id)
        {
            _ItsView.ResultMessage = string.Empty;
            _TrainFBQuesType = _ITrainFacade.GetTrainFBQuesTypeByPKID(Convert.ToInt32(id));
            if (!IspostBack)
            {
                _ItsView.Title = "ɾ��������������";
                _ItsView.OperationType = "Delete";
                _ItsView.FBQuesTypeID = _TrainFBQuesType.ParameterID.ToString();
                _ItsView.FBQuesTypeName = _TrainFBQuesType.Name;
                _ItsView.SetIDReadonly = true;
                _ItsView.SetNameReadonly = true;
            }
        }

        private void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += DeleteEvent;
        }

        //private int _ID;
        private void DeleteEvent()
        {
            _TrainFBQuesType = _ITrainFacade.GetTrainFBQuesTypeByPKID(Convert.ToInt32(_ItsView.FBQuesTypeID));


            try
            {
                _ITrainFacade.DeleteFBQuesType(_TrainFBQuesType);
                _ItsView.ActionSuccess = true;

            }
            catch (Exception ex)
            {
                _ItsView.ResultMessage = ex.Message;
            }
        }
    }
}
