using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.Adjusts;
using SEP.HRMIS.Presenter.IPresenter.IAdjustRule;

namespace SEP.HRMIS.Presenter.AdjustRules
{
    public class DetailAdjustRulePresenter
    {
        private readonly IAdjustRuleEditView _View;
        private readonly IAdjustRuleFacade _AdjustRuleFacade = InstanceFactory.CreateAdjustRuleFacade();

        public DetailAdjustRulePresenter(IAdjustRuleEditView view, bool isPostBack)
        {
            _View = view;
            InitView(isPostBack);
        }

        private void InitView(bool isPostBack)
        {
            if (!isPostBack)
            {
                AdjustRule adjustRule = _AdjustRuleFacade.GetAdjustRuleByAdjustRuleID(_View.AdjustRuleID);
                _View.Operation = "查看调休规则";
                _View.Name = adjustRule.AdjustRuleName;
                _View.OutCityJieRiRate = adjustRule.OutCityJieRiRate.ToString();
                _View.OutCityPuTongRate = adjustRule.OutCityPuTongRate.ToString();
                _View.OutCityShuangXiuRate = adjustRule.OutCityShuangXiuRate.ToString();
                _View.OverWorkJieRiRate = adjustRule.OverWorkJieRiRate.ToString();
                _View.OverWorkPuTongRate = adjustRule.OverWorkPuTongRate.ToString();
                _View.OverWorkShuangXiuRate = adjustRule.OverWorkShuangXiuRate.ToString();
                _View.Message = string.Empty;
                _View.Message = string.Empty;
                _View.OutCityJieRiRateMessage = string.Empty;
                _View.OutCityPuTongRateMessage = string.Empty;
                _View.OutCityShuangXiuRateMessage = string.Empty;
                _View.OverWorkJieRiRateMessage = string.Empty;
                _View.OverWorkPuTongRateMessage = string.Empty;
                _View.OverWorkShuangXiuRateMessage = string.Empty;
                 _View.NameMessage = string.Empty;
            }
        }
    }
}