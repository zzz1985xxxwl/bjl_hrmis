using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using SEP.Model.Departments;
using SEP.Presenter.Config;

namespace SEP.Performance.Pages.Config
{
    public partial class SetCompanyInfoConfig : System.Web.UI.Page
    {
        private readonly string _CompanyFilePath = HttpContext.Current.Request.PhysicalApplicationPath + @"\Company.config";

        protected void Page_Load(object sender, EventArgs e)
        {
            //加载web.config文件
            if (!Page.IsPostBack)
            {
                XmlDocument webconfigDoc = new XmlDocument();
                webconfigDoc.Load(_CompanyFilePath);
                CompanyInfoView1.GetCompanyInfo(webconfigDoc);
                SetCreateInitDataBtnStatus();
            }
        }

        protected void btnAutoRemindConfig_Click(object sender, EventArgs e)
        {
            //加载web.config文件
            XmlDocument webconfigDoc = new XmlDocument();
            webconfigDoc.Load(_CompanyFilePath);

            CompanyInfoView1.SetCompanyInfo(webconfigDoc);

            //保存设置
            webconfigDoc.Save(_CompanyFilePath);
            Response.Redirect("SetAutoRemindConfig.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SetWebConfig.aspx");
        }

        protected void btnCreateInitData_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateInitData.aspx");
        }
        private void SetCreateInitDataBtnStatus()
        {
            List<Department> departs = new SepDataManage().GetAllDepartment();
            btnCreateInitData.Visible = departs == null || departs.Count == 0;
            btnAutoRemindConfig.Visible = !btnCreateInitData.Visible;
        }
    }
}
