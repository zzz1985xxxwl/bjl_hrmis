//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ErrorType.cs
// Creater:  Xue.wenlong
// Date:  2009-09-28
// Resume:1门禁卡号,2排班规则,3请假流程，4外出申请流程,5加班申请流程,6绩效考核流程,7人事负责人,8报销流程,9培训申请流程
// ----------------------------------------------------------------

using System.Collections.Generic;
using ShiXin.Security;

namespace SEP.HRMIS.Model.SystemError
{
    /// <summary>
    /// </summary>
    public class ErrorType
    {
        private int _ID;
        private string _Name;
        private string _EditPageUrl;

        /// <summary>
        /// </summary>
        public ErrorType(int id, string name, string url)
        {
            _ID = id;
            _Name = name;
            _EditPageUrl = url;
        }
        public static ErrorType All =
           new ErrorType(-1, "全部", "");
        public static ErrorType DoorCardNoError =
            new ErrorType(1, "门禁卡号",
                          string.Format(
                              "../../HRMIS/EmployeePages/EmployeeUpdate.aspx?EmployeeVacationOperation={0}&employeeID=",
                              SecurityUtil.DECEncrypt(2.ToString())));

        public static ErrorType DutyCalssError =
            new ErrorType(2, "排班规则","../../HRMIS/AttendancePages/AddPlanDuty.aspx?employeeID=");

        public static ErrorType DiyLeaveRequestError =
            new ErrorType(3, "请假流程",
                          string.Format(
                              "../../HRMIS/EmployeePages/EmployeeUpdate.aspx?EmployeeVacationOperation={0}&employeeID=",
                              SecurityUtil.DECEncrypt(2.ToString())));

        public static ErrorType DiyOutError =
            new ErrorType(4, "外出申请流程",
                          string.Format(
                              "../../HRMIS/EmployeePages/EmployeeUpdate.aspx?EmployeeVacationOperation={0}&employeeID=",
                              SecurityUtil.DECEncrypt(2.ToString())));

        public static ErrorType DiyOverWorkError =
            new ErrorType(5, "加班申请流程",
                          string.Format(
                              "../../HRMIS/EmployeePages/EmployeeUpdate.aspx?EmployeeVacationOperation={0}&employeeID=",
                              SecurityUtil.DECEncrypt(2.ToString())));

        public static ErrorType DiyAssessError =
            new ErrorType(6, "绩效考核流程",
                          string.Format(
                              "../../HRMIS/EmployeePages/EmployeeUpdate.aspx?EmployeeVacationOperation={0}&employeeID=",
                              SecurityUtil.DECEncrypt(2.ToString())));

        public static ErrorType DiyHRPrincipalError =
            new ErrorType(7, "人事负责人",
                          string.Format(
                              "../../HRMIS/EmployeePages/EmployeeUpdate.aspx?EmployeeVacationOperation={0}&employeeID=",
                              SecurityUtil.DECEncrypt(2.ToString())));

        //public static ErrorType DiyReimburseError =
        //    new ErrorType(8, "报销流程",
        //                  string.Format(
        //                      "../../HRMIS/EmployeePages/EmployeeUpdate.aspx?EmployeeVacationOperation={0}&employeeID=",
        //                      SecurityUtil.DECEncrypt(2.ToString())));

        public static ErrorType DiyTraineeApplicationError =
            new ErrorType(9, "培训申请流程",
                          string.Format(
                              "../../HRMIS/EmployeePages/EmployeeUpdate.aspx?EmployeeVacationOperation={0}&employeeID=",
                              SecurityUtil.DECEncrypt(2.ToString())));
        public static ErrorType AttendanceError = new ErrorType(10, "考勤数据", "../../HRMIS/AttendancePages/InAndOutDetailListView.aspx?");

        public static ErrorType EmployeeContractError =
            new ErrorType(11, "员工合同", "../../HRMIS/ContractPages/EmployeeContractList.aspx?");

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// 更新的url，会与markid结合，匹配出实际的链接地址，以供更新异常
        /// </summary>
        public string EditPageUrl
        {
            get { return _EditPageUrl; }
            set { _EditPageUrl = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static ErrorType GetErrorTypeByID(int id)
        {
            switch (id)
            {
                case -1:
                    return All;
                case 1:
                    return DoorCardNoError;
                case 2:
                    return DutyCalssError;
                case 3:
                    return DiyLeaveRequestError;
                case 4:
                    return DiyOutError;
                case 5:
                    return DiyOverWorkError;
                case 6:
                    return DiyAssessError;
                case 7:
                    return DiyHRPrincipalError;
                //case 8:
                //    return DiyReimburseError;
                case 9:
                    return DiyTraineeApplicationError;
                case 10:
                    return AttendanceError;
                default:
                    return null;
            }
        }

        ///<summary>
        ///</summary>
        public static List<ErrorType> GetDiyErrorType
        {
            get
            {
                List<ErrorType> errorTypeList = new List<ErrorType>();
                errorTypeList.Add(DiyAssessError);
                errorTypeList.Add(DiyHRPrincipalError);
                errorTypeList.Add(DiyLeaveRequestError);
                errorTypeList.Add(DiyOutError);
                errorTypeList.Add(DiyOverWorkError);
                //errorTypeList.Add(DiyReimburseError);
                errorTypeList.Add(DiyTraineeApplicationError);
                return errorTypeList;
            }
        }
    }
}