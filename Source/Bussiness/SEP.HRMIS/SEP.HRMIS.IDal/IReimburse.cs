//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IReimburse.cs
// ������: wangshali
// ��������: 2008-10-06
// ����: ����
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

        //���ݼ���ʱ����ұ�����
        List<Reimburse> GetReimburseByEmployeeIDBillingTime
            (int employeeId, DateTime billingFrom, DateTime billingTo);

        Reimburse GetReimburseByReimburseID(int ReimburseID);
        void UpdateReimburse(Account loginUser, Reimburse reimburse, ReimburseStatusEnum statusEnum);

        List<Reimburse> GetMyAuditingReimburses(int accountID);

        List<ReimburseFlow> GetReimbursesHistory(int ReimburseID);

        void UpdateEmployeeReimburse(Reimburse reimburse);

        /// <summary>
        /// ��ȡ��ǰʱ��ǰ24Сʱδ�͵�������˵ı�����
        /// </summary>
        /// <returns></returns>
        List<Reimburse> GetReimburseByDateTime();

        /// <summary>
        /// ��ѯ��������ͻ��ĸ���
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
        /// ���±���item
        /// </summary>
        /// <param name="reimburse"></param>
        void UpdateReimburseItemCustomer(Reimburse reimburse);
    }
}