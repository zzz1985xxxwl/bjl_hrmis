using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.PayModule.Tax;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.Tax
{
    public partial class IndividualIncomeTaxWithEditTaxBand : UserControl
    {
        private IndividualIncomeTaxPresenter _IndividualIncomeTaxPresenter;
        private UpdateTaxBandPresenter _UpdateTaxBandPresenter;
        private AddTaxBandPresenter _AddTaxBandPresenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _IndividualIncomeTaxPresenter = new IndividualIncomeTaxPresenter(IndividualIncomeTaxView1, IsPostBack);
            IndividualIncomeTaxView1.AddTaxBand += AddTaxBand;
            IndividualIncomeTaxView1.UpdateTaxBand += UpdateTaxBand;

            if (EditTaxBand1.Title.Contains("修改"))
            {
                _UpdateTaxBandPresenter = new UpdateTaxBandPresenter(EditTaxBand1, IsPostBack);
                _UpdateTaxBandPresenter._Completed = InitIndividualIncomeTaxView;
            }
            else
            {
                _AddTaxBandPresenter = new AddTaxBandPresenter(EditTaxBand1, IsPostBack);
                _AddTaxBandPresenter._Completed = InitIndividualIncomeTaxView;
            }
            //修正小界面关闭按钮
            EditTaxBand1.btnCancelOnClientClick
                = "return CloseModalPopupExtender('" + divMPE.ClientID + "');";
        }

        private void UpdateTaxBand(object sender, CommandEventArgs e)
        {
            EditTaxBand1.TaxBandID = Convert.ToInt32(e.CommandArgument);
            _UpdateTaxBandPresenter = new UpdateTaxBandPresenter(EditTaxBand1, false);
            mpeOperation.Show();
        }

        private void AddTaxBand(object sender, EventArgs e)
        {
            _AddTaxBandPresenter = new AddTaxBandPresenter(EditTaxBand1, false);
            mpeOperation.Show();
        }

        private void InitIndividualIncomeTaxView(bool hasError)
        {
            if (hasError)
            {
                mpeOperation.Show();
            }
            else
            {
                _IndividualIncomeTaxPresenter.InitView(false);
                UpdatePanel1.Update();
            }
        }
    }
}