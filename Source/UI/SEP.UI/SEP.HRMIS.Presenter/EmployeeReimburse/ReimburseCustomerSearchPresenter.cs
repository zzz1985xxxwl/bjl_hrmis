//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IReimburseCustomerSearchView.cs
// 创建者: 刘丹
// 创建日期: 2009-09-07
// 概述: 添加出差客户查询界面
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.Presenter.Core;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class ReimburseCustomerSearchPresenter : BasePresenter
    {
        private readonly IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();

        private DateTime? dtApplyDateFrom;
        private DateTime? dtApplyDateTo;
        private decimal? dTotalCostFrom;
        private decimal? dTotalCostTo;

        protected DateTime tempStartTime;
        protected DateTime tempEndTime;
        protected decimal tempTotalCostFrom;
        protected decimal tempTotalCostTo;

       public IReimburseCustomerSearchView _View;
        private readonly Account _LoginUser;
        public ReimburseCustomerSearchPresenter(IReimburseCustomerSearchView view, Account loginUser)
            : base(loginUser)
        {
            if (view == null)
            {
                throw new Exception("view may not be null");
            }
            _View = view;
            _LoginUser = loginUser;
        }

        public override void Initialize(bool isPostBack)
        {

            AttachViewEvent();
            if (!isPostBack)
            {
                _View.ReimburseCategoriesEnumDataSrc = ReimburseCategoriesEnum.GetAll();
                _View.ReimburseStatus = GetReimburseStatusEnum();
                List<Department> departmentList = BllInstance.DepartmentBllInstance.GetAllDepartment();
                _View.DepartmentSource = Tools.RemoteUnAuthDeparetment(departmentList, AuthType.HRMIS, _LoginUser, HrmisPowers.A904);
                _View.ApplyDateFrom = DateTime.Now.AddDays(-45).ToShortDateString();
                _View.ApplyDateTo = DateTime.Now.ToShortDateString();
                BindReimburse(null, null);
            }
        }

        private void AttachViewEvent()
        {
            _View.btnSearchClick += BindReimburse;
        }

        public void BindReimburse(object source, EventArgs e)
        {
            if (Validation())
            {
                try
                {
                    bool? isCustomerFilled = null;
                    if(_View.SelectedIsCustomerFilled==1)
                    {
                        isCustomerFilled = true;
                    }
                    if(_View.SelectedIsCustomerFilled==0)
                    {
                        isCustomerFilled = false;
                    }
                    List<Model.Reimburse> reimburseList =
                        ReimburseLogic.GetReimburseByCondition(_LoginUser, _View.EmployeeName,
                                                                  Convert.ToInt32(_View.DepartmentID),
                                                                  (ReimburseStatusEnum)Convert.ToInt32(_View.SelectedReimburseStatus), ReimburseStatusEnum.Added, isCustomerFilled,
                                                                  Convert.ToInt32(_View.ReimburseCategoriesEnumID),
                                                                  dTotalCostFrom, dTotalCostTo, dtApplyDateFrom,
                                                                  dtApplyDateTo, null, null, -1,
                                                                  _View.SelectedFinishStatus, HrmisPowers.A904, _View.PagerEntity);
                    _View.ReimburseListSource = reimburseList;
                  
                    _View.Message =
                        "<span class='font14b'>共查到 </span>"
                        + "<span class='fontred'>" + _View.ReimburseListSource.Count + "</span>"
                        + "<span class='font14b'> 个报销单; 共报销金额为</span>"
                        + SearchReimburseInfoPresenter.GetTotalCountStr(reimburseList);
                }
                catch (ApplicationException ex)
                {
                    _View.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }
        #region private Validation
        public bool Validation()
        {
            _View.TotalCostMsg = string.Empty;
            _View.ApplyDateMsg = string.Empty;
            bool ret = true;
            if (!(VaildateApplyDateFrom() && VaildateApplyDateTo()))
            {
                ret = false;
            }
            else if (!string.IsNullOrEmpty(_View.ApplyDateFrom) && !string.IsNullOrEmpty(_View.ApplyDateTo))
            {
                if (DateTime.Compare(tempStartTime, tempEndTime) > 0)
                {
                    _View.ApplyDateMsg = "开始时间不可晚于结束时间";
                    ret = false;
                }
            }
            if (!(VaildateTotalCostFrom() && VaildateTotalCostTo()))
            {
                ret = false;
            }
            else if (!string.IsNullOrEmpty(_View.TotalCostFrom) && !string.IsNullOrEmpty(_View.TotalCostTo))
            {
                if (tempTotalCostFrom > tempTotalCostTo)
                {
                    _View.TotalCostMsg = "无效的查询范围";
                    ret = false;
                }
            }
            return ret;
        }

        private bool VaildateTotalCostFrom()
        {
            if (!string.IsNullOrEmpty(_View.TotalCostFrom))
            {
                if (!Decimal.TryParse(_View.TotalCostFrom, out tempTotalCostFrom))
                {
                    _View.TotalCostMsg = "请输入数字";
                    return false;
                }
                    dTotalCostFrom = tempTotalCostFrom;
            }
            return true;
        }

        private bool VaildateTotalCostTo()
        {
            if (!string.IsNullOrEmpty(_View.TotalCostTo))
            {
                if (!Decimal.TryParse(_View.TotalCostTo, out tempTotalCostTo))
                {
                    _View.TotalCostMsg = "请输入数字";
                    return false;
                }
                    dTotalCostTo = tempTotalCostTo;
            }
            return true;
        }
        private bool VaildateApplyDateFrom()
        {
            if (!string.IsNullOrEmpty(_View.ApplyDateFrom))
            {
                if (!DateTime.TryParse(_View.ApplyDateFrom, out tempStartTime))
                {
                    _View.ApplyDateMsg = "时间格式输入不正确";
                    return false;
                }
                    dtApplyDateFrom = tempStartTime;
            }
            return true;
        }

        private bool VaildateApplyDateTo()
        {
            if (!string.IsNullOrEmpty(_View.ApplyDateTo))
            {
                if (!DateTime.TryParse(_View.ApplyDateTo, out tempEndTime))
                {
                    _View.ApplyDateMsg = "时间格式输入不正确";
                    return false;
                }
                    dtApplyDateTo = tempEndTime;
            }
            return true;
        }

        private static Dictionary<string, string> GetReimburseStatusEnum()
        {
            Dictionary<string, string> reimburseType = new Dictionary<string, string>();
            hrmisModel.Reimburse.AddReimburseStatusValueAndNameIntoDictionary(reimburseType, ReimburseStatusEnum.All);
            hrmisModel.Reimburse.AddReimburseStatusValueAndNameIntoDictionary(reimburseType, ReimburseStatusEnum.Reimbursing);
            hrmisModel.Reimburse.AddReimburseStatusValueAndNameIntoDictionary(reimburseType, ReimburseStatusEnum.WaitAudit);
            hrmisModel.Reimburse.AddReimburseStatusValueAndNameIntoDictionary(reimburseType, ReimburseStatusEnum.Auditing);
            hrmisModel.Reimburse.AddReimburseStatusValueAndNameIntoDictionary(reimburseType, ReimburseStatusEnum.Reimbursed);
            return reimburseType;
        }

        #endregion
    }
}
