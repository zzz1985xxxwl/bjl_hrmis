using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;
using SEP.Presenter.Core;
using SEP.HRMIS.Model.PayModule;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Performance;
using Button = System.Web.UI.WebControls.Button;

namespace SEP.Performance.Views.HRMIS.PayModuleViews
{
    public partial class SetEmployeeAccountListSet : UserControl, ISetEmployeeAccountSetListPresenter
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        public string EmployeeStatusId
        {
            get
            {
                return ddlEmployeeStatus.SelectedValue;
            }
        }
        protected void LinkButtonGoPage_Click(int pageindex)
        {
            grvcontractlist.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grvcontractlist, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        private readonly int _All = -1;

        public event DelegateNoParameter BtnSearchEvent;
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BtnSearchEvent();
        }

        protected void grvcontractlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BtnSearchEvent();
            grvcontractlist.PageIndex = e.NewPageIndex;
            grvcontractlist.DataSource = _EmployeeAccountSetList;
            grvcontractlist.DataBind();
        }

        protected void grvcontractlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }

        public event CommandEventHandler BtnUpdateEvent;
        public event CommandEventHandler BtnAdjustSalaryHistoryEvent;
        public event CommandEventHandler BtnEmployeeSalaryHistoryEvent;
        protected void Update_Command(object sender, CommandEventArgs e)
        {
            BtnUpdateEvent(sender, e);
        }

        public string ResultMessage
        {
            set
            {
                lblMessage.Text = value;
            }
        }

        public bool RecursionDepartment
        {
            get { return cbRecursionDepartment.Checked; }
        }
        public string EmployeeName
        {
            get { return txtName.Text.Trim(); }
        }

        public string EmployeeType
        {
            get
            {
                return listEmployeeType.SelectedValue;
            }
            set
            {
                listEmployeeType.SelectedIndex = Convert.ToInt32(value);
            }
        }

        public Dictionary<string, string> EmployeeTypeSource
        {
            set
            {
                listEmployeeType.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, _All.ToString(), true);
                listEmployeeType.Items.Add(itemAll);
                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    listEmployeeType.Items.Add(item);
                }
            }
        }

        public int PositionId
        {
            get
            {
                return Convert.ToInt32(listPosition.SelectedValue);
            }
        }

        public List<Position> PositionSource
        {
            set
            {
                listPosition.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, _All.ToString(), true);
                listPosition.Items.Add(itemAll);
                foreach (Position position in value)
                {
                    ListItem item = new ListItem(position.Name, position.ParameterID.ToString(), true);
                    listPosition.Items.Add(item);
                }
            }
        }

        public List<Department> DepartmentSource
        {
            set
            {
                listDepartment.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, _All.ToString(), true);
                listDepartment.Items.Add(itemAll);
                foreach (Department department in value)
                {
                    ListItem item = new ListItem(department.DepartmentName, department.DepartmentID.ToString(), true);
                    listDepartment.Items.Add(item);
                }
            }
        }

        public int DepartmentId
        {
            get { return Convert.ToInt32(listDepartment.SelectedValue); }
        }

        private List<EmployeeSalary> _EmployeeAccountSetList;
        public List<EmployeeSalary> EmployeeAccountSetList
        {
            set
            {
                _EmployeeAccountSetList = value;
                grvcontractlist.DataSource = value;
                grvcontractlist.DataBind();
                tbEmployeeGridView.Style["display"] = value.Count > 0 ? "block" : "none";
            }
        }

        protected void EmployeeSalaryHistory_Command(object sender, CommandEventArgs e)
        {
            BtnEmployeeSalaryHistoryEvent(sender, e);
        }

        protected void AdjustSalaryHistory_Command(object sender, CommandEventArgs e)
        {
            BtnAdjustSalaryHistoryEvent(sender, e);
        }


        protected void btnInport_Click(object sender, EventArgs e)
        {
            Import();
        }

        public event DelegateID ImportEvent;

        private void Import()
        {
            string uploadFileLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
            if (!Directory.Exists(uploadFileLocation))
            {
                Directory.CreateDirectory(uploadFileLocation);
            }
            HttpPostedFile hpf = fuExcel.PostedFile;
            if (hpf != null)
            {
                string filename = Path.GetFileName(hpf.FileName);
                string fileExt = Path.GetExtension(hpf.FileName);
                string filePath = uploadFileLocation + "\\" + (Guid.NewGuid().ToString()) + ".xls";
                if (Validation(filename, fileExt))
                {
                    hpf.SaveAs(filePath);
                    if (ImportEvent != null)
                    {
                        ImportEvent(filePath);
                    }
                }
            }
        }

        private bool Validation(string filename, string fileExt)
        {
            if (!string.IsNullOrEmpty(filename.Trim()))
            {
                if (fileExt == ".xls" || fileExt == ".xlsx")
                {
                    return true;
                }
                lblMessage.Text = "<span class='fontred'>导入的文件格式错误</span>";
                return false;
            }
            lblMessage.Text = "<span class='fontred'>没有要导入的文件</span>";
            return false;
        }

    }
}