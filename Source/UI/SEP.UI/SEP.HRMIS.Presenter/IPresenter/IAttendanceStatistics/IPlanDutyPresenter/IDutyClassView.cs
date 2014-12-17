using System.Collections.Generic;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter
{
    public interface IDutyClassView
    {
        /// <summary>
        /// ��ʾ�ײ��һЩ��Ϣ
        /// </summary>
        string Message { set;}

        string DutyClassId { get; set;}

        /// <summary>
        /// �������
        /// </summary>
        string DutyClassName { get; set;}

        /// <summary>
        /// ������������Ϣ
        /// </summary>
        string DutyClassNameMessage { set;}

        /// <summary>
        /// �����ϰ�ʱ�䷶Χ
        /// </summary>
        string FirstStartFromTime { get; set;}
        /// <summary>
        /// �����ϰ�ʱ�䷶Χ
        /// </summary>
        string FirstStartToTime { get; set;}
        /// <summary>
        /// �����°�ʱ��
        /// </summary>
        string FirstEndTime { get; set;}
        /// <summary>
        /// �����ϰ�ʱ��
        /// </summary>
        string SecondStartTime { get; set;}
        /// <summary>
        /// �����°�ʱ��
        /// </summary>
        string SecondEndTime { get; set;}

        /// <summary>
        /// һ���ϰ���ʱ��
        /// </summary>
        string WorkAllTime { get; set;}

        /// <summary>
        /// ��ʾ�����ϰ�ʱ�����Ϣ
        /// </summary>
        string WorkTimeMessage { set;}

        /// <summary>
        /// �趨�ٵ��Ķ���
        /// </summary>
        string LateTime { get; set;}

        /// <summary>
        /// ��ʾ���ڳٵ���Ϣ
        /// </summary>
        string LateMessage { set;}

        /// <summary>
        /// �趨���˵Ķ���
        /// </summary>
        string EarlyLeaveTime { get; set;}

        /// <summary>
        /// ��ʾ����������Ϣ
        /// </summary>
        string EarlyLeaveMessage { set;}

        string AbsentLateTime { get; set;}

        string AbsentLateMessage { set;}

        string AbsentEarlyLeaveTime { get; set;}

        string AbsentEarlyLeaveMessage { set;}

        /// <summary>
        /// ��������;�������޸ģ���ϸ
        /// </summary>
        string OperationTitle { set; get;}

        /// <summary>
        /// ȷ�ϰ�ť�¼�
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;

        /// <summary>
        /// ȡ����ť�¼�
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;

        /// <summary>
        /// �����Ƿ�ɹ�
        /// </summary>
        bool ActionSuccess { get; set;}

        /// <summary>
        /// ��������
        /// </summary>
        string OperationType { get; set;}

        List<string> HoursSource { set;}
        List<string> MinutesSource { set;}
    }
}
