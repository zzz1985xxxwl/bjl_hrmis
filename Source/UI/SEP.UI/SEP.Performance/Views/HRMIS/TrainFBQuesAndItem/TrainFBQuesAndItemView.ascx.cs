using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using hrmismodel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain;
using TextBox=System.Web.UI.WebControls.TextBox;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.TrainFBQuesAndItem
{
    public partial class TrainFBQuesAndItemView : UserControl, ITrainFBQuestionAndItemView
    {
       protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string ResultMessage
        {
            get { return lbResultMessage.Text.Trim(); }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    divResultMessage.Style["display"] = "none";
                }
                else
                {
                    divResultMessage.Style["display"] = "block";
                    lbResultMessage.Text = value;
                }
            }
        }

        public string OperationType
        {
            get { return lbOperationType.Text.Trim(); }
            set { lbOperationType.Text = value; }
        }

        public string FBQuestionID
        {
            get { return lbID.Text.Trim().Split('#')[1]; }
            set { lbID.Text = " # " + value; }
        }

        public string FBQuestion
        {
            get { return tbName.Text.Trim(); }
            set { tbName.Text = value; }
        }

        public string FBQuestionMessage
        {
            get { return lbNameMessage.Text.Trim(); }
            set { lbNameMessage.Text = value; }
        }

        public string TrainFBQuesType
        {
            get
            {
                return ddlType.SelectedValue;
            }
            set
            {
                ddlType.SelectedValue = value;
            }
        }
        public List<TrainFBQuesType> TrainFBQuesTypeSource
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                ddlType.Items.Clear();
                foreach (TrainFBQuesType type in value)
                {
                    ddlType.Items.Add(new ListItem(type.Name, type.ParameterID.ToString(), true));
                }
            }
            
        }

        public string FBQuesTypeMessage
        {
            get
            {
                return lblTypeMessage.Text.Trim();
               
            }
            set {  lblTypeMessage.Text = value; }
        }

        public List<TrainFBItem> FBItemList
        {
            get
            {
                List<TrainFBItem> fBItems =
                    (List<TrainFBItem>)ViewState["_FBItems"];
                GetGridViewValue(fBItems);
                return fBItems;
            }
            set
            {
                ViewState["_FBItems"] = value;
                gvTrainFBItemList.DataSource = value;
                gvTrainFBItemList.DataBind();

                if (value == null || value.Count == 0)
                {
                    tbLeaveRequestItem.Style["display"] = "none";
                }
                else
                {
                    tbLeaveRequestItem.Style["display"] = "block";
                    SetGridViewDisplay(value);
                }
            }
        }

        public bool SetFormReadOnly
        {
            set
            {
                tbName.Enabled = !value;
                ddlType.Enabled = !value;
                SetEmunListColumnFalse(value);
            }
        }

        private void SetEmunListColumnFalse(bool value)
        {
            for (int i = 0; i < gvTrainFBItemList.Rows.Count; i++)
            {
                TextBox txtDescription = (TextBox)gvTrainFBItemList.Rows[i].FindControl("txtDescription");
                TextBox txtValue = (TextBox)gvTrainFBItemList.Rows[i].FindControl("txtValue");

                if (txtDescription != null)
                {
                    txtDescription.Enabled = !value;
                }
                if (txtValue != null)
                {
                    txtValue.Enabled = !value;
                }
            }
        }

        #region DiyStepList 内部方法

        private void GetGridViewValue(List<TrainFBItem> trainFBItems)
        {
            for (int i = 0; i < trainFBItems.Count; i++)
            {
                int intData;
                TextBox txtDescription =
                    (TextBox) gvTrainFBItemList.Rows[i].FindControl("txtDescription");
                if (txtDescription != null)
                {
                    trainFBItems[i].Description = txtDescription.Text.Trim();
                }

                TextBox txtValue =
                    (TextBox) gvTrainFBItemList.Rows[i].FindControl("txtValue");
                if (txtValue != null)
                {
                    if (int.TryParse(txtValue.Text.Trim(), out intData))
                    {
                        trainFBItems[i].Worth = Convert.ToInt32(txtValue.Text.Trim());
                    }
                    else
                    {
                        trainFBItems[i].Worth = 0;
                    }
                }
            }
        }

        private void SetGridViewDisplay(List<TrainFBItem> trainFBItems)
        {
            for (int i = 0; i < trainFBItems.Count; i++)
            {
                SetGridViewRowddlTrainFBItemDisplay(i, trainFBItems);
                SetGridViewRowLinkButtonDisplay(i);
            }
        }

        private void SetGridViewRowddlTrainFBItemDisplay(int rowIndex, List<TrainFBItem> trainFBItems)
        {
            TextBox txtDescription = (TextBox) gvTrainFBItemList.Rows[rowIndex].FindControl("txtDescription");
            TextBox txtValue = (TextBox) gvTrainFBItemList.Rows[rowIndex].FindControl("txtValue");

            if (txtDescription == null || txtValue == null)
            {
                return;
            }

            txtDescription.Text = trainFBItems[rowIndex].Description;
            txtDescription.Style["display"] = "block";
            txtValue.Text = trainFBItems[rowIndex].Worth.ToString();
            txtValue.Style["display"] = "block";
        }

        private void SetGridViewRowLinkButtonDisplay(int rowIndex)
        {
            LinkButton lbAddItem = (LinkButton)gvTrainFBItemList.Rows[rowIndex].FindControl("lbAddItem");
            if (lbAddItem != null)
            {
                lbAddItem.Text = "<img src=../../../Pages/image/file_new.gif border=0>";
            }
            LinkButton lbDeleteItem = (LinkButton)gvTrainFBItemList.Rows[rowIndex].FindControl("lbDeleteItem");
            if (lbDeleteItem != null)
            {
                lbDeleteItem.Text = "<img src=../../../Pages/image/file_cancel.gif border=0>";
            }
        }

        #endregion

        public event EventHandler btnOKClick;
        protected void BtnOK_Click(object sender, EventArgs e)
        {
            GetGridViewValue(FBItemList);
            btnOKClick(sender, e);
        }

        public event EventHandler btnSubmitClick;
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            GetGridViewValue(FBItemList);
            btnSubmitClick(sender, e);
        }

        public event DelegateID ddlTrainFBItemChangedForDownEvent;
        public event DelegateID ddlTrainFBItemChangedForUpEvent;
        public event DelegateID TrainFBItemForDeleteAtEvent;
        public event DelegateID TrainFBItemForAddAtEvent;

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
            if (TrainFBItemForDeleteAtEvent != null)
            {
                TrainFBItemForDeleteAtEvent(row.RowIndex.ToString());
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
            if (TrainFBItemForAddAtEvent != null)
            {
                TrainFBItemForAddAtEvent(row.RowIndex.ToString());
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
            if (ddlTrainFBItemChangedForUpEvent != null)
            {
                ddlTrainFBItemChangedForUpEvent(row.RowIndex.ToString());
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
            if (ddlTrainFBItemChangedForDownEvent != null)
            {
                ddlTrainFBItemChangedForDownEvent(row.RowIndex.ToString());
            }
        }
        protected void gvDiyStepList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }

    }
}