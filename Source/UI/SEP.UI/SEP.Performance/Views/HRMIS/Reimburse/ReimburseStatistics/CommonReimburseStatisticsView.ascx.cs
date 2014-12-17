using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.UI;
using Microsoft.Office.Interop.Excel;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics;
using DataTable=System.Data.DataTable;

namespace SEP.Performance.Views.HRMIS.Reimburse.ReimburseStatistics
{
    public partial class CommonReimburseStatisticsView : UserControl, ICommonEmployeeReimburseStatisticsView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public ICommonStatisticsView ICommonStatisticsView
        {
            get { return CommonStatisticsView1; }
            set { throw new NotImplementedException(); }
        }

        public IEmployeeCommonStatisticsView IEmployeeCommonStatisticsView
        {
            get { return EmployeeCommonStatisticsView1; }
            set { throw new NotImplementedException(); }
        }



    }
}