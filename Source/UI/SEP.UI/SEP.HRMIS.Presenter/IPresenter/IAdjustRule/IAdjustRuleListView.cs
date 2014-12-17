using System.Collections.Generic;
using SEP.HRMIS.Model.Adjusts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAdjustRule
{
    public interface IAdjustRuleListView
    {
        List<AdjustRule> AdjustRuleList{ get; set;}
        string Name{ get; set;}
        string Message { set;}
        event DelegateNoParameter Search;
        event DelegateNoParameter AddAdjustRule;
        event DelegateID DeleteAdjustRule;
        event DelegateID UpdateAdjustRule;
        event DelegateID ShowAdjustRule;
    }
}