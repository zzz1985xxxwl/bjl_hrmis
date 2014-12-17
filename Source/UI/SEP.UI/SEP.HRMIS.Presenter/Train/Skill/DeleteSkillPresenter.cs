//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: DeleteSkillPresenter.cs
// 创建者: ZZ
// 创建日期: 2008-11-07
// 概述: 删除技能的Presenter
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter;

namespace SEP.HRMIS.Presenter
{
  public class DeleteSkillPresenter
    {
      private readonly ISkillSearchView _View;
      private ISkillFacade _ISkillFacade = InstanceFactory.CreateSkillFacade();
      public DeleteSkillPresenter(ISkillSearchView view)
      {
          _View = view;
          AttachViewEvent();
      }
      private void AttachViewEvent()
      {
          _View.BtnDeleteEvent += DeleteEvent;
      }

      public void DeleteEvent(string id)
      {
          int _ID;
          if (!VaildateSkillId(id, out _ID))
          {
              return;
          }
          try
          {
              _ISkillFacade.DeleteSkill(_ID);
          }
          catch (ApplicationException ex)
          {
              _View.ErrorMessage = "<span class='fontred'>" + ex.Message + "</span>";
          }
      }

      private bool VaildateSkillId(string id, out int skillId)
      {
          if (!int.TryParse(id, out skillId))
          {
              _View.ErrorMessage = SkillUtility._SkillIDError;
              return false;
          }
          return true;
      }

      public ISkillFacade DeleteSkill
      {
          get { return _ISkillFacade; }
          set { _ISkillFacade = value; }
      }

    }
}
