using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.HRMIS.Model.DiyProcesss;
using System.IO;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// ���˻ҵ��ӿ�
    /// </summary>
    public interface IAssessActivityFacade
    {
        /// <summary>
        /// ���ݻ״̬��ID����ȡ��Ӧ�Ŀ����
        /// </summary>
        AssessActivity GetAssessActivityByAssessActivityID(int AssessActivityID);

        /// <summary>
        /// ��ȡaccountId�ܷ��������������Ա��
        /// </summary>
        List<Account> GetAssessActivityForManagerApply(int accountId);

        /// <summary>
        /// ΪHR��ȡ�����뿼�˵�Ա��
        /// </summary>
        List<Account> GetAssessActivityForHRApply(string employeeName,
                                                          EmployeeTypeEnum employeeType, int positionID,
                                                          int departmentID,
                                                          bool recursionDepartment, Account loginUser);

        /// <summary>
        /// ���ݻ״̬����ȡ��EmployeeID����Ŀ����
        /// </summary>
        /// <param name="EmployeeID">�л�ȴ�Employeeȥ����</param>
        /// <param name="Status">�������ת״̬</param>
        /// <returns></returns>
        //List<AssessActivity> GetAssessActivityByEmployeeStatus(int EmployeeID, AssessStatus Status);

        ///<summary>
        /// ͨ����ǰ��Ա����Id����ȡ���д���ǰԱ����д�Ŀ����
        ///</summary>
        List<AssessActivity> GetEmployeeFillActivitys(int currentEmployeeId);

        /// <summary>
        /// ͨ����ǰ�����ܵ�Id����ȡ���д���ǰ������д�Ŀ����
        /// </summary>
        List<AssessActivity> GetManagerFillActivitys(int currentManagerId);

        ///// <summary>
        ///// ͨ����ǰ���ܼ��Id����ȡ���д���ǰ�ܼ���д�Ŀ����
        ///// </summary>
        //List<AssessActivity> GetDirectFillActivitys(int currentDirectId);

        /// <summary>
        /// ͨ����ǰ��Ceo��Id����ȡ���д���ǰCeo��д�Ŀ����
        /// </summary>
        List<AssessActivity> GetCeoFillActivitys(int currentCeoId);

        /// <summary>
        /// ͨ����ǰ���ܼ��Id����ȡ���д���ǰ�ܼ���д�Ŀ����
        /// </summary>
        List<AssessActivity> GetSummarizeCommmentFillActivitys(int currentDirectId);

        /// <summary>
        /// ������ѯ���˻
        /// </summary>
        List<AssessActivity> GetAssessActivityByCondition(string employeeName,
                                                          AssessCharacterType assessCharacterType, AssessStatus status,
                                                          DateTime? hrSubmitTimeFrom, DateTime? hrSubmitTimeTo,
                                                          int finishStatus, DateTime? scopeFrom, DateTime? scopeTo, int departmentID,
                                                    Account loginuser, int power);

        /// <summary>
        /// ������ѯ���˻
        /// </summary>
        List<AssessActivity> GetAnnualAssessActivityByCondition(string employeeName,
                                                          AssessCharacterType assessCharacterType, AssessStatus status,
                                                          DateTime? hrSubmitTimeFrom, DateTime? hrSubmitTimeTo,
                                                          int finishStatus, DateTime? scopeFrom, DateTime? scopeTo, int departmentID,
                                                    Account loginuser, int power);

        /// <summary>
        /// ������ѯ���˻
        /// </summary>
        List<AssessActivity> GetContractAssessActivityByCondition(string employeeName,
                                                          AssessCharacterType assessCharacterType, AssessStatus status,
                                                          DateTime? hrSubmitTimeFrom, DateTime? hrSubmitTimeTo,
                                                          int finishStatus, DateTime? scopeFrom, DateTime? scopeTo, int departmentID,
                                                    Account loginuser, int power);

        /// <summary>
        /// ��ȡEmployeeIDԱ���μӵ����л
        /// </summary>
        List<AssessActivity> GetAssessActivityByAccountId(int accountId);

        /// <summary>
        /// �������ܲ������������µ�assessActivity
        /// </summary>
        List<AssessActivity> GetAssessActivityByManagerName(string managerName);

        /// <summary>
        /// �����Լ�������Ŀ���
        /// </summary>
        List<AssessActivity> GetAssessActivityHistoryByEmployeeName(string employeeName);

        /// <summary>
        /// ������
        /// </summary>
        void ManualAssess(AssessActivity assessActivity);

        /// <summary>
        /// �жϿ��˻
        /// </summary>
        void InterruptActivity(int assessActivityID);

        /// <summary>
        /// ȷ�Ͽ���
        /// </summary>
        void ConfirmActivityExcute(int activityId, int assessTempletPaperId, DateTime managerExpectedFinish,
                        DateTime personalExpectedTime, string currentEmployeeName);

        /// <summary>
        /// ���˿����������
        /// </summary>
        void FillEmployeeItemsExcute(int activityId, List<AssessActivityItem> answers, string comments,
                          string intention, bool ifSubmit, string currentEmployeeName);

        /// <summary>
        /// ���ܿ����������
        /// </summary>
        void FillManagerItemsExcute(int activityId, List<AssessActivityItem> answers, string comments,
                                    string intention, bool ifSubmit, string currentEmployeeName, decimal? salaryChange);

        /// <summary>
        /// ���¿����������
        /// </summary>
        void FillHRItemsExcute(int activityId, List<AssessActivityItem> answers, string comments,
                               bool ifSubmit, string currentEmployeeName, decimal? salaryNow);

        ///// <summary>
        ///// �ܼ࿼���������
        ///// </summary>
        //void FillDirectorCommentExcute(int activityId, string comment, string currentEmployeeName);

        /// <summary>
        /// CEO�����������
        /// </summary>
        void FillCEOCommentExcute(int activityId, string comment, string currentEmployeeName, decimal? salaryChange);

        /// <summary>
        /// CEO�����������
        /// </summary>
        void FillSummarizeCommmentExcute(int activityId, string comment, string currentEmployeeName);

        /// <summary>
        /// �����Զ������̲����ҳ�������
        /// </summary>
        Account GetDiyStepAccount(int activityAccountId, DiyStep diyStep);


        /// <summary>
        /// �������ܿ���
        /// </summary>
        string ExportLeaderAssessForm(int assessActivityId, string employeeTemplateLocation);

        /// <summary>
        /// �������˿���
        /// </summary>
        string ExportEmployeeSelfAssessForm(int assessActivityId, string employeeTemplateLocation);

        /// <summary>
        /// ����Ա���Ƿ�ɼ�
        /// </summary>
        void SetEmployeeVisible(int assessActivityID, bool ifEmployeeVisible);

        /// <summary>
        /// ����ҵļ�Ч����
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        List<AssessActivity> GetMyAssessActivityByAccountId(int EmployeeID);

        /// <summary>
        /// ������ͬ����������
        /// </summary>
        string ExportExportNormalForContractAssessForm(int assessActivityId, string employeeTemplateLocation);
        /// <summary>
        /// ����Ա�������ռ�Ч��ĸ��˹����ܽ��
        /// </summary>
        string ExportEmployeeNormalSummary(int assessActivityId, string employeeTemplateLocation);

        ///<summary>
        /// ����Ա�����ռ�Ч���˹����ܽ��
        ///</summary>
        string ExportEmployeeAnnualSummary(int assessActivityId, string employeeTemplateLocation);

        /// <summary>
        /// �������Ա������ͳ�Ʊ�(�����ռ�Ч)
        /// </summary>
        string ExportAnnualAssessForm(int assessActivityId, string employeeTemplateLocation);

        /// <summary>
        /// ����Ա�����ռ�Ч����
        /// </summary>
        MemoryStream ExportAnualAssessListExcel(string employeeTemplateLocation, string employeeName,
                                           DateTime? hrSubmitTimeFrom, DateTime? hrSubmitTimeTo,
                                           int finishStatus, DateTime? scopeFrom, DateTime? scopeTo, int departmentID,
                                           Account loginuser, int power, AssessStatus assessStatus);

        /// <summary>
        /// ɾ�������
        /// </summary>
        /// <param name="assessActivityID"></param>
        void DeleteAssessActivity(int assessActivityID);
    }
}
