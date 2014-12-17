using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;

namespace SEP.HRMIS.Presenter.AttendanceStatistics.MonthAttendance
{
    public class MonthAttendancePresenter
    {
        private readonly Account _Operator;
        protected DateTime dtFromDate;
        protected DateTime dtToDate;

        private IEmployeeAttendanceStatisticsFacade _IEmployeeAttendanceStatisticsFacade =
            InstanceFactory.CreateEmployeeAttendanceStatisticsFacade();
        public IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        public IMonthAttendanceView _IMonthAttendanceView;
        public MonthAttendancePresenter(IMonthAttendanceView view, Account _operator)
        {
            _Operator = _operator;
            _IMonthAttendanceView = view;
        }
        public void InitPresenter(bool isPostBack)
        {
            if (!isPostBack)
            {
                //DateTime dttempDate = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
                //_IMonthAttendanceView.FromDate = dttempDate.ToShortDateString();//月头
                //_IMonthAttendanceView.ToDate = dttempDate.AddMonths(1).AddDays(-1).ToShortDateString();//月末
                _IMonthAttendanceView.FromDate = new HrmisUtility().CurrenMonthStartTime().ToShortDateString(); //月头
                _IMonthAttendanceView.ToDate = new HrmisUtility().CurrenMonthEndTime().ToShortDateString(); //月末
                BindDepartment();
                BindMonthAttendanceList(null, null);
                _IMonthAttendanceView.IsHours = true;
                _IMonthAttendanceView.GradesSource = GradesType.GetAll();
            }
        }

        public void BindDepartment()
        {
            List<Department> deptList =
                Tools.RemoteUnAuthDeparetment(_IDepartmentBll.GetAllDepartment(), AuthType.HRMIS, _Operator,
                                              HrmisPowers.A507);
            if (!Tools.IsDeptListContainsDept(deptList, _Operator.Dept))
            {
                deptList.Add(_Operator.Dept);
            }
            _IMonthAttendanceView.DepartmentList = _IDepartmentBll.GenerateDeptListWithLittleParentDept(deptList);
        }

        public void BindMonthAttendanceList(object source, EventArgs e)
        {
            if (CheckValid())
            {
                try
                {
                    List<Employee> employeeMonthAttendanceList =
                        _IEmployeeAttendanceStatisticsFacade.GetMonthAttendanceStatisticsFacade(
                            _IMonthAttendanceView.EmployeeName,
                            _IMonthAttendanceView.SelectedDepartment, _IMonthAttendanceView.GradesId,
                            dtFromDate, dtToDate, _Operator, HrmisPowers.A507);
                    //列表中没有查出当前员工的信息时，满足一下两个条件的任何一个，再次加载当前员工的信息
                    //1.所选部门是当前员工的部门
                    //2.所选部门包含当前员工的部门
                    //如现实数据中王莎莉登录，无任何权限，只可看自己的信息
                    if (_Operator.Name.Contains(_IMonthAttendanceView.EmployeeName)
                        && !HrmisUtility.IsEmployeeListContainEmployee(employeeMonthAttendanceList, _Operator.Id))
                    {
                        bool getnow = true;
                        if (_IMonthAttendanceView.SelectedDepartment != _Operator.Dept.Id)
                        {
                            Department selectedDept =
                                _IDepartmentBll.GetDepartmentById(_IMonthAttendanceView.SelectedDepartment, null);
                            if (!selectedDept.IsExistDept(_Operator.Dept.Id))
                            {
                                getnow = false;
                            }
                        }
                        if (_IMonthAttendanceView.GradesId != null && _Operator.GradesID != _IMonthAttendanceView.GradesId)
                        {
                            getnow = false;
                        }
                        if (getnow)
                        {
                            GetCurrEmployeeMonthAttendance(employeeMonthAttendanceList);
                        }
                    }
                    _IMonthAttendanceView.EmployeeMonthAttendanceList = employeeMonthAttendanceList;
                    _IMonthAttendanceView.ScopeDateFrom = _IMonthAttendanceView.FromDate;
                    _IMonthAttendanceView.ScopeDateTo = _IMonthAttendanceView.ToDate;
                    _IMonthAttendanceView.Message =
                        "<span class='font14b'>共有 </span>"
                        + "<span class='fontred'>" + _IMonthAttendanceView.EmployeeMonthAttendanceList.Count + "</span>"
                        + "<span class='font14b'> 条统计记录</span>";
                }
                catch (ApplicationException ex)
                {
                    _IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

        private void GetCurrEmployeeMonthAttendance(List<Employee> employeeMonthAttendanceList)
        {
            Employee currEmployeeMonthAttendance =
                _IEmployeeAttendanceStatisticsFacade.GetMonthAttendanceStatisticsFacade(_Operator.Id, dtFromDate, dtToDate);
            if (currEmployeeMonthAttendance != null)
            {
                employeeMonthAttendanceList.Add(currEmployeeMonthAttendance);
            }
        }

        public void StatisticsEvent(object sender, EventArgs e)
        {
            BindMonthAttendanceList(null, null);
        }

        private bool CheckValid()
        {
            _IMonthAttendanceView.ScopeMsg = "";
            bool ret = true;
            if (String.IsNullOrEmpty(_IMonthAttendanceView.FromDate) || String.IsNullOrEmpty(_IMonthAttendanceView.ToDate))
            {
                _IMonthAttendanceView.ScopeMsg = "时间不可为空";
                ret = false;
            }
            else
            {
                if (!(DateTime.TryParse(_IMonthAttendanceView.FromDate, out dtFromDate) && DateTime.TryParse(_IMonthAttendanceView.ToDate, out dtToDate)))
                {
                    _IMonthAttendanceView.ScopeMsg = "时间格式输入不正确";
                    ret = false;
                }
                else
                {
                    if (DateTime.Compare(dtFromDate, dtToDate) > 0)
                    {
                        _IMonthAttendanceView.ScopeMsg = "开始时间不可晚于结束时间";
                        ret = false;
                    }
                }
            }
            return ret;
        }

        private void BindEmployeeName()
        {
            _IMonthAttendanceView.EmployeeNameReadOnly = false;
            _IMonthAttendanceView.EmployeeName = string.Empty;
            //如果所选部门示该员工所在的部门，若以下两个条件都不满足，则绑定EmployeeName，则只能查询自己的信息
            //1.该员工不是主管
            //2.没有权限看这个部门的信息
            //如现实数据中王莎莉登录，无任何权限，只可看自己的信息
            if (_Operator.Dept.Id == _IMonthAttendanceView.SelectedDepartment)
            {
                if (!_IDepartmentBll.IsDepartmentManagedByEmployee(_IMonthAttendanceView.SelectedDepartment,
                                                                   _Operator.Id)
                    &&
                    !_Operator.IsHasAuthOnDept(AuthType.HRMIS, HrmisPowers.A507,
                                               _IMonthAttendanceView.SelectedDepartment))
                {
                    _IMonthAttendanceView.EmployeeName = _Operator.Name;
                    _IMonthAttendanceView.EmployeeNameReadOnly = true;
                }
            }
        }

        public void ddlDepartmentSelectedIndexChanged(object sender, EventArgs e)
        {
            BindEmployeeName();
        }

    }
}