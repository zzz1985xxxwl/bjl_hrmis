//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: TaxValidition.cs
// Creater:  Xue.wenlong
// Date:  2008-12-25
// Resume:
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Presenter.PayModule.IPresenter.ITax;

namespace SEP.HRMIS.Presenter.PayModule.Tax
{
    public class TaxValidition
    {
        private TaxValidition()
        {
        }

        public static bool ValidTaxCutoffPoint(IIndividualIncomeTaxView view)
        {
            bool validition = true;
            decimal taxCutoffPoint;
            //检验起征点
            if (string.IsNullOrEmpty(view.TaxCutoffPoint))
            {
                validition = false;
                view.TaxCutoffPointMessage = "请输入起征点";
            }
            else if (!Decimal.TryParse(view.TaxCutoffPoint, out taxCutoffPoint))
            {
                validition = false;
                view.TaxCutoffPointMessage = "格式错误";
            }
            else if (Convert.ToDecimal(view.TaxCutoffPoint) < 0)
            {
                validition = false;
                view.TaxCutoffPointMessage = "不可小于0";
            }

            return validition;
        }

        public static bool ValidTaxBand(IEditTaxBandView view)
        {
            bool validition = true;
            decimal temp;
           
            if (string.IsNullOrEmpty(view.BandMin))
            {
                validition = false;
                view.BandMinMessage = "不可为空";
            }
            else if (!Decimal.TryParse(view.BandMin, out temp))
            {
                validition = false;
                view.BandMinMessage = "格式错误";
            }
            else if (Convert.ToDecimal(view.BandMin) < 0)
            {
                validition = false;
                view.BandMinMessage = "不可小于0";
            }

            if (string.IsNullOrEmpty(view.TaxRate))
            {
                validition = false;
                view.TaxRateMessage = "不可为空";
            }
            else if (!Decimal.TryParse(view.TaxRate, out temp))
            {
                validition = false;
                view.TaxRateMessage = "格式错误";
            }
            else if (Convert.ToDecimal(view.TaxRate) < 0)
            {
                validition = false;
                view.TaxRateMessage = "不可小于0";
            }


            return validition;
        }
    }
}