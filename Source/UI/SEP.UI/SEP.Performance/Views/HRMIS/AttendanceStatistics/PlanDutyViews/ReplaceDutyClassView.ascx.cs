using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.PlanDutyViews
{
    public partial class ReplaceDutyClassView : UserControl, IReplaceDutyClassView
    {
        private List<DutyClass> _DutyClassList;

        public List<DutyClass> DutyClassList
        {
            set { _DutyClassList = value; }
        }

        public string Message
        {
            set
            {
                lblMessage.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    tbMessage.Style["display"] = "none";
                }
                else
                {
                    tbMessage.Style["display"] = "block";
                }
            }
            get { return lblMessage.Text; }
        }

        public string From
        {
            get { return dtpScopeFrom.Text; }
            set { dtpScopeFrom.Text = value; }
        }

        public string To
        {
            get { return dtpScopeTo.Text; }
            set { dtpScopeTo.Text = value; }
        }

        /// <summary>
        /// 新旧班别替换列表
        /// </summary>
        public List<DutyClassReplace> DutyClassReplaceList
        {
            get
            {
                List<DutyClassReplace> dutyClassReplaceList;
                if (ViewState["_DutyClassReplaceList"] != null)
                {
                    dutyClassReplaceList =
                        (List<DutyClassReplace>) ViewState["_DutyClassReplaceList"];
                    //GetGridViewValue(dutyClassReplaceList);
                }
                else
                {
                    dutyClassReplaceList = new List<DutyClassReplace>();
                }
                return dutyClassReplaceList;
            }
            set
            {
                ViewState["_DutyClassReplaceList"] = value;
                gvReplaceDutyClassList.DataSource = value;
                gvReplaceDutyClassList.DataBind();

                if (value == null || value.Count == 0)
                {
                    divReplaceDutyClassList.Style["display"] = "none";
                }
                else
                {
                    divReplaceDutyClassList.Style["display"] = "block";
                    if (_DutyClassList != null && _DutyClassList.Count > 0)
                    {
                        SetGridViewDisplay(value);
                    }
                }
            }
        }

        /// <summary>
        /// 替换
        /// </summary>
        public event Delegate2Parameter BtnReplaceEvent;

        public event DelegateNoParameter BtnddSelectedIndexChangedEvent;
        public event DelegateNoParameter DataBindEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Attributes["onclick"] = "return CloseModalPopupExtender('divMPEReplaceDutyClassView');";
        }

        protected void gvReplaceDutyClassList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }

        //private void GetGridViewValue(IList<DutyClassReplace> dutyClassReplaceList)
        //{
        //    for (int i = 0; i < dutyClassReplaceList.Count; i++)
        //    {
        //        DropDownList ddlReplaceDutyClass =
        //            (DropDownList)gvReplaceDutyClassList.Rows[i].FindControl("ddlReplaceDutyClassList");
        //        if (ddlReplaceDutyClass != null)
        //        {
        //            dutyClassReplaceList[i].NewDutyClassID = Convert.ToInt32(ddlReplaceDutyClass.SelectedValue);
        //        }
        //    }
        //}
        private void SetGridViewDisplay(IList<DutyClassReplace> dutyClassReplaceList)
        {
            for (int i = 0; i < gvReplaceDutyClassList.Rows.Count; i++)
            {
                SetGridViewRowddlReplaceDutyClassDisplay(i, dutyClassReplaceList);
            }
        }

        private void SetGridViewRowddlReplaceDutyClassDisplay(int rowIndex, IList<DutyClassReplace> dutyClassReplaceList)
        {
            DropDownList ddlReplaceDutyClass =
                (DropDownList) gvReplaceDutyClassList.Rows[rowIndex].FindControl("ddlReplaceDutyClassList");
            if (ddlReplaceDutyClass == null)
            {
                return;
            }
            //_AccountSetPara Copy to accountSetPara

            ddlReplaceDutyClass.DataSource = _DutyClassList;
            ddlReplaceDutyClass.DataValueField = "DutyClassID";
            ddlReplaceDutyClass.DataTextField = "DutyClassName";
            ddlReplaceDutyClass.DataBind();
            ddlReplaceDutyClass.SelectedValue =
                dutyClassReplaceList[rowIndex + PageIndex*gvReplaceDutyClassList.PageSize].NewDutyClassID.ToString();
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (BtnReplaceEvent == null)
            {
                return;
            }
            BtnReplaceEvent(dtpScopeFrom.Text, dtpScopeTo.Text);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlReplaceDutyClass = sender as DropDownList;
            if (ddlReplaceDutyClass == null)
            {
                return;
            }
            List<DutyClassReplace> dutyClassReplaceList =
                (List<DutyClassReplace>) ViewState["_DutyClassReplaceList"];
            GridViewRow row = ddlReplaceDutyClass.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            dutyClassReplaceList[row.RowIndex + PageIndex*gvReplaceDutyClassList.PageSize].NewDutyClassID =
                Convert.ToInt32(ddlReplaceDutyClass.SelectedValue);
            ViewState["_DutyClassReplaceList"] = dutyClassReplaceList;
            if (BtnddSelectedIndexChangedEvent != null)
            {
                BtnddSelectedIndexChangedEvent();
            }
        }

        protected void gvReplaceDutyClassList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReplaceDutyClassList.PageIndex = e.NewPageIndex;
            PageIndex = e.NewPageIndex;
            if (DataBindEvent != null)
            {
                DataBindEvent();
            }
            gvReplaceDutyClassList.DataSource = DutyClassReplaceList;
            gvReplaceDutyClassList.DataBind();

            if (DutyClassReplaceList == null || DutyClassReplaceList.Count == 0)
            {
                divReplaceDutyClassList.Style["display"] = "none";
            }
            else
            {
                divReplaceDutyClassList.Style["display"] = "block";
                if (_DutyClassList != null && _DutyClassList.Count > 0)
                {
                    SetGridViewDisplay(ViewState["_DutyClassReplaceList"] as List<DutyClassReplace>);
                }
            }
        }

        private int PageIndex
        {
            get { return Convert.ToInt32(ViewState["PageIndex"]); }
            set { ViewState["PageIndex"] = value; }
        }
    }
}