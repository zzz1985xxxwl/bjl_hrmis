//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PlanDutyDetailPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2009-05-12
// 概述: 查看排班
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter
{
    public class PlanDutyDetailPresenter
    {
        private readonly IPlanDutyFacade _IPlanDutyFacade = InstanceFactory.CreatePlanDutyFacade();
        private readonly ISetPlanDutyInfoView _ItsView;
        private readonly PlanDutyUtility planDutyUtility;
        public PlanDutyDetailPresenter(ISetPlanDutyInfoView itsView, Account _Account)
        {
            _ItsView = itsView;
            _ItsView.SetPlanDutyView.OperationTitle = PlanDutyUtility.DetailPageTitle;
            planDutyUtility = new PlanDutyUtility(itsView, _IPlanDutyFacade, _Account);
            AttachViewEvent();
        }
        public void InitView(bool IsPostBack, string id)
        {
            planDutyUtility.InitView(IsPostBack);
            if (!IsPostBack)
            {
                planDutyUtility.GetPlanDutyByID(id);
            }
            _ItsView.SetPlanDutyView.SetFormReadOnly = true;
        }
        public void AttachViewEvent()
        {
            _ItsView.SetPlanDutyView.btnCopyEvent += planDutyUtility.CopyEvent;
        }


        public void InitView(bool pageIsPostBack)
        {
            throw new NotImplementedException();
        }
    }
}

