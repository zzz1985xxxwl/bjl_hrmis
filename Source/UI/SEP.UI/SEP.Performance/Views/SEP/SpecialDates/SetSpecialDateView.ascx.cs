using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using SEP.Model.SpecialDates;
using SEP.Presenter;
using SEP.Presenter.IPresenter.ISpecialDate;

namespace SEP.Performance.Views.SEP.SpecialDates
{
    public partial class SetSpecialDateView : UserControl, ISpecialDateView
    {
        private const string _WorkText = "¹¤×÷";
        private const string _RestText = "ÐÝÏ¢";

        private const string _Id = "Id";
        private const string _SpecialDate = "SpecialDate";
        private const string _SpecialDescription = "SpecialDescription";
        private const string _SpecialHeader = "SpecialHeader";
        private const string _SpecialBackColor = "SpecialBackColor";
        private const string _SpecialForeColor = "SpecialForeColor";
        private const string _SpecialIsWork = "SpecialIsWork";

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
        }

        private void ShowCalendar(DateTime dt)
        {
            Calendar1.VisibleDate = dt;
            Calendar1.SelectedDate = dt;
            lblYearMonth.Text = dt.Year + "-" + dt.Month;
        }

        public string CurrentDay
        {
            get { return lblCurrentDay.Value; }
            set { lblCurrentDay.Value = value; }
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

        public event DelegateSomeParameter SpecialDateSlection;
        public event DelegateSomeParameter SetNullValue;

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = Calendar1.SelectedDate;
            lblYearMonth.Text = selectedDate.Year + "-" + selectedDate.Month;

            string specialHeader;
            int isWork;
            if (selectedDate.DayOfWeek == DayOfWeek.Saturday ||
     selectedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                specialHeader = Calendar1.RestText;
                isWork = 0;
            }
            else
            {
                specialHeader = Calendar1.WorkText;
                isWork = 1;
            }

            if (Calendar1.SpecialDateSource == null)
            {
                SpecialDateSlection(string.Empty, selectedDate.ToShortDateString(), string.Empty, string.Empty, string.Empty, specialHeader, isWork);
                return;
            }
            foreach (DataRow drSpecialDate in Calendar1.SpecialDateSource.Rows)
                if (selectedDate.Date == (Convert.ToDateTime(drSpecialDate[Calendar1.SpecialDateColumnName])).Date)
                {
                    string specialDateID = drSpecialDate[_Id].ToString();
                    string specialDate =
                        (Convert.ToDateTime(drSpecialDate[Calendar1.SpecialDateColumnName])).ToShortDateString();
                    specialHeader = drSpecialDate[Calendar1.SpecialHeaderColumnName].ToString();
                    string specialDescription = drSpecialDate[Calendar1.SpecialDescriptionColumnName].ToString();
                    isWork = Convert.ToInt32(drSpecialDate[Calendar1.SpecialIsWork]);
                    string specialForeColor = drSpecialDate[Calendar1.SpecialForeColorName].ToString();
                    string specialDateBackColor = drSpecialDate[Calendar1.SpecialBackColorName].ToString();

                    SpecialDateSlection(specialDateID, specialDate, specialDateBackColor,
                        specialDescription, specialForeColor, specialHeader, isWork);

                    return;
                }
            SpecialDateSlection(string.Empty, selectedDate.ToShortDateString(), string.Empty, string.Empty, string.Empty, specialHeader, isWork);
        }

        protected void IbtnLast_Click(object sender, ImageClickEventArgs e)
        {
            ShowCalendar(Calendar1.SelectedDate.AddMonths(-1));
        }

        protected void IBtnNext_Click(object sender, ImageClickEventArgs e)
        {
            ShowCalendar(Calendar1.SelectedDate.AddMonths(1));
        }
    }
}