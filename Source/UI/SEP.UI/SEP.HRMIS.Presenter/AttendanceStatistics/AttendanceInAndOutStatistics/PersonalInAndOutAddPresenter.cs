//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PersonalInAndOutAddPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-10-21
// 概述: 个人考勤详情修改
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using PresenterCore = SEP.Presenter.Core;
using SEP.Model.Accounts;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter
{
    public class PersonalInAndOutAddPresenter : PresenterCore.BasePresenter
    {      
        private readonly IPersonalInAndOutView _View;
        private readonly PersonalInAndOutUtilityPresenter _Utility;

        public PersonalInAndOutAddPresenter(IPersonalInAndOutView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;
            _Utility = new PersonalInAndOutUtilityPresenter(_View, loginUser);
            AttachViewEvent();
        }

        public void InitView()
        {
             _Utility.InitTheViewToDefault();
            _View.OperationTitle = "新增打卡记录";
            _View.OperationType = "Add";
            _View.SetReadOnly = true;
            _View.SetReasonReadOnly = true;
        }

        public void AttachViewEvent()
        {
            _View.ActionButtonEvent += AddEvent;
        }

        public void AddEvent()
        {
             if(!_Utility.Validate())
             {
                 return;
             }
            AttendanceInAndOutRecord record = new AttendanceInAndOutRecord();
             _Utility.CompleteTheObject(record);
             record.OperateStatus = OutInRecordOperateStatusEnum.AddByOperator;
             try
             {
                 InstanceFactory.AttendanceInOutRecordFacade.InsertAttendanceInOutRecord(
                     Convert.ToInt32(_View.EmployeeId), record, CompleteLogData(record), LoginUser);
                 _View.ActionSuccess = true;
             }
             catch (ApplicationException ae)
             {
                 _View.Message = ae.Message;
             }
        }
        
        /// <summary>
        /// 收集日志数据
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private AttendanceInAndOutRecordLog CompleteLogData(AttendanceInAndOutRecord record)
        {
            AttendanceInAndOutRecordLog log = new AttendanceInAndOutRecordLog();
            log.EmployeeID = Convert.ToInt32(_View.EmployeeId);
            log.EmployeeName = _View.EmployeeName;
            log.OldIOStatus = InOutStatusEnum.All;
            log.OldIOTime = Convert.ToDateTime("2000-12-31 0:00:00");
            log.NewIOStatus = record.IOStatus;
            log.NewIOTime = record.IOTime;
            log.OperateReason = _View.Reason;
            log.OperateTime = record.OperateTime;
            log.OperateStatus = record.OperateStatus;
            log.Operator = LoginUser.Name;
            return log;
        }

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
