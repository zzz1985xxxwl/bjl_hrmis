using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.LeaveRequests;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Calendar;
using SEP.Model.Departments;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 获得请假的方法
    /// </summary>
    public class GetLeaveRequest
    {
        private readonly ILeaveRequestDal _DalLeaveRequest = DalFactory.DataAccess.CreateLeaveRequest();
        private readonly ILeaveRequestType _DalLeaveRequestType = DalFactory.DataAccess.CreateLeaveRequestType();
        private readonly ILeaveRequestFlowDal _DalLeaveRequestFlow = DalFactory.DataAccess.CreateLeaveRequestFlow();
        private readonly IVacation _DalVacation = DalFactory.DataAccess.CreateVacation();
        private readonly IPlanDutyDal _DalPlanDutyDal = DalFactory.DataAccess.CreatePlanDutyDal();
        private readonly IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;

        /// <summary>
        /// 获得请假的方法
        /// </summary>
        public GetLeaveRequest()
        {
        }

        /// <summary>
        /// 获得请假的方法
        /// </summary>
        /// <param name="mockLeaveRequest"></param>
        /// <param name="mockLeaveRequestFlow"></param>
        public GetLeaveRequest(ILeaveRequestDal mockLeaveRequest, ILeaveRequestFlowDal mockLeaveRequestFlow)
        {
            _DalLeaveRequest = mockLeaveRequest;
            _DalLeaveRequestFlow = mockLeaveRequestFlow;
        }

        /// <summary>
        /// 获得请假的方法
        /// </summary>
        /// <param name="mockVacation"></param>
        /// <param name="mockLeaveRequestType"></param>
        /// <param name="mockIPlanDutyDal"></param>
        public GetLeaveRequest(IVacation mockVacation, ILeaveRequestType mockLeaveRequestType,
                               IPlanDutyDal mockIPlanDutyDal)
        {
            _DalVacation = mockVacation;
            _DalLeaveRequestType = mockLeaveRequestType;
            _DalPlanDutyDal = mockIPlanDutyDal;
        }

        /// <summary>
        /// 获得请假的方法
        /// </summary>
        /// <param name="mockLeaveRequest"></param>
        /// <param name="mockLeaveRequestFlow"></param>
        /// <param name="mockILeaveRequestType"></param>
        /// <param name="mockIAccountBll"></param>
        /// <param name="mockIDepartmentBll"></param>
        public GetLeaveRequest(ILeaveRequestDal mockLeaveRequest, ILeaveRequestFlowDal mockLeaveRequestFlow,
                               ILeaveRequestType mockILeaveRequestType, IAccountBll mockIAccountBll,
                               IDepartmentBll mockIDepartmentBll)
        {
            _DalLeaveRequest = mockLeaveRequest;
            _DalLeaveRequestFlow = mockLeaveRequestFlow;
            _DalLeaveRequestType = mockILeaveRequestType;
            _IAccountBll = mockIAccountBll;
            _IDepartmentBll = mockIDepartmentBll;
        }

        /// <summary>
        /// 根据账号ID获得该账号的所有请假信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<LeaveRequest> GetLeaveRequestByAccountID(int accountID)
        {
            List<LeaveRequest> iRet = _DalLeaveRequest.GetLeaveRequestByAccountID(accountID);
            foreach (LeaveRequest request in iRet)
            {
                if (request != null && request.Account != null)
                {
                    request.Account = _IAccountBll.GetAccountById(request.Account.Id);
                }
            }
            return iRet;
        }

        /// <summary>
        /// 根据PKID获得的请假信息
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public LeaveRequest GetLeaveRequestByPKID(int pkid)
        {
            LeaveRequest iRet = _DalLeaveRequest.GetLeaveRequestByPKID(pkid);
            if (iRet != null && iRet.Account != null)
            {
                iRet.Account = _IAccountBll.GetAccountById(iRet.Account.Id);
            }
            return iRet;
        }

        #region 正常流程

        ///// <summary>
        ///// 正常流程
        ///// </summary>
        ///// <param name="accountID"></param>
        ///// <returns></returns>
        //public List<LeaveRequest> GetConfirmLeaveRequest(int accountID)
        //{
        //    List<LeaveRequest> leaveRequestList = new List<LeaveRequest>();
        //    List<Account> accountList = _IAccountBll.GetSubordinates(accountID);
        //    //找出所有待审核的请假申请
        //    List<LeaveRequest> confirmLeaveRequestList = _DalLeaveRequest.GetConfirmLeaveRequest();

        //    foreach (LeaveRequest confirmLeaveRequest in confirmLeaveRequestList)
        //    {
        //        foreach (Account account in accountList)
        //        {
        //            if (IsTheSameEmployee(account, confirmLeaveRequest.Account))
        //            {
        //                confirmLeaveRequest.Account = account;
        //                leaveRequestList.Add(confirmLeaveRequest);
        //            }
        //        }
        //    }
        //    return leaveRequestList;
        //}

        #endregion

        /// <summary>
        /// 自定义流程
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<LeaveRequest> GetConfirmLeaveRequest(int accountID)
        {
            List<LeaveRequest> leaveRequestList = new List<LeaveRequest>();
            //找出所有待审核的请假申请
            List<LeaveRequest> confirmLeaveRequestList = GetConfirmLeaveRequest();

            foreach (LeaveRequest confirmLeaveRequest in confirmLeaveRequestList)
            {
                foreach (LeaveRequestItem item in confirmLeaveRequest.LeaveRequestItems)
                {
                    if (item.CurrentStep.OperatorID == accountID && item.CurrentStep.Status != "取消")
                    {
                        leaveRequestList.Add(confirmLeaveRequest);
                        break;
                    }
                }
            }

            foreach (LeaveRequest request in leaveRequestList)
            {
                request.LeaveRequestType =
                    _DalLeaveRequestType.GetLeaveRequestTypeByPkid(request.LeaveRequestType.LeaveRequestTypeID);
                request.LeaveRequestType.Description = "最小单位：" + request.LeaveRequestType.LeastHour + "小时。说明：" +
                                                       request.LeaveRequestType.Description;
            }
            return leaveRequestList;
        }

        /// <summary>
        /// 根据PKID获得的请假信息
        /// </summary>
        /// <returns></returns>
        public List<LeaveRequest> GetConfirmLeaveRequest()
        {
            //找出所有待审核的请假申请
            List<LeaveRequest> confirmLeaveRequestList = _DalLeaveRequest.GetConfirmLeaveRequest();
            foreach (LeaveRequest request in confirmLeaveRequestList)
            {
                request.Account = _IAccountBll.GetAccountById(request.Account.Id);
                foreach (LeaveRequestItem item in request.LeaveRequestItems)
                {
                    if (item.CurrentStep != null)
                    {
                        item.CurrentStep.OperatorID =
                            ChangeOperatorToEmployee(request, item.CurrentStep);
                    }
                    else
                    {
                        item.CurrentStep = new DiyStep(0, "", OperatorType.Others, 0);
                    }
                }
            }
            return confirmLeaveRequestList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequest"></param>
        /// <param name="diyStep"></param>
        /// <returns></returns>
        public int ChangeOperatorToEmployee(LeaveRequest leaveRequest, DiyStep diyStep)
        {
            int accountID = 0;
            try
            {
                switch (diyStep.OperatorType.Id)
                {
                        //"本人"
                    case 0:
                        accountID = leaveRequest.Account.Id;
                        break;
                        //"部门主管"
                    case 1:
                        accountID = _IAccountBll.GetLeaderByAccountId(leaveRequest.Account.Id).Id;
                        break;
                        //"上级部门主管";
                    case 2:
                        Account account2 = _IAccountBll.GetAccountById(leaveRequest.Account.Id);
                        accountID = _IDepartmentBll.GetParentDept(account2.Dept.Id, null).Leader.Id;
                        break;
                        //"上上级部门主管"
                    case 3:
                        Account account3 = _IAccountBll.GetAccountById(leaveRequest.Account.Id);
                        Department department3 = _IDepartmentBll.GetParentDept(account3.Dept.Id, null);
                        accountID = _IDepartmentBll.GetParentDept(department3.Id, null).Leader.Id;
                        break;
                        //"上上上级部门主管"
                    case 4:
                        Account account4 = _IAccountBll.GetAccountById(leaveRequest.Account.Id);
                        Department department4 = _IDepartmentBll.GetParentDept(account4.Dept.Id, null);
                        department4 = _IDepartmentBll.GetParentDept(department4.Id, null);
                        accountID = _IDepartmentBll.GetParentDept(department4.Id, null).Leader.Id;
                        break;
                        //"上上上上级部门主管"
                    case 5:
                        Account account5 = _IAccountBll.GetAccountById(leaveRequest.Account.Id);
                        Department department5 = _IDepartmentBll.GetParentDept(account5.Dept.Id, null);
                        department5 = _IDepartmentBll.GetParentDept(department5.Id, null);
                        department5 = _IDepartmentBll.GetParentDept(department5.Id, null);
                        accountID = _IDepartmentBll.GetParentDept(department5.Id, null).Leader.Id;
                        break;
                        //"其他"
                    case 6:
                        accountID = diyStep.OperatorID;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                foreach (LeaveRequestItem item in leaveRequest.LeaveRequestItems)
                {
                    //-1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;
                    //5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
                    RequestStatus status;
                    switch (item.Status.Id)
                    {
                        case 4:
                        case 8:
                            status = RequestStatus.ApproveCancelFail;
                            break;
                        default: //1 7
                            status = RequestStatus.ApproveFail;
                            break;
                    }
                    ApproveFailLeaveRequestItem approveFailLeaveRequestItem =
                        new ApproveFailLeaveRequestItem(leaveRequest.PKID, item.LeaveRequestItemID, Account.AdminPkid,
                                                        status, HrmisUtility._No_Account);
                    approveFailLeaveRequestItem.Excute();
                }
            }
            return accountID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operatorID"></param>
        /// <param name="name"></param>
        /// <param name="fromTime"></param>
        /// <param name="toTime"></param>
        /// <returns></returns>
        public List<LeaveRequest> GetLeaveRequestConfirmHistoryByOperatorID(int operatorID, string name, DateTime fromTime, DateTime toTime)
        {
            List<LeaveRequest> iRet = _DalLeaveRequest.GetLeaveRequestConfirmHistoryByOperatorID(operatorID, fromTime, toTime);
            List<LeaveRequest> leaveRequests = new List<LeaveRequest>();
            foreach (LeaveRequest request in iRet)
            {
                request.Account = _IAccountBll.GetAccountById(request.Account.Id);
                if (request.Account.Name.Contains(name))
                {
                    leaveRequests.Add(request);
                }
            }
            return leaveRequests;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <returns></returns>
        public List<LeaveRequestFlow> GetLeaveRequestFlowByLeaveRequestID(int leaveRequestID)
        {
            List<LeaveRequestFlow> iRet = _DalLeaveRequestFlow.GetLeaveRequestFlowByLeaveRequestID(leaveRequestID);
            foreach (LeaveRequestFlow flow in iRet)
            {
                flow.LeaveRequestItem =
                    _DalLeaveRequest.GetLeaveRequestItemByPKID(flow.LeaveRequestItem.LeaveRequestItemID);
                flow.Account = _IAccountBll.GetAccountById(flow.Account.Id);
            }
            return iRet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequest"></param>
        /// <returns></returns>
        public bool AdjudgeVacationDaysAvailable(LeaveRequest leaveRequest)
        {
            int accountID = leaveRequest.Account.Id;

            #region GetVacationByAccountIDAndTimeSpan 修改年假扣除方法后，以下内容过时 by xwl 2009-8-12

            //DateTime StartDt;
            //DateTime EndDt;
            //if (leaveRequest.FromDate == null)
            //{
            //    StartDt = Convert.ToDateTime("1900-1-1");
            //}
            //else
            //{
            //    StartDt = Convert.ToDateTime(leaveRequest.FromDate);
            //}
            //if (leaveRequest.ToDate == null)
            //{
            //    EndDt = Convert.ToDateTime("2999-12-31");
            //}
            //else
            //{
            //    EndDt = Convert.ToDateTime(leaveRequest.ToDate);
            //}
            //List<Vacation> vacations =
            //    _DalVacation.GetVacationByAccountIDAndTimeSpan(accountID, StartDt, EndDt);

            #endregion

            //获得“提交”的调休小时总数
            //获得“审批中”的调休小时总数
            //还没审核过就取消了 但仍旧要预扣
            List<LeaveRequest> leaveRequestByAccountID = _DalLeaveRequest.GetLeaveRequestByAccountID(accountID);
            List<LeaveRequestItem> leaveRequestItems = new List<LeaveRequestItem>();
            List<LeaveRequestItem> leaveRequestItems2 = new List<LeaveRequestItem>();
            foreach (LeaveRequest request in leaveRequestByAccountID)
            {
                if (request.LeaveRequestType.LeaveRequestTypeID == (int) LeaveRequestTypeEnum.AnnualLeave)
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
            leaveRequestItems.AddRange(AdjustIfApprovePass(leaveRequestItems2));
            leaveRequestItems.AddRange(leaveRequest.LeaveRequestItems);

            DeleteVacationByLeaveReuqest updateVacationByLeaveReuqest =
                new DeleteVacationByLeaveReuqest(accountID, leaveRequestItems, leaveRequest.LeaveRequestType);
            updateVacationByLeaveReuqest.IsUpdateVacation = false;
            try
            {
                updateVacationByLeaveReuqest.Excute();
            }
            catch
            {
                return false;
            }
            return true;

            #region 修改年假扣除方法后，以下内容过时 by xwl 2009-8-12

            //for (int i = 0; i < vacations.Count; i++)
            //{
            //    decimal itemTime = 0;
            //    decimal availableTime = vacations[i].SurplusDayNum * 8;
            //    foreach (LeaveRequestItem item in leaveRequestItems)
            //    {
            //        //请假开始时间晚于年假开始时间，请假结束时间早于年假结束时间
            //        if (item.FromDate >= vacations[i].VacationStartDate && item.ToDate <= vacations[i].VacationEndDate)
            //        {
            //            itemTime += item.CostTime;
            //        }
            //        //请假开始时间早于年假开始时间，请假结束时间晚于年假结束时间
            //        else if (item.FromDate <= vacations[i].VacationStartDate &&
            //                 item.ToDate >= vacations[i].VacationEndDate)
            //        {
            //            itemTime +=
            //                new CalculateCostHour(vacations[i].VacationStartDate, vacations[i].VacationEndDate,
            //                                      leaveRequest.Account.Id,
            //                                      leaveRequest.LeaveRequestType.LeaveRequestTypeID,
            //                                      _DalLeaveRequestType,
            //                                      _DalPlanDutyDal).Excute();
            //        }
            //        //请假开始时间早于年假开始时间，请假结束时间早于年假结束时间
            //        else if (item.FromDate <= vacations[i].VacationStartDate &&
            //                 item.ToDate >= vacations[i].VacationStartDate
            //                 && item.ToDate <= vacations[i].VacationEndDate)
            //        {
            //            itemTime +=
            //                new CalculateCostHour(vacations[i].VacationStartDate, item.ToDate,
            //                                      leaveRequest.Account.Id,
            //                                      leaveRequest.LeaveRequestType.LeaveRequestTypeID,
            //                                      _DalLeaveRequestType,
            //                                      _DalPlanDutyDal).Excute();
            //        }
            //        //请假开始时间晚于年假开始时间，请假结束时间晚于年假结束时间
            //        else if (item.FromDate >= vacations[i].VacationStartDate &&
            //                 item.FromDate <= vacations[i].VacationEndDate
            //                 && item.ToDate >= vacations[i].VacationEndDate)
            //        {
            //            itemTime +=
            //                new CalculateCostHour(item.FromDate, vacations[i].VacationEndDate,
            //                                      leaveRequest.Account.Id,
            //                                      leaveRequest.LeaveRequestType.LeaveRequestTypeID,
            //                                      _DalLeaveRequestType,
            //                                      _DalPlanDutyDal).Excute();
            //        }
            //    }
            //    if (availableTime < itemTime)
            //    {
            //        return false;
            //    }
            //}

            #endregion
        }

        /// <summary>
        /// 根据员工获取提交了但是没有经过审核就取消中的年假天数
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public decimal GetAdjustRestCostTimeByEmployeeWhenCancelAfterSubmit(int employeeID)
        {
            decimal costTime = 0;
            List<LeaveRequestItem> LeaveRequestItems = new List<LeaveRequestItem>();
            List<LeaveRequestItem> LeaveRequestItems1 =
                _DalLeaveRequest.GetLeaveRequestItemByAccountIDAndRequestStatus(employeeID,
                                                                                LeaveRequestTypeEnum.AdjustRest,
                                                                                RequestStatus.Cancelled);

            List<LeaveRequestItem> LeaveRequestItems2 =
                _DalLeaveRequest.GetLeaveRequestItemByAccountIDAndRequestStatus(employeeID,
                                                                                LeaveRequestTypeEnum.AdjustRest,
                                                                                RequestStatus.CancelApproving);

            LeaveRequestItems.AddRange(LeaveRequestItems1);
            LeaveRequestItems.AddRange(LeaveRequestItems2);

            List<LeaveRequestItem> iRet = AdjustIfApprovePass(LeaveRequestItems);

            foreach (LeaveRequestItem item in iRet)
            {
                costTime += item.CostTime;
            }
            return costTime;
        }

        /// <summary>
        /// 找出所有曾经审核通过的item
        /// </summary>
        /// <param name="leaveRequestItems"></param>
        /// <returns></returns>
        public List<LeaveRequestItem> AdjustIfApprovePass(List<LeaveRequestItem> leaveRequestItems)
        {
            List<LeaveRequestItem> iRet = new List<LeaveRequestItem>();

            foreach (LeaveRequestItem item in leaveRequestItems)
            {
                List<LeaveRequestFlow> LeaveRequestFlows =
                    _DalLeaveRequestFlow.GetLeaveRequestFlowByLeaveRequestItemID(item.LeaveRequestItemID);

                bool ifApprovePass = false;

                foreach (LeaveRequestFlow flow in LeaveRequestFlows)
                {
                    if (flow.LeaveRequestStatus.Id == RequestStatus.ApprovePass.Id)
                    {
                        ifApprovePass = true;
                        break;
                    }
                }

                if (!ifApprovePass)
                {
                    iRet.Add(item);
                }
            }
            return iRet;
        }

        /// <summary>
        /// 通过账号ID,时间范围得到相应的加班，外出，请假情况,包括未审核的，转化为员工的日考勤列表返回
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public List<DayAttendance> GetAllCalendarByEmployee(int accountID, DateTime fromDate, DateTime toDate)
        {
            List<DayAttendance> iRet = new List<DayAttendance>();

            //找出所有符合条件的请假单及其符合条件的子项
            List<LeaveRequest> LeaveRequest = GetLeaveRequestByAccountAndRelatedDate(accountID, fromDate, toDate);

            foreach (LeaveRequest request in LeaveRequest)
            {
                foreach (LeaveRequestItem item in request.LeaveRequestItems)
                {
                    CalculateCostHour cal =
                        new CalculateCostHour(item.FromDate, item.ToDate, item.Status, accountID,
                                              request.LeaveRequestType.LeaveRequestTypeID);
                    cal.Excute();
                    iRet.AddRange(cal.DayAttendanceList);
                }
            }

            return iRet;
        }
        /// <summary>
        /// 获得与fromDate-toDate事件上有交集的请假信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public List<LeaveRequest> GetLeaveRequestByAccountAndRelatedDate(int accountID, DateTime fromDate, DateTime toDate)
        {
            #region 找出所有符合条件的请假单及其符合条件的子项

            //0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
            //根据账号找出所有审核通过、取消请假、拒绝取消假期、审核取消中的请假单
            List<LeaveRequest> LeaveRequest = _DalLeaveRequest.GetAllLeaveRequestByAccountIDForCalendar(accountID);

            for(int i=0;i<LeaveRequest.Count;i++)
            {
                DateTime fromDt = Convert.ToDateTime("1900-1-1");
                if (LeaveRequest[i].FromDate != null)
                {
                    fromDt = Convert.ToDateTime(LeaveRequest[i].FromDate);
                }
                DateTime toDt = Convert.ToDateTime("2999-12-31");
                if (LeaveRequest[i].FromDate != null)
                {
                    toDt = Convert.ToDateTime(LeaveRequest[i].ToDate);
                }
                //判断这张请假单是否在时间范围内
                if (AdjustTime(fromDt, toDt, fromDate, toDate))
                {
                    List<LeaveRequestItem> leaveRequestItemList = new List<LeaveRequestItem>();
                    foreach (LeaveRequestItem item in LeaveRequest[i].LeaveRequestItems)
                    {
                        //判断子项是否在时间范围内
                        if (AdjustTime(item.FromDate, item.ToDate, fromDate, toDate))
                        {
                            leaveRequestItemList.Add(item);
                        }
                    }
                    LeaveRequest[i].LeaveRequestItems = leaveRequestItemList;
                }
                else
                {
                    LeaveRequest.RemoveAt(i);
                    i--;
                }
            }

            #endregion
            return LeaveRequest;
        }

        /// <summary>
        /// 通过账号ID,时间范围得到相应的加班，外出，请假情况，转化为员工的日考勤列表返回
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public List<DayAttendance> GetCalendarByEmployee(int accountID, DateTime fromDate, DateTime toDate)
        {
            List<DayAttendance> iRet = new List<DayAttendance>();

            #region 找出所有符合条件的请假单及其符合条件的子项

            //0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
            //根据账号找出所有审核通过、取消请假、拒绝取消假期、审核取消中的请假单
            List<LeaveRequest> LeaveRequest = _DalLeaveRequest.GetLeaveRequestByAccountIDForCalendar(accountID);

            foreach (LeaveRequest request in LeaveRequest)
            {
                DateTime fromDt = Convert.ToDateTime("1900-1-1");
                if (request.FromDate != null)
                {
                    fromDt = Convert.ToDateTime(request.FromDate);
                }
                DateTime toDt = Convert.ToDateTime("2999-12-31");
                if (request.FromDate != null)
                {
                    toDt = Convert.ToDateTime(request.ToDate);
                }
                //判断这张请假单是否在时间范围内
                if (AdjustTime(fromDt, toDt, fromDate, toDate))
                {
                    List<LeaveRequestItem> leaveRequestItemList = new List<LeaveRequestItem>();
                    foreach (LeaveRequestItem item in request.LeaveRequestItems)
                    {
                        //判断子项是否在时间范围内
                        if (AdjustTime(item.FromDate, item.ToDate, fromDate, toDate))
                        {
                            //如果是取消或是审核取消中的，判断是否曾经审核通过过
                            if (item.Status.Id == RequestStatus.Cancelled.Id ||
                                item.Status.Id == RequestStatus.CancelApproving.Id)
                            {
                                if (AdjustIfApprovePass(item))
                                {
                                    leaveRequestItemList.Add(item);
                                }
                            }
                            else
                            {
                                leaveRequestItemList.Add(item);
                            }
                        }
                    }
                    request.LeaveRequestItems = leaveRequestItemList;
                }
            }

            #endregion

            foreach (LeaveRequest request in LeaveRequest)
            {
                foreach (LeaveRequestItem item in request.LeaveRequestItems)
                {
                    CalculateCostHour cal =
                        new CalculateCostHour(item.FromDate, item.ToDate, accountID,
                                              request.LeaveRequestType.LeaveRequestTypeID);
                    cal.Excute();
                    iRet.AddRange(cal.DayAttendanceList);
                }
            }

            return iRet;
        }

        /// <summary>
        /// 判断是否曾经审核通过的item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool AdjustIfApprovePass(LeaveRequestItem item)
        {
            List<LeaveRequestFlow> LeaveRequestFlows =
                _DalLeaveRequestFlow.GetLeaveRequestFlowByLeaveRequestItemID(item.LeaveRequestItemID);

            bool ifApprovePass = false;

            foreach (LeaveRequestFlow flow in LeaveRequestFlows)
            {
                if (flow.LeaveRequestStatus.Id == RequestStatus.ApprovePass.Id)
                {
                    ifApprovePass = true;
                    break;
                }
            }

            return ifApprovePass;
        }

        /// <summary>
        /// 判断fromDate~toDate与fromDt~toDt是否有交集，仅排除请假单开始时间晚于toDt，结束时间早于fromDt
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="fromDt"></param>
        /// <param name="toDt"></param>
        /// <returns></returns>
        private static bool AdjustTime(DateTime fromDate, DateTime toDate, DateTime fromDt, DateTime toDt)
        {
            bool iRet = true;
            if (toDate < fromDt || fromDate > toDt)
            {
                iRet = false;
            }
            return iRet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<LeaveRequest> GetLeaveRequestDetailByAccountIDAndDate(int accountID, DateTime date)
        {
            return _DalLeaveRequest.GetLeaveRequestDetailByAccountIDAndDate(accountID, date);
        }

        /// <summary>
        /// 查看员工的所有请年假情况
        /// </summary>
        public List<LeaveRequestItem> GetVacationUsedDetailByAccountID(int accountID)
        {
            List<LeaveRequestItem> leaveRequestItemList = new List<LeaveRequestItem>();
            List<LeaveRequestItem> temp = _DalLeaveRequest.GetVacationUsedDetailByAccountID(accountID);
            foreach (LeaveRequestItem item in temp)
            {
                if (item.Status.Id == RequestStatus.Cancelled.Id ||
                    item.Status.Id == RequestStatus.CancelApproving.Id)
                {
                    if (AdjustIfApprovePass(item))
                    {
                        leaveRequestItemList.Add(item);
                    }
                }
                else
                {
                    leaveRequestItemList.Add(item);
                }
            }
            return leaveRequestItemList;
        }
    }
}