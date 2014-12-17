//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ReadHistoryListPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-10-16
// 概述: 读取数据记录的显示Presenter
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.ReadDataViews;
using SEP.Model.Accounts;
using SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter;

namespace SEP.HRMIS.Presenter.AttendanceStatistics.AttendanceReadData
{
    public class ReadHistoryListPresenter : SEP.Presenter.Core.BasePresenter
    {
        private readonly IReadHistoryListView _View;
        private readonly IAttendanceReadDataFacade _IAttendanceReadDataFacade = InstanceFactory.CreateAttendanceReadDataFacade();
        private bool IsSetReadTime;
        public ReadHistoryListPresenter(IReadHistoryListView listView, Account loginUser)
            : base(loginUser)
        {
            _View = listView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _View.BtnReadEvent += ReadEvent;
            _View.BindDataEvent += ReadHistoryDataBind;
        }

        public void InitView(bool isPostBack)
        {
             if(!isPostBack)
             {
                 ReadHistoryDataBind();
                 _View.HoursSource = DutyClassUtility.Hours();
                 _View.MinutesSource = DutyClassUtility.Minutes();
             }
        }

        public void ReadEvent()
        {
            if(!Validate())
            {
                return;
            }
            ReadDataHistory readHistory = _IAttendanceReadDataFacade.GetLastReadDataHistory(LoginUser);
            if (readHistory !=null && readHistory.ReadResult == ReadDataResultType.Reading)
            {
                _View.ErrorMessage = "正在读取数据中请稍候再试！";
                return;
            }
            readHistory = new ReadDataHistory(DateTime.Now,ReadDataResultType.Reading,"");
            try
            {
                //增加此次读取记录，状态为读取中
                int readDataHistoryID = _IAttendanceReadDataFacade.InsertReadDataHistoryRecord(readHistory, LoginUser);
                //跟新显示
                 ReadHistoryDataBind();
                 //读取oa数据库的结果
                 if (IsSetReadTime)
                 {
                       _IAttendanceReadDataFacade.ReadDataFromAccessToSQL(readDataHistoryID, LoginUser,Convert.ToDateTime(_View.ReadFromTime),Convert.ToDateTime(_View.ReadToTime));
                 }
                 else
                 {
                     _IAttendanceReadDataFacade.ReadDataFromAccessToSQL(readDataHistoryID, LoginUser);
                 }
                //跟新显示
                 ReadHistoryDataBind();
            }
            catch (Exception ae)
            {
                _View.ErrorMessage = ae.Message;
            }
        }

        public void ReadHistoryDataBind()
        {
            List<ReadDataHistory> historys = _IAttendanceReadDataFacade.GetAllReadDataHistory(LoginUser);
            _View.ReadHistorys = historys;
        }

        public override void Initialize(bool isPostBack)
        {
            throw new NotImplementedException();
        }

        public bool Validate()
        {
            IsSetReadTime = true;
            bool value = true;
            DateTime temp1, temp2;
            if (String.IsNullOrEmpty(_View.ReadFromTime) && String.IsNullOrEmpty(_View.ReadToTime))
            {
                IsSetReadTime = false;
                return value ;
            }

            if (!DateTime.TryParse(_View.ReadFromTime, out temp1))
            {
                _View.ErrorMessage = "读取时间设置不正确";
                value = false;
            }
            if (!DateTime.TryParse(_View.ReadToTime, out temp2))
            {
                _View.ErrorMessage = "读取时间设置不正确";
                value = false;
            }
            return value;
        }
    }
}
