using System;
using System.Text;
using SEP.HRMIS.Presenter.EmployeeReimburse;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class GoogleDownBackCode : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerNameLikePresenter presenter = new CustomerNameLikePresenter();

            Response.Clear();
            Response.Charset = "utf-8";
            Response.Buffer = true;
            EnableViewState = false;
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/plain";
            if (Request.QueryString["q"] != null && Request.QueryString["q"] != "")
            {
                Response.Write(presenter.SearchLikeName(Request.QueryString["q"]));
            }
            else
            {
                Response.Write(presenter.SearchLikeName(""));
            }
            Response.Flush();
            Response.Close();
            Response.End();
        }
    }
}

