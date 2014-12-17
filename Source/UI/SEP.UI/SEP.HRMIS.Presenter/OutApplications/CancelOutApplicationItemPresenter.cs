//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CancelOutApplicationItemPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-05-06
// Resume:
// ---------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IOutApplication;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Presenter.OutApplications
{
    public class CancelOutApplicationItemPresenter
    {
        private readonly IOutApplicationFacade _IOutApplication = InstanceFactory.CreateOutApplicationFacade();
        private readonly ICancelOutApplicationItemView _View;

        public CancelOutApplicationItemPresenter(ICancelOutApplicationItemView view, bool isPostBack)
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
            OutApplication outApplication =
                _IOutApplication.GetOutApplicationByOutApplicationID(_View.ApplicationID);
            _View.EmployeeName = outApplication.Account.Name;
            _View.EmployeeID = outApplication.Account.Id;
            _View.TimeSpan = outApplication.FromDate + " ～ " + outApplication.ToDate;
            _View.CostTime = outApplication.CostTime.ToString();
            _View.OutLocation = outApplication.OutLocation;
            _View.OperationType = OperationType.Cancel;
            _View.ApproveStatusSource = RequestUtility.GetCancelChose();
            _View.Reason = outApplication.Reason;
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
                        Account cancelAccount = new Account(_View.EmployeeID, "", _View.EmployeeName);
                        _IOutApplication.CancelOutApplicationItem(item.ItemID, item.OutApplicationFlow[0].Remark,
                                                                  cancelAccount);
                        successCount++;
                    }
                    catch
                    {
                        failCount++;
                    }
                }
                _View.ResultMessage = successCount + "个外出项成功取消，" + failCount + "个外出项取消失败";
                Init();
            }
        }


        private bool CheckValidate()
        {
            bool result = true;

            try
            {
                foreach (OutApplicationItem item in _View.ApplicationItemList)
                {
                    if (string.IsNullOrEmpty(item.OutApplicationFlow[0].Remark))
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