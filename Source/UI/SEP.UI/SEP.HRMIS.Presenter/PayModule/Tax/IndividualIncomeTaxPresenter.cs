//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IndividualIncomeTaxPresenter.cs
// Creater:  Xue.wenlong
// Date:  2008-12-25
// Resume:
// ----------------------------------------------------------------

using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.ITax;

namespace SEP.HRMIS.Presenter.PayModule.Tax
{
    public class IndividualIncomeTaxPresenter
    {
        private readonly IIndividualIncomeTaxView _View;
        private readonly ITaxFacade _ITax = InstanceFactory.CreateTaxFacade();

        public IndividualIncomeTaxPresenter(IIndividualIncomeTaxView view, bool isPostBack)
        {
            _View = view;
            AttachViewEvent();
            InitView(isPostBack);
        }
        /// <summary>
        /// for test
        /// </summary>
        public IndividualIncomeTaxPresenter(IIndividualIncomeTaxView view, bool isPostBack, ITaxFacade mockTax)
        {
            _ITax = mockTax;
            _View = view;
            AttachViewEvent();
            InitView(isPostBack);
        }

        private void AttachViewEvent()
        {
            _View.DeleteTaxBand += DeleteTaxBand;
            _View.SaveTaxCutoffPoint += SaveTaxCutoffPoint;
        }

        public void InitView(bool isPostBack)
        {
            _View.TaxCutoffPointMessage = string.Empty;
            _View.ForeignTaxCutoffPointMessage = string.Empty;

            _View.Message = string.Empty;
            if (!isPostBack)
            {
                BindIndividualIncomeTax();
            }
        }

        private void BindIndividualIncomeTax()
        {
            IndividualIncomeTax individualIncomeTax = _ITax.GetIndividualIncomeTax();
            foreach (TaxBand t in individualIncomeTax.TaxBands)
            {
                t.TaxRate *= 100;
            }
            _View.TaxBandList = individualIncomeTax.TaxBands;
            _View.TaxCutoffPoint = individualIncomeTax.TaxCutoffPoint.ToString();
            _View.ForeignTaxCutoffPoint = individualIncomeTax.ForeignTaxCutoffPoint.ToString();
        }

        public void DeleteTaxBand(object sender, CommandEventArgs e)
        {
            try
            {
                _ITax.DeleteTaxBand(Convert.ToInt32(e.CommandArgument));
                BindIndividualIncomeTax();
            }
            catch (ApplicationException ex)
            {
                _View.Message = //"<img src=\"../../image/icon03.jpg\" align=\"absmiddle\" /><span class='fontred'>" + 
                    ex.Message;// +"</span>";
            }
        }

        public void SaveTaxCutoffPoint(object sender, EventArgs e)
        {
            if (TaxValidition.ValidTaxCutoffPoint(_View))
            {
                try
                {
                    _ITax.SaveTaxCutoffPoint(Convert.ToDecimal(_View.TaxCutoffPoint),
                        Convert.ToDecimal(_View.ForeignTaxCutoffPoint));
                    _View.Message = "<span class='fontred'>修改起征点成功</span>";
                }
                catch (ApplicationException ex)
                {
                    _View.Message =
                        //"<img src=\"../../image/icon03.jpg\" align=\"absmiddle\" /><span class='fontred'>" + 
                        ex.Message;// +"</span>";
                }
            }
        }
    }
}