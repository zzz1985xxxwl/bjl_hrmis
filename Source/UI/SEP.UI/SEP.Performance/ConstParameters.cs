//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: ConstParameters.cs
// ������: �ߺ�
// ��������: 2008-06-16
// ����: ���ڴ���HttpRequireString��Ӳ���룬����һ���ദ����Щ����
// ----------------------------------------------------------------

namespace SEP.Performance
{
    /// <summary>
    /// Session��ʶ��
    /// </summary>
    public class SessionKeys
    {
        /// <summary>
        /// ��¼��½��Ϣ
        /// </summary>
        public const string LOGININFO = "LoginInfo";

        /// <summary>
        /// ��¼Ȩ����ѡ�еĽڵ�
        /// </summary>
        public const string SELECTEDAUTHTREEINDEX = "SelectedIndex";

        /// <summary>
        /// ��¼Ȩ����ѡ�е��ӽڵ�����
        /// </summary>
        public const string SELECTEDNODENAME = "selectedNodeName";

        /// <summary>
        /// ��¼�����Ŀ�����
        /// </summary>
        public const string SESSIONCOPYPAPER = "SessionCopyPaper";
        /// <summary>
        /// ��ǰϵͳ
        /// </summary>
        public const string CURRENTSYSTEM = "CurrentSystem";

        #region
        //public const string SEPAUTHTREE = "SEP_AuthTree";
        ///// <summary>
        ///// Session�м�¼��ǰ��Ա����¼��
        ///// </summary>
        //public const string EMPLOYEEID = "EmployeeID";

        ///// <summary>
        ///// Session�м�¼��ǰ��Ա������
        ///// </summary>
        //public const string EMPLOYEENAME = "EmployeeName";

        ///// <summary>
        ///// Session�м�¼��ǰ��Ա���Ĳ��ű��
        ///// </summary>
        //public const string DEPARTMENTID = "DepartmentID";

        ///// <summary>
        ///// Session�м�¼��ǰ��Ա���Ĳ�������
        ///// </summary>
        //public const string DEPARTMENTNAME = "DepartmentName";
        ///// <summary>
        ///// Session�м�¼��ǰ��Ա����¼��
        ///// </summary>
        //public const string ACCOUNTSID = "AccountsID";
        ///// <summary>
        ///// Session�м�¼��ǰ��Ա����¼��
        ///// </summary>
        //public const string ACCOUNTSNAME = "AccountsName";
        ///// <summary>
        ///// Session�м�¼��ǰ��Ա����¼��
        ///// </summary>
        //public const string ACCOUNTSAUTHS = "AccountsAuths";
        ///// <summary>
        ///// Session�м�¼��ǰԱ�������ݿ��б����UsbKey
        ///// </summary>
        //public const string USBKEY = "UsbKey";
        ///// <summary>
        ///// Session�м�¼��ǰԱ����������U�̵�UsbKey
        ///// </summary>
        //public const string USBKEYLOCAL = "UsbKeyLocal";
        #endregion
        #region �������
        public const string InAndOutStatisticsRecordDataTable = "_InAndOutStatisticsRecordDataTable";
        public const string PersionInAndOutDataTable = "_PersionInAndOutDataTable";
        #endregion
        #region �������
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
        #region �������
        public const string gvDepartmentStatisticsTableSourceForReimburse =
            "_gvDepartmentStatisticsTableSourceForReimburse";
        public const string DepartmentReimburseStatisticsBarChart =
           "_DepartmentReimburseStatisticsBarChart";
        public const string EmployeeReimburseStatisticsBarChart =
         "_EmployeeReimburseStatisticsBarChart";

        #endregion
        #region Ա��ͳ��
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
    /// QueryString��ʶ��
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
        #region �ļ�·��

        public const string UploadFile = "../UploadFile";
        public const string FileCargo = "../FileCargo";
        public const string Template_AssessExportDoc = "../Template/AssessExport.doc";
        public const string Template_PositionInfoDoc = "../Template/PositionInfo.doc";
        public const string Template_EmployeeInfoDoc = "../Template/EmployeeInfo.doc";
        public const string Template_NormalForContractDoc = "../Template/��ͬ����������.doc";
        public const string Template_EmployeeNormalSummaryDoc = "../Template/Ա���������˹����ܽ��.docx";
        public const string Template_EmployeeAnnualSummaryDoc = "../Template/Ա�����ռ�Ч�������˹����ܽ��.docx";
        public const string Template_AnnualDoc = "../Template/���Ա����Ч����ͳ�Ʊ�.docx";
        public const string Template_FeedBackReportDoc = "../Template/��ѵ�γ̷��������.doc";
        public const string Template_AnnualAssessXls = "../Template/��Ч�������.xls";

        #endregion
    }
}
