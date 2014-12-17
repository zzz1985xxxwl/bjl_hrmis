//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ReadHistoryListPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-10-16
// 概述: 设置读取数据的时间Presenter
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.ReadDataViews;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.AttendanceStatistics.AttendanceReadData
{
    public class SetReadRulePresenter : SEP.Presenter.Core.BasePresenter
    {
        private readonly IReadAttendanceRuleView _View;
        private readonly IAttendanceReadDataFacade _IAttendanceReadDataFacade = InstanceFactory.CreateAttendanceReadDataFacade();

        public SetReadRulePresenter(IReadAttendanceRuleView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _View.BtnConfrimEvent += UpdateEvent;
        }

        public void InitView(bool ispostback)
        {
            _View.Message = string.Empty;
            if (!ispostback)
            {
                _View.SendMailRuleSource = GetSendEmailRuleTypeEnum();
                _View.HoursSource = DutyClassUtility.Hours();
                _View.MinutesSource = DutyClassUtility.Minutes();
                DataBind();
            }
        }

        public void UpdateEvent()
        {
            //设置初始数据
            AttendanceReadRule readRule = _IAttendanceReadDataFacade.GetAttendanceReadRuleByPkid(1, LoginUser);
            if (readRule==null)
            {
                _View.Message = "初始化错误,不能设置读取时间";
                return;
            }
            readRule.IsSendMail = Convert.ToBoolean(_View.IsSendMail);
            readRule.ReadDateTime = Convert.ToDateTime(_View.ReadTime);
            readRule.SendEmailRule = GetChoosedSendEmailRuleType(_View.SendMailRuleId);
            try
            {
                _IAttendanceReadDataFacade.UpdateAttendanceReadRule(readRule, LoginUser);
                _View.Message = "设置成功";
            }
            catch (ApplicationException ae)
            {
                _View.Message = ae.Message;
            }
        }

        private void DataBind()
        {
            //设置初始数据
            AttendanceReadRule readRule = _IAttendanceReadDataFacade.GetAttendanceReadRuleByPkid(1, LoginUser);
            if (readRule != null)
            {
                _View.ReadRuleId = readRule.AttendanceReadTimeId.ToString();
                _View.ReadTime = readRule.ReadDateTime.ToString();
                _View.IsSendMail = readRule.IsSendMail;
                _View.SendMailRuleId = readRule.SendEmailRule.ToString();

            }
            else
            {
                _View.Message = "初始化错误,不能设置读取时间";
                _View.ReadTime = DateTime.Now.ToString();
                _View.IsSendMail = false;
                _View.SendMailRuleId = SendEmailRuleType.InEmpty.ToString();
                return;
            }
        }

        private static Dictionary<string, string> GetSendEmailRuleTypeEnum()
        {
            Dictionary<string, string> sendMailType = new Dictionary<string, string>();
            sendMailType.Add(SendEmailRuleType.InEmpty.ToString(), "进入时间为空");
            sendMailType.Add(SendEmailRuleType.OutEmpty.ToString(), "离开时间为空");
            sendMailType.Add(SendEmailRuleType.InAndOutEmpty.ToString(), "进入时间为空并且离开时间为空");
            sendMailType.Add(SendEmailRuleType.InOrOutEmpty.ToString(), "进入时间为空或者离开时间为空");
            return sendMailType;
        }

        private static SendEmailRuleType GetChoosedSendEmailRuleType(string sendMailType)
        {
            switch (sendMailType)
            {
                case "InEmpty":
                    return SendEmailRuleType.InEmpty;
                case "OutEmpty":
                    return SendEmailRuleType.OutEmpty;
                case "InAndOutEmpty":
                    return SendEmailRuleType.InAndOutEmpty;
                case "InOrOutEmpty":
                    return SendEmailRuleType.InOrOutEmpty;
                default:
                    return SendEmailRuleType.InEmpty;
            }
        }

        public override void Initialize(bool isPostBack)
        {
            throw new NotImplementedException();
        }
    }
}
