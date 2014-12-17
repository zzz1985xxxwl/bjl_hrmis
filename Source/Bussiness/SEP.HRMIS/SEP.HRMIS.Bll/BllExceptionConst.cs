//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BllExceptionConst.cs
// 创建者: 倪豪
// 创建日期: 2008-05-19
// 概述: 定义常量，用于标识资源文件的Id
// ----------------------------------------------------------------

namespace SEP.HRMIS.Bll
{
    public class BllExceptionConst
    {
        public const string _NormalError = "未知错误，请联系管理员";

        public const string _DbError = "DbError";

        #region Employee
        /// <summary>
        /// 员工名字不能重复
        /// </summary>
        public const string _Employee_Name_Repeat = "_Employee_Name_Repeat";
        /// <summary>
        /// 该员工不存在
        /// </summary>
        public const string _Employee_Name_NotExist = "_Employee_Name_NotExist";
        /// <summary>
        /// 该员工已经离职
        /// </summary>
        public const string _Employee_HasLeft = "_Employee_HasLeft";
        /// <summary>
        /// 离职的员工需要填写离职信息
        /// </summary>
        public const string _Employee_NeedDimissionInformation = "_Employee_NeedDimissionInformation";
        #endregion

        #region LeaveRequest
        /// <summary>
        /// 内容相同的请假已存在
        /// </summary>
        public const string _LeaveRequest_Exist = "_LeaveRequest_Exist";
        /// <summary>
        /// 该请假单不能被审核
        /// </summary>
        public const string _LeaveRequest_CanNot_BeApproved = "_LeaveRequest_CanNot_BeApproved";

       /// <summary>
        /// 剩余调休不可透支，请假时间不可超出剩余调休小时数
        /// </summary>
        public const string _Request_CostTime_AdjustRestOverAvailableTime = "_Request_CostTime_AdjustRestOverAvailableTime";
        /// <summary>
        /// 剩余年假不可透支，请假时间不可超出剩余年假小时数
        /// </summary>
        public const string _Request_CostTime_AnnualLeaveOverAvailableTime = "_Request_CostTime_AnnualLeaveOverAvailableTime";

        #endregion

        #region Accounts
        /// <summary>
        /// 登录名不能重复
        /// </summary>
        public const string _Accounts_AccountsFrontName_Repeat = "_Accounts_AccountsFrontName_Repeat";
        /// <summary>
        /// 密码错误
        /// </summary>
        public const string _Accounts_AccountsFront_Password_Wrong = "_Accounts_AccountsFront_Password_Wrong";
        /// <summary>
        /// 登录名不存在
        /// </summary>
        public const string _Accounts_AccountsBack_NotExist = "_Accounts_AccountsBack_NotExist";
        /// <summary>
        /// 登录名不能重复
        /// </summary>
        public const string _Accounts_AccountsBack_Repeat = "_Accounts_AccountsBack_Repeat";
        /// <summary>
        /// 密码错误
        /// </summary>
        public const string _Accounts_AccountsBack_Password_Wrong = "_Accounts_AccountsBack_Password_Wrong";
        /// <summary>
        /// 错误的UsbKey身份认证
        /// </summary>
        public const string _Accounts_AccountsBack_UsbKey_Wrong = "_Accounts_AccountsBack_UsbKey_Wrong";

        /// <summary>
        /// 旧密码不正确
        /// </summary>
        public const string _OldPassword_Wrong = "_OldPassword_Wrong";

        #endregion

        #region department
        /// <summary>
        /// 部门名称不能重复
        /// </summary>
        public const string _Department_Name_Repeat = "_Department_Name_Repeat";
        /// <summary>
        /// 不存在该部门主管
        /// </summary>
        public const string _Department_Leader_NotExist = "_Department_Leader_NotExist";
        /// <summary>
        /// 上级部门不能为空
        /// </summary>
        public const string _Department_ParentDepartment_CannotBeNull = "_Department_ParentDepartment_CannotBeNull";
        /// <summary>
        /// 上级部门不存在
        /// </summary>
        public const string _Department_ParentDepartment_NotExist = "_Department_ParentDepartment_NotExist";
        /// <summary>
        /// 该部门不存在
        /// </summary>
        public const string _Department_NotExist = "_Department_NotExist";
        /// <summary>
        /// 根结点的上级部门不能被修改
        /// </summary>
        public const string _Department_RootDepartment_CannotBeChanged = "_Department_RootDepartment_CannotBeChanged";
        /// <summary>
        /// 还有员工属于该部门
        /// </summary>
        public const string _Department_HasEmployee = "_Department_HasEmployee";

        public const string _Department_HasChildren = "_Department_HasChildren";
        /// <summary>
        /// 当前部门中已经有报销单记录
        /// </summary>
        public const string _Department_HasReimburse = "_Department_HasReimburse";


        #endregion

        #region AssessManagement

        /// <summary>
        /// 考评项已经存在
        /// </summary>
        public const string _AssessTemplateItem_Title_Exist = "_AssessTemplateItem_Title_Exist";

        /// <summary>
        /// 考评表已经存在
        /// </summary>
        public const string _AssessTemplatePaper_PaperName_Exist = "_AssessTemplatePaper_PaperName_Exist";

        /// <summary>
        /// 该考评表不存在
        /// </summary>
        public const string _AssessTemplatePaper_Not_Exist = "_AssessTemplatePaper_Not_Exist";

        /// <summary>
        /// 考评表中的考评项没有20项
        /// </summary>
        public const string _AssessTemplatePaper_Not_20 = "_AssessTemplatePaper_Not_20";

        /// <summary>
        /// 考评项不存在
        /// </summary>
        public const string _AssessTemplateItem_Not_Exist = "_AssessTemplateItem_Not_Exist";

        /// <summary>
        /// 考评项在考评表关系中
        /// </summary>
        public const string _AssessTemplateItem_In_AssessTemplatePaper = "_AssessTemplateItem_In_AssessTemplatePaper";

        #endregion

        #region AssessActivity

        /// <summary>
        /// 合同期满考核
        /// </summary>
        public const string _CharacterNormalForContract = "_CharacterNormalForContract";
        /// <summary>
        /// 合同期周年考核
        /// </summary>
        public const string _CharacterNormal = "_CharacterNormal";
        /// <summary>
        /// 试用期I
        /// </summary>
        public const string _CharacterProbationI = "_CharacterProbationI";
        /// <summary>
        /// 试用期II
        /// </summary>
        public const string _CharacterProbationII = "_CharacterProbationII";
        /// <summary>
        /// 实习期I
        /// </summary>
        public const string _CharacterPracticeI = "_CharacterPracticeI";
        /// <summary>
        /// 实习期II
        /// </summary>
        public const string _CharacterPracticeII = "_CharacterPracticeII";
        /// <summary>
        /// 非常规考核
        /// </summary>
        public const string _CharacterAbnormal = "_CharacterAbnormal";
        /// <summary>
        /// 年终考核
        /// </summary>
        public const string _CharacterAnnual = "_CharacterAnnual";
        /// <summary>
        /// 员工考核以被初始化，等待人事确认。
        /// </summary>
        public const string _Email_To_HR_For_Confirming = "_Email_To_HR_For_Confirming";
        /// <summary>
        /// 月末考勤确认
        /// </summary>
        public const string _Email_To_Employee_For_Confirming_Attendance = "_Email_To_Employee_For_Confirming_Attendance";
        /// <summary>
        /// 年假到期提醒个人
        /// </summary>
        public const string _Email_To_Employee_For_Vacation = "_Email_To_Employee_For_Vacation";
        /// <summary>
        /// 年假到期提醒HR
        /// </summary>
        public const string _Email_To_HR_For_Vacation = "_Email_To_HR_For_Vacation";
        /// <summary>
        /// 合同到期提醒HR
        /// </summary>
        public const string _Email_To_HR_For_Contract = "_Email_To_HR_For_Contract";
        /// <summary>
        /// 该员工正在参加其它考核活动
        /// </summary>
        public const string _Exist_Opening_AssessActivity = "_Exist_Opening_AssessActivity";
        /// <summary>
        /// 无效的考评活动
        /// </summary>
        /// <summary>
        /// 无效的考评活动
        /// </summary>
        public const string _InvalidActivityId = "_InvalidActivityId";
        /// <summary>
        /// 无效的考评模板
        /// </summary>
        /// <summary>
        /// 无效的考评表模板
        /// </summary>
        public const string _InvalidTemplateId = "_InvalidTemplateId";
        /// <summary>
        /// 无效的考评项
        /// </summary>
        public const string _InvalidFillItems = "FillItemsActivity_InvalidItem";

        /// <summary>
        /// 不正常的流程，联系人事部门或者管理员
        /// </summary>
        public const string _InvalidStatus = "_InvalidStatus";

        /// <summary>
        /// 该考评活动已经结束
        /// </summary>
        public const string _Activity_Is_Finish = "_Activity_Is_Finish";
        /// <summary>
        /// 该考评活动已经中断
        /// </summary>
        public const string _Activity_Is_Interrupt = "_Activity_Is_Interrupt";
        /// <summary>
        /// 无效的考评意向
        /// </summary>
        public const string _InvalidIntention = "_InvalidIntention";


        #endregion

        #region Parameter
        /// <summary>
        /// 工资类型名称不能重复
        /// </summary>
        public const string _SalaryType_Name_Repeat = "_SalaryType_Name_Repeat";
        /// <summary>
        /// 不存在该工资类型
        /// </summary>
        public const string _SalaryType_Name_NotExist = "_SalaryType_Name_NotExist";
        /// <summary>
        /// 此工资类型已经被使用，不可被修改或删除
        /// </summary>
        public const string _SalaryType_HasLeaveRequest = "_SalaryType_HasLeaveRequest";
        /// <summary>
        /// 请假类型名称不能重复
        /// </summary>
        public const string _LeaveRequestType_Name_Repeat = "_LeaveRequestType_Name_Repeat";
        /// <summary>
        /// 不存在该请假类型
        /// </summary>
        public const string _LeaveRequestType_Name_NotExist = "_LeaveRequestType_Name_NotExist";
        /// <summary>
        /// 此请假类型已经被使用，不可被修改或删除
        /// </summary>
        public const string _LeaveRequestType_HasLeaveRequest = "_LeaveRequestType_HasLeaveRequest";
        /// <summary>
        /// 合同类型名称不能重复
        /// </summary>
        public const string _ContractType_Name_Repeat = "_ContractType_Name_Repeat";
        /// <summary>
        /// 不存在该合同类型
        /// </summary>
        public const string _ContractType_Name_NotExist = "_ContractType_Name_NotExist";
        /// <summary>
        /// 还有合同属于该类型
        /// </summary>
        public const string _ConstractType_HasConstract = "_ConstractType_HasConstract";
        /// <summary>
        /// 职位名称不能重复
        /// </summary>
        public const string _Position_Name_Repeat = "_Position_Name_Repeat";
        /// <summary>
        /// 还有属于该职位的员工
        /// </summary>
        public const string _Position_HasEmployee = "_Position_HasEmployee";
        /// <summary>
        /// 不存在该职位
        /// </summary>
        public const string _Position_Not_Exist = "_Position_Not_Exist";
        /// <summary>
        /// 职位层级名称不能重复
        /// </summary>
        public const string _PositionGrade_Name_Repeat = "_PositionGrade_Name_Repeat";
        /// <summary>
        /// 不存在该职位层级
        /// </summary>
        public const string _PositionGrade_Name_NotExist = "_PositionGrade_Name_NotExist";
        /// <summary>
        /// 此职位层级已经被使用，不可被修改或删除
        /// </summary>
        public const string _PositionGrade_HasPositionGrade = "_PositionGrade_HasPositionGrade";

        /// <summary>
        /// 培训反馈问题类型不能重复
        /// </summary>
        public const string _FBQuesType_Repeat = "_FBQuesType_Repeat";


        /// <summary>
        /// 技能类型名称不能重复
        /// </summary>
        public const string _SkillType_Name_Repeat = "_SkillType_Name_Repeat";
        /// <summary>
        /// 不存在该技能类型
        /// </summary>
        public const string _SkillType_Name_NotExist = "_SkillType_Name_NotExist";
        /// <summary>
        /// 此技能类型已经被使用，不可被修改或删除
        /// </summary>
        public const string _SkillType_HasSkill = "_SkillType_HasSkill";

        #endregion

        #region Vacation
        /// <summary>
        /// 该年假信息不存在
        /// </summary>
        public const string _Vacation_Not_Exist = "_Vacation_Not_Exist";

        /// <summary>
        /// 该员工年假信息已存在
        /// </summary>
        public const string _Employee_Vacation_Exist = "_Employee_Vacation_Exist";

        #endregion

        #region Bulletin

        /// <summary>
        /// 附件标题重复
        /// </summary>
        public const string _Appendix_Title_Repeat = "_Appendix_Title_Repeat";
        /// <summary>
        /// 公告标题重复
        /// </summary>
        public const string _Bulletin_Title_Repeat = "_Bulletin_Title_Repeat";
        /// <summary>
        /// 该公告不存在
        /// </summary>
        public const string _Bulletin_Not_Exist = "_Bulletin_Not_Exist";
        /// <summary>
        /// 附件不存在
        /// </summary>
        public const string _Appendix_Not_Exist = "_Appendix_Not_Exist";
        /// <summary>
        /// 公告标题不能为空
        /// </summary>
        public const string _Bulletin_Title_Null = "_Bulletin_Title_Null";
        /// <summary>
        /// 请检查附件标题是否为空或大于50个字符
        /// </summary>
        public const string _Appendix_Title_Null_Or_Big_Then_Fifty = "_Appendix_Title_Null_Or_Big_Then_Fifty";
        /// <summary>
        /// 公告标题不能超过50个字符
        /// </summary>
        public const string _Bulletin_Title_Big_Then_Fifty = "_Bulletin_Title_Big_Then_Fifty";


        #endregion

        #region Contract
        /// <summary>
        /// 不存在这份合同
        /// </summary>
        public const string _Contract_NotExist = "_Contract_NotExist";
        #endregion

        #region Goal
        /// <summary>
        /// 公司目标标题重复
        /// </summary>
        public const string _CompanyGoal_Title_Repeat = "_CompanyGoal_Title_Repeat";
        /// <summary>
        /// 个人目标标题重复
        /// </summary>
        public const string _PersonalGoal_Title_Repeat = "_PersonalGoal_Title_Repeat";
        /// <summary>
        /// 团队目标标题重复
        /// </summary>
        public const string _DepartmentGoal_Title_Repeat = "_DepartmentGoal_Title_Repeat";
        /// <summary>
        /// 该目标不存在
        /// </summary>
        public const string _Goal_NotExist = "_Goal_NotExist";
        /// <summary>
        /// 该公司目标不存在
        /// </summary>
        public const string _CompanyGoal_NotExist = "_CompanyGoal_NotExist";
        /// <summary>
        /// 该个人目标不存在
        /// </summary>
        public const string _PersonalGoal_NotExist = "_PersonalGoal_NotExist";
        /// <summary>
        /// 该团队目标不存在
        /// </summary>
        public const string _DepartmentGoal_NotExist = "_DepartmentGoal_NotExist";
        /// <summary>
        /// 目标标题不能为空
        /// </summary>
        public const string _Goal_Title_Null = "_Goal_Title_Null";
        /// <summary>
        /// 目标标题不能超过50个字符
        /// </summary>
        public const string _Goal_Title_More_Then_Fifty = "_Goal_Title_More_Then_Fifty";


        #endregion

        #region Email
        /// <summary>
        /// 发信地址不能为空
        /// </summary>
        public const string _Email_From_Null = "_Email_From_Null";
        /// <summary>
        /// 收信地址不能为空
        /// </summary>
        public const string _Email_To_Null = "_Email_To_Null";
        /// <summary>
        /// 邮件标题不能为空
        /// </summary>
        public const string _Email_Subject_Null = "_Email_Subject_Null";
        /// <summary>
        /// 邮件正文不能为空
        /// </summary>
        public const string _Email_Body_Null = "_Email_Body_Null";
        /// <summary>
        /// 简单邮件传输协议(SMTP) 服务器不能为空
        /// </summary>
        public const string _Email_SmtpClient_Null = "_Email_SmtpClient_Null";
        /// <summary>
        /// 发送邮件失败
        /// </summary>
        public const string _Email_Send_Failure = "_Email_Send_Failure";
        #endregion

        #region Application
        /// <summary>
        /// 申请表不存在
        /// </summary>
        public const string _Application_Not_Exist = "_Application_Not_Exist";
        /// <summary>
        /// 内容相同的申请已存在
        /// </summary>
        public const string _Application_Exist = "_Application_Exist";
        /// <summary>
        /// 申请表格已被提交，无法修改
        /// </summary>
        public const string _Application_Not_UpdateAble = "_Application_Not_UpdateAble";
        /// <summary>
        /// 申请表格已被提交，无法删除
        /// </summary>
        public const string _Application_Not_DeleteAble = "_Application_Not_DeleteAble";
        /// <summary>
        /// 该审核不存在
        /// </summary>
        public const string _ApplicationFlow_Not_Exist = "_ApplicationFlow_Not_Exist";

        /// <summary>
        /// 无法取消申请
        /// </summary>
        public const string _Application_Not_CancelAble = "_Application_Not_CancelAble";

        /// <summary>
        /// 无法审核申请
        /// </summary>
        public const string _Application_Not_ConfirmAble = "_Application_Not_ConfirmAble";

        /// <summary>
        /// 该时间段内，已有请假，加班或外出记录
        /// </summary>
        public const string _Request_Date_Repeat = "_Request_Date_Repeat";
        #endregion

        #region EmployeeAttendance

        /// <summary>
        /// 系统中无该员工
        /// </summary>
        public const string _Employee_Not_Found = "_Employee_Not_Found";
        /// <summary>
        /// 该员工在同一天已经有了旷工记录
        /// </summary>
        public const string _Absent_SameDay = "_Absent_SameDay";
        /// <summary>
        /// 该员工在同一天已经有了早退记录
        /// </summary>
        public const string _EarlyLeave_SameDay = "_EarlyLeave_SameDay";
        /// <summary>
        /// 该员工在同一天已经有了迟到记录
        /// </summary>
        public const string _Later_SameDay = "_Later_SameDay";
        /// <summary>
        /// 该记录不存在
        /// </summary>
        public const string _Attendance_Not_Exist = "_Attendance_Not_Exist";
        #endregion

        #region Reimburse
        /// <summary>
        /// 该报销单不存在
        /// </summary>
        public const string _Reimburse_Not_Exist = "_Reimburse_Not_Exist";
        /// <summary>
        /// 该报销单已进入报销流程，不可修改或删除
        /// </summary>
        public const string _Reimburse_Not_Update_Or_Delete = "_Reimburse_Not_Update_Or_Delete";
        /// <summary>
        /// 操作失败，该报销单已被中断
        /// </summary>
        public const string _Reimburse_Has_Interruptted = "_Reimburse_Has_Interruptted";
        /// <summary>
        /// 操作失败，该报销单已报销
        /// </summary>
        public const string _Reimburse_Has_Reimbursed = "_Reimburse_Has_Reimbursed";
        /// <summary>
        /// 操作失败，该报销单尚未进入报销流程
        /// </summary>
        public const string _Reimburse_Has_Added = "_Reimburse_Has_Added";
        /// <summary>
        /// 操作失败，该报销单已经取消
        /// </summary>
        public const string _Reimburse_Has_Canceled = "_Reimburse_Has_Canceled";
        /// <summary>
        /// 该账号没有报销流程
        /// </summary>
        public const string _Reimburse_No_DiyProcess = "_Reimburse_No_DiyProcess";

        /// <summary>
        /// 操作失败，该报销单已退回
        /// </summary>
        public const string _Reimburse_Has_Return = "_Reimburse_Has_Return";

        /// <summary>
        /// 操作失败，该报销单已审核通过
        /// </summary>
        public const string _Reimburse_Has_Auditing = "_Reimburse_Has_Auditing";

        /// <summary>
        /// 操作失败，该报销单已报销
        /// </summary>
        public const string _Reimburse_Has_WaitAudit = "_Reimburse_Has_WaitAudit";

        /// <summary>
        /// 操作失败，该报销单提交中
        /// </summary>
        public const string _Reimburse_Has_Reimbursing = "_Reimburse_Has_Reimbursing";
        #endregion

        #region AttendanceRule
        /// <summary>
        /// 该考勤规则不存在
        /// </summary>
        public const string _AttendanceRule_Not_Exist = "_AttendanceRule_Not_Exist";

        /// <summary>
        /// 考勤规则名词重复
        /// </summary>
        public const string _AttendanceRule_Name_Repeat = "_AttendanceRule_Name_Repeat";


        /// <summary>
        /// 读取设置不存在
        /// </summary>
        public const string _AttendanceReadRule_Not_Exist = "_AttendanceReadRule_Not_Exist";

        #endregion

        #region DutyClass
        /// <summary>
        /// 该班别不存在
        /// </summary>
        public const string _DutyClass_Not_Exist = "_DutyClass_Not_Exist";

        /// <summary>
        /// 班别名词重复
        /// </summary>
        public const string _DutyClass_Name_Repeat = "_DutyClass_Name_Repeat";


        #endregion

        #region  AttendanceInAndOutRecord

        public const string _AttendanceInAndOut_Not_Exist = "_AttendanceInAndOut_Not_Exist";

        #endregion

        #region XML

        /// <summary>
        /// 请假单信息错误
        /// </summary>
        public const string _LeaveRequest_Error = "_LeaveRequest_Error";

        /// <summary>
        /// xml读取错误，请联系管理员
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
        /// 培训课程不存在
        /// </summary>
        public const string _TrainCourse_NotExist = "_TrainCourse_NotExist";

        /// <summary>
        /// 培训课程已经结束
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
        /// 技能名称不能重复
        /// </summary>
        public const string _Skill_Name_Repeat = "_Skill_Name_Repeat";
        /// <summary>
        /// 技能名称不存在
        /// </summary>
        public const string _Skill_Name_NotExist = "_SkillType_Name_NotExist";
        /// <summary>
        /// 此技能已经被使用，不可被修改或删除
        /// </summary>
        public const string _Skill_HasEmployeeSkillOrCourse = "_Skill_HasEmployeeSkillOrCourse";
        #endregion

        #region Tax

        /// <summary>
        /// 税阶下限重复
        /// </summary>
        public const string _TaxBand_BindMin_Repeat = "_TaxBand_BindMin_Repeat";

        #endregion


        #region AccountSet
        /// <summary>
        /// 帐套参数名称不可为空
        /// </summary>
        public const string _AccountSetParaName_IsNull = "_AccountSetParaName_IsNull";
        /// <summary>
        /// 绑定项不可为空
        /// </summary>
        public const string _AccountSetParaName_BindItem_IsNull = "_AccountSetParaName_BindItem_IsNull";
        /// <summary>
        /// 存在重复的帐套参数名称
        /// </summary>
        public const string _AccountSetParaName_Repeat = "_AccountSetParaName_Repeat";
        /// <summary>
        /// 绑定项不可为无
        /// </summary>
        public const string _AccountSet_BindItem_IsNull = "_AccountSet_BindItem_IsNull";
        /// <summary>
        /// 帐套参数不存在
        /// </summary>
        public const string _AccountSetPara_IsNotExist = "_AccountSetPara_IsNotExist";
        /// <summary>
        /// 操作失败，帐套参数已被某个帐套项使用
        /// </summary>
        public const string _AccountSetParaName_HasUsed = "_AccountSetParaName_HasUsed";
        /// <summary>
        /// 帐套名称不可为空
        /// </summary>
        public const string _AccountSetName_IsNull = "_AccountSetName_IsNull";
        /// <summary>
        /// 存在重复的帐套名称
        /// </summary>
        public const string _AccountSetName_Repeat = "_AccountSetName_Repeat";
        /// <summary>
        /// 帐套参数没有实例化
        /// </summary>
        public const string _AccountSetPara_IsNull = "_AccountSetPara_IsNull";
        /// <summary>
        /// 计算公式不可为空
        /// </summary>
        public const string _AccountSet_CalculateFormula_IsNull = "_AccountSet_CalculateFormula_IsNull";
        /// <summary>
        /// 帐套不存在
        /// </summary>
        public const string _AccountSet_IsNotExist = "_AccountSet_IsNotExist";
        /// <summary>
        /// 操作失败，该帐套已被使用
        /// </summary>
        public const string _AccountSet_EmployeeAccountSet_HasUsed = "_AccountSet_EmployeeAccountSet_HasUsed";
        /// <summary>
        /// 帐套参数的字段属性没有实例化
        /// </summary>
        public const string _AccountSetPara_FieldAttribute_IsNull = "_AccountSetPara_FieldAttribute_IsNull";
        /// <summary>
        /// 帐套中使用了重复的帐套参数
        /// </summary>
        public const string _AccountSet_UseRepeatPara = "_AccountSet_UseRepeatPara";

        #endregion

        #region EmployeeAccountSet

        /// <summary>
        /// 员工帐套不能为空
        /// </summary>
        public const string _EmployeeAccountSet_AccountSet_IsNull = "_EmployeeAccountSet_AccountSet_IsNull";
        /// <summary>
        /// 后台账号不能为空
        /// </summary>
        public const string _EmployeeAccountSet_BackAccountsName_IsNull = "_EmployeeAccountSet_BackAccountsName_IsNull";

        /// <summary>
        /// 员工编号不能为空
        /// </summary>
        public const string _EmployeeAccountSet_EmployeeID_IsNull = "_EmployeeAccountSet_EmployeeID_IsNull";
        /// <summary>
        /// 该员工不存在帐套
        /// </summary>
        public const string _EmployeeAccountSet_EmployeeAccountSet_NotExist =
            "_EmployeeAccountSet_EmployeeAccountSet_NotExist";
        /// <summary>
        /// 该帐套不存在
        /// </summary>
        public const string _EmployeeAccountSet_AccountSet_NotExist = "_EmployeeAccountSet_AccountSet_NotExist";

        /// <summary>
        /// 该薪水记录不存在
        /// </summary>
        public const string _Employee_Salary_NotExist = "_Employee_Salary_NotExist";

        /// <summary>
        /// 该薪水记录已封帐
        /// </summary>
        public const string _Employee_Salary_Closed = "_Employee_Salary_Closed";

        /// <summary>
        /// 该薪水记录还没有封帐
        /// </summary>
        public const string _Employee_Salary_Not_Closed = "_Employee_Salary_Not_Closed";

        /// <summary>
        /// 该员工此月工资记录已存在
        /// </summary>
        public const string _Employee_Salary_Exist = "_Employee_Salary_Exist";

        #endregion

        #region 导入Excel

        /// <summary>
        /// 导入失败
        /// </summary>
        public const string _Import_Failed = "_Import_Failed";
        /// <summary>
        /// 上传失败
        /// </summary>
        public const string _Upload_Failed = "_Upload_Failed";

        /// <summary>
        /// 确保一个工作表
        /// </summary>
        public const string _Sheet_Count_NotOne = "_Sheet_Count_NotOne";

        /// <summary>
        /// 没有“姓名”列
        /// </summary>
        public const string _WithOut_EmployeeName = "_WithOut_EmployeeName";
        #endregion

        #region CompanyRegulations

        /// <summary>
        /// 公司规章制度标题不能为空
        /// </summary>
        public const string _CompanyRegulations_Title_Null = "_CompanyRegulations_Title_Null";

        /// <summary>
        /// 公司规章制度附件标题不能为空
        /// </summary>
        public const string _CompanyReguAppendix_FileName_Null = "_CompanyReguAppendix_FileName_Null";

        /// <summary>
        /// 公司规章制度附件路径不能为空
        /// </summary>
        public const string _CompanyReguAppendix_Directory_Null = "_CompanyReguAppendix_Directory_Null";
        #endregion

        #region FeedBackPaper 反馈表

        /// <summary>
        /// 该反馈表不存在
        /// </summary>
        public const string _FeedBackPaper_Not_Exist = "_FeedBackPaper_Not_Exist";

        /// <summary>
        /// 该反馈表名称重复
        /// </summary>
        public const string _FeedBackPaper_Name_Repeat = "_FeedBackPaper_Name_Repeat";

        #endregion
    }
}
