//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: UpdateTaxBand.cs
// Creater:  Xue.wenlong
// Date:  2008-12-25
// Resume:
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.ITax;

namespace SEP.HRMIS.Presenter.PayModule.Tax
{
    public class UpdateTaxBandPresenter : EditTaxBandBase
    {
        public UpdateTaxBandPresenter(IEditTaxBandView view, bool isPostBack) : base(view)
        {
            AttachViewEvent();
            Init(isPostBack);
        }

        /// <summary>
        /// fot test
        /// </summary>
        public UpdateTaxBandPresenter(IEditTaxBandView view, bool isPostBack, ITaxFacade mockTax) : base(view)
        {
            _ITax = mockTax;
            AttachViewEvent();
            Init(isPostBack);
        }

        private void AttachViewEvent()
        {
            _IEditTaxBandView.EditEvent += UpdateTaxBandEvent;
        }

        private void Init(bool isPostBack)
        {
            InitMessage();
            _IEditTaxBandView.Title = "ÐÞ¸ÄË°½×";
            if (!isPostBack)
            {
                TaxBand taxBand = _ITax.GetTaxBandByTaxBandID(_IEditTaxBandView.TaxBandID);
                _IEditTaxBandView.BandMin = taxBand.BandMin.ToString();
                _IEditTaxBandView.TaxRate = (taxBand.TaxRate * 100).ToString();
            }
        }

        public void UpdateTaxBandEvent(object sender, EventArgs e)
        {
            if (TaxValidition.ValidTaxBand(_IEditTaxBandView))
            {
                try
                {
                    _ITax.UpdateTaxBand(_IEditTaxBandView.TaxBandID, Convert.ToDecimal(_IEditTaxBandView.BandMin),
                                        Convert.ToDecimal(_IEditTaxBandView.TaxRate)/100);
                }
                catch (ApplicationException ex)
                {
                    _IEditTaxBandView.Message = ex.Message;
                }
            }
            _Completed(HasError());
        }
    }
}