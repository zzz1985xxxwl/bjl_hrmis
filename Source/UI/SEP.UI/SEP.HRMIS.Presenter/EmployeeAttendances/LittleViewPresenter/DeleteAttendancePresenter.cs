using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeAttendance;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.EmployeeAttendances.LittleViewPresenter
{
    public class DeleteAttendancePresenter : PresenterCore.BasePresenter
    {
        private readonly IAttendaceSearchView _View;
        //private readonly GetBadAttendance _Attendance = new GetBadAttendance();
        //private DeleteBadAttendance _DeleteAttendance;
        public IEmployeeAttendanceFacade _AttendanceBll = InstanceFactory.CreateEmployeeAttendanceFacade();

        public DeleteAttendancePresenter(IAttendaceSearchView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;
            //AttachViewEvent();
        }

        public override void Initialize(bool isPostBack)
        {
            _View.OnAttendanceDelete += DeleteEvent;
        }

        //private void AttachViewEvent()
        //{
        //    _View.OnAttendanceDelete += DeleteEvent;
        //}

        public void DeleteEvent(string id)
        {
            int _AttendanceID;
            if (!VaildateAttendanceId(id, out _AttendanceID))
            {
                return;
            }

            try
            {
                //_DeleteAttendance = new DeleteBadAttendance(_AttendanceID);
                //_DeleteAttendance.Excute();
                _AttendanceBll.DeleteBadAttendance(_AttendanceID, LoginUser);
            }
            catch (ApplicationException ex)
            {
                _View.Message = ex.Message;
            }
        }

        private bool VaildateAttendanceId(string id, out int attendanceId)
        {
            if (!int.TryParse(id, out attendanceId))
            {
                _View.Message = "删除的记录ID不正确";
                return false;
            }
            return true;
        }

        #region 测试用

        public IEmployeeAttendanceFacade AttendanceBll
        {
            get { return _AttendanceBll; }
        }

        #endregion

      
    }
}
