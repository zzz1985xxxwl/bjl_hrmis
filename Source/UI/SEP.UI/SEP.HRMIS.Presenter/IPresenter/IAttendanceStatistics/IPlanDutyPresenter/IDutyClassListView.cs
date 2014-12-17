using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter
{
    public interface IDutyClassListView
    {
        string Message { get; set;}

        string DutyClassName { get;}

        /// <summary>
        /// 班别
        /// </summary>
        List<DutyClass> DutyClasss { set; get;}

        /// <summary>
        /// 新增事件
        /// </summary>
        event DelegateNoParameter BtnAddEvent;

        /// <summary>
        /// 修改事件
        /// </summary>
        event DelegateID BtnUpdateEvent;

        /// <summary>
        /// 详情
        /// </summary>
        event DelegateID BtnDetailEvent;

        /// <summary>
        /// 查询
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}
