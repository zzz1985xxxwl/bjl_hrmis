//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: AssessActivityListPresenter.cs
// 创建者: 顾艳娟
// 创建日期: 2008-06-23
// 概述: 查询考评活动
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using System.IO;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class AssessActivityListPresenter : BasePresenter
    {
        protected DateTime tempStartTime;
        protected DateTime tempEndTime;
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;

        public IAssessActivityListView _View;

        public AssessActivityListPresenter(IAssessActivityListView view, Account loginUser)
            : base(loginUser)
        {
            if (view == null)
            {
                throw new Exception("view may not be null");
            }
            _View = view;
        }

        public override void Initialize(bool isPostBack)
        {
            //_View.Message = string.Empty;
            if (!isPostBack)
            {
                _View.CharacterTypeSource = AssessActivityUtility.GetAllCharacterTypeEnum();

                _View.StatusTypeSource = AssessActivityUtility.GetAllAssessStatusTypeEnum();
                _View.DepartmentSource = _IDepartmentBll.GetAllDepartment();
                BindAssessActivity(null, null);

            }
        }

        public void BindAssessActivity(object source, EventArgs e)
        {
            if (Validation())
            {
                DateTime dttemp;
                DateTime? dtHRSubmitTimeFrom = null;
                DateTime? dtHRSubmitTimeTo = null;
                DateTime? dtScopeFrom = null;
                DateTime? dtScopeTo = null;
                dtHRSubmitTimeFrom = DateTime.TryParse(_View.HRSubmitTimeFrom, out dttemp) ? dttemp : dtHRSubmitTimeFrom;
                dtHRSubmitTimeTo = DateTime.TryParse(_View.HRSubmitTimeTo, out dttemp) ? dttemp : dtHRSubmitTimeTo;
                dtScopeFrom = DateTime.TryParse(_View.ScopeTimeFrom, out dttemp) ? dttemp : dtScopeFrom;
                dtScopeTo = DateTime.TryParse(_View.ScopeTimeTo, out dttemp) ? dttemp : dtScopeTo;
                try
                {
                    AssessCharacterType assessCharacterType = (AssessCharacterType)Convert.ToInt32(_View.CharacterType);
                    AssessStatus assessStatus = (AssessStatus)Convert.ToInt32(_View.StatusType);
                    //_View.AssessActivitysToList =
                    //    InstanceFactory.AssessActivityFacade().GetAssessActivityByCondition(_View.EmployeeName,
                    //                                                                      assessCharacterType,
                    //                                                                      assessStatus,
                    //                                                                      dtHRSubmitTimeFrom,
                    //                                                                      dtHRSubmitTimeTo,
                    //                                                                      _View.FinishStatus,
                    //                                                                      dtScopeFrom, dtScopeTo,
                    //                                                                      _View.DepartmentID, LoginUser,
                    //                                                                      HrmisPowers.A705);
                    _View.AssessActivitysToList =
                      AssessActivityLogic.GetAssessActivityByCondition(_View.EmployeeName,
                                                                                        assessCharacterType,
                                                                                        assessStatus,
                                                                                        dtHRSubmitTimeFrom,
                                                                                        dtHRSubmitTimeTo,
                                                                                        _View.FinishStatus,
                                                                                        dtScopeFrom, dtScopeTo,
                                                                                        _View.DepartmentID, LoginUser,
                                                                                        HrmisPowers.A705, "", _View.pagerEntity);

                    _View.Message =
                        "<span class='font14b'>共查到 </span>"
                        + "<span class='fontred'>" + _View.AssessActivitysToList.Count + "</span>"
                        + "<span class='font14b'> 个绩效考核活动</span>";
                }
                catch (ApplicationException ex)
                {
                    _View.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

        public void ExecutEvent(object sender, EventArgs e)
        {
            BindAssessActivity(null, null);
        }

        public void BtnInterruptClick(object sender, EventArgs e)
        {
            try
            {
                InstanceFactory.AssessActivityFacade().InterruptActivity(Convert.ToInt32(_View.AssessActivityId));
                BindAssessActivity(null, null);
            }
            catch (Exception ex)
            {
                _View.Message = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        public void BtnEmployeeVisibleClick(string id, string linkBtText)
        {
            try
            {
                bool ifVisible = false;
                if (linkBtText == "设置员工可见")
                {
                    ifVisible = true;
                }
                InstanceFactory.AssessActivityFacade().SetEmployeeVisible(Convert.ToInt32(id), ifVisible);
                BindAssessActivity(null, null);
            }
            catch (Exception ex)
            {
                _View.Message = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        public bool Validation()
        {
            _View.HRSubmitTimeMsg = string.Empty;
            _View.ScopeTimeMsg = string.Empty;

            if (!(VaildateDateTimeFormat(_View.HRSubmitTimeFrom) && VaildateDateTimeFormat(_View.HRSubmitTimeTo)))
            {
                _View.HRSubmitTimeMsg = "时间格式输入不正确";
                return false;
            }
            if (!string.IsNullOrEmpty(_View.HRSubmitTimeFrom) && !string.IsNullOrEmpty(_View.HRSubmitTimeTo))
            {
                if (DateTime.Compare(Convert.ToDateTime(_View.HRSubmitTimeFrom), Convert.ToDateTime(_View.HRSubmitTimeTo)) > 0)
                {
                    _View.HRSubmitTimeMsg = "开始时间不可晚于结束时间";
                    return false;
                }
            }

            if (!(VaildateDateTimeFormat(_View.ScopeTimeFrom) && VaildateDateTimeFormat(_View.ScopeTimeTo)))
            {
                _View.ScopeTimeMsg = "时间格式输入不正确";
                return false;
            }
            if (!string.IsNullOrEmpty(_View.ScopeTimeFrom) && !string.IsNullOrEmpty(_View.ScopeTimeTo))
            {
                if (DateTime.Compare(Convert.ToDateTime(_View.ScopeTimeFrom), Convert.ToDateTime(_View.ScopeTimeTo)) > 0)
                {
                    _View.ScopeTimeMsg = "开始时间不可晚于结束时间";
                    return false;
                }
            }

            return true;
        }
        private bool VaildateDateTimeFormat(string strDateTime)
        {
            if (!string.IsNullOrEmpty(strDateTime))
            {
                if (!DateTime.TryParse(strDateTime, out tempStartTime))
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        public string ExportLeaderEvent(string employeeTemplateLocation)
        {
            return
                InstanceFactory.AssessActivityFacade().ExportLeaderAssessForm(Convert.ToInt32(_View.AssessActivityId),
                                                                            employeeTemplateLocation);
        }

        public string ExportSelfEvent(string employeeTemplateLocation)
        {
            return
                InstanceFactory.AssessActivityFacade().ExportEmployeeSelfAssessForm(
                    Convert.ToInt32(_View.AssessActivityId), employeeTemplateLocation);
        }


        public static string ExportEmployeeSummaryEvent(string employeeTemplateLocationAnnual, string employeeTemplateLocationNormal, int id)
        {
            Model.AssessActivity assess =
               InstanceFactory.AssessActivityFacade().GetAssessActivityByAssessActivityID(
                   id);
            if (assess.AssessCharacterType == AssessCharacterType.Annual)
            {
                return
                    InstanceFactory.AssessActivityFacade().ExportEmployeeAnnualSummary(
                        id, employeeTemplateLocationAnnual);
            }
            else
            {
                return
                    InstanceFactory.AssessActivityFacade().ExportEmployeeNormalSummary(
                        id, employeeTemplateLocationNormal);
            }
        }

        public static string ExportAssessFormEvent(string employeeTemplateLocationAnnual, string employeeTemplateLocationNormal, int id)
        {
            Model.AssessActivity assess =
                InstanceFactory.AssessActivityFacade().GetAssessActivityByAssessActivityID(
                    id);
            if (assess.AssessCharacterType == AssessCharacterType.Annual)
            {
                return
                    InstanceFactory.AssessActivityFacade().ExportAnnualAssessForm(
                        id, employeeTemplateLocationAnnual);
            }
            else
            {
                return
                    InstanceFactory.AssessActivityFacade().ExportExportNormalForContractAssessForm(
                        id, employeeTemplateLocationNormal);
            }
        }

        public MemoryStream ExportAnnualAssessAll(string employeeTemplateLocation)
        {
            if (Validation())
            {
                DateTime dttemp;
                DateTime? dtHRSubmitTimeFrom = null;
                DateTime? dtHRSubmitTimeTo = null;
                DateTime? dtScopeFrom = null;
                DateTime? dtScopeTo = null;
                dtHRSubmitTimeFrom = DateTime.TryParse(_View.HRSubmitTimeFrom, out dttemp) ? dttemp : dtHRSubmitTimeFrom;
                dtHRSubmitTimeTo = DateTime.TryParse(_View.HRSubmitTimeTo, out dttemp) ? dttemp : dtHRSubmitTimeTo;
                dtScopeFrom = DateTime.TryParse(_View.ScopeTimeFrom, out dttemp) ? dttemp : dtScopeFrom;
                dtScopeTo = DateTime.TryParse(_View.ScopeTimeTo, out dttemp) ? dttemp : dtScopeTo;
                AssessStatus assessStatus = (AssessStatus)Convert.ToInt32(_View.StatusType);
                return
                    InstanceFactory.AssessActivityFacade().ExportAnualAssessListExcel(employeeTemplateLocation,
                                                                                    _View.EmployeeName,
                                                                                    dtHRSubmitTimeFrom, dtHRSubmitTimeTo,
                                                                                    _View.FinishStatus, dtScopeFrom,
                                                                                    dtScopeTo, _View.DepartmentID, LoginUser, HrmisPowers.A705, assessStatus);
            }
            return null;
        }

        public string JUDGEERROR
        {
            get { return "JUDGEERROR"; }
        }
        public void DeleteAssessActivity(string id)
        {
            try
            {
                InstanceFactory.AssessActivityFacade().DeleteAssessActivity(Convert.ToInt32(id));
                BindAssessActivity(null, null);
            }
            catch (Exception ex)
            {
                _View.Message = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }
    }
}