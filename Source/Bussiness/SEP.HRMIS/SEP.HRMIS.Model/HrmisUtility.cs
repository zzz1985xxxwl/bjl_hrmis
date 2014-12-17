//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: HrmisUtility.cs.cs
// Creater:  Xue.wenlong
// Date:  2009-03-24
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using SEP.HRMIS.Model.PayModule;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class HrmisUtility
    {
        /// <summary>
        /// 
        /// </summary>
        public const string _DbError = "数据库访问错误";

        #region 请假类型

        public const string _LeaveRequestType_Name_Repeat = "请假类型重复";
        public const string _LeaveRequestType_Name_NotExist = "请假类型不存在";
        public const string _LeaveRequestType_HasLeaveRequest = "此请假类型已经被使用，不可被修改或删除";
        public const string _LeaveRequestType_CanNotDelete = "重要参数，不能删除";
        #endregion

        #region 请假
        public const string _Date_Repeat = "该时间段内，已有请假记录";
        public const string _Date_Inner_Repeat = "该条记录存在重叠时间段";
        public const string _Over_Vacation = "请假时间超过剩余年假";
        public const string _Over_AdjustRest = "请假时间超过剩余调休";

        public const string _LeaveRequestItem_CanNot_Zero = "请假项中，不能有0小时项";
        public const string _OutApplicationItem_CanNot_Zero = "外出项中，不能有0小时项";
        public const string _OverWorkItem_CanNot_Zero = "加班项中，不能有0小时项";
        /// <summary>
        /// 该请假单不能被取消
        /// </summary>
        public const string _LeaveRequest_CanNot_BeCancled = "该请假单不能被取消";
        /// <summary>
        /// 该请假单部分不能被取消
        /// </summary>
        public const string _LeaveRequest_Partial_CanNot_BeCancled = "该请假单部分不能被取消";
        /// <summary>
        /// 该请假单部分不能被审核
        /// </summary>
        public const string _LeaveRequest_Partial_CanNot_BeApproved = "该请假单部分不能被审核";
        /// <summary>
        /// 该请假单不存在
        /// </summary>
        public const string _LeaveRequest_Not_Exist = "该请假单不存在";
        ///// <summary>
        ///// 不能整张请假单操作
        ///// </summary>
        //public const string _LeaveRequest_Not_Whole_Action = "不能整张请假单操作";
        /// <summary>
        /// 该账号没有请假流程
        /// </summary>
        public const string _No_LeaveRequest_DiyProcess = "该账号没有请假流程";
        /// <summary>
        /// 该账号没有考评流程
        /// </summary>
        public const string _No_Assess_DiyProcess = "该账号没有绩效考核流程";
        /// <summary>
        /// 没有权限审核该请假单
        /// </summary>
        public const string _No_Auth_To_Approve = "没有权限审核该请假单";
        /// <summary>
        /// 查无此人，流程中断，请与人事联系
        /// </summary>
        public const string _No_Account = "查无此人，流程中断，请与人力资源部联系";

        #endregion

        #region 外出

        public const string _Date_Out_Repeat = "该时间段内，已有外出记录";
        public const string _From_Bigger_To = "开始时间大于结束时间";
        public const string _OutApplication_Not_Exit = "该外出申请不存在";
        public const string _OutApplication_CanNot_BeCancled = "该外出申请不能被取消";
        public const string _OutApplicationItem_Not_Exit = "该外出申请项不存在";
        public const string _NextOperator_Not_Exit = "下一步操作人不存在";
        public const string _No_OutApplication_DiyProcess = "该账号没有外出流程";
        #endregion

        #region 加班

        public const string _Date_OverWork_Repeat = "该时间段内，已有加班记录";
        public const string _OverWork_Not_Exit = "该加班申请不存在";
        public const string _OverWork_CanNot_BeCancled = "该加班申请不能被取消";
        public const string _OverWorkItem_Not_Exit = "该加班申请项不存在";
        public const string _OverWorkType_Not_OneDay = "不能跨天";
        public const string _PlanDutyDetail_NULL = "没有排版表";
        public const string _No_OverWork_DiyProcess = "该账号没有加班流程";
        #endregion

        #region 自定义流程

        public const string _DiyProcess_Name_Repeat = "自定义流程的名称不能重复";
        public const string _DiyProcess_Used = "该流程正在使用中，不能被删除";

        #endregion

        #region 国籍

        public const string _Nationality_Name_Repeat = "国籍名称重复";
        public const string _Nationality_NotExist = "该国籍不存在";
        public const string _Nationality_HasBeenUsed = "此国籍已经被使用，不可被修改或删除";

        #endregion

        #region 职位申请
        public const string _PositionApplication_Not_Exit = "该职位申请不存在";
        public const string _PositionApplication_CanNot_BeCancled = "该职位申请不能被取消";
        public const string _No_PositionApplication_DiyProcess = "该账号没有职位申请流程";
        public const string _PositionApplication_CanNot_BeApproved = "该职位申请不能被审核";
        #endregion

        #region 调休规则

        public const string _AdjustRule_Name_Repeat = "调休规则名称重复";
        public const string _AdjustRule_Not_Exit = "调休规则不存在";
        public const string _AdjustRule_Used = "调休规则正被使用，无法删除";
        public const string _Employee_NotHave_AdjustRule = "没有调休规则";

        #endregion

        #region 客户信息

        public const string _CustomerInfo_Name_Repeat = "客户名称重复";
        public const string _CustomerInfo_Not_Exit = "客户信息不存在";
        public const string _CustomerInfo_Used = "客户信息正被使用，无法删除";


        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static ApplicationException ThrowException(string constString)
        {
            throw new ApplicationException(constString);
        }

        /// <summary>
        /// 根据当前操作人，过滤没有权限操作的员工
        /// </summary>
        /// <param name="oldEmployeeList"></param>
        /// <param name="authType"></param>
        /// <param name="loginUser"></param>
        /// <param name="powersID"></param>
        /// <returns></returns>
        public static List<Employee> RemoteUnAuthEmployee(List<Employee> oldEmployeeList,
            AuthType authType, Account loginUser, int powersID)
        {
            Auth myAuth = loginUser.FindAuth(authType, powersID);

            if (myAuth == null)
            {
                return new List<Employee>();
                //throw new ApplicationException("没有权限访问");
            }
            if (myAuth.Departments.Count == 0)
                return oldEmployeeList;

            List<Employee> newEmployeeList = new List<Employee>();
            for (int i = 0; i < oldEmployeeList.Count; i++)
            {
                if (SEP.Model.Utility.Tools.IsDeptListContainsDept(myAuth.Departments, oldEmployeeList[i].Account.Dept))
                {
                    newEmployeeList.Add(oldEmployeeList[i]);
                }
            }
            return newEmployeeList;
        }
        /// <summary>
        /// 根据当前操作人，过滤没有权限操作的员工年假
        /// </summary>
        /// <param name="oldVacationList"></param>
        /// <param name="authType"></param>
        /// <param name="loginUser"></param>
        /// <param name="powersID"></param>
        /// <returns></returns>
        public static List<Vacation> RemoteUnAuthVacation(List<Vacation> oldVacationList,
            AuthType authType, Account loginUser, int powersID)
        {
            Auth myAuth = loginUser.FindAuth(authType, powersID);

            if (myAuth == null)
            {
                return new List<Vacation>();
                //throw new ApplicationException("没有权限访问");
            }
            if (myAuth.Departments.Count == 0)
                return oldVacationList;

            List<Vacation> newVacationList = new List<Vacation>();
            for (int i = 0; i < oldVacationList.Count; i++)
            {
                if (oldVacationList[i].Employee.Account != null &&
                    SEP.Model.Utility.Tools.IsDeptListContainsDept(myAuth.Departments,
                                                                   oldVacationList[i].Employee.Account.Dept))
                {
                    newVacationList.Add(oldVacationList[i]);
                }
            }
            return newVacationList;
        }
        /// <summary>
        /// 根据当前操作人，过滤没有权限操作的合同
        /// </summary>
        /// <param name="oldContractList"></param>
        /// <param name="authType"></param>
        /// <param name="loginUser"></param>
        /// <param name="powersID"></param>
        /// <returns></returns>
        public static List<Contract> RemoteUnAuthContract(List<Contract> oldContractList,
            AuthType authType, Account loginUser, int powersID)
        {
            Auth myAuth = loginUser.FindAuth(authType, powersID);

            if (myAuth == null)
            {
                return new List<Contract>();
                //throw new ApplicationException("没有权限访问");
            }
            if (myAuth.Departments.Count == 0)
                return oldContractList;

            List<Contract> newContractList = new List<Contract>();
            for (int i = 0; i < oldContractList.Count; i++)
            {
                if (oldContractList[i].Employee != null && oldContractList[i].Employee.Account != null &&
                    oldContractList[i].Employee.Account.Dept != null &&
                    SEP.Model.Utility.Tools.IsDeptListContainsDept(myAuth.Departments,
                                                                   oldContractList[i].Employee.Account.Dept))
                {
                    newContractList.Add(oldContractList[i]);
                }
            }
            return newContractList;
        }
        /// <summary>
        /// 根据当前操作人，过滤没有权限操作的员工薪资
        /// </summary>
        /// <param name="oldEmployeeSalaryList"></param>
        /// <param name="authType"></param>
        /// <param name="loginUser"></param>
        /// <param name="powersID"></param>
        /// <returns></returns>
        public static List<EmployeeSalary> RemoteUnAuthEmployeeSalary(List<EmployeeSalary> oldEmployeeSalaryList,
            AuthType authType, Account loginUser, int powersID)
        {
            Auth myAuth = loginUser.FindAuth(authType, powersID);

            if (myAuth == null)
            {
                return new List<EmployeeSalary>();
                //throw new ApplicationException("没有权限访问");
            }
            if (myAuth.Departments.Count == 0)
                return oldEmployeeSalaryList;

            List<EmployeeSalary> newEmployeeSalaryList = new List<EmployeeSalary>();
            for (int i = 0; i < oldEmployeeSalaryList.Count; i++)
            {
                if (oldEmployeeSalaryList[i].Employee.Account != null &&
                    SEP.Model.Utility.Tools.IsDeptListContainsDept(myAuth.Departments,
                                                                   oldEmployeeSalaryList[i].Employee.Account.Dept))
                {
                    newEmployeeSalaryList.Add(oldEmployeeSalaryList[i]);
                }
            }
            return newEmployeeSalaryList;
        }

        private readonly string _AttendanceStartDay = ConfigurationManager.AppSettings["AttendanceStartDay"];
        ///<summary>
        /// 考勤开始时间
        ///</summary>
        public string AttendanceStratDay
        {
            get
            {
                if (string.IsNullOrEmpty(_AttendanceStartDay))
                {
                    return "1";
                    //throw new ApplicationException("考勤开始日错误");
                }
                return _AttendanceStartDay;
            }
        }

        /////<summary>
        ///// 考勤基准月,true 为计算当月工资，false为计算下个月工资
        /////</summary>
        /////<exception cref="ApplicationException"></exception>
        //public static bool AttendanceBaseMonth
        //{
        //    get
        //    {
        //        string _AttendanceBaseMonth = ConfigurationManager.AppSettings["AttendanceBaseMonth"];
        //        if (string.IsNullOrEmpty(_AttendanceBaseMonth))
        //        {
        //            throw new ApplicationException("考勤基准月错误");
        //        }
        //        return _AttendanceBaseMonth.Equals("true");
        //    }
        //}

        /// <summary>
        /// 获取当月开始时间
        /// </summary>
        public DateTime CurrenMonthStartTime()
        {

            DateTime now = DateTime.Today;
            DateTime currentStartTime = Convert.ToDateTime(now.Year + "-" + now.Month + "-" + AttendanceStratDay);
            return now.Day >= Convert.ToInt32(AttendanceStratDay) ? Convert.ToDateTime(now.Year + "-" + now.Month + "-" + AttendanceStratDay) : currentStartTime.AddMonths(-1);
        }

        /// <summary>
        /// 获取当月开始时间
        /// </summary>
        public DateTime CurrenMonthEndTime()
        {
            return CurrenMonthStartTime().AddMonths(1).AddDays(-1);
        }

        ///<summary>
        /// 获取某个时间点的开始时间
        ///</summary>
        ///<param name="time"></param>
        ///<returns></returns>
        public DateTime StartMonthByYearMonth(DateTime time)
        {
            DateTime temp = Convert.ToDateTime(time.Year + "-" + time.Month + "-" + AttendanceStratDay);
            return time.Day >= Convert.ToInt32(AttendanceStratDay)
                       ? temp
                       : temp.AddMonths(-1);
        }
        /// <summary>
        /// employeelist中是否包含employee
        /// </summary>
        /// <param name="list"></param>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static bool IsEmployeeListContainEmployee(List<Employee> list, int employeeID)
        {
            if (list == null || list.Count == 0)
                return false;
            foreach (Employee eachEmployee in list)
            {
                if (employeeID == eachEmployee.Account.Id)
                    return true;
            }
            return false;
        }

        ///<summary>
        /// 获取某个时间点的结束时间
        ///</summary>
        ///<param name="time"></param>
        ///<returns></returns>
        public DateTime EndMonthByYearMonth(DateTime time)
        {
            return StartMonthByYearMonth(time).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// 
        /// </summary>
        public static decimal? ConvertToDecimal(object obj)
        {
            if (obj == null || obj == DBNull.Value || string.IsNullOrEmpty(obj.ToString()))
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<string> GetMail(Account account)
        {
            List<string> mails = new List<string>();
            string mailto1 = account.Email1;
            string mailto2 = account.Email2;
            mails.Add(mailto1);
            if (!string.IsNullOrEmpty(mailto2))
            {
                mails.Add(mailto2);
            }
            return mails;
        }
    }
}