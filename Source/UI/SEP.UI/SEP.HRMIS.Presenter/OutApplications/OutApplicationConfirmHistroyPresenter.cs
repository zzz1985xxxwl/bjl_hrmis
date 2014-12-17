//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutApplicationConfirmHistroyPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-04-17
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Presenter.IPresenter.IOutApplication;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.OutApplications
{
    public class OutApplicationConfirmHistroyPresenter
    {
        private readonly IOutApplicationConfirmHistroyView _View;
        private readonly IOutApplicationFacade _IOutApplication = InstanceFactory.CreateOutApplicationFacade();
        private readonly Account _LoginUser;

        public OutApplicationConfirmHistroyPresenter(IOutApplicationConfirmHistroyView view, Account loginUser,
                                                     bool isPostBack)
        {
            _View = view;
            _LoginUser = loginUser;
            AttachViewEvent();
            Init(isPostBack);
        }

        private void AttachViewEvent()
        {
            _View.BindOutApplicationSource += BindOutApplicationSource;
        }

        private void Init(bool isPostBack)
        {
            if (!isPostBack)
            {
                _View.FromDate = DateTime.Now.ToShortDateString();
                _View.ToDate = DateTime.Now.ToShortDateString();
                List<OutApplication> OutApplicationSourceAll = _IOutApplication.GetConfirmHistroy(_LoginUser.Id,
                                                                                             _View.EmployeeName,
                                                                                              Convert.ToDateTime(_View.FromDate), Convert.ToDateTime(_View.ToDate));
                if (OutApplicationSourceAll.Count == 0)
                {
                    _View.DisplaySearchCondition = false;
                }
                BindOutApplicationSource(null, null);
            }
        }

        private void BindOutApplicationSource(object source, EventArgs e)
        {
            if (CheckValid())
            {
                _View.OutApplicationSource =
                    _IOutApplication.GetConfirmHistroy(_LoginUser.Id, _View.EmployeeName,
                                                       Convert.ToDateTime(_View.FromDate),
                                                       Convert.ToDateTime(_View.ToDate));
            }
        }

        #region 时间验证

        private DateTime _DayFrom = new DateTime(1900, 1, 1);
        private DateTime _DayTo = new DateTime(2999, 12, 31);

        public bool CheckValid()
        {
            if (VaildateDayFrom() && ValidateDayTo())
            {
                if (DateTime.Compare(_DayFrom, _DayTo) > 0)
                {
                    _View.DateMsg = "开始时间不可晚于结束时间";
                    return false;
                }
                else
                {
                    _View.DateMsg = string.Empty;
                    return true;
                }
            }
            return false;
        }

        private bool VaildateDayFrom()
        {
            if (!string.IsNullOrEmpty(_View.FromDate))
            {
                if (!DateTime.TryParse(_View.FromDate, out _DayFrom))
                {
                    _View.DateMsg = "时间格式输入不正确";
                    return false;
                }
            }
            return true;
        }

        private bool ValidateDayTo()
        {
            if (!string.IsNullOrEmpty(_View.ToDate))
            {
                if (!DateTime.TryParse(_View.ToDate, out _DayTo))
                {
                    _View.DateMsg = "时间格式输入不正确";
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}