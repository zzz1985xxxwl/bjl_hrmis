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
        /// �¾ɰ���滻�б�
        /// </summary>
        List<DutyClassReplace> DutyClassReplaceList { set; get;}


        /// <summary>
        /// �滻
        /// </summary>
        event Delegate2Parameter BtnReplaceEvent;
        event DelegateNoParameter BtnddSelectedIndexChangedEvent;
        event DelegateNoParameter DataBindEvent;
    }
}
