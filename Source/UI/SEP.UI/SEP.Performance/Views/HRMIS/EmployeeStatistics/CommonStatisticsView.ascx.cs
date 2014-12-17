using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.UI;
using Microsoft.Office.Interop.Excel;
using SEP.HRMIS.Presenter;
using DataTable=System.Data.DataTable;

namespace SEP.Performance.Views.EmployeeStatistics
{
    public partial class CommonStatisticsView : UserControl, ICommonStatisticsView
    {
        public IAgePieChartView IAgePieChartView
        {
            get { return AgePieChartView1; }
            set { throw new NotImplementedException(); }
        }

        public IStatisticsConditionView IStatisticsConditionView
        {
            get { return StatisticsConditionView1; }
            set { throw new NotImplementedException(); }
        }

        public IEduBgPieChartView IEduBgPieChartView
        {
            get { return EduBgPieChartView1; }
            set { throw new NotImplementedException(); }
        }

        public IGenderPieChartView IGenderPieChartView
        {
            get { return GenderPieChartView1; }
            set { throw new NotImplementedException(); }
        }

        public IWorkAgePieChartView IWorkAgePieChartView
        {
            get { return WorkAgePieChartView1; }
            set { throw new NotImplementedException(); }
        }

        public IWorkTypePieChartView IWorkTypePieChartView
        {
            get { return WorkTypePieChartView1; }
            set { throw new NotImplementedException(); }
        }

        public IComeAndLeaveTableView IComeAndLeaveTableView
        {
            get { return ComeAndLeaveTableView1; }
            set { throw new NotImplementedException(); }
        }

        public IComeAndLeaveBarChartView IComeAndLeaveBarChartView
        {
            get { return ComeAndLeaveBarChartView1; }
            set { throw new NotImplementedException(); }
        }

        public ILeaveRateLineChartView ILeaveRateLineChartView
        {
            get { return LeaveRateLineChartView1; }
            set { throw new NotImplementedException(); }
        }

        public IPositionGradeTowerTableView IPositionGradeTowerTableView
        {
            get { return PositionGradeTowerTableView1; }
            set { throw new NotImplementedException(); }
        }

        public event EventHandler StatisticsButtonEvent;

        public IOtherStatisticsDataView IOtherStatisticsDataView
        {
            get { return OtherStatisticsDataView1; }
            set { throw new NotImplementedException(); }
        }

    }
}