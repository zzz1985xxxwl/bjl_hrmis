
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
        /// �õ�ĳһʱ���PlanDutyDetailList
        /// </summary>
        /// <param name="viewStateName"></param>
        /// <returns></returns>
        List<PlanDutyDetail> GetViewState(string viewStateName);
        /// <summary>
        /// �õ���ǰ��PlanDutyDetailList
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<PlanDutyDetail> GetCurrentPlanDutyDetailList(DateTime dt);
        /// <summary>
        /// ����ViewState�����Ű��������Ϣ
        /// </summary>
        void SetSomePlanDutyTableViewState();
        /// <summary>
        /// ����ViewState�����Ű����
        /// </summary>
        /// <param name="dt"></param>
        void SetPlanDutyTableByViewState(DateTime dt);

        /// <summary>
        /// ��planDutyDetailLis���浽ViewState
        /// </summary>
        void SavePlanDutyDetailListViewState(List<PlanDutyDetail> planDutyDetailLis, string viewStateName);
        /// <summary>
        /// ���浱ǰ��View
        /// </summary>
        /// <param name="dt"></param>
        void SaveViewState(DateTime dt);

    }
}
