//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PersonalInAndOutUtilityPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-10-21
// 概述: 个人考勤详情的公共方法
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;
using SEP.HRMIS.IFacede;
using SEP.IBll;

namespace SEP.HRMIS.Presenter
{
    public class PersonalInAndOutUtilityPresenter : PresenterCore.BasePresenter, PresenterCore.IDataCollector<AttendanceInAndOutRecord>
    {
        private readonly IPersonalInAndOutView _View;
        //note colbert 2
        //private IAttendanceOutInRecord _GetRecord = new AttendanceOutInRecord();
        //public string DoorNoMessage;
        public PersonalInAndOutUtilityPresenter(IPersonalInAndOutView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;
        }

        public void InitTheViewToDefault()
        {
            if (InitEmployeeInfo(_View.EmployeeId))
            {
                _View.Reason = string.Empty;
                _View.TimeMessage = string.Empty;
                _View.ReasonMessage = string.Empty;
                _View.HoursSource = DutyClassUtility.Hours();
                _View.MinutesSource = DutyClassUtility.Minutes();
                _View.IOStatusSource = IoStatusSource();
                _View.IOTime = DateTime.Now.ToString();
            }
        }

        public void CompleteTheObject(AttendanceInAndOutRecord record)
        {
            if (record != null)
            {
                record.OperateTime = DateTime.Now;
                record.IOTime = Convert.ToDateTime(_View.IOTime);
                record.IOStatus = AttendanceInAndOutRecord.GetInOutStatusByInOutName(_View.IOStatusId);
                record.DoorCardNo = _View.DoorCardNo;
            }
        }

        public bool Validate()
        {
            _View.TimeMessage = string.Empty;
            DateTime temp;
            if (!DateTime.TryParse(_View.IOTime.Trim(),out temp) )
            {
                _View.TimeMessage = "时间设置不正确";
                return false;
            }
            if(string.IsNullOrEmpty(_View.Reason.Trim()))
            {
                _View.ReasonMessage = "不能为空";
                return false;
            }
                return true;
        }

        public bool DataBind(string ruleId,string employeeId)
        {
            int id,employId;
            if (!int.TryParse(ruleId, out id))
            {
                _View.Message = "初始化错误";
                return false;
            }
            if (!int.TryParse(employeeId, out employId))
            {
                _View.Message = "初始化错误";
                return false;
            }
            Employee employee = InstanceFactory.AttendanceInOutRecordFacade.GetEmployeeInAndOutRecordByEmployeeId(employId, LoginUser);
            _View.DoorCardNo = employee.EmployeeAttendance.DoorCardNo;
            AttendanceInAndOutRecord record = employee.EmployeeAttendance.FindInAndOutRecordByRecordId(id);
            if (record != null)
            {
                _View.RecordId = record.RecordID.ToString();
                _View.IOTime = record.IOTime.ToString();
                _View.IOStatusId = record.IOStatus.ToString();

                return true;
            }
            _View.Message = "初始化错误";
            return false;
        }



        private bool InitEmployeeInfo(string employeeId)
        {
            int accountId;
            if (!int.TryParse(employeeId, out accountId))
            {
                _View.Message = "员工Id不存在";
                return false;
            }
            Employee employee = InstanceFactory.AttendanceInOutRecordFacade.GetEmployeeInAndOutRecordByEmployeeId(accountId, LoginUser);
            _View.DoorCardNo = employee.EmployeeAttendance.DoorCardNo;

            if (string.IsNullOrEmpty(_View.DoorCardNo))
            {
                _View.Message = "员工没有门禁卡号";
                return false;
            }

            _View.EmployeeName = BllInstance.AccountBllInstance.GetAccountById(accountId).Name;
            _View.Message = string.Empty;
            return true;
        }

        /// <summary>
        /// 打卡记录详情的“状态”下拉菜单的查询条件
        /// </summary>
        public static Dictionary<string,string> IoStatusSource()
        {
           Dictionary<string,string> iostatus=new  Dictionary<string, string>();
           iostatus.Add(InOutStatusEnum.All.ToString(), "");
           iostatus.Add(InOutStatusEnum.In.ToString(), "进入");
           iostatus.Add(InOutStatusEnum.Out.ToString(), "离开");
           return iostatus;
        }
        /// <summary>
        /// 打卡记录详情的“数据来源”下拉菜单的查询条件
        /// </summary>
        public static Dictionary<string, string> OperateStatusSource()
        {
            Dictionary<string, string> operate = new Dictionary<string, string>();
            operate.Add(OutInRecordOperateStatusEnum.All.ToString(), "");
            operate.Add(OutInRecordOperateStatusEnum.ReadFromDataBase.ToString(), "从ACCESS导入");
            operate.Add(OutInRecordOperateStatusEnum.AddByOperator.ToString(), "新增");
            operate.Add(OutInRecordOperateStatusEnum.ModifyByOperator.ToString(), "修改");
            operate.Add(OutInRecordOperateStatusEnum.DeleteByOperator.ToString(), "删除");
            operate.Add(OutInRecordOperateStatusEnum.ImportByOperator.ToString(), "从XSL导入");

            return operate;
        }

        //note colbert 2
        //public IAttendanceOutInRecord GetRecord
        //{
        //    set { _GetRecord = value; }
        //}

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
