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
using SEP.IBll;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Presenter;
using SEP.Presenter.IPresenter.IAccounts;
using ShiXin.Security;

namespace SEP.Performance.Views.SEP.Choose
{
    public partial class ChooseAccountView : System.Web.UI.UserControl, IChooseAccountView
    {
        public bool IsReadOnly
        {
            set
            {
                isShowImg.Value = value.ToString();
            }
        }
        public string ChooseAccount
        {
            get { return txtAccount.Value; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Substring(value.Length - 1, 1) == ";")
                {
                    txtAccount.Value = value.Substring(0, value.Length - 1); 
                }
                else
                {
                    txtAccount.Value = value;
                }
            }
        }

        public string PowerID
        {
            set { hpPowerID.Value = value;}
        }
        public string ChooseAccountTitle
        {
            set { lblTitle.Text = value;}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<Department> depts = BllInstance.DepartmentBllInstance.GetAllDepartmentOrderName();
                depts.Insert(0, new Department(-1, ""));
                ddlDepartment.DataSource = depts;
                ddlDepartment.DataValueField = "Id";
                ddlDepartment.DataTextField = "Name";
                ddlDepartment.DataBind();

                List<Position> positions = BllInstance.PositionBllInstance.GetAllPosition();
                positions.Insert(0, new Position(-1, "", new PositionGrade()));
                ddlPosition.DataSource = positions;
                ddlPosition.DataValueField = "Id";
                ddlPosition.DataTextField = "Name";
                ddlPosition.DataBind();
            }
        }

    }
}