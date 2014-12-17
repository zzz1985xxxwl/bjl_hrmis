using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SEP.HRMIS.Presenter.IPresenter.IAuth;
using SEP.Model.Departments;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.Auths
{
    public partial class DepartmentTreeView : UserControl, IAssignAuthDepartmentTree
    {
        public string BackAccountsID
        {
            get
            {
                return hfBackAccountsID.Value;
            }
            set
            {
                hfBackAccountsID.Value = value;
            }
        }

        public string AuthID
        {
            get
            {
                return hfAuthID.Value;
            }
            set
            {
                hfAuthID.Value = value;
            }
        }

        private bool _ActionSuccess;
        public bool ActionSuccess
        {
            get
            {
                return _ActionSuccess;
            }
            set
            {
                _ActionSuccess = value;
            }
        }

        public List<Model.Accounts.Auth> AuthSource
        {
            get
            {
                return (List<Model.Accounts.Auth>)Session["_BackAccountsAuth"];
            }
            set
            {
                Session["_BackAccountsAuth"] = value;
            }
        }

        //private static void GenerateTreeStruct(List<Department> oldDepartment, List<Department> newDepartment, int parentID, string parentIndex)
        //{
        //    if (oldDepartment == null || newDepartment == null)
        //    {
        //        throw new ArgumentNullException();
        //    }
        //    int i = 1;
        //    foreach (Department department in oldDepartment)
        //    {
        //        if (department.ParentDepartment == null)
        //        {
        //            continue;
        //        }
        //        else if (department.ParentDepartment.DepartmentID == parentID)
        //        {
        //            department.IndexFromRoot = parentIndex + "_" + i++;
        //            newDepartment.Add(department);
        //            //递归找孩子
        //            //department.HasChild =
        //            GenerateTreeStruct(oldDepartment, newDepartment, department.DepartmentID,
        //                               department.IndexFromRoot);
        //        }
        //    }
        //}

        //private void SetgrdDisplay()
        //{
        //    foreach (GridViewRow row in gvDepartment.Rows)
        //    {
        //        LinkButton btnDelete = (LinkButton)row.FindControl("btnDelete");
        //        HiddenField hfHasChild = (HiddenField)row.FindControl("hfHasChild");
        //        if (btnDelete != null && hfHasChild != null)
        //        {
        //            if (Convert.ToBoolean((hfHasChild.Value.ToLower())))
        //            {
        //                btnDelete.Enabled = false;
        //            }
        //            else
        //            {
        //                btnDelete.Enabled = true;
        //            }
        //        }
        //        Label lblShowOrHide = (Label)row.FindControl("lblShowOrHide");
        //        HiddenField hfHasMemeber = (HiddenField)row.FindControl("hfHasMemeber");
        //        if (lblShowOrHide != null && hfHasMemeber != null)
        //        {
        //            if (Convert.ToBoolean((hfHasMemeber.Value.ToLower())))
        //            {
        //                lblShowOrHide.Visible = true;
        //            }
        //            else
        //            {
        //                lblShowOrHide.Visible = false;
        //            }
        //        }
        //    }
        //}

        public List<Department> DepartmentList
        {
            get
            {
                List<Department> newDepartment = new List<Department>();
                foreach (GridViewRow row in gvDepartment.Rows)
                {
                    HtmlInputCheckBox cb = row.FindControl("cbSelected") as HtmlInputCheckBox;
                    if ((cb != null) && (cb.Checked))
                    {
                        HiddenField ih = row.FindControl("btnHiddenPostButton") as HiddenField;
                        if (ih != null)
                        {
                            newDepartment.Add(new Department(Convert.ToInt32(ih.Value), null, "", null));
                        }
                    }
                }
                return newDepartment;
            }
            set
            {
                //List<Department> newDepartment = new List<Department>();
                //GenerateTreeStruct(value, newDepartment, 0, "");

                //todo Session changed to ViewState
                //Session["newDepartmentSource"] = newDepartment;
                //gvDepartment.DataSource = Session["newDepartmentSource"];
                ViewState["newDepartmentSource"] = value;
                gvDepartment.DataSource = ViewState["newDepartmentSource"];

                gvDepartment.DataBind();
                if (value.Count == 0)
                {
                    tbDepartment.Style["display"] = "none";
                }
                else
                {
                    tbDepartment.Style["display"] = "block";
                    //SetgrdDisplay();
                }
            }
        }

        public event DelegateNoParameter ShowView;
        protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            SetChildChecked(e.Node);
            ShowView();
        }

        private static void SetChildChecked(TreeNode parentNode)
        {
            foreach (TreeNode node in parentNode.ChildNodes)
            {
                node.Checked = parentNode.Checked;
                if (node.ChildNodes.Count > 0)
                {
                    SetChildChecked(node);
                }
            }
        }

        protected void gvDepartment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            HiddenField hfIndexFromRoot = e.Row.FindControl("hfIndexFromRoot") as HiddenField;
            HiddenField hfHasChild = e.Row.FindControl("hfHasChild") as HiddenField;
            HtmlImage imgTree = e.Row.FindControl("imgTree") as HtmlImage;
            HtmlInputCheckBox cbSelected = e.Row.FindControl("cbSelected") as HtmlInputCheckBox;
            if (hfIndexFromRoot != null && imgTree != null && hfHasChild != null && cbSelected != null)
            {
                e.Row.ID = hfIndexFromRoot.Value;
                e.Row.Style["display"] = "block";

                //ViewUtility.RowDataBound(sender, e, new Button(), ViewUtility.MouseStyle_Default,
                //                         Color.FromArgb(
                //                             SetColor(_ColorR, hfIndexFromRoot.Value.Split('_').Length - 2, 15),
                //                             SetColor(_ColorG, hfIndexFromRoot.Value.Split('_').Length - 2, 15),
                //                             SetColor(_ColorB, hfIndexFromRoot.Value.Split('_').Length - 2, 15)));
                imgTree.Attributes["onclick"] = "ExpandOrShrinkTree('" + e.Row.ClientID + "','imgTree');";
                imgTree.Style["margin"] = " 0px 0px 0px " + (hfIndexFromRoot.Value.Split('_').Length - 2) * 15 + "px";
                if (Convert.ToBoolean((hfHasChild.Value.ToLower())))
                {
                    imgTree.Src = "../../../Pages/image/jian.gif";
                }
                else
                {
                    imgTree.Src = "../../../Pages/image/xian.gif";
                }
                cbSelected.Attributes["onclick"] = "SelectedNodeTree('" + e.Row.ClientID + "','cbSelected');";
            }
            // 额外样式定义
            ViewUtility.RowMouseOver(e);
           
        }

        public event DelegateNoParameter SaveClick;
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveClick();
        }
    }
}