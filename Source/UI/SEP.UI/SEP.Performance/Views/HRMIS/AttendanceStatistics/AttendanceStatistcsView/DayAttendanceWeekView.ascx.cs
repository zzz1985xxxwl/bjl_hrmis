//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DayAttendanceWeekView.cs
// 创建者: 王玥琦
// 创建日期: 2008-09-02
// 概述: 显示日考勤中的周
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics;
using HRMISEmployee = SEP.HRMIS.Model.Employee;
namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceStatistcsView
{
    public partial class DayAttendanceWeekView : UserControl, IDayAttendanceWeekView
    {
        private PagedDataSource _Pds;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<string> LblWeek
        {
            set 
            {
                if(value.Count==0)
                {
                   return; 
                }
                lblMon.Text = value[0];
                lblTues.Text =  value[1];
                lblWedn.Text = value[2];
                lblThurs.Text =  value[3];
                lblFri.Text =  value[4];
                lblSat.Text =  value[5];
                lblSun.Text = value[6];
            }
        }

        public string CurrentDate
        {
            set 
            { 
                lblDate.Value = value;
                txtYear.Text = Convert.ToDateTime(lblDate.Value).Year.ToString();
                ddMonth.SelectedIndex = Convert.ToDateTime(lblDate.Value).Month - 1;
            }
        }
        
        public int CurrentPage
        {
            set { lblCurrent.Text = (value+1).ToString(); }
        }

        public List<HRMISEmployee> DayAttendanceWeekList
        {
            set
            {
                _Pds = new PagedDataSource();
                _Pds.DataSource = value;
                _Pds.AllowPaging = true;
                _Pds.PageSize = 15;
                int page = Convert.ToInt32(lblCurrent.Text)-1;
                if (page >= _Pds.PageCount)
                {
                    page = _Pds.PageCount - 1;
                }
                lblAllPage.Text = _Pds.PageCount.ToString();
                _Pds.CurrentPageIndex = page;
                LinkButtonPreviousPage.Enabled = true;
                LinkButtonNextPage.Enabled = true;
                if (_Pds.IsFirstPage)
                    LinkButtonPreviousPage.Enabled = false;
                if (_Pds.IsLastPage)
                    LinkButtonNextPage.Enabled = false;

                listDayAttendanceWeek.DataSource = _Pds;
                listDayAttendanceWeek.DataBind();
                tbPage.Visible = !(value.Count <= 15);
            }
        }

        public delegate void btnSearchEvent(DateTime date,int page);
        public btnSearchEvent _ToButtonSearch;

        protected void IbtnLast_Click(object sender, ImageClickEventArgs e)
        {
            lblDate.Value = Convert.ToDateTime(lblDate.Value).AddMonths(-1).ToShortDateString();
            txtYear.Text = Convert.ToDateTime(lblDate.Value).Year.ToString();
            ddMonth.SelectedIndex = Convert.ToDateTime(lblDate.Value).Month - 1;
            _ToButtonSearch(Convert.ToDateTime(lblDate.Value), Convert.ToInt32(lblCurrent.Text)-1);
        }

        protected void IBtnNext_Click(object sender, ImageClickEventArgs e)
        {
            lblDate.Value = Convert.ToDateTime(lblDate.Value).AddMonths(1).ToShortDateString();
            txtYear.Text = Convert.ToDateTime(lblDate.Value).Year.ToString();
            ddMonth.SelectedIndex = Convert.ToDateTime(lblDate.Value).Month - 1;
            _ToButtonSearch(Convert.ToDateTime(lblDate.Value), Convert.ToInt32(lblCurrent.Text)-1);
        }
        protected void txtYear_TextChanged(object sender, EventArgs e)
        {
            ChangeYearOrMonth();
        }
        private void ChangeYearOrMonth()
        {
            lblValidateYear.Visible = false;
            int year;
            if (!int.TryParse(txtYear.Text, out year))
            {
                lblValidateYear.Text = "请输入正确的年份！";
                lblValidateYear.Visible = true;
                return;
            }
            if (year < 1900 || year > 2900)
            {
                lblValidateYear.Text = "请输入1900-2900之间的年份！";
                lblValidateYear.Visible = true;
                return;
            }
            if (Convert.ToDateTime(lblDate.Value).Day == 31)
            {
                if (ddMonth.SelectedIndex == 1)
                {
                    lblDate.Value = new DateTime(year, ddMonth.SelectedIndex+1 , 28).ToShortDateString();
                }
                else
                {
                    lblDate.Value = new DateTime(year, ddMonth.SelectedIndex+1 ,30).ToShortDateString();
                }
            }
            else
            {
                 lblDate.Value = new DateTime(year, ddMonth.SelectedIndex +1,
                                       Convert.ToDateTime(lblDate.Value).Day).ToShortDateString();
            }
            _ToButtonSearch(Convert.ToDateTime(lblDate.Value), Convert.ToInt32(lblCurrent.Text)-1);
        }
       
        protected void ddMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeYearOrMonth();
        }

        protected void Page_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument.ToString() == "Prev")
            {
                lblCurrent.Text = (Convert.ToInt32(lblCurrent.Text) - 1).ToString();
                _ToButtonSearch(Convert.ToDateTime(lblDate.Value), Convert.ToInt32(lblCurrent.Text)-1);                
            }
            else if (e.CommandArgument.ToString() == "First")
            {
                lblCurrent.Text = "1";
                _ToButtonSearch(Convert.ToDateTime(lblDate.Value), Convert.ToInt32(lblCurrent.Text)-1);  
            }
            else if (e.CommandArgument.ToString() == "Last")
            {
                lblCurrent.Text = lblAllPage.Text;
                _ToButtonSearch(Convert.ToDateTime(lblDate.Value), Convert.ToInt32(lblCurrent.Text) - 1);  
            }
            else
            {
                lblCurrent.Text = (Convert.ToInt32(lblCurrent.Text) + 1).ToString();
                _ToButtonSearch(Convert.ToDateTime(lblDate.Value), Convert.ToInt32(lblCurrent.Text)-1);
            }
        }

        public delegate void DateSlection(string employeeID,string specialDate,bool isNormal);
        public DateSlection _DateSlection;

        protected void DateSlection_Command(object sender, CommandEventArgs e)
        {
            string[] temp=e.CommandArgument.ToString().Split(';');
            string employeeInfo = e.CommandArgument.ToString();
            bool isNormal = !temp[3].Contains("数据有误");
            
            switch (e.CommandName)
            {
                case "Mon":
                    _DateSlection(employeeInfo, lblMon.Text, isNormal);
                    break;
                case "Tues":
                    _DateSlection(employeeInfo, lblTues.Text, isNormal);
                    break;
                case "Wedn":
                    _DateSlection(employeeInfo, lblWedn.Text, isNormal);
                    break;
                case "Thurs":
                    _DateSlection(employeeInfo, lblThurs.Text, isNormal);
                    break;
                case "Fri":
                    _DateSlection(employeeInfo, lblFri.Text, isNormal);
                    break;
                case "Sat":
                    _DateSlection(employeeInfo, lblSat.Text, isNormal);
                    break;
                case "Sun":
                    _DateSlection(employeeInfo, lblSun.Text, isNormal);
                    break;
                default:
                    break;
            }
        }

        protected void LinkButtonGoPage_Click(object sender, EventArgs e)
        {
            int index;
            if (int.TryParse(txtGoPage.Text.Trim(), out index))
            {
                index = index < 1 ? 1 : index;
                index = index > Convert.ToInt32(lblAllPage.Text) ? Convert.ToInt32(lblAllPage.Text) : index;
                lblCurrent.Text = index.ToString();
                _ToButtonSearch(Convert.ToDateTime(lblDate.Value), Convert.ToInt32(lblCurrent.Text) - 1);
                txtGoPage.Text = "";
            }
        }
    }
}