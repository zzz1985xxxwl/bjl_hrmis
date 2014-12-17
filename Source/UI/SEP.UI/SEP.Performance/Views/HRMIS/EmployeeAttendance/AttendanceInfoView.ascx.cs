using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeAttendance;

namespace SEP.Performance.Views.HRMIS.EmployeeAttendance
{
    public partial class AttendanceInfoView : UserControl, IEmployeeAttendanceView
    {

        public IAttendaceSearchView theSearchView
        {
            get { return AttendanceSearchView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public IRecordAttendanceView theRecordView
        {
            get { return RecordAttendanceView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public bool ShowTheRecordView
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set
            {
                if (value)
                {
                    mpeAttendance.Show();
                }
                else
                {
                    mpeAttendance.Hide();
                }
            }
        }


    }
}