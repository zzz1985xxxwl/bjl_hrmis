//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IReimburse.cs
// 创建者: wangshali
// 创建日期: 2008-10-06
// 概述: 报销
// ----------------------------------------------------------------


using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IDal
{
    public interface IReimburse
    {
        void InsertEmployeeReimburse(Employee employeeReimburse);
        void UpdateEmployeeReimburse(Employee employeeReimburse);
        void DeleteEmployeeReimburse(Employee employeeReimburse);
        Employee GetEmployeeReimburseByEmployeeID(int employeeID);

        List<Reimburse> GetReimburseByCondition(int departmentId, ReimburseStatusEnum statusEnum,
                                                int reimburseCategoriesEnumID, decimal? totalcostfrom,
                                                decimal? totalcostto, DateTime? applydateFrom, DateTime? applydateTo,
                                                DateTime? billtimeFrom, DateTime? billtimeTo, int companyID, int finishStatus);

        List<Reimburse> GetReimburseByEmployeeIDConsumeTime(int employeeId, DateTime consumeFrom, DateTime consumeTo);

        //根据记账时间查找报销单
        List<Reimburse> GetReimburseByEmployeeIDBillingTime
            (int employeeId, DateTime billingFrom, DateTime billingTo);

        Reimburse GetReimburseByReimburseID(int ReimburseID);
        void UpdateReimburse(Account loginUser, Reimburse reimburse, ReimburseStatusEnum statusEnum);

        List<Reimburse> GetMyAuditingReimburses(int accountID);

        List<ReimburseFlow> GetReimbursesHistory(int ReimburseID);

        void UpdateEmployeeReimburse(Reimburse reimburse);

        /// <summary>
        /// 获取当前时间前24小时未送到财务处审核的报销单
        /// </summary>
        /// <returns></returns>
        List<Reimburse> GetReimburseByDateTime();

        /// <summary>
        /// 查询报销单里客户的个数
        /// </summary>
        /// <param name="reiburseID"></param>
        /// <returns></returns>
        int GetCustomerCountByReiburseID(int reiburseID);

        List<Reimburse> GetReiburseTotalByCondition(string employeename, string place, string customerName,
                                                    string projectName, DateTime? applydateFrom, DateTime? applydateTo,
                                                    string remark, int ReimburseCategoriesId, DateTime? billingTimeFrom,
                                                    DateTime? billingTimeTo,int companyID);

        bool GetReiburseByCustomerID(int customerID);

        void DeleteReimburseByID(int reimburseID);

        /// <summary>
        /// 更新报销item
        /// </summary>
        /// <param name="reimburse"></param>
        void UpdateReimburseItemCustomer(Reimburse reimburse);
    }
}