using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeAttendance;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.EmployeeAttendances.LittleViewPresenter
{
    public class AddAttendancePresenter : PresenterCore.BasePresenter
    {
        private readonly IRecordAttendanceView _ItsView;
        //private RecordBadAttendance _ItsModel;
        public IEmployeeAttendanceFacade _ItsModel = InstanceFactory.CreateEmployeeAttendanceFacade();

        private DateTime _TransformTheDay;
        private int _TransformInfluenceMinutes;
        private decimal _TransformInfluenceDays;

        public AddAttendancePresenter(IRecordAttendanceView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }
        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += AddEvent;
            _ItsView.OnSelectTypeChange += SelectTypeChangedEvent;
        }

        public override void Initialize(bool isPostBack)
        {
            _ItsView.Message = string.Empty;
            if (!isPostBack)
            {
                _ItsView.EmployeeName = string.Empty;
                _ItsView.EmployeeNameMessage = string.Empty;
                _ItsView.InfluenceTime = string.Empty;
                _ItsView.InfluenceTimeMessage = string.Empty;
                _ItsView.TheDay = DateTime.Today.ToString("yyyy-MM-dd");
                _ItsView.TheDayMessage = string.Empty;
                _ItsView.AttendanceTypes = GetAllTypes();
                _ItsView.AttendanceTypeMessage = string.Empty;
                _ItsView.OperationType = "Add";
                _ItsView.SelectedType = EmployeeAttendanceUtilitys._Absent;
                _ItsView.MinutesVisable = false;
            }
        }

        private List<string> GetAllTypes()
        {
            List<string> alltypes = new List<string>();
            alltypes.Add(EmployeeAttendanceUtilitys._Absent);
            alltypes.Add(EmployeeAttendanceUtilitys._Later);
            alltypes.Add(EmployeeAttendanceUtilitys._EarlyLeave);
            return alltypes;
        }

        public void AddEvent()
        {
            switch (_ItsView.SelectedType)
            {
                case EmployeeAttendanceUtilitys._Absent:
                    if (!ValidateDay())
                    {
                        return;
                    }
                    try
                    {
                        _ItsModel.RecordAbsentAttendance(_ItsView.EmployeeName, _TransformTheDay, _TransformInfluenceDays, LoginUser);
                        _ItsView.IsAddSuccess = true;
                    }
                    catch (ApplicationException ae)
                    {
                        _ItsView.Message = ae.Message;
                    }
                    break;

                case EmployeeAttendanceUtilitys._Later:
                    if (!ValidateMinute())
                    {
                        return;
                    }
                    try
                    {
                        _ItsModel.RecordLaterAttendance(_ItsView.EmployeeName, _TransformTheDay, _TransformInfluenceMinutes, LoginUser);
                        _ItsView.IsAddSuccess = true;
                    }
                    catch (ApplicationException ae)
                    {
                        _ItsView.Message = ae.Message;
                    }
                    break;

                case EmployeeAttendanceUtilitys._EarlyLeave:
                    if (!ValidateMinute())
                    {
                        return;
                    }
                    try
                    {
                        _ItsModel.RecordEarlyLeaveAttendance(_ItsView.EmployeeName, _TransformTheDay, _TransformInfluenceMinutes, LoginUser);
                        _ItsView.IsAddSuccess = true;
                    }
                    catch (ApplicationException ae)
                    {
                        _ItsView.Message = ae.Message;
                    }
                    break;

                default:
                    break;
            }
            //ExcuteTheModel();
        }

        //private void ExcuteTheModel()
        //{
        //    try
        //    {
        //        _ItsModel.Excute();
        //        _ItsView.IsAddSuccess = true;
        //    }
        //    catch (ApplicationException ae)
        //    {
        //        _ItsView.Message = ae.Message;
        //    }
        //}

        public void SelectTypeChangedEvent()
        {
            switch (_ItsView.SelectedType)
            {
                case EmployeeAttendanceUtilitys._Absent:
                    _ItsView.MinutesVisable = false;
                    break;
                case EmployeeAttendanceUtilitys._Later:
                case EmployeeAttendanceUtilitys._EarlyLeave:
                    _ItsView.MinutesVisable = true;
                    break;
                default:
                    break;
            }
            _ItsView.InfluenceTime = string.Empty;
        }

        #region 数据验证

        public bool ValidateDay()
        {
            bool employeeName = ValidateEmployeeName();
            bool theday = VaildateTheDay();
            bool affactDays = VaildateAffactDays();

            return employeeName && affactDays && theday;
        }

        public bool VaildateTheDay()
        {
            if (!DateTime.TryParse(_ItsView.TheDay, out _TransformTheDay))
            {
                _ItsView.TheDayMessage = EmployeeAttendanceUtilitys._ErrorTheDay;
                return false;
            }
            _ItsView.TheDayMessage = string.Empty;
            return true;
        }

        public bool ValidateMinute()
        {
            bool employeeName = ValidateEmployeeName();
            bool influenceMinutes = VaildateInfluenceMinutes();
            bool theday = VaildateTheDay();

            return employeeName && influenceMinutes && theday;
        }

        public bool ValidateEmployeeName()
        {
            if (string.IsNullOrEmpty(_ItsView.EmployeeName.Trim()))
            {
                _ItsView.EmployeeNameMessage = EmployeeAttendanceUtilitys._ErrorEmployeeName;
                return false;
            }
            _ItsView.EmployeeNameMessage = string.Empty;
            return true;
        }

        private bool VaildateInfluenceMinutes()
        {
            if (!int.TryParse(_ItsView.InfluenceTime, out _TransformInfluenceMinutes))
            {
                _ItsView.InfluenceTimeMessage = EmployeeAttendanceUtilitys._ErrorInfluenceMinutes;
                return false;
            }
            _ItsView.InfluenceTimeMessage = string.Empty;
            return true;
        }

        private bool VaildateAffactDays()
        {
            if (!decimal.TryParse(_ItsView.InfluenceTime, out _TransformInfluenceDays))
            {
                _ItsView.InfluenceTimeMessage = EmployeeAttendanceUtilitys._ErrorAffactDays;
                return false;
            }
            if (_TransformInfluenceDays != 0.5m && _TransformInfluenceDays != 1m)
            {
                _ItsView.InfluenceTimeMessage = EmployeeAttendanceUtilitys._ErrorAffactDays;
                return false;
            }
            _ItsView.InfluenceTimeMessage = string.Empty;
            return true;
        }

        #endregion
    }
}
