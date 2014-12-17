using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter
{
    public interface IDutyClassInfoView
    {
        /// <summary>
        /// ����б����
        /// </summary>
        IDutyClassListView DutyClassListView { get; set;}

        /// <summary>
        /// ������
        /// </summary>
        IDutyClassView DutyClassView { get; set;}

        /// <summary>
        /// С����ɼ�
        /// </summary>
        bool DutyClassViewVisible { get;set;}
    }
}
