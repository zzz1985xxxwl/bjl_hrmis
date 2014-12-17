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
            //��Ա��ָ��
            Response.Redirect("NewEmployeeGuide.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //�ƶ�����
            Response.Redirect("RegulationProcess.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //н�긣��
            Response.Redirect("Welfare.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            //��ѵ��չ
            Response.Redirect("Training.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            //��Ч����
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