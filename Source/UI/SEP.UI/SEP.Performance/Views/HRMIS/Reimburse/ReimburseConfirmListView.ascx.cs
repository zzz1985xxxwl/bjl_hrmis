using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;
using SEP.Presenter.Core;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.Reimburse
{
    public partial class ReimburseConfirmListView : UserControl, IReimburseConfirmListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region IReimburseConfirmListView ≥…‘±

        public int ListCount
        {
            get { return Convert.ToInt32(hfCount.Value); }
        }
        public event EventHandler BindEmployeeReimbursingSource;

        private global::SEP.HRMIS.Model.Employee _EmployeeReimbursingSource;
        public global::SEP.HRMIS.Model.Employee EmployeeReimbursingSource
        {
            get
            {
                return _EmployeeReimbursingSource;
            }
            set
            {
                _EmployeeReimbursingSource = value;
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
        protected void Detail_Command(object sender, CommandEventArgs e)
        {
            btnViewClick(sender, e);
        }
        public event CommandEventHandler btnViewClick;

        protected void Approve_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ReimburseAuditing.aspx?ReimburseID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }

        protected void QuickPass_Command(object sender, CommandEventArgs e)
        {
            QuickPassEvent(this, e);
            UpdateView();
            //BindEmployeeReimbursingSource(null, null);
        }
        public event CommandEventHandler QuickPassEvent;

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            UpdateView();
            //BindEmployeeReimbursingSource(null, null);
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

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        public event DelegateNoParameter UpdateView;

        #endregion
    }
}