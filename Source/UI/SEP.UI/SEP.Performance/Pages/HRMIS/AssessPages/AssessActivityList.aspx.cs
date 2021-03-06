using System;
using System.IO;
using System.Text;
using System.Web;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.AssessActivity;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Performance.Views;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class AssessActivityList : BasePage
    {
        private AssessActivityListPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A705))
            {
                throw new ApplicationException("没有权限访问");
            }

            presenter = new AssessActivityListPresenter(AssessActivityListView1, LoginUser);
            AssessActivityListView1.btnInterruptClick = presenter.BtnInterruptClick;
            AssessActivityListView1.btnEmployeeVisibleClick += presenter.BtnEmployeeVisibleClick;
            AssessActivityListView1.btnSearchEvent += presenter.ExecutEvent;
            AssessActivityListView1.BindAssessActivity += presenter.BindAssessActivity;
            //add by liudan 
            AssessActivityListView1.btnDeleteClick += presenter.DeleteAssessActivity;
            presenter.Initialize(IsPostBack);
            AssessActivityListView1.btnExportLeaderClick += ExportLeaderClick;
            AssessActivityListView1.btnExportSelfClick += ExportSelfClick;
            AssessActivityListView1.btnExportAssessFormClick += btnExportAssessFormClick;
            AssessActivityListView1.btnExportEmployeeSummaryClick += btnExportEmployeeSummaryClick;
            AssessActivityListView1.btnExportAnnualAssessClick += btnExportAnnualAssessClick;
        }

        public void ExportLeaderClick(string id)
        {
            string filename = presenter.ExportLeaderEvent(Server.MapPath(ConstParameters.Template_AssessExportDoc));
            Export(filename);
        }

        public void ExportSelfClick(string id)
        {
            string filename = presenter.ExportSelfEvent(Server.MapPath(ConstParameters.Template_AssessExportDoc));
            Export(filename);
        }


        public void btnExportEmployeeSummaryClick(string id)
        {
            string filename =
                AssessActivityListPresenter.ExportEmployeeSummaryEvent(
                    Server.MapPath(ConstParameters.Template_EmployeeAnnualSummaryDoc),
                    Server.MapPath(ConstParameters.Template_EmployeeNormalSummaryDoc), Convert.ToInt32(id));
            Export(filename);
        }

        public void btnExportAssessFormClick(string id)
        {
            string filename =
                AssessActivityListPresenter.ExportAssessFormEvent(Server.MapPath(ConstParameters.Template_AnnualDoc),
                                                                  Server.MapPath(
                                                                      ConstParameters.Template_NormalForContractDoc),
                                                                  Convert.ToInt32(id));
            Export(filename);
        }

        public void btnExportAnnualAssessClick()
        {
            //string filename =
            //    presenter.ExportAnnualAssessAll(Server.MapPath(ConstParameters.Template_AnnualAssessXls));
            //if (filename != presenter.JUDGEERROR)
            //{
            //    Export(filename);
            //}
            MemoryStream ms =
               presenter.ExportAnnualAssessAll(Server.MapPath(ConstParameters.Template_AnnualAssessXls));
            if (ms != null)
            {
                ExcelExportUtility.OutputExcel(Server, Response, "绩效评估结果", ms);
            }
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
    }
}