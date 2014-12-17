//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: AddTaxBand.cs
// Creater:  Xue.wenlong
// Date:  2008-12-25
// Resume:增加税制
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.ITax;

namespace SEP.HRMIS.Presenter.PayModule.Tax
{
    public class AddTaxBandPresenter : EditTaxBandBase
    {
        public AddTaxBandPresenter(IEditTaxBandView view,bool isPostBack) : base(view)
        {
            AttachViewEvent();
            Init(isPostBack);
        }
        /// <summary>
        /// for test
        /// </summary>
        public AddTaxBandPresenter(IEditTaxBandView view, bool isPostBack, ITaxFacade mockTax)
            : this(view,isPostBack)
        {
            _ITax = mockTax;
        }

        private void AttachViewEvent()
        {
            _IEditTaxBandView.EditEvent += AddTaxBandEvent;
        }

        private void Init(bool isPostBack)
        {
            InitMessage();
            _IEditTaxBandView.Title = "新增税阶";
            if (!isPostBack)
            {
                _IEditTaxBandView.TaxRate = string.Empty;
                _IEditTaxBandView.BandMin = string.Empty;
            }
        }

        public void AddTaxBandEvent(object sender, EventArgs e)
        {
            if (TaxValidition.ValidTaxBand(_IEditTaxBandView))
            {
                try
                {
                    _ITax.CreateTaxBand(Convert.ToDecimal(_IEditTaxBandView.BandMin),
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