using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.IBll;
using SEP.Model.Positions;

namespace SEP.Performance.Views.HRMIS.PositionApplications
{
    public partial class HrPositionApplicationView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsCallback)
            {
                //ddlGrade.DataSource = BllInstance.PositionBllInstance.GetAllPositionGrade();
                //ddlGrade.DataValueField = "Id";
                //ddlGrade.DataTextField = "Name";
                //ddlGrade.DataBind();

                ddlPositionStatus.DataSource = PositionStatus.AllPositionStatus;
                ddlPositionStatus.DataValueField = "Id";
                ddlPositionStatus.DataTextField = "Name";
                ddlPositionStatus.DataBind();
                ddlPositionStatus.SelectedValue = PositionStatus.Publish.Id.ToString();

                ddlIsPublishSearch.Items.Add(new ListItem("", "-1"));
                ddlIsPublishSearch.Items.Add(new ListItem("未发布", "0"));
                ddlIsPublishSearch.Items.Add(new ListItem("已发布", "1"));
                ddlIsPublishSearch.SelectedValue = "0";

                ddlStatusSearch.Items.Add(new ListItem("", "-1"));
                ddlStatusSearch.Items.Add(new ListItem("进行中", "0"));
                ddlStatusSearch.Items.Add(new ListItem("审核通过", "1"));
                ddlStatusSearch.Items.Add(new ListItem("审核拒绝", "2"));
                ddlStatusSearch.SelectedValue = "1";

                List<PositionNature> PositionNatures = BllInstance.PositionBllInstance.GetAllPositionNature();
                for (int i = 0; i < PositionNatures.Count; i++)
                {
                    ListItem li = new ListItem(PositionNatures[i].Name, PositionNatures[i].Pkid.ToString());
                    li.Attributes["val"] = PositionNatures[i].Pkid.ToString();
                    li.Attributes["text"] = PositionNatures[i].Name;
                    li.Attributes["type"] = "checkbox";
                    cblNature.Items.Add(li);
                }
                ChooseAccountView1.PowerID = "-1";
                ChooseAccountView1.ChooseAccountTitle = "适用员工";
            }
        }
    }
}