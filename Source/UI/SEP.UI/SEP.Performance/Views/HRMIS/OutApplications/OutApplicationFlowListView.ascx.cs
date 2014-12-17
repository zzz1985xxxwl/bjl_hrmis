using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Presenter.IPresenter.IOutApplication;
using SEP.Presenter.Core;
namespace SEP.Performance.Views.HRMIS.OutApplications
{
    public partial class OutApplicationFlowListView : UserControl, IOutApplicationFlowListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            BindOutApplicationFlowSource();
            grd.PageIndex = pageindex;
            grd.DataSource = _OutApplicationSource;
            grd.DataBind();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grd, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        private List<OutApplicationFlow> _OutApplicationSource;

        public List<OutApplicationFlow> OutApplicationFlowSource
        {
            set
            {
                _OutApplicationSource = value;
                grd.DataSource = value;
                grd.DataBind();
            }
        }

        public event DelegateNoParameter BindOutApplicationFlowSource;

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindOutApplicationFlowSource();
            grd.PageIndex = e.NewPageIndex;
            grd.DataSource = _OutApplicationSource;
            grd.DataBind();
        }


        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }
    }
}