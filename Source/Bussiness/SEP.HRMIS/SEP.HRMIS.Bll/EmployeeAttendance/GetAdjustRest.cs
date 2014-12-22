//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetAdjustRest.cs
// 创建者: 薛文龙
// 创建日期: 2008-09-16
// 概述: 得到员工的剩余调休
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.LeaveRequests;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Model.Utility;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 员工的剩余调休
    /// </summary>
    public class GetAdjustRest
    {
        private GetAdjustRestHistory _GetAdjustRestHistory = new GetAdjustRestHistory();
        private GetEmployee _GetEmployee = new GetEmployee();
        private static IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private IAdjustRest _IAdjustRestDal = new AdjustRestDal();
        private ILeaveRequestDal _ILeaveRequestDal = new LeaveRequestDal();
        private ILeaveRequestFlowDal _ILeaveRequestFlowDal = new LeaveRequestFlowDal();

        #region 测试

        /// <summary>
        /// 测试
        /// </summary>
        public GetAdjustRestHistory MockGetAdjustRestHistory
        {
            set { _GetAdjustRestHistory = value; }
        }

        /// <summary>
        /// 测试
        /// </summary>
        public IAdjustRest MockIAdjustRest
        {
            set { _IAdjustRestDal = value; }
        }

        /// <summary>
        /// 测试
        /// </summary>
        public GetEmployee MockGetEmployee
        {
            set { _GetEmployee = value; }
        }

        /// <summary>
        /// 测试
        /// </summary>
        public ILeaveRequestDal MockILeaveRequestDal
        {
            set { _ILeaveRequestDal = value; }
        }

        /// <summary>
        /// 测试
        /// </summary>
        public ILeaveRequestFlowDal MockILeaveRequestFlowDal
        {
            set { _ILeaveRequestFlowDal = value; }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public GetAdjustRest()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public GetAdjustRest(IAdjustRest mockEmployeeAttendance, ILeaveRequestFlowDal mockLeaveRequestFlow)
        {
            _IAdjustRestDal = mockEmployeeAttendance;
            _ILeaveRequestFlowDal = mockLeaveRequestFlow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mockEmployeeAttendance"></param>
        /// <param name="mockLeaveRequest"></param>
        /// <param name="mockLeaveRequestFlow"></param>
        public GetAdjustRest(IAdjustRest mockEmployeeAttendance, ILeaveRequestDal mockLeaveRequest,
                             ILeaveRequestFlowDal mockLeaveRequestFlow)
        {
            _IAdjustRestDal = mockEmployeeAttendance;
            _ILeaveRequestDal = mockLeaveRequest;
            _ILeaveRequestFlowDal = mockLeaveRequestFlow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public decimal GetAdjustRestRemainedDaysByEmployeeID(int accountID)
        {
            return GetNowAdjustRestByAccountID(accountID).SurplusHours;
        }

        ///// <summary>
        ///// 获取员工可用的剩余调休天数 剩余调休天数-已提交待审核的调休天数-提交了但是没有经过审核就取消中的调休天数
        ///// </summary>
        ///// <param name="accountID"></param>
        ///// <returns></returns>
        //public decimal GetAvailableAdjustRestDaysByEmployeeID(int accountID)
        //{
        //    //获得剩余调休
        //    decimal availableTime = GetNowAdjustRestByAccountID(accountID).SurplusHours;
        //    //获得“提交”的调休小时总数
        //    decimal submittingTotalTime =
        //        _ILeaveRequestDal.SumLeaveRequestCostTimeByEmployeeIDStatusApplyType(accountID, RequestStatus.Submit,
        //                                                                             LeaveRequestTypeEnum.AdjustRest);
        //    //获得“审批中”的调休小时总数
        //    submittingTotalTime +=
        //        _ILeaveRequestDal.SumLeaveRequestCostTimeByEmployeeIDStatusApplyType(accountID, RequestStatus.Approving,
        //                                                                             LeaveRequestTypeEnum.AdjustRest);

        //    //还没审核过就取消了 但仍旧要预扣
        //    submittingTotalTime +=
        //        new GetLeaveRequest(_ILeaveRequestDal, _ILeaveRequestFlowDal).
        //            GetAdjustRestCostTimeByEmployeeWhenCancelAfterSubmit(accountID);
        //    return availableTime - submittingTotalTime;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequest"></param>
        /// <returns></returns>
        public bool AdjudgeAdjustAvailable(LeaveRequest leaveRequest)
        {
            int accountID = leaveRequest.Account.Id;
            //获得“提交”的调休小时总数
            //获得“审批中”的调休小时总数
            //还没审核过就取消了 但仍旧要预扣
            List<LeaveRequest> leaveRequestByAccountID = _ILeaveRequestDal.GetLeaveRequestByAccountID(accountID);
            List<LeaveRequestItem> leaveRequestItems = new List<LeaveRequestItem>();
            List<LeaveRequestItem> leaveRequestItems2 = new List<LeaveRequestItem>();
            foreach (LeaveRequest request in leaveRequestByAccountID)
            {
                if (request.LeaveRequestType.LeaveRequestTypeID == (int)LeaveRequestTypeEnum.AdjustRest)
                {
                    foreach (LeaveRequestItem item in request.LeaveRequestItems)
                    {
                        if (item.Status.Id == RequestStatus.Submit.Id || item.Status.Id == RequestStatus.Approving.Id)
                        {
                            leaveRequestItems.Add(item);
                        }
                        else if (item.Status.Id == RequestStatus.CancelApproving.Id ||
                                 item.Status.Id == RequestStatus.Cancelled.Id)
                        {
                            leaveRequestItems2.Add(item);
                        }
                    }
                }
            }
            leaveRequestItems.AddRange(new GetLeaveRequest().AdjustIfApprovePass(leaveRequestItems2));
            leaveRequestItems.AddRange(leaveRequest.LeaveRequestItems);

            JudgeAdjustRestCanDelete judgeAdjustRestCanDelete =
                new JudgeAdjustRestCanDelete(leaveRequestItems, accountID);
            try
            {
                judgeAdjustRestCanDelete.Excute();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<AdjustRest> GetAdjustRestByCondition(string employeeName,
                                                         EmployeeTypeEnum employeeType, int positionID,
                                                         int departmentID,
                                                         bool recursionDepartment, Account _operator, int? powers, int employeeStatus)
        {
            List<AdjustRest> adjustRestList = new List<AdjustRest>();
            //List<Account> accountList =
            //    _IAccountBll.GetAccountByBaseCondition(employeeName, departmentID, positionID, null, recursionDepartment, null);
            //if (powers != null)
            //{
            //    accountList = Tools.RemoteUnAuthAccount(accountList, AuthType.HRMIS, _operator, (int) powers);
            //}
            //foreach (Account account in accountList)
            //{
            //    Employee employee = _GetEmployee.GetEmployeeBasicInfoByAccountID(account.Id);
            //    if (employee == null)
            //    {
            //        continue;
            //    }
            //    if (!employee.IsNeedEmployeeStatusCondition(employeeStatus))
            //    {
            //        continue;
            //    }
            //    if (employeeType == EmployeeTypeEnum.All || employeeType == employee.EmployeeType)
            //    {
            //        //加载调休信息
            //        List<AdjustRest> arList = GetNowAdjustRestListByAccountID(account.Id);
            //        foreach (AdjustRest rest in arList)
            //        {
            //            rest.Employee = employee;
            //        }
            //        adjustRestList.AddRange(arList);
            //    }
            //}
            var list = AdjustRestLogic.GetAdjustRestByCondition(employeeName,
                                                                departmentID, positionID,
                                                                employeeType,
                                                                recursionDepartment, _operator, employeeStatus);
            foreach (var e in list)
            {
                DateTime dt = DateTime.Now;
                adjustRestList.Add(new AdjustRest
                                       {
                                           AdjustRestID = e.PKID,
                                           AdjustYear = e.AdjustYear,
                                           SurplusHours = e.Hours,
                                           Expired = new DateTime(e.AdjustYear.Year + 1, AdjustRestUtility.AvailableTime.Month, AdjustRestUtility.AvailableTime.Day) < dt,
                                           Employee = new Employee()
                                                          {
                                                              Account = new Account
                                                                            {
                                                                                Name = e.EmployeeName,
                                                                                Id = e.AccountId,
                                                                                Dept = new Department(e.DepartmentId, e.DepartmentName),
                                                                                Position = new Position(e.PositionId, e.PositionName, null)
                                                                            },
                                                              EmployeeType = (EmployeeTypeEnum)e.EmployeeType,
                                                              EmployeeDetails = new EmployeeDetails()
                                                                                    {
                                                                                        Work = new Work()
                                                                                                   {
                                                                                                       ComeDate = e.ComeDate
                                                                                                   }
                                                                                    }
                                                          }
                                       });
            }
            return adjustRestList;
        }

        /// <summary>
        /// 根据员工ID获得调休信息，包括历史信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public AdjustRest GetAdjustRestByAccountID(int accountID)
        {
            AdjustRest retAdjustRest = GetNowAdjustRestByAccountID(accountID);
            retAdjustRest.Employee = new Employee(accountID, EmployeeTypeEnum.All);
            retAdjustRest.Employee = _GetEmployee.GetEmployeeBasicInfoByAccountID(accountID);
            retAdjustRest.AdjustRestHistoryList =
                _GetAdjustRestHistory.GetAdjustRestHistoryByAccountID(accountID);
            return retAdjustRest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public AdjustRest GetAdjustRestByPKID(int pkid)
        {
            AdjustRest retAdjustRest = _IAdjustRestDal.GetAdjustRestByPKID(pkid);
            retAdjustRest.Employee = new Employee(retAdjustRest.Employee.Account.Id, EmployeeTypeEnum.All);
            retAdjustRest.Employee = _GetEmployee.GetEmployeeBasicInfoByAccountID(retAdjustRest.Employee.Account.Id);
            retAdjustRest.AdjustRestHistoryList =
                _GetAdjustRestHistory.GetAdjustRestHistoryByAccountID(retAdjustRest.Employee.Account.Id);
            return retAdjustRest;
        }

        /// <summary>
        /// 根据员工ID获得调休信息，不包括历史信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public AdjustRest GetAdjustRestBasicInfoByAccountID(int accountID)
        {
            AdjustRest retAdjustRest = GetNowAdjustRestByAccountID(accountID);
            retAdjustRest.Employee = new Employee(accountID, EmployeeTypeEnum.All);
            retAdjustRest.Employee = _GetEmployee.GetEmployeeBasicInfoByAccountID(accountID);
            return retAdjustRest;
        }


        /// <summary>
        /// 通过时间查询某个员工有效的调休值，没有则返回0
        /// </summary>
        public AdjustRest GetAdjustRestByAccountIDAndTime(int accountid, DateTime dt)
        {
            AdjustRest retAdjustRest;
            //判断是不是12月21号以后
            if (dt.Month == AdjustRestUtility.StartTime.Month &&
                dt.Day >= AdjustRestUtility.StartTime.Day)
            {
                dt = dt.AddYears(1);
            }
            retAdjustRest = _IAdjustRestDal.GetAdjustRestByAccountIDAndYear(accountid, dt);
            if (retAdjustRest == null)
            {
                retAdjustRest = new AdjustRest(0, 0, null, dt);
            }
            if (dt.Date <=
                new DateTime(dt.Year, AdjustRestUtility.AvailableTime.Month, AdjustRestUtility.AvailableTime.Day)
                || (dt.Month == AdjustRestUtility.StartTime.Month &&
                dt.Day >= AdjustRestUtility.StartTime.Day))
            {
                retAdjustRest.SurplusHours +=
                    _IAdjustRestDal.GetAdjustRestByAccountIDAndYear(accountid, dt.AddYears(-1)).SurplusHours;
            }
            return retAdjustRest;
        }

        ///<summary>
        ///</summary>
        public AdjustRest GetNowAdjustRestByAccountID(int accountid)
        {
            return GetAdjustRestByAccountIDAndTime(accountid, DateTime.Now);
        }

        private List<AdjustRest> GetNowAdjustRestListByAccountID(int accountid)
        {
            List<AdjustRest> adjustRestList = new List<AdjustRest>();
            DateTime dt = DateTime.Now;
            //判断是不是12月21号以后
            if (dt.Month == AdjustRestUtility.StartTime.Month &&
                dt.Day >= AdjustRestUtility.StartTime.Day)
            {
                dt = dt.AddYears(1);
            }
            AdjustRest retAdjustRest1;
            AdjustRest retAdjustRest2;
            retAdjustRest1 = _IAdjustRestDal.GetAdjustRestByAccountIDAndYear(accountid, dt);
            retAdjustRest2 =
                _IAdjustRestDal.GetAdjustRestByAccountIDAndYear(accountid, dt.AddYears(-1));
            retAdjustRest1 = retAdjustRest1 ?? new AdjustRest(0, 0, null, dt);
            retAdjustRest2 = retAdjustRest2 ?? new AdjustRest(0, 0, null, dt.AddYears(-1));
            if (dt.Date >
                new DateTime(dt.Year, AdjustRestUtility.AvailableTime.Month, AdjustRestUtility.AvailableTime.Day))
            {
                retAdjustRest2.Expired = true;
            }
            adjustRestList.Add(retAdjustRest1);
            adjustRestList.Add(retAdjustRest2);
            return adjustRestList;
        }
    }
}