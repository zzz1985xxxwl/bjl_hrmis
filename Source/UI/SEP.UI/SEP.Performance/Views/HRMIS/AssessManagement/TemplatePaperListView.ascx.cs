using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using SEP.Model.Positions;
using SEP.Presenter.Core;
using System.Data;

namespace SEP.Performance.Views.HRMIS.AssessManagement
{
    public partial class TemplatePaperListView : UserControl, ITemplatePaperListView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grvPaperlist, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            grvPaperlist.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        private List<AssessTemplatePaper> _Papers;

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (BtnSearchEvent != null)
                BtnSearchEvent();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (BtnAddEvent != null)
                BtnAddEvent();
        }

        protected void btnModify_Command(object sender, CommandEventArgs e)
        {
            if (BtnUpdateEvent != null)
                BtnUpdateEvent(e.CommandArgument.ToString());
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            if (BtnUpdateEvent != null)
                BtnDeleteEvent(e.CommandArgument.ToString());
        }

        protected void tbnCopy_Command(object sender, CommandEventArgs e)
        {
            if (BtnCopyEvent != null)
                BtnCopyEvent(e.CommandArgument.ToString());
        }

        protected void grvPaperlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvPaperlist.PageIndex = e.NewPageIndex;
            if (BtnUpdateEvent != null)
                BtnSearchEvent();
        }

        protected void grvPaperlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    if (BtnDetailEvent != null)
                        BtnDetailEvent(e.CommandArgument.ToString());
                    break;
                default:
                    break;
            }
        }

        protected void gvPaperlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }

        #region ITemplatePaperListView 成员

        public string TemplatePaperName
        {
            get
            {
                return txtPaperName.Text.Trim();
            }
            set
            {
                txtPaperName.Text = value;
            }
        }

        public string Message
        {
            get
            {
                return lblMessage.Text;
            }
            set
            {
                lblMessage.Text = value;
            }
        }

        public List<AssessTemplatePaper> AssessTemplatePapers
        {
            get
            {
                return _Papers;
            }
            set
            {
                _Papers = value;
                grvPaperlist.DataSource = value;
                grvPaperlist.DataBind();
                if (_Papers == null || _Papers.Count == 0)
                {
                    tbPaperList.Style["display"] = "none";
                }
                else
                {
                    tbPaperList.Style["display"] = "block";

                }
                lblMessage.Text = "<span class=\"font14b\">共查到 <span class=\"fontred\">"
                                   + value.Count + "</span> 条记录</span>";
            }
        }
        public event DelegateNoParameter BtnSearchEvent;
        public event DelegateNoParameter BtnAddEvent;
        public event DelegateID BtnUpdateEvent;
        public event DelegateID BtnDetailEvent;
        public event DelegateID BtnDeleteEvent;
        public event DelegateID BtnCopyEvent;
        public AssessTemplatePaper SessionCopyPaper
        {
            get
            {
                return Session[SessionKeys.SESSIONCOPYPAPER] as AssessTemplatePaper;
            }
            set
            {
                Session[SessionKeys.SESSIONCOPYPAPER] = value;
            }
        }

        #endregion

        #region 导出
        protected void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void Export()
        {
            string FileName = "绩效考核表" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day +
                      DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
            DataTable dt = CreateTable();
            MemoryStream ms = ExcelExportUtility.DataTableTurnToExcel(dt, "绩效考核表");
            ExcelExportUtility.OutputExcel(Server, Response, FileName, ms);
        }

        /// <summary>
        /// 生成表数据
        /// </summary>
        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            TemplateBuildHead(dt);
            TemplateBuildBody(dt);
            return dt;
        }

        /// <summary>
        /// 生成内容
        /// </summary>
        private void TemplateBuildBody(DataTable dt)
        {
            List<AssessTemplatePaper> itsSource =
                InstanceFactory.CreateAssessManagementFacade().GetTemplatePapersAllInfoByPaperName(TemplatePaperName);
            for (int k = 0; k < itsSource.Count; k++)
            {
                for (int i = 0; i < itsSource[k].ItsAssessTemplateItems.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["考核表名"] = itsSource[k].PaperName;
                    dr["岗位"] = itsSource[k].PositionList != null
                                                    ? PositionNames(itsSource[k].PositionList)
                                                    : "";
                    dr["绩效指标"] = itsSource[k].ItsAssessTemplateItems[i].Question;
                    dr["权重"] = itsSource[k].ItsAssessTemplateItems[i].Weight;
                    dr["绩效指标的相关说明"] = itsSource[k].ItsAssessTemplateItems[i].Description;
                    dt.Rows.Add(dr);
                }
            }
        }

        /// <summary>
        /// 生成表头
        /// </summary>
        private static void TemplateBuildHead(DataTable dt)
        {
            dt.Columns.Add("考核表名");
            dt.Columns.Add("岗位");
            dt.Columns.Add("绩效指标");
            dt.Columns.Add("权重");
            dt.Columns.Add("绩效指标的相关说明");
        }

        private static string PositionNames(List<Position> positions)
        {
            string ret = "";
            foreach (Position item in positions)
            {
                ret += string.IsNullOrEmpty(ret) ? item.Name : (item.Name + ", ");
            }
            return ret;
        }
        #endregion

        protected void btnInport_Click(object sender, EventArgs e)
        {
            Import();
        }
        private void Import()
        {
            string uploadFileLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
            if (!Directory.Exists(uploadFileLocation))
            {
                Directory.CreateDirectory(uploadFileLocation);
            }
            HttpPostedFile hpf = fuExcel.PostedFile;
            if (hpf != null)
            {
                string filename = Path.GetFileName(hpf.FileName);
                string fileExt = Path.GetExtension(hpf.FileName);
                string filePath = uploadFileLocation + "\\员工福利.xls";
                if (Validation(filename, fileExt))
                {
                    hpf.SaveAs(filePath);
                    if (ImportEvent != null)
                    {
                        ImportEvent(filePath);
                    }
                }
            }
        }

        public event DelegateID ImportEvent;
        private bool Validation(string filename, string fileExt)
        {
            if (!string.IsNullOrEmpty(filename.Trim()))
            {
                if (fileExt == ".xls" || fileExt == ".xlsx")
                {
                    return true;
                }
                lblMessage.Text = "<span class='fontred'>导入的文件格式错误</span>";
                return false;
            }
            lblMessage.Text = "<span class='fontred'>没有要导入的文件</span>";
            return false;
        }
    }
}





