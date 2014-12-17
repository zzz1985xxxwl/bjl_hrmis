
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Model.SpecialDates;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter
{
    public interface ISetPlanDutyView
    {
        PlanDutyTable SessionCopyPlanDutyTable { get;set;}
        string OperationTitle { get;set;}
        bool SetFormReadOnly { set;}
        string Message { get;set;}
        string EmployeeList { get;set;}
        List<PlanDutyDetail> PlanDutyDateSource { get;set;}
        List<DutyClass> DutyClassList { get;set;}

        List<SpecialDate> SpecialDates { get;set;}
        DateTime CurrentDay { get; set; }
        string PlanDutyID { get; set; }
        string PlanDutyTableName{ get; set; }
        string FromTime { get; set; }
        string ToTime { get; set; }
        string Period { get; set; }
        string PlanDutyNameMessage { get; set; }
        string TimeMessage{ get; set; }
        string PeriodMessage { get; set; }
        bool SetbtnPlasterPlanDuty { set; }
        event DelegateNoParameter CreatePlanDutyClick;
        event Delegate2Parameter DutyClassDisplaceClick;
        event DelegateID ChangeMonthClick;
        event DelegateNoParameter btnCopyEvent;
        event DelegateNoParameter btnPasteEvent;
        /// <summary>
        /// 得到某一时间的PlanDutyDetailList
        /// </summary>
        /// <param name="viewStateName"></param>
        /// <returns></returns>
        List<PlanDutyDetail> GetViewState(string viewStateName);
        /// <summary>
        /// 得到当前的PlanDutyDetailList
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<PlanDutyDetail> GetCurrentPlanDutyDetailList(DateTime dt);
        /// <summary>
        /// 根据ViewState设置排班的其他信息
        /// </summary>
        void SetSomePlanDutyTableViewState();
        /// <summary>
        /// 根据ViewState设置排班情况
        /// </summary>
        /// <param name="dt"></param>
        void SetPlanDutyTableByViewState(DateTime dt);

        /// <summary>
        /// 将planDutyDetailLis保存到ViewState
        /// </summary>
        void SavePlanDutyDetailListViewState(List<PlanDutyDetail> planDutyDetailLis, string viewStateName);
        /// <summary>
        /// 保存当前的View
        /// </summary>
        /// <param name="dt"></param>
        void SaveViewState(DateTime dt);

    }
}
