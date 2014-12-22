using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.IBll.Positions;
using SEP.Model.Utility;
using SEP.Model.Accounts;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Departments;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet
{
    public class SetEmployeeAccountSetListPresenter
    {
        private readonly IDepartmentBll _Department = BllInstance.DepartmentBllInstance;
        private readonly IPositionBll _Position = BllInstance.PositionBllInstance;

        private readonly IEmployeeAccountSetFacade _IEmployeeAccountSetFacade =
            InstanceFactory.CreateEmployeeAccountSetFacade();
        private readonly ISetEmployeeAccountSetListPresenter _ItsView;
        private List<EmployeeSalary> _EmployeeSalaryList;
        private readonly Account _LoginUser;
        public SetEmployeeAccountSetListPresenter(ISetEmployeeAccountSetListPresenter view, Account loginUser)
        {
            _ItsView = view;
            _LoginUser = loginUser;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.BtnSearchEvent += ExecutEvent;
            _ItsView.ImportEvent += ImportEmployeeAccountSet;
        }


        /// <summary>
        /// 初始界面查询所有的员工信息
        /// </summary>
        private void InitPresenter()
        {
            try
            {
                _ItsView.ResultMessage = string.Empty;
                _ItsView.EmployeeType = "-1";
                _EmployeeSalaryList =
                    _IEmployeeAccountSetFacade.GetEmployeeAccountSetByCondition(string.Empty, -1, -1, EmployeeTypeEnum.All, _ItsView.RecursionDepartment, _LoginUser, Convert.ToInt32(_ItsView.EmployeeStatusId));
                _ItsView.EmployeeAccountSetList = _EmployeeSalaryList;
                _ItsView.ResultMessage = "<span class='font14b'>共查到 </span>"
                                     + "<span class='fontred'>" + _EmployeeSalaryList.Count + "</span>"
                                     + "<span class='font14b'> 条信息</span>";
            }
            catch (Exception ex)
            {
                _ItsView.ResultMessage = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        public void ExecutEvent()
        {
            try
                {
                    _ItsView.ResultMessage = string.Empty;
                    EmployeeTypeEnum employeetype = EmployeeTypeUtility.GetEmployeeTypeByID (Convert.ToInt32(_ItsView.EmployeeType));

                    _EmployeeSalaryList =
                        _IEmployeeAccountSetFacade.GetEmployeeAccountSetByCondition(_ItsView.EmployeeName,
                                                                                 _ItsView.DepartmentId,
                                                                                 _ItsView.PositionId, employeetype, _ItsView.RecursionDepartment, _LoginUser,
                                                            Convert.ToInt32(_ItsView.EmployeeStatusId));
                    _ItsView.EmployeeAccountSetList = _EmployeeSalaryList;
                    _ItsView.ResultMessage = "<span class='font14b'>共查到 </span>"
                                         + "<span class='fontred'>" + _EmployeeSalaryList.Count + "</span>"
                                         + "<span class='font14b'> 条信息</span>";
                }
                catch (Exception ex)
                {
                    _ItsView.ResultMessage = "<span class='fontred'>" + ex.Message + "</span>";
                }
        }

        public void InitView(bool isPostBack)
        {
            if (!isPostBack)
            {
                GetData();
                InitPresenter();
            }
        }

        private void GetData()
        {
            List<Department> departmentList = _Department.GetAllDepartment();
            _ItsView.DepartmentSource =
                Tools.RemoteUnAuthDeparetment(departmentList, AuthType.HRMIS, _LoginUser, HrmisPowers.A604);
            _ItsView.PositionSource = _Position.GetAllPosition();
            _ItsView.EmployeeTypeSource = EmployeeTypeUtility.GetAllEmployeeTypeEnum();
        }

        private void ImportEmployeeAccountSet(string filePath)
        {
            try
            {
                _IEmployeeAccountSetFacade.ImportEmployeeAccountSetFacade(filePath, _LoginUser);
                ExecutEvent();
                _ItsView.ResultMessage = "<span class='fontred'>导入成功</span>";
            }
            catch (Exception e)
            {
                _ItsView.ResultMessage = "<span class='fontred'>" + e.Message + "</span>";
            }
        }
    }
}
