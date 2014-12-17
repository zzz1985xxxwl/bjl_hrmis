using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter
{
    public interface IDutyClassInfoView
    {
        /// <summary>
        /// 班别列表界面
        /// </summary>
        IDutyClassListView DutyClassListView { get; set;}

        /// <summary>
        /// 班别界面
        /// </summary>
        IDutyClassView DutyClassView { get; set;}

        /// <summary>
        /// 小界面可见
        /// </summary>
        bool DutyClassViewVisible { get;set;}
    }
}
