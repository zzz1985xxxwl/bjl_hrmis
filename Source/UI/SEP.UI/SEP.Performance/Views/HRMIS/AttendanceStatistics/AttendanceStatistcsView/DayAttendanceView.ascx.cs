//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DayAttendanceView.cs
// 创建者: 王玥琦
// 创建日期: 2008-09-02
// 概述: 显示日考勤
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using HRMISEmployee=SEP.HRMIS.Model.Employee;
namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceStatistcsView
{
    public partial class DayAttendanceView : System.Web.UI.UserControl, IDayAttendance
    {
        private readonly string _Week1ActiveImage = "../../../../Pages/image/Week1Active.jpg";
        private readonly string _Week1NotActiveImage = "../../../../Pages/image/Week1NotActive.jpg";
        private readonly string _Week2ActiveImage = "../../../../Pages/image/Week2Active.jpg";
        private readonly string _Week2NotActiveImage = "../../../../Pages/image/Week2NotActive.jpg";
        private readonly string _Week3ActiveImage = "../../../../Pages/image/Week3Active.jpg";
        private readonly string _Week3NotActiveImage = "../../../../Pages/image/Week3NotActive.jpg";
        private readonly string _Week4ActiveImage = "../../../../Pages/image/Week4Active.jpg";
        private readonly string _Week4NotActiveImage = "../../../../Pages/image/Week4NotActive.jpg";
        private readonly string _Week5ActiveImage = "../../../../Pages/image/Week5Active.jpg";
        private readonly string _Week5NotActiveImage = "../../../../Pages/image/Week5NotActive.jpg";
        private readonly string _Week6ActiveImage = "../../../../Pages/image/Week6Active.jpg";
        private readonly string _Week6NotActiveImage = "../../../../Pages/image/Week6NotActive.jpg";

        protected void Page_Load(object sender, EventArgs e)
        {
            DayAttendanceWeekView1._ToButtonSearch = btnNextLastEvent;
            DayAttendanceWeekView2._ToButtonSearch = btnNextLastEvent;
            DayAttendanceWeekView3._ToButtonSearch = btnNextLastEvent;
            DayAttendanceWeekView4._ToButtonSearch = btnNextLastEvent;
            DayAttendanceWeekView5._ToButtonSearch = btnNextLastEvent;
            DayAttendanceWeekView6._ToButtonSearch = btnNextLastEvent;

            DayAttendanceWeekView1._DateSlection = SomeDateSlection;
            DayAttendanceWeekView2._DateSlection = SomeDateSlection;
            DayAttendanceWeekView3._DateSlection = SomeDateSlection;
            DayAttendanceWeekView4._DateSlection = SomeDateSlection;
            DayAttendanceWeekView5._DateSlection = SomeDateSlection;
            DayAttendanceWeekView6._DateSlection = SomeDateSlection;
        }
        private void InitImage()
        {
            Menu1.Items[0].ImageUrl = _Week1NotActiveImage;
            Menu1.Items[1].ImageUrl = _Week2NotActiveImage;
            Menu1.Items[2].ImageUrl = _Week3NotActiveImage;
            Menu1.Items[3].ImageUrl = _Week4NotActiveImage;
            Menu1.Items[4].ImageUrl = _Week5NotActiveImage;
            Menu1.Items[5].ImageUrl = _Week6NotActiveImage;

        }

        public string ResultMessage
        {
            set
            {
                lblMessage.Text = value;
            }
            get
            {
                return lblMessage.Text;
            }
        }

        public string EmployeeName
        {
            get { return txtName.Text.Trim(); }
            set { txtName.Text = value;}
        }

        public int? GradesId
        {
            get
            {
                if (string.IsNullOrEmpty(ddGrades.SelectedValue))
                {
                    return null;
                }
                return Convert.ToInt32(ddGrades.SelectedValue);
            }
        }

        public List<GradesType> GradesSource
        {
            set
            {
                ddGrades.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, "", true);
                ddGrades.Items.Add(itemAll);
                foreach (GradesType g in value)
                {
                    ListItem item = new ListItem(g.Name, g.ID.ToString(), true);
                    ddGrades.Items.Add(item);
                }
            }
        }
        public List<Department> DepartmentSource
        {
            set
            {
                listDepartment.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, (-1).ToString(), true);
                listDepartment.Items.Add(itemAll);
                foreach (Department department in value)
                {
                    ListItem item = new ListItem(department.DepartmentName, department.DepartmentID.ToString(), true);
                    listDepartment.Items.Add(item);
                }
            }
            get
            {
                return new List<Department>();
            }
        }

        public string FromDate 
        {
            set
            {
                hfFromDate.Value = Convert.ToDateTime(value).AddDays(1 - Convert.ToDateTime(value).Day).ToShortDateString();
                hfToDate.Value = Convert.ToDateTime(value).AddDays(1 - Convert.ToDateTime(value).Day).AddMonths(1).AddDays(-1).ToShortDateString();

                DayAttendanceWeekView1.CurrentDate = value;
                DayAttendanceWeekView2.CurrentDate = value;
                DayAttendanceWeekView3.CurrentDate = value;
                DayAttendanceWeekView4.CurrentDate = value;
                DayAttendanceWeekView5.CurrentDate = value;
                DayAttendanceWeekView6.CurrentDate = value;
            }
            get
            {
                return hfFromDate.Value;
            }
        }
        public string ToDate
        {
            set
            {
                hfToDate.Value = value;
            }
            get
            {
                return hfToDate.Value;
            }
        }

        public List<HRMISEmployee> DayAttendanceWeek1List
        {
            set
            {
                InitImage();
                MultiView1.ActiveViewIndex = 0;
                Menu1.Items[0].ImageUrl = _Week1ActiveImage;
                DayAttendanceWeekView1.CurrentPage =Convert.ToInt32(lblCurrent.Value);
                DayAttendanceWeekView1.DayAttendanceWeekList = value;
                Session["TheEmployeeDayAttendanceWeek1List"] = value;
            }
            get { return new List<HRMISEmployee>(); }
        }
        public List<HRMISEmployee> DayAttendanceWeek2List
        {
            set
            {
                DayAttendanceWeekView2.CurrentPage = Convert.ToInt32(lblCurrent.Value);
                DayAttendanceWeekView2.DayAttendanceWeekList = value;
                Session["TheEmployeeDayAttendanceWeek2List"] = value;
            }
            get { return new List<HRMISEmployee>(); }
        }
        public List<HRMISEmployee> DayAttendanceWeek3List
        {
            set
            {
                DayAttendanceWeekView3.CurrentPage = Convert.ToInt32(lblCurrent.Value);
                DayAttendanceWeekView3.DayAttendanceWeekList = value;
                Session["TheEmployeeDayAttendanceWeek3List"] = value;
            }
            get { return new List<HRMISEmployee>(); }
        }
        public List<HRMISEmployee> DayAttendanceWeek4List
        {
            set
            {
                DayAttendanceWeekView4.CurrentPage = Convert.ToInt32(lblCurrent.Value);
                DayAttendanceWeekView4.DayAttendanceWeekList = value;
                Session["TheEmployeeDayAttendanceWeek4List"] = value;
            }
            get { return new List<HRMISEmployee>(); }
        }
        public List<HRMISEmployee> DayAttendanceWeek5List
        {
            set
            {
                DayAttendanceWeekView5.CurrentPage = Convert.ToInt32(lblCurrent.Value);
                DayAttendanceWeekView5.DayAttendanceWeekList = value;
                Session["TheEmployeeDayAttendanceWeek5List"] = value;
                if (value.Count == 0)
                {
                    Menu1.Items[4].ImageUrl = "";
                }
            }
            get { return new List<HRMISEmployee>(); }
        }
        public List<HRMISEmployee> DayAttendanceWeek6List
        {
            set
            {
                DayAttendanceWeekView6.CurrentPage = Convert.ToInt32(lblCurrent.Value);
                DayAttendanceWeekView6.DayAttendanceWeekList = value;
                Session["TheEmployeeDayAttendanceWeek6List"] = value;
                if (value.Count == 0)
                {
                    Menu1.Items[5].ImageUrl = "";
                }
                SetTab();
            }
            get { return new List<HRMISEmployee>(); }
        }
        private void SetTab()
        {
            if (String.IsNullOrEmpty(hfCurrentTab.Value ))
            {
                ChangeImage("1");
            }
            else
            {
                if (hfCurrentTab.Value == "6" && String.IsNullOrEmpty(Menu1.Items[5].ImageUrl))
                {
                    hfCurrentTab.Value = "5";
                }
                if (hfCurrentTab.Value == "5" && String.IsNullOrEmpty(Menu1.Items[4].ImageUrl ))
                {
                    hfCurrentTab.Value = "4";
                }
                ChangeImage(hfCurrentTab.Value);
            }
            if (((List<HRMISEmployee>)Session["TheEmployeeDayAttendanceWeek1List"]).Count > 0)
            {
                tdExport.Style["display"] = "block";
            }
            else
            {
                tdExport.Style["display"] = "none";
            }
        }
        public List<string> Week1List
        {
            set
            {
                DayAttendanceWeekView1.LblWeek = value;
                Session["TheEmployeeWeek1List"] = value;
            }
            get { return new List<string>(); }
        }
        public List<string> Week2List
        {
            set
            {
                DayAttendanceWeekView2.LblWeek = value;
                Session["TheEmployeeWeek2List"] = value;
            }
            get { return new List<string>(); }
        }
        public List<string> Week3List
        {
            set
            {
                DayAttendanceWeekView3.LblWeek = value;
                Session["TheEmployeeWeek3List"] = value;
            }
            get { return new List<string>(); }
        }
        public List<string> Week4List
        {
            set
            {
                DayAttendanceWeekView4.LblWeek = value;
                Session["TheEmployeeWeek4List"] = value;
            }
            get { return new List<string>(); }
        }
        public List<string> Week5List
        {
            set
            {
                DayAttendanceWeekView5.LblWeek = value;
                Session["TheEmployeeWeek5List"] = value;
            }
            get { return new List<string>(); }
        }
        public List<string> Week6List
        {
            set
            {
                DayAttendanceWeekView6.LblWeek = value;
                Session["TheEmployeeWeek6List"] = value;
            }
            get { return new List<string>(); }
        }
        public string DepartmentId
        {
            set { listDepartment.SelectedValue = value; }
            get { return listDepartment.SelectedValue; }
        }

        private void btnNextLastEvent(DateTime date,int page)
        {
            FromDate = date.ToShortDateString();
            lblCurrent.Value = page.ToString();
            _ToButtonSearch(null, EventArgs.Empty);
        }

        public delegate void DateSlection(string employeeInfo, string specialDate,bool isNormal);
        public DateSlection _DateSlection;
        private void SomeDateSlection(string employeeInfo, string specialDate, bool isNormal)
        {
            _DateSlection(employeeInfo, specialDate, isNormal);
        }
        public EventHandler _ToButtonSearch;
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblCurrent.Value = "0";
            _ToButtonSearch(sender, EventArgs.Empty);
        }
        private void ChangeImage(string active)
        {
            MultiView1.ActiveViewIndex = Int32.Parse(active) - 1;
            for (int i = 0; i < Menu1.Items.Count; i++)
            {
                if (!String.IsNullOrEmpty(Menu1.Items[i].ImageUrl))
                {
                    if ((i + 1).ToString() == active)
                    {
                        switch (Menu1.Items[i].ToolTip)
                        {
                            case "第一周":
                                Menu1.Items[i].ImageUrl = _Week1ActiveImage;
                                break;
                            case "第二周":
                                Menu1.Items[i].ImageUrl = _Week2ActiveImage;
                                break;
                            case "第三周":
                                Menu1.Items[i].ImageUrl = _Week3ActiveImage;
                                break;
                            case "第四周":
                                Menu1.Items[i].ImageUrl = _Week4ActiveImage;
                                break;
                            case "第五周":
                                Menu1.Items[i].ImageUrl = _Week5ActiveImage;
                                break;
                            case "第六周":
                                Menu1.Items[i].ImageUrl = _Week6ActiveImage;
                                break;
                            default:
                                break;
                        }

                    }
                    else
                    {
                        switch (Menu1.Items[i].ToolTip)
                        {
                            case "第一周":
                                Menu1.Items[i].ImageUrl = _Week1NotActiveImage;
                                break;
                            case "第二周":
                                Menu1.Items[i].ImageUrl = _Week2NotActiveImage;
                                break;
                            case "第三周":
                                Menu1.Items[i].ImageUrl = _Week3NotActiveImage;
                                break;
                            case "第四周":
                                Menu1.Items[i].ImageUrl = _Week4NotActiveImage;
                                break;
                            case "第五周":
                                Menu1.Items[i].ImageUrl = _Week5NotActiveImage;
                                break;
                            case "第六周":
                                Menu1.Items[i].ImageUrl = _Week6NotActiveImage;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            hfCurrentTab.Value = e.Item.Value;
            ChangeImage(hfCurrentTab.Value);
        }
    }
}