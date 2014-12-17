using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancedCondition;
using AdvancedCondition.Enums;
using SEP.Presenter.Core;

namespace SEP.Performance.Views
{
    public partial class SetSearchConditionView : UserControl
    {
        protected void gvSearchConditionList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }

        protected void lbAddItem_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbAddItem = sender as LinkButton;
            if (lbAddItem == null)
            {
                return;
            }
            GridViewRow row = lbAddItem.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            List<SearchField> searchFieldConditionSource = SearchFieldConditionSource;
            searchFieldConditionSource.Insert(row.RowIndex, SearchField.InitField_Null());
            SearchFieldConditionSource = searchFieldConditionSource;
        }

        protected void lbDeleteItem_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbAddItem = sender as LinkButton;
            if (lbAddItem == null)
            {
                return;
            }
            GridViewRow row = lbAddItem.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            List<SearchField> searchFieldConditionSource = SearchFieldConditionSource;
            searchFieldConditionSource.RemoveAt(row.RowIndex);
            SearchFieldConditionSource = searchFieldConditionSource;

        }

        protected void txtSearchField_TextChanged(object sender, EventArgs e)
        {
            TextBox txtSearchField = sender as TextBox;
            if (txtSearchField == null)
            {
                return;
            }
            GridViewRow row = txtSearchField.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            List<SearchField> searchFieldConditionSource = SearchFieldConditionSource;
            searchFieldConditionSource[row.RowIndex] = GetSearchFieldObjectdelegate(txtSearchField.Text.Trim()); ;
            if (row.RowIndex == searchFieldConditionSource.Count - 1
                && searchFieldConditionSource[searchFieldConditionSource.Count - 1].FieldParaBase.Id != -1)
            {
                searchFieldConditionSource.Add(SearchField.InitField_Null());
            }
            SearchFieldConditionSource = searchFieldConditionSource;
        }

        protected void btntxtSearchFieldChange_Click(object sender, EventArgs e)
        {
            Button ButtonProduct = sender as Button;
            if (ButtonProduct == null)
            {
                return;
            }
            GridViewRow row = ButtonProduct.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            TextBox txtSearchField = (TextBox)gvSearchConditionList.Rows[row.RowIndex].FindControl("txtSearchField");
            if (txtSearchField == null)
            {
                return;
            }
            List<SearchField> searchFieldConditionSource = SearchFieldConditionSource;
            searchFieldConditionSource[row.RowIndex] = GetSearchFieldObjectdelegate(txtSearchField.Text.Trim());
            if (row.RowIndex == searchFieldConditionSource.Count - 1
                && searchFieldConditionSource[searchFieldConditionSource.Count - 1].FieldParaBase.Id != -1)
            {
                searchFieldConditionSource.Add(SearchField.InitField_Null());
            }
            SearchFieldConditionSource = searchFieldConditionSource;
        }

        #region SearchFieldSource get set 内部方法
        private List<SearchField> GetGridViewValue()
        {
            List<SearchField> retSearchFieldList = new List<SearchField>();
            for (int i = 0; i < gvSearchConditionList.Rows.Count; i++)
            {
                TextBox txtSearchField =
                    (TextBox)gvSearchConditionList.Rows[i].FindControl("txtSearchField");
                if (txtSearchField == null)
                {
                    continue;
                }
                DropDownList ddlCompareType =
                    (DropDownList)gvSearchConditionList.Rows[i].FindControl("ddlCompareType");
                if (ddlCompareType == null)
                {
                    continue;
                }
                DropDownList ddlCollectedType =
                    (DropDownList)gvSearchConditionList.Rows[i].FindControl("ddlCollectedType");
                if (ddlCollectedType == null)
                {
                    continue;
                }
                TextBox txtExpression =
                    (TextBox)gvSearchConditionList.Rows[i].FindControl("txtExpression");
                if (txtExpression == null)
                {
                    continue;
                }
                CheckBox cbIsInvert =
                    (CheckBox)gvSearchConditionList.Rows[i].FindControl("cbIsInvert");
                if (cbIsInvert == null)
                {
                    continue;
                }
                SearchField searchField = GetSearchFieldObjectdelegate(txtSearchField.Text.Trim());
                if (searchField == null)
                {
                    searchField = SearchField.InitField_Null();
                }
                searchField.ConditionField.EnumCollectedType = (EnumCollectedType)Convert.ToInt32(ddlCollectedType.SelectedValue);
                searchField.ConditionField.EnumCompareType = (EnumCompareType)Convert.ToInt32(ddlCompareType.SelectedValue);
                searchField.ConditionField.ConditionExpression = txtExpression.Text.Trim();
                searchField.ConditionField.IsInvert = cbIsInvert.Checked;

                retSearchFieldList.Add(searchField);
            }
            return retSearchFieldList;
        }

        private void SetGridViewDisplay(List<SearchField> searchFieldList)
        {
            for (int i = 0; i < searchFieldList.Count; i++)
            {
                SetGridViewRowddlDisplay(i, searchFieldList[i]);
                SetGridViewRowtxtDisplay(i, searchFieldList[i]);
                if (i < searchFieldList.Count - 1)
                {
                    SetGridViewRowLinkButtonDisplay(i);
                }
            }
        }

        private void SetGridViewRowtxtDisplay(int rowIndex, SearchField searchField)
        {
            TextBox txtExpression =
                (TextBox) gvSearchConditionList.Rows[rowIndex].FindControl("txtExpression");
            if (txtExpression == null)
            {
                return;
            }
            txtExpression.CssClass += " FieldParaBaseId" + searchField.FieldParaBase.Id;
        }

        private void SetGridViewRowddlDisplay(int rowIndex, SearchField searchField)
        {
            DropDownList ddlCompareType =
                (DropDownList)gvSearchConditionList.Rows[rowIndex].FindControl("ddlCompareType");
            if (ddlCompareType == null)
            {
                return;
            }
            ddlCompareType.Items.Clear();
            foreach (EnumCompareType enumCompareTypeItem in searchField.ConditionField.EnumCompareTypeSource)
            {
                ListItem item =
                    new ListItem(Utility.GetEnumCompareTypeName(enumCompareTypeItem),
                                 ((int)enumCompareTypeItem).ToString(), true);
                ddlCompareType.Items.Add(item);
            }
            ddlCompareType.SelectedValue = ((int)searchField.ConditionField.EnumCompareType).ToString();

            DropDownList ddlCollectedType =
                (DropDownList)gvSearchConditionList.Rows[rowIndex].FindControl("ddlCollectedType");
            if (ddlCollectedType == null)
            {
                return;
            }
            ddlCollectedType.Items.Clear();
            foreach (EnumCollectedType enumCollectedTypeItem in searchField.ConditionField.EnumCollectedTypeSource)
            {
                ListItem item =
                    new ListItem(Utility.GetEnumCollectedTypeName(enumCollectedTypeItem),
                                 ((int)enumCollectedTypeItem).ToString(), true);
                ddlCollectedType.Items.Add(item);
            }
            ddlCollectedType.SelectedValue = ((int)searchField.ConditionField.EnumCollectedType).ToString();
        }

        private void SetGridViewRowLinkButtonDisplay(int rowIndex)
        {
            LinkButton lbAddItem = (LinkButton)gvSearchConditionList.Rows[rowIndex].FindControl("lbAddItem");
            if (lbAddItem != null)
            {
                lbAddItem.Text = "<img src=../../image/file_new.gif border=0>";
            }
            LinkButton lbDeleteItem = (LinkButton)gvSearchConditionList.Rows[rowIndex].FindControl("lbDeleteItem");
            if (lbDeleteItem != null)
            {
                lbDeleteItem.Text = "<img src=../../image/file_cancel.gif border=0>";
            }
        }
        #endregion

        public List<SearchField> SearchFieldConditionSource
        {
            get
            {
                return GetGridViewValue();
            }
            set
            {
                gvSearchConditionList.DataSource = value;
                gvSearchConditionList.DataBind();
                if (value == null || value.Count == 0)
                {
                    tbSearchConditionList.Style["display"] = "none";
                }
                else
                {
                    tbSearchConditionList.Style["display"] = "";
                    SetGridViewDisplay(value);
                }
            }
        }
        public GetSearchFieldObject GetSearchFieldObjectdelegate;
    }
}