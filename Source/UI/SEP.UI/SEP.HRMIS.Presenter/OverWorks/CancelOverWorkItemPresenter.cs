//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CancelOverWorkItemPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-05-06
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
    public class CancelOverWorkItemPresenter
    {
        private readonly IOverWorkFacade _IOverWork = InstanceFactory.CreateOverWorkFacade();
        private readonly ICancelOverWorkItemView _View;

        public CancelOverWorkItemPresenter(ICancelOverWorkItemView view, bool isPostBack)
        {
            _View = view;
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
            _View.OperationType = OperationType.Cancel;
            _View.ApproveStatusSource = RequestUtility.GetCancelChose();
            _View.Reason = OverWork.Reason;
            _View.ApplicationItemList = OverWork.Item;
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
                        Account cancelAccount = new Account(_View.EmployeeID, "", _View.EmployeeName);
                        _IOverWork.CancelOverWorkItem(item.ItemID, item.OverWorkFlow[0].Remark,
                                                                  cancelAccount);
                        successCount++;
                    }
                    catch
                    {
                        failCount++;
                    }
                }
                _View.ResultMessage = successCount + "个加班项成功取消，" + failCount + "个加班项取消失败";
                Init();
            }
        }


        private bool CheckValidate()
        {
            bool result = true;

            try
            {
                foreach (OverWorkItem item in _View.ApplicationItemList)
                {
                    if (string.IsNullOrEmpty(item.OverWorkFlow[0].Remark))
                    {
                        _View.ResultMessage = "备注不能为空";
                        result = false;
                    }
                }
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