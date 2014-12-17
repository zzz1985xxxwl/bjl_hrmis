using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SEP.Presenter.Positions;

namespace SEP.Performance.Pages.SEP.PositionPages
{
    public partial class PositionGradeManage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PositionGradePresenter presenter = new PositionGradePresenter(PositionGradeView1, LoginUser);
            presenter.InitView(IsPostBack);
        }
    }
}
