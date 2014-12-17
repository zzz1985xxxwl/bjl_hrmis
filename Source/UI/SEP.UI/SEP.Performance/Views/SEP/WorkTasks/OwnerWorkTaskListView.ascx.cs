using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.Model;
namespace SEP.Performance.Views.SEP.WorkTasks
{
    public partial class OwnerWorkTaskListView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsCallback)
            {
                ownerList_Priority.DataSource = WTPriority.AllWTPriority;
                ownerList_Priority.DataValueField = "Id";
                ownerList_Priority.DataTextField = "Name";
                ownerList_Priority.DataBind();

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
                    ownerList_Status.Items.Add(li);
                }
            }
        }
    }
}