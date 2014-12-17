//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: BllExceptionConst.cs
// ������: �ߺ�
// ��������: 2008-05-19
// ����: ���峣�������ڱ�ʶ��Դ�ļ���Id
// ----------------------------------------------------------------

namespace SEP.HRMIS.Bll
{
    public class BllExceptionConst
    {
        public const string _NormalError = "δ֪��������ϵ����Ա";

        public const string _DbError = "DbError";

        #region Employee
        /// <summary>
        /// Ա�����ֲ����ظ�
        /// </summary>
        public const string _Employee_Name_Repeat = "_Employee_Name_Repeat";
        /// <summary>
        /// ��Ա��������
        /// </summary>
        public const string _Employee_Name_NotExist = "_Employee_Name_NotExist";
        /// <summary>
        /// ��Ա���Ѿ���ְ
        /// </summary>
        public const string _Employee_HasLeft = "_Employee_HasLeft";
        /// <summary>
        /// ��ְ��Ա����Ҫ��д��ְ��Ϣ
        /// </summary>
        public const string _Employee_NeedDimissionInformation = "_Employee_NeedDimissionInformation";
        #endregion

        #region LeaveRequest
        /// <summary>
        /// ������ͬ������Ѵ���
        /// </summary>
        public const string _LeaveRequest_Exist = "_LeaveRequest_Exist";
        /// <summary>
        /// ����ٵ����ܱ����
        /// </summary>
        public const string _LeaveRequest_CanNot_BeApproved = "_LeaveRequest_CanNot_BeApproved";

       /// <summary>
        /// ʣ����ݲ���͸֧�����ʱ�䲻�ɳ���ʣ�����Сʱ��
        /// </summary>
        public const string _Request_CostTime_AdjustRestOverAvailableTime = "_Request_CostTime_AdjustRestOverAvailableTime";
        /// <summary>
        /// ʣ����ٲ���͸֧�����ʱ�䲻�ɳ���ʣ�����Сʱ��
        /// </summary>
        public const string _Request_CostTime_AnnualLeaveOverAvailableTime = "_Request_CostTime_AnnualLeaveOverAvailableTime";

        #endregion

        #region Accounts
        /// <summary>
        /// ��¼�������ظ�
        /// </summary>
        public const string _Accounts_AccountsFrontName_Repeat = "_Accounts_AccountsFrontName_Repeat";
        /// <summary>
        /// �������
        /// </summary>
        public const string _Accounts_AccountsFront_Password_Wrong = "_Accounts_AccountsFront_Password_Wrong";
        /// <summary>
        /// ��¼��������
        /// </summary>
        public const string _Accounts_AccountsBack_NotExist = "_Accounts_AccountsBack_NotExist";
        /// <summary>
        /// ��¼�������ظ�
        /// </summary>
        public const string _Accounts_AccountsBack_Repeat = "_Accounts_AccountsBack_Repeat";
        /// <summary>
        /// �������
        /// </summary>
        public const string _Accounts_AccountsBack_Password_Wrong = "_Accounts_AccountsBack_Password_Wrong";
        /// <summary>
        /// �����UsbKey�����֤
        /// </summary>
        public const string _Accounts_AccountsBack_UsbKey_Wrong = "_Accounts_AccountsBack_UsbKey_Wrong";

        /// <summary>
        /// �����벻��ȷ
        /// </summary>
        public const string _OldPassword_Wrong = "_OldPassword_Wrong";

        #endregion

        #region department
        /// <summary>
        /// �������Ʋ����ظ�
        /// </summary>
        public const string _Department_Name_Repeat = "_Department_Name_Repeat";
        /// <summary>
        /// �����ڸò�������
        /// </summary>
        public const string _Department_Leader_NotExist = "_Department_Leader_NotExist";
        /// <summary>
        /// �ϼ����Ų���Ϊ��
        /// </summary>
        public const string _Department_ParentDepartment_CannotBeNull = "_Department_ParentDepartment_CannotBeNull";
        /// <summary>
        /// �ϼ����Ų�����
        /// </summary>
        public const string _Department_ParentDepartment_NotExist = "_Department_ParentDepartment_NotExist";
        /// <summary>
        /// �ò��Ų�����
        /// </summary>
        public const string _Department_NotExist = "_Department_NotExist";
        /// <summary>
        /// �������ϼ����Ų��ܱ��޸�
        /// </summary>
        public const string _Department_RootDepartment_CannotBeChanged = "_Department_RootDepartment_CannotBeChanged";
        /// <summary>
        /// ����Ա�����ڸò���
        /// </summary>
        public const string _Department_HasEmployee = "_Department_HasEmployee";

        public const string _Department_HasChildren = "_Department_HasChildren";
        /// <summary>
        /// ��ǰ�������Ѿ��б�������¼
        /// </summary>
        public const string _Department_HasReimburse = "_Department_HasReimburse";


        #endregion

        #region AssessManagement

        /// <summary>
        /// �������Ѿ�����
        /// </summary>
        public const string _AssessTemplateItem_Title_Exist = "_AssessTemplateItem_Title_Exist";

        /// <summary>
        /// �������Ѿ�����
        /// </summary>
        public const string _AssessTemplatePaper_PaperName_Exist = "_AssessTemplatePaper_PaperName_Exist";

        /// <summary>
        /// �ÿ���������
        /// </summary>
        public const string _AssessTemplatePaper_Not_Exist = "_AssessTemplatePaper_Not_Exist";

        /// <summary>
        /// �������еĿ�����û��20��
        /// </summary>
        public const string _AssessTemplatePaper_Not_20 = "_AssessTemplatePaper_Not_20";

        /// <summary>
        /// ���������
        /// </summary>
        public const string _AssessTemplateItem_Not_Exist = "_AssessTemplateItem_Not_Exist";

        /// <summary>
        /// �������ڿ������ϵ��
        /// </summary>
        public const string _AssessTemplateItem_In_AssessTemplatePaper = "_AssessTemplateItem_In_AssessTemplatePaper";

        #endregion

        #region AssessActivity

        /// <summary>
        /// ��ͬ��������
        /// </summary>
        public const string _CharacterNormalForContract = "_CharacterNormalForContract";
        /// <summary>
        /// ��ͬ�����꿼��
        /// </summary>
        public const string _CharacterNormal = "_CharacterNormal";
        /// <summary>
        /// ������I
        /// </summary>
        public const string _CharacterProbationI = "_CharacterProbationI";
        /// <summary>
        /// ������II
        /// </summary>
        public const string _CharacterProbationII = "_CharacterProbationII";
        /// <summary>
        /// ʵϰ��I
        /// </summary>
        public const string _CharacterPracticeI = "_CharacterPracticeI";
        /// <summary>
        /// ʵϰ��II
        /// </summary>
        public const string _CharacterPracticeII = "_CharacterPracticeII";
        /// <summary>
        /// �ǳ��濼��
        /// </summary>
        public const string _CharacterAbnormal = "_CharacterAbnormal";
        /// <summary>
        /// ���տ���
        /// </summary>
        public const string _CharacterAnnual = "_CharacterAnnual";
        /// <summary>
        /// Ա�������Ա���ʼ�����ȴ�����ȷ�ϡ�
        /// </summary>
        public const string _Email_To_HR_For_Confirming = "_Email_To_HR_For_Confirming";
        /// <summary>
        /// ��ĩ����ȷ��
        /// </summary>
        public const string _Email_To_Employee_For_Confirming_Attendance = "_Email_To_Employee_For_Confirming_Attendance";
        /// <summary>
        /// ��ٵ������Ѹ���
        /// </summary>
        public const string _Email_To_Employee_For_Vacation = "_Email_To_Employee_For_Vacation";
        /// <summary>
        /// ��ٵ�������HR
        /// </summary>
        public const string _Email_To_HR_For_Vacation = "_Email_To_HR_For_Vacation";
        /// <summary>
        /// ��ͬ��������HR
        /// </summary>
        public const string _Email_To_HR_For_Contract = "_Email_To_HR_For_Contract";
        /// <summary>
        /// ��Ա�����ڲμ��������˻
        /// </summary>
        public const string _Exist_Opening_AssessActivity = "_Exist_Opening_AssessActivity";
        /// <summary>
        /// ��Ч�Ŀ����
        /// </summary>
        /// <summary>
        /// ��Ч�Ŀ����
        /// </summary>
        public const string _InvalidActivityId = "_InvalidActivityId";
        /// <summary>
        /// ��Ч�Ŀ���ģ��
        /// </summary>
        /// <summary>
        /// ��Ч�Ŀ�����ģ��
        /// </summary>
        public const string _InvalidTemplateId = "_InvalidTemplateId";
        /// <summary>
        /// ��Ч�Ŀ�����
        /// </summary>
        public const string _InvalidFillItems = "FillItemsActivity_InvalidItem";

        /// <summary>
        /// �����������̣���ϵ���²��Ż��߹���Ա
        /// </summary>
        public const string _InvalidStatus = "_InvalidStatus";

        /// <summary>
        /// �ÿ�����Ѿ�����
        /// </summary>
        public const string _Activity_Is_Finish = "_Activity_Is_Finish";
        /// <summary>
        /// �ÿ�����Ѿ��ж�
        /// </summary>
        public const string _Activity_Is_Interrupt = "_Activity_Is_Interrupt";
        /// <summary>
        /// ��Ч�Ŀ�������
        /// </summary>
        public const string _InvalidIntention = "_InvalidIntention";


        #endregion

        #region Parameter
        /// <summary>
        /// �����������Ʋ����ظ�
        /// </summary>
        public const string _SalaryType_Name_Repeat = "_SalaryType_Name_Repeat";
        /// <summary>
        /// �����ڸù�������
        /// </summary>
        public const string _SalaryType_Name_NotExist = "_SalaryType_Name_NotExist";
        /// <summary>
        /// �˹��������Ѿ���ʹ�ã����ɱ��޸Ļ�ɾ��
        /// </summary>
        public const string _SalaryType_HasLeaveRequest = "_SalaryType_HasLeaveRequest";
        /// <summary>
        /// ����������Ʋ����ظ�
        /// </summary>
        public const string _LeaveRequestType_Name_Repeat = "_LeaveRequestType_Name_Repeat";
        /// <summary>
        /// �����ڸ��������
        /// </summary>
        public const string _LeaveRequestType_Name_NotExist = "_LeaveRequestType_Name_NotExist";
        /// <summary>
        /// ����������Ѿ���ʹ�ã����ɱ��޸Ļ�ɾ��
        /// </summary>
        public const string _LeaveRequestType_HasLeaveRequest = "_LeaveRequestType_HasLeaveRequest";
        /// <summary>
        /// ��ͬ�������Ʋ����ظ�
        /// </summary>
        public const string _ContractType_Name_Repeat = "_ContractType_Name_Repeat";
        /// <summary>
        /// �����ڸú�ͬ����
        /// </summary>
        public const string _ContractType_Name_NotExist = "_ContractType_Name_NotExist";
        /// <summary>
        /// ���к�ͬ���ڸ�����
        /// </summary>
        public const string _ConstractType_HasConstract = "_ConstractType_HasConstract";
        /// <summary>
        /// ְλ���Ʋ����ظ�
        /// </summary>
        public const string _Position_Name_Repeat = "_Position_Name_Repeat";
        /// <summary>
        /// �������ڸ�ְλ��Ա��
        /// </summary>
        public const string _Position_HasEmployee = "_Position_HasEmployee";
        /// <summary>
        /// �����ڸ�ְλ
        /// </summary>
        public const string _Position_Not_Exist = "_Position_Not_Exist";
        /// <summary>
        /// ְλ�㼶���Ʋ����ظ�
        /// </summary>
        public const string _PositionGrade_Name_Repeat = "_PositionGrade_Name_Repeat";
        /// <summary>
        /// �����ڸ�ְλ�㼶
        /// </summary>
        public const string _PositionGrade_Name_NotExist = "_PositionGrade_Name_NotExist";
        /// <summary>
        /// ��ְλ�㼶�Ѿ���ʹ�ã����ɱ��޸Ļ�ɾ��
        /// </summary>
        public const string _PositionGrade_HasPositionGrade = "_PositionGrade_HasPositionGrade";

        /// <summary>
        /// ��ѵ�����������Ͳ����ظ�
        /// </summary>
        public const string _FBQuesType_Repeat = "_FBQuesType_Repeat";


        /// <summary>
        /// �����������Ʋ����ظ�
        /// </summary>
        public const string _SkillType_Name_Repeat = "_SkillType_Name_Repeat";
        /// <summary>
        /// �����ڸü�������
        /// </summary>
        public const string _SkillType_Name_NotExist = "_SkillType_Name_NotExist";
        /// <summary>
        /// �˼��������Ѿ���ʹ�ã����ɱ��޸Ļ�ɾ��
        /// </summary>
        public const string _SkillType_HasSkill = "_SkillType_HasSkill";

        #endregion

        #region Vacation
        /// <summary>
        /// �������Ϣ������
        /// </summary>
        public const string _Vacation_Not_Exist = "_Vacation_Not_Exist";

        /// <summary>
        /// ��Ա�������Ϣ�Ѵ���
        /// </summary>
        public const string _Employee_Vacation_Exist = "_Employee_Vacation_Exist";

        #endregion

        #region Bulletin

        /// <summary>
        /// ���������ظ�
        /// </summary>
        public const string _Appendix_Title_Repeat = "_Appendix_Title_Repeat";
        /// <summary>
        /// ��������ظ�
        /// </summary>
        public const string _Bulletin_Title_Repeat = "_Bulletin_Title_Repeat";
        /// <summary>
        /// �ù��治����
        /// </summary>
        public const string _Bulletin_Not_Exist = "_Bulletin_Not_Exist";
        /// <summary>
        /// ����������
        /// </summary>
        public const string _Appendix_Not_Exist = "_Appendix_Not_Exist";
        /// <summary>
        /// ������ⲻ��Ϊ��
        /// </summary>
        public const string _Bulletin_Title_Null = "_Bulletin_Title_Null";
        /// <summary>
        /// ���鸽�������Ƿ�Ϊ�ջ����50���ַ�
        /// </summary>
        public const string _Appendix_Title_Null_Or_Big_Then_Fifty = "_Appendix_Title_Null_Or_Big_Then_Fifty";
        /// <summary>
        /// ������ⲻ�ܳ���50���ַ�
        /// </summary>
        public const string _Bulletin_Title_Big_Then_Fifty = "_Bulletin_Title_Big_Then_Fifty";


        #endregion

        #region Contract
        /// <summary>
        /// ��������ݺ�ͬ
        /// </summary>
        public const string _Contract_NotExist = "_Contract_NotExist";
        #endregion

        #region Goal
        /// <summary>
        /// ��˾Ŀ������ظ�
        /// </summary>
        public const string _CompanyGoal_Title_Repeat = "_CompanyGoal_Title_Repeat";
        /// <summary>
        /// ����Ŀ������ظ�
        /// </summary>
        public const string _PersonalGoal_Title_Repeat = "_PersonalGoal_Title_Repeat";
        /// <summary>
        /// �Ŷ�Ŀ������ظ�
        /// </summary>
        public const string _DepartmentGoal_Title_Repeat = "_DepartmentGoal_Title_Repeat";
        /// <summary>
        /// ��Ŀ�겻����
        /// </summary>
        public const string _Goal_NotExist = "_Goal_NotExist";
        /// <summary>
        /// �ù�˾Ŀ�겻����
        /// </summary>
        public const string _CompanyGoal_NotExist = "_CompanyGoal_NotExist";
        /// <summary>
        /// �ø���Ŀ�겻����
        /// </summary>
        public const string _PersonalGoal_NotExist = "_PersonalGoal_NotExist";
        /// <summary>
        /// ���Ŷ�Ŀ�겻����
        /// </summary>
        public const string _DepartmentGoal_NotExist = "_DepartmentGoal_NotExist";
        /// <summary>
        /// Ŀ����ⲻ��Ϊ��
        /// </summary>
        public const string _Goal_Title_Null = "_Goal_Title_Null";
        /// <summary>
        /// Ŀ����ⲻ�ܳ���50���ַ�
        /// </summary>
        public const string _Goal_Title_More_Then_Fifty = "_Goal_Title_More_Then_Fifty";


        #endregion

        #region Email
        /// <summary>
        /// ���ŵ�ַ����Ϊ��
        /// </summary>
        public const string _Email_From_Null = "_Email_From_Null";
        /// <summary>
        /// ���ŵ�ַ����Ϊ��
        /// </summary>
        public const string _Email_To_Null = "_Email_To_Null";
        /// <summary>
        /// �ʼ����ⲻ��Ϊ��
        /// </summary>
        public const string _Email_Subject_Null = "_Email_Subject_Null";
        /// <summary>
        /// �ʼ����Ĳ���Ϊ��
        /// </summary>
        public const string _Email_Body_Null = "_Email_Body_Null";
        /// <summary>
        /// ���ʼ�����Э��(SMTP) ����������Ϊ��
        /// </summary>
        public const string _Email_SmtpClient_Null = "_Email_SmtpClient_Null";
        /// <summary>
        /// �����ʼ�ʧ��
        /// </summary>
        public const string _Email_Send_Failure = "_Email_Send_Failure";
        #endregion

        #region Application
        /// <summary>
        /// ���������
        /// </summary>
        public const string _Application_Not_Exist = "_Application_Not_Exist";
        /// <summary>
        /// ������ͬ�������Ѵ���
        /// </summary>
        public const string _Application_Exist = "_Application_Exist";
        /// <summary>
        /// �������ѱ��ύ���޷��޸�
        /// </summary>
        public const string _Application_Not_UpdateAble = "_Application_Not_UpdateAble";
        /// <summary>
        /// �������ѱ��ύ���޷�ɾ��
        /// </summary>
        public const string _Application_Not_DeleteAble = "_Application_Not_DeleteAble";
        /// <summary>
        /// ����˲�����
        /// </summary>
        public const string _ApplicationFlow_Not_Exist = "_ApplicationFlow_Not_Exist";

        /// <summary>
        /// �޷�ȡ������
        /// </summary>
        public const string _Application_Not_CancelAble = "_Application_Not_CancelAble";

        /// <summary>
        /// �޷��������
        /// </summary>
        public const string _Application_Not_ConfirmAble = "_Application_Not_ConfirmAble";

        /// <summary>
        /// ��ʱ����ڣ�������٣��Ӱ�������¼
        /// </summary>
        public const string _Request_Date_Repeat = "_Request_Date_Repeat";
        #endregion

        #region EmployeeAttendance

        /// <summary>
        /// ϵͳ���޸�Ա��
        /// </summary>
        public const string _Employee_Not_Found = "_Employee_Not_Found";
        /// <summary>
        /// ��Ա����ͬһ���Ѿ����˿�����¼
        /// </summary>
        public const string _Absent_SameDay = "_Absent_SameDay";
        /// <summary>
        /// ��Ա����ͬһ���Ѿ��������˼�¼
        /// </summary>
        public const string _EarlyLeave_SameDay = "_EarlyLeave_SameDay";
        /// <summary>
        /// ��Ա����ͬһ���Ѿ����˳ٵ���¼
        /// </summary>
        public const string _Later_SameDay = "_Later_SameDay";
        /// <summary>
        /// �ü�¼������
        /// </summary>
        public const string _Attendance_Not_Exist = "_Attendance_Not_Exist";
        #endregion

        #region Reimburse
        /// <summary>
        /// �ñ�����������
        /// </summary>
        public const string _Reimburse_Not_Exist = "_Reimburse_Not_Exist";
        /// <summary>
        /// �ñ������ѽ��뱨�����̣������޸Ļ�ɾ��
        /// </summary>
        public const string _Reimburse_Not_Update_Or_Delete = "_Reimburse_Not_Update_Or_Delete";
        /// <summary>
        /// ����ʧ�ܣ��ñ������ѱ��ж�
        /// </summary>
        public const string _Reimburse_Has_Interruptted = "_Reimburse_Has_Interruptted";
        /// <summary>
        /// ����ʧ�ܣ��ñ������ѱ���
        /// </summary>
        public const string _Reimburse_Has_Reimbursed = "_Reimburse_Has_Reimbursed";
        /// <summary>
        /// ����ʧ�ܣ��ñ�������δ���뱨������
        /// </summary>
        public const string _Reimburse_Has_Added = "_Reimburse_Has_Added";
        /// <summary>
        /// ����ʧ�ܣ��ñ������Ѿ�ȡ��
        /// </summary>
        public const string _Reimburse_Has_Canceled = "_Reimburse_Has_Canceled";
        /// <summary>
        /// ���˺�û�б�������
        /// </summary>
        public const string _Reimburse_No_DiyProcess = "_Reimburse_No_DiyProcess";

        /// <summary>
        /// ����ʧ�ܣ��ñ��������˻�
        /// </summary>
        public const string _Reimburse_Has_Return = "_Reimburse_Has_Return";

        /// <summary>
        /// ����ʧ�ܣ��ñ����������ͨ��
        /// </summary>
        public const string _Reimburse_Has_Auditing = "_Reimburse_Has_Auditing";

        /// <summary>
        /// ����ʧ�ܣ��ñ������ѱ���
        /// </summary>
        public const string _Reimburse_Has_WaitAudit = "_Reimburse_Has_WaitAudit";

        /// <summary>
        /// ����ʧ�ܣ��ñ������ύ��
        /// </summary>
        public const string _Reimburse_Has_Reimbursing = "_Reimburse_Has_Reimbursing";
        #endregion

        #region AttendanceRule
        /// <summary>
        /// �ÿ��ڹ��򲻴���
        /// </summary>
        public const string _AttendanceRule_Not_Exist = "_AttendanceRule_Not_Exist";

        /// <summary>
        /// ���ڹ��������ظ�
        /// </summary>
        public const string _AttendanceRule_Name_Repeat = "_AttendanceRule_Name_Repeat";


        /// <summary>
        /// ��ȡ���ò�����
        /// </summary>
        public const string _AttendanceReadRule_Not_Exist = "_AttendanceReadRule_Not_Exist";

        #endregion

        #region DutyClass
        /// <summary>
        /// �ð�𲻴���
        /// </summary>
        public const string _DutyClass_Not_Exist = "_DutyClass_Not_Exist";

        /// <summary>
        /// ��������ظ�
        /// </summary>
        public const string _DutyClass_Name_Repeat = "_DutyClass_Name_Repeat";


        #endregion

        #region  AttendanceInAndOutRecord

        public const string _AttendanceInAndOut_Not_Exist = "_AttendanceInAndOut_Not_Exist";

        #endregion

        #region XML

        /// <summary>
        /// ��ٵ���Ϣ����
        /// </summary>
        public const string _LeaveRequest_Error = "_LeaveRequest_Error";

        /// <summary>
        /// xml��ȡ��������ϵ����Ա
        /// </summary>
        public const string _XML_Error = "_XML_Error";

        #endregion

        #region Asset

        public const string _AssetType_CannotBeNull = "_AssetType_CannotBeNull";

        public const string _AssetType_HasChild = "_AssetType_HasChild";

        public const string _AssetType_Repeat = "_AssetType_Repeat";

        public const string _AssetType_HasExsit = "_AssetType_HasExsit";
        #endregion

        #region Train
        public const string _TrainFBQuesiton_Repeate = "_TrainFBQuesiton_Repeate";

        public const string _TrainFBQuesitonType_Hasused = "_TrainFBQuesitonType_Hasused";

        public const string _TrainFBItem_Repeate = "_TrainFBItem_Repeate";
        /// <summary>
        /// ��ѵ�γ̲�����
        /// </summary>
        public const string _TrainCourse_NotExist = "_TrainCourse_NotExist";

        /// <summary>
        /// ��ѵ�γ��Ѿ�����
        /// </summary>
        public const string _TrainCourse_End = "_TrainCourse_End";

        public const string _TrainCourse_Interrupt = "_TrainCourse_Interrupt";

        public const string _TrainCourseNew_Cannot_End = "_TrainCourseNew_Cannot_End";

        public const string _Condinator_Cannot_Find = "_Condinator_Cannot_Find";

        public const string _Condinator_NoAuth = "_Condinator_NoAuth";

        public const string _TrainCourseManagement_NoAuth = "_TrainCourseManagement_NoAuth";
        #endregion

        #region Skill
        /// <summary>
        /// �������Ʋ����ظ�
        /// </summary>
        public const string _Skill_Name_Repeat = "_Skill_Name_Repeat";
        /// <summary>
        /// �������Ʋ�����
        /// </summary>
        public const string _Skill_Name_NotExist = "_SkillType_Name_NotExist";
        /// <summary>
        /// �˼����Ѿ���ʹ�ã����ɱ��޸Ļ�ɾ��
        /// </summary>
        public const string _Skill_HasEmployeeSkillOrCourse = "_Skill_HasEmployeeSkillOrCourse";
        #endregion

        #region Tax

        /// <summary>
        /// ˰�������ظ�
        /// </summary>
        public const string _TaxBand_BindMin_Repeat = "_TaxBand_BindMin_Repeat";

        #endregion


        #region AccountSet
        /// <summary>
        /// ���ײ������Ʋ���Ϊ��
        /// </summary>
        public const string _AccountSetParaName_IsNull = "_AccountSetParaName_IsNull";
        /// <summary>
        /// �����Ϊ��
        /// </summary>
        public const string _AccountSetParaName_BindItem_IsNull = "_AccountSetParaName_BindItem_IsNull";
        /// <summary>
        /// �����ظ������ײ�������
        /// </summary>
        public const string _AccountSetParaName_Repeat = "_AccountSetParaName_Repeat";
        /// <summary>
        /// �����Ϊ��
        /// </summary>
        public const string _AccountSet_BindItem_IsNull = "_AccountSet_BindItem_IsNull";
        /// <summary>
        /// ���ײ���������
        /// </summary>
        public const string _AccountSetPara_IsNotExist = "_AccountSetPara_IsNotExist";
        /// <summary>
        /// ����ʧ�ܣ����ײ����ѱ�ĳ��������ʹ��
        /// </summary>
        public const string _AccountSetParaName_HasUsed = "_AccountSetParaName_HasUsed";
        /// <summary>
        /// �������Ʋ���Ϊ��
        /// </summary>
        public const string _AccountSetName_IsNull = "_AccountSetName_IsNull";
        /// <summary>
        /// �����ظ�����������
        /// </summary>
        public const string _AccountSetName_Repeat = "_AccountSetName_Repeat";
        /// <summary>
        /// ���ײ���û��ʵ����
        /// </summary>
        public const string _AccountSetPara_IsNull = "_AccountSetPara_IsNull";
        /// <summary>
        /// ���㹫ʽ����Ϊ��
        /// </summary>
        public const string _AccountSet_CalculateFormula_IsNull = "_AccountSet_CalculateFormula_IsNull";
        /// <summary>
        /// ���ײ�����
        /// </summary>
        public const string _AccountSet_IsNotExist = "_AccountSet_IsNotExist";
        /// <summary>
        /// ����ʧ�ܣ��������ѱ�ʹ��
        /// </summary>
        public const string _AccountSet_EmployeeAccountSet_HasUsed = "_AccountSet_EmployeeAccountSet_HasUsed";
        /// <summary>
        /// ���ײ������ֶ�����û��ʵ����
        /// </summary>
        public const string _AccountSetPara_FieldAttribute_IsNull = "_AccountSetPara_FieldAttribute_IsNull";
        /// <summary>
        /// ������ʹ�����ظ������ײ���
        /// </summary>
        public const string _AccountSet_UseRepeatPara = "_AccountSet_UseRepeatPara";

        #endregion

        #region EmployeeAccountSet

        /// <summary>
        /// Ա�����ײ���Ϊ��
        /// </summary>
        public const string _EmployeeAccountSet_AccountSet_IsNull = "_EmployeeAccountSet_AccountSet_IsNull";
        /// <summary>
        /// ��̨�˺Ų���Ϊ��
        /// </summary>
        public const string _EmployeeAccountSet_BackAccountsName_IsNull = "_EmployeeAccountSet_BackAccountsName_IsNull";

        /// <summary>
        /// Ա����Ų���Ϊ��
        /// </summary>
        public const string _EmployeeAccountSet_EmployeeID_IsNull = "_EmployeeAccountSet_EmployeeID_IsNull";
        /// <summary>
        /// ��Ա������������
        /// </summary>
        public const string _EmployeeAccountSet_EmployeeAccountSet_NotExist =
            "_EmployeeAccountSet_EmployeeAccountSet_NotExist";
        /// <summary>
        /// �����ײ�����
        /// </summary>
        public const string _EmployeeAccountSet_AccountSet_NotExist = "_EmployeeAccountSet_AccountSet_NotExist";

        /// <summary>
        /// ��нˮ��¼������
        /// </summary>
        public const string _Employee_Salary_NotExist = "_Employee_Salary_NotExist";

        /// <summary>
        /// ��нˮ��¼�ѷ���
        /// </summary>
        public const string _Employee_Salary_Closed = "_Employee_Salary_Closed";

        /// <summary>
        /// ��нˮ��¼��û�з���
        /// </summary>
        public const string _Employee_Salary_Not_Closed = "_Employee_Salary_Not_Closed";

        /// <summary>
        /// ��Ա�����¹��ʼ�¼�Ѵ���
        /// </summary>
        public const string _Employee_Salary_Exist = "_Employee_Salary_Exist";

        #endregion

        #region ����Excel

        /// <summary>
        /// ����ʧ��
        /// </summary>
        public const string _Import_Failed = "_Import_Failed";
        /// <summary>
        /// �ϴ�ʧ��
        /// </summary>
        public const string _Upload_Failed = "_Upload_Failed";

        /// <summary>
        /// ȷ��һ��������
        /// </summary>
        public const string _Sheet_Count_NotOne = "_Sheet_Count_NotOne";

        /// <summary>
        /// û�С���������
        /// </summary>
        public const string _WithOut_EmployeeName = "_WithOut_EmployeeName";
        #endregion

        #region CompanyRegulations

        /// <summary>
        /// ��˾�����ƶȱ��ⲻ��Ϊ��
        /// </summary>
        public const string _CompanyRegulations_Title_Null = "_CompanyRegulations_Title_Null";

        /// <summary>
        /// ��˾�����ƶȸ������ⲻ��Ϊ��
        /// </summary>
        public const string _CompanyReguAppendix_FileName_Null = "_CompanyReguAppendix_FileName_Null";

        /// <summary>
        /// ��˾�����ƶȸ���·������Ϊ��
        /// </summary>
        public const string _CompanyReguAppendix_Directory_Null = "_CompanyReguAppendix_Directory_Null";
        #endregion

        #region FeedBackPaper ������

        /// <summary>
        /// �÷���������
        /// </summary>
        public const string _FeedBackPaper_Not_Exist = "_FeedBackPaper_Not_Exist";

        /// <summary>
        /// �÷����������ظ�
        /// </summary>
        public const string _FeedBackPaper_Name_Repeat = "_FeedBackPaper_Name_Repeat";

        #endregion
    }
}
