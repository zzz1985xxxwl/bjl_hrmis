using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Common.DataAccess;
using SEP.HRMIS.DataAccess;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.HRMIS.Logic
{
    public class AssessActivityLogic
    {
        public static List<AssessActivity> GetAnnualAssessActivityByCondition(string employeeName,
                                                                       AssessCharacterType assessCharacterType,
                                                                       AssessStatus status,
                                                                       DateTime? hrSubmitTimeFrom,
                                                                       DateTime? hrSubmitTimeTo,
                                                                       int finishStatus, DateTime? scopeFrom,
                                                                       DateTime? scopeTo, int departmentID,
                                                                       Account loginuser, int power, PagerEntity pagerEntity)
        {
            var assessActivitylist = AssessActiveityDA.GetAnnualAssessActivityByCondition(assessCharacterType, status,
                                                                                          hrSubmitTimeFrom,
                                                                                          hrSubmitTimeTo, finishStatus,
                                                                                          scopeFrom, scopeTo);
            var assessActivities = assessActivitylist.Select(AssessActivityEntity.Convert).ToList();
            var ans = GetAssessActivityByEmployeeNameAndPower(assessActivities, employeeName, loginuser, power, departmentID);
            var ids = new List<int>();
            for (var i = pagerEntity.PageIndex * pagerEntity.PageSize; i < (pagerEntity.PageIndex + 1 * pagerEntity.PageSize) && i < ans.Count; i++)
            {
                ids.Add(ans[i].AssessActivityID);
            }
            var items = AssessActivityItemDA.GetByAssessActivityIDs(ids);
            var papers = AssessActivityPaperDA.GetByAssessActivityIDs(ids);
            for (var i = pagerEntity.PageIndex * pagerEntity.PageSize; i < (pagerEntity.PageIndex + 1 * pagerEntity.PageSize) && i < ans.Count; i++)
            {
                ans[i].ItsAssessActivityPaper.SubmitInfoes = papers.Where(x => x.AssessActivityID == ans[i].AssessActivityID).Select(AssessActivityPaperEntity.Convert).ToList();
                foreach (var submitInfoe in ans[i].ItsAssessActivityPaper.SubmitInfoes)
                {
                    submitInfoe.ItsAssessActivityItems = new List<AssessActivityItem>();
                    submitInfoe.ItsAssessActivityItems.AddRange(items.Where(x => x.AssessActivityPaperID == submitInfoe.SubmitInfoID).Select(AssessActivityItemEntity.Convert).ToList());

                }
            }
            return ans;
        }

        private static List<AssessActivity> GetAssessActivityByEmployeeNameAndPower
            (List<AssessActivity> assessActivitylist, string employeeName, Account loginuser, int power,
             int departmentID)
        {
            List<AssessActivity> iRet = new List<AssessActivity>();
            List<Account> accountList =
                Tools.RemoteUnAuthAccount(
                    BllInstance.AccountBllInstance.GetAccountByBaseCondition("", departmentID, -1, null, true, null),
                    AuthType.HRMIS,
                    loginuser, power);

            foreach (AssessActivity assessActivity in assessActivitylist)
            {
                if (!Tools.ContainsAccountById(accountList, assessActivity.ItsEmployee.Account.Id))
                {
                    continue;
                }
                assessActivity.ItsEmployee.Account =
                    BllInstance.AccountBllInstance.GetAccountById(assessActivity.ItsEmployee.Account.Id);
                if (string.IsNullOrEmpty(employeeName))
                {
                    iRet.Add(assessActivity);
                    continue;
                }
                if (assessActivity.ItsEmployee.Account.Name.Contains(employeeName))
                {
                    iRet.Add(assessActivity);
                    continue;
                }
            }
            return iRet;
        }

        public static List<AssessActivity> GetAssessActivityByEmployeeStatus(int EmployeeID, AssessStatus Status)
        {
            var assessActivitylist = AssessActiveityDA.GetAssessActivityByEmployeeStatus(EmployeeID, Status);
            var list = assessActivitylist.Select(AssessActivityEntity.Convert).ToList();
            var ids = list.Select(x => x.AssessActivityID).ToList();
            var items = AssessActivityItemDA.GetByAssessActivityIDs(ids);
            var papers = AssessActivityPaperDA.GetByAssessActivityIDs(ids);
            for (var i = 0; i < list.Count; i++)
            {
                list[i].ItsAssessActivityPaper.SubmitInfoes = papers.Where(x => x.AssessActivityID == list[i].AssessActivityID).Select(AssessActivityPaperEntity.Convert).ToList();
                foreach (var submitInfoe in list[i].ItsAssessActivityPaper.SubmitInfoes)
                {
                    submitInfoe.ItsAssessActivityItems = new List<AssessActivityItem>();
                    submitInfoe.ItsAssessActivityItems.AddRange(items.Where(x => x.AssessActivityPaperID == submitInfoe.SubmitInfoID).Select(AssessActivityItemEntity.Convert).ToList());
                }
            }

            foreach (Model.AssessActivity activity in list)
            {
                activity.ItsEmployee.Account =
                BllInstance.AccountBllInstance.GetAccountById(activity.ItsEmployee.Account.Id);
            }
            return list;
        }


    }
}