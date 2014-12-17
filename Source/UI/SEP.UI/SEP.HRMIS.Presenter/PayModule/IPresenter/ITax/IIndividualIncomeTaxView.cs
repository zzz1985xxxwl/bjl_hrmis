//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IIndividualIncomeTaxView.cs
// Creater:  Xue.wenlong
// Date:  2008-12-25
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.ITax
{
    public interface IIndividualIncomeTaxView
    {
        List<TaxBand> TaxBandList { get; set; }

        string TaxCutoffPoint { get; set; }

        string TaxCutoffPointMessage { get; set; }

        string ForeignTaxCutoffPoint{ get; set; }

        string ForeignTaxCutoffPointMessage { get; set; }

        string Message { get; set; }

        event EventHandler SaveTaxCutoffPoint;
        event EventHandler AddTaxBand;
        event CommandEventHandler UpdateTaxBand;
        event CommandEventHandler DeleteTaxBand;
    }
}