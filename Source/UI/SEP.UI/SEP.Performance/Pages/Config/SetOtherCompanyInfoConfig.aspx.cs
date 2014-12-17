using System;
using System.Web;
using System.Xml;

namespace SEP.Performance.Pages.Config
{
    public partial class SetOtherCompanyInfoConfig : System.Web.UI.Page
    {
        private readonly string _CompanyFilePath = HttpContext.Current.Request.PhysicalApplicationPath + @"\Company.config";
        private string _FilePath;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fAppAddress.Value))
            {
                ViewState["SetOtherCompanyInfoConfig_FilePath"] = fAppAddress.Value;
            }
            else
            {
                ViewState["SetOtherCompanyInfoConfig_FilePath"] = ViewState["SetOtherCompanyInfoConfig_FilePath"] ?? string.Empty;
            }
            _FilePath = Convert.ToString(ViewState["SetOtherCompanyInfoConfig_FilePath"]);
            Message = "";
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SetAutoRemindConfig.aspx");
        }

        private string Message
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    lbMessage.Style["display"] = "none";
                }
                else
                {
                    lbMessage.Text = value;
                    lbMessage.Style["display"] = "block";
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                XmlDocument webconfigDoc = new XmlDocument();
                webconfigDoc.Load(_FilePath);
                CompanyInfoView1.SetCompanyInfo(webconfigDoc);

                //保存设置
                webconfigDoc.Save(_FilePath);
                Message = "保存成功";
                NextPage();
            }
            else
            {
                Message = "保存失败";
            }
        }
        private void NextPage()
        {
            Response.Redirect("ConfigEnd.aspx");
        }

        private bool CheckValidation()
        {
            bool iRet = true;

            if (string.IsNullOrEmpty(_FilePath))
            {
                lbLoadMessage.Text = "请选择一个App.Config";
                iRet = false;
            }
            else
            {
                lbLoadMessage.Text = "";
            }
            return iRet;
        }
        protected void btnLoadInfo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_FilePath))
            {
                XmlDocument webconfigDoc = new XmlDocument();
                webconfigDoc.Load(_FilePath);
                CompanyInfoView1.GetCompanyInfo(webconfigDoc);
            }
            else
            {
                lbLoadMessage.Text = "请选择一个App.Config";
            }
        }

        protected void lbCompanyInfoCopy_Click(object sender, EventArgs e)
        {
            XmlDocument webconfigDoc = new XmlDocument();
            webconfigDoc.Load(_CompanyFilePath);

            CompanyInfoView1.GetCompanyInfo(webconfigDoc);
        }

        protected void btnSkip_Click(object sender, EventArgs e)
        {
            NextPage();
        }
    }
}
