using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using SEP.Presenter;
using SEP.Model.Positions;
using SEP.Presenter.IPresenter.IPositions;

namespace SEP.Performance.Views.SEP.Positions
{
    public partial class PositionGradeView : UserControl, IPositionGradeView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (ActionButtonEvent != null)
                ActionButtonEvent();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DelPositionGradeId = null;

            if (CancelButtonEvent != null)
                CancelButtonEvent();
        }

        public event DelegateNoParameter ActionButtonEvent;
        public event DelegateNoParameter CancelButtonEvent;
        public event DelegateID ddlCardPropertyParaParaChangedForDeleteEvent;
        public event DelegateID ddlCardPropertyParaParaChangedForAddAtEvent;
        public event DelegateID ddlCardPropertyParaParaChangedForUpEvent;
        public event DelegateID ddlCardPropertyParaParaChangedForDownEvent;
        public event DlgLinkButtonAndId InitEvent;

        public string Message
        {
            set
            {
                lblMessage.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    tbMessage.Visible = false;
                }
                else
                {
                    tbMessage.Visible = true;
                }
            }
            get { return lblMessage.Text; }

        }


        public string OperationTitle
        {
            get { return lblOperationTitle.Text.Trim(); }
            set { lblOperationTitle.Text = value; }
        }

        public bool SetFormReadOnly
        {
            set
            {
                dgPositionGradeList.Columns[2].Visible = !value;
                dgPositionGradeList.Columns[3].Visible = !value;
                dgPositionGradeList.Columns[4].Visible = !value;
                dgPositionGradeList.Columns[5].Visible = !value;
                SetEmunListColumnFalse(value);
            }
        }

        private void SetEmunListColumnFalse(bool value)
        {
            for (int i = 0; i < dgPositionGradeList.Rows.Count; i++)
            {
                TextBox txtPositionGrade =
                    (TextBox)dgPositionGradeList.Rows[i].FindControl("txtName");
                TextBox txtDescription = (TextBox)dgPositionGradeList.Rows[i].FindControl("txtDescription");
                if (txtPositionGrade != null && txtDescription!=null)
                {
                    txtPositionGrade.ReadOnly = value;
                    txtDescription.ReadOnly = value;
                }
            }
        }

        public List<PositionGrade> PositionGradeListSrc
        {
            get
            {
                List<PositionGrade> positionGradeListSrc =
                    (List<PositionGrade>)ViewState["PositionGradeList"];
                GetGridViewValue(positionGradeListSrc);
                return positionGradeListSrc;
            }
            set
            {
                List<PositionGrade> positionGradeListSrc = value;
                dgPositionGradeList.DataSource = value;
                dgPositionGradeList.DataBind();

                if (value != null && value.Count != 0)
                {
                    SetGridViewDisplay(positionGradeListSrc);
                }
                ViewState["PositionGradeList"] = positionGradeListSrc;
            }
        }

        #region EmunList 内部方法
        private void GetGridViewValue(List<PositionGrade> positionGradeListSrc)
        {
            for (int i = 0; i < positionGradeListSrc.Count; i++)
            {
                TextBox txtPositionGradeName =
                    (TextBox)dgPositionGradeList.Rows[i].FindControl("txtName");
                TextBox txtDescription = (TextBox)dgPositionGradeList.Rows[i].FindControl("txtDescription");
                if (txtPositionGradeName != null && txtDescription!=null)
                {
                    positionGradeListSrc[i].Name = txtPositionGradeName.Text.Trim();
                    positionGradeListSrc[i].Description = txtDescription.Text.Trim();
                }
            }
        }

        private void SetGridViewDisplay(List<PositionGrade> positionGradeListSrc)
        {
            for (int i = 0; i < positionGradeListSrc.Count; i++)
            {
                SetGridViewRowtxtEmunNameDisplay(i, positionGradeListSrc[i]);
                SetGridViewRowLinkButtonDisplay(i);
                SetGridViewRowLinkButtonReadOnlyDisplay(i, positionGradeListSrc[i]);
            }
        }

        private void SetGridViewRowtxtEmunNameDisplay
            (int rowIndex, PositionGrade positionGrade)
        {
            TextBox txtName = (TextBox)dgPositionGradeList.Rows[rowIndex].FindControl("txtName");
            TextBox txtDescription = (TextBox)dgPositionGradeList.Rows[rowIndex].FindControl("txtDescription");
            if (txtName == null || txtDescription==null)
            {
                return;
            }
            txtName.Text = positionGrade.Name;
            txtDescription.Text = positionGrade.Description;
            txtDescription.Style["display"] = txtName.Style["display"] = "block";
        }

        private void SetGridViewRowLinkButtonDisplay(int rowIndex)
        {
            LinkButton lbAddItem = (LinkButton)dgPositionGradeList.Rows[rowIndex].FindControl("lbAddItem");
            if (lbAddItem != null)
            {
                lbAddItem.Text = "<img src=../../image/file_new.gif border=0>";
            }
            LinkButton lbDeleteItem = (LinkButton)dgPositionGradeList.Rows[rowIndex].FindControl("lbDeleteItem");
            if (lbDeleteItem != null)
            {
                lbDeleteItem.Text = "<img src=../../image/file_cancel.gif border=0>";
            }
            LinkButton lbUpItem = (LinkButton)dgPositionGradeList.Rows[rowIndex].FindControl("lbUpItem");
            if (lbUpItem != null)
            {
                lbUpItem.Text = "<img src=../../image/Up_icon.gif border=0>";
            }
            LinkButton lbDownItem = (LinkButton)dgPositionGradeList.Rows[rowIndex].FindControl("lbDownItem");
            if (lbDownItem != null)
            {
                lbDownItem.Text = "<img src=../../image/Down_icon.gif border=0>";
            }
        }

        private void SetGridViewRowLinkButtonReadOnlyDisplay(int rowIndex, PositionGrade positionGrade)
        {
            LinkButton lbDeleteItem = (LinkButton)dgPositionGradeList.Rows[rowIndex].FindControl("lbDeleteItem");
            if (lbDeleteItem != null)
            {
                //已使用的职位等级不允许删除
                if (InitEvent != null)
                {
                    InitEvent(lbDeleteItem, positionGrade.Id);
                    //lbDeleteItem.Text = "<img src=../../image/file_cancel_enable.gif border=0>";
                    //lbDeleteItem.Enabled = false;
                }
            }
        }

        #endregion

        protected void PositionGradeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as LinkButton;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
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
            if (ddlCardPropertyParaParaChangedForDeleteEvent != null)
            {
                ddlCardPropertyParaParaChangedForDeleteEvent(row.RowIndex.ToString());
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
            if (ddlCardPropertyParaParaChangedForAddAtEvent != null)
            {
                ddlCardPropertyParaParaChangedForAddAtEvent(row.RowIndex.ToString());
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
            if (ddlCardPropertyParaParaChangedForDownEvent != null)
            {
                ddlCardPropertyParaParaChangedForDownEvent(row.RowIndex.ToString());
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
            if (ddlCardPropertyParaParaChangedForUpEvent != null)
            {
                ddlCardPropertyParaParaChangedForUpEvent(row.RowIndex.ToString());
            }
        }


        public List<int> DelPositionGradeId
        {
            get
            {
                List<int> items = ViewState["DelPositionGradeId"] as List<int>;
                if(items == null)
                    items = new List<int>();
                return items;
            }
            set
            {
                ViewState["DelPositionGradeId"] = value;
            }
        }
    }
}