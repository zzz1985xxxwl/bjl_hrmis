//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SendMailForBulletinPresenter.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-17
// 概述: 增加SendMailForBulletinPresenter
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Bulletins;
using SEP.IBll.Departments;
using SEP.IBll.Positions;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Bulletins;
using SEP.Model.Utility;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IBulletins;

namespace SEP.Presenter
{
    public class SendMailForBulletinPresenter : BasePresenter
    {
        private readonly ISendMailForBulletinView _View;
        private IPositionBll _IPosition;
        private IDepartmentBll _IDepartment;
        private IAccountBll _IAccount;
        private IBulletinBll _IBulletin;

        public delegate void _SendMail(
            int BulletinID, List<Account> employeeRight, IAccountBll iGetEmployee);

        public SendMailForBulletinPresenter(ISendMailForBulletinView view, Account loginUser) : base(loginUser)
        {
            _View = view;
            AttachViewEvent();
            BindBll();
        }

        private void AttachViewEvent()
        {
            _View.SearchEmployeeEvent += SearchEmployee;
            _View.SendMailEvent += SendMail;
            _View.ToRightEvent += ToRight;
            _View.ToLeftEvent += ToLeft;
            _View.InitView += Init;
        }

        private void BindBll()
        {
            _IPosition = BllInstance.PositionBllInstance;
            _IDepartment = BllInstance.DepartmentBllInstance;
            _IAccount = BllInstance.AccountBllInstance;
            _IBulletin = BllInstance.BulletinBllInstance;
        }

        public void Init(object sender, EventArgs e)
        {
            _View.PositionList = _IPosition.GetAllPosition();
            _View.DepartmentList =
                Tools.RemoteUnAuthDeparetment(_IDepartment.GetAllDepartment(), AuthType.SEP, LoginUser, Powers.A302);
            _View.EmployeeRight = new List<Account>();
            _View.EmployeeLeft = new List<Account>();
            Bulletin bulletin = _IBulletin.GetBulletinByBulletinID(_View.BulletinID, LoginUser);
            _View.BulletinTitle = bulletin.Title;
        }

        public void SearchEmployee(object sender, EventArgs e)
        {
            int positionID = _View.PositionID;
            int departmentID = _View.DepartmentID;
            _View.EmployeeLeft =
                BulletinUtility.RemoteUnAuthAccount(
                    _IAccount.GetAccountByBaseCondition(_View.EmployeeName, departmentID, positionID,null, true, true),
                    AuthType.SEP, LoginUser, Powers.A302);
        }

        public void ToRight(object sender, EventArgs e)
        {
            if (!contions(_View.EmployeeID))
            {
                Account employee = new Account();
                employee.Name = _View.EmployeeNameForRight;
                employee.Id = _View.EmployeeID;
                _View.EmployeeRight.Add(employee);
            }
        }

        private bool contions(int i)
        {
            foreach (Account employee in _View.EmployeeRight)
            {
                if (i == employee.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public void ToLeft(object sender, EventArgs e)
        {
            _View.EmployeeRight.RemoveAll(MatchID);
        }

        private bool MatchID(Account employee)
        {
            if (employee.Id == _View.EmployeeID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SendMail(object sender, EventArgs e)
        {
            _View.MessageFromBll = "";
            if (_View.EmployeeRight == null || _View.EmployeeRight.Count == 0)
            {
                _View.MessageFromBll = "请选择收件人";
                return;
            }
            _SendMail sendMailDelegate = SendEmailForEmployees;
            sendMailDelegate.BeginInvoke(_View.BulletinID, _View.EmployeeRight, _IAccount,null,null);
            _View.MessageFromBll = "邮件已发送";
        }

        public static void SendEmailForEmployees(int bulletinID, List<Account> employeeRight, IAccountBll account)
        {
            try
            {
                IBulletinBll bulletinBll = BllInstance.BulletinBllInstance;
                foreach (Account tempEmployee in employeeRight)
                {
                    Account employee = account.GetAccountById(tempEmployee.Id);

                    if (employee.AccountType == VisibleType.None || !employee.IsAcceptEmail)
                        continue;

                    string to = employee.Email1;
                    bulletinBll.SendEmailForBulletin(bulletinID, to, null);
                    if (!string.IsNullOrEmpty(employee.Email2))
                    {
                        to = employee.Email2;
                        bulletinBll.SendEmailForBulletin(bulletinID, to, null);
                    }
                }
             
            }
            catch(Exception ex)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(@"c:\faildMails.txt", true);
                    sw.WriteLine( ex.Message);
                    if(ex.InnerException!=null)
                    {
                        sw.WriteLine(ex.InnerException.Message);
                    }
                    sw.Flush();
                    sw.Close();
                }
                catch
                {
                }
            }
        }

        public override void Initialize(bool isPostBack)
        {
            throw new NotImplementedException();
        }
    }
}