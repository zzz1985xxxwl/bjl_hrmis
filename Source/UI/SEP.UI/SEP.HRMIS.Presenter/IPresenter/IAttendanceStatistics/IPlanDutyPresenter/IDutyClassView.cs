using System.Collections.Generic;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter
{
    public interface IDutyClassView
    {
        /// <summary>
        /// 显示底层的一些信息
        /// </summary>
        string Message { set;}

        string DutyClassId { get; set;}

        /// <summary>
        /// 班别名称
        /// </summary>
        string DutyClassName { get; set;}

        /// <summary>
        /// 班别规则名词信息
        /// </summary>
        string DutyClassNameMessage { set;}

        /// <summary>
        /// 上午上班时间范围
        /// </summary>
        string FirstStartFromTime { get; set;}
        /// <summary>
        /// 上午上班时间范围
        /// </summary>
        string FirstStartToTime { get; set;}
        /// <summary>
        /// 上午下班时间
        /// </summary>
        string FirstEndTime { get; set;}
        /// <summary>
        /// 下午上班时间
        /// </summary>
        string SecondStartTime { get; set;}
        /// <summary>
        /// 下午下班时间
        /// </summary>
        string SecondEndTime { get; set;}

        /// <summary>
        /// 一天上班总时间
        /// </summary>
        string WorkAllTime { get; set;}

        /// <summary>
        /// 显示关于上班时间的信息
        /// </summary>
        string WorkTimeMessage { set;}

        /// <summary>
        /// 设定迟到的定义
        /// </summary>
        string LateTime { get; set;}

        /// <summary>
        /// 显示关于迟到信息
        /// </summary>
        string LateMessage { set;}

        /// <summary>
        /// 设定早退的定义
        /// </summary>
        string EarlyLeaveTime { get; set;}

        /// <summary>
        /// 显示关于早退信息
        /// </summary>
        string EarlyLeaveMessage { set;}

        string AbsentLateTime { get; set;}

        string AbsentLateMessage { set;}

        string AbsentEarlyLeaveTime { get; set;}

        string AbsentEarlyLeaveMessage { set;}

        /// <summary>
        /// 操作类型;新增，修改，详细
        /// </summary>
        string OperationTitle { set; get;}

        /// <summary>
        /// 确认按钮事件
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;

        /// <summary>
        /// 取消按钮事件
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;

        /// <summary>
        /// 动作是否成功
        /// </summary>
        bool ActionSuccess { get; set;}

        /// <summary>
        /// 操作类型
        /// </summary>
        string OperationType { get; set;}

        List<string> HoursSource { set;}
        List<string> MinutesSource { set;}
    }
}
