using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using SEP.HRMIS.Presenter;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Presenter.Core;
using Label=System.Web.UI.WebControls.Label;

namespace SEP.Performance.Views.HRMIS.DepartmentHistory
{
    public partial class DepartmentHistoryListView : UserControl, IDepartmentHistoryListView
    {
        #region IDepartmentListView成员

        public event DelegateID BtnDetailEvent;
        public event DelegateNoParameter BtnSearchEvent;

        public string SearchTime
        {
            get { return txtSearchTime.Text; }
            set { txtSearchTime.Text = value; }
        }

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
                    trMessage.Style["display"] = "";
                }
            }
        }

        public bool IsShowSearchTime
        {
            set { ShowSearchTime.Visible = value; }
        }

        public string Title
        {
            set { lbl_Title.Text = value; }
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
                    tbDepartment.Style["display"] = "";
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BtnSearchEvent();
        }

        protected void gvDepartment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            HiddenField hfIndexFromRoot = e.Row.FindControl("hfIndexFromRoot") as HiddenField;
            HiddenField hfHasChild = e.Row.FindControl("hfHasChild") as HiddenField;
            HtmlImage imgTree = e.Row.FindControl("imgTree") as HtmlImage;
            if (hfIndexFromRoot != null && imgTree != null && hfHasChild != null)
            {
                e.Row.ID = hfIndexFromRoot.Value;
                e.Row.Style["display"] = "";

                //ViewUtility.RowDataBound(sender, e, new Button(), ViewUtility.MouseStyle_Default,
                //                         Color.FromArgb(
                //                             SetColor(_ColorR, hfIndexFromRoot.Value.Split('_').Length - 2, 15),
                //                             SetColor(_ColorG, hfIndexFromRoot.Value.Split('_').Length - 2, 15),
                //                             SetColor(_ColorB, hfIndexFromRoot.Value.Split('_').Length - 2, 15)));
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            //先查找
            BtnSearchEvent();
            //导出
            GC.Collect();
            Application excelApp = new ApplicationClass();
            Workbook excelBook = excelApp.Workbooks.Add(Type.Missing);
            excelApp.Cells[1, 1] = "部门名称";
            excelApp.Cells[1, 2] = "人数";
            excelApp.Cells[1, 3] = "部门经理";
            excelApp.Cells[1, 4] = "成员";
            for (int i = 0; i < _Departments.Count; i++)
            {
                excelApp.Cells[i + 2, 1] = _Departments[i].DepartmentName;
                excelApp.Cells[i + 2, 2] = _Departments[i].CountEmployee;
                excelApp.Cells[i + 2, 3] = _Departments[i].DepartmentLeader.Name;
                excelApp.Cells[i + 2, 4] = GetMamber(_Departments[i].Members);
            }
            object nothing = Type.Missing;
            object fileFormat = XlFileFormat.xlExcel8;
            object file = Server.MapPath(".") + "\\组织架构.xls";
            if (File.Exists(file.ToString()))
            {
                File.Delete(file.ToString());
            }
            excelBook.SaveAs(file, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange,
                             nothing, nothing, nothing, nothing, nothing);
            excelBook.Close(false, null, null);
            excelApp.Quit();
            Marshal.ReleaseComObject(excelBook);
            Marshal.ReleaseComObject(excelApp);
            GC.Collect();
            OutputExcel("组织架构");
        }

        private void OutputExcel(string filename)
        {
            string path = Server.MapPath(filename + ".xls");
            FileInfo file = new FileInfo(path);
            Response.Clear();
            Response.Charset = "GB2312";
            Response.ContentEncoding = Encoding.UTF8;
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(file.Name));
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/ms-excel";
            Response.WriteFile(file.FullName);
            Response.End();
        }

        private static string GetMamber(IEnumerable<Account> accounts)
        {
            StringBuilder bb = new StringBuilder();
            if (accounts != null)
            {
                foreach (Account account in accounts)
                {
                    bb.AppendFormat("{0};", account.Name);
                }
            }
            return bb.ToString();
        }
    }
}