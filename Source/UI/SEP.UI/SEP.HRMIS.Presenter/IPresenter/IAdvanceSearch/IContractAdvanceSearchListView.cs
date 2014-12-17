using System.Collections.Generic;
using AdvancedCondition;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAdvanceSearch
{
    public interface IContractAdvanceSearchListView
    {
        List<SearchField> SearchFieldSourceCookie { get;}
        List<SearchField> SearchFieldConditionSource { get; set;}
        List<SearchField> SearchFieldCheckBoxCol { get; set;}
        List<SearchField> SearchFieldHiddenValue { set;}
        List<SearchField> InitCheckedBoxCol { set;}
        string SearchFieldColShowCookie { get;}
        event GetSearchFieldObject GetSearchFieldObjectdelegate;
    }
}
