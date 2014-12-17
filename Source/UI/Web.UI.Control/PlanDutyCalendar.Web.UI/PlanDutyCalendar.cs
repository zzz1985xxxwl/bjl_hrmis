
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PlanDutyCalendar.Web.UI
{
    public class PlanDutyCalendar : Calendar
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
        public bool IsReadOnly
        {
            get
            {
                if (ViewState["IsReadOnly"] == null)
                    return false;
                else
                    return ((bool)ViewState["IsReadOnly"]);
            }
            set { ViewState["IsReadOnly"] = value; }
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

        public string lbBorderColor
        {
            get
            {
                if (ViewState["lbBorderColor"] == null)
                    return "#69ad3c";
                else
                    return (ViewState["lbBorderColor"]).ToString();
            }
            set { ViewState["lbBorderColor"] = value; }
        }
        // **********************************************************
        #endregion
        #region PlanDutyCalendar
        // **********************************************************
        // Gets or Sets the Name of source DataTable  
        /// <summary>
        /// If this is specified, then PlanDutyDate are mandatory
        /// </summary>
        public DataTable PlanDutyDateSource
        {
            get
            {
                if (ViewState["PlanDutyDateSource"] == null)
                    return null;
                else
                    return ((DataTable)ViewState["PlanDutyDateSource"]);
            }
            set { ViewState["PlanDutyDateSource"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the Date Column in the DataTable
        public string PlanDutyDateColumnName
        {
            get
            {
                if (ViewState["PlanDutyDateColumnName"] == null)
                    return string.Empty;
                else
                    return (ViewState["PlanDutyDateColumnName"].ToString());
            }
            set { ViewState["PlanDutyDateColumnName"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the PlanDuty Header Column Name in the DataTable
        public string PlanDutySelectValue
        {
            get
            {
                if (ViewState["PlanDutySelectValue"] == null)
                    return string.Empty;
                else
                    return (ViewState["PlanDutySelectValue"].ToString());
            }
            set { ViewState["PlanDutySelectValue"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the PlanDuty Description Column Name in the DataTable
        public string PlanDutyDescriptionColumnName
        {
            get
            {
                if (ViewState["PlanDutyDescriptionColumnName"] == null)
                    return string.Empty;
                else
                    return (ViewState["PlanDutyDescriptionColumnName"].ToString());
            }
            set { ViewState["PlanDutyDescriptionColumnName"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the PlanDuty Back Color Column Name in the DataTable
        public string PlanDutyBackColorName
        {
            get
            {
                if (ViewState["PlanDutyBackColorName"] == null)
                    return string.Empty;
                else
                    return (ViewState["PlanDutyBackColorName"].ToString());
            }
            set { ViewState["PlanDutyBackColorName"] = value; }
        }
        // **********************************************************
        // **********************************************************
        // Gets or sets the PlanDuty Fore Color Column Name in the DataTable
        public string PlanDutyForeColorName
        {
            get
            {
                if (ViewState["PlanDutyForeColorName"] == null)
                    return string.Empty;
                else
                    return (ViewState["PlanDutyForeColorName"].ToString());
            }
            set { ViewState["PlanDutyForeColorName"] = value; }
        }
        // **********************************************************
        // **********************************************************
        // Gets or sets the 是否工作 in the DataTable
        public string PlanDutyIsWork
        {
            get
            {
                if (ViewState["PlanDutyIsWork"] == null)
                    return string.Empty;
                else
                    return (ViewState["PlanDutyIsWork"]).ToString();
            }
            set { ViewState["PlanDutyIsWork"] = value; }
        }

        public DataTable PlanDutyListDateSource
        {
            get
            {
                if (ViewState["PlanDutyListDateSource"] == null)
                    return null;
                else
                    return ((DataTable)ViewState["PlanDutyListDateSource"]);
            }
            set { ViewState["PlanDutyListDateSource"] = value; }
        }
        // **********************************************************
        #endregion
        public PlanDutyCalendar()
        {
            DayRender += SpecialCalendarDayRender;
            DayRender += PlanDutyCalendarDayRender;
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
            lbl.Style.Add("border-top", "1px solid " + lbBorderColor);
            lbl.Style.Add("border-bottom", "0px solid " + lbBorderColor);
            lbl.Style.Add("border-left", "0px solid " + lbBorderColor);
            lbl.Style.Add("border-right", "0px solid " + lbBorderColor);
            lbl.Style.Add("Padding-top", "4px");
            lbl.Style.Add("Padding-right", "2%");
            lbl.BorderColor = System.Drawing.Color.FromName(lbBorderColor);
            lbl.BorderWidth = 1;
            lbl.Text = text;
            lbl.Font.Bold = false;
            lbl.Font.Size = 10;
            lbl.Font.Name = "宋体";
            lbl.Height = 20;
            lbl.Width = Unit.Percentage(98);
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
                        c.ForeColor = System.Drawing.Color.FromName(dr[SpecialForeColorName].ToString());
                }
            }
        }

        private DropDownList NewDropDownList(CalendarDay d)
        {
            DropDownList dd = new DropDownList();
            dd.ID = d.Date.Year + "-" + d.Date.Month + "-" + d.Date.Day;
            for (int i = 0;i< PlanDutyListDateSource.Rows.Count;i++ )
            {
                dd.Items.Add(new ListItem(PlanDutyListDateSource.Rows[i][1].ToString(),
                    PlanDutyListDateSource.Rows[i][0].ToString()));
            }
            //if (d.IsWeekend)
            //{
            //    dd.ForeColor = System.Drawing.Color.Black;
            //    dd.BackColor = System.Drawing.Color.FromName("#ffeded");
            //}
            //else
            //{
            //    dd.ForeColor = System.Drawing.Color.Green;
            //    dd.BackColor = System.Drawing.Color.White;
            //}
            dd.Style.Add("border-top", "1px solid #A6D0E8");
            dd.Style.Add("border-bottom", "0px solid #A6D0E8");
            dd.Style.Add("border-left", "0px solid #A6D0E8");
            dd.Style.Add("border-right", "0px solid #A6D0E8");
            dd.Style.Add("Padding-top", "4px");
            dd.Style.Add("Padding-right", "2%");
            dd.BorderColor = System.Drawing.Color.FromName("#A6D0E8");
            dd.BorderWidth = 1;
            //dd.Text = text;
            dd.Font.Bold = false;
            dd.Font.Size = 10;
            dd.Font.Name = "宋体";
            dd.Height = (Unit)(20);
            dd.Width = Unit.Percentage(98);
            dd.Attributes.Add("onchange", "return SelectedIndexChange('" + dd.ID + "');");
            dd.Enabled = !IsReadOnly;
            return dd;
        }
        protected void PlanDutyCalendarDayRender(object sender, DayRenderEventArgs e)
        {
            CalendarDay d = e.Day;
            TableCell c =  e.Cell;
            // If there is nothing to bind
            //Label dd = NewLable(d);
            DateTime dtFrom=new DateTime(SelectedDate.Year, SelectedDate.Month,1);
            DateTime dtTo = dtFrom.AddMonths(1).AddDays(-1);
            DateTime dtDate = d.Date;
            if (DateTime.Compare(dtDate, dtFrom) < 0 || 
                DateTime.Compare(dtDate, dtTo) > 0)
            {
                e.Cell.BackColor = System.Drawing.Color.LightGray; ;
                return;
            }
            DropDownList dd = NewDropDownList(d);
            c.Controls.Add(dd);

            if (this.PlanDutyDateSource == null)
                return;
            DataTable dt = this.PlanDutyDateSource;

            foreach (DataRow dr in dt.Rows)
            {
                if (PlanDutyDateColumnName == string.Empty)
                    throw new ApplicationException(
                        "Must set PlanDutyCalendar's PlanDutyDateColumnName property when PlanDutySource is specified");
                if (PlanDutySelectValue == string.Empty)
                    throw new ApplicationException(
                        "Must set PlanDutyCalendar's PlanDutyHeaderColumnName property when PlanDutySource is specified");

                //if (!d.IsOtherMonth
                //    && d.Date == Convert.ToDateTime(dr[this.PlanDutyDateColumnName]).Date)
                if (d.Date == Convert.ToDateTime(dr[this.PlanDutyDateColumnName]).Date)
                {
                    // Show the PlanDuty Text
                    dd.SelectedValue = dr[PlanDutySelectValue].ToString();
                    if (dd.SelectedValue == "-1")
                    {
                        dd.ForeColor = System.Drawing.Color.Black;
                        dd.BackColor = System.Drawing.Color.FromName("#ffeded");
                    }
                    else
                    {
                        dd.ForeColor = System.Drawing.Color.Green;
                        dd.BackColor = System.Drawing.Color.White;
                    }
                    // Set the Tool Tip
                    if (PlanDutyDescriptionColumnName != string.Empty)
                        dd.ToolTip = dr[PlanDutyDescriptionColumnName].ToString();

                    // Set the Back Color of the Label
                    //if (PlanDutyBackColorName != null && dr[PlanDutyBackColorName] != null &&
                    //    dr[PlanDutyBackColorName].ToString() != "")
                    //    dd.BackColor = System.Drawing.Color.FromName(dr[PlanDutyBackColorName].ToString());
                    // Set the Fore Color
                    if (PlanDutyForeColorName != null && dr[PlanDutyForeColorName] != null &&
                        dr[PlanDutyForeColorName].ToString() != "")
                        c.ForeColor = System.Drawing.Color.FromName(dr[PlanDutyForeColorName].ToString());
                }
            }
        }
    }
}
