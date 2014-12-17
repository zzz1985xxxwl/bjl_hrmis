using System.Collections.Generic;
using AdvancedCondition;
using SEP.HRMIS.Model.AdvanceSearch;
using SEP.HRMIS.Presenter.IPresenter.IAdvanceSearch;

namespace SEP.HRMIS.Presenter.AdvanceSearch
{
    public class EmployeeAdvancedSearchListPresenter
    {
        private readonly IEmployeeAdvanceSearchListView _IEmployeeAdvanceSearchListView;
        public EmployeeAdvancedSearchListPresenter(IEmployeeAdvanceSearchListView iEmployeeAdvanceSearchListView)
        {
            _IEmployeeAdvanceSearchListView = iEmployeeAdvanceSearchListView;
            Attachment();
        }

        #region 事件绑定
        public void Attachment()
        {
            _IEmployeeAdvanceSearchListView.GetSearchFieldObjectdelegate += GetSearchFieldObjectEvent;
        }


        private static SearchField GetSearchFieldObjectEvent(string fieldName)
        {
            SearchField retSearchField =
                SearchField.GetFieldParaByFieldName(EmployeeFieldPara.GetAllEmployeeSearchField(), fieldName);
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
                List<SearchField> SearchFieldList = _IEmployeeAdvanceSearchListView.SearchFieldSourceCookie;
                if (SearchFieldList.Count == 0)
                {
                    SearchFieldList = EmployeeFieldPara.InitialConditionList();
                }
                SearchFieldList.Add(SearchField.InitField_Null());
                _IEmployeeAdvanceSearchListView.SearchFieldConditionSource = SearchFieldList;
                _IEmployeeAdvanceSearchListView.SearchFieldHiddenValue = EmployeeFieldPara.GetAllEmployeeSearchField();

                List<SearchField> colshowlist = new List<SearchField>();
                if (!string.IsNullOrEmpty(_IEmployeeAdvanceSearchListView.SearchFieldColShowCookie))
                {
                    string[] colshowcookies = _IEmployeeAdvanceSearchListView.SearchFieldColShowCookie.Split('|');
                    foreach (string colindex in colshowcookies)
                    {
                        int temp;
                        if (!string.IsNullOrEmpty(colindex) && int.TryParse(colindex, out temp))
                        {
                            colshowlist.Add(EmployeeFieldPara.GetAllEmployeeSearchField()[temp]);
                        }
                    }
                    _IEmployeeAdvanceSearchListView.InitCheckedBoxCol = colshowlist;
                }
                if (colshowlist.Count == 0)
                {
                    _IEmployeeAdvanceSearchListView.InitCheckedBoxCol = EmployeeFieldPara.InitialColList();
                }
                _IEmployeeAdvanceSearchListView.SearchFieldCheckBoxCol = EmployeeFieldPara.GetAllEmployeeSearchField();
            }
        }

        #endregion

    }
}
