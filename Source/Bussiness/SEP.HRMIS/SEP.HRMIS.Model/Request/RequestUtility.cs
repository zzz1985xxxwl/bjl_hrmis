//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: RequestUtility.cs
// Creater:  Xue.wenlong
// Date:  2009-05-12
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.HRMIS.Model.Request
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetCancelChose()
        {
            Dictionary<string, string> OutStatus = new Dictionary<string, string>();
            OutStatus.Add("0", "取消");
            return OutStatus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetConfirmChose()
        {
            Dictionary<string, string> OutStatus = new Dictionary<string, string>();
            OutStatus.Add("0", "批准");
            OutStatus.Add("1", "拒绝");
            return OutStatus;
        }

        /// <summary>
        /// 方法重载，根据员工列表获取员工姓名字符串
        /// </summary>
        /// <param name="accountList">员工列表</param>
        /// <returns></returns>
        public static string GetEmployeeNames(List<Account> accountList)
        {
            StringBuilder employees = new StringBuilder();
            if (accountList != null)
            {
                int count = accountList.Count;
                for (int i = 0; i < count; i++)
                {
                    employees.Append(accountList[i].Name);
                    if (i < count - 1)
                    {
                        employees.Append("，");
                    }
                }
            }
            return employees.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetNameListString(List<String> stringlist)
        {
            StringBuilder employees = new StringBuilder();
            if (stringlist != null)
            {
                int count = stringlist.Count;
                for (int i = 0; i < count; i++)
                {
                    employees.Append(stringlist[i]);
                    if (i < count - 1)
                    {
                        employees.Append("，");
                    }
                }
            }
            return employees.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetDateWithOutYear(DateTime time)
        {
            string minute;
            if (time.Minute < 10)
            {
                minute = string.Format("0{0}", time.Minute);
            }
            else
            {
                minute = time.Minute.ToString();
            }
            return string.Format("{0}-{1} {2}:{3}", time.Month, time.Day, time.Hour, minute);
        }

        /// <summary>
        /// </summary>
        public static RequestStatus GetStatus(RequestStatus status, bool isAgree)
        {
            if (isAgree)
            {
                if (status == RequestStatus.Submit || status == RequestStatus.Approving)
                {
                    return RequestStatus.ApprovePass;
                }
                else if (status == RequestStatus.Cancelled || status == RequestStatus.CancelApproving)
                {
                    return RequestStatus.ApproveCancelPass;
                }
            }
            else
            {
                if (status == RequestStatus.Submit || status == RequestStatus.Approving)
                {
                    return RequestStatus.ApproveFail;
                }
                else if (status == RequestStatus.Cancelled || status == RequestStatus.CancelApproving)
                {
                    return RequestStatus.ApproveCancelFail;
                }
            }
            return RequestStatus.ApproveFail;
        }

        /// <summary>
        /// </summary>
        public static RequestStatus GetStatus(RequestStatus status, bool isAgree, int step)
        {
            if (isAgree)
            {
                if (status == RequestStatus.Submit)
                {
                    if (step == -1)
                    {
                        return RequestStatus.ApprovePass;
                    }
                    else
                    {
                        return RequestStatus.Approving;
                    }
                }
                else if (status == RequestStatus.Cancelled)
                {
                    if (step == -1)
                    {
                        return RequestStatus.ApproveCancelPass;
                    }
                    else
                    {
                        return RequestStatus.CancelApproving;
                    }
                }
                else if (status == RequestStatus.Approving)
                {
                    if (step == -1)
                    {
                        return RequestStatus.ApprovePass;
                    }
                    else
                    {
                        return RequestStatus.Approving;
                    }
                }
                else if (status == RequestStatus.CancelApproving)
                {
                    if (step == -1)
                    {
                        return RequestStatus.ApproveCancelPass;
                    }
                    else
                    {
                        return RequestStatus.CancelApproving;
                    }
                }
            }
            else
            {
                if (status == RequestStatus.Submit || status == RequestStatus.Approving)
                {
                    return RequestStatus.ApproveFail;
                }
                else if (status == RequestStatus.Cancelled || status == RequestStatus.CancelApproving)
                {
                    return RequestStatus.ApproveCancelFail;
                }
            }
            return RequestStatus.ApproveFail;
        }

        ///<summary>
        ///</summary>
        public static string DiyProcessToString(DiyProcess diyProcess)
        {
            StringBuilder processtext = new StringBuilder();
            if (diyProcess != null && diyProcess.DiySteps != null)
            {
                foreach (DiyStep step in diyProcess.DiySteps)
                {
                    processtext.Append(step.DiyStepID);
                    processtext.Append("|");
                    processtext.Append(step.Status);
                    processtext.Append("|");
                    processtext.Append(step.OperatorType.Id);
                    processtext.Append("|");
                    processtext.Append(step.OperatorID);
                    processtext.Append("|");

                    foreach (Account account in step.MailAccount)
                    {
                        processtext.Append(account.Id);
                        processtext.Append(",");
                    }

                    processtext.Append(";");
                }
            }
            return processtext.ToString();
        }

        /// <summary>
        /// </summary>
        public static DiyProcess GetDiyProcess(string processtest)
        {
            List<DiyStep> diyStepList = new List<DiyStep>();
            string diyProcess = processtest;
            string[] diySteps = diyProcess.Split(';');
            foreach (string diyStep in diySteps)
            {
                string[] steps = diyStep.Split('|');
                if (steps.Length > 4)
                {
                    DiyStep step =
                        new DiyStep(Convert.ToInt32(steps[0]), steps[1],
                                    new OperatorType(Convert.ToInt32(steps[2]),
                                                     OperatorType.FindOperatorTypeByID(Convert.ToInt32(steps[2]))),
                                    Convert.ToInt32(steps[3]));

                    string[] mailAccounts = steps[4].Split(',');
                    foreach (string mailAccount in mailAccounts)
                    {
                        if (!string.IsNullOrEmpty(mailAccount))
                        {
                            step.MailAccount.Add(new Account(Convert.ToInt32(mailAccount), "", ""));
                        }
                    }

                    diyStepList.Add(step);
                }
            }
            DiyProcess diyprocess=new DiyProcess();
            diyprocess.DiySteps = diyStepList;
            return diyprocess;       
        }

        ///<summary>
        /// 根据当前状态，把审核状态改为取消
        ///</summary>
        public static RequestStatus MakeDisAggree(RequestStatus status)
        {
            if (status == RequestStatus.Cancelled || status == RequestStatus.CancelApproving)
            {
                return RequestStatus.ApproveCancelFail;
            }
            else
            {
                 return RequestStatus.ApproveFail;
            }
        }

        /// <summary>
        /// 把日期改成同一的一天
        /// </summary>
        public static DateTime ConvertToTime(DateTime dt)
        {
            return new DateTime(2000, 1, 1, dt.Hour, dt.Minute, dt.Second);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsAccountContain(List<Account> accountList,int accountID)
        {
            foreach (Account account in accountList)
            {
                if(account.Id==accountID)
                {
                    return true;
                }
            }
            return false;
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

        /// <summary>
        /// 
        /// </summary>
        public static string OutMailConfirmAddress()
        {
            return CompanyConfig.LOCALHOSTADDRESS.ToLower().Replace("pages/login.aspx", "Pages/HRMIS/OutApplicationPages/OutApplicationConfirmByMail.aspx");
        }

        /// <summary>
        /// 
        /// </summary>
        public static string LeaveRequestMailConfirmAddress()
        {
            return CompanyConfig.LOCALHOSTADDRESS.ToLower().Replace("pages/login.aspx", "Pages/HRMIS/LeaveRequestPages/LeaveRequestConfirmByMail.aspx");
        }

        /// <summary>
        /// 
        /// </summary>
        public static string OverWorkMailConfirmAddress()
        {
            return CompanyConfig.LOCALHOSTADDRESS.ToLower().Replace("pages/login.aspx", "Pages/HRMIS/OverWorkPages/OverWorkConfirmByMail.aspx");
        }


        /// <summary>
        /// 
        /// </summary>
        public static string PositionApplicationMailConfirmAddress()
        {
            return CompanyConfig.LOCALHOSTADDRESS.ToLower().Replace("pages/login.aspx", "Pages/HRMIS/PositionPages/PositionApplicationConfirmByMail.aspx");
        }

        /// <summary>
        /// 根据申请类型枚举获取名称
        /// </summary>
        /// <param name="type">申请类型</param>
        /// <returns></returns>
        public static string GetTypeName(ApplicationTypeEnum type)
        {
            switch (type)
            {
                case ApplicationTypeEnum.OverTime:
                    return "加班申请";
                case ApplicationTypeEnum.InCityOut:
                    return "市内外出申请";
                case ApplicationTypeEnum.OutCityOut:
                    return "出差申请";
                case ApplicationTypeEnum.TrainOut:
                    return "培训外出申请";
                case ApplicationTypeEnum.LeaveRequest:
                    return "请假申请";
                default:
                    return "";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static List<string> CleanMailAddress(List<string> address)
        {
            List<string> res=new List<string>();
            foreach (string s in address)
            {
                if(!HasAddress(res,s))
                {
                    res.Add(s);
                }
            }
            return res;
        }

        private static bool HasAddress(IEnumerable<string> adlist, string s)
        {
            foreach (string s1 in adlist)
            {
                if(s1==s)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool ContinsAccount(List<Account> accounts, Account account)
        {
            foreach (Account account1 in accounts)
            {
                if (account1 == null && account == null)
                {
                    return true;
                }
                if (account1.Id == account.Id)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsItemFlowContainStatus(List<LeaveRequestFlow> LeaveRequestFlows, RequestStatus requeststatus)
        {
            foreach (LeaveRequestFlow flow in LeaveRequestFlows)
            {
                if (flow.LeaveRequestStatus.Id == requeststatus.Id)
                {
                    return true;
                }
            }
            return false;
        }

    }
}