//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IEditTaxBandView.cs
// Creater:  Xue.wenlong
// Date:  2008-12-25
// Resume:
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.ITax
{
    public interface IEditTaxBandView
    {
        string BandMin{ get; set;}
        string TaxRate{ get; set;}
        string BandMinMessage { get; set;}
        string TaxRateMessage { get; set;}
        string Message { get; set;}
        int TaxBandID { get; set;}
        string Title{ get; set;}
        event EventHandler EditEvent;
    }
}