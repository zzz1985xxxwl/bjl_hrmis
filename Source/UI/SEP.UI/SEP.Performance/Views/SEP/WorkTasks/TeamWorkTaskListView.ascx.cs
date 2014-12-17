using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.Model;

namespace SEP.Performance.Views.SEP.WorkTasks
{
    public partial class TeamWorkTaskListView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsCallback)
            {
                teamList_Priority.DataSource = WTPriority.AllWTPriority;
                teamList_Priority.DataValueField = "Id";
                teamList_Priority.DataTextField = "Name";
                teamList_Priority.DataBind();

                List<WTStatus> WTStatuss = WTStatus.GetWTStatus;
                for (int i = 0; i < WTStatuss.Count; i++)
                {
                    ListItem li = new ListItem(WTStatuss[i].Name, WTStatuss[i].Id.ToString());
                    li.Attributes["val"] = WTStatuss[i].Id.ToString();
                    li.Attributes["text"] = WTStatuss[i].Name;
                    li.Attributes["type"] = "checkbox";
                    if (WTStatuss[i].Id != WTStatus.Finish.Id)
                    {
                        li.Selected = true;
                    }
                    teamList_Status.Items.Add(li);
                }
            }
        }

    }
}