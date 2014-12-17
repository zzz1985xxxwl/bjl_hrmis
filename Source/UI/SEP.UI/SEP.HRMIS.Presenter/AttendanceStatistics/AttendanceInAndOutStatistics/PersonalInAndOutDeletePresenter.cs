//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PersonalInAndOutDeletePresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-10-21
// 概述: 个人考勤删除
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter
{
    public class PersonalInAndOutDeletePresenter : PresenterCore.BasePresenter
    {
        //note colbert 2
        //private DeleteAttendanceInOutRecord _Delete;
        private readonly IPersonalInAndOutView _View;
        private readonly PersonalInAndOutUtilityPresenter _Utility;

        public PersonalInAndOutDeletePresenter(IPersonalInAndOutView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;
            _Utility = new PersonalInAndOutUtilityPresenter(_View, loginUser);
            AttachViewEvent();
        }

        public void InitView(string id)
        {
             _Utility.InitTheViewToDefault();
             _View.OperationTitle = "删除打卡记录";
            _View.OperationType = "Delete";
            _View.SetReadOnly = false;
            _View.SetReasonReadOnly = true;
            _Utility.DataBind(id, _View.EmployeeId);
        }


        public void AttachViewEvent()
        {
            _View.ActionButtonEvent += DeleteEvent;
        }

        public void DeleteEvent()
        {
             if(!_Utility.Validate())
             {
                 return;
             }

             try
             {
                 InstanceFactory.AttendanceInOutRecordFacade.DeleteAttendanceInOutRecord(
                     Convert.ToInt32(_View.EmployeeId), Convert.ToInt32(_View.RecordId),
                     Convert.ToDateTime(_View.IOTime), CompleteLogData(), LoginUser);
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
        /// <returns></returns>
        private AttendanceInAndOutRecordLog CompleteLogData()
        {
            AttendanceInAndOutRecordLog log = new AttendanceInAndOutRecordLog();
            log.EmployeeID = Convert.ToInt32(_View.EmployeeId);
            log.EmployeeName = _View.EmployeeName;
            log.OldIOStatus = AttendanceInAndOutRecord.GetInOutStatusByInOutName( _View.IOStatusId);
            log.OldIOTime = Convert.ToDateTime(_View.IOTime);
            log.OperateReason = _View.Reason;
            log.OperateTime = DateTime.Now;
            log.OperateStatus = OutInRecordOperateStatusEnum.DeleteByOperator;
            log.Operator = LoginUser.Name;
            log.NewIOStatus = InOutStatusEnum.All;
            log.NewIOTime = Convert.ToDateTime("2999-12-31");
            return log;
        }

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
