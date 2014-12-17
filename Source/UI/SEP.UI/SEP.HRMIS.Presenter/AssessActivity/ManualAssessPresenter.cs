//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ManualAssessPresenter.cs
// 创建者:wang.shali
// 创建日期: 2008-06-16
// 概述: 申请考评活动
// ----------------------------------------------------------------
using System;

using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public abstract class ManualAssessPresenter : SEP.Presenter.Core.BasePresenter 
    {
        public IManualAssessView _View;

        protected ManualAssessPresenter(IManualAssessView view, Account loginUser)
            : base(loginUser)
        {
            if (view == null)
            {
                throw new Exception("view may not be null");
            }

            _View = view;
        }

        public bool Validation()
        {
            _View.ScopeMsg = string.Empty;
            _View.ReasonMsg = string.Empty;
            _View.Message = string.Empty;

            bool ret = true;
            if (String.IsNullOrEmpty(_View.ScopeFrom) || String.IsNullOrEmpty(_View.ScopeTo))
            {
                _View.ScopeMsg = "绩效考核时间不可为空";
                ret = false;
            }
            else
            {
                DateTime dtScopeFrom;
                DateTime dtScopeTo;
                if (!(DateTime.TryParse(_View.ScopeFrom, out dtScopeFrom) && DateTime.TryParse(_View.ScopeTo, out dtScopeTo)))
                {
                    _View.ScopeMsg = "绩效考核时间格式不正确";
                    ret = false;
                }
                else
                {
                    if (DateTime.Compare(dtScopeFrom, dtScopeTo) > 0)
                    {
                        _View.ScopeMsg = "绩效考核开始时间不可晚于结束时间";
                        ret = false;
                    }
                    else
                    {
                        if (DateTime.Compare(dtScopeFrom, _View.Employee.EmployeeDetails.Work.ComeDate) < 0)
                        {
                            _View.ScopeMsg = "绩效考核开始时间不可早于员工入职时间";
                            ret = false;
                        }
                    }
                }
            }
            if (String.IsNullOrEmpty(_View.Reason))
            {
                _View.ReasonMsg = "考核原因不可为空";
                ret = false;
            }
            return ret;
        }

        public void btnApplyClick(object sender, EventArgs e)
        {
            if (!Validation())
            {
                return;
            }

            try
            {
                hrmisModel.AssessActivity temp = _View.AssessActivityToManual;
                temp.AssessProposerName = LoginUser.Name;

                InstanceFactory.AssessActivityFacade.ManualAssess(temp);
                ToGetEmployeeForApplyPage(this, null);
            }
            catch (ApplicationException ex)
            {
                _View.Message = ex.Message;
            }
        }
        public EventHandler ToGetEmployeeForApplyPage;

        //public void InitView(string strEmployeeID, bool isPageValid)
        //{
        //    _View.Message = string.Empty;
        //    int employeeID;
        //    if (!int.TryParse(strEmployeeID, out employeeID))
        //    {
        //        _View.Message = "员工信息传入错误";
        //        return;
        //    }


        //    _View.Employee = InstanceFactory.CreateEmployeeFacade().GetEmployeeByAccountID(employeeID);
        //    if (!isPageValid)
        //    {
        //        _View.txtEmployeeNameReadOnly = true;
        //    }
        //    InitForSpecial(isPageValid);
        //}

    }
}
