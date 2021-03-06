using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.IBll;
using SEP.Model.Positions;

namespace SEP.Performance.Views.HRMIS.PositionApplications
{
    public partial class PositionApplicationView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsCallback)
            {
                ddlGrade.DataSource = BllInstance.PositionBllInstance.GetAllPositionGrade();
                ddlGrade.DataValueField = "Id";
                ddlGrade.DataTextField = "Name";
                ddlGrade.DataBind();

                List<PositionNature> PositionNatures = BllInstance.PositionBllInstance.GetAllPositionNature();
                for (int i = 0; i < PositionNatures.Count; i++)
                {
                    ListItem li = new ListItem(PositionNatures[i].Name, PositionNatures[i].Pkid.ToString());
                    li.Attributes["val"] = PositionNatures[i].Pkid.ToString();
                    li.Attributes["text"] = PositionNatures[i].Name;
                    li.Attributes["type"] = "checkbox";
                    cblNature.Items.Add(li);
                }
            }
        }
    }
}