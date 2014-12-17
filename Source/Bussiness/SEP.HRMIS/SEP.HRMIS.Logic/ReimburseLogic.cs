using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Common.DataAccess;
using SEP.HRMIS.DataAccess;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;

namespace SEP.HRMIS.Logic
{
    public class ReimburseLogic
    {
        public static List<Reimburse> GetReimburseByCondition(Account loginUser, string employeename, int departmentid,
                                                              ReimburseStatusEnum statusEnum, ReimburseStatusEnum? exceptStatusEnum, bool? isFillCustomer,
                                                              int reimburseCategoriesEnumID, decimal? totalcostfrom,
                                                              decimal? totalcostto, DateTime? applydateFrom,
                                                              DateTime? applydateTo, DateTime? billtimeFrom,
                                                              DateTime? billtimeTo,
                                                              int companyID, int finishStatus, int auth,
                                                              PagerEntity pagerEntity)
        {
            List<int> departmentids = new List<int>();
            if (departmentid != -1)
            {
                List<Department> departments = BllInstance.DepartmentBllInstance.GetChildDeptList(departmentid);
                departmentids.Add(departmentid);
                departmentids.AddRange(departments.Select(x => x.DepartmentID).ToList());
            }
            var reimburseentities = ReimburseDA.GetReimburseByCondition(departmentids, statusEnum, exceptStatusEnum, isFillCustomer,
                                                                        reimburseCategoriesEnumID,
                                                                        totalcostfrom, totalcostto, applydateFrom,
                                                                        applydateTo, billtimeFrom, billtimeTo,
                                                                        companyID, finishStatus);
            var reimburses = reimburseentities.Select(ReimburseEntity.ConvertToReimburse).ToList();
            List<Account> accounts =
                BllInstance.AccountBllInstance.GetAccountByBaseCondition(employeename, departmentid, -1, null, true,
                                                                         null);
            accounts = Tools.RemoteUnAuthAccount(accounts, AuthType.HRMIS, loginUser, auth);
            for (int i = reimburses.Count - 1; i >= 0; i--)
            {
                if (!IsContainsAccount(accounts, reimburses[i].ApplierID))
                {
                    reimburses.RemoveAt(i);
                }
            }
            var reimbursesids = new List<int>();
            for (int i = pagerEntity.PageIndex * pagerEntity.PageSize;
                 i < (pagerEntity.PageIndex + 1) * pagerEntity.PageSize  && i < reimburses.Count;
                 i++)
            {
                Account account = BllInstance.AccountBllInstance.GetAccountById(reimburses[i].ApplierID);
                reimburses[i].ApplerName = account.Name;
                reimburses[i].Department.DepartmentName = account.Dept.DepartmentName;
                reimbursesids.Add(reimburses[i].ReimburseID);
            }
            var items = ReimburseItemDA.GetReimburseItemByReimburseID(reimbursesids);
            for (int i = pagerEntity.PageIndex * pagerEntity.PageSize;
                 i < (pagerEntity.PageIndex + 1) * pagerEntity.PageSize && i < reimburses.Count;
                 i++)
            {
                reimburses[i].ReimburseItems =
                    items.Where(x => x.ReimburseID == reimburses[i].ReimburseID).Select(ReimburseItemEntity.ConvertTo).
                        ToList();
            }

            return reimburses;
        }


        private static bool IsContainsAccount(IEnumerable<Account> accounts, int accountId)
        {
            return accounts.Any(account => account.Id == accountId);
        }
    }
}