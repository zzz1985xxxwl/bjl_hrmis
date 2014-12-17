//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SetPlanDutyPresenter.cs
// 创建者: SYY
// 创建日期: 2009-04-17
// 概述: 排班列表
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;
namespace SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter
{
    public class PlanDutyListPresenter : PresenterCore.BasePresenter
    {
        private readonly IPlanDutyListView _View;
        private IPlanDutyFacade _IPlanDutyFacade = InstanceFactory.CreatePlanDutyFacade();

        public PlanDutyListPresenter(IPlanDutyListView itsView, Account loginUser)
            : base(loginUser)
        {
            _View = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _View.BtnSearchEvent += RuleDataBind;
            _View.BtnDeleteEvent += DeletePlanDuty;
            _View.BtnCopyEvent += CopyEvent;
        }
        private void CopyEvent(string id)
        {
            int id_Int;
            if (!int.TryParse(id, out id_Int))
            {
                _View.TitleMessage = "排班表ID需为整数";
                return;
            }
            PlanDutyTable planDutyTable = _IPlanDutyFacade.GetPlanDutyTableByPKID(id_Int);
            try
            {
                _View.SessionCopyPlanDutyTable = planDutyTable;
                _View.TitleMessage = "复制成功！";

            }
            catch (ApplicationException ae)
            {
                _View.TitleMessage = ae.Message;
            }

        }
        private void DeletePlanDuty(string id)
        {
            _IPlanDutyFacade.DeletePlanDuty(Convert.ToInt32(id));
            RuleDataBind();
        }

        public void RuleDataBind()
        {
            bool dateTimeCheck = true;
            //查询事件
            DateTime dateFrom = new DateTime();
            DateTime dateTo = new DateTime();
            if (String.IsNullOrEmpty(_View.DateFrom))
            {
                dateFrom = Convert.ToDateTime("1900/01/01");
            }
            else if (DateTime.TryParse(_View.DateFrom, out dateFrom))
            {
                dateFrom = Convert.ToDateTime(_View.DateFrom);
            }
            else
            {
                dateTimeCheck = false;
                _View.DateFromMessage = "检索时间格式不正确";
            }
            if (String.IsNullOrEmpty(_View.DateTo))
            {
                dateTo = Convert.ToDateTime("2999/12/31");
            }
            else if (DateTime.TryParse(_View.DateTo, out dateTo))
            {
                dateTo = Convert.ToDateTime(_View.DateTo);
            }
            else
            {
                dateTimeCheck = false;
                _View.DateToMessage = "检索时间格式不正确";
            }
            if (dateTimeCheck)
            {
                List<PlanDutyTable> planDutyTables =
                    _IPlanDutyFacade.GetPlanDutyTableByCondition(_View.PlanDutyTableName,
                                                                 dateFrom,
                                                                 dateTo, _View.EmployeeName,LoginUser);
                _View.PlanDutyTables = planDutyTables;
            }
            else
            {
                //_View.Message = "检索时间格式不正确";
            }
        }

        public override void Initialize(bool isPostBack)
        {
            _View.DateFromMessage = string.Empty;
            _View.DateToMessage = string.Empty;
            _View.TitleMessage = string.Empty;
            if (!isPostBack)
            {
                RuleDataBind();
            }
        }
    }
}
