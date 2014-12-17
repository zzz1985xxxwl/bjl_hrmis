// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateReimburseCustomerPresenter.cs
// 创建者: 刘丹
// 创建日期: 2009-09-07
// 概述: 添加出差客户界面
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;
using SEP.IBll;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class UpdateReimburseCustomerPresenter
    {
        private readonly IReimburseCustomerView _IReimburseView;
        private readonly Account _LoginUser;
        private readonly int _ReimburseID;
        private readonly ICustomerInfoFacade _ICustomerInfoFacade = InstanceFactory.CreateCustomerInfoFacade();
        private hrmisModel.Reimburse reimburse;
        private readonly IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();

        public UpdateReimburseCustomerPresenter(int reimburseID, Account loginUser, IReimburseCustomerView iReimburseView)
        {
            _LoginUser = loginUser;
            _ReimburseID = reimburseID;
            _IReimburseView = iReimburseView;
            AttachViewEvent();
        }

        public void Init(bool isPostBack)
        {
            if (!isPostBack)
            {
                try
                {
                    _IReimburseView.Message = string.Empty;

                    _IReimburseView.ReimburseCategoriesEnumDataSrc = ReimburseCategoriesEnum.GetAll();

                    reimburse = _IReimburseFacade.GetReimburseByPkid(_ReimburseID);
                    Account account = BllInstance.AccountBllInstance.GetAccountById(reimburse.ApplierID);
                    _IReimburseView.OutCityAllowance = reimburse.OutCityAllowance.ToString();
                    _IReimburseView.ApplierName = account.Name;
                    _IReimburseView.Reimburse = reimburse;
                    _IReimburseView.ReimburseCategoriesEnumID = reimburse.ReimburseCategoriesEnum.Id.ToString();
                    _IReimburseView.PaperCount = reimburse.PaperCount.ToString();
                    _IReimburseView.Destinations = reimburse.Destinations;
                    _IReimburseView.ProjectName = reimburse.ProjectName;
                    _IReimburseView.ConsumeDateFrom = reimburse.ConsumeDateFrom.ToString();
                    _IReimburseView.ConsumeDateTo = reimburse.ConsumeDateTo.ToString();
                    _IReimburseView.DepartmentName = _LoginUser.Dept.DepartmentName;
                    _IReimburseView.ReimburseItemSource = reimburse.ReimburseItems;
                    _IReimburseView.OutCityDays = reimburse.OutCityDays.ToString();
                }
                catch
                {
                    _IReimburseView.Message = "初始化信息失败";
                }
            }
            // 差旅报销
            if (_IReimburseView.ReimburseCategoriesEnumID == "0")
            {
                _IReimburseView.IsTravelReimburse = true;
            }
            // 非差旅报销
            else if (_IReimburseView.ReimburseCategoriesEnumID == "1")
            {
                _IReimburseView.IsTravelReimburse = false;
            }
        }
        public void btnSaveClick(object source, EventArgs e)
        {
            reimburse = _IReimburseView.Reimburse;
            reimburse.ReimburseID = _ReimburseID;
            if (validate())
            {
                Execute();
            }
        }

        private void Execute()
        {
            try
            {
                _IReimburseFacade.UpdateReimburseItemCustomer(reimburse);
                ToMyReimbursePage(null, null);
            }
            catch (ApplicationException ae)
            {
                _IReimburseView.Message = ae.Message;
            }
        }

        public event EventHandler ToMyReimbursePage;

        private void AttachViewEvent()
        {
            _IReimburseView.btnOKClick += btnSaveClick;
        }

        private bool validate()
        {
            bool ret = true;
            string name = string.Empty;
            foreach (hrmisModel.ReimburseItem item in reimburse.ReimburseItems)
            {

                //// 客户不能为空
                if (string.IsNullOrEmpty(item.CustomerName.Trim()))
                {
                    if (_IReimburseView.IsTravelReimburse)
                    {
                        ret = false;
                    }
                    item.CustomerID = 0;
                }
                else
                {
                    CustomerInfo info = _ICustomerInfoFacade.GetCustomerIDInfoByName(item.CustomerName.Trim());
                    if (info == null)
                    {
                        name += item.CustomerName;
                        ret = false;
                    }
                    else
                    {
                        item.CustomerID = info.CustomerInfoId;
                    }
                }

            }
            if (ret == false) _IReimburseView.Message = name + "客户信息不在系统中或者差旅报销单客户信息必填";
            return ret;
        }

    }
}
