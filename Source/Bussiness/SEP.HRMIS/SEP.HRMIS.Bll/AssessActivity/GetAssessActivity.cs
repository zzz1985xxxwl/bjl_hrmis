//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: GetAssessActivity.cs
// 创建者:wang.shali
// 创建日期: 2008-05-23
// 概述: 获取考核活动的业务
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mail.Model;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Departments;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SEP.HRMIS.Bll.DiyProcesses;
using SEP.Model.Utility;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAssessActivity
    {
        /// <summary>
        /// 构造类工厂
        /// </summary>
        private static AssessActivityDal _AssessActivityDal = new AssessActivityDal();
        private static IAccountBll _AccountBll = BllInstance.AccountBllInstance;

        /// <summary>
        /// 根据活动状态的ID，获取相应的考评活动
        /// </summary>
        /// <param name="AssessActivityID"></param>
        /// <returns></returns>
        public Model.AssessActivity GetAssessActivityByAssessActivityID(int AssessActivityID)
        {
            Model.AssessActivity assessActivity = _AssessActivityDal.GetAssessActivityById(AssessActivityID);
            assessActivity.ItsEmployee.Account =
                BllInstance.AccountBllInstance.GetAccountById(assessActivity.ItsEmployee.Account.Id);
            return assessActivity;
        }

        /// <summary>
        /// 获取EmployeeID员工参加的所有活动
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public List<Model.AssessActivity> GetAssessActivityByEmployee(int EmployeeID)
        {
            List<Model.AssessActivity> list = _AssessActivityDal.GetAssessActivityByEmployee(EmployeeID);
            foreach (Model.AssessActivity activity in list)
            {
                activity.ItsEmployee.Account =
                BllInstance.AccountBllInstance.GetAccountById(activity.ItsEmployee.Account.Id);
            }
            return list;
        }

  

        /// <summary>
        /// 查询当前登录人作为员工的身份需要填写的考评
        /// </summary>
        public List<Model.AssessActivity> GetEmployeeFillActivitys(int currentEmployeeId)
        {
            return AssessActivityLogic.GetAssessActivityByEmployeeStatus(currentEmployeeId, AssessStatus.PersonalFilling);
        }

        /// <summary>
        /// 根据employeeName、assessCharacterType、status、HRSubmitTime的查找所有的assessActivity
        /// </summary>
        public List<Model.AssessActivity> GetAssessActivityByCondition(string employeeName, AssessCharacterType assessCharacterType,
                                                    AssessStatus status, DateTime? hrSubmitTimeFrom, DateTime? hrSubmitTimeTo,
                                                    int finishStatus, DateTime? scopeFrom, DateTime? scopeTo, int departmentID,
                                                    Account loginuser, int power)
        {
            List<Model.AssessActivity> assessActivitylist =
                _AssessActivityDal.GetAssessActivityByCondition(assessCharacterType, status, hrSubmitTimeFrom,
                                                                hrSubmitTimeTo, finishStatus, scopeFrom, scopeTo);
            return GetAssessActivityByEmployeeNameAndPower(assessActivitylist, employeeName, loginuser, power, departmentID);
        }

        private static List<Model.AssessActivity> GetAssessActivityByEmployeeNameAndPower
            (List<Model.AssessActivity> assessActivitylist, string employeeName, Account loginuser, int power, int departmentID)
        {
            List<Model.AssessActivity> iRet = new List<Model.AssessActivity>();
     

           var employees= EmployeeLogic.GetEmployeeBasicInfoByBasicConditionRetModel(employeeName, EmployeeTypeEnum.All, -1, null,
                departmentID, null, true, power, loginuser.Id, -1, null);

            foreach (Model.AssessActivity assessActivity in assessActivitylist)
            {
                var employee =
                    employees.Where(x => x.Account.Id == assessActivity.ItsEmployee.Account.Id).FirstOrDefault();
                if (employee == null || employee.Account == null || employee.Account.Id<=0)
                {
                    continue;
                }
                assessActivity.ItsEmployee.Account = employee.Account;
                iRet.Add(assessActivity);
                    //BllInstance.AccountBllInstance.GetAccountById(assessActivity.ItsEmployee.Account.Id);
                //if (string.IsNullOrEmpty(employeeName))
                //{
                //    iRet.Add(assessActivity);
                //    continue;
                //}
                //if (assessActivity.ItsEmployee.Account.Name.Contains(employeeName))
                //{
                //    iRet.Add(assessActivity);
                //    continue;
                //}
            }
            return iRet;
        }

        /// <summary>
        /// 根据employeeName、assessCharacterType、status、HRSubmitTime的查找所有的assessActivity
        /// </summary>
        public List<Model.AssessActivity> GetAnnualAssessActivityByCondition(string employeeName, AssessCharacterType assessCharacterType,
                                                    AssessStatus status, DateTime? hrSubmitTimeFrom, DateTime? hrSubmitTimeTo,
                                                    int finishStatus, DateTime? scopeFrom, DateTime? scopeTo, int departmentID,
                                                    Account loginuser, int power)
        {
            List<Model.AssessActivity> assessActivitylist =
                _AssessActivityDal.GetAnnualAssessActivityByCondition(assessCharacterType, status, hrSubmitTimeFrom,
                                                                hrSubmitTimeTo, finishStatus, scopeFrom, scopeTo);
            return GetAssessActivityByEmployeeNameAndPower(assessActivitylist, employeeName, loginuser, power, departmentID);
        }

        /// <summary>
        /// 根据employeeName、assessCharacterType、status、HRSubmitTime的查找所有的assessActivity
        /// </summary>
        public List<Model.AssessActivity> GetContractAssessActivityByCondition(string employeeName, AssessCharacterType assessCharacterType,
                                                    AssessStatus status, DateTime? hrSubmitTimeFrom, DateTime? hrSubmitTimeTo,
                                                    int finishStatus, DateTime? scopeFrom, DateTime? scopeTo, int departmentID,
                                                    Account loginuser, int power)
        {
            List<Model.AssessActivity> assessActivitylist =
                _AssessActivityDal.GetContractAssessActivityByCondition(assessCharacterType, status, hrSubmitTimeFrom,
                                                                hrSubmitTimeTo, finishStatus, scopeFrom, scopeTo);
            return GetAssessActivityByEmployeeNameAndPower(assessActivitylist, employeeName, loginuser, power, departmentID);
        }

        /// <summary>
        /// 为HR获取可申请考核的员工
        /// </summary>
        public List<Account> GetAssessActivityForHRApply(string employeeName,
                                                          EmployeeTypeEnum employeeType, int positionID,
                                                          int departmentID,
                                                          bool recursionDepartment, Account loginUser)
        {
            List<Account> retaccount=new List<Account>();
            Auth myAuth = loginUser.FindAuth(AuthType.HRMIS, HrmisPowers.A703);
            
            if(myAuth == null)
            {
                throw new ApplicationException("没有权限访问");
            }

            List<Account> accounts =
                RemoveInvalidationAccount(
                    _AccountBll.GetAccountByBaseCondition(employeeName, departmentID, positionID, null, recursionDepartment,
                                                          null));
            foreach (Account account in accounts)
            {
                Employee employee =new GetEmployee().GetEmployeeByAccountID(account.Id);
                if (employee == null)
                {
                    continue;
                }
                if (employeeType == EmployeeTypeEnum.All || employeeType == employee.EmployeeType)
                {
                    retaccount.Add(account);
                }
            }
            if (myAuth.Departments.Count == 0)
                return retaccount;

            for (int i = retaccount.Count - 1; i >= 0; i--)
            {
                if (!SEP.Model.Utility.Tools.IsDeptListContainsDept(myAuth.Departments, retaccount[i].Dept))
                    retaccount.RemoveAt(i);
            }
            return retaccount;
        }

        /// <summary>
        /// 为Manager获取可申请考核的员工
        /// </summary>
        public List<Account> GetAssessActivityForManagerApply(int ManagerID)
        {
            return
                RemoveAssessingAccount(RemoveInvalidationAccount(_AccountBll.GetDirectSubordinates(ManagerID)),
                                       AssessCharacterType.Abnormal);
        }
        /// <summary>
        /// 移出列表中正在进行某种考评的员工
        /// </summary>
        private static List<Account> RemoveAssessingAccount(List<Account> accounts, AssessCharacterType assessCharacterType)
        {
            if (accounts == null)
            {
                accounts = new List<Account>();
            }
            for (int i = accounts.Count - 1; i >= 0; i--)
            {
                if (_AssessActivityDal.CountOpeningAssessActivityByAccountId(accounts[i].Id, assessCharacterType) >
                    0)
                    accounts.RemoveAt(i);
            }
            return accounts;
        }

        /// <summary>
        /// 移出无效员工
        /// </summary>
        private static List<Account> RemoveInvalidationAccount(List<Account> accounts)
        {
            List<Account> result = new List<Account>();

            foreach (Account account in accounts)
            {
                if(account.AccountType != VisibleType.None && account.IsHRAccount)
                {
                    result.Add(account);
                }
            }
            return result;
        }

        /// <summary>
        /// 根据主管查找他所有属下的assessActivity
        /// </summary>
        public List<Model.AssessActivity> GetAssessActivityByManagerName(string managerName)
        {
            List<Model.AssessActivity> list = _AssessActivityDal.GetAssessActivityByManagerName(managerName);
            foreach (Model.AssessActivity activity in list)
            {
                activity.ItsEmployee.Account =
                    BllInstance.AccountBllInstance.GetAccountById(activity.ItsEmployee.Account.Id);
                //foreach (SubmitInfo info in activity.ItsAssessActivityPaper.SubmitInfoes)
                //{
                //    if (info.SubmitInfoType.Id == SubmitInfoType.ManagerAssess.Id && info.FillPerson == managerName)
                //    {
                //        activity.ItsAssessActivityPaper.SubmitInfoes = new List<SubmitInfo>();
                //        activity.ItsAssessActivityPaper.SubmitInfoes.Add(info);
                //        break;
                //    }
                //}
            }

            return list;
        }
        /// <summary>
        /// 查找自己参与过的考评
        /// </summary>
        public List<Model.AssessActivity> GetAssessActivityHistoryByEmployeeName(string employeeName)
        {
            List<Model.AssessActivity> list = _AssessActivityDal.GetAssessActivityHistoryByEmployeeName(employeeName);
            foreach (Model.AssessActivity activity in list)
            {
                activity.ItsEmployee.Account =
                    BllInstance.AccountBllInstance.GetAccountById(activity.ItsEmployee.Account.Id);
            }

            return list;
        }

        private List<Model.AssessActivity> GetActivitysByStatusAndOperAccountId(int accountId, AssessStatus status)
        {
            List<Model.AssessActivity> retVal = new List<Model.AssessActivity>();

            List<Model.AssessActivity> employeeAssessActivitys = AssessActivityLogic.GetAssessActivityByEmployeeStatus(-1, status);
            foreach (Model.AssessActivity item in employeeAssessActivitys)
            {
                Account operAccount =
                    GetDiyStepAccount(item.ItsEmployee.Account.Id, item.DiyProcess.DiySteps[item.NextStepIndex]);
                if(operAccount == null)
                {
                    //mail通知人事
                    List<Account> accounts = new GetDiyProcess().GetHRPrincipalByAccountID(item.ItsEmployee.Account.Id);
                    if (accounts != null && accounts.Count > 0)
                    {
                        List<List<string>> mails = BllUtility.GetEmailsByAccountIds(accounts);
                        MailBody mailBody = new MailBody();
                        mailBody.Subject = "绩效考核流程中断";

                        StringBuilder sbMailBody = new StringBuilder(item.ItsEmployee.Account.Name);
                        sbMailBody.Append("的");
                        sbMailBody.Append(
                            AssessActivityUtility.GetCharacterNameByType(item.AssessCharacterType));
                        sbMailBody.Append("未能找到下一步处理人，被系统自动中断！");
                        mailBody.Body = sbMailBody.ToString();
                        if (mails[0].Count > 0)
                            mailBody.MailTo = mails[0];
                        if (mails[1].Count > 0)
                            mailBody.MailCc = mails[1];
                        if (mails[0].Count > 0 || mails[1].Count > 0)
                            BllInstance.MailGateWayBllInstance.Send(mailBody);
                    }

                    new InterruptActivity(item.AssessActivityID).Excute();
                    continue;
                }
                if(operAccount.Id == accountId)
                {
                    retVal.Add(item);
                }
            }
            return retVal;
        }
        /// <summary>
        /// 查询当前登录人作为主管的身份需要填写的考评
        /// </summary>
        public List<Model.AssessActivity> GetManagerFillActivitys(int currentManagerId)
        {
            return GetActivitysByStatusAndOperAccountId(currentManagerId, AssessStatus.ManagerFilling);
        }

        /// <summary>
        /// 查询当前登录人作为总监的身份需要填写的考评
        /// </summary>
        public List<Model.AssessActivity> GetDirectFillActivitys(int currentDirectId)
        {
            return GetActivitysByStatusAndOperAccountId(currentDirectId, AssessStatus.ApproveFilling);
        }

        /// <summary>
        /// 查询当前登录人作为Ceo的身份需要填写的考评
        /// </summary>
        public List<Model.AssessActivity> GetCeoFillActivitys(int currentCeoId)
        {
            return GetActivitysByStatusAndOperAccountId(currentCeoId, AssessStatus.ApproveFilling);
        }

        /// <summary>
        /// 查询当前登录人作为Ceo的身份需要填写的考评
        /// </summary>
        public List<Model.AssessActivity> GetSummarizeCommmentFillActivitys(int currentCeoId)
        {
            return GetActivitysByStatusAndOperAccountId(currentCeoId, AssessStatus.SummarizeCommment);
        }

        /// <summary>
        /// 根据自定义流程步骤找出处理人
        /// </summary>
        public Account GetDiyStepAccount(int activityAccountId, DiyStep diyStep)
        {
            Account account = null;
            try
            {
                switch (diyStep.OperatorType.Id)
                {
                    //"本人"
                    case 0:
                        account = BllInstance.AccountBllInstance.GetAccountById(activityAccountId);
                        break;
                    //"部门主管"
                    case 1:
                        account = BllInstance.AccountBllInstance.GetLeaderByAccountId(activityAccountId);
                        break;
                    //"上级部门主管";
                    case 2:
                        account = BllInstance.AccountBllInstance.GetAccountById(activityAccountId);
                        account = BllInstance.DepartmentBllInstance.GetParentDept(account.Dept.Id, null).Leader;
                        break;
                    //"上上级部门主管"
                    case 3:
                        account = BllInstance.AccountBllInstance.GetAccountById(activityAccountId);
                        Department dept = BllInstance.DepartmentBllInstance.GetParentDept(account.Dept.Id, null);
                        account = BllInstance.DepartmentBllInstance.GetParentDept(dept.Id, null).Leader;
                        break;
                    //"上上上级部门主管"
                    case 4:
                        account = BllInstance.AccountBllInstance.GetAccountById(activityAccountId);
                        Department dept4 = BllInstance.DepartmentBllInstance.GetParentDept(account.Dept.Id, null);
                        dept4 = BllInstance.DepartmentBllInstance.GetParentDept(dept4.Id, null);
                        account = BllInstance.DepartmentBllInstance.GetParentDept(dept4.Id, null).Leader;
                        break;
                    //"上上上上级部门主管"
                    case 5:
                        account = BllInstance.AccountBllInstance.GetAccountById(activityAccountId);
                        Department dept5 = BllInstance.DepartmentBllInstance.GetParentDept(account.Dept.Id, null);
                        dept5 = BllInstance.DepartmentBllInstance.GetParentDept(dept5.Id, null);
                        dept5 = BllInstance.DepartmentBllInstance.GetParentDept(dept5.Id, null);
                        account = BllInstance.DepartmentBllInstance.GetParentDept(dept5.Id, null).Leader;
                        break;
                    //"其他"
                    case 6:
                        account = BllInstance.AccountBllInstance.GetAccountById(diyStep.OperatorID);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                account = null;
            }
            
            return account;
        }

        /// <summary>
        /// 获取EmployeeID员工参加的所有活动
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public List<Model.AssessActivity> GetMyAssessActivityByAccountId(int EmployeeID)
        {
            List<Model.AssessActivity> iRet = new List<Model.AssessActivity>();
            List<Model.AssessActivity> list = _AssessActivityDal.GetAssessActivityByEmployee(EmployeeID);
            foreach (Model.AssessActivity activity in list)
            {
                //modify by liudan 2009-09-03
                //if (activity.IfEmployeeVisible)
                //{
                    activity.ItsEmployee.Account =
                        BllInstance.AccountBllInstance.GetAccountById(activity.ItsEmployee.Account.Id);
                    //foreach (SubmitInfo info in activity.ItsAssessActivityPaper.SubmitInfoes)
                    //{
                    //    if (info.SubmitInfoType.Id == SubmitInfoType.MyselfAssess.Id)
                    //    {
                    //        activity.ItsAssessActivityPaper.SubmitInfoes = new List<SubmitInfo>();
                    //        activity.ItsAssessActivityPaper.SubmitInfoes.Add(info);
                    //        break;
                    //    }
                    //}
                iRet.Add(activity);
                //}
            }
            return iRet;
        }


        ///<summary>
        /// 获取员工年终考评
        ///</summary>
        ///<param name="accountId">员工id</param>
        ///<param name="salaryTime">发工资时间</param>
        ///<returns></returns>
        public Model.AssessActivity GetAnualPerfomanceResultByAccountId(int accountId, DateTime salaryTime)
        {
            List<Model.AssessActivity> list = _AssessActivityDal.GetAssessActivityByEmployee(accountId);
            foreach (Model.AssessActivity activity in list)
            {
                if (activity.AssessCharacterType != AssessCharacterType.Annual)
                {
                    continue;
                }
                if (activity.ItsEmployee.Account.Id == accountId)
                {
                    //以結束點為參照
                    if (activity.ScopeTo.Year == new HrmisUtility().EndMonthByYearMonth(salaryTime).Year - 1)
                    {
                        return activity;
                    }
                }
            }
            return null;
        }

        #region use for test

        //public IAssessActivity AssessActivityDal
        //{
        //    set { _AssessActivityDal = value; }
        //}

        //public IEmployee EmployeeDal
        //{
        //    set { _EmployeeDal = value; }
        //}

        //public IDepartment DepartmentDal
        //{
        //    set { _DepartmentDal = value; }
        //}

        //public IGetEmployee EmployeeBll
        //{
        //    set { _EmployeeBll = value; }
        //}

        //public IGetDepartment DepartmentBll
        //{
        //    set { _DepartmentBll = value; }
        //}

        #endregion
    }
}