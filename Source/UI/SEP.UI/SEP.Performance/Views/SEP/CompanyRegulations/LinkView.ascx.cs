using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SEP.Model.Utility;

namespace SEP.Performance.Views.SEP.CompanyRegulations
{
    public partial class LinkView : System.Web.UI.UserControl
    {
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //新员工指南
            Response.Redirect("NewEmployeeGuide.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //制度流程
            Response.Redirect("RegulationProcess.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //薪酬福利
            Response.Redirect("Welfare.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            //培训发展
            Response.Redirect("Training.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            //绩效考核
            Response.Redirect("EffectAssess.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            //FAQS
            Response.Redirect("FAQS.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyFrame.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!CompanyConfig.HasHrmisSystem)
            {
                lCompanyFrame.Visible = false;
            }
        }
    }
}