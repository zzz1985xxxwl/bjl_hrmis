using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.HRMIS.Model.TraineeApplications
{
    public class TraineeApplicationUtility
    {
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
        /// <param name="status"></param>
        /// <returns></returns>
        public static string TraineeApplicationStatusDisplay(TraineeApplicationStatus status)
        {
            switch (status.Id)
            {
                case 0:
                    return "新增";
                case 1:
                    return "提交";
                case 2:
                    return "审核拒绝";
                case 3:
                    return "审核通过";
                case 4:
                    return "审核中";
                default:
                    return "";
            }
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
        public static TraineeApplicationStatus GetStatus(TraineeApplicationStatus status, bool isAgree)
        {
            if (isAgree)
            {
                if (status == TraineeApplicationStatus.Submit || status == TraineeApplicationStatus.Approving)
                {
                    return TraineeApplicationStatus.ApprovePass;
                }
            }
            else
            {
                if (status == TraineeApplicationStatus.Submit || status == TraineeApplicationStatus.Approving)
                {
                    return TraineeApplicationStatus.ApproveFail;
                }
            }
            return TraineeApplicationStatus.ApproveFail;
        }

        /// <summary>
        /// </summary>
        public static TraineeApplicationStatus GetStatus(TraineeApplicationStatus status, bool isAgree, int step)
        {
            if (isAgree)
            {
                if (status == TraineeApplicationStatus.Submit)
                {
                    if (step == -1)
                    {
                        return TraineeApplicationStatus.ApprovePass;
                    }
                    else
                    {
                        return TraineeApplicationStatus.Approving;
                    }
                }
                else if (status == TraineeApplicationStatus.Approving)
                {
                    if (step == -1)
                    {
                        return TraineeApplicationStatus.ApprovePass;
                    }
                    else
                    {
                        return TraineeApplicationStatus.Approving;
                    }
                }
            }
            else
            {
                if (status == TraineeApplicationStatus.Submit || status == TraineeApplicationStatus.Approving)
                {
                    return TraineeApplicationStatus.ApproveFail;
                }
            }
            return TraineeApplicationStatus.ApproveFail;
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
            DiyProcess diyprocess = new DiyProcess();
            diyprocess.DiySteps = diyStepList;
            return diyprocess;
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
        public static bool IsAccountContain(List<Account> accountList, int accountID)
        {
            foreach (Account account in accountList)
            {
                if (account.Id == accountID)
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
        public static string TraineeApplicationMailConfirmAddress()
        {
            return CompanyConfig.LOCALHOSTADDRESS.ToLower().Replace("pages/login.aspx", "Pages/HRMIS/TrianApplicationPages/TraineeApplicationConfirmByMail.aspx");
        }


        /// <summary>
        /// 
        /// </summary>
        public static List<string> CleanMailAddress(List<string> address)
        {
            List<string> res = new List<string>();
            foreach (string s in address)
            {
                if (!HasAddress(res, s))
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
                if (s1 == s)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
