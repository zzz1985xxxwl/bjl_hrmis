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
        /// �Ű��
        /// </summary>
        List<PlanDutyTable> PlanDutyTables { set;}

        /// <summary>
        /// �����¼�
        /// </summary>
        event DelegateNoParameter BtnAddEvent;

        /// <summary>
        /// �޸��¼�
        /// </summary>
        event DelegateID BtnUpdateEvent;

        /// <summary>
        /// ɾ���¼�
        /// </summary>
        event DelegateID BtnDeleteEvent;

        /// <summary>
        /// ����
        /// </summary>
        event DelegateID BtnDetailEvent;

        /// <summary>
        /// �����¼�
        /// </summary>
        event DelegateID BtnCopyEvent;

        /// <summary>
        /// ��ѯ
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}
