using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using HRMISModel = SEP.HRMIS.Model;


namespace SEP.Performance.Views.Employee
{
    public partial class EmployeeContractView : UserControl,IEmployeeContractView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            listType.Attributes.Add("onchange", Page.GetPostBackEventReference(listType));
        }

        public delegate void ShowWindowForAddAssessCondition();
        public ShowWindowForAddAssessCondition _ShowWindowForAddAssessCondition;
        public delegate void ShowWindowForModifyAssessCondition(ApplyAssessCondition ApplyAssessCondition);
        public ShowWindowForModifyAssessCondition _ShowWindowForModifyAssessCondition;
        public delegate void ShowWindowForDeleteAssessCondition(ApplyAssessCondition ApplyAssessCondition);
        public ShowWindowForDeleteAssessCondition _ShowWindowForDeleteAssessCondition;
        public delegate void ShowWindowForDetailAssessCondition(ApplyAssessCondition ApplyAssessCondition);
        public ShowWindowForDetailAssessCondition _ShowWindowForDetailAssessCondition;
        public delegate void GetSystemSet();
        public GetSystemSet _GetSystemSet;

        #region IEmployeeContractView 成员
        public event EventHandler btnOKClick;
        public event EventHandler btnCancelClick;
        protected void btnOk_Click(object sender, EventArgs e)
        {
            btnOKClick(sender, e);
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            btnCancelClick(sender, e);
        }

        protected void listType_SelectedIndexChanged(object sender, EventArgs e) { }
         
        public List<ApplyAssessCondition> ConditionSource
        {
            get
            {
                return (List<ApplyAssessCondition>)Session["_ConditionSource"];
            }
            set
            {
                Session["_ConditionSource"] = value;
                gvCondition.DataSource = value;
                gvCondition.DataBind();
                if (value == null || value.Count == 0)
                {
                    tbCondition.Style["display"] = "none";
                }
                else
                {
                    tbCondition.Style["display"] = "";
                }
            }
        }


        public List<HRMISModel.ContractType> ContractTypeSource
        {
            set
            {
                listType.Items.Clear();
                foreach (HRMISModel.ContractType type in value)
                {
                    ListItem item = new ListItem(type.ContractTypeName, type.ContractTypeID.ToString());
                    listType.Items.Add(item);
                }
            }
        }

        public string ContractStartTime
        {
            get { return txtStartTime.Text; }
            set { txtStartTime.Text = value; }
        }

        public string ContractTypeId
        {
            get { return listType.SelectedValue; }
            set { listType.SelectedValue = value; }
        }

        public string ResultMessage
        {
            set
            {
                lblResultMessage.Text = value;
                if (String.IsNullOrEmpty(value))
                {
                    tbNoDataMessage.Style["display"] = "none";
                }
                else
                {
                    tbNoDataMessage.Style["display"] = "";
                }
            }
        }

        public string Title
        {
            set { lblTitle.Text = value; }
        }

        public bool SetReadonly
        {
            set 
            {
                listType.Enabled = !value;
                txtEndTime.ReadOnly = value;
                txtStartTime.ReadOnly = value;
                btnGetSystemSet.Visible = !value;
                btnAddFirstCondition.Visible = !value;
                gvCondition.Columns[4].Visible = !value;
                gvCondition.Columns[5].Visible = !value;
            }
        }

        public bool SetTypeReadonly
        {
            set
            {
                listType.Enabled = !value;
            }
        }
        public string Remark
        {
            get
            {
                return txtRemark.Text;
            }
            set
            {
                txtRemark.Text = value;
            }
        }

        public string Attachment
        {
            get
            {
                return txtAttachment.Text;
            }
            set
            {
                txtAttachment.Text = value;
            }
        }

        public string TimeErrorMessage
        {
            get { throw new NotImplementedException(); }
            set { lblErrorTime.Text = value; }
        }

        public string ContractEndTime
        {
            get { return txtEndTime.Text; }
            set { txtEndTime.Text = value; }
        }


        public List<EmployeeContractBookMark> EmployeeContractBookMarkList
        {
            get
            {
                if (tbBookMark.Rows.Count > 0)
                {
                    List<EmployeeContractBookMark> employeeContractBookMarkList = new List<EmployeeContractBookMark>();
                    for (int i = 0; i < tbBookMark.Rows.Count; i++)
                    {
                        employeeContractBookMarkList.Add(
                            new EmployeeContractBookMark(-1, -1, ((Label)tbBookMark.Rows[i].Cells[0].Controls[0]).Text,
                                                         ((TextBox)tbBookMark.Rows[i].Cells[1].Controls[0]).Text));
                        try
                        {
                            employeeContractBookMarkList.Add(
                                new EmployeeContractBookMark(-1, -1,
                                                             ((Label)tbBookMark.Rows[i].Cells[2].Controls[0]).Text,
                                                             ((TextBox)tbBookMark.Rows[i].Cells[3].Controls[0]).Text));
                        }
                        catch
                        {
                        }
                    }
                    return employeeContractBookMarkList;
                }
                return null;
            }
            set
            {
                if (value != null && value.Count > 0)
                {
                    trBookMark.Style["display"] = "";
                    //生成表格
                    if (value.Count == 1)
                    {
                        HtmlTableRow row = new HtmlTableRow();
                        HtmlTableCell cell0 = new HtmlTableCell();
                        cell0.Width = "10%";
                        cell0.Align = "right";
                        HtmlTableCell cell1 = new HtmlTableCell();
                        cell1.Width = "90%";
                        cell1.Align = "left";
                        row.Cells.Add(cell0);
                        row.Cells.Add(cell1);
                        tbBookMark.Rows.Add(row);
                    }
                    else
                    {
                        for (int i = 0; i < ((value.Count + value.Count % 2) / 2); i++)
                        {
                            HtmlTableRow row = new HtmlTableRow();
                            HtmlTableCell cell0 = new HtmlTableCell();
                            cell0.Width = "10%";
                            cell0.Align = "right";
                            HtmlTableCell cell1 = new HtmlTableCell();
                            cell1.Width = "40%";
                            cell1.Align = "left";
                            HtmlTableCell cell2 = new HtmlTableCell();
                            cell2.Width = "10%";
                            cell2.Align = "right";
                            HtmlTableCell cell3 = new HtmlTableCell();
                            cell3.Width = "40%";
                            cell3.Align = "left";
                            row.Cells.Add(cell0);
                            row.Cells.Add(cell1);
                            row.Cells.Add(cell2);
                            row.Cells.Add(cell3);
                            tbBookMark.Rows.Add(row);
                        }
                    }
                    //生成表格内的内容
                    int j = 0;
                    for (int i = 0; i < value.Count; i++)
                    {

                        Label lb = new Label();
                        lb.ID = value[i].BookMarkName;
                        lb.Text = value[i].BookMarkName;
                        TextBox textBox = new TextBox();
                        textBox.Width = Unit.Parse("70%");
                        textBox.Text = value[i].BookMarkValue;
                        textBox.CssClass = "input1";
                        textBox.ID = "TextBox" + value[i].BookMarkName;
                        if (value[i].BookMarkValue.Contains("\r"))
                        {
                            textBox.TextMode = TextBoxMode.MultiLine;
                        } 
                        if (i % 2 == 1)
                        {
                            tbBookMark.Rows[j].Cells[2].Controls.Add(lb);
                            tbBookMark.Rows[j].Cells[3].Controls.Add(textBox);
                            j++;
                        }
                        else
                        {
                            tbBookMark.Rows[j].Cells[0].Controls.Add(lb);
                            tbBookMark.Rows[j].Cells[1].Controls.Add(textBox);
                        }

                    }
                }
                else
                {
                    trBookMark.Style["display"] = "none";
                }
            }
        }

        public string EmployeeId
        {
            get { return lblEmployeeID.Text; }
            set { lblEmployeeID.Text = value; }
        }

        #endregion

        protected void lbModifyCondition_Click(object sender, CommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            _ShowWindowForModifyAssessCondition(ConditionSource[gvCondition.PageIndex*gvCondition.PageSize + index]);
        }

        protected void lbDeleteCondition_Click(object sender, CommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            _ShowWindowForDeleteAssessCondition(ConditionSource[gvCondition.PageIndex * gvCondition.PageSize + index]);
        }

        protected void gvAssessActivityList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCondition.PageIndex = e.NewPageIndex;
            gvCondition.DataSource = ConditionSource;
            gvCondition.DataBind();
        }

        protected void btnAddCondition_Click(object sender, EventArgs e)
        {
            _ShowWindowForAddAssessCondition();
        }

        protected void btnGetSystemSet_Click(object sender, EventArgs e)
        {
            _GetSystemSet();
        }

        protected void gvCondition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    int index = Convert.ToInt32(e.CommandArgument.ToString());
                    _ShowWindowForDetailAssessCondition(ConditionSource[gvCondition.PageIndex * gvCondition.PageSize + index]);
                    return;
            }

        }

        protected void gvCondition_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

    }
}