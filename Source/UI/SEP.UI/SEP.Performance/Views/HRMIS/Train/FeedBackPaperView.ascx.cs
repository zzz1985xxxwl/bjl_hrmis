using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;
using SEP.HRMIS.Presenter.IPresenter.ITrain;

namespace SEP.Performance.Views.HRMIS.Train
{
    public partial class FeedBackPaperView : UserControl, IFeedBackPaperView
    {
        private List<TrainFBQuestion> _AssessItems;

        private void SetgvAssessPaperItemListColumnFalse(bool value)
        {
            for (int i = 0; i < gvFeedBackPaperItemList.Rows.Count; i++)
            {

                DropDownList ddlAssessItem =
                    (DropDownList)gvFeedBackPaperItemList.Rows[i].FindControl("ddlFBQuestion");
                if (ddlAssessItem != null)
                {
                    ddlAssessItem.Enabled = !value;
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

        protected void gvFeedBackPaperList_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void ddlFBQuestion_Changed(object sender, EventArgs e)
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
            if (row.RowIndex + 1 == QuestionList.Count)
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

        protected void lbDownItem_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbDownItem = sender as LinkButton;
            if (lbDownItem == null)
            {
                return;
            }
            GridViewRow row = lbDownItem.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            if (ddlAssessItemChangedForDownEvent != null)
            {
                ddlAssessItemChangedForDownEvent(row.RowIndex.ToString());
            }
        }

        protected void lbUpItem_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbUpItem = sender as LinkButton;
            if (lbUpItem == null)
            {
                return;
            }
            GridViewRow row = lbUpItem.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            if (ddlAssessItemChangedForUpEvent != null)
            {
                ddlAssessItemChangedForUpEvent(row.RowIndex.ToString());
            }
        }

        #region AssessItemList 内部方法

        private void SetGridViewDisplay(List<TrainFBQuestion> assessItemList)
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
            LinkButton lbAddItem = (LinkButton)gvFeedBackPaperItemList.Rows[rowIndex].FindControl("lbAddItem");
            if (lbAddItem != null)
            {
                lbAddItem.Text = "<img src=../../image/file_new.gif border=0>";
            }
            LinkButton lbDeleteItem = (LinkButton)gvFeedBackPaperItemList.Rows[rowIndex].FindControl("lbDeleteItem");
            if (lbDeleteItem != null)
            {
                lbDeleteItem.Text = "<img src=../../image/file_cancel.gif border=0>";
            }
            LinkButton lbUpItem = (LinkButton)gvFeedBackPaperItemList.Rows[rowIndex].FindControl("lbUpItem");
            if (lbUpItem != null)
            {
                lbUpItem.Text = "<img src=../../image/Up_icon.gif border=0>";
            }
            LinkButton lbDownItem = (LinkButton)gvFeedBackPaperItemList.Rows[rowIndex].FindControl("lbDownItem");
            if (lbDownItem != null)
            {
                lbDownItem.Text = "<img src=../../image/Down_icon.gif border=0>";
            }
        }

        private void SetGridViewRowddlAccountSetParaDisplay(int rowIndex, List<TrainFBQuestion> assessItemList)
        {
            DropDownList ddlAssessItem =
                (DropDownList)gvFeedBackPaperItemList.Rows[rowIndex].FindControl("ddlFBQuestion");
            if (ddlAssessItem == null)
            {
                return;
            }

            List<TrainFBQuestion> accountSetPara = new List<TrainFBQuestion>();
            foreach (TrainFBQuestion para in _AssessItems)
            {
                accountSetPara.Add(para);
            }
            if (assessItemList[rowIndex].FBQuestioniD == -1)
            {
                accountSetPara.Add(new TrainFBQuestion(-1, "",new TrainFBQuesType(-1,""),new List<TrainFBItem>()));
            }
            ddlAssessItem.DataSource = accountSetPara;
            ddlAssessItem.DataValueField = "FBQuestioniD";
            ddlAssessItem.DataTextField = "Description";
            ddlAssessItem.DataBind();
            ddlAssessItem.SelectedValue = assessItemList[rowIndex].FBQuestioniD.ToString();
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
                tbMessage.Style["display"] = String.IsNullOrEmpty(value) ? "none" : "block";
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

        public List<TrainFBQuestion> QuestionList
        {
            get
            {
                List<TrainFBQuestion> assessItemList = (List<TrainFBQuestion>)ViewState["_TrainFBQuestionList"];
                return assessItemList;
            }
            set
            {
                ViewState["_TrainFBQuestionList"] = value;
                Session["AccountSetItemListForCheck"] = value;
                gvFeedBackPaperItemList.DataSource = value;
                gvFeedBackPaperItemList.DataBind();

                if (value == null || value.Count == 0)
                {
                    divFeedBackPaperItem.Style["display"] = "none";
                }
                else
                {
                    divFeedBackPaperItem.Style["display"] = "block";
                    if (_AssessItems != null && _AssessItems.Count > 0)
                    {
                        SetGridViewDisplay(value);
                    }
                }
            }
        }
        public List<TrainFBQuestion> QuestionItems
        {
            set
            {
                _AssessItems = value;
            }
        }

        public FeedBackPaper SessionCopyPaper
        {
            get { return Session["CopyFeedBackPaper"] as FeedBackPaper; }
            set
            {
                if (value != null)
                {
                    Session["CopyFeedBackPaper"] = value;
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
                gvFeedBackPaperItemList.Columns[3].Visible = !value;
                gvFeedBackPaperItemList.Columns[4].Visible = !value;
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
    }
}