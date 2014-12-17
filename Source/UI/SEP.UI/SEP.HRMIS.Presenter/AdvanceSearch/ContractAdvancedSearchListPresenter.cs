using System.Collections.Generic;
using AdvancedCondition;
using SEP.HRMIS.Model.AdvanceSearch;
using SEP.HRMIS.Presenter.IPresenter.IAdvanceSearch;

namespace SEP.HRMIS.Presenter.AdvanceSearch
{
    public class ContractAdvancedSearchListPresenter
    {
        private readonly IContractAdvanceSearchListView _IContractAdvanceSearchListView;
        public ContractAdvancedSearchListPresenter(IContractAdvanceSearchListView iContractAdvanceSearchListView)
        {
            _IContractAdvanceSearchListView = iContractAdvanceSearchListView;
            Attachment();
        }

        #region 事件绑定
        public void Attachment()
        {
            _IContractAdvanceSearchListView.GetSearchFieldObjectdelegate += GetSearchFieldObjectEvent;
        }


        private static SearchField GetSearchFieldObjectEvent(string fieldName)
        {
            SearchField retSearchField =
                SearchField.GetFieldParaByFieldName(ContractFieldPara.GetAllContractSearchField(), fieldName);
            if (retSearchField == null)
            {
                return SearchField.InitField_Null();
            }
            return retSearchField;
        }

        #endregion

        #region 初始化界面
        public void InitView(bool isPostBack)
        {
            InitSearchConditionView(isPostBack);
        }


        public void InitSearchConditionView(bool isPostBack)
        {
            if (!isPostBack)
            {
                List<SearchField> SearchFieldList = _IContractAdvanceSearchListView.SearchFieldSourceCookie;
                if (SearchFieldList.Count == 0)
                {
                    SearchFieldList = ContractFieldPara.InitialConditionList();
                }
                SearchFieldList.Add(SearchField.InitField_Null());
                _IContractAdvanceSearchListView.SearchFieldConditionSource = SearchFieldList;
                _IContractAdvanceSearchListView.SearchFieldHiddenValue = ContractFieldPara.GetAllContractSearchField();

                List<SearchField> colshowlist = new List<SearchField>();
                if (!string.IsNullOrEmpty(_IContractAdvanceSearchListView.SearchFieldColShowCookie))
                {
                    string[] colshowcookies = _IContractAdvanceSearchListView.SearchFieldColShowCookie.Split('|');
                    foreach (string colindex in colshowcookies)
                    {
                        int temp;
                        if (!string.IsNullOrEmpty(colindex) && int.TryParse(colindex, out temp))
                        {
                            colshowlist.Add(ContractFieldPara.GetAllContractSearchField()[temp]);
                        }
                    }
                    _IContractAdvanceSearchListView.InitCheckedBoxCol = colshowlist;
                }
                if (colshowlist.Count == 0)
                {
                    _IContractAdvanceSearchListView.InitCheckedBoxCol = ContractFieldPara.InitialColList();
                }
                _IContractAdvanceSearchListView.SearchFieldCheckBoxCol = ContractFieldPara.GetAllContractSearchField();
            }
        }
        #endregion
    }
}
