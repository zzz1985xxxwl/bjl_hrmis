//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: PositionPresenter.cs
// 创建者: 张燕
// 创建日期: 2008-11-12
// 概述: 后台问题反馈类型总界面
// ----------------------------------------------------------------

using SEP.HRMIS.Presenter.IPresenter.IParamter.IFBQuesType;
using SEP.HRMIS.Presenter.Parameter.FBQuesType.FBQuesTypeDetailPresenter;

namespace SEP.HRMIS.Presenter.Parameter.FBQuesType
{
    public class FBQuesTypepresenter
    {
        private readonly IFBQuesTypeInfoView _ItsView;
        private readonly FBQuesTypeListPresenter _BasePresenter;

        public FBQuesTypepresenter(IFBQuesTypeInfoView itsView)
        {
            _ItsView = itsView;
            _BasePresenter = new FBQuesTypeListPresenter(_ItsView.FBQuesTypeListView);
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        private void SwitchLittleViewPresenter()
        {
            switch (_ItsView.FBQuesTypeView.OperationType)
            {
                case "Add":
                    new AddFBQuesTypeDetailPresenter(_ItsView.FBQuesTypeView);
                    break;
                case "Update":
                    new UpdateFBQuesTypeDetailPresenter(_ItsView.FBQuesTypeView);
                    break;
                case "Delete":
                    new DeleteFBQuesTypeDetailPresenter(_ItsView.FBQuesTypeView);
                    break;
                case "Detail":
                    new DetailFBQuesTypeDetailPresenter(_ItsView.FBQuesTypeView);
                    break;

            }
        }

        public void AttachViewEvent()
        {
            //大界面
            _ItsView.FBQuesTypeListView.BtnAddEvent += ShowAddView;
            _ItsView.FBQuesTypeListView.BtnUpdateEvent += ShowUpdateView;
            _ItsView.FBQuesTypeListView.BtnDeleteEvent += ShowDeleteView;
            _ItsView.FBQuesTypeListView.BtnDetailEvent += ShowDetailView;

            //小界面
            _ItsView.FBQuesTypeView.ActionButtonEvent += ActionEvent;
            _ItsView.FBQuesTypeView.CancelButtonEvent += CancelEvent;
        }

        private void ShowAddView()
        {
            new AddFBQuesTypeDetailPresenter(_ItsView.FBQuesTypeView).InitView(false);
            _ItsView.FBQuesTypeViewVisible = true;
        }

        private void ShowUpdateView(string id)
        {
            new UpdateFBQuesTypeDetailPresenter(_ItsView.FBQuesTypeView).InitView(false, id);
            _ItsView.FBQuesTypeViewVisible = true;
        }

        private void ShowDeleteView(string id)
        {
            new DeleteFBQuesTypeDetailPresenter(_ItsView.FBQuesTypeView).InitView(false, id);
            _ItsView.FBQuesTypeViewVisible = true;
        }
        private void ShowDetailView(string id)
        {
            new DetailFBQuesTypeDetailPresenter(_ItsView.FBQuesTypeView).InitView(false, id);
            _ItsView.FBQuesTypeViewVisible = true;
        }

        private void ActionEvent()
        {
            if (_ItsView.FBQuesTypeView.ActionSuccess)
            {
                _BasePresenter.FBQuesTypeDataBind();
                _ItsView.FBQuesTypeViewVisible = false;
            }
            else
            {
                _ItsView.FBQuesTypeViewVisible = true;
            }
        }

        private void CancelEvent()
        {
            _ItsView.FBQuesTypeViewVisible = false;
        }

        public void InitView(bool IsPostBack)
        {
            _BasePresenter.InitView(IsPostBack);
        }
    }
}
