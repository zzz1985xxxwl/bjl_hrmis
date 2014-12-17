//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: SkillPresenter.cs
// 创建者: ZZ
// 创建日期: 2008-11-07
// 概述: 技能总界面的Presenter
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Presenter
{
    public class SkillPresenter
    {
        private readonly ISkillInfoView _ItsView;
        private readonly ListSkillPresenter _SearchPresenter;

        public SkillPresenter(ISkillInfoView itsView)
        {
            _ItsView = itsView;
            _SearchPresenter = new ListSkillPresenter(_ItsView.SkillSearchView);
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        private void SwitchLittleViewPresenter()
        {
            switch (_ItsView.SkillView.OperationType)
            {
                case "Add":
                    new AddSkillPresenter(_ItsView.SkillView);
                    break;
                case "Update":
                    new UpdateSkillPresenter(_ItsView.SkillView);
                    break;
                case "Delete":
                    new DeleteSkillPresenter(_ItsView.SkillSearchView);
                    break;
            }
        }

        public void AttachViewEvent()
        {
            _ItsView.SkillSearchView.BtnAddEvent += HandleSearchViewAddEvent;
            _ItsView.SkillSearchView.BtnUpdateEvent += HandleSearchViewUpdateEvent;
            _ItsView.SkillSearchView.BtnDeleteEvent += HandleSearchViewDeleteEvent;
            _ItsView.SkillView.ActionButtonEvent += HandleSkillViewAddEvent;
            _ItsView.SkillView.CancelButtonEvent += HandleSkillViewCancelEvent;
        }

        public void InitView(bool pageIsPostBack)
        {
            _SearchPresenter.InitView(pageIsPostBack);

        }

        private void HandleSearchViewAddEvent()
        {
            new AddSkillPresenter(_ItsView.SkillView).InitView(false);
            _ItsView.ShowSkillViewVisible = true;
        }

        private void HandleSearchViewUpdateEvent(string id)
        {
            new UpdateSkillPresenter(_ItsView.SkillView).InitView(Convert.ToInt32(id));
            _ItsView.ShowSkillViewVisible = true;
        }

        private void HandleSearchViewDeleteEvent(string id)
        {
            new DeleteSkillPresenter(_ItsView.SkillSearchView).DeleteEvent(id);
            _SearchPresenter.SearchEvent();
        }

        private void HandleSkillViewAddEvent()
        {
            if (_ItsView.SkillView.ActionSuccess)
            {
                _ItsView.ShowSkillViewVisible = false;
                _SearchPresenter.SearchEvent();
            }
            else
            {
                _ItsView.ShowSkillViewVisible = true;
            }
        }

        private void HandleSkillViewCancelEvent()
        {
            _ItsView.ShowSkillViewVisible = false;
        }
    }
}
