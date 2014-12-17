//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SearchContractListPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-06-23
// 概述: 员工合同查询presenter
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter
{
    public class SearchContractListPresenter
    {
        private IContractTypeFacade _IContractTypeFacade = InstanceFactory.CreateContractTypeFacade();
        private IEmployeeContractFacade _IEmployeeContractFacade = InstanceFactory.CreateEmployeeContractFacade();
        private readonly ISearchContractListView _View;
        private readonly DateTime _DateFrom=Convert.ToDateTime("1900-1-1");
        private readonly DateTime _DateTo = Convert.ToDateTime("2999-12-31");
        private List<Contract> _contracts;
        private int _ContractID;
        private int _EmployeeID;
        private readonly Account _Operator;
        public SearchContractListPresenter(ISearchContractListView view, Account _operator)
        {
            _View = view;
            _Operator = _operator;
        }

        public void InitView(bool isPostBack)
        {
            _View.TimeErrorMessage = string.Empty;
            if (!isPostBack)
            {
                _View.ContractTypeSource = _IContractTypeFacade.GetContractTypeByCondition(-1, string.Empty);
            }
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            _View.ContractEditEvent += UpdateContractEvent;
            _View.ContractDeleteEvent += DeleteContractEvent;
            _View.ContractDownLoadEvent += ContractDownLoadEvent;
            _View.IsDownLoadEnable += IsDownEnable;
        }

        public void SearchEvent(object sender, EventArgs e)
        {
            if (Validate())
            {
                try
                {
                    // modify by liudan  add condition EmployeeStatus 2009-08-20
                    //_contracts =
                    //    _IEmployeeContractFacade.GetEmployeeContractByCondition(_View.EmployeeName, _OutStartFrom,
                    //                                                            _OutStartTo,
                    //                                                            _OutEndFrom,
                    //                                                            _OutEndTo,
                    //                                                            Convert.ToInt32(_View.ContractTypeId),
                    //                                                            _Operator);
                    _contracts =
    _IEmployeeContractFacade.GetEmployeeContractByCondition(_View.EmployeeName, _OutStartFrom,
                                                            _OutStartTo,
                                                            _OutEndFrom,
                                                            _OutEndTo,
                                                            Convert.ToInt32(_View.ContractTypeId),
                                                            _Operator, Convert.ToInt32(_View.EmployeeStatusId));
                    _View.contracts = _contracts;
                    _View.TimeErrorMessage = "<span class='font14b'>共查到 </span>"
                                             + "<span class='fontred'>" + _contracts.Count + "</span>"
                                             + "<span class='font14b'> 条信息</span>";
                }
                catch (Exception ex)
                {
                    _View.TimeErrorMessage = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

        #region Validate

        public bool Validate()
        {
            if ( !(VaildatStartFrom() && VaildatStartTo() && VaildatEndFrom()
                  && VaildatEndTo()))
            {
                return false;
            }
            if (DateTime.Compare(_OutStartFrom, _OutStartTo) > 0)
            {
                _View.TimeErrorMessage = "<span class='fontred'>合同开始时间段不正确</span>";
                return false;
            }
            if (DateTime.Compare(_OutEndFrom,_OutEndTo) > 0)
            {
                _View.TimeErrorMessage = "<span class='fontred'>合同结束时间段不正确</span>";
                return false;
            }
            return true;
        }

        private DateTime _OutStartFrom;
        private bool VaildatStartFrom()
        {
            if (string.IsNullOrEmpty(_View.StartTimeFrom))
            {
                _OutStartFrom = _DateFrom;
                return true;
            }
            if (!DateTime.TryParse(_View.StartTimeFrom, out _OutStartFrom))
            {
                _View.TimeErrorMessage = "开始时间格式输入不正确";
                return false;
            }
            else
            {
                return true;
            }
        }

        private DateTime _OutStartTo;
        private bool VaildatStartTo()
        {
            if (string.IsNullOrEmpty(_View.StartTimeTo))
            {
                _OutStartTo = _DateTo;
                return true;
            }
            if (!DateTime.TryParse(_View.StartTimeTo, out _OutStartTo))
            {
                _View.TimeErrorMessage = "开始时间格式输入不正确";
                return false;
            }
            else
            {
                return true;
            }
        }

        private DateTime _OutEndFrom;
        private bool VaildatEndFrom()
        {
            if (string.IsNullOrEmpty(_View.EndTimeFrom))
            {
                _OutEndFrom = _DateFrom;
                return true;
            }
            if (!DateTime.TryParse(_View.EndTimeFrom, out _OutEndFrom))
            {
                _View.TimeErrorMessage = "结束时间格式输入不正确";
                return false;
            }
            else
            {
                return true;
            }
        }

        private DateTime _OutEndTo;
        private bool VaildatEndTo()
        {
            if (string.IsNullOrEmpty(_View.EndTimeTo))
            {
                _OutEndTo = _DateTo;
                return true;
            }
            if (!DateTime.TryParse(_View.EndTimeTo, out _OutEndTo))
            {
                _View.TimeErrorMessage = "结束时间格式输入不正确";
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        public EventHandler ToContractDeletePage;
        public void DeleteContractEvent(object sender, CommandEventArgs e)
        {
            string[] temp = e.CommandArgument.ToString().Split('&');
            if (temp.Length != 2)
            {
                _View.ResultMessage = "数据库访问错误";
                return;
            }
            if (!int.TryParse(temp[1], out _ContractID))
            {
                _View.ResultMessage = "合同编号不存在";
                return;
            }
            if (!int.TryParse(temp[0], out _EmployeeID))
            {
                _View.ResultMessage = "员工编号不存在";
                return;
            }
            ToContractDeletePage(sender, null);
        }

        public EventHandler ToContractUpdatePage;
        public void UpdateContractEvent(object sender, CommandEventArgs e)
        {
            string[] temp = e.CommandArgument.ToString().Split('&');
            if (temp.Length != 2)
            {
                _View.ResultMessage = "数据库访问错误";
                return;
            }
            if (!int.TryParse(temp[1], out _ContractID))
            {
                _View.ResultMessage = "合同编号不存在";
                return;
            }
            if (!int.TryParse(temp[0], out _EmployeeID))
            {
                _View.ResultMessage = "员工编号不存在";
                return;
            }
            ToContractUpdatePage(sender, null);
        }

        public int ContractID
        {
            get { return _ContractID; }
            set { _ContractID = value; }
        }

        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        public string ContractDownLoadEvent(int contractID)
        {
            return _IEmployeeContractFacade.ExportEmployeeContract(contractID);
        }

        public bool IsDownEnable(int contractID)
        {
            return _IContractTypeFacade.GetContractTypeByContractID(contractID).HasTemplate;
        }

        #region user for tests

        public IContractTypeFacade SetGetContractType
        {
            set
            {
                _IContractTypeFacade = value;
            }
        }

        public IEmployeeContractFacade SetGetEmployeeContract
        {
            set
            {
                _IEmployeeContractFacade = value;
            }
        }

        #endregion
    }
}
