using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;
using SEP.Model.SpecialDates;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.PlanDutyViews
{
    public partial class SetPlanDutyView : UserControl, ISetPlanDutyView
    {
        #region 
        private const string _WorkText = "工作";
        private const string _RestText = "休息";

        private const string _Id = "Id";
        private const string _SpecialDate = "SpecialDate";
        private const string _SpecialDescription = "SpecialDescription";
        private const string _SpecialHeader = "SpecialHeader";
        private const string _SpecialBackColor = "SpecialBackColor";
        private const string _SpecialForeColor = "SpecialForeColor";
        private const string _SpecialIsWork = "SpecialIsWork";

        private const string _PlanDutyDate = "PlanDutyDate";
        private const string _PlanDutyDescription = "PlanDutyDescription";
        private const string _PlanDutySelectValue = "PlanDutySelectValue";
        private const string _PlanDutyBackColor = "PlanDutyBackColor";
        private const string _PlanDutyForeColor = "PlanDutyForeColor";
        private const string _PlanDutyIsWork = "PlanDutyIsWork";

        private const string _PlanDutyItem = "PlanDutyItem";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowCalendar(Convert.ToDateTime(CurrentDay));
            }
            Calendar1.WorkText = _WorkText;
            Calendar1.RestText = _RestText;
            Calendar1.SpecialDateColumnName = _SpecialDate;
            Calendar1.SpecialDescriptionColumnName = _SpecialDescription;
            Calendar1.SpecialHeaderColumnName = _SpecialHeader;
            Calendar1.SpecialBackColorName = _SpecialBackColor;
            Calendar1.SpecialForeColorName = _SpecialForeColor;
            Calendar1.SpecialIsWork = _SpecialIsWork;

            Calendar1.PlanDutyDateColumnName = _PlanDutyDate;
            Calendar1.PlanDutyDescriptionColumnName = _PlanDutyDescription;
            Calendar1.PlanDutySelectValue = _PlanDutySelectValue;
            Calendar1.PlanDutyBackColorName = _PlanDutyBackColor;
            Calendar1.PlanDutyForeColorName = _PlanDutyForeColor;
            Calendar1.PlanDutyIsWork = _PlanDutyIsWork;
        }
        public string OperationTitle
        {
            get { return lblOperationTitle.Text.Trim(); }
            set { lblOperationTitle.Text = value; }
        }
        public bool SetFormReadOnly
        {
            set
            {
                txtEmployeeList.ReadOnly = value;
                txtPeriod.ReadOnly = value;
                txtPlanDutyName.ReadOnly = value;
                dtpScopeFrom.ReadOnly = value;
                dtpScopeTo.ReadOnly = value;
                btnCreatePlanDuty.Visible = !value;
                btnDutyClassDisplace.Visible = !value;
                btnPlasterPlanDuty.Visible = !value;
                Calendar1.IsReadOnly = value;
            }
        }
        public void SetPlanDutyTableByViewState(DateTime dt)
        {
            if (ViewState[dt.Year + ";" + dt.Month] != null)
            {
                SetPlanDutyTable((List<PlanDutyDetail>)ViewState[dt.Year + ";" + dt.Month]);
            }
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
            get
            {
                return lblMessage.Text;
            }
        }
        public string PlanDutyID
        {
            get { return lblPlanDutyID.Value; }
            set { lblPlanDutyID.Value = value; }
        }
        public string PlanDutyTableName
        {
            get { return txtPlanDutyName.Text; }
            set { txtPlanDutyName.Text = value; }
        }
        public string FromTime
        {
            get { return dtpScopeFrom.Text; }
            set { dtpScopeFrom.Text = value; }
        }
        public string ToTime
        {
            get { return dtpScopeTo.Text; }
            set { dtpScopeTo.Text = value; }
        }
        public string Period
        {
            get { return txtPeriod.Text; }
            set { txtPeriod.Text = value; }
        }
        public string EmployeeList
        {
            get { return txtEmployeeList.Text; }
            set { txtEmployeeList.Text = value; }
        }

        public string PlanDutyNameMessage
        {
            get { return lblPlanDutyNameMessage.Text; }
            set { lblPlanDutyNameMessage.Text = value; }
        }
        public string TimeMessage
        {
            get { return lblTimeMessage.Text; }
            set { lblTimeMessage.Text = value; }
        }
        public string PeriodMessage
        {
            get { return lblPeriodMessage.Text; }
            set { lblPeriodMessage.Text = value; }
        }
        public DateTime CurrentDay
        {
            get
            {
                return Convert.ToDateTime(lblCurrentDay.Value);
            }
            set
            {
                lblCurrentDay.Value = value.ToString();
                Calendar1.VisibleDate = value;
                Calendar1.SelectedDate = value;
                lblYearMonth.Text = value.Year + "-" + value.Month;
            }
        }

        public List<PlanDutyDetail> GetViewState(string viewStateName)
        {
            if (ViewState[viewStateName] != null)
                return (List<PlanDutyDetail>) ViewState[viewStateName];
            else
                return null;
        }

        public List<PlanDutyDetail> PlanDutyDateSource
        {
            get
            {
                return new List<PlanDutyDetail>();
            }
            set
            {
                SetPlanDutyTable(value);
            }
        }
        public List<PlanDutyDetail> GetCurrentPlanDutyDetailList(DateTime dt)
        {
            List<PlanDutyDetail> planDutyDetailList=new List<PlanDutyDetail>();
            DateTime monthFrom = dt.AddDays(1 - dt.Day);
            DateTime monthTo = dt.AddDays(1 - dt.Day).AddMonths(1).AddDays(-1);
            DateTime temp = monthFrom;
            while (DateTime.Compare(temp, monthTo) <= 0)
            {
                String[] sDateList = Request.Form.GetValues(temp.Year + "-" + temp.Month + "-" + temp.Day);
                
                PlanDutyDetail planDutyDetail = new PlanDutyDetail();
                planDutyDetail.Date = temp;
                planDutyDetail.PlanDutyClass = new DutyClass();
                if (sDateList!=null)
                {
                    planDutyDetail.PlanDutyClass.DutyClassID = Convert.ToInt32(sDateList[0]);
                }
                else
                {
                    return null;
                }
                planDutyDetailList.Add(planDutyDetail);
                temp = temp.AddDays(1);
            }
            return planDutyDetailList;
        }
        private void SetPlanDutyTable(IList<PlanDutyDetail> planDutyDetailList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(_Id, Type.GetType("System.Int32"));
            dt.Columns.Add(_PlanDutyDate, Type.GetType("System.DateTime"));
            dt.Columns.Add(_PlanDutyDescription, Type.GetType("System.String"));
            dt.Columns.Add(_PlanDutySelectValue, Type.GetType("System.String"));
            dt.Columns.Add(_PlanDutyForeColor, Type.GetType("System.String"));
            dt.Columns.Add(_PlanDutyBackColor, Type.GetType("System.String"));
            dt.Columns.Add(_PlanDutyIsWork, Type.GetType("System.String"));
            for (int i = 0; i < planDutyDetailList.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[_Id] = planDutyDetailList[i].PlanDutyDetailID;
                dr[_PlanDutyDate] = planDutyDetailList[i].Date;
                dr[_PlanDutyDescription] = planDutyDetailList[i].PlanDutyClass.DutyClassName;
                dr[_PlanDutySelectValue] = planDutyDetailList[i].PlanDutyClass.DutyClassID;
                dr[_PlanDutyForeColor] = "black";
                dr[_PlanDutyBackColor] = "white";
                dr[_PlanDutyIsWork] = 
                    planDutyDetailList[i].PlanDutyClass.DutyClassID == 0 ? "0" : "1";
                dt.Rows.Add(dr);
            }
            if (Calendar1.PlanDutyDateSource != null)
            {
                Calendar1.PlanDutyDateSource.Clear();
            }
            Calendar1.PlanDutyDateSource = dt;
        }

        public List<DutyClass> DutyClassList
        {
            get
            {
                return new List<DutyClass>();//Calendar1.SpecialDateSource;
            }
            set
            {
                GetDutyClass(value);
            }
        }

        private void GetDutyClass(IList<DutyClass> dutyClassList)
        {
            DataTable dtPlanDutyListDateSource = new DataTable();
            dtPlanDutyListDateSource.Columns.Add(_Id, Type.GetType("System.Int32"));
            dtPlanDutyListDateSource.Columns.Add(_PlanDutyItem, Type.GetType("System.String"));
            DataRow dr = dtPlanDutyListDateSource.NewRow();
            dr[_Id] = -1;
            dr[_PlanDutyItem] = "休息";
            dtPlanDutyListDateSource.Rows.Add(dr);

            for (int i = 0; i < dutyClassList.Count; i++)
            {
                dr = dtPlanDutyListDateSource.NewRow();
                dr[_Id] = dutyClassList[i].DutyClassID;
                dr[_PlanDutyItem] = dutyClassList[i].DutyClassName;
                dtPlanDutyListDateSource.Rows.Add(dr);
            }
            if (Calendar1.PlanDutyListDateSource != null)
            {
                Calendar1.PlanDutyListDateSource.Clear();
            }
            Calendar1.PlanDutyListDateSource = dtPlanDutyListDateSource;
        }

        private void GetSpecialDate(IList<SpecialDate> specialDates)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(_Id, Type.GetType("System.Int32"));
            dt.Columns.Add(_SpecialDate, Type.GetType("System.DateTime"));
            dt.Columns.Add(_SpecialHeader, Type.GetType("System.String"));
            dt.Columns.Add(_SpecialDescription, Type.GetType("System.String"));
            dt.Columns.Add(_SpecialForeColor, Type.GetType("System.String"));
            dt.Columns.Add(_SpecialBackColor, Type.GetType("System.String"));
            dt.Columns.Add(_SpecialIsWork, Type.GetType("System.String"));
            for (int i = 0; i < specialDates.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[_Id] = specialDates[i].SpecialDateID;
                dr[_SpecialDate] = specialDates[i].SpecialDateTime;
                dr[_SpecialHeader] = specialDates[i].SpecialHeader;
                dr[_SpecialDescription] = specialDates[i].SpecialDescription;
                dr[_SpecialForeColor] = specialDates[i].SpecialForeColor;
                dr[_SpecialBackColor] = specialDates[i].SpecialBackColor;
                dr[_SpecialIsWork] = specialDates[i].IsWork;
                dt.Rows.Add(dr);
            }
            if (Calendar1.SpecialDateSource != null)
            {
                Calendar1.SpecialDateSource.Clear();
            }
            Calendar1.SpecialDateSource = dt;
        }

        public List<SpecialDate> SpecialDates
        {
            get
            {
                return new List<SpecialDate>();//Calendar1.SpecialDateSource;
            }
            set
            {
                GetSpecialDate(value);
            }
        }

        public event DelegateNoParameter CreatePlanDutyClick;
        public event Delegate2Parameter DutyClassDisplaceClick;
        public event DelegateID ChangeMonthClick;
        public event DelegateNoParameter btnCopyEvent;
        public event DelegateNoParameter btnPasteEvent;

        public void SetSomePlanDutyTableViewState()
        {
            if (ViewState["SomePlanDutyTable"] != null)
            {
               string[] somePlanDutyTable=(string[]) ViewState["SomePlanDutyTable"];
               txtPlanDutyName.Text = somePlanDutyTable[0];
               dtpScopeFrom.Text = somePlanDutyTable[1];
               dtpScopeTo.Text = somePlanDutyTable[2];
               txtPeriod.Text = somePlanDutyTable[3];
               txtEmployeeList.Text = somePlanDutyTable[4];
            }
        }
        public void SavePlanDutyDetailListViewState(List<PlanDutyDetail> planDutyDetailLis,string viewStateName)
        {
            ViewState[viewStateName] = planDutyDetailLis;
        }
        public PlanDutyTable SessionCopyPlanDutyTable
        {
            get 
            {
                if (Session[PlanDutyUtility.SessionCopyPlanDutyTable]==null)
                {
                    return null;
                }
                return Session[PlanDutyUtility.SessionCopyPlanDutyTable] as PlanDutyTable;
            }
            set
            {
                if (value != null)
                {
                    Session[PlanDutyUtility.SessionCopyPlanDutyTable] = value;
                }
                if (OperationTitle == PlanDutyUtility.AddPageTitle ||
    OperationTitle == PlanDutyUtility.UpdatePageTitle)
                {
                    SetbtnPlasterPlanDuty = value == null ? false : true;
                }

            }
        }
        public bool SetbtnPlasterPlanDuty
        {
            set { btnPlasterPlanDuty.Visible = value; }
        }

        private void ShowCalendar(DateTime dt)
        {
            CurrentDay = dt;
            if (ChangeMonthClick == null)
            {
                return;
            }
            ChangeMonthClick(dt.ToShortDateString());
        }
        public void SaveViewState(DateTime dt)
        {
            ViewState[dt.Year + ";" + dt.Month] = GetCurrentPlanDutyDetailList(dt);
            string[] somePlanDutyTable = new string[5];
            somePlanDutyTable[0] = txtPlanDutyName.Text;
            somePlanDutyTable[1] = dtpScopeFrom.Text;
            somePlanDutyTable[2] = dtpScopeTo.Text;
            somePlanDutyTable[3] = txtPeriod.Text;
            somePlanDutyTable[4] = txtEmployeeList.Text;
            ViewState["SomePlanDutyTable"] = somePlanDutyTable;
        }
        protected void IbtnLast_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dt = Calendar1.SelectedDate;
            SaveViewState(dt);
            ShowCalendar(dt.AddMonths(-1));
        }

        protected void IBtnNext_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dt = Calendar1.SelectedDate;
            SaveViewState(dt);
            ShowCalendar(dt.AddMonths(1));
        }

        protected void btnDutyClassDisplace_Click(object sender, EventArgs e)
        {
            if (DutyClassDisplaceClick == null)
            {
                return;
            }
            DutyClassDisplaceClick(dtpScopeFrom.Text,dtpScopeTo.Text);
        }

        protected void btnCopyPlanDuty_Click(object sender, EventArgs e)
        {
            if (btnCopyEvent == null)
            {
                return;
            }
            btnCopyEvent();
        }

        protected void btnPlasterPlanDuty_Click(object sender, EventArgs e)
        {
            if (btnPasteEvent == null)
            {
                return;
            }
            btnPasteEvent();
        }

        protected void btnCreatePlanDuty_Click(object sender, EventArgs e)
        {
            if (CreatePlanDutyClick == null)
            {
                return;
            }
            CreatePlanDutyClick();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlanDutyList.aspx?");
        }
    }
}