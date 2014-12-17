using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using ShiXin.Security;
using hrmisModel = SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.AssessActivity
{
    

    public partial class AssessBasicInfoView : UserControl, IAssessBasicInfoView
    {
        #region IAssessBasicInfoView 成员

        public string Message
        {
            set
            {
                lblMessage.Text = value;
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

        public string ManagerName
        {
            set
            {
                lblManager.Text = value;

            }
        }

        private bool _IsBack;
        public bool IsBack
        {
            get
            {
                return _IsBack;
            }
            set
            {
                _IsBack = value;

            }
        }

        public hrmisModel.AssessActivity AssessActivityToShow
        {
            set
            {
                lblEmployeeName.Text = value.ItsEmployee.Account.Name;
                lblCharacter.Text = AssessActivityUtility.GetCharacterNameByType(value.AssessCharacterType);
                lblDepartment.Text = value.EmployeeDept;
                lblScopeFrom.Text = value.ScopeFrom.Date.ToShortDateString();
                lblScopeTo.Text = value.ScopeTo.Date.ToShortDateString();
                AssessActivityTable = value;
            }
        }

        public hrmisModel.AssessActivity AssessActivityTable
        {
            set
            {
                int count = value.ItsAssessActivityPaper.SubmitInfoes.Count;
                string width = (1.00 / count).ToString();
                bool isEmployeeVisible = value.IfEmployeeVisible;
                #region 生成表格

                HtmlTableRow row = new HtmlTableRow();
                for (int i = 0; i < count; i++)
                {
                    HtmlTableCell cell0 = new HtmlTableCell();
                    cell0.Width = width;
                    cell0.Align = "left";
                    row.Cells.Add(cell0);
                }
                tbAssessTable.Rows.Add(row);

                #endregion

                #region 生成表格内的内容

                List<SubmitInfo> itemsList = value.ItsAssessActivityPaper.SubmitInfoes;
                int stepIndex = value.NextStepIndex;
                for (int i = 0; i < count; i++)
                {
                    Button button = new Button();
                    button.CssClass = "assessflowlb1";
                    string btnText;
                    button.OnClientClick =
                        "window.open('" + LinkResult(value.AssessActivityID, itemsList[i], out btnText) +
                        "','AssessActivityDetail','resizable=1,scrollbars=1,status=1,menubar=no,toolbar=no,location=no, menu=no');return false";
                    button.Text = btnText;
                    tbAssessTable.Rows[0].Cells[i].Controls.Add(button);

                    //modify by liudan 2009-09-03 添加员工可见性判断
                    Account loginAccount = Session[SessionKeys.LOGININFO] as Account;
                    if (loginAccount != null)
                        if (loginAccount.Id.Equals(value.ItsEmployee.Account.Id))
                        {
                            if (isEmployeeVisible)
                            {
                                button.Enabled = i < stepIndex;
                            }
                            else
                            {
                                button.Enabled = false;
                                if (itemsList[i].SubmitInfoType.Id.Equals(1) && i < stepIndex)
                                {
                                    button.Enabled = true;
                                }
                            }
                        }
                        else
                        {
                            button.Enabled = i < stepIndex;
                        }
                    if (_IsBack)
                    {
                        button.Enabled = i < stepIndex;
                    }
                }

                #endregion
            }
        }

        private string LinkResult(int assessActivityID, SubmitInfo submitInfo, out string btnText)
        {
            string linkResult = "";
            string strBack = "";
            if (_IsBack)
            {
                strBack = "Back";
            }
            switch(submitInfo.SubmitInfoType.Id)
            {
                //SubmitInfoType.HRAssess
                case 0:
                    linkResult = "HRFillAssess" + strBack + "Detail.aspx?assessActivityID=" +
                                 SecurityUtil.DECEncrypt(assessActivityID.ToString()) + "&submitID=" +
                                 SecurityUtil.DECEncrypt(submitInfo.SubmitInfoID.ToString());
                    btnText = "HR考核意见";
                    break;
                //SubmitInfoType.MyselfAssess
                case 1:
                    linkResult = "PersonalFillAssess" + strBack + "Detail.aspx?assessActivityID=" +
                                 SecurityUtil.DECEncrypt(assessActivityID.ToString()) + "&submitID=" +
                                 SecurityUtil.DECEncrypt(submitInfo.SubmitInfoID.ToString());
                    btnText = "自我评定";
                    break;
                //SubmitInfoType.ManagerAssess
                case 2:
                    linkResult = "ManagerFillAssess" + strBack + "Detail.aspx?assessActivityID=" +
                                 SecurityUtil.DECEncrypt(assessActivityID.ToString()) + "&submitID=" +
                                 SecurityUtil.DECEncrypt(submitInfo.SubmitInfoID.ToString());
                    btnText = "主管考核意见";
                    break;
                //SubmitInfoType.Approve
                case 3:
                    linkResult = "CEOFillAssess" + strBack + "Detail.aspx?assessActivityID=" +
                                 SecurityUtil.DECEncrypt(assessActivityID.ToString()) + "&submitID=" +
                                 SecurityUtil.DECEncrypt(submitInfo.SubmitInfoID.ToString());
                    btnText = "批阅意见";
                    break;
                //SubmitInfoType.SummarizeCommment
                case 4:
                    linkResult = "SummaryAssess" + strBack + "Detail.aspx?assessActivityID=" +
                                 SecurityUtil.DECEncrypt(assessActivityID.ToString()) + "&submitID=" +
                                 SecurityUtil.DECEncrypt(submitInfo.SubmitInfoID.ToString());
                    btnText = "终结评语";
                    break;
                default:
                    btnText = "";
                    break;
            }
            return linkResult;
        }

        #endregion
     }
}