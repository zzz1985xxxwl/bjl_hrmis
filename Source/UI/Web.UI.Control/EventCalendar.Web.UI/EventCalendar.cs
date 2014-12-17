using System;
using System.Data;
using System.Web.UI.WebControls;

namespace EventCalendar.Web.UI
{
    public class EventCalendar: Calendar
    {
        public string WorkText
        {
            get
            {
                if (ViewState["WorkText"] == null)
                    return string.Empty;
                else
                    return (ViewState["WorkText"].ToString());
            }
            set { ViewState["WorkText"] = value; }
        }
        public string RestText
        {
            get
            {
                if (ViewState["RestText"] == null)
                    return string.Empty;
                else
                    return (ViewState["RestText"].ToString());
            }
            set { ViewState["RestText"] = value; }
        }
        #region SpecialCalendar
        // **********************************************************
        // Gets or Sets the Name of source DataTable  
        /// <summary>
        /// If this is specified, then SpecialDate are mandatory
        /// </summary>
        public DataTable SpecialDateSource
        {
            get
            {
                if (ViewState["SpecialDateSource"] == null)
                    return null;
                else
                    return ((DataTable)ViewState["SpecialDateSource"]);
            }
            set { ViewState["SpecialDateSource"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the Date Column in the DataTable
        public string SpecialDateColumnName
        {
            get
            {
                if (ViewState["SpecialDateColumnName"] == null)
                    return string.Empty;
                else
                    return (ViewState["SpecialDateColumnName"].ToString());
            }
            set { ViewState["SpecialDateColumnName"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the Special Header Column Name in the DataTable
        public string SpecialHeaderColumnName
        {
            get
            {
                if (ViewState["SpecialHeaderColumnName"] == null)
                    return string.Empty;
                else
                    return (ViewState["SpecialHeaderColumnName"].ToString());
            }
            set { ViewState["SpecialHeaderColumnName"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the Special Description Column Name in the DataTable
        public string SpecialDescriptionColumnName
        {
            get
            {
                if (ViewState["SpecialDescriptionColumnName"] == null)
                    return string.Empty;
                else
                    return (ViewState["SpecialDescriptionColumnName"].ToString());
            }
            set { ViewState["SpecialDescriptionColumnName"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the Special Back Color Column Name in the DataTable
        public string SpecialBackColorName
        {
            get
            {
                if (ViewState["SpecialBackColorName"] == null)
                    return string.Empty;
                else
                    return (ViewState["SpecialBackColorName"].ToString());
            }
            set { ViewState["SpecialBackColorName"] = value; }
        }
        // **********************************************************
        // **********************************************************
        // Gets or sets the Special Fore Color Column Name in the DataTable
        public string SpecialForeColorName
        {
            get
            {
                if (ViewState["SpecialForeColorName"] == null)
                    return string.Empty;
                else
                    return (ViewState["SpecialForeColorName"].ToString());
            }
            set { ViewState["SpecialForeColorName"] = value; }
        }
        // **********************************************************
        // **********************************************************
        // Gets or sets the 是否工作 in the DataTable
        public string SpecialIsWork
        {
            get
            {
                if (ViewState["SpecialIsWork"] == null)
                    return string.Empty;
                else
                    return (ViewState["SpecialIsWork"]).ToString();
            }
            set { ViewState["SpecialIsWork"] = value; }
        }

        // **********************************************************
        #endregion
        #region Event
        // **********************************************************
        // Gets or Sets the Name of source DataTable  
        /// <summary>
        /// If this is specified, then EventDate and EventHeader are mandatory
        /// </summary>
        public DataTable EventSource
        {
            get
            {
                if (ViewState["EventSource"] == null)
                    return null;
                else
                    return ((DataTable)ViewState["EventSource"]);
            }
            set { ViewState["EventSource"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the Date Column in the DataTable
        public string EventStartDateColumnName
        {
            get
            {
                if (ViewState["StartDateColumnName"] == null)
                    return string.Empty;
                else
                    return (ViewState["StartDateColumnName"].ToString());
            }
            set { ViewState["StartDateColumnName"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the Date Column in the DataTable
        public string EventEndDateColumnName
        {
            get
            {
                if (ViewState["EndDateColumnName"] == null)
                    return string.Empty;
                else
                    return (ViewState["EndDateColumnName"].ToString());
            }
            set { ViewState["EndDateColumnName"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the Event Header Column Name in the DataTable
        public string EventHeaderColumnName
        {
            get
            {
                if (ViewState["EventHeaderColumnName"] == null)
                    return string.Empty;
                else
                    return (ViewState["EventHeaderColumnName"].ToString());
            }
            set { ViewState["EventHeaderColumnName"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the Event Description Column Name in the DataTable
        public string EventDescriptionColumnName
        {
            get
            {
                if (ViewState["EventDescriptionColumnName"] == null)
                    return string.Empty;
                else
                    return (ViewState["EventDescriptionColumnName"].ToString());
            }
            set { ViewState["EventDescriptionColumnName"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the Event Description Column Name in the DataTable
        public bool ShowDescriptionAsToolTip
        {
            get
            {
                if (ViewState["EventDescriptionColumnName"] == null)
                    return true;
                else
                    return (Convert.ToBoolean(ViewState["ShowDescriptionAsToolTip"].ToString()));
            }
            set { ViewState["ShowDescriptionAsToolTip"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the Event Back Color Column Name in the DataTable
        public string EventBackColorName
        {
            get
            {
                if (ViewState["EventBackColorName"] == null)
                    return string.Empty;
                else
                    return (ViewState["EventBackColorName"].ToString());
            }
            set { ViewState["EventBackColorName"] = value; }
        }
        // **********************************************************
        // **********************************************************
        // Gets or sets the Event Fore Color Column Name in the DataTable
        public string EventForeColorName
        {
            get
            {
                if (ViewState["EventForeColorName"] == null)
                    return string.Empty;
                else
                    return (ViewState["EventForeColorName"].ToString());
            }
            set { ViewState["EventForeColorName"] = value; }
        }
        // **********************************************************
        #endregion
        public EventCalendar()
        {
            DayRender += SpecialCalendarDayRender;
            DayRender += EventCalendarDayRender;
        }
        private Label NewLable(CalendarDay d)
        {

            Label lbl = new Label();
            string text;
            if (d.IsWeekend)
            {
                text = RestText;
                lbl.ForeColor = System.Drawing.Color.Black;
                lbl.BackColor = System.Drawing.Color.FromName("#ffeded");
            }
            else
            {
                text = WorkText;
                lbl.ForeColor = System.Drawing.Color.Green;
                lbl.BackColor = System.Drawing.Color.White;
            }
            lbl.CssClass = "CalendarContentClass";
            lbl.Style.Add("padding","4px 2% 0 0");
            lbl.Style.Add("overflow", "hidden");
            lbl.Style.Add("display", "block");
            lbl.Text = text;
            lbl.Font.Bold = false;
            lbl.Font.Size = 9;
            lbl.Font.Name = "宋体";
            lbl.Height = 60;
            //lbl.Width = Unit.Percentage(98);
            return lbl;
        }
        protected void SpecialCalendarDayRender(object sender, DayRenderEventArgs e)
        {
            CalendarDay d = (e).Day;
            TableCell c = (e).Cell;
            // If there is nothing to bind

            Label lbl = NewLable(d);
            c.Controls.Add(lbl);

            if (SpecialDateSource == null)
                return;
            DataTable dt = SpecialDateSource;

            foreach (DataRow dr in dt.Rows)
            {
                if (SpecialDateColumnName == string.Empty)
                    throw new ApplicationException(
                        "Must set SpecialCalendar's SpecialDateColumnName property when SpecialSource is specified");
                if (SpecialHeaderColumnName == string.Empty)
                    throw new ApplicationException(
                        "Must set SpecialCalendar's SpecialHeaderColumnName property when SpecialSource is specified");

                //if (!d.IsOtherMonth
                //    && d.Date == Convert.ToDateTime(dr[this.SpecialDateColumnName]).Date)
                if (d.Date == Convert.ToDateTime(dr[SpecialDateColumnName]).Date)
                {
                    // Show the Special Text
                    lbl.Text = dr[SpecialHeaderColumnName].ToString();
                    // Set the Tool Tip
                    if (SpecialDescriptionColumnName != string.Empty)
                        lbl.ToolTip = dr[SpecialDescriptionColumnName].ToString();

                    // Set the Back Color of the Label
                    if (SpecialBackColorName != null && dr[SpecialBackColorName] != null &&
                        dr[SpecialBackColorName].ToString() != "")
                        lbl.BackColor = System.Drawing.Color.FromName(dr[SpecialBackColorName].ToString());
                    // Set the Fore Color
                    if (SpecialForeColorName != null && dr[SpecialForeColorName] != null &&
                        dr[SpecialForeColorName].ToString() != "")
                        lbl.ForeColor = System.Drawing.Color.FromName(dr[SpecialForeColorName].ToString());
                }
            }
        }

        protected void EventCalendarDayRender(object sender, DayRenderEventArgs e)
        {
            CalendarDay d = (e).Day;
            TableCell c = (e).Cell;
            // If there is nothing to bind

            if (EventSource == null)
                return;

            DataTable dt = EventSource;
            Label lbl = (Label)c.Controls[1];

            foreach (DataRow dr in dt.Rows)
            {
                if (EventStartDateColumnName == string.Empty)
                    throw new ApplicationException("Must set EventCalendar's EventStartDateColumnName property when EventSource is specified");
                if (EventEndDateColumnName == string.Empty)
                    throw new ApplicationException("Must set EventCalendar's EventEndDateColumnName property when EventSource is specified");
                if (EventHeaderColumnName == string.Empty)
                    throw new ApplicationException("Must set EventCalendar's EventHeaderColumnName property when EventSource is specified");


                //if (!d.IsOtherMonth
                //    && d.Date >= Convert.ToDateTime(dr[this.EventStartDateColumnName]).Date
                //    && d.Date <= Convert.ToDateTime(dr[this.EventEndDateColumnName]).Date)
                if (d.Date >= Convert.ToDateTime(dr[EventStartDateColumnName]).Date
                    && d.Date <= Convert.ToDateTime(dr[EventEndDateColumnName]).Date)
                {

                    // Show the Event Text
                    if (lbl.Text == WorkText || lbl.Text == RestText)
                    {
                        lbl.Text = dr[EventHeaderColumnName].ToString();
                    }
                    else
                    {
                        string[] temp = lbl.Text.Split('<');
                        if (temp.Length < 4)
                        {
                            lbl.Text = lbl.Text + "<br />" + dr[EventHeaderColumnName];
                        }
                        else if (temp.Length == 4)
                        {
                            lbl.Text = lbl.Text + "<br />" + "点击查看更多..";
                        }
                    }
                    // Set the Tool Tip
                    if (ShowDescriptionAsToolTip && EventDescriptionColumnName != string.Empty)
                        lbl.ToolTip = dr[EventDescriptionColumnName].ToString();

                    // Set the Back Color of the Label
                    if (EventBackColorName != null && dr[EventBackColorName] != null && dr[EventBackColorName].ToString() != "")
                        lbl.BackColor = System.Drawing.Color.FromName(dr[EventBackColorName].ToString());
                    // Set the Fore Color
                    if (EventForeColorName != null && dr[EventForeColorName] != null && dr[EventForeColorName].ToString() != "")
                        lbl.ForeColor = System.Drawing.Color.FromName(dr[EventForeColorName].ToString());
                    c.Controls.Add(lbl);

                }
            }
        }
    }
}
