
using System.Collections.Generic;
using SEP.HRMIS.Presenter.IPresenter.IChoseEmployee;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter
{
    public interface ISetPlanDutyInfoView
    {
        Account LoginUser { get; set;}
        /// <summary>
        /// 大界面
        /// </summary>
        ISetPlanDutyView SetPlanDutyView { get; set;}

        /// <summary>
        /// 小界面
        /// </summary>
        IChoseEmployeeView ChoseEmployeeView { get; set;}
        IReplaceDutyClassView ReplaceDutyClassView { get; set;}
        /// <summary>
        /// 小界面是否可见
        /// </summary>
        bool IChoseEmployeeViewVisible { get; set;}
        bool IReplaceDutyClassViewVisible { get; set;}

        List<Account> EmployeeList { get; set;}
    }
}
