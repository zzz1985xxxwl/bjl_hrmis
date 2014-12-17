using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Adjusts;
using SEP.Model.Departments;
using SEP.Presenter.Core;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.Model.Positions;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation
{
    public interface IWorkInfoView
    {
        /// <summary>
        /// 职位
        /// </summary>
        string Position { set;}
        /// <summary>
        /// 门禁卡卡号
        /// </summary>
        string DoorCardNO { get;set;}
        /// <summary>
        /// 社会工龄
        /// </summary>
        string SocietyWorkAge { get;set;}
        /// <summary>
        /// 社会工龄如果输入类型不对，报错信息
        /// </summary>
        string SocietyWorkAgeMessage { get;set;}
        /// <summary>
        /// 聘用岗位
        /// </summary>
        string ContractPosition { get; set;}
        /// <summary>
        /// 所属公司
        /// </summary>
        string Company { get;set;}
        string CompanyMessage { get; set;}
        /// <summary>
        /// 部门
        /// </summary>
        string Department { set;}
        int DepartmentID { get; set;}
        /// <summary>
        /// 部门负责人
        /// </summary>
        string DepartmentLeader { get;set; }
        /// <summary>
        /// 入职时间
        /// </summary>
        string ComeDate { get; set;}
        string ComeDateMessage { get; set;}
        /// <summary>
        /// 司龄
        /// </summary>
        string WorkAge{ get; set;}
        /// <summary>
        /// 工作职责
        /// </summary>
        string Responsibility { get; set;}
        /// <summary>
        /// 试用期到期日
        /// </summary>
        string ProbationEndDate { get; set;}
        string ProbationEndDateMessage { get; set;}

        /// <summary>
        /// 试用期起始日
        /// </summary>
        string ProbationStartDate { get; set;}
        string ProbationStartDateMessage { get; set;}
        /// <summary>
        /// 合同起始日
        /// </summary>
        string ContractStartDate { get; set;}
        bool ContractStartDateEnable { get; set;}
        /// <summary>
        /// 新合同起始日
        /// </summary>
        string NewContractStartDate { get; set;}
        bool NewContractStartDateEnable { get; set;}
        /// <summary>
        /// 合同到期日
        /// </summary>
        string ContractEndDate { get; set;}
        bool ContractEndDateEnable { get; set;}
        /// <summary>
        /// 合同信息的数据源
        /// </summary>
        List<Contract> EmployeeContract { get; set;}
        /// <summary>
        /// 合同信息的Session，用于合同信息对象
        /// </summary>
        List<Contract> EmployeeContractDataSource { get; set;}
        /// <summary>
        /// 所属公司的数据源
        /// </summary>
        List<Department> CompanySource { get;set;}
        /// <summary>
        /// 工作地点
        /// </summary>
        string WorkPlace{ get; set;}

        /// <summary>
        /// 请假流程
        /// </summary>
        List<DiyProcess> LeaveRequestProcess { get; set;}
        int leaveProcessId { get; set;}
        string LeaveProcessString { set;}

        /// <summary>
        /// 申请外出流程
        /// </summary>
        List<DiyProcess> OutProcess { get; set;}
        int outProcessId { get; set;}
        string OutProcessString { set;}

        /// <summary>
        /// 申请加班流程
        /// </summary>
        List<DiyProcess> OverTimeProcess { get; set;}
        int OverTimeProcessId { get; set;}
        string OverTimeString { set;}

        /// <summary>
        /// 考评流程
        /// </summary>
        List<DiyProcess> AssessProcess { get; set;}
        int AssessProcessId { get; set;}
        string AssessProcessString { set;}

        /// <summary>
        /// 人事负责人
        /// </summary>
        List<DiyProcess> HRPrincipalProcess { get; set;}
        int HRPrincipalProcessId { get; set;}
        string HRPrincipalProcessString { set;}

        ///// <summary>
        ///// 报销流程
        ///// </summary>
        //List<DiyProcess> ReimburseProcess { get; set;}
        //int ReimburseProcessId { get; set;}
        //string ReimburseProcessString { set;}
        /// <summary>
        /// 培训申请流程
        /// </summary>
        List<DiyProcess> TraineeApplicationProcess{ get; set;}
        int TraineeApplicationProcessId { get; set;}
        string TraineeApplicationString { set;}

        /// <summary>
        /// 自定义流程改变时显示其代码
        /// </summary>
        int AccountIdForProcess { get; set;}

        event DelegateNoParameter FatherSelectChangeEvent;
        event DelegateReturnString ContractDownLoadEvent;
        event DelegateReturnBool IsDownLoadEnable;

        /// <summary>
        /// 自定义流程选择事件
        /// </summary>
        event DelegateID DiyProcessSelectChangeEvent;
        bool ContractManageVisible { set;}

        /// <summary>
        /// 职位等级
        /// </summary>
        List<PositionGrade> PositionGradeSource { set;}

        string PositionGradeId { get;set;}

        /// <summary>
        /// 调休规则数据源
        /// </summary>
        List<AdjustRule> AdjustRuleSource { set;}
        int AdjustRuleID{ get; set;}

        List<AssessTemplateItem> AssessActivityItemList { get; set;}

        List<PrincipalShip> PrincipalShipSource { set;}
        string PrincipalShipId { get;set;}
    }
}