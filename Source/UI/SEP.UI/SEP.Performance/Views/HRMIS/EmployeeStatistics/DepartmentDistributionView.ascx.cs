using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using SEP.Model.Departments;

namespace SEP.Performance.Views.EmployeeStatistics
{
    public partial class DepartmentDistributionView : UserControl, IDepartmentDistributionView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvDepartmentDistribution_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            HiddenField hfIndexFromRoot = e.Row.FindControl("hfIndexFromRoot") as HiddenField;
            HiddenField hfHasChild = e.Row.FindControl("hfHasChild") as HiddenField;
            HtmlImage imgTree = e.Row.FindControl("imgTree") as HtmlImage;
            if (hfIndexFromRoot != null && imgTree != null&& hfHasChild!=null)
            {
                e.Row.ID = hfIndexFromRoot.Value;
                e.Row.Style["display"] = "block";
                imgTree.Attributes["onclick"] = "ExpandOrShrinkTree('" + e.Row.ClientID + "','imgTree');";
                imgTree.Style["margin"] = " 0px 0px 0px " + hfIndexFromRoot.Value.Split('_').Length*15 + "px";
                if(Convert.ToBoolean((hfHasChild.Value.ToLower())))
                {
                    imgTree.Src = "../../Pages/image/jian.gif";
                }
                else
                {
                    imgTree.Src = "../../Pages/image/xian.gif";
                }
            }
        }

        public List<Department> DepartmentDistribution
        {
            set
            {
                List<Department> newDepartment = new List<Department>();
                GenerateTreeStruct(value, newDepartment, 0, "");
                gvDepartmentDistribution.DataSource = newDepartment;
                gvDepartmentDistribution.DataBind();
                if (value.Count == 0)
                {
                    trSearch.Style["display"] = "none";
                }
                else
                {
                    trSearch.Style["display"] = "";
                }
            }
        }
        /// <summary>
        /// 递归，重新组织列表结构为树形结构
        /// </summary>
        /// <param name="oldDepartment"></param>
        /// <param name="newDepartment"></param>
        /// <param name="parentID"></param>
        /// <param name="parentIndex"></param>
        private static bool GenerateTreeStruct(List<Department> oldDepartment, List<Department> newDepartment, int parentID, string parentIndex)
        {
            if (oldDepartment == null || newDepartment == null)
            {
                throw new ArgumentNullException();
            }
            int i = 1;
            bool retHasChild = false;//父亲是否有孩子
            foreach (Department department in oldDepartment)
            {
                if (department.ParentDepartment.DepartmentID == parentID)
                {
                    department.IndexFromRoot = parentIndex + "_" + i++;
                    newDepartment.Add(department);
                    retHasChild = true;
                    //递归找孩子
                    //department.HasChild =
                    //    GenerateTreeStruct(oldDepartment, newDepartment, department.DepartmentID,
                    //                       department.IndexFromRoot);
                }
            }
            return retHasChild;
        }
    }
}