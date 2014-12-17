using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class MyLeaveRequestConfirmHistoryListPresenter : PresenterCore.BasePresenter
    {
        private readonly ILeaveRequestFacade _ILeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();
        private readonly IMyLeaveRequestConfirmHistoryListView _ItsView;

        public MyLeaveRequestConfirmHistoryListPresenter(IMyLeaveRequestConfirmHistoryListView view, Account loginUser)
            : base(loginUser)
        {
            _ItsView = view;
        }

        private void AttachViewEvent()
        {
            _ItsView.BindLeaveRequestSource += BindLeaveRequestSource;
        }
        public override void Initialize(bool isPostBack)
        {
            AttachViewEvent();

            if (!isPostBack)
            {

                _ItsView.FromDate = new HrmisUtility().CurrenMonthStartTime().ToShortDateString();
                _ItsView.ToDate = new HrmisUtility().CurrenMonthEndTime().ToShortDateString();

                List<LeaveRequest> leaveRequestSourceAll =
                    _ILeaveRequestFacade.GetLeaveRequestConfirmHistoryByOperatorID(LoginUser.Id, _ItsView.EmployeeName,
                                                                                     Convert.ToDateTime(_ItsView.FromDate),
                                                                                   Convert.ToDateTime(_ItsView.ToDate));
                if (leaveRequestSourceAll.Count == 0)
                {
                    _ItsView.DisplaySearchCondition = false;
                }

                BindLeaveRequestSource(null, null);
            }
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BindLeaveRequestSource(object sender, EventArgs e)
        {
            if (CheckValid())
            {
                _ItsView.LeaveRequestSource =
                    _ILeaveRequestFacade.GetLeaveRequestConfirmHistoryByOperatorID(LoginUser.Id, _ItsView.EmployeeName,
                                                                                   Convert.ToDateTime(_ItsView.FromDate),
                                                                                   Convert.ToDateTime(_ItsView.ToDate));
            }
        }

        #region 时间验证

        private DateTime _DayFrom = new DateTime(1900, 1,1);
        private DateTime _DayTo = new DateTime(2999, 12, 31);

        public bool CheckValid()
        {
            if( VaildateDayFrom() && ValidateDayTo())
            {
                if (DateTime.Compare(_DayFrom, _DayTo) > 0)
                {
                    _ItsView.DateMsg = "开始时间不可晚于结束时间";
                    return false;
                }
                else
                {
                    _ItsView.DateMsg = string.Empty;
                    return true;
                }
            }
            return false;
        }

        private bool VaildateDayFrom()
        {
            if (!string.IsNullOrEmpty(_ItsView.FromDate))
            {
                if (!DateTime.TryParse(_ItsView.FromDate, out _DayFrom))
                {
                    _ItsView.DateMsg = "时间格式输入不正确";
                    return false;
                }
            }
            return true;
        }

        private bool ValidateDayTo()
        {
            if (!string.IsNullOrEmpty(_ItsView.ToDate))
            {
                if (!DateTime.TryParse(_ItsView.ToDate, out _DayTo))
                {
                    _ItsView.DateMsg = "时间格式输入不正确";
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}