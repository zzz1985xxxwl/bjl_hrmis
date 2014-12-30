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
        public static List<AssessActivity> GetAssessActivityByCondition(string employeeName,
                                                                       AssessCharacterType assessCharacterType,
                                                                       AssessStatus status,
                                                                       DateTime? hrSubmitTimeFrom,
                                                                       DateTime? hrSubmitTimeTo,
                                                                       int finishStatus, DateTime? scopeFrom,
                                                                       DateTime? scopeTo, int departmentID,
                                                                       Account loginuser, int power,string assessCharacter, PagerEntity pagerEntity)
        {
            var assessActivitylist = AssessActiveityDA.GetAssessActivityByCondition(assessCharacterType, status,
                                                                                          hrSubmitTimeFrom,
                                                                                          hrSubmitTimeTo, finishStatus,
                                                                                          scopeFrom, scopeTo, assessCharacter);
            var assessActivities = assessActivitylist.Select(AssessActivityEntity.Convert).ToList();
            var ans = GetAssessActivityByEmployeeNameAndPower(assessActivities, employeeName, loginuser, power, departmentID);
            BindItemInfo(pagerEntity, ans);
            return ans;
        }

        private static void BindItemInfo(PagerEntity pagerEntity, List<AssessActivity> ans)
        {
            var ids = new List<int>();
            for (var i = pagerEntity.PageIndex*pagerEntity.PageSize;
                i < ((pagerEntity.PageIndex + 1)*pagerEntity.PageSize) && i < ans.Count;
                i++)
            {
                ids.Add(ans[i].AssessActivityID);
            }
            var items = AssessActivityItemDA.GetByAssessActivityIDs(ids);
            var papers = AssessActivityPaperDA.GetByAssessActivityIDs(ids);
            for (var i = pagerEntity.PageIndex*pagerEntity.PageSize;
                i < ((pagerEntity.PageIndex + 1)*pagerEntity.PageSize) && i < ans.Count;
                i++)
            {
                ans[i].ItsAssessActivityPaper.SubmitInfoes =
                    papers.Where(x => x.AssessActivityID == ans[i].AssessActivityID)
                        .Select(AssessActivityPaperEntity.Convert)
                        .ToList();
                foreach (var submitInfoe in ans[i].ItsAssessActivityPaper.SubmitInfoes)
                {
                    submitInfoe.ItsAssessActivityItems = new List<AssessActivityItem>();
                    submitInfoe.ItsAssessActivityItems.AddRange(
                        items.Where(x => x.AssessActivityPaperID == submitInfoe.SubmitInfoID)
                            .Select(AssessActivityItemEntity.Convert)
                            .ToList());
                }
            }
        }

        private static List<AssessActivity> GetAssessActivityByEmployeeNameAndPower
            (List<AssessActivity> assessActivitylist, string employeeName, Account loginuser, int power,
             int departmentID)
        {
            List<AssessActivity> iRet = new List<AssessActivity>();

            var employees = EmployeeLogic.GetEmployeeBasicInfoByBasicConditionRetModel(employeeName, EmployeeTypeEnum.All, -1, null,
                 departmentID, null, true, power, loginuser.Id, -1, null);

            foreach (AssessActivity assessActivity in assessActivitylist)
            {
                var employee = employees.FirstOrDefault(x => x.Account.Id == assessActivity.ItsEmployee.Account.Id);
                if (employee == null || employee.Account == null || employee.Account.Id <= 0)
                {
                    continue;
                }
                assessActivity.ItsEmployee.Account = employee.Account;
                iRet.Add(assessActivity);
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

            foreach (AssessActivity activity in list)
            {
                activity.ItsEmployee.Account =
                BllInstance.AccountBllInstance.GetAccountById(activity.ItsEmployee.Account.Id);
            }
            return list;
        }


        public static List<AssessActivity> GetAssessActivityHistoryByEmployeeName(string employeeName, PagerEntity pagerEntity)
        {
            var assessActivitylist = AssessActiveityDA.GetAssessActivityHistoryByEmployeeName(employeeName)
                .Select(AssessActivityEntity.Convert).ToList();
            BindItemInfo(pagerEntity, assessActivitylist);
            return assessActivitylist;
        }


        public static List<AssessActivity> GetAssessActivityByEmployee(int employeeId, PagerEntity pagerEntity)
        {
            var assessActivitylist = AssessActiveityDA.GetAssessActivityByEmployee(employeeId)
                .Select(AssessActivityEntity.Convert).ToList();
            BindItemInfo(pagerEntity, assessActivitylist);
            return assessActivitylist;
        }
        
    }
}