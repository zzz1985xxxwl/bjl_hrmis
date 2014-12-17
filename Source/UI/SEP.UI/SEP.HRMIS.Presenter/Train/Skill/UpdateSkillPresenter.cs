//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: UpdateSkillPresenter.cs
// 创建者: ZZ
// 创建日期: 2008-11-17
// 概述: 测试UpdateSkillPresenter
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter;

namespace SEP.HRMIS.Presenter
{
    public class UpdateSkillPresenter
    {
        private readonly ISkillView _ItsView;
        private ISkillTypeFacade _ISkillTypeFacade = InstanceFactory.CreateSkillTypeFacade();
        private ISkillFacade _ISkillFacade = InstanceFactory.CreateSkillFacade();
       
        public UpdateSkillPresenter(ISkillView view)
        {
            _ItsView = view;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += UpdateEvent;
        }

        public void InitView(int skillID)
        {
            _ItsView.OperationTitle = SkillUtility.UpdatePageTitle;
            _ItsView.OperationType = SkillUtility.UpdateOperationType;
            _ItsView.Message = string.Empty;
            _ItsView.SkillNameMsg = string.Empty;
            _ItsView.SkillTypeMsg = string.Empty;

            Skill skill = _ISkillFacade.GetSkillByPKID(skillID);
            _ItsView.SkillID = skill.SkillID.ToString();
            _ItsView.SkillName = skill.SkillName;
            _ItsView.SkillTypes = _ISkillTypeFacade.GetSkillTypeByCondition(-1, "");
            _ItsView.SkillType = skill.SkillType.ParameterID.ToString();
        }

        public void UpdateEvent()
        {
            if (Validation())
            {
                SkillType skillType = _ISkillTypeFacade.GetSkillTypeByPKID((Convert.ToInt32(_ItsView.SkillType)));
                Skill skill = new Skill(Convert.ToInt32(_ItsView.SkillID), _ItsView.SkillName, skillType);
                try
                {
                _ISkillFacade.UpdateSkill(skill);
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
        public ISkillFacade UpdateSkill
        {
            get { return _ISkillFacade; }
        }
        public ISkillTypeFacade SetSkillType
        {
            set { _ISkillTypeFacade = value; }
        }
        public ISkillFacade SetSkill
        {
            set { _ISkillFacade = value; }
        }
        #endregion
    }
}
