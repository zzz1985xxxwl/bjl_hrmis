//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkConfirmHistroyPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-04-17
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.OverWorks
{
    public class OverWorkConfirmHistroyPresenter
    {
        private readonly IOverWorkConfirmHistroyView _View;
        private readonly IOverWorkFacade _IOverWork = InstanceFactory.CreateOverWorkFacade();
        private readonly Account _LoginUser;

        public OverWorkConfirmHistroyPresenter(IOverWorkConfirmHistroyView view, Account loginUser,
                                                     bool isPostBack)
        {
            _View = view;
            _LoginUser = loginUser;
            AttachViewEvent();
            Init(isPostBack);
        }

        private void AttachViewEvent()
        {
            _View.BindOverWorkSource += BindOverWorkSource;
        }
        private void Init(bool isPostBack)
        {
            if (!isPostBack)
            {
                _View.FromDate = new HrmisUtility().CurrenMonthStartTime().ToShortDateString();
                _View.ToDate = new HrmisUtility().CurrenMonthEndTime().ToShortDateString();
                List<OverWork> overWorkSourceAll = _IOverWork.GetConfirmHistroy(_LoginUser.Id, _View.EmployeeName, _View.Adjust, Convert.ToDateTime(_View.FromDate),
                                                                    Convert.ToDateTime(_View.ToDate));
                if (overWorkSourceAll.Count == 0)
                {
                    _View.DisplaySearchCondition = false;
                }
             
                BindOverWorkSource(null, null);
            }
        }
        
        private void BindOverWorkSource(object source, EventArgs e)
        {
            if (CheckValid())
            {
                _View.OverWorkSource = _IOverWork.GetConfirmHistroy(_LoginUser.Id, _View.EmployeeName, _View.Adjust,
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