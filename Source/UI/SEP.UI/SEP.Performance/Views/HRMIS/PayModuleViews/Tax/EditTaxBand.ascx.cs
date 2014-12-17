using System;
using SEP.HRMIS.Presenter.PayModule.IPresenter.ITax;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.Tax
{
    public partial class EditTaxBand : System.Web.UI.UserControl, IEditTaxBandView
    {
        #region interface

        public string BandMin
        {
            get { return txtBandMin.Text.Trim(); }
            set { txtBandMin.Text = value; }
        }

        public string TaxRate
        {
            get { return txtTaxRate.Text.Trim(); }
            set { txtTaxRate.Text = value; }
        }

        public string BandMinMessage
        {
            get { return lblBindMin.Text; }
            set { lblBindMin.Text = value; lblBindMin.Visible = string.IsNullOrEmpty(value) ? false : true; }
        }

        public string TaxRateMessage
        {
            get { return lblTaxRate.Text; }
            set { lblTaxRate.Text = value; lblTaxRate.Visible = string.IsNullOrEmpty(value) ? false : true; }
        }

        public string Message
        {
            get { return ErrorMessage.Text; }
            set { ErrorMessage.Text = value; tbMessage.Visible = string.IsNullOrEmpty(value) ? false : true; }
        }

        public int TaxBandID
        {
            get { return Convert.ToInt32(ViewState["TaxBandID"]); }
            set { ViewState["TaxBandID"] = value; }
        }

        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        public event EventHandler EditEvent;

        #endregion
        /// <summary>
        /// 关闭小界面设置
        /// </summary>
        public string btnCancelOnClientClick
        {
            set { btnCancel.OnClientClick = value; }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EditEvent(sender,e);
        }
    }
}