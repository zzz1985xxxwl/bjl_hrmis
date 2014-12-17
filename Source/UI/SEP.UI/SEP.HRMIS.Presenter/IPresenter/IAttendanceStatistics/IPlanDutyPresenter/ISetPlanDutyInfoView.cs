
using System.Collections.Generic;
using SEP.HRMIS.Presenter.IPresenter.IChoseEmployee;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter
{
    public interface ISetPlanDutyInfoView
    {
        Account LoginUser { get; set;}
        /// <summary>
        /// �����
        /// </summary>
        ISetPlanDutyView SetPlanDutyView { get; set;}

        /// <summary>
        /// С����
        /// </summary>
        IChoseEmployeeView ChoseEmployeeView { get; set;}
        IReplaceDutyClassView ReplaceDutyClassView { get; set;}
        /// <summary>
        /// С�����Ƿ�ɼ�
        /// </summary>
        bool IChoseEmployeeViewVisible { get; set;}
        bool IReplaceDutyClassViewVisible { get; set;}

        List<Account> EmployeeList { get; set;}
    }
}
