//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ConfrimOutApplicationItemPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-05-07
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IOutApplication;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.OutApplications
{
    public class ConfrimOutApplicationItemPresenter
    {
        private readonly IOutApplicationFacade _IOutApplication = InstanceFactory.CreateOutApplicationFacade();
        private readonly Account _LoginUser;
        private readonly ICancelOutApplicationItemView _View;

        public ConfrimOutApplicationItemPresenter(ICancelOutApplicationItemView view, Account loginUser, bool isPostBack)
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
            OutApplication outApplication =
                _IOutApplication.GetOutApplicationByOutApplicationID(_View.ApplicationID);
            _View.EmployeeName = outApplication.Account.Name;
            _View.EmployeeID = outApplication.Account.Id;
            _View.TimeSpan = outApplication.FromDate + " ～ " + outApplication.ToDate;
            _View.CostTime = outApplication.CostTime.ToString();
            _View.OutLocation = outApplication.OutLocation;
            _View.OperationType = OperationType.Confirm;
            _View.ApproveStatusSource = RequestUtility.GetConfirmChose();
            _View.Reason = outApplication.Reason;
            if(outApplication.OutType==OutType.OutCity)
            {
                _IOutApplication.SetCanChangeAdjust(outApplication);
            }
            _View.ApplicationItemList = outApplication.Item;
            _View.OutType = outApplication.OutType;
        }

        private void SaveEvent(object source, EventArgs e)
        {
            if (CheckValidate())
            {
                int failCount = 0;
                int successCount = 0;
                foreach (OutApplicationItem item in _View.ApplicationItemList)
                {
                    try
                    {
                        _IOutApplication.ApproveOutApplicationItem(item.ItemID, _LoginUser.Id, item.Status.Id == 0,
                                                                   item.OutApplicationFlow[0].Remark,
                                                                   _View.ApplicationID,item.Adjust,item.AdjustHour);
                        successCount++;
                    }
                    catch
                    {
                        failCount++;
                    }
                }      
                _View.ResultMessage = successCount + "个外出项成功审核，" + failCount + "个外出项审核失败";
                Init();
            }
        }

        private bool CheckValidate()
        {
            bool result = true;

            try
            {
                List<OutApplicationItem> outitems = _View.ApplicationItemList;
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