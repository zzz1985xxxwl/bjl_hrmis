//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ConstParameters.cs
// 创建者: 倪豪
// 创建日期: 2008-06-16
// 概述: 用于代替HttpRequireString的硬编码，构建一个类处理这些变量
// ----------------------------------------------------------------

namespace SEP.Performance
{
    /// <summary>
    /// Session标识符
    /// </summary>
    public class SessionKeys
    {
        /// <summary>
        /// 记录登陆信息
        /// </summary>
        public const string LOGININFO = "LoginInfo";

        /// <summary>
        /// 记录权限树选中的节点
        /// </summary>
        public const string SELECTEDAUTHTREEINDEX = "SelectedIndex";

        /// <summary>
        /// 记录权限树选中的子节点名称
        /// </summary>
        public const string SELECTEDNODENAME = "selectedNodeName";

        /// <summary>
        /// 记录拷贝的考评表
        /// </summary>
        public const string SESSIONCOPYPAPER = "SessionCopyPaper";
        /// <summary>
        /// 当前系统
        /// </summary>
        public const string CURRENTSYSTEM = "CurrentSystem";

        #region
        //public const string SEPAUTHTREE = "SEP_AuthTree";
        ///// <summary>
        ///// Session中记录当前的员工登录号
        ///// </summary>
        //public const string EMPLOYEEID = "EmployeeID";

        ///// <summary>
        ///// Session中记录当前的员工姓名
        ///// </summary>
        //public const string EMPLOYEENAME = "EmployeeName";

        ///// <summary>
        ///// Session中记录当前的员工的部门编号
        ///// </summary>
        //public const string DEPARTMENTID = "DepartmentID";

        ///// <summary>
        ///// Session中记录当前的员工的部门名称
        ///// </summary>
        //public const string DEPARTMENTNAME = "DepartmentName";
        ///// <summary>
        ///// Session中记录当前的员工登录号
        ///// </summary>
        //public const string ACCOUNTSID = "AccountsID";
        ///// <summary>
        ///// Session中记录当前的员工登录号
        ///// </summary>
        //public const string ACCOUNTSNAME = "AccountsName";
        ///// <summary>
        ///// Session中记录当前的员工登录号
        ///// </summary>
        //public const string ACCOUNTSAUTHS = "AccountsAuths";
        ///// <summary>
        ///// Session中记录当前员工的数据库中保存的UsbKey
        ///// </summary>
        //public const string USBKEY = "UsbKey";
        ///// <summary>
        ///// Session中记录当前员工本地所插U盘的UsbKey
        ///// </summary>
        //public const string USBKEYLOCAL = "UsbKeyLocal";
        #endregion
        #region 考勤相关
        public const string InAndOutStatisticsRecordDataTable = "_InAndOutStatisticsRecordDataTable";
        public const string PersionInAndOutDataTable = "_PersionInAndOutDataTable";
        #endregion
        #region 工资相关
        public const string AverageStatisticsBarChartFileNameAndExp = "_AverageStatisticsBarChartFileNameAndExp";
        public const string TimeSpanStatisticsGroupByDeptLineChartFileNameAndExp = "_TimeSpanStatisticsGroupByDeptLineChartFileNameAndExp";
        public const string DepartmentStatisticsBarChartFileNameAndExp = "_DepartmentStatisticsBarChartFileNameAndExp";
        public const string PositionStatisticsBarChartFileNameAndExp = "_PositionStatisticsBarChartFileNameAndExp";

        public const string TimeSpanStatisticsGroupByParaLineChartFileNameAndExp =
            "_TimeSpanStatisticsGroupByParaLineChartFileNameAndExp";

        public const string gvDepartmentStatisticsTableSource = "_gvDepartmentStatisticsTableSource";
        public const string gvPositionStatisticsTableSource = "_gvPositionStatisticsTableSource";
        public const string gvTimeSpanStatisticsGroupByParaSource = "_gvTimeSpanStatisticsGroupByParaSource";
        public const string gvAverageStatisticsTableSource = "_gvAverageStatisticsTableSource";
        public const string gvTimeSpanStatisticsGroupByDeptSource = "_gvTimeSpanStatisticsGroupByDeptSource";
        #endregion
        #region 报销相关
        public const string gvDepartmentStatisticsTableSourceForReimburse =
            "_gvDepartmentStatisticsTableSourceForReimburse";
        public const string DepartmentReimburseStatisticsBarChart =
           "_DepartmentReimburseStatisticsBarChart";
        public const string EmployeeReimburseStatisticsBarChart =
         "_EmployeeReimburseStatisticsBarChart";

        #endregion
        #region 员工统计
        public const string gvEmployeeStatisticsTableSource = "_gvEmployeeStatisticsTableSource";

        public const string EmployeeStaticsComeAndLeaveBarChart = "_EmployeeStaticsComeAndLeaveBarChart";
        public const string EmployeeStaticsComeAndLeaveTable = "_EmployeeStaticsComeAndLeaveTable";
        public const string EmployeeStaticsGenderPieChart = "_EmployeeStaticsGenderPieChart";
        public const string EmployeeStaticsEduBgPieChart = "_EmployeeStaticsEduBgPieChart";
        public const string EmployeeStaticsLeaveRateLineChart = "_EmployeeStaticsLeaveRateLineChart";
        public const string EmployeeStaticsOtherStatisticsData = "_EmployeeStaticsOtherStatisticsData";
        public const string EmployeeStaticsPositionGradeTowerTable = "_EmployeeStaticsPositionGradeTowerTable";
        public const string EmployeeStaticsWorkAgePieChart = "_EmployeeStaticsWorkAgePieChart";
        public const string EmployeeStaticsWorkTypePieChart = "_EmployeeStaticsWorkTypePieChart";
        public const string EmployeeStaticsAgePieChart = "_EmployeeStaticsAgePieChart";
        #endregion
    }

    /// <summary>
    /// QueryString标识符
    /// </summary>
    public static class QueryStringKeys
    {

    }


    public class ConstParameters
    {

        /// <summary>
        /// HrmisSystem
        /// </summary>
        public const string HRMISSYSTEM = "HrmisSystem";
        /// <summary>
        /// CrmSystem
        /// </summary>
        public const string CRMSYSTEM = "CrmSystem";
        /// <summary>
        /// SepSystem
        /// </summary>
        public const string SEPSYSTEM = "SepSystem";
        /// <summary>
        /// EShoppingSystem
        /// </summary>
        public const string ESHOPPINGSYSTEM = "EShoppingSystem";

        public const string EmployeeVacationOperation = "EmployeeVacationOperation";
        public const string VacationID = "VacationID";
        public const string ContractId = "ContractId";
        //public const string SalaryTypeID = "salaryTypeID";
        public const string EmployeeId = "employeeID";
        public const string AssessActivityID = "assessActivityID";
        //public const string VacationID = "VacationId";
        public const string EmployeeName = "EmployeeName";
        public const string GoalID = "GoalID";
        public const string AccountBackId = "AccountBackId";
        //public const string ContractId = "ContractId";
        public const string ItemID = "ItemID";
        public const string CurrentDay = "CurrentDay";
        //public const string LeaveRequestID = "LeaveRequestID";

        public const string DepartmentID = "DepartmentID";
        public const string SearchFrom = "SearchFrom";
        public const string SearchTo = "SearchTo";

        public const string PlanDutyID = "PlanDutyID";
        #region 文件路径

        public const string UploadFile = "../UploadFile";
        public const string FileCargo = "../FileCargo";
        public const string Template_AssessExportDoc = "../Template/AssessExport.doc";
        public const string Template_PositionInfoDoc = "../Template/PositionInfo.doc";
        public const string Template_EmployeeInfoDoc = "../Template/EmployeeInfo.doc";
        public const string Template_NormalForContractDoc = "../Template/合同期满评估表.doc";
        public const string Template_EmployeeNormalSummaryDoc = "../Template/员工考评个人工作总结表.docx";
        public const string Template_EmployeeAnnualSummaryDoc = "../Template/员工年终绩效考评个人工作总结表.docx";
        public const string Template_AnnualDoc = "../Template/年度员工绩效考核统计表.docx";
        public const string Template_FeedBackReportDoc = "../Template/培训课程反馈结果表.doc";
        public const string Template_AnnualAssessXls = "../Template/绩效评估结果.xls";

        #endregion
    }
}
