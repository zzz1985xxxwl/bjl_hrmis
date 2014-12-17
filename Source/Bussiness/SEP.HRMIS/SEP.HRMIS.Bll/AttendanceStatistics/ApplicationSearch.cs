//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ApplicationSearch.cs
// 创建者: 王玥琦
// 创建日期: 2009-6-1
// 概述: 查询申请信息
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.Entity;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    ///<summary>
    ///</summary>
    public class ApplicationSearch 
    {
        private readonly IPlanDutyDal _DalRull = DalFactory.DataAccess.CreatePlanDutyDal();
        private readonly ILeaveRequestDal _DalLeaveRequest = DalFactory.DataAccess.CreateLeaveRequest();
        private readonly IOutApplication _DalOutApplication = DalFactory.DataAccess.CreateOutApplication();
        private readonly IOverWork _DalOverWork = DalFactory.DataAccess.CreateOverWork();
       
        ///<summary>
        ///</summary>
        public ApplicationSearch()
        {
        }

        /// <summary>
        /// 测试专用
        /// </summary>
        public ApplicationSearch(
            ILeaveRequestDal iLeaveRequestDal,
            IOutApplication iOutApplication, IOverWork iOverWork)
        {
            _DalLeaveRequest = iLeaveRequestDal;
            _DalOutApplication = iOutApplication;
            _DalOverWork = iOverWork;
        }

        /// <summary>
        ///将查找出来的请假转化为IRequest
        /// </summary>
        private List<Request> GetRequestFromLeaveRequest(int employeeID, DateTime formTime, DateTime toTime,
            RequestStatus status)
        {

            List<LeaveRequest> leaveRequestList=
            _DalLeaveRequest.GetLeaveRequestByCondition(employeeID, formTime, toTime, status);
            List<Request> requestList = new List<Request>();
            foreach(LeaveRequest leaveRequest in leaveRequestList)
            {
                requestList.Add(new Request(leaveRequest));
            }
            return requestList;
        }

        /// <summary>
        ///将查找出来的申请转化为IRequest
        /// </summary>
        private List<Request> GetRequestFromOutApplication(int employeeID, DateTime formTime, DateTime toTime,
            RequestStatus status,OutType type)
        {
            List<OutApplication> applicationList =
                _DalOutApplication.GetOutApplicationByCondition(employeeID, formTime, toTime, status,type);
            List<Request> requestList = new List<Request>();
            foreach (OutApplication application in applicationList)
            {
                requestList.Add(new Request(application));
            }
            return requestList;
        }
        /// <summary>
        ///将查找出来的申请转化为IRequest
        /// </summary>
        private List<Request> GetRequestFromOverWork(int employeeID, DateTime formTime, DateTime toTime,
            RequestStatus status)
        {
            List<OverWork> overWorkList = 
                _DalOverWork.GetOverWorkByCondition(employeeID, formTime, toTime, status);
            List<Request> requestList = new List<Request>();
            foreach (OverWork overWork in overWorkList)
            {
                requestList.Add(new Request(overWork));
            }
            return requestList;
        }
        
        /// <summary>
        /// 通过条件查找员工的请假，加班，外出情况，便于人事后台查看流程流转状态
        /// </summary>
        public List<Request> GetRequestRecordByCondition(string employeeName, int departmentID,int? gradeType,
            DateTime from, DateTime to, ApplicationTypeEnum applicationType,
            RequestStatus applicationStatus, Account loginUser)
        {
            List<Request> applicationList = new List<Request>();

            var list = EmployeeLogic.GetEmployeeBasicInfoByBasicCondition(employeeName, EmployeeTypeEnum.All, -1,
                                                                          gradeType, departmentID, true,
                                                                          HrmisPowers.A509, loginUser.Id, -1,
                                                                          new List<int>
                                                                              {(int) EmployeeTypeEnum.BorrowedEmployee});

            List<Employee> employeeList =new List<Employee>();
            foreach (var employeeEntity in list)
            {
                employeeList.Add(EmployeeEntity.Convert(employeeEntity));
            }
            //  new GetEmployee().GetEmployeeBasicInfoByBasicCondition(employeeName, EmployeeTypeEnum.All, -1, departmentID, true, -1, gradeType);
            //if (departmentID==-1)//如果查全部员工需去掉没有查询权限的员工
            //{
            //    EmployeeList = HrmisUtility.RemoteUnAuthEmployee(EmployeeList, AuthType.HRMIS, loginUser, HrmisPowers.A509);
            //}
            for (int i = 0; i < employeeList.Count; i++)
            {
                //if (EmployeeList[i] == null || EmployeeList[i].EmployeeType == EmployeeTypeEnum.BorrowedEmployee)
                //{
                //    continue;
                //}

                //根据入职离职时间确定考勤的有效时间

                DateTime employeeFromDate = DateTime.Compare(employeeList[i].EmployeeDetails.Work.ComeDate, from) > 0
                                                ? employeeList[i].EmployeeDetails.Work.ComeDate
                                                : from;
                DateTime employeeToDate;
                if (employeeList[i].EmployeeType == EmployeeTypeEnum.DimissionEmployee
                    && employeeList[i].EmployeeDetails.Work.DimissionInfo != null)
                {
                    employeeToDate =
                        DateTime.Compare(employeeList[i].EmployeeDetails.Work.DimissionInfo.DimissionDate, to) < 0
                            ? employeeList[i].EmployeeDetails.Work.DimissionInfo.DimissionDate
                            : to;
                }
                else
                {
                    employeeToDate = to;
                }
                if (DateTime.Compare(employeeFromDate, employeeToDate) > 0)
                {
                    continue;
                }
                employeeList[i].EmployeeAttendance = new EmployeeAttendance(employeeFromDate, employeeToDate);
                employeeList[i].EmployeeAttendance.PlanDutyDetailList = _DalRull.GetPlanDutyDetailByAccount(employeeList[i].Account.Id, employeeFromDate, employeeToDate);
                //没有考勤规则的人不会这里出现
                if (employeeList[i].EmployeeAttendance.PlanDutyDetailList == null ||
                    employeeList[i].EmployeeAttendance.PlanDutyDetailList.Count == 0)
                {
                    continue;
                }
                List<Request> applicationListTemp = new List<Request>();
                switch (applicationType)
                {
                    case ApplicationTypeEnum.All:
                        applicationListTemp.AddRange(
                            GetRequestFromLeaveRequest(employeeList[i].Account.Id,
                            employeeList[i].EmployeeAttendance.FromDate, employeeList[i].EmployeeAttendance.ToDate,
                            applicationStatus));
                        applicationListTemp.AddRange(
                            GetRequestFromOutApplication(employeeList[i].Account.Id,
                            employeeList[i].EmployeeAttendance.FromDate, employeeList[i].EmployeeAttendance.ToDate,
                             applicationStatus,OutType.All));
                        applicationListTemp.AddRange(
                            GetRequestFromOverWork(employeeList[i].Account.Id,
                            employeeList[i].EmployeeAttendance.FromDate, employeeList[i].EmployeeAttendance.ToDate,
                             applicationStatus));
                        break;
                    case ApplicationTypeEnum.LeaveRequest:
                        applicationListTemp.AddRange(
                            GetRequestFromLeaveRequest(employeeList[i].Account.Id,
                            employeeList[i].EmployeeAttendance.FromDate, employeeList[i].EmployeeAttendance.ToDate,
                             applicationStatus));
                        break;
                    case ApplicationTypeEnum.InCityOut:
                        applicationListTemp.AddRange(
                            GetRequestFromOutApplication(employeeList[i].Account.Id,
                            employeeList[i].EmployeeAttendance.FromDate, employeeList[i].EmployeeAttendance.ToDate,
                            applicationStatus,OutType.InCity));
                        break;
                    case ApplicationTypeEnum.OutCityOut:
                        applicationListTemp.AddRange(
                            GetRequestFromOutApplication(employeeList[i].Account.Id,
                            employeeList[i].EmployeeAttendance.FromDate, employeeList[i].EmployeeAttendance.ToDate,
                            applicationStatus, OutType.OutCity));
                        break;
                    case ApplicationTypeEnum.TrainOut:
                        applicationListTemp.AddRange(
                            GetRequestFromOutApplication(employeeList[i].Account.Id,
                            employeeList[i].EmployeeAttendance.FromDate, employeeList[i].EmployeeAttendance.ToDate,
                            applicationStatus, OutType.Train));
                        break;
                    case ApplicationTypeEnum.OverTime:
                        applicationListTemp.AddRange(
                            GetRequestFromOverWork(employeeList[i].Account.Id,
                            employeeList[i].EmployeeAttendance.FromDate, employeeList[i].EmployeeAttendance.ToDate,
                             applicationStatus));
                        break;
                    default:
                        break;
                }
                foreach(Request request in applicationListTemp)
                {
                    request.Account.Name = employeeList[i].Account.Name;
                }
                applicationList.AddRange(applicationListTemp);
            }
            return applicationList;
        }
    }
}
