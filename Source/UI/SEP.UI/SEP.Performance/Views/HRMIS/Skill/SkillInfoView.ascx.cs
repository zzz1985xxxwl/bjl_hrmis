using System;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.IPresenter;

namespace SEP.Performance.Views.Skill
{
    public partial class SkillInfoView : System.Web.UI.UserControl,ISkillInfoView
    {
        public ISkillSearchView SkillSearchView
        {
            get { return SkillListView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public ISkillView SkillView
        {
            get { return SkillView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public bool ShowSkillViewVisible
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set
            {
                if (value)
                {
                    mpeSkill.Show();
                }
                else
                {
                    mpeSkill.Hide();
                }
            }
        }
    }
}