//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: AdjustRuleUtility.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-31
// Resume: 
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Model.Adjusts;
using SEP.HRMIS.Presenter.IPresenter.IAdjustRule;

namespace SEP.HRMIS.Presenter.AdjustRules
{
    public class AdjustRuleUtility
    {
        public bool Valide(IAdjustRuleEditView view)
        {
            bool valide=true;
            bool valideout;
            view.OutCityJieRiRateMessage = ConvertToDecimail(view.OutCityJieRiRate, out valideout);
            valide &= valideout;
            view.OutCityPuTongRateMessage = ConvertToDecimail(view.OutCityPuTongRate, out valideout);
            valide &= valideout;
            view.OutCityShuangXiuRateMessage = ConvertToDecimail(view.OutCityShuangXiuRate, out valideout);
            valide &= valideout;
            view.OverWorkJieRiRateMessage = ConvertToDecimail(view.OverWorkJieRiRate, out valideout);
            valide &= valideout;
            view.OverWorkShuangXiuRateMessage = ConvertToDecimail(view.OverWorkShuangXiuRate, out valideout);
            valide &= valideout;
            view.OverWorkPuTongRateMessage = ConvertToDecimail(view.OverWorkPuTongRate, out valideout);
            valide &= valideout;
            if(string.IsNullOrEmpty(view.Name))
            {
                valide = false;
                view.NameMessage = "不可为空";
            }
            return valide;
        }

        public AdjustRule GetAdjustRuleData(IAdjustRuleEditView view)
        {
            return
                new AdjustRule(view.AdjustRuleID, view.Name, Convert.ToDecimal(view.OverWorkPuTongRate),
                               Convert.ToDecimal(view.OverWorkJieRiRate),
                               Convert.ToDecimal(view.OverWorkShuangXiuRate),
                               Convert.ToDecimal(view.OutCityPuTongRate), Convert.ToDecimal(view.OutCityJieRiRate),
                               Convert.ToDecimal(view.OutCityShuangXiuRate));
        }

        private static string ConvertToDecimail(string text, out bool valide)
        {
            decimal temp;
            if (string.IsNullOrEmpty(text))
            {
                valide = false;
                return "不可为空";
            }
            if (!Decimal.TryParse(text, out temp))
            {
                valide = false;
                return "格式错误";
            }
            valide = true;
            return "";
        }
    }
}