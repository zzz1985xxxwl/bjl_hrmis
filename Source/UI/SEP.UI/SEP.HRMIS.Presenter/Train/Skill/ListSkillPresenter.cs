//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: SkillPresenter.cs
// 创建者: ZZ
// 创建日期: 2008-11-07
// 概述: 技能大界面的Presenter
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter;

namespace SEP.HRMIS.Presenter
{
    public class ListSkillPresenter
    {
        private readonly ISkillSearchView _View;
        private ISkillTypeFacade _ISkillTypeFacade = InstanceFactory.CreateSkillTypeFacade();
        private ISkillFacade _ISkillFacade = InstanceFactory.CreateSkillFacade();

        public ListSkillPresenter(ISkillSearchView view)
        {
            _View = view;
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            _View.BtnSearchEvent += SearchEvent;
        }

        public void InitView(bool isPostBack)
        {
            _View.ErrorMessage = string.Empty;
            if (!isPostBack)
            {
                _View.SkillTypeList = _ISkillTypeFacade.GetSkillTypeByCondition(-1, "");
                SearchEvent();
            }
        }

        public void SearchEvent()
        {
            List<Model.Skill> itsSource = _ISkillFacade.GetSkillByCondition(_View.SkillName, _View.SelectedSkillTypeID);
            _View.Skills = itsSource;
        }
    }
}
