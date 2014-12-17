using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;

namespace SEP.Performance.Views.HRMIS.TrainApplication
{
    public partial class TrainApplicationFlowListView : UserControl, ITrainApplicationFlowListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            BindTraineeApplicationFlowListSource(null, null);
            grdTrainApplicationFlowList.PageIndex = pageindex;
            grdTrainApplicationFlowList.DataSource = _TraineeApplicationFlowListSource;
            grdTrainApplicationFlowList.DataBind();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grdTrainApplicationFlowList, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void grdTrainApplicationFlowList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindTraineeApplicationFlowListSource(null, null);
            grdTrainApplicationFlowList.PageIndex = e.NewPageIndex;
            grdTrainApplicationFlowList.DataSource = _TraineeApplicationFlowListSource;
            grdTrainApplicationFlowList.DataBind();
        }

        protected void grdTrainApplicationFlowList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }

        private List<TraineeApplicationFlow> _TraineeApplicationFlowListSource;
        public List<TraineeApplicationFlow> TraineeApplicationFlowListSource
        {
            set
            {
                _TraineeApplicationFlowListSource = value;
                grdTrainApplicationFlowList.DataSource = value;
                grdTrainApplicationFlowList.DataBind();
                if (value.Count == 0)
                {
                    divTrainApplicationFlowList.Style["display"] = "none";
                }
                else
                {
                    divTrainApplicationFlowList.Style["display"] = "block";
                }
            }
        }

        public event EventHandler BindTraineeApplicationFlowListSource;
    }
}