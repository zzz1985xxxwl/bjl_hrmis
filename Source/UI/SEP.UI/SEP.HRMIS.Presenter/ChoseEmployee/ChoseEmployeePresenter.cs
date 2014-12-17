//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EditApplicationBase.cs
// 创建者: xue.wenlong
// 创建日期: 2008-08-13
// 概述: 选择员工
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Presenter.IPresenter.IChoseEmployee;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Positions;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;
using PresenterCore = SEP.Presenter.Core;
namespace SEP.HRMIS.Presenter.ChoseEmployee
{
    public class ChoseEmployeePresenter
    {
        public readonly IChoseEmployeeView _View;
        private readonly IPositionBll _IPositionBll = BllInstance.PositionBllInstance;
        private readonly IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private int _PowerID=-1;
        private readonly Account _LoginUser;
        public ChoseEmployeePresenter(IChoseEmployeeView view, Account loginUser)
        {
            _View = view;
            _LoginUser = loginUser;
            AttachViewEvent();
        }

        public int PowerID
        {
            get { return _PowerID; }
            set { _PowerID = value; }
        }

        public void AttachViewEvent()
        {
            _View.SearchAccountEvent += SearchEmployee;
            _View.ToRightEvent += ToRight;
            _View.ToLeftEvent += ToLeft;
            _View.InitView += Init;
        }
        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Init(object sender, EventArgs e)
        {
            _View.PositionList = _IPositionBll.GetAllPosition();
            List<Department> departmentList = BllInstance.DepartmentBllInstance.GetAllDepartment();

            if (_PowerID != -1)
            {
                _View.DepartmentList = Tools.RemoteUnAuthDeparetment(departmentList, AuthType.HRMIS, _LoginUser, _PowerID);
            }
            else
            {
                _View.DepartmentList = departmentList;
            }
            if (_View.AccountRight == null)
            {
                _View.AccountRight = new List<Account>();
            }
            _View.AccountLeft = new List<Account>();
        }

        //public void InitControl()
        //{
        //    _View.PositionList = _IPositionBll.GetAllPosition();
        //    _View.DepartmentList = _IDepartmentBll.GetAllDepartment();
        //    _View.AccountRight = _View.AccountRight;
        //}

        public void SearchEmployee(object sender, EventArgs e)
        {
            int positionID = _View.PositionID;
            int departmentID = _View.DepartmentID;

            List<Account> accountList =
                _IAccountBll.GetAccountByBaseCondition(_View.AccountName, departmentID, positionID, null,true, true);

            if (_PowerID != -1)
            {
                _View.AccountLeft = Tools.RemoteUnAuthAccount(accountList, AuthType.HRMIS, _LoginUser, _PowerID);
            }
            else
            {
                _View.AccountLeft = accountList;
            }

        }

        /// <summary>
        /// 移入员工操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ToRight(object sender, EventArgs e)
        {
            if (!contions(_View.AccountID))
            {
                Account account = new Account();
                account.Id = _View.AccountID;
                account.Name = _View.AccountNameForRight;
                _View.AccountRight.Add(account);
            }
        }

        private bool contions(int i)
        {
            foreach (Account account in _View.AccountRight)
            {
                if (i == account.Id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 移除员工操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ToLeft(object sender, EventArgs e)
        {
            _View.AccountRight.RemoveAll(MatchID);
        }

        private bool MatchID(Account account)
        {
            if (account.Id == _View.AccountID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}