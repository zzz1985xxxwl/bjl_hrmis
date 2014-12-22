using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    ///<summary>
    /// �Ű�
    ///</summary>
    public interface IPlanDutyFacade
    {
        #region DutyClass
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="rule"></param>
        void AddDutyClass(DutyClass rule);

        /// <summary>
        /// �޸İ��
        /// </summary>
        /// <param name="rule"></param>
        void UpdateDutyClass(DutyClass rule);

        /// <summary>
        /// ɾ�����
        /// </summary>
        /// <param name="dutyClassId"></param>
        void DeleteDutyClass(int dutyClassId);

        /// <summary>
        /// ����PKID��ð��
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        DutyClass GetDutyClassByPKID(int pkid);

        /// <summary>
        /// ����������ѯ���
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="ruleName"></param>
        /// <returns></returns>
        List<DutyClass> GetDutyClassByCondition(int pkid, string ruleName);

        ///// <summary>
        ///// ����Ա�����ʺ�id��ÿ��ڹ���
        ///// </summary>
        ///// <param name="accountId"></param>
        ///// <param name="cardno"></param>
        ///// <returns></returns>
        //DutyClass GetAttendanceRuleAndDoorCardNoByAccountID(int accountId, out string cardno);
        #endregion
        #region PlanDutyTable

        ///<summary>
        /// ͨ��planDutyTableId�õ��Ű����Ӧ�ø��Ű���Ա��
        ///</summary>
        ///<param name="planDutyTableId"></param>
        ///<returns></returns>
        PlanDutyTable GetPlanDutyTableByPKID(int planDutyTableId);
        /// <summary>
        /// �����Ű�
        /// </summary>
        /// <returns></returns>
        /// <param name="planDutyTable"></param>
        void AddPlanDuty(PlanDutyTable planDutyTable);
        /// <summary>
        /// �޸��Ű�
        /// </summary>
        /// <returns></returns>
        /// <param name="planDutyTable"></param>
        void UpdatePlanDuty(PlanDutyTable planDutyTable);
        /// <summary>
        /// ɾ���Ű�
        /// </summary>
        /// <param name="planDutyTableId"></param>
        /// <returns></returns>
        void DeletePlanDuty(int planDutyTableId);
        /// <summary>
        /// ����������ѯ�Ű�
        /// </summary>
        /// <param name="PlanDutyTableName"></param>
        /// <returns></returns>
        /// <param name="fromTime"></param>
        /// <param name="toTime"></param>
        /// <param name="employeeName"></param>
        List<PlanDutyTable> GetPlanDutyTableByCondition(string PlanDutyTableName,
            DateTime fromTime, DateTime toTime, string employeeName,Account loginUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        List<PlanDutyDetail> GetPlanDutyDetailByAccount(int AccountID, DateTime dateStart, DateTime dateEnd);
        #endregion
    }
}
