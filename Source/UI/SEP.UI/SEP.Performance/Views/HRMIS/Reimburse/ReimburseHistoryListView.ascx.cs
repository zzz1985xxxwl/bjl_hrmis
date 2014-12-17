using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.Performance.Views.HRMIS.Reimburse
{
    public partial class ReimburseHistoryListView : UserControl, IReimburseHistoryListView
    {
        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            BindEmployeeReimburseHistorySource(null, null);
        }
        public int ListCount
        {
            get { return Convert.ToInt32(hfCount.Value); }
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    btnViewClick(sender, e);
                    return;
            }
        }
        public event CommandEventHandler btnViewClick;

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        public hrmisModel.Employee EmployeeReimburseHistorySource
        {
            set
            {
                grd.DataSource = value.Reimburses;
                grd.DataBind();
                hfCount.Value = value.Reimburses.Count.ToString();
                if (value.Reimburses.Count == 0)
                {
                    tbReimburse.Style["display"] = "none";
                }
                else
                {
                    tbReimburse.Style["display"] = "block";
                }
            }
        }

        public event EventHandler BindEmployeeReimburseHistorySource;
    }
}