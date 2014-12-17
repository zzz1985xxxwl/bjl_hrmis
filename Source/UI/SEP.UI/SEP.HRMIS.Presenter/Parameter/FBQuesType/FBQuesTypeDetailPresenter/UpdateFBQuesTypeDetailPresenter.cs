//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateFBQuesTypeDetailPresenter.cs
// ������: ����
// ��������: 2008-11-12
// ����: �޸ĺ�̨������������С�����Presenter
// ----------------------------------------------------------------;
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IFBQuesType;

namespace SEP.HRMIS.Presenter.Parameter.FBQuesType.FBQuesTypeDetailPresenter
{
    public class UpdateFBQuesTypeDetailPresenter
    {
        private readonly IFBQuesTypeView _ItsView;
        //private UpdateFBQuesType _UpdateFBQuesType;
        private ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        private TrainFBQuesType _TrainFBQuesType;
        //private readonly IGetTrainQuesType _IGetTrainQuesType = new GetTrainFBQuesType();

        public UpdateFBQuesTypeDetailPresenter(IFBQuesTypeView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void InitView(bool isPostBack, string id)
        {
            _ItsView.ResultMessage = string.Empty;
            _TrainFBQuesType = _ITrainFacade.GetTrainFBQuesTypeByPKID(Convert.ToInt32(id));
            if (!isPostBack)
            {
                _ItsView.Title = "�޸ķ�����������";
                _ItsView.OperationType = "Update";
                _ItsView.FBQuesTypeName = _TrainFBQuesType.Name;
                _ItsView.FBQuesTypeID = _TrainFBQuesType.ParameterID.ToString();
                _ItsView.SetIDReadonly = true;
                _ItsView.SetNameReadonly = false;

            }
        }

        private void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += UpdateEvent;
        }

        public void UpdateEvent()
        {
            if (Validate())
            {
                _TrainFBQuesType =
                    _ITrainFacade.GetTrainFBQuesTypeByPKID(Convert.ToInt32(_ItsView.FBQuesTypeID));
                _TrainFBQuesType.Name = _ItsView.FBQuesTypeName;

                try
                {
                    _ITrainFacade.UpdateFBQuesType(_TrainFBQuesType);
                    //_UpdateFBQuesType.Excute();
                    _ItsView.ActionSuccess = true;
                }
                catch (Exception ex)
                {
                    _ItsView.ResultMessage = ex.Message;
                }
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(_ItsView.FBQuesTypeName))
            {
                _ItsView.NameMessage = "����Ϊ��";
                return false;

            }
            else
            {
                _ItsView.NameMessage = string.Empty;
                return true;
            }
        }
    }
}
