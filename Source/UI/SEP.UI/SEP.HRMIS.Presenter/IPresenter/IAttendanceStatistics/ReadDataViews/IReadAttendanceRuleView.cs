//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IReadAttendanceRuleView.cs
// ������: ����
// ��������: 2008-10-16
// ����: ���ö�ȡ���ݵ�ʱ�����
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.ReadDataViews
{
     public interface IReadAttendanceRuleView
     {
         string Message { set;}

         /// <summary>
         /// ��ȡ��¼��id
         /// </summary>
         string ReadRuleId { get; set;}

         /// <summary>
         /// ÿ���ȡʱ��
         /// </summary>
         string ReadTime { get; set;}

         /// <summary>
         /// �Ƿ���Email
         /// </summary>
         bool IsSendMail { get; set;}

         /// <summary>
         /// ѡ����Eamil������
         /// </summary>
         string SendMailRuleId { get; set;}

         /// <summary>
         /// ��������Դ
         /// </summary>
         Dictionary<string, string> SendMailRuleSource { set;}

         /// <summary>
         /// Сʱʱ��Դ
         /// </summary>
         List<string> HoursSource { set;}
         List<string> MinutesSource { set;}


         /// <summary>
         /// ��ȡ�¼�
         /// </summary>
         event DelegateNoParameter BtnConfrimEvent;
         /// <summary>
         /// ȡ��
         /// </summary>
         event DelegateNoParameter BtnCancelEvent;
         /// <summary>
         /// ��ȡ�Ƿ�ɹ�
         /// </summary>
         bool IsActionSuccess { get; set;}
     }
}
