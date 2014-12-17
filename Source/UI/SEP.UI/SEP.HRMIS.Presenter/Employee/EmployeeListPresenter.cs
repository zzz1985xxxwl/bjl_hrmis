//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeListPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-06-17
// 概述: 查询员工Presenter
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.IBll.Positions;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;

namespace SEP.HRMIS.Presenter
{
    public class EmployeeListPresenter
    {
        private IPositionBll _IPositionBll = BllInstance.PositionBllInstance;
        private IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();

        private readonly IEmployeeListView _View;
        private readonly IEmployeeCardView _CardView;
        protected DateTime stratTime = Convert.ToDateTime("1900-1-1");
        protected DateTime endTime = Convert.ToDateTime("2999-12-31");
        private List<Employee> _EmployeeList; 

        public delegate void ToVacationUpdatePageDelegate();
        public ToVacationUpdatePageDelegate _ToVacationUpdatePageEvent;

        private int _EmployeeIDForContract;
        private readonly Account _Operator;
        private int? AgeFrom;
        private int? AgeTo;

        public EmployeeListPresenter(IEmployeeListView view, IEmployeeCardView cardView, Account _operator)
        {
            _CardView = cardView;
            _View = view;
            _Operator = _operator;
        }

        public void InitView(bool isPostBack)
        {
            if (!isPostBack)
            {
                _View.CompanyAgeError = string.Empty;
                _View.EmployeeType = EmployeeTypeEnum.NormalEmployee;
                GetData();
            }
        }

        /// <summary>
        /// 初始界面查询所有的员工信息
        /// </summary>
        public void InitLetter()
        {
            if (!ValidateFrom() || !ValidateTo())
            {

            }
            else
            {
                try
                {
                    _View.ErrorMessage = string.Empty;
                    //20090112 修改默认查询条件中的员工类型为“正式” by yyb
                    EmployeeTypeEnum employeetype =
           EmployeeTypeUtility.GetEmployeeTypeByID(Convert.ToInt32(_View.EmployeeType));
                    //_EmployeeList = _IEmployeeFacade.GetEmployeeByBasicCondition(string.Empty,
                    //                                                             EmployeeTypeEnum.NormalEmployee,
                    //                                                             -1, -1, _View.RecursionDepartment);
                    //20090807  修改查询条件  by liudan 
                    _EmployeeList = _IEmployeeFacade.GetEmployeeBasicInfoByBasicConditionWithCompanyAge(_View.EmployeeName,employeetype,_View.PositionId,_View.GradesId, _View.DepartmentId, AgeFrom, AgeTo, _View.RecursionDepartment,Convert.ToInt32(_View.EmployeeStatusId));
                    _EmployeeList =
                        HrmisUtility.RemoteUnAuthEmployee(_EmployeeList, AuthType.HRMIS, _Operator, HrmisPowers.A401);
                    List<Employee> emplyees = new List<Employee>();
                    foreach (Employee emplyee in _EmployeeList)
                    {
                        //根据所属公司id，得到所属公司名称
                        Employee temp = emplyee;
                        if (temp.EmployeeDetails == null || temp.EmployeeDetails.Work == null ||
                            temp.EmployeeDetails.Work.Company == null)
                        {
                        }
                        else
                        {
                            //todo noted by wsl transfer waiting for modify
                            temp.EmployeeDetails.Work.Company =
                                _IDepartmentBll.GetDepartmentById(
                                    temp.EmployeeDetails.Work.Company.Id, new Account());
                        }
                        temp.EmployeeDetails = temp.EmployeeDetails ?? new EmployeeDetails();
                        temp.EmployeeDetails.Work = temp.EmployeeDetails.Work ?? new Work();
                        temp.EmployeeDetails.Work.Company = temp.EmployeeDetails.Work.Company ??
                                                            new Department();
                        emplyees.Add(temp);
                    }
                    _CardView.Employees = _EmployeeList;
                    _View.ErrorMessage = "<span class='font14b'>共查到 </span>"
                                         + "<span class='fontred'>" + _EmployeeList.Count + "</span>"
                                         + "<span class='font14b'> 条信息</span>";
                }
                catch (Exception ex)
                {
                    _View.ErrorMessage = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        public void ExecutEvent(string letter)
        {
            if (!ValidateFrom() || !ValidateTo())
            {
                
            }
            else
            {
                try
                {
                    _View.ErrorMessage = string.Empty;
                    EmployeeTypeEnum employeetype =
                        EmployeeTypeUtility.GetEmployeeTypeByID(Convert.ToInt32(_View.EmployeeType));
                    //_EmployeeList =
                    //    _IEmployeeFacade.GetEmployeeByBasicConditionAndFirstLetter(_View.EmployeeName, employeetype,
                    //                                                               _View.PositionId, _View.DepartmentId,
                    //                                                               _View.RecursionDepartment,
                    //                                                               letter);
                    //20090807  修改查询条件  by liudan 
                      _EmployeeList =
                            _IEmployeeFacade.GetEmployeeByBasicConditionWithFirstLetterAndCompanyAge(_View.EmployeeName, employeetype,
                                                                                       _View.PositionId, _View.DepartmentId,
                                                                                       _View.RecursionDepartment,
                                                                                       letter, AgeFrom, AgeTo, Convert.ToInt32(_View.EmployeeStatusId));
                    _EmployeeList =
                        HrmisUtility.RemoteUnAuthEmployee(_EmployeeList, AuthType.HRMIS, _Operator, HrmisPowers.A401);
                    List<Employee> emplyees = new List<Employee>();
                    foreach (Employee emplyee in _EmployeeList)
                    {
                        //根据所属公司id，得到所属公司名称
                        Employee temp = emplyee;
                        if (temp.EmployeeDetails == null || temp.EmployeeDetails.Work == null ||
                            temp.EmployeeDetails.Work.Company == null)
                        {
                        }
                        else
                        {
                            //todo noted by wsl transfer waiting for modify
                            temp.EmployeeDetails.Work.Company =
                                _IDepartmentBll.GetDepartmentById(
                                    temp.EmployeeDetails.Work.Company.Id, new Account());
                        }
                        temp.EmployeeDetails = temp.EmployeeDetails ?? new EmployeeDetails();
                        temp.EmployeeDetails.Work = temp.EmployeeDetails.Work ?? new Work();
                        temp.EmployeeDetails.Work.Company = temp.EmployeeDetails.Work.Company ??
                                                            new Department();
                        emplyees.Add(temp);
                    }
                    _CardView.Employees = emplyees;
                    _View.ErrorMessage = "<span class='font14b'>共查到 </span>"
                                         + "<span class='fontred'>" + _EmployeeList.Count + "</span>"
                                         + "<span class='font14b'> 条信息</span>";
                }
                catch (Exception ex)
                {
                    _View.ErrorMessage = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

        /// <summary>
        /// 年假
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ViewVacationEvent(object sender, CommandEventArgs e)
        {
            if (!int.TryParse(e.CommandArgument.ToString(), out _EmployeeIDForContract))
            {
                _View.ErrorMessage = "Employee ID is not exist";
                return;
            }
            try
            {
                Employee employee = _IEmployeeFacade.GetEmployeeByAccountID(_EmployeeIDForContract);
                if (employee == null)
                {
                    _View.ErrorMessage = "Employee is not exist";
                    return;
                }

                _ToVacationUpdatePageEvent();
            }
            catch (Exception ex)
            {
                _View.ErrorMessage = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        /// <summary>
        /// 跳转合同列表页面
        /// </summary>
        public EventHandler ToContractListPage;
        /// <summary>
        /// 合同管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ContractManageEvent(object sender, CommandEventArgs e)
        {
            if (!int.TryParse(e.CommandArgument.ToString(), out _EmployeeIDForContract))
            {
                _View.ErrorMessage = "Employee ID is not exist";
                return;
            }
            try
            {
                Employee employee = _IEmployeeFacade.GetEmployeeByAccountID(_EmployeeIDForContract);
                if (employee == null)
                {
                    _View.ErrorMessage = "Employee is not exist";
                    return;
                }
                ToContractListPage(this,null);
            }

            catch (Exception ex)
            {
                _View.ErrorMessage = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        /// <summary>
        /// for页面跳转
        /// </summary>
        public int EmployeeId
        {
            get { return _EmployeeIDForContract; }
            set { _EmployeeIDForContract = value; }
        }

        #region private method

        private void GetData()
        {
            List<Department> deptList= _IDepartmentBll.GetAllDepartment();
            _View.DepartmentSource =
                Tools.RemoteUnAuthDeparetment(deptList, AuthType.HRMIS, _Operator, HrmisPowers.A401);
            _View.PositionSource = _IPositionBll.GetAllPosition();
            _View.GradesSource=GradesType.GetAll();
            _View.EmployeeTypeSource = EmployeeTypeUtility.GetAllEmployeeTypeEnum();
            _View.EmployeeType = EmployeeTypeEnum.All; 
        }

        private bool ValidateFrom()
        {
            int age;
            if (String.IsNullOrEmpty(_View.CompanyAgeFrom.Trim()))
            {
                AgeFrom = null;
                return true;
            }

            if (!int.TryParse(_View.CompanyAgeFrom.Trim(), out age))
            {
                _View.CompanyAgeError = "请输入正整数";
            }
            else
            {
                if (age < 0)
                {
                    _View.CompanyAgeError = "请输入正整数";
                }
            }
            AgeFrom =365 * age ;
            _View.CompanyAgeError = string.Empty;
            return true;
        }

        private bool ValidateTo()
        {
            int age;
            if (String.IsNullOrEmpty(_View.CompanyAgeTo.Trim()))
            {
                AgeTo = null;
                return true;
            }

            if (!int.TryParse(_View.CompanyAgeTo.Trim(), out age))
            {
                _View.CompanyAgeError = "请输入正整数";
            }
            else
            {
                if (age < 0)
                {
                    _View.CompanyAgeError = "请输入正整数";
                }
            }
            //转换年成天查询
            AgeTo = 365*age;
            if(AgeTo==AgeFrom)//如果查询条件相同，则把结束的查询条件转成下一年，以便查一年以内的人员
            {
                AgeTo = AgeTo + 364;
            }
            _View.CompanyAgeError = string.Empty;
            return true;
        }

        #endregion

        #region user for tests

        public IDepartmentBll SetGetDepartment
        {
            set
            {
                _IDepartmentBll = value;
            }
        }

        public IPositionBll SetGetPosition
        {
            set
            {
                _IPositionBll = value;
            }
        }

        public IEmployeeFacade SetGetEmployee
        {
            set
            {
                _IEmployeeFacade = value;
            }
        }


        #endregion
    }
}
