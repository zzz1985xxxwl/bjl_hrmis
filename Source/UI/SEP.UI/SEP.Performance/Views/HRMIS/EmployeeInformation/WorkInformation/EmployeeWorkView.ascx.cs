//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeWorkView.ascx.cs
// 创建者: 倪豪
// 创建日期: 2008-10-09
// 概述: 工作信息的基本信息界面
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Adjusts;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.EmployeeInformation.WorkInformation
{
    public partial class EmployeeWorkView : UserControl, IWorkInfoView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DiyProcessSelectChangeEvent != null)
            {
                DiyProcessSelectChangeEvent("");
            }
            BindPageTemplate();
        }

        protected void LinkButtonGoPageAssess_Click(int pageindex)
        {
            gvAssessTemplate.PageIndex = pageindex;
            gvAssessTemplate.DataSource = AssessActivityItemList;
            gvAssessTemplate.DataBind();
        }

        protected void LinkButtonGoPageContract_Click(int pageindex)
        {
            WorkGV.PageIndex = pageindex;
            EmployeeContract = EmployeeContractDataSource;
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplateAssessTemplate = ViewUtility.GetPageTemplate(gvAssessTemplate, "PageTemplateAssessTemplate");
            PageTemplate PageTemplateContract = ViewUtility.GetPageTemplate(WorkGV, "PageTemplateContract");

            if (PageTemplateAssessTemplate != null)
            {
                PageTemplateAssessTemplate.LinkButtonGoPageClickdelegate += LinkButtonGoPageAssess_Click;
            }
            if (PageTemplateContract != null)
            {
                PageTemplateContract.LinkButtonGoPageClickdelegate += LinkButtonGoPageContract_Click;
            }
        }

        public int AccountIdForProcess
        {
            get { return Convert.ToInt32(ViewState["AccountIdForProcess"]); }
            set
            {
                ViewState["AccountIdForProcess"] = value;
                hidAccountID.Value = value.ToString();
            }
        }

        public event DelegateNoParameter FatherSelectChangeEvent;
        public event DelegateNoParameter btnContractManageEvent;

        public event DelegateID DiyProcessSelectChangeEvent;

        public bool ContractManageVisible
        {
            set
            {
                if (value)
                {
                    tbContractManage.Style["display"] = "block";
                }
                else
                {
                    tbContractManage.Style["display"] = "none";
                }
            }
        }

        private int _DepartmentID;

        public int DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }

        protected void WorkGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            WorkGV.PageIndex = e.NewPageIndex;
            EmployeeContract = EmployeeContractDataSource;
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            FatherSelectChangeEvent();
        }

        protected void WorkGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        #region IWorkInfoView 成员

        public string SocietyWorkAge
        {
            set { txtSocietyWorkAge.Text = value; }
            get { return txtSocietyWorkAge.Text; }
        }

        public string Position
        {
            set { lblPosition.Text = value; }
        }

        public string SocietyWorkAgeMessage
        {
            get { return lblSocietyWorkAge.Text; }
            set { lblSocietyWorkAge.Text = value; }
        }

        public string ContractPosition
        {
            get { return txtContractPosition.Text.Trim(); }
            set { txtContractPosition.Text = value; }
        }

        public string Company
        {
            get { return ddlCompany.SelectedValue; }
            set { ddlCompany.SelectedValue = value; }
        }

        public string CompanyMessage
        {
            get { return lblCompanyMsg.Text; }
            set { lblCompanyMsg.Text = value; }
        }

        public string Department
        {
            set { lblDept.Text = value; }
        }

        public string DepartmentLeader
        {
            get { return txtDepLeader.Text.Trim(); }
            set { txtDepLeader.Text = value; }
        }

        public string ComeDate
        {
            get { return txtComeDate.Text; }
            set { txtComeDate.Text = value; }
        }

        public string ComeDateMessage
        {
            get { return lblComeDateMsg.Text; }
            set { lblComeDateMsg.Text = value; }
        }

        public string WorkAge
        {
            get { return lbWorkAge.Text; }
            set { lbWorkAge.Text = value; }
        }

        public string Responsibility
        {
            get { return txtResponsibility.Text.Trim(); }
            set { txtResponsibility.Text = value; }
        }

        public string ProbationEndDate
        {
            get { return txtProbationEndDate.Text; }
            set { txtProbationEndDate.Text = value; }
        }

        public string ProbationEndDateMessage
        {
            get { return lblProbationEndDate.Text; }
            set { lblProbationEndDate.Text = value; }
        }

        public string ProbationStartDate
        {
            get { return txtProbationStartDate.Text; }
            set { txtProbationStartDate.Text = value; }
        }

        public string ProbationStartDateMessage
        {
            get { return lblProbationStartDate.Text; }
            set { lblProbationStartDate.Text = value; }
        }

        public string ContractStartDate
        {
            get { return txtStartDate.Text; }
            set { txtStartDate.Text = value; }
        }

        public bool ContractStartDateEnable
        {
            get { return txtStartDate.Enabled; }
            set { txtStartDate.Enabled = value; }
        }

        public string NewContractStartDate
        {
            get { return txtNewConStart.Text; }
            set { txtNewConStart.Text = value; }
        }

        public bool NewContractStartDateEnable
        {
            get { return txtNewConStart.Enabled; }
            set { txtNewConStart.Enabled = value; }
        }

        public string ContractEndDate
        {
            get { return txtEndDate.Text; }
            set { txtEndDate.Text = value; }
        }

        public bool ContractEndDateEnable
        {
            get { return txtEndDate.Enabled; }
            set { txtEndDate.Enabled = value; }
        }

        public List<Contract> EmployeeContract
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set
            {
                if (value != null && value.Count != 0)
                {
                    WorkGV.DataSource = value;
                    WorkGV.DataBind();
                    DownLoadStatusDisplay();
                    Result.Visible = true;
                    Result.Style["display"] = "";
                }
                else
                {
                    Result.Visible = false;
                    Result.Style["display"] = "none";
                }
            }
        }

        public List<Department> CompanySource
        {
            get { throw new NotImplementedException(); }
            set
            {
                ddlCompany.Items.Clear();

                foreach (Department department in value)
                {
                    ListItem item = new ListItem(department.DepartmentName, department.DepartmentID.ToString(), true);
                    ddlCompany.Items.Add(item);
                }
            }
        }

        public string HRPrincipalProcessString
        {
            set { lblHRPrincipal.Text = value; }
        }

        //public List<DiyProcess> ReimburseProcess
        //{
        //    get { throw new NotImplementedException(); }
        //    set
        //    {
        //        ddlReimburse.Items.Clear();
        //        ddlReimburse.Items.Add(new ListItem("", "0", true));
        //        foreach (DiyProcess reimburse in value)
        //        {
        //            ddlReimburse.Items.Add(new ListItem(reimburse.Name, reimburse.ID.ToString(), true));
        //        }
        //    }
        //}

        public List<DiyProcess> TraineeApplicationProcess
        {
            get { throw new NotImplementedException(); }
            set
            {
                ddlTraineeApplication.Items.Clear();
                ddlTraineeApplication.Items.Add(new ListItem("", "0", true));
                foreach (DiyProcess traineeApplication in value)
                {
                    ddlTraineeApplication.Items.Add(
                        new ListItem(traineeApplication.Name, traineeApplication.ID.ToString(), true));
                }
            }
        }

        //public int ReimburseProcessId
        //{
        //    get { return Convert.ToInt32(ddlReimburse.SelectedValue); }
        //    set { ddlReimburse.SelectedValue = value.ToString(); }
        //}

        public int TraineeApplicationProcessId
        {
            get { return Convert.ToInt32(ddlTraineeApplication.SelectedValue); }
            set { ddlTraineeApplication.SelectedValue = value.ToString(); }
        }

        //public string ReimburseProcessString
        //{
        //    set { lblReimburse.Text = value; }
        //}

        public string TraineeApplicationString
        {
            set { lblTraineeApplication.Text = value; }
        }

        public List<DiyProcess> HRPrincipalProcess
        {
            get { throw new NotImplementedException(); }
            set
            {
                ddlHRPrincipal.Items.Clear();
                ddlHRPrincipal.Items.Add(new ListItem("", "0", true));
                foreach (DiyProcess assess in value)
                {
                    ddlHRPrincipal.Items.Add(new ListItem(assess.Name, assess.ID.ToString(), true));
                }
            }
        }

        public int HRPrincipalProcessId
        {
            get { return Convert.ToInt32(ddlHRPrincipal.SelectedValue); }
            set { ddlHRPrincipal.SelectedValue = value.ToString(); }
        }

        public string AssessProcessString
        {
            set { lblAssess.Text = value; }
        }

        public List<DiyProcess> AssessProcess
        {
            get { throw new NotImplementedException(); }
            set
            {
                ddlAssess.Items.Clear();
                ddlAssess.Items.Add(new ListItem("", "0", true));
                foreach (DiyProcess assess in value)
                {
                    ddlAssess.Items.Add(new ListItem(assess.Name, assess.ID.ToString(), true));
                }
            }
        }

        public int AssessProcessId
        {
            get { return Convert.ToInt32(ddlAssess.SelectedValue); }
            set { ddlAssess.SelectedValue = value.ToString(); }
        }

        public List<DiyProcess> LeaveRequestProcess
        {
            get { throw new NotImplementedException(); }
            set
            {
                ddlLeaveRequest.Items.Clear();
                ddlLeaveRequest.Items.Add(new ListItem("", "0", true));
                foreach (DiyProcess leave in value)
                {
                    ddlLeaveRequest.Items.Add(new ListItem(leave.Name, leave.ID.ToString(), true));
                }
            }
        }

        public int leaveProcessId
        {
            get { return Convert.ToInt32(ddlLeaveRequest.SelectedValue); }
            set { ddlLeaveRequest.SelectedValue = value.ToString(); }
        }

        public string LeaveProcessString
        {
            set { lblLeaveRequest.Text = value; }
        }

        public List<DiyProcess> OutProcess
        {
            get { throw new NotImplementedException(); }
            set
            {
                ddlOut.Items.Clear();
                ddlOut.Items.Add(new ListItem("", "0", true));
                foreach (DiyProcess leave in value)
                {
                    ddlOut.Items.Add(new ListItem(leave.Name, leave.ID.ToString(), true));
                }
            }
        }

        public int outProcessId
        {
            get { return Convert.ToInt32(ddlOut.SelectedValue); }
            set { ddlOut.SelectedValue = value.ToString(); }
        }

        public string OutProcessString
        {
            set { lblOut.Text = value; }
        }

        public List<DiyProcess> OverTimeProcess
        {
            get { throw new NotImplementedException(); }
            set
            {
                ddlOverTime.Items.Clear();
                ddlOverTime.Items.Add(new ListItem("", "0", true));
                foreach (DiyProcess overTime in value)
                {
                    ddlOverTime.Items.Add(new ListItem(overTime.Name, overTime.ID.ToString(), true));
                }
            }
        }

        public int OverTimeProcessId
        {
            get { return Convert.ToInt32(ddlOverTime.SelectedValue); }
            set { ddlOverTime.SelectedValue = value.ToString(); }
        }

        public string OverTimeString
        {
            set { lblOverTime.Text = value; }
        }

        public List<Contract> EmployeeContractDataSource
        {
            get
            {
                //todo Session changed to ViewState
                //return Session["Contract"] as List<Contract>;
                return ViewState["Contract"] as List<Contract>;
            }
            set
            {
                //todo Session changed to ViewState
                //Session["Contract"] = value;
                ViewState["Contract"] = value;
            }
        }

        public string DoorCardNO
        {
            get { return txtDoorCardNO.Text; }
            set { txtDoorCardNO.Text = value; }
        }

        public string WorkPlace
        {
            get { return tbWorkPlace.Text; }
            set { tbWorkPlace.Text = value; }
        }

        public List<PositionGrade> PositionGradeSource
        {
            set
            {
                ddlGrade.Items.Clear();
                ddlGrade.Items.Add(new ListItem(string.Empty, "-1"));
                foreach (PositionGrade positionGrade in value)
                {
                    ddlGrade.Items.Add(new ListItem(positionGrade.Name, positionGrade.Id.ToString(), true));
                }
            }
        }

        public string PositionGradeId
        {
            get { return ddlGrade.SelectedValue; }
            set { ddlGrade.SelectedValue = value; }
        }

        //public List<PrincipalShip> PrincipalShipSource
        //{
        //    set
        //    {
        //        ddlPrincipalShip.Items.Clear();
        //        ddlPrincipalShip.Items.Add(new ListItem(string.Empty, "-1"));
        //        foreach (PrincipalShip principalShip in value)
        //        {
        //            ddlPrincipalShip.Items.Add(new ListItem(principalShip.Name, principalShip.Id.ToString(), true));
        //        }
        //    }
        //}

        //public string PrincipalShipId
        //{
        //    get { return ddlPrincipalShip.SelectedValue; }
        //    set { ddlPrincipalShip.SelectedValue = value; }
        //}


        public List<AdjustRule> AdjustRuleSource
        {
            set
            {
                ddlAdjustRule.Items.Clear();
                ddlAdjustRule.Items.Add(new ListItem("", "0", true));
                foreach (AdjustRule rule in value)
                {
                    ddlAdjustRule.Items.Add(new ListItem(rule.AdjustRuleName, rule.AdjustRuleID.ToString(), true));
                }
            }
        }

        public int AdjustRuleID
        {
            get { return Convert.ToInt32(ddlAdjustRule.SelectedValue); }
            set { ddlAdjustRule.SelectedValue = value.ToString(); }
        }

        public List<AssessTemplateItem> AssessActivityItemList
        {
            get { return ViewState["AssessTemplateItem"] as List<AssessTemplateItem>; }
            set
            {
                ViewState["AssessTemplateItem"] = value;
                gvAssessTemplate.DataSource = value;
                gvAssessTemplate.DataBind();
            }
        }

        public List<PrincipalShip> PrincipalShipSource
        {
            set
            {
                ddlPrincipalShip.Items.Clear();
                ddlPrincipalShip.Items.Add(new ListItem(string.Empty, "-1"));
                foreach (PrincipalShip principalShip in value)
                {
                    ddlPrincipalShip.Items.Add(new ListItem(principalShip.Name, principalShip.Id.ToString(), true));
                }
            }
        }

        public string PrincipalShipId
        {
            get { return ddlPrincipalShip.SelectedValue; }
            set { ddlPrincipalShip.SelectedValue = value; }
        }

        #endregion

        protected void btnContractManage_Click(object sender, EventArgs e)
        {
            Response.Redirect(
                "../ContractPages/EmployeeContractList.aspx?" + ConstParameters.EmployeeId + "=" +
                Request.QueryString[ConstParameters.EmployeeId], false);
        }

        public event DelegateReturnString ContractDownLoadEvent;

        protected void DownLoad_Command(object sender, CommandEventArgs e)
        {
            string filename = ContractDownLoadEvent(Convert.ToInt32(e.CommandArgument));
            if (string.IsNullOrEmpty(filename))
            {
                Response.Write("<script>alert('下载失败');</script>");
                return;
            }
            FileInfo fileInfo = new FileInfo(filename);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename));
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
        }

        public event DelegateReturnBool IsDownLoadEnable;

        private void DownLoadStatusDisplay()
        {
            foreach (GridViewRow row in WorkGV.Rows)
            {
                LinkButton btnDownLoad = (LinkButton) row.FindControl("btnDownLoad");
                btnDownLoad.Enabled = IsDownLoadEnable(Convert.ToInt32(btnDownLoad.CommandArgument));
            }
        }

        protected void DiyProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = sender as DropDownList;
            if (list != null) DiyProcessSelectChangeEvent(list.ID);
        }

        #region AssessTemplate

        protected void gvAssessTemplate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAssessTemplate.PageIndex = e.NewPageIndex;
            gvAssessTemplate.DataSource = AssessActivityItemList;
            gvAssessTemplate.DataBind();
        }

        protected void gvAssessTemplate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

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

        #endregion
    }
}