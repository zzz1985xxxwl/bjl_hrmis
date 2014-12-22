//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: EditTaxBandBase.cs
// Creater:  Xue.wenlong
// Date:  2008-12-25
// Resume:
// ----------------------------------------------------------------

using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.ITax;

namespace SEP.HRMIS.Presenter.PayModule.Tax
{
    public class EditTaxBandBase
    {
        protected IEditTaxBandView _IEditTaxBandView;
        protected ITaxFacade _ITax = InstanceFactory.CreateTaxFacade();

        public delegate void EditCompleted(bool hasError);

        public EditCompleted _Completed;

        public EditTaxBandBase(IEditTaxBandView view)
        {
            _IEditTaxBandView = view;
        }

        protected void InitMessage()
        {
            _IEditTaxBandView.TaxRateMessage = string.Empty;
            _IEditTaxBandView.BandMinMessage = string.Empty;
            _IEditTaxBandView.Message = string.Empty;
        }

        protected bool HasError()
        {
            if (string.IsNullOrEmpty(_IEditTaxBandView.TaxRateMessage) &&
                string.IsNullOrEmpty(_IEditTaxBandView.BandMinMessage) &&
                string.IsNullOrEmpty(_IEditTaxBandView.Message))
            {
                return false;
            }
            return true;
        }

    }
}