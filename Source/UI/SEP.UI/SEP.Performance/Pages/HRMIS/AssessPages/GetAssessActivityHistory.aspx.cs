//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetAssessActivityHistory.cs
// 创建者: 唐曼丽
// 创建日期: 2008-06-16
// 概述: 添加查询历史考评活动
// ----------------------------------------------------------------
using System;
using System.IO;
using System.Text;
using System.Web;
using SEP.HRMIS.Presenter.AssessActivity;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class GetAssessActivityHistory : BasePage
    {
        public string _StrCount;
        private GetMyAssessHistoryPresenter MyPresenter;
        private GetUnderlingAsessHistoryPresenter UnderlingPresenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            MyPresenter = new GetMyAssessHistoryPresenter(GetMyAssessHistoryView1, LoginUser);
            UnderlingPresenter = new GetUnderlingAsessHistoryPresenter(GetUnderlingAssessHistoryView1, LoginUser);
            MyPresenter.Initialize(IsPostBack);
            UnderlingPresenter.Initialize(IsPostBack);
            GetMyAssessHistoryView1.BindAssessActivity = MyPresenter.BindAssessActivity;
            GetUnderlingAssessHistoryView1.BindAssessActivity = UnderlingPresenter.BindAssessActivity;
            GetMyAssessHistoryView1.CaculateCount = CaculateCount;
            GetUnderlingAssessHistoryView1.CaculateCount = CaculateCount;
            CaculateCount(null, null);
            GetUnderlingAssessHistoryView1.btnExportLeaderClick += ExportUnderlingAssessHistoryLeaderClick;
            GetUnderlingAssessHistoryView1.btnExportSelfClick += ExportUnderlingAssessHistorySelfClick;
            GetMyAssessHistoryView1.btnExportSelfClick += ExportMyAssessHistorySelfClick;
            GetMyAssessHistoryView1.btnExportAllClick += btnExportAssessFormClick;
            GetUnderlingAssessHistoryView1.btnExportAssessFormClick += btnExportAssessFormClick;
            GetUnderlingAssessHistoryView1.btnExportEmployeeSummaryClick += btnExportEmployeeSummaryClick;
        }

        public void btnExportEmployeeSummaryClick(string id)
        {
            string filename =
                AssessActivityListPresenter.ExportEmployeeSummaryEvent(Server.MapPath(ConstParameters.Template_EmployeeAnnualSummaryDoc), Server.MapPath(ConstParameters.Template_EmployeeNormalSummaryDoc), Convert.ToInt32(id));
            Export(filename);
        }

        public void btnExportAssessFormClick(string id)
        {
            string filename =
                AssessActivityListPresenter.ExportAssessFormEvent(Server.MapPath(ConstParameters.Template_AnnualDoc), Server.MapPath(ConstParameters.Template_NormalForContractDoc), Convert.ToInt32(id));
            Export(filename);
        }

        private void Export(string filename)
        {
            if (string.IsNullOrEmpty(filename) || !File.Exists(filename))
            {
                Response.Write("<script>alert('导出失败');</script>");
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

        private void CaculateCount(object sender, EventArgs e)
        {
            _StrCount =
                (GetMyAssessHistoryView1.AssessActivitysCount + GetUnderlingAssessHistoryView1.AssessActivitysCount).
                    ToString();
        }

        public void ExportUnderlingAssessHistoryLeaderClick(string id)
        {
            string filename = UnderlingPresenter.ExportLeaderEvent(Server.MapPath(ConstParameters.Template_AssessExportDoc));
            if (string.IsNullOrEmpty(filename) || !File.Exists(filename))
            {
                //getUnderlingAssessHistoryView.Message = "导出失败";
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

        public void ExportUnderlingAssessHistorySelfClick(string id)
        {
            string filename = UnderlingPresenter.ExportSelfEvent(Server.MapPath(ConstParameters.Template_AssessExportDoc));
            if (string.IsNullOrEmpty(filename) || !File.Exists(filename))
            {
                //AssessActivityListView1.Message = "导出失败";
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

        public void ExportMyAssessHistorySelfClick(string id)
        {
            string filename =
               AssessActivityListPresenter.ExportEmployeeSummaryEvent(Server.MapPath(ConstParameters.Template_EmployeeAnnualSummaryDoc), Server.MapPath(ConstParameters.Template_EmployeeNormalSummaryDoc), Convert.ToInt32(id));
            Export(filename);
        }
    }
}
