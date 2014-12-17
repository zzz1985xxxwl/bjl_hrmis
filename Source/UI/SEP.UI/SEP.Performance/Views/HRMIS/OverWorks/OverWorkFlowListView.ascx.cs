using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;
using SEP.Presenter.Core;
namespace SEP.Performance.Views.HRMIS.OverWorks
{
    public partial class OverWorkFlowListView : UserControl, IOverWorkFlowListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            BindOverWorkFlowSource();
            grd.PageIndex = pageindex;
            grd.DataSource = _OverWorkSource;
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

        private List<OverWorkFlow> _OverWorkSource;

        public List<OverWorkFlow> OverWorkFlowSource
        {
            set
            {
                _OverWorkSource = value;
                grd.DataSource = value;
                grd.DataBind();
            }
        }

        public event DelegateNoParameter BindOverWorkFlowSource;

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindOverWorkFlowSource();
            grd.PageIndex = e.NewPageIndex;
            grd.DataSource = _OverWorkSource;
            grd.DataBind();
        }


        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }
    }
}