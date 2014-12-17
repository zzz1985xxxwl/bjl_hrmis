using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.ITax;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.Tax
{
    public partial class IndividualIncomeTaxView : UserControl, IIndividualIncomeTaxView
    {
        private List<TaxBand> _TaxBand;

        #region interface

        public List<TaxBand> TaxBandList
        {
            get { return _TaxBand; }
            set
            {
                _TaxBand = value;
                BindTaxBand();
            }
        }

        public string TaxCutoffPoint
        {
            get { return txtTaxCutoffPoint.Text.Trim(); }
            set { txtTaxCutoffPoint.Text = value; }
        }

        public string TaxCutoffPointMessage
        {
            get { return lblTaxCutoffPoint.Text; }
            set
            {
                lblTaxCutoffPoint.Text = value;
                lblTaxCutoffPoint.Visible = string.IsNullOrEmpty(value) ? false : true;
            }
        }
        public string ForeignTaxCutoffPoint
        {
            get { return txtForeignTaxCutoffPoint.Text.Trim(); }
            set { txtForeignTaxCutoffPoint.Text = value; }
        }

        public string ForeignTaxCutoffPointMessage
        {
            get { return lblForeignTaxCutoffPoint.Text; }
            set
            {
                lblForeignTaxCutoffPoint.Text = value;
                lblForeignTaxCutoffPoint.Visible = string.IsNullOrEmpty(value) ? false : true;
            }
        }
        public string Message
        {
            get { return ErrorMessage.Text; }
            set
            {
                ErrorMessage.Text = value;
                trMessage.Visible = string.IsNullOrEmpty(value) ? false : true;
            }
        }

        public event EventHandler SaveTaxCutoffPoint;
        public event EventHandler AddTaxBand;
        public event CommandEventHandler UpdateTaxBand;
        public event CommandEventHandler DeleteTaxBand;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvTaxBand.PageIndex = pageindex;
            BindTaxBand();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvTaxBand, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        private void BindTaxBand()
        {
            if (TaxBandList != null && TaxBandList.Count > 0)
            {
                tbGVTaxBand.Visible = true;
            }
            else
            {
                tbGVTaxBand.Visible = false;
            }
            gvTaxBand.DataSource = TaxBandList;
            gvTaxBand.DataBind();
        }

        protected void gvTaxBand_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTaxBand.PageIndex = e.NewPageIndex;
            BindTaxBand();
        }

        protected void btnSaveTaxCutoffPoint_Click(object sender, EventArgs e)
        {
            SaveTaxCutoffPoint(sender, e);
        }

        protected void btnAddTaxBand_Click(object sender, EventArgs e)
        {
            AddTaxBand(sender, e);
        }


        protected void gvTaxBand_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        protected void UpdateTaxBand_Command(object sender, CommandEventArgs e)
        {
            UpdateTaxBand(sender, e);
        }

        protected void DeleteTaxBand_Command(object sender, CommandEventArgs e)
        {
            DeleteTaxBand(sender, e);
        }
    }
}