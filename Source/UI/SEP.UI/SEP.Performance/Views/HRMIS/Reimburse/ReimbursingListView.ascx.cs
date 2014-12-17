using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;
using ShiXin.Security;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.Performance.Views.HRMIS.Reimburse
{
    public partial class ReimbursingListView : UserControl, IReimbursingListView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            grd.PageIndex = pageindex;
            BindEmployeeReimbursingSource(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grd, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            BindEmployeeReimbursingSource(null, null);
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

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        private hrmisModel.Employee _EmployeeReimbursingSource;
        public hrmisModel.Employee EmployeeReimbursingSource
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
                    SetgrdDisplay();
                }
            }
        }
        private void SetgrdDisplay()
        {
            foreach (GridViewRow row in grd.Rows)
            {
                Label lblStatus = (Label)row.FindControl("lblStatus");
                LinkButton btnUpdate = (LinkButton)row.FindControl("btnUpdate");
                LinkButton btnDelete = (LinkButton)row.FindControl("btnDelete");
                LinkButton btnPrint = (LinkButton)row.FindControl("btnPrint");
                //LinkButton btnCancel = (LinkButton)row.FindControl("btnCancel");

                switch (hrmisModel.Reimburse.GetReimburseStatusByReimburseStatusName(lblStatus.Text))
                {
                    case ReimburseStatusEnum.Return:
                    case ReimburseStatusEnum.Added:
                        btnUpdate.Enabled = true;
                        btnUpdate.Text = "±à¼­";
                        btnDelete.Enabled = true;
                        btnDelete.Text = "É¾³ý";
                        break;
                    case ReimburseStatusEnum.Reimbursing:
                        HiddenField hfReimburseID1 = (HiddenField)row.FindControl("hfReimburseID");
                        HiddenField hfReimburseCategoriesEnum1 = (HiddenField)row.FindControl("hfReimburseCategoriesEnum");
                        btnPrint.Enabled = true;
                        btnPrint.Text = "´òÓ¡";

                        if (hfReimburseCategoriesEnum1.Value == ReimburseCategoriesEnum.TravelReimburse.Id.ToString())
                        {
                            btnPrint.OnClientClick = "Confirmed = false;window.open('PrintTravelReimburse.aspx?ReimburseID=" +
                                                     SecurityUtil.DECEncrypt(
                                                         hfReimburseID1.Value) +
                                                     "','','resizable=1,scrollbars=1,status=1,menubar=no,toolbar=no,location=no, menu=no') ";
                        }
                        else
                        {
                            btnPrint.OnClientClick = "Confirmed = false;window.open('PrintReimburse.aspx?ReimburseID=" +
                                                     SecurityUtil.DECEncrypt(
                                                         hfReimburseID1.Value) +
                                                     "','','resizable=1,scrollbars=1,status=1,menubar=no,toolbar=no,location=no, menu=no') ";
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        public event EventHandler btnAddClick;
        public event EventHandler BindEmployeeReimbursingSource;

        protected void btnAdd_Command(object sender, EventArgs e)
        {
            btnAddClick(sender, e);
        }

        public event CommandEventHandler btnUpdateClick;
        public event CommandEventHandler btnDeleteClick;
        public event CommandEventHandler btnViewClick;
        public event CommandEventHandler btnPrintClick;
        protected void btnUpdate_Command(object sender, CommandEventArgs e)
        {
            btnUpdateClick(sender, e);
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            btnDeleteClick(sender, e);
        }
        public event DelegateNoParameter UpdateView;
    }
}