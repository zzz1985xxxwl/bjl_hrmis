using System;
using System.IO;
using System.Text;
using System.Web;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.Train.TrainCourse;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.TrainingPages
{
    public partial class SearchTrainCourseBack : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["operation"] != null
                && Request.QueryString["operation"] == "FeedBackExport")
            {
                int courseID;
                if (Request.QueryString["courseID"] != null
                    && int.TryParse(Request.QueryString["courseID"],out courseID))
                {
                    FeedBackExport(courseID);
                }
                return;
            }
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A801))
            {
                throw new ApplicationException("没有权限访问");
            }
            TrainCourseBackSearchPresenter presenter = new TrainCourseBackSearchPresenter(TrainCourseBackSearch1, LoginUser);
            TrainCourseBackSearch1.SearchEvent += presenter.SearchEvent;
            presenter.Init(Page.IsPostBack);
        }


            
        private void FeedBackExport(int courseID)
        {
            string filename =
                InstanceFactory.CreateTrainFacade().ExportFeedBackResult(courseID,
                                                                         Server.MapPath(
                                                                             ConstParameters.Template_FeedBackReportDoc));
            Export(filename);
        }

        private void Export(string filename)
        {
            if (string.IsNullOrEmpty(filename) || !File.Exists(filename))
            {
                Response.Write("<script>alert('导出失败');history.go(-1);</script>");
                Response.Flush();
                Response.End();
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
