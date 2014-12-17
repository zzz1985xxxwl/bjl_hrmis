//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: AddSkillPresenter.cs
// 创建者: ZZ
// 创建日期: 2008-11-07
// 概述: 新增技能小界面的Presenter
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter;

namespace SEP.HRMIS.Presenter
{
    public class AddSkillPresenter
    {
        private readonly ISkillView _ItsView;
        private ISkillTypeFacade _ISkillTypeFacade = InstanceFactory.CreateSkillTypeFacade();
        private ISkillFacade _ISkillFacade = InstanceFactory.CreateSkillFacade();

        public AddSkillPresenter(ISkillView view)
        {
            _ItsView = view;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += AddEvent;
        }

        public void InitView(bool isPostBack)
        {
            _ItsView.Message = string.Empty;
            if (!isPostBack)
            {
                _ItsView.OperationTitle = SkillUtility.AddPageTitle;
                _ItsView.OperationType = SkillUtility.AddOperationType;
                _ItsView.SkillNameMsg = string.Empty;
                _ItsView.SkillTypeMsg = string.Empty;
                _ItsView.SkillID = string.Empty;
                _ItsView.SkillName = string.Empty;
                _ItsView.SkillTypes = _ISkillTypeFacade.GetSkillTypeByCondition(-1, "");
            }
        }

        public void AddEvent()
        {
            if (Validation())
            {
                SkillType skillType = _ISkillTypeFacade.GetSkillTypeByPKID(Convert.ToInt32(_ItsView.SkillType));
                Skill skill = new Skill(1, _ItsView.SkillName, skillType);
                try
                {
                _ISkillFacade.AddSkill(skill);
                    _ItsView.ActionSuccess = true;
                }
                catch (ApplicationException ex)
                {
                    _ItsView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

        public bool Validation()
        {
            bool iRet = true;
            if (string.IsNullOrEmpty(_ItsView.SkillName.Trim()))
            {
                _ItsView.SkillNameMsg = SkillUtility._NameIsEmpty;
                iRet = false;
            }
            else
            {
                _ItsView.SkillNameMsg = string.Empty;
            }
            if (_ItsView.SkillType == "-1")
            {
                _ItsView.SkillTypeMsg = SkillUtility._SkillTypeIsEmpty;
                iRet = false;
            }
            else
            {
                _ItsView.SkillTypeMsg = string.Empty;
            }
            return iRet;
        }

        #region test
        public ISkillTypeFacade SetSkillType
        {
            set { _ISkillTypeFacade = value; }
        }

        public ISkillFacade AddSkill
        {
            get { return _ISkillFacade; }
        }
        #endregion
    }
}
