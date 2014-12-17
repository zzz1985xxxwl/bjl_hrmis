using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter
{
    public interface IPlanDutyListView
    {
        PlanDutyTable SessionCopyPlanDutyTable { get;set;}

        string TitleMessage { set;}
        string Message { set;}

        string DateFromMessage { get;set;}

        string DateToMessage { get;set;}

        string PlanDutyTableName { get;}

        string EmployeeName { get;}

        string DateFrom { get; set;}

        string DateTo { get; set;}

        /// <summary>
        /// 排班表
        /// </summary>
        List<PlanDutyTable> PlanDutyTables { set;}

        /// <summary>
        /// 新增事件
        /// </summary>
        event DelegateNoParameter BtnAddEvent;

        /// <summary>
        /// 修改事件
        /// </summary>
        event DelegateID BtnUpdateEvent;

        /// <summary>
        /// 删除事件
        /// </summary>
        event DelegateID BtnDeleteEvent;

        /// <summary>
        /// 详情
        /// </summary>
        event DelegateID BtnDetailEvent;

        /// <summary>
        /// 复制事件
        /// </summary>
        event DelegateID BtnCopyEvent;

        /// <summary>
        /// 查询
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}
