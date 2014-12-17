using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SEP.Model;

namespace SEP.Performance.Views.SEP.WorkTasks
{
    public partial class OtherWorkTaskListView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsCallback)
            {
                otherList_Priority.DataSource = WTPriority.AllWTPriority;
                otherList_Priority.DataValueField = "Id";
                otherList_Priority.DataTextField = "Name";
                otherList_Priority.DataBind();

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
                    otherList_Status.Items.Add(li);
                }
            }

        }
    }
}