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
                //_IMonthAttendanceView.FromDate = dttempDate.ToShortDateString();//��ͷ
                //_IMonthAttendanceView.ToDate = dttempDate.AddMonths(1).AddDays(-1).ToShortDateString();//��ĩ
                _IMonthAttendanceView.FromDate = new HrmisUtility().CurrenMonthStartTime().ToShortDateString(); //��ͷ
                _IMonthAttendanceView.ToDate = new HrmisUtility().CurrenMonthEndTime().ToShortDateString(); //��ĩ
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
                    //�б���û�в����ǰԱ������Ϣʱ������һ�������������κ�һ�����ٴμ��ص�ǰԱ������Ϣ
                    //1.��ѡ�����ǵ�ǰԱ���Ĳ���
                    //2.��ѡ���Ű�����ǰԱ���Ĳ���
                    //����ʵ��������ɯ���¼�����κ�Ȩ�ޣ�ֻ�ɿ��Լ�����Ϣ
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
                        "<span class='font14b'>���� </span>"
                        + "<span class='fontred'>" + _IMonthAttendanceView.EmployeeMonthAttendanceList.Count + "</span>"
                        + "<span class='font14b'> ��ͳ�Ƽ�¼</span>";
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
                _IMonthAttendanceView.ScopeMsg = "ʱ�䲻��Ϊ��";
                ret = false;
            }
            else
            {
                if (!(DateTime.TryParse(_IMonthAttendanceView.FromDate, out dtFromDate) && DateTime.TryParse(_IMonthAttendanceView.ToDate, out dtToDate)))
                {
                    _IMonthAttendanceView.ScopeMsg = "ʱ���ʽ���벻��ȷ";
                    ret = false;
                }
                else
                {
                    if (DateTime.Compare(dtFromDate, dtToDate) > 0)
                    {
                        _IMonthAttendanceView.ScopeMsg = "��ʼʱ�䲻�����ڽ���ʱ��";
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
            //�����ѡ����ʾ��Ա�����ڵĲ��ţ����������������������㣬���EmployeeName����ֻ�ܲ�ѯ�Լ�����Ϣ
            //1.��Ա����������
            //2.û��Ȩ�޿�������ŵ���Ϣ
            //����ʵ��������ɯ���¼�����κ�Ȩ�ޣ�ֻ�ɿ��Լ�����Ϣ
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