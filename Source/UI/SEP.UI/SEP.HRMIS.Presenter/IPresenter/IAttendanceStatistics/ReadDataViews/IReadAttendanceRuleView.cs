//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IReadAttendanceRuleView.cs
// 创建者: 刘丹
// 创建日期: 2008-10-16
// 概述: 设置读取数据的时间界面
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.ReadDataViews
{
     public interface IReadAttendanceRuleView
     {
         string Message { set;}

         /// <summary>
         /// 读取记录的id
         /// </summary>
         string ReadRuleId { get; set;}

         /// <summary>
         /// 每天读取时间
         /// </summary>
         string ReadTime { get; set;}

         /// <summary>
         /// 是否发送Email
         /// </summary>
         bool IsSendMail { get; set;}

         /// <summary>
         /// 选择发送Eamil的条件
         /// </summary>
         string SendMailRuleId { get; set;}

         /// <summary>
         /// 发送条件源
         /// </summary>
         Dictionary<string, string> SendMailRuleSource { set;}

         /// <summary>
         /// 小时时间源
         /// </summary>
         List<string> HoursSource { set;}
         List<string> MinutesSource { set;}


         /// <summary>
         /// 读取事件
         /// </summary>
         event DelegateNoParameter BtnConfrimEvent;
         /// <summary>
         /// 取消
         /// </summary>
         event DelegateNoParameter BtnCancelEvent;
         /// <summary>
         /// 读取是否成功
         /// </summary>
         bool IsActionSuccess { get; set;}
     }
}
