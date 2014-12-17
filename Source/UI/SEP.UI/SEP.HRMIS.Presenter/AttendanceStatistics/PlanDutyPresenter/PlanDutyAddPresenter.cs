//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PlanDutyAddPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2009-04-17
// 概述: 设置排班
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter
{
    public class PlanDutyAddPresenter
    {
        private readonly IPlanDutyFacade _IPlanDutyFacade = InstanceFactory.CreatePlanDutyFacade();
        private readonly ISetPlanDutyInfoView _ItsView;
        private readonly PlanDutyUtility planDutyUtility;
        public PlanDutyAddPresenter(ISetPlanDutyInfoView itsView, Account _Account)
        {
            _ItsView = itsView;
            _ItsView.SetPlanDutyView.OperationTitle = PlanDutyUtility.AddPageTitle;
            planDutyUtility = new PlanDutyUtility(itsView, _IPlanDutyFacade, _Account);
            AttachViewEvent();
        }
        public void InitView(bool IsPostBack, DateTime date)
        {
            planDutyUtility.InitView(IsPostBack);
            if (!IsPostBack)
            {
                _ItsView.SetPlanDutyView.CurrentDay = date;
                //初始化,绑定为公司日历
                _ItsView.SetPlanDutyView.SavePlanDutyDetailListViewState(
                    planDutyUtility.InitNewPlanDutyDetailList(date), date.Year + ";" + date.Month);
            }
        }
       
        public void AttachViewEvent()
        {
            _ItsView.SetPlanDutyView.btnCopyEvent += planDutyUtility.CopyEvent;
            _ItsView.SetPlanDutyView.btnPasteEvent += planDutyUtility.PasteEvent;
            _ItsView.SetPlanDutyView.CreatePlanDutyClick += planDutyUtility.CreatePlanDutyClickEvent;
            _ItsView.SetPlanDutyView.DutyClassDisplaceClick += planDutyUtility.DutyClassDisplaceEvent;
            _ItsView.SetPlanDutyView.ChangeMonthClick += planDutyUtility.SavePlanDutyViewStateForChangeMonthEvent;
            _ItsView.ChoseEmployeeView.SavePlanDutyViewState += planDutyUtility.SavePlanDutyViewStateEvent;
            _ItsView.ReplaceDutyClassView.BtnReplaceEvent += planDutyUtility.ReplaceDutyClassEvent;
            _ItsView.ReplaceDutyClassView.BtnddSelectedIndexChangedEvent += planDutyUtility.ShowReplaceDutyClassView;
            _ItsView.ReplaceDutyClassView.DataBindEvent += planDutyUtility.ReplaceDutyClassDateBind;
        }


        public void InitView(bool pageIsPostBack)
        {
            throw new NotImplementedException();
        }
    }
}