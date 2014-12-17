using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAdjustRule
{
    public interface IAdjustRuleEditView
    {
        string OverWorkPuTongRate { get; set; }
        string OverWorkJieRiRate { get; set; }
        string OverWorkShuangXiuRate { get; set; }
        string OutCityPuTongRate { get; set; }
        string OutCityJieRiRate { get; set; }
        string OutCityShuangXiuRate { get; set; }
        string OverWorkPuTongRateMessage { set; }
        string OverWorkJieRiRateMessage { set; }
        string OverWorkShuangXiuRateMessage { set; }
        string OutCityPuTongRateMessage { set; }
        string OutCityJieRiRateMessage { set; }
        string OutCityShuangXiuRateMessage { set; }
        string NameMessage { set; }
        string Message { set; }
        string Name { get; set; }
        string Operation { get; set; }
        string OpreationType{ get; set;}
        bool ReadOnly { set; }
        int AdjustRuleID { get; set; }
        event DelegateNoParameter ActionButtonEvent;
    }
}