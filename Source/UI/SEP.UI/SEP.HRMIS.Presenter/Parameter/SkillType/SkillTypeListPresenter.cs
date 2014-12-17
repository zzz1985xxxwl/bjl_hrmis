using System.Collections.Generic;
using SEP.HRMIS.IFacede;


namespace SEP.HRMIS.Presenter.Parameter.SkillType
{
  public class SkillTypeListPresenter
    {
       private readonly ISkillTypeListView _View;
      private ISkillTypeFacade _ISkillTypeFacade = InstanceFactory.CreateSkillTypeFacade();


      public SkillTypeListPresenter(ISkillTypeListView view)
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
                SearchEvent();
            }
        }

        public void SearchEvent()
        {
            List<Model.SkillType> itsSource = _ISkillTypeFacade.GetSkillTypeByCondition(-1, _View.SkillTypeName);
            _View.SkillTypes = itsSource;
        }
    }
}
