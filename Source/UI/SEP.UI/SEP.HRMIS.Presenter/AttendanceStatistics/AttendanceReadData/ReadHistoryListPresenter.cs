//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ReadHistoryListPresenter.cs
// ������: ����
// ��������: 2008-10-16
// ����: ��ȡ���ݼ�¼����ʾPresenter
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
                _View.ErrorMessage = "���ڶ�ȡ���������Ժ����ԣ�";
                return;
            }
            readHistory = new ReadDataHistory(DateTime.Now,ReadDataResultType.Reading,"");
            try
            {
                //���Ӵ˴ζ�ȡ��¼��״̬Ϊ��ȡ��
                int readDataHistoryID = _IAttendanceReadDataFacade.InsertReadDataHistoryRecord(readHistory, LoginUser);
                //������ʾ
                 ReadHistoryDataBind();
                 //��ȡoa���ݿ�Ľ��
                 if (IsSetReadTime)
                 {
                       _IAttendanceReadDataFacade.ReadDataFromAccessToSQL(readDataHistoryID, LoginUser,Convert.ToDateTime(_View.ReadFromTime),Convert.ToDateTime(_View.ReadToTime));
                 }
                 else
                 {
                     _IAttendanceReadDataFacade.ReadDataFromAccessToSQL(readDataHistoryID, LoginUser);
                 }
                //������ʾ
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
                _View.ErrorMessage = "��ȡʱ�����ò���ȷ";
                value = false;
            }
            if (!DateTime.TryParse(_View.ReadToTime, out temp2))
            {
                _View.ErrorMessage = "��ȡʱ�����ò���ȷ";
                value = false;
            }
            return value;
        }
    }
}
