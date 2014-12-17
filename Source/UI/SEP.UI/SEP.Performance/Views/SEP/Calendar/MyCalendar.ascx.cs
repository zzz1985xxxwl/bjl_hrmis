using System;
using System.Web.UI.WebControls;
using SEP.Presenter.IPresenter.ICalendar;

namespace SEP.Performance.Views.SEP.Calendar
{
    public partial class MyCalendar : System.Web.UI.UserControl,IMyCalendarView
    {
        private readonly string _DayActiveImage = "../../../pages/image/DayActive.jpg";
        private readonly string _DayNotActiveImage = "../../../pages/image/DayNotActive.jpg";
        private readonly string _WeekActiveImage = "../../../pages/image/WeekActive.jpg";
        private readonly string _WeekNotActiveImage = "../../../pages/image/WeekNotActive.jpg";
        private readonly string _MonthActiveImage = "../../../pages/image/MonthActive.jpg";
        private readonly string _MonthNotActiveImage = "../../../pages/image/MonthNotActive.jpg";
        private readonly string _YearActiveImage = "../../../pages/image/YearActive.jpg";
        private readonly string _YearNotActiveImage = "../../../pages/image/YearNotActive.jpg";

        public IDayCalendarView _IDayCalendarView
        {
            get { return DayCalendar1; }
            set { DayCalendar1 = (DayCalendar) value; }
        }

        public IWeekCalendarView _IWeekCalendarView
        {
            get { return WeekCalendar1; }
            set { WeekCalendar1 = (WeekCalendar) value;}
        }
        public string SelectIndex
        {
            get { return MultiView1.ActiveViewIndex.ToString(); }
            set { MultiView1.ActiveViewIndex = Convert.ToInt16(value); }
        }

        private void RefreshShow()
        {
            Menu1.Items[0].ImageUrl = _DayActiveImage;
            Menu1.Items[1].ImageUrl = _WeekNotActiveImage;
            Menu1.Items[2].ImageUrl = _MonthNotActiveImage;
            Menu1.Items[3].ImageUrl = _YearNotActiveImage;
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Menu1.Items[0].ImageUrl ))
            {
                RefreshShow();
            }
            GetCalendar();
        }
        public void GetCalendar()
        {
            MyCalendarPresenter myCalendarPresenter = new MyCalendarPresenter(this);
            myCalendarPresenter.InitPresenter(IsPostBack, DateTime.Now); 
        }
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            MultiView1.ActiveViewIndex = Int32.Parse(e.Item.Value);
            for (int i = 0; i < Menu1.Items.Count; i++)
            {
                if (!String.IsNullOrEmpty(Menu1.Items[i].ImageUrl))
                {
                    if (i.ToString() == e.Item.Value)
                    {
                        switch (Menu1.Items[i].ToolTip)
                        {
                            case "Day":
                                Menu1.Items[i].ImageUrl = _DayActiveImage;
                                break;
                            case "Week":
                                Menu1.Items[i].ImageUrl = _WeekActiveImage;
                                break;
                            case "Month":
                                Menu1.Items[i].ImageUrl = _MonthActiveImage;
                                break;
                            case "Year":
                                Menu1.Items[i].ImageUrl = _YearActiveImage;
                                break;
                            default:
                                break;
                        }

                    }
                    else
                    {
                        switch (Menu1.Items[i].ToolTip)
                        {
                            case "Day":
                                Menu1.Items[i].ImageUrl = _DayNotActiveImage;
                                break;
                            case "Week":
                                Menu1.Items[i].ImageUrl = _WeekNotActiveImage;
                                break;
                            case "Month":
                                Menu1.Items[i].ImageUrl = _MonthNotActiveImage;
                                break;
                            case "Year":
                                Menu1.Items[i].ImageUrl = _YearNotActiveImage;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

    }
}