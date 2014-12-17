using System;
using System.Collections.Generic;
using System.Web.UI;
using AdvancedCondition;
using SEP.HRMIS.Model.AdvanceSearch;
using SEP.HRMIS.Presenter.IPresenter.IAdvanceSearch;
using SEP.Presenter.Core;
using ModelAdvanceSearch = SEP.HRMIS.Model.AdvanceSearch;

namespace SEP.Performance.Views.HRMIS.AdvanceSearch
{
    public partial class ContractAdvanceSearchList : UserControl, IContractAdvanceSearchListView
    {
        public List<SearchField> SearchFieldConditionSource
        {
            get { return SetSearchConditionView1.SearchFieldConditionSource; }
            set
            {
                SetSearchConditionView1.SearchFieldConditionSource = value;
            }
        }

        public List<SearchField> SearchFieldCheckBoxCol
        {
            get { return SetColumnListView1.SearchFieldCheckBoxCol; }
            set
            {
                SetColumnListView1.SearchFieldCheckBoxCol = value;
            }
        }

        public List<SearchField> InitCheckedBoxCol
        {
            set
            {
                SetColumnListView1.InitCheckedBoxCol = value;
            }
        }

        public List<SearchField> SearchFieldHiddenValue
        {
            set
            {
                string strhiddenColName = "\"\"";
                string strhiddenColTemplates = "\"\"";
                for (int i = 0; i < value.Count; i++)
                {
                    strhiddenColName += ",\"" + value[i].FieldParaBase.FieldName + "\"";
                    strhiddenColTemplates += ",\"#" + value[i].FieldParaBase.FieldKey + "#\"";
                }
                hiddenColName.Text = strhiddenColName;
                hiddenColTemplates.Text = strhiddenColTemplates;
            }
        }

        public List<SearchField> SearchFieldSourceCookie
        {
            get
            {
                List<SearchField> SearchFieldSource = new List<SearchField>();
                if (Session["AdvanceSearchContractCondition"] != null)
                {
                    SearchFieldSource =
                        ModelAdvanceSearch.Utility.ConvertStringToSearchFieldList(
                            Session["AdvanceSearchContractCondition"].ToString(),
                            ContractFieldPara.GetAllContractSearchField());
                }
                return SearchFieldSource;
            }
        }

        public string SearchFieldColShowCookie
        {
            get
            {
                if (Session["AdvanceSearchContractColShow"] != null)
                {
                    return Session["AdvanceSearchContractColShow"].ToString();
                }
                return "";
            }
        }

        public event GetSearchFieldObject GetSearchFieldObjectdelegate;

        protected void Page_Load(object sender, EventArgs e)
        {
            SetSearchConditionView1.GetSearchFieldObjectdelegate += GetSearchFieldObjectdelegate;
        }

    }
}