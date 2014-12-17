//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: EmployeeWelfareSearchListPresenter.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-23
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.EmployInformation.WelfareInformation;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeWelfares;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.IBll.Positions;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;

namespace SEP.HRMIS.Presenter
{
    public class EmployeeWelfareSearchListPresenter
    {
        private readonly IEmployeeWelfareListView _View;
        private readonly IPositionBll _IPositionBll = BllInstance.PositionBllInstance;
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        private readonly IEmployeeWelfareFacade _IEmployeeWelfareFacade = InstanceFactory.CreateEmployeeWelfareFacade();
        private readonly ICompanyInvolveFacade _ICompanyFacade = InstanceFactory.CreateCompanyInvolveFacade();
        private readonly Account _Operator;
        private string _ValideMessage;

        public EmployeeWelfareSearchListPresenter(IEmployeeWelfareListView view, Account loginUser, bool isPostBack)
        {
            _View = view;
            _Operator = loginUser;
            InitView(isPostBack);
        }

        private void InitView(bool isPostBack)
        {
            AttachViewEvent();
            if (!isPostBack)
            {
                GetData();
                SearchEmployeeWelfare();
            }
        }

        private void AttachViewEvent()
        {
            _View.SearchEvent += SearchEmployeeWelfare;
            _View.SaveEvent += SaveEmployeeWelfare;
            _View.ImportEvent += ImportEmployeeWelfare;
        }

        private void SearchEmployeeWelfare()
        {
            try
            {
                List<EmployeeWelfare> employeeWelfarelist = new List<EmployeeWelfare>();
                List<Employee> employeeList =
                    _IEmployeeFacade.GetEmployeeBasicInfoByBasicCondition(_View.EmployeeName, _View.EmployeeType,
                                                                          _View.PositionId, _View.DepartmentId,
                                                                          _View.RecursionDepartment,
                                                                          Convert.ToInt32(_View.EmployeeStatusId),
                                                                          _View.CompanyId);
                employeeList =
                    HrmisUtility.RemoteUnAuthEmployee(employeeList, AuthType.HRMIS, _Operator, HrmisPowers.A605);
                if (employeeList != null)
                {
                    foreach (Employee employee in employeeList)
                    {
                        EmployeeWelfare welfare =
                            _IEmployeeWelfareFacade.GetEmployeeWelfareByAccountID(employee.Account.Id);
                        if (welfare == null)
                        {
                            welfare = EmployeeWelfare.EmptyWelfare();
                        }
                        welfare.AccumulationFund.BaseTemp = welfare.AccumulationFund.Base == null
                                                                ? ""
                                                                : welfare.AccumulationFund.Base.ToString();
                        welfare.AccumulationFund.SupplyBaseTemp = welfare.AccumulationFund.SupplyBase == null
                                                                ? ""
                                                                : welfare.AccumulationFund.SupplyBase.ToString();
                        welfare.SocialSecurity.BaseTemp = welfare.SocialSecurity.Base == null
                                                              ? ""
                                                              : welfare.SocialSecurity.Base.ToString();
                        welfare.SocialSecurity.YangLaoBaseTemp = welfare.SocialSecurity.YangLaoBase == null
                                                              ? ""
                                                              : welfare.SocialSecurity.YangLaoBase.ToString();
                        welfare.SocialSecurity.ShiYeBaseTemp = welfare.SocialSecurity.ShiYeBase == null
                                                              ? ""
                                                              : welfare.SocialSecurity.ShiYeBase.ToString();
                        welfare.SocialSecurity.YiLiaoBaseTemp = welfare.SocialSecurity.YiLiaoBase == null
                                                              ? ""
                                                              : welfare.SocialSecurity.YiLiaoBase.ToString();
                        welfare.AccumulationFund.EffectiveYearMonthTemp =
                            EmployeeWelfare.YearAndMonth(welfare.AccumulationFund.EffectiveYearMonth);
                        welfare.SocialSecurity.EffectiveYearMonthTemp =
                            EmployeeWelfare.YearAndMonth(welfare.SocialSecurity.EffectiveYearMonth);
                        welfare.Owner = employee.Account;
                        employeeWelfarelist.Add(welfare);
                    }
                }
                _View.EmployeeWelfareList = employeeWelfarelist;
                _View.Message =
                    string.Format(
                        "<span class='font14b'>共查到 </span><span class='fontred'>{0}</span><span class='font14b'> 条信息</span>",
                        employeeList == null ? 0 : employeeList.Count);
            }
            catch (Exception ex)
            {
                _View.Message = string.Format("<span class='fontred'>{0}</span>", ex.Message);
            }
        }

        private void SaveEmployeeWelfare()
        {
            if (ValideAndInit())
            {
                foreach (EmployeeWelfare welfare in _View.EmployeeWelfareList)
                {
                    _IEmployeeWelfareFacade.SaveEmployeeWelfare(welfare.Owner.Id, welfare.SocialSecurity.Type,
                                                                welfare.SocialSecurity.Base,
                                                                welfare.SocialSecurity.EffectiveYearMonth,
                                                                welfare.AccumulationFund.Account,
                                                                welfare.AccumulationFund.EffectiveYearMonth,
                                                                welfare.AccumulationFund.Base, _Operator.Name,
                                                                welfare.AccumulationFund.SupplyAccount,
                                                                welfare.AccumulationFund.SupplyBase,
                                                                welfare.SocialSecurity.YangLaoBase,
                                                                welfare.SocialSecurity.ShiYeBase,
                                                                welfare.SocialSecurity.YiLiaoBase
                                                                );
                    _View.Message = string.Format("<span class='fontred'>保存成功</span>");
                }
            }
            else
            {
                _View.Message = string.Format("<span class='fontred'>数据：{0}存在问题</span>", _ValideMessage);
            }
        }

        #region valide

        public bool ValideAndInit()
        {
            _ValideMessage = "";
            bool valid = true;
            foreach (EmployeeWelfare welfare in _View.EmployeeWelfareList)
            {
                valid &= Vaildate(welfare);
            }
            return valid;
        }

        private bool Vaildate(EmployeeWelfare welfare)
        {
            bool valid = true;
            decimal dctemp;
            if (!string.IsNullOrEmpty(welfare.AccumulationFund.BaseTemp) &&
                !decimal.TryParse(welfare.AccumulationFund.BaseTemp, out dctemp))
            {
                _ValideMessage = string.Format("{0}{1};", _ValideMessage, welfare.AccumulationFund.BaseTemp);
                valid = false;
            }
            else
            {
                if (string.IsNullOrEmpty(welfare.AccumulationFund.BaseTemp))
                {
                    welfare.AccumulationFund.Base = null;
                }
                else
                {
                    welfare.AccumulationFund.Base = Convert.ToDecimal(welfare.AccumulationFund.BaseTemp);
                }
            }
            if (!string.IsNullOrEmpty(welfare.AccumulationFund.SupplyBaseTemp) &&
                !decimal.TryParse(welfare.AccumulationFund.SupplyBaseTemp, out dctemp))
            {
                _ValideMessage = string.Format("{0}{1};", _ValideMessage, welfare.AccumulationFund.SupplyBaseTemp);
                valid = false;
            }
            else
            {
                if (string.IsNullOrEmpty(welfare.AccumulationFund.SupplyBaseTemp))
                {
                    welfare.AccumulationFund.SupplyBase = null;
                }
                else
                {
                    welfare.AccumulationFund.SupplyBase = Convert.ToDecimal(welfare.AccumulationFund.SupplyBaseTemp);
                }
            }
            if (!string.IsNullOrEmpty(welfare.SocialSecurity.BaseTemp) &&
                !decimal.TryParse(welfare.SocialSecurity.BaseTemp, out dctemp))
            {
                _ValideMessage = string.Format("{0}{1};", _ValideMessage, welfare.SocialSecurity.BaseTemp);
                valid = false;
            }
            else
            {
                if (string.IsNullOrEmpty(welfare.SocialSecurity.BaseTemp))
                {
                    welfare.SocialSecurity.Base = null;
                }
                else
                {
                    welfare.SocialSecurity.Base = Convert.ToDecimal(welfare.SocialSecurity.BaseTemp);
                }
            }
            if (!string.IsNullOrEmpty(welfare.SocialSecurity.YangLaoBaseTemp) &&
                !decimal.TryParse(welfare.SocialSecurity.YangLaoBaseTemp, out dctemp))
            {
                _ValideMessage = string.Format("{0}{1};", _ValideMessage, welfare.SocialSecurity.YangLaoBaseTemp);
                valid = false;
            }
            else
            {
                if (string.IsNullOrEmpty(welfare.SocialSecurity.YangLaoBaseTemp))
                {
                    welfare.SocialSecurity.YangLaoBase = null;
                }
                else
                {
                    welfare.SocialSecurity.YangLaoBase = Convert.ToDecimal(welfare.SocialSecurity.YangLaoBaseTemp);
                }
            }
            if (!string.IsNullOrEmpty(welfare.SocialSecurity.ShiYeBaseTemp) &&
                !decimal.TryParse(welfare.SocialSecurity.ShiYeBaseTemp, out dctemp))
            {
                _ValideMessage = string.Format("{0}{1};", _ValideMessage, welfare.SocialSecurity.ShiYeBaseTemp);
                valid = false;
            }
            else
            {
                if (string.IsNullOrEmpty(welfare.SocialSecurity.ShiYeBaseTemp))
                {
                    welfare.SocialSecurity.ShiYeBase = null;
                }
                else
                {
                    welfare.SocialSecurity.ShiYeBase = Convert.ToDecimal(welfare.SocialSecurity.ShiYeBaseTemp);
                }
            }
            if (!string.IsNullOrEmpty(welfare.SocialSecurity.YiLiaoBaseTemp) &&
                !decimal.TryParse(welfare.SocialSecurity.YiLiaoBaseTemp, out dctemp))
            {
                _ValideMessage = string.Format("{0}{1};", _ValideMessage, welfare.SocialSecurity.YiLiaoBaseTemp);
                valid = false;
            }
            else
            {
                if (string.IsNullOrEmpty(welfare.SocialSecurity.YiLiaoBaseTemp))
                {
                    welfare.SocialSecurity.YiLiaoBase = null;
                }
                else
                {
                    welfare.SocialSecurity.YiLiaoBase = Convert.ToDecimal(welfare.SocialSecurity.YiLiaoBaseTemp);
                }
            }
            if (!WelfareInfoVaildater.YearMonthOK(welfare.AccumulationFund.EffectiveYearMonthTemp))
            {
                _ValideMessage =
                    string.Format("{0}{1}年-{2}月;", _ValideMessage, welfare.AccumulationFund.EffectiveYearMonthTemp[0],
                                  welfare.AccumulationFund.EffectiveYearMonthTemp[1]);
                valid = false;
            }
            else
            {
                welfare.AccumulationFund.EffectiveYearMonth =
                    EmployeeWelfare.ConvertToDateTime(welfare.AccumulationFund.EffectiveYearMonthTemp);
            }
            if (!WelfareInfoVaildater.YearMonthOK(welfare.SocialSecurity.EffectiveYearMonthTemp))
            {
                _ValideMessage =
                    string.Format("{0}{1}年-{2}月;", _ValideMessage, welfare.SocialSecurity.EffectiveYearMonthTemp[0],
                                  welfare.SocialSecurity.EffectiveYearMonthTemp[1]);
                valid = false;
            }
            else
            {
                welfare.SocialSecurity.EffectiveYearMonth =
                    EmployeeWelfare.ConvertToDateTime(welfare.SocialSecurity.EffectiveYearMonthTemp);
            }

            return valid;
        }

        #endregion

       

        private void GetData()
        {
            List<Department> deptList = _IDepartmentBll.GetAllDepartment();
            _View.DepartmentSource =
                Tools.RemoteUnAuthDeparetment(deptList, AuthType.HRMIS, _Operator, HrmisPowers.A605);
            _View.PositionSource = _IPositionBll.GetAllPosition();
            _View.EmployeeTypeSource = EmployeeTypeUtility.GetAllEmployeeTypeEnum();
            _View.EmployeeType = EmployeeTypeEnum.All;
            _View.CompanySource = _ICompanyFacade.GetAllCompanyHaveEmployee(_Operator, HrmisPowers.A605);
        }


        private void ImportEmployeeWelfare(string filePath)
        {
            try
            {
                _IEmployeeWelfareFacade.ImportEmployeeWelfare(filePath, _Operator);
                SearchEmployeeWelfare();
                _View.Message = "<span class='fontred'>导入成功</span>";
            }
            catch (Exception e)
            {
                _View.Message ="<span class='fontred'>"+e.Message+"</span>" ;
            }
        }
    }
}