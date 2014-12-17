using System;
using System.Web.UI.WebControls;

namespace SEP.Performance.Views
{
    public partial class PageTemplate : System.Web.UI.UserControl
    {
        public delegate void LinkButtonGoPageClick(int pageindex);

        public delegate void GoalLinkButtonGoPageClick();

        public LinkButtonGoPageClick LinkButtonGoPageClickdelegate;
        public GoalLinkButtonGoPageClick GoalLinkButtonGoPageClickdelegate;

        protected void LinkButtonGoPage_Click(object sender, EventArgs e)
        {
            if (GoalLinkButtonGoPageClickdelegate != null)
            {
                GoalLinkButtonGoPageClickdelegate();
            }
            else
            {
                int index;
                if (int.TryParse(txtGoPage.Text.Trim(), out index))
                {
                    index = index < 1 ? 1 : index;
                    LinkButtonGoPageClickdelegate(index - 1);
                }
            }
        }
    }
}