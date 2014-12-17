using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.PlanDutyViews
{
    public partial class DutyClassInfoView1 : UserControl, IDutyClassInfoView
    {
        /// <summary>
        /// 大界面
        /// </summary>
        public IDutyClassListView DutyClassListView
        {
            get { return DutyClassListView1; }
            set { throw new NotImplementedException(); }
        }
        /// <summary>
        /// 小界面
        /// </summary>
        public IDutyClassView DutyClassView
        {
            get { return DutyClassView1; }
            set { throw new NotImplementedException(); }
        }
        /// <summary>
        /// 控制小界面的显示
        /// </summary>
        public bool DutyClassViewVisible
        {
            get { throw new NotImplementedException(); }
            set
            {
                if (value)
                {
                    mpeDutyClass.Show();
                }
                else
                {
                    mpeDutyClass.Hide();
                }
            }
        }
    }
}