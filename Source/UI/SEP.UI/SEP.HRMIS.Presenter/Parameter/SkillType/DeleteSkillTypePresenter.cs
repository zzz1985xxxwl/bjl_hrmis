using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter;

namespace SEP.HRMIS.Presenter.Parameter.SkillType
{
   public class DeleteSkillTypePresenter
    {
        private readonly ISkillTypeListView _View;
       private ISkillTypeFacade _ISkillTypeFacade = InstanceFactory.CreateSkillTypeFacade();

       public DeleteSkillTypePresenter(ISkillTypeListView view)
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
           if (!VaildateId(id, out _ID))
           {
               return;
           }
           try
           {
               _ISkillTypeFacade.DeleteSkillType(_ID);
           }
           catch (ApplicationException ex)
           {
               _View.ErrorMessage = "<span class='fontred'>" + ex.Message + "</span>";
           }
       }

       private bool VaildateId(string id, out int skillTypeId)
       {
           if (!int.TryParse(id, out skillTypeId))
           {
               _View.ErrorMessage = "删除的记录ID不正确";
               return false;
           }
           return true;
       }

       #region 测试用

       public ISkillTypeFacade Skill
       {
           get { return _ISkillTypeFacade; }
       }

       #endregion
    }
}
