using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;

namespace SEP.Performance.Views.HRMIS.AssessActivity
{
    public partial class AssessAnswerView : UserControl, IAssessAnswerView
    {
       
        #region IAssessAnswerView 成员
        public string Message
        {
            set
            {
                lblMessage.Text = value;
                if(String.IsNullOrEmpty(value))
                {
                    tbMessage.Style["display"] = "none";
                }
                else
                {
                    tbMessage.Style["display"] = "block";
                }
            }
            get { return lblMessage.Text; }
        }
        public string CommentMsg
        {
            set { lblCommentMsg.Text = value; }
        }
        public string IntentionMsg
        {
            set { lblIntentionMsg.Text = value; }
        }
        public string Title
        {
            set { lblTitle.Text = value; }
        }
        public string SalaryName
        {
            set { lblSalaryName.Text = value; }
        }
        
        public string Comment
        {
            get
            {
                return txtComment.Text.Trim();
            }
            set
            {
                txtComment.Text = value;
            }
        }

        public string SalaryNow
        {
            get { return txtSalaryNow.Text.Trim(); }
            set { txtSalaryNow.Text=value; }
        }

        public string SalaryChange
        {
            get { return txtSalaryChange.Text.Trim(); }
            set { txtSalaryChange.Text=value; }
        }

        public string ManagerSalalry
        {
            set { lblManageSalary.Text = value; }
        }

        public bool ShowNowSalaryStar
        {
            set { nowSalaryStar.Visible = value; }
        }

        private bool _Visible360;
        public bool Visible360
        {
            get { return _Visible360; }
            set { _Visible360 = value; }
        }

        public string SalaryNowMessage
        {
            set { lblSalaryNow.Text=value; }
        }

        public string SalaryChangeMessage
        {
            set { lblSalaryChange.Text=value; }
        }

        public string PersonalGoal
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    lblPersonalGoal.Text = "无";
                }
                else
                {
                    lblPersonalGoal.Text = value;
                }
            }
        }

        public string AssessFromTime
        {
            set { lblScopeDateFrom.Text = value; }
        }

        public string AssessToTime
        {
            set { lblScopeDateTo.Text=value; }
        }

        public string EmployeeID
        {
            get { return hfEmployeeID.Value; }
            set { hfEmployeeID.Value=value; }
        }

        public string Responsibility
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    lblResponsibility.Text = "无";
                }
                else
                {
                    lblResponsibility.Text = value;
                }
            }
        }
        public List<AssessActivityItem> AssessActivityItems
        {
            get
            {
                List<AssessActivityItem> assessActivityItems = _AssessActivityItems;
                foreach (RepeaterItem item in rptQuesItems.Items)
                {
                    if ( assessActivityItems[item.ItemIndex].AssessTemplateItemType == AssessTemplateItemType.Option )
                    {
                        assessActivityItems[item.ItemIndex].Grade =
                            Convert.ToInt32(((DropDownList) item.FindControl("ddlScore")).SelectedValue);
                        assessActivityItems[item.ItemIndex].Note = ((TextBox) item.FindControl("txtNote")).Text.Trim();
                    }
                    else if (assessActivityItems[item.ItemIndex].AssessTemplateItemType == AssessTemplateItemType.Open)
                    {
                        assessActivityItems[item.ItemIndex].Note = ((TextBox)item.FindControl("txtNote")).Text.Trim();
                    }
                    else if (assessActivityItems[item.ItemIndex].AssessTemplateItemType == AssessTemplateItemType.Score)
                    {
                        assessActivityItems[item.ItemIndex].GradeString = ((TextBox)item.FindControl("txtScore")).Text.Trim();
                        assessActivityItems[item.ItemIndex].Note = ((TextBox)item.FindControl("txtNote")).Text.Trim();
                    }
                }
                return assessActivityItems;
            }
            set
            {
                _AssessActivityItems = value;

            }
        }

        private List<AssessActivityItem> _AssessActivityItems;

        public List<AssessActivityItem> QuesItemsSource
        {
            set
            {
                rptQuesItems.DataSource = value;
                rptQuesItems.DataBind();
                foreach (RepeaterItem item in rptQuesItems.Items)
                {
                    //add by liudan 2009-09-04
                    Label lblType = (Label)item.FindControl("lblType");
                    lblType.Text = AssessUtility.GetChoosedItemClassficationName(lblType.Text);


                    HtmlTableCell tdOther = (HtmlTableCell)item.FindControl("tdOther");
                    tdOther.Style["display"] = "block";
                    HtmlTableCell tdOpen = (HtmlTableCell)item.FindControl("tdOpen");
                    tdOpen.Style["display"] = "none";
                    HtmlTableCell td360 = (HtmlTableCell)item.FindControl("td360");
                    td360.Style["display"] = "none";

                    if (value[item.ItemIndex].AssessTemplateItemType==AssessTemplateItemType.Option)
                    {
                        HtmlTableRow trScore = (HtmlTableRow)item.FindControl("trScore");
                        trScore.Style["display"] = "none";
                        HtmlTableRow trFormula = (HtmlTableRow)item.FindControl("trFormula");
                        trFormula.Style["display"] = "none";
                        DropDownList ddlScoreSelect = (DropDownList) item.FindControl("ddlScore");
                        string[] eachOptions = value[item.ItemIndex].Option.Split('/');
                        for (int i = 0; i < eachOptions.Length; i++)
                        {
                            ddlScoreSelect.Items.Add(
                                new ListItem(eachOptions[i], ((eachOptions.Length - i)*20).ToString()));//2010-11-10 ltl要求每题都是100分
                        }
                        ddlScoreSelect.SelectedValue = Convert.ToInt32(_AssessActivityItems[item.ItemIndex].Grade).ToString();
                        Label lblremarkoranswer = (Label) item.FindControl("lblremarkoranswer");
                        lblremarkoranswer.Text = "备 注";
                        HtmlTableRow trRemark = (HtmlTableRow)item.FindControl("trRemark");
                        trRemark.Style["display"] = "none";
                    }
                    else if (value[item.ItemIndex].AssessTemplateItemType == AssessTemplateItemType.Open)
                    {
                        //add by liudan 2009-09-04
                        tdOther.Style["display"] = "none";
                        if (value[item.ItemIndex].Classfication == ItemClassficationEmnu._360)
                        {
                            td360.Style["display"] = "block";
                        }
                        else
                        {
                            tdOpen.Style["display"] = "block";
                        }
                        HtmlTableRow trScore = (HtmlTableRow)item.FindControl("trScore");
                        trScore.Style["display"] = "none";
                        HtmlTableRow trOption = (HtmlTableRow)item.FindControl("trOption");
                        trOption.Style["display"] = "none";
                        HtmlTableRow trFormula = (HtmlTableRow)item.FindControl("trFormula");
                        trFormula.Style["display"] = "none";
                        Label lblremarkoranswer = (Label)item.FindControl("lblremarkoranswer");
                        lblremarkoranswer.Text = "答 案";
                    }
                    else if (value[item.ItemIndex].AssessTemplateItemType == AssessTemplateItemType.Score)
                    {
                        HtmlTableRow trScore = (HtmlTableRow)item.FindControl("trScore");
                        trScore.Style["display"] = "block";
                        HtmlTableRow trOption = (HtmlTableRow)item.FindControl("trOption");
                        trOption.Style["display"] = "none";
                        HtmlTableRow trFormula = (HtmlTableRow)item.FindControl("trFormula");
                        trFormula.Style["display"] = "none";
                        Label lblRange = (Label)item.FindControl("lblRange");
                        string[] scoreRange = value[item.ItemIndex].Option.Split('/');
                        lblRange.Text = string.Format("范围：{0} -- {1}",scoreRange[0],scoreRange[1]);
                        TextBox txtScore = (TextBox)item.FindControl("txtScore");
                        txtScore.Text = value[item.ItemIndex].Grade.ToString();
                        Label lblremarkoranswer = (Label)item.FindControl("lblremarkoranswer");
                        lblremarkoranswer.Text = "备 注";
                        HtmlTableRow trRemark = (HtmlTableRow)item.FindControl("trRemark");
                        trRemark.Style["display"] = "none";
                    }
                    else if (value[item.ItemIndex].AssessTemplateItemType == AssessTemplateItemType.Formula)
                    {
                        HtmlTableRow trScore = (HtmlTableRow)item.FindControl("trScore");
                        trScore.Style["display"] = "none";
                        HtmlTableRow trOption = (HtmlTableRow)item.FindControl("trOption");
                        trOption.Style["display"] = "none";
                        TextBox txtFormulaAnswer = (TextBox)item.FindControl("txtFormulaAnswer");
                        txtFormulaAnswer.Text = value[item.ItemIndex].Grade.ToString();
                        Label lblremarkoranswer = (Label)item.FindControl("lblremarkoranswer");
                        lblremarkoranswer.Text = "备 注";
                        HtmlTableRow trRemark = (HtmlTableRow)item.FindControl("trRemark");
                        trRemark.Style["display"] = "none";
                    }
                }
            }
        }

        public string[] IntentionSource
        {
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    rbIntention.Items.Add(value[i]);
                }
            }
        }

        public string SelectIntention
        {
            get
            {
                try
                {
                    return rbIntention.SelectedItem.Text;
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                for (int i = 0; i < rbIntention.Items.Count; i++)
                {
                    if (rbIntention.Items[i].Text.Equals(value))
                    {
                        rbIntention.Items[i].Selected = true;
                        return;
                    }
                }
            }
        }

        public bool ShowComment
        {
            set
            {
                tblComment.Visible = value;
            }
        }
        public bool ShowIntention
        {
            set { tblIntentioin.Visible = value; }
        }
        public bool ShowAssessItem
        {
            set { tblAssessItem.Visible = value; }
        }
        public bool ShowPersonalGoal
        {
            set { tbPersonalGoal.Visible = value; }
        }
        public bool ShowResponsibility
        {
            set { tbResponsibility.Visible = value; }
        }
        public bool ShowAttendanceStatistics
        {
            set { tbAttendanceStatistics.Visible = value;}
        }
        public bool ShowbtnSave
        {
            set { btnSave.Visible = value; }
        }
        public bool FormReadonly
        {
            set
            {
                foreach (RepeaterItem item in rptQuesItems.Items)
                {
                    foreach (Control ctrl in item.Controls)
                    {
                        switch (ctrl.GetType().FullName)
                        {
                            case "System.Web.UI.WebControls.DropDownList":
                                ((DropDownList)ctrl).Enabled = !value;
                                break;
                            case "System.Web.UI.WebControls.TextBox":
                                ((TextBox)ctrl).ReadOnly = value;
                                break;
                            default:
                                break;
                        }
                    }
                }
                for (int i = 0; i < rbIntention.Items.Count; i++)
                {
                    rbIntention.Items[i].Enabled = !value;
                }
                txtComment.ReadOnly = value;
                btnSave.Visible = !value;
                btnSubmit.Visible = !value;
            }
        }

        public bool ShowSalary
        {
            set { divSalary.Visible=value; }
        }

        public bool ShowSalaryChange
        {
            set { tableSalaryChange.Visible=value; }
        }

        public bool ReadOnlySalaryChange
        {
            set { txtSalaryChange.ReadOnly = value; }
        }

        public bool ReadOnlySalaryNow
        {
            set { txtSalaryNow.ReadOnly = value; }
        }

        public bool ShowStar
        {
            set
            {
                lblStar.Visible = value;
            }
        }

        #endregion

        public EventHandler btnSaveClick;
        protected void btnSave_Click(object sender, EventArgs e)
        {
            btnSaveClick(sender, e);
        }

        public EventHandler btnSubmitClick;
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmitClick(sender, e);
        }

    }
}