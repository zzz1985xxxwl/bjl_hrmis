//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ConfrimOverWorkItemPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-05-07
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;
using SEP.HRMIS.Presenter.OutApplications;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.OverWorks
{
    public class ConfrimOverWorkItemPresenter
    {
        private readonly IOverWorkFacade _IOverWork = InstanceFactory.CreateOverWorkFacade();
        private readonly Account _LoginUser;
        private readonly ICancelOverWorkItemView _View;
        private readonly IEmployeeAttendanceFacade _IEmployeeAttendanceFacade = InstanceFactory.CreateEmployeeAttendanceFacade();

        public ConfrimOverWorkItemPresenter(ICancelOverWorkItemView view, Account loginUser, bool isPostBack)
        {
            _View = view;
            _LoginUser = loginUser;
            AttachViewEvent();
            InitPresenter(isPostBack);
        }

        private void AttachViewEvent()
        {
            _View.btnOKClick += SaveEvent;
        }

        private void InitPresenter(bool ispostback)
        {
            _View.ResultMessage = string.Empty;
            if (!ispostback)
            {
                Init();
            }
        }

        private void Init()
        {
            OverWork OverWork =
                _IOverWork.GetOverWorkByOverWorkID(_View.ApplicationID);
            _View.EmployeeName = OverWork.Account.Name;
            _View.EmployeeID = OverWork.Account.Id;
            _View.TimeSpan = OverWork.FromDate + " ～ " + OverWork.ToDate;
            _View.CostTime = OverWork.CostTime.ToString();
            _View.OutLocation = OverWork.ProjectName;
            _View.OperationType = OperationType.Confirm;
            _View.ApproveStatusSource = RequestUtility.GetConfirmChose();
            _View.Reason = OverWork.Reason;
            _IOverWork.SetCanChangeAdjust(OverWork);
            _View.ApplicationItemList = OverWork.Item;
            _View.SurplusAdjustRest = "剩余调休" +
                          _IEmployeeAttendanceFacade.GetAdjustRestRemainedDaysByEmployeeID(
                              OverWork.Account.Id) + "小时";

        }

        private void SaveEvent(object source, EventArgs e)
        {
            if (CheckValidate())
            {
                int failCount = 0;
                int successCount = 0;
                foreach (OverWorkItem item in _View.ApplicationItemList)
                {
                    try
                    {
                        _IOverWork.ApproveOverWorkItem(item.ItemID, _LoginUser.Id, item.Status.Id == 0,
                                                                   item.OverWorkFlow[0].Remark, item.Adjust,
                                                                   _View.ApplicationID,item.AdjustHour);
                        successCount++;
                    }
                    catch
                    {
                        failCount++;
                    }
                }      
                _View.ResultMessage = successCount + "个加班项成功审核，" + failCount + "个加班项审核失败";
                Init();
            }
        }

        private bool CheckValidate()
        {
            bool result = true;

            try
            {
                List<OverWorkItem> outitems = _View.ApplicationItemList;
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("格式"))
                {
                    _View.ResultMessage = "请选择一种操作";
                    result = false;
                }
            }
            if (result)
            {
                _View.ResultMessage = string.Empty;
            }
            return result;
        }
    }
}