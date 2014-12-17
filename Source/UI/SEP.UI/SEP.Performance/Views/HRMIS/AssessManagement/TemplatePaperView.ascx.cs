using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.AssessManagement;
using SEP.Model.Positions;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.AssessManagement
{
    public partial class TemplatePaperView : UserControl, ITemplatePaperView
    {
        #region 年终绩效考核绑定职位

        protected void Page_Load(object sender, EventArgs e)
        {
            new ChosePositionPresenter(ChosePositionView1);
            ChosePositionView1.AttachAccountAjax += ChosePositionAjax;
        }

        private void ChosePositionAjax(object sender, EventArgs e)
        {
            txtPosition.Text = GetEmployeeNames(ChosePositionView1.PositionRight);
            mpeChoosePosition.Show();
        }

        private static string GetEmployeeNames(IList<Position> positionList)
        {
            StringBuilder employees = new StringBuilder();
            if (positionList != null)
            {
                int count = positionList.Count;
                for (int i = 0; i < count; i++)
                {
                    employees.Append(positionList[i].Name);
                    if (i < count - 1)
                    {
                        employees.Append("，");
                    }
                }
            }
            return employees.ToString();
        }

        public List<Position> PositionList
        {
            get { return ChosePositionView1.PositionRight; }
            set
            {
                ChosePositionView1.PositionRight = value;
                txtPosition.Text = GetEmployeeNames(value);
            }
        }

        #endregion

        private List<AssessTemplateItem> _AssessItems;

        private void SetgvAssessPaperItemListColumnFalse(bool value)
        {
            for (int i = 0; i < gvAssessPaperItemList.Rows.Count; i++)
            {
                DropDownList ddlAssessItem =
                    (DropDownList) gvAssessPaperItemList.Rows[i].FindControl("ddlAssessItem");
                TextBox weight =
                    (TextBox) gvAssessPaperItemList.Rows[i].FindControl("txtWeight");
                if (ddlAssessItem != null)
                {
                    ddlAssessItem.Enabled = !value;
                }
                if (weight != null)
                {
                    weight.Enabled = !value;
                }
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (ActionButtonEvent != null)
                ActionButtonEvent();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (CancelButtonEvent != null)
                CancelButtonEvent();
        }

        protected void btnCopy_Click(object sender, EventArgs e)
        {
            if (btnCopyEvent != null)
            {
                btnCopyEvent();
            }
        }

        protected void btnPaste_Click(object sender, EventArgs e)
        {
            if (btnPasteEvent != null)
            {
                btnPasteEvent();
            }
        }

        protected void gvAssessPaperItemList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }

        /// <summary>
        /// 每行下拉框选择
        /// </summary>
        protected void ddlAssessItem_Changed(object sender, EventArgs e)
        {
            DropDownList ddlAssessItem = sender as DropDownList;
            if (ddlAssessItem == null)
            {
                return;
            }
            GridViewRow row = ddlAssessItem.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            if (row.RowIndex + 1 == AssessItemList.Count)
            {
                if (ddlAssessItemChangedForAddEvent != null)
                {
                    ddlAssessItemChangedForAddEvent(ddlAssessItem.SelectedValue);
                }
            }
            else
            {
                if (ddlAssessItemChangedForUpdateEvent != null)
                {
                    ddlAssessItemChangedForUpdateEvent(row.RowIndex.ToString(), ddlAssessItem.SelectedValue);
                }
            }
        }

        protected void lbDeleteItem_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbDeleteItem = sender as LinkButton;
            if (lbDeleteItem == null)
            {
                return;
            }
            GridViewRow row = lbDeleteItem.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            if (ddlAssessItemChangedForDeleteEvent != null)
            {
                ddlAssessItemChangedForDeleteEvent(row.RowIndex.ToString());
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
            if (ddlAssessItemChangedForAddEvent != null)
            {
                ddlAssessItemChangedForAddAtEvent(row.RowIndex.ToString());
            }
        }

        //protected void lbDownItem_Command(object sender, CommandEventArgs e)
        //{
        //    LinkButton lbDownItem = sender as LinkButton;
        //    if (lbDownItem == null)
        //    {
        //        return;
        //    }
        //    GridViewRow row = lbDownItem.NamingContainer as GridViewRow;
        //    if (row == null)
        //    {
        //        return;
        //    }
        //    if (ddlAssessItemChangedForDownEvent != null)
        //    {
        //        ddlAssessItemChangedForDownEvent(row.RowIndex.ToString());
        //    }
        //}

        //protected void lbUpItem_Command(object sender, CommandEventArgs e)
        //{
        //    LinkButton lbUpItem = sender as LinkButton;
        //    if (lbUpItem == null)
        //    {
        //        return;
        //    }
        //    GridViewRow row = lbUpItem.NamingContainer as GridViewRow;
        //    if (row == null)
        //    {
        //        return;
        //    }
        //    if (ddlAssessItemChangedForUpEvent != null)
        //    {
        //        ddlAssessItemChangedForUpEvent(row.RowIndex.ToString());
        //    }
        //}

        #region AssessItemList 内部方法

        private void SetGridViewDisplay(List<AssessTemplateItem> assessItemList)
        {
            for (int i = 0; i < assessItemList.Count; i++)
            {
                SetGridViewRowddlAccountSetParaDisplay(i, assessItemList);
                if (i < assessItemList.Count - 1)
                {
                    SetGridViewRowLinkButtonDisplay(i, assessItemList.Count);
                }
            }
        }

        private void SetGridViewRowLinkButtonDisplay(int rowIndex, int count)
        {
            LinkButton lbAddItem = (LinkButton) gvAssessPaperItemList.Rows[rowIndex].FindControl("lbAddItem");
            if (lbAddItem != null)
            {
                lbAddItem.Text = "<img src=../../image/file_new.gif border=0>";
            }
            LinkButton lbDeleteItem = (LinkButton) gvAssessPaperItemList.Rows[rowIndex].FindControl("lbDeleteItem");
            if (lbDeleteItem != null)
            {
                lbDeleteItem.Text = "<img src=../../image/file_cancel.gif border=0>";
            }
            LinkButton lbUpItem = (LinkButton) gvAssessPaperItemList.Rows[rowIndex].FindControl("lbUpItem");
            if (lbUpItem != null)
            {
                lbUpItem.Text = "<img src=../../image/Up_icon.gif border=0>";
            }
            LinkButton lbDownItem = (LinkButton) gvAssessPaperItemList.Rows[rowIndex].FindControl("lbDownItem");
            if (lbDownItem != null)
            {
                lbDownItem.Text = "<img src=../../image/Down_icon.gif border=0>";
            }
        }

        private void SetGridViewRowddlAccountSetParaDisplay(int rowIndex, List<AssessTemplateItem> assessItemList)
        {
            DropDownList ddlAssessItem =
                (DropDownList) gvAssessPaperItemList.Rows[rowIndex].FindControl("ddlAssessItem");
            if (ddlAssessItem == null)
            {
                return;
            }

            List<AssessTemplateItem> accountSetPara = new List<AssessTemplateItem>();
            foreach (AssessTemplateItem para in _AssessItems)
            {
                accountSetPara.Add(para);
            }
            if (assessItemList[rowIndex].AssessTemplateItemID == -1)
            {
                accountSetPara.Add(new AssessTemplateItem(-1, "", OperateType.NotHR));
            }
            ddlAssessItem.DataSource = accountSetPara;
            ddlAssessItem.DataValueField = "AssessTemplateItemID";
            ddlAssessItem.DataTextField = "Question";
            ddlAssessItem.DataBind();
            ddlAssessItem.SelectedValue = assessItemList[rowIndex].AssessTemplateItemID.ToString();
        }

        #endregion

        #region ITemplatePaperView 成员

        public string ResultMessage
        {
            get { return lblResultMessage.Text; }
            set
            {
                if (lblResultMessage != null)
                {
                    lblResultMessage.Text = value;
                }
                if (String.IsNullOrEmpty(value))
                {
                    tbMessage.Style["display"] = "none";
                }
                else
                {
                    tbMessage.Style["display"] = "block";
                }
            }
        }

        public string ValidatePaperName
        {
            set { lblValidateName.Text = value; }
            get { return lblValidateName.Text; }
        }

        public string TemplatePaperName
        {
            set { txtPaperName.Text = value; }
            get { return txtPaperName.Text.Trim(); }
        }

        public string OperationInfo
        {
            set { lblOperationInfo.Text = value; }
            get { return lblOperationInfo.Text; }
        }

        public string OperationType
        {
            get { return lblOperation.Value; }
            set { lblOperation.Value = value; }
        }

        private bool actionSuccess;

        public bool ActionSuccess
        {
            get { return actionSuccess; }
            set { actionSuccess = value; }
        }

        public List<AssessTemplateItem> AssessItemList
        {
            get
            {
                List<AssessTemplateItem> assessItemList = (List<AssessTemplateItem>) ViewState["_AssessItemList"];
                for (int i = 0; i < assessItemList.Count; i++)
                {
                    TextBox txtWeight =
                        (TextBox) gvAssessPaperItemList.Rows[i].FindControl("txtWeight");
                    string weight = txtWeight.Text.Trim();
                    assessItemList[i].WeightString = weight;
                    decimal temp;
                    if (Decimal.TryParse(weight, out temp))
                    {
                        assessItemList[i].Weight = temp;
                    }
                }
                return assessItemList;
            }
            set
            {
                ViewState["_AssessItemList"] = value;
                Session["AccountSetItemListForCheck"] = value;
                gvAssessPaperItemList.DataSource = value;
                gvAssessPaperItemList.DataBind();

                if (value == null || value.Count == 0)
                {
                    divAssessPaperItem.Style["display"] = "none";
                }
                else
                {
                    divAssessPaperItem.Style["display"] = "block";
                    if (_AssessItems != null && _AssessItems.Count > 0)
                    {
                        SetGridViewDisplay(value);
                    }
                }
            }
        }

        public List<AssessTemplateItem> AssessItems
        {
            set { _AssessItems = value; }
        }

        public AssessTemplatePaper SessionCopyPaper
        {
            get { return Session[SessionKeys.SESSIONCOPYPAPER] as AssessTemplatePaper; }
            set
            {
                if (value != null)
                {
                    Session[SessionKeys.SESSIONCOPYPAPER] = value;
                    if (OperationType == "Add" || OperationType == "Update")
                    {
                        SetbtnPasteVisible = SessionCopyPaper != null;
                    }
                }
            }
        }

        public bool SetbtnPasteVisible
        {
            set { btnPaste.Visible = value; }
        }


        public bool SetFormReadOnly
        {
            set
            {
                txtPaperName.ReadOnly = value;
                txtPosition.Enabled = !value;
                gvAssessPaperItemList.Columns[7].Visible = !value;
                gvAssessPaperItemList.Columns[8].Visible = !value;
                SetgvAssessPaperItemListColumnFalse(value);
                btnPaste.Visible = !value;
            }
        }


        public event DelegateNoParameter ActionButtonEvent;

        public event DelegateNoParameter CancelButtonEvent;

        public event DelegateID ddlAssessItemChangedForAddEvent;

        public event Delegate2Parameter ddlAssessItemChangedForUpdateEvent;

        public event DelegateID ddlAssessItemChangedForDeleteEvent;

        public event DelegateID ddlAssessItemChangedForAddAtEvent;

        public event DelegateID ddlAssessItemChangedForUpEvent;

        public event DelegateID ddlAssessItemChangedForDownEvent;

        public event DelegateNoParameter btnCopyEvent;

        public event DelegateNoParameter btnPasteEvent;

        #endregion

        public static string AssessTemplateItemTypeToString(AssessTemplateItemType type)
        {
            switch (type)
            {
                case AssessTemplateItemType.ALL:
                    return "";
                case AssessTemplateItemType.Open:
                    return "开放项";
                case AssessTemplateItemType.Option:
                    return "选择项";
                case AssessTemplateItemType.Score:
                    return "打分项";
                case AssessTemplateItemType.Formula:
                    return "公式项";
                default:
                    return "";
            }
        }

       

        public static bool ConvertToBoolIsHr(OperateType type)
        {
            return type == OperateType.HR;
        }
    }
}