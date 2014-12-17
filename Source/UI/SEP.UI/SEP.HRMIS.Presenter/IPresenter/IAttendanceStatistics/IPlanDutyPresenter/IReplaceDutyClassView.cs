using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter
{
    public interface IReplaceDutyClassView
    {
        List<DutyClass> DutyClassList { set;}
        string Message { get; set;}
        string From { get; set;}
        string To { get; set;}
        /// <summary>
        /// 新旧班别替换列表
        /// </summary>
        List<DutyClassReplace> DutyClassReplaceList { set; get;}


        /// <summary>
        /// 替换
        /// </summary>
        event Delegate2Parameter BtnReplaceEvent;
        event DelegateNoParameter BtnddSelectedIndexChangedEvent;
        event DelegateNoParameter DataBindEvent;
    }
}
