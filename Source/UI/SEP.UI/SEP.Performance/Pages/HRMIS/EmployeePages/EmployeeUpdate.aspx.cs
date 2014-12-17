using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.EmployInformation;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages
{
    public partial class EmployeeUpdate : BasePage
    {
        private UpdateEmployeeInfoPresenter up;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A401))
            {
                throw new ApplicationException("没有权限访问");
            }
            up = new UpdateEmployeeInfoPresenter(EmployeeView1, SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.EmployeeId]), LoginUser);

            up.InitView(Page.IsPostBack);
            //导出事件由界面处理
            EmployeeView1.BtnExportEvent += Export;
            EmployeeView1.BackAccountsID = LoginUser.Id.ToString();
            
            //ap = new UpdateEmployeePresenter(EmployeeMessageDisplayView1, 11.ToString());
            //ap = new UpdateEmployeePresenter(EmployeeMessageDisplayView1, SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.EmployeeId]));
            //ap.InitView(SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.EmployeeId]), Page.IsPostBack);
            //EmployeeMessageDisplayView1.btnConfrimEvent=ap.UpdateEmployeeEvent;
            //EmployeeMessageDisplayView1.btnExportEvent = Export;
            //ap.InitView(11.ToString(), Page.IsPostBack);
        }
     
        public void Export()
        {
            string filename = up.ExportEmployeeEvent(Server.MapPath(ConstParameters.Template_EmployeeInfoDoc));
            if (string.IsNullOrEmpty(filename)||!File.Exists(filename))
            {
                EmployeeView1.Message = //EmployeePresenterUtilitys._ErrorImage +
                    "导出失败";
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