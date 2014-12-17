//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: FBQuesTypeListPresenter.cs
// ������: ����
// ��������: 2008-11-12
// ����: ��̨�����������ʹ����
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IFBQuesType;

namespace SEP.HRMIS.Presenter.Parameter.FBQuesType
{
    public class FBQuesTypeListPresenter
    {
        private readonly IFBQuesTypeListView _ItsView;
        //private IGetTrainQuesType _GetTrainQuesType = new GetTrainFBQuesType();
        private ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        private List<TrainFBQuesType> itsSource;

        public FBQuesTypeListPresenter(IFBQuesTypeListView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }
        public void InitView(bool IsPostBack)
        {
            if (!IsPostBack)
            {
                FBQuesTypeDataBind();
            }
        }

        public void AttachViewEvent()
        {
            _ItsView.BtnSearchEvent += FBQuesTypeDataBind;
        }

        public void FBQuesTypeDataBind()
        {
            itsSource = new List<TrainFBQuesType>();
            itsSource = _ITrainFacade.GetTrainFBQuesTypeByCondition(-1, _ItsView.FBQuesTypeName);
            _ItsView.FBQuesTypes = itsSource;
        }

        #region use for tests

        //public IGetTrainQuesType setType
        //{
        //    set { _GetTrainQuesType = value; }
        //}

        #endregion
    }
}
