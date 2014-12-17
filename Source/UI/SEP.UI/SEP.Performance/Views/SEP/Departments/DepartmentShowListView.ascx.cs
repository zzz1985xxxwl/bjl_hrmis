using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SEP.Model.Departments;
using SEP.Presenter;
using SEP.Presenter.IPresenter.IDepartments;

namespace SEP.Performance.Views.SEP.Departments
{
    public partial class DepartmentShowListView : UserControl, IDepartmentListView
    {
        #region IDepartmentListView成员

        public event DelegateID BtnAddEvent;
        public event DelegateID BtnUpdateEvent;
        public event DelegateID BtnDeleteEvent;
        public event DelegateID BtnDetailEvent;
        public event DelegateNoParameter BtnSearchEvent;

        public string Message
        {
            get { return lblMessage.Text; }
            set
            {
                lblMessage.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    trMessage.Style["display"] = "none";
                }
                else
                {
                    trMessage.Style["display"] = "block";
                }
            }
        }

        private List<Department> _Departments;

        public List<Department> Departments
        {
            get { return _Departments; }
            set
            {
                _Departments = value;
                gvDepartment.DataSource = _Departments;
                gvDepartment.DataBind();
                if (value.Count == 0)
                {
                    tbDepartment.Style["display"] = "none";
                }
                else
                {
                    tbDepartment.Style["display"] = "block";
                    SetgrdDisplay();
                }
            }
        }

        private void SetgrdDisplay()
        {
            foreach (GridViewRow row in gvDepartment.Rows)
            {
                LinkButton btnDelete = (LinkButton) row.FindControl("btnDelete");
                HiddenField hfHasChild = (HiddenField) row.FindControl("hfHasChild");
                if (btnDelete != null && hfHasChild != null)
                {
                    if (Convert.ToBoolean((hfHasChild.Value.ToLower())))
                    {
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        btnDelete.Enabled = true;
                    }
                }
                Label lblShowOrHide = (Label) row.FindControl("lblShowOrHide");
                HiddenField hfHasMemeber = (HiddenField) row.FindControl("hfHasMemeber");
                if (lblShowOrHide != null && hfHasMemeber != null)
                {
                    if (Convert.ToBoolean((hfHasMemeber.Value.ToLower())))
                    {
                        lblShowOrHide.Visible = true;
                    }
                    else
                    {
                        lblShowOrHide.Visible = false;
                    }
                }
            }
        }

        #endregion

        protected void gvDepartment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            HiddenField hfIndexFromRoot = e.Row.FindControl("hfIndexFromRoot") as HiddenField;
            HiddenField hfHasChild = e.Row.FindControl("hfHasChild") as HiddenField;
            HtmlImage imgTree = e.Row.FindControl("imgTree") as HtmlImage;
            if (hfIndexFromRoot != null && imgTree != null && hfHasChild != null)
            {
                e.Row.ID = hfIndexFromRoot.Value;
                e.Row.Style["display"] = "block";
                imgTree.Attributes["onclick"] = "ExpandOrShrinkTree('" + e.Row.ClientID + "','imgTree');";
                imgTree.Style["margin"] = " 0px 0px 0px " + (hfIndexFromRoot.Value.Split('_').Length - 2)*15 + "px";
                if (Convert.ToBoolean((hfHasChild.Value.ToLower())))
                {
                    imgTree.Src = "../../../Pages/image/jian.gif";
                }
                else
                {
                    imgTree.Src = "../../../Pages/image/xian.gif";
                }
            }
            // 额外样式定义
            ViewUtility.RowMouseOver(e);
        }
    }
}