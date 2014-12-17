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
            //����������
            if (string.IsNullOrEmpty(view.TaxCutoffPoint))
            {
                validition = false;
                view.TaxCutoffPointMessage = "������������";
            }
            else if (!Decimal.TryParse(view.TaxCutoffPoint, out taxCutoffPoint))
            {
                validition = false;
                view.TaxCutoffPointMessage = "��ʽ����";
            }
            else if (Convert.ToDecimal(view.TaxCutoffPoint) < 0)
            {
                validition = false;
                view.TaxCutoffPointMessage = "����С��0";
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
                view.BandMinMessage = "����Ϊ��";
            }
            else if (!Decimal.TryParse(view.BandMin, out temp))
            {
                validition = false;
                view.BandMinMessage = "��ʽ����";
            }
            else if (Convert.ToDecimal(view.BandMin) < 0)
            {
                validition = false;
                view.BandMinMessage = "����С��0";
            }

            if (string.IsNullOrEmpty(view.TaxRate))
            {
                validition = false;
                view.TaxRateMessage = "����Ϊ��";
            }
            else if (!Decimal.TryParse(view.TaxRate, out temp))
            {
                validition = false;
                view.TaxRateMessage = "��ʽ����";
            }
            else if (Convert.ToDecimal(view.TaxRate) < 0)
            {
                validition = false;
                view.TaxRateMessage = "����С��0";
            }


            return validition;
        }
    }
}