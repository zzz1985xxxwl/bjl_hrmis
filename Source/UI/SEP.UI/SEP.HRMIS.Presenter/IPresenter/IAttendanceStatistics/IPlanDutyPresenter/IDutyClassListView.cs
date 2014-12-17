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
        /// ���
        /// </summary>
        List<DutyClass> DutyClasss { set; get;}

        /// <summary>
        /// �����¼�
        /// </summary>
        event DelegateNoParameter BtnAddEvent;

        /// <summary>
        /// �޸��¼�
        /// </summary>
        event DelegateID BtnUpdateEvent;

        /// <summary>
        /// ����
        /// </summary>
        event DelegateID BtnDetailEvent;

        /// <summary>
        /// ��ѯ
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}
