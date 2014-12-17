//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: Employee.cs
// 创建者: 杨俞彬
// 创建日期: 2008-05-20
// 概述: 员工
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model.Adjusts;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 员工信息
    /// </summary>
    [Serializable]
    public class Employee : IComparable<Employee>
    {
        //员工信息
        private Account _Account;
        private EmployeeTypeEnum _EmployeeType;
        private EmployeeDetails _EmployeeDetails;
        //合同信息
        private List<Contract> _EmployeeContracts;
        //报销信息
        private List<Reimburse> _Reimburses;
        //培训申请信息
        private List<TraineeApplication> _TraineeApplicationList;

        //考勤信息
        private EmployeeAttendance.AttendanceStatistics.EmployeeAttendance _EmployeeAttendance;

        private List<EmployeeSkill> _EmployeeSkills;
        //邮件帐号
        private List<MailAccount> _TheMailAccounts = new List<MailAccount>();

        //社会工龄与年假列表
        private SocWorkAgeAndVacationList _SocWorkAgeAndVacationList;

        //员工福利
        private EmployeeWelfare _EmployeeWelfare;
        private List<EmployeeWelfareHistory> _EmployeeWelfareHistory;
        //对象状态
        private bool _IsObjectStatus;

        //自定义列表
        private List<DiyProcess> _DiyProcessList;

        //调休规则
        private AdjustRule _AdjustRule;

        /// <summary>
        /// 是否接收短信
        /// </summary>
        private bool _IfReceiveMessage;

        /// <summary>
        /// 员工构造函数
        /// </summary>
        public Employee()
        {
        }

        /// <summary>
        /// 员工构造函数
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="type"></param>
        public Employee(int accountID, EmployeeTypeEnum type)
        {
            _Account = new Account(accountID, "", "");
            _EmployeeType = type;
        }

        /// <summary>
        /// 员工构造函数
        /// </summary>
        /// <param name="account"></param>
        /// <param name="email"></param>
        /// <param name="email2"></param>
        /// <param name="type"></param>
        /// <param name="position"></param>
        /// <param name="department"></param>
        public Employee(Account account, string email, string email2, EmployeeTypeEnum type,
                        Position position, Department department)
        {
            _Account = account;
            _Account.Email1 = email;
            _Account.Email2 = email2;
            _Account.Position = position;
            _Account.Dept = department;
            _EmployeeType = type;
        }

        #region 属性

        /// <summary>
        /// 帐号
        /// </summary>
        public Account Account
        {
            get { return _Account; }
            set { _Account = value; }
        }

        /// <summary>
        /// 社会工龄和年假信息列表
        /// </summary>
        public SocWorkAgeAndVacationList SocWorkAgeAndVacationList
        {
            get { return _SocWorkAgeAndVacationList; }
            set { _SocWorkAgeAndVacationList = value; }
        }

        /// <summary>
        /// 报销
        /// </summary>
        public List<Reimburse> Reimburses
        {
            get { return _Reimburses; }
            set { _Reimburses = value; }
        }

        /// <summary>
        /// 员工合同列表
        /// </summary>
        public List<Contract> EmployeeContracts
        {
            get { return _EmployeeContracts; }
            set { _EmployeeContracts = value; }
        }

        /// <summary>
        /// 员工类型
        /// </summary>
        public EmployeeTypeEnum EmployeeType
        {
            get { return _EmployeeType; }
            set { _EmployeeType = value; }
        }

        /// <summary>
        /// 员工详细信息
        /// </summary>
        public EmployeeDetails EmployeeDetails
        {
            get { return _EmployeeDetails; }
            set { _EmployeeDetails = value; }
        }

        /// <summary>
        /// 员工考勤
        /// </summary>
        public EmployeeAttendance.AttendanceStatistics.EmployeeAttendance EmployeeAttendance
        {
            get { return _EmployeeAttendance; }
            set { _EmployeeAttendance = value; }
        }

        /// <summary>
        /// 员工技能列表
        /// </summary>
        public List<EmployeeSkill> EmployeeSkills
        {
            get { return _EmployeeSkills; }
            set { _EmployeeSkills = value; }
        }

        /// <summary>
        /// 邮件帐号
        /// </summary>
        public List<MailAccount> TheMailAccounts
        {
            get { return _TheMailAccounts; }
            set { _TheMailAccounts = value; }
        }

        /// <summary>
        /// 对象的状态，不要在Dal以外的任何层次修改或访问
        /// </summary>
        public bool ObjectStatus
        {
            get { return _IsObjectStatus; }
            set { _IsObjectStatus = value; }
        }

        /// <summary>
        /// 员工福利
        /// </summary>
        public EmployeeWelfare EmployeeWelfare
        {
            get { return _EmployeeWelfare; }
            set { _EmployeeWelfare = value; }
        }

        /// <summary>
        /// 员工福利历史
        /// </summary>
        public List<EmployeeWelfareHistory> EmployeeWelfareHistory
        {
            get { return _EmployeeWelfareHistory; }
            set { _EmployeeWelfareHistory = value; }
        }

        /// <summary>
        /// 是否接收短信
        /// </summary>
        public bool IfReceiveMessage
        {
            get { return _IfReceiveMessage; }
            set { _IfReceiveMessage = value; }
        }

        /// <summary>
        /// 自定义流程
        /// </summary>
        public List<DiyProcess> DiyProcessList
        {
            get { return _DiyProcessList; }
            set { _DiyProcessList = value; }
        }

        /// <summary>
        /// 培训申请信息
        /// </summary>
        public List<TraineeApplication> TraineeApplicationList
        {
            get { return _TraineeApplicationList; }
            set { _TraineeApplicationList = value; }
        }

        /// <summary>
        /// 调休规则
        /// </summary>
        public AdjustRule AdjustRule
        {
            get { return _AdjustRule; }
            set { _AdjustRule = value; }
        }

        #endregion

        #region 方法

        //todo noted by wsl transfer waiting for modify
        /// <summary>
        /// 判断是否Employee相同
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(Employee obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.Account.Id == _Account.Id &&
                   Equals(obj.Account.Id, _Account.Id) &&
                   Equals(obj._EmployeeType, _EmployeeType) &&
                   Equals(obj._EmployeeDetails, _EmployeeDetails);
        }

        /// <summary>
        /// HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = _Account.Id;
                result = (result * 397) ^ _EmployeeType.GetHashCode();
                result = (result * 397) ^ (_Account != null ? _Account.GetHashCode() : 0);
                result = (result * 397) ^ (_EmployeeContracts != null ? _EmployeeContracts.GetHashCode() : 0);
                result = (result * 397) ^ (_EmployeeDetails != null ? _EmployeeDetails.GetHashCode() : 0);
                result = (result * 397) ^ _IsObjectStatus.GetHashCode();
                return result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isAddName"></param>
        /// <returns></returns>
        public string StatDayAttendance(bool isAddName)
        {
            StringBuilder theAttendance = new StringBuilder();
            if (isAddName)
            {
                theAttendance.Append(_Account.Name).Append("\t");
            }
            theAttendance.Append(_EmployeeAttendance.DayAttendanceWeek.Mon).Append("\t")
                .Append(_EmployeeAttendance.DayAttendanceWeek.Tues).Append("\t")
                .Append(_EmployeeAttendance.DayAttendanceWeek.Wedn).Append("\t")
                .Append(_EmployeeAttendance.DayAttendanceWeek.Thurs).Append("\t")
                .Append(_EmployeeAttendance.DayAttendanceWeek.Fri).Append("\t")
                .Append(_EmployeeAttendance.DayAttendanceWeek.Sat).Append("\t")
                .Append(_EmployeeAttendance.DayAttendanceWeek.Sun).Append("\t");
            return theAttendance.ToString();
        }

        /// <summary>
        /// 员工导出
        /// </summary>
        /// <returns></returns>
        public string StatEmployeeInfo()
        {
            string iDCardNo = string.Empty;
            string dueDate = string.Empty;
            string rDueDate = string.Empty;
            string rOrgnaization = string.Empty;
            string dimissionReason = string.Empty;
            string dimissionDate = string.Empty;
            string RPRAddress = string.Empty;
            string PRPPostCode = string.Empty;
            string PRPStreet = string.Empty;
            string PRPArea = string.Empty;
            string educationalBackgroundName = string.Empty;
            string educationSchool = string.Empty;
            string educationMajor = string.Empty;
            string foreignLanguageAbility = string.Empty;
            string certificates = string.Empty;
            string childName = string.Empty;
            string childBirthday = string.Empty;
            string strDate = string.Empty;
            string endDate = string.Empty;
            string newstrDate = string.Empty;
            string workPlace = string.Empty;
            string countryNationalityName = string.Empty;
            //将非空字段也加判断，以免代码修改
            string name = string.Empty;
            string gradeType = string.Empty;
            string iD = string.Empty;
            string genderName = string.Empty;
            string mobileNum = string.Empty;
            string companyName = string.Empty;
            string departmentName = string.Empty;
            string positionName = string.Empty;
            string positionGrad = string.Empty;
            string principalship = string.Empty;
            string politicalAffiliationName = string.Empty;
            string maritalStatusName = string.Empty;
            string familyAddress = string.Empty;
            string familyPhone = string.Empty;
            string postCode = string.Empty;
            string departmentLeaderName = string.Empty;
            string workTypeName = string.Empty;
            string comeDate = string.Empty;
            //string contractPosition = string.Empty;
            string workTitle = string.Empty;
            string email1 = string.Empty;
            string email2 = string.Empty;
            var gradesType = GradesType.GetAll();
            if (_EmployeeDetails.IDCard != null)
            {
                iDCardNo = _EmployeeDetails.IDCard.IDCardNo;
                dueDate = _EmployeeDetails.IDCard.DueDate.ToShortDateString();
            }

            if (_EmployeeDetails.ResidencePermits != null)
            {
                rDueDate = _EmployeeDetails.ResidencePermits.DueDate.ToShortDateString();
                rOrgnaization = _EmployeeDetails.ResidencePermits.Orgnaization;
            }

            if (_EmployeeDetails.RegisteredPermanentResidence != null)
            {
                PRPStreet = _EmployeeDetails.RegisteredPermanentResidence.PRPStreet;
                PRPPostCode = _EmployeeDetails.RegisteredPermanentResidence.PRPPostCode;
                RPRAddress = _EmployeeDetails.RegisteredPermanentResidence.RPRAddress;
                PRPArea = _EmployeeDetails.RegisteredPermanentResidence.PRPArea;
            }

            if (_EmployeeDetails.Work != null && _EmployeeDetails.Work.DimissionInfo != null)
            {
                dimissionReason = _EmployeeDetails.Work.DimissionInfo.DimissionReason;
                dimissionDate = _EmployeeDetails.Work.DimissionInfo.DimissionDate.ToShortDateString();
            }

            if (_EmployeeDetails.Education != null)
            {
                educationSchool = _EmployeeDetails.Education.School;
                educationMajor = _EmployeeDetails.Education.Major;
                foreignLanguageAbility = _EmployeeDetails.Education.ForeignLanguageAbility;
                if (_EmployeeDetails.Education.EducationalBackground != null)
                {
                    educationalBackgroundName = _EmployeeDetails.Education.EducationalBackground.Name;
                }
            }

            if (_EmployeeDetails.Family != null)
            {
                childName = _EmployeeDetails.Family.ChildName;
                childBirthday = _EmployeeDetails.Family.ChildBirthday == null
                                    ? string.Empty
                                    : Convert.ToDateTime(EmployeeDetails.Family.ChildBirthday).ToShortDateString();
            }
            if (_EmployeeContracts.Count != 0)
            {
                DateTime strDateTemp = new DateTime();
                DateTime endDateTemp = new DateTime();
                DateTime newstrDateTemp = new DateTime();
                int icount = _EmployeeContracts.Count;
                if (icount > 0)
                {
                    strDateTemp = _EmployeeContracts[0].StartDate;
                    endDateTemp = _EmployeeContracts[0].EndDate;
                    //newstrDate = strDate;

                    foreach (Contract con in _EmployeeContracts)
                    {
                        if (con != null && DateTime.Compare(strDateTemp, con.StartDate) > 0)
                        {
                            strDateTemp = con.StartDate;
                        }
                        if (con != null && DateTime.Compare(endDateTemp, con.EndDate) < 0)
                        {
                            endDateTemp = con.EndDate;
                        }
                        if (con != null && DateTime.Compare(newstrDateTemp, con.StartDate) < 0)
                        {
                            newstrDateTemp = con.StartDate;
                        }
                    }
                }
                strDate = strDateTemp.ToShortDateString();
                endDate = endDateTemp.ToShortDateString();
                newstrDate = newstrDateTemp.ToShortDateString();
            }

            if (_Account != null)
            {
                name = _Account.Name;
                iD = _Account.Id.ToString();
                mobileNum = _Account.MobileNum;
                email1 = _Account.Email1;
                email2 = _Account.Email2;
                if (_Account.Dept != null)
                {
                    departmentName = _Account.Dept.DepartmentName;
                    if (_Account.Dept.DepartmentLeader != null)
                    {
                        departmentLeaderName = _Account.Dept.DepartmentLeader.Name;
                    }
                }
                if (_Account.Position != null)
                {
                    positionName = _Account.Position.Name;
                    if (_Account.Position.Grade != null)
                    {
                        positionGrad = _Account.Position.Grade.Name;
                    }
                }
                foreach (var type in gradesType)
                {
                    if(type.ID==_Account.GradesID)
                    {
                        gradeType = type.Name;
                        break;
                    }
                }
                
            }
            if (_EmployeeDetails.Gender != null)
            {
                genderName = _EmployeeDetails.Gender.Name;
            }
            if (_EmployeeDetails.Work != null)
            {
                if (_EmployeeDetails.Work.Company != null)
                {
                    companyName = _EmployeeDetails.Work.Company.Name;
                }
                if (_EmployeeDetails.Work.WorkType != null)
                {
                    workTypeName = _EmployeeDetails.Work.WorkType.Name;
                }
                comeDate = _EmployeeDetails.Work.ComeDate.ToShortDateString();
                if (_EmployeeDetails.Work.Principalship != null)
                {
                    principalship = _EmployeeDetails.Work.Principalship.Name;
                }

                //contractPosition = _EmployeeDetails.Work.ContractPosition;
                workTitle = _EmployeeDetails.Work.Title;
                workPlace = _EmployeeDetails.Work.WorkPlace;
            }
            if (_EmployeeDetails.PoliticalAffiliation != null)
            {
                politicalAffiliationName = _EmployeeDetails.PoliticalAffiliation.Name;
            }
            if (_EmployeeDetails.MaritalStatus != null)
            {
                maritalStatusName = _EmployeeDetails.MaritalStatus.Name;
            }
            if (_EmployeeDetails.Family != null)
            {
                familyAddress = _EmployeeDetails.Family.FamilyAddress;
                familyPhone = _EmployeeDetails.Family.FamilyPhone;
                postCode = _EmployeeDetails.Family.PostCode;
            }
            if (_EmployeeDetails.CountryNationality != null)
            {
                countryNationalityName = _EmployeeDetails.CountryNationality.Name;
            }
            StringBuilder theEmployeeInfo = new StringBuilder();
            theEmployeeInfo.Append(name).Append("\t")
                .Append(iD).Append("\t")
                .Append(_EmployeeDetails.EnglishName).Append("\t")
                .Append(genderName).Append("\t")
                .Append("'" + mobileNum.Replace("\n", @"\n")).Append("\t")
                .Append(companyName).Append("\t")
                .Append(departmentName).Append("\t")
                .Append(positionName).Append("\t")
                .Append(principalship).Append("\t")
                .Append(positionGrad).Append("\t")
                .Append(gradeType).Append("\t")
                .Append("'" + iDCardNo).Append("\t")
                .Append(dueDate).Append("\t")
                .Append(_EmployeeDetails.Birthday.ToShortDateString()).Append("\t")
                .Append(_EmployeeDetails.Nationality).Append("\t")
                .Append(politicalAffiliationName).Append("\t")
                .Append(educationalBackgroundName).Append("\t")
                .Append(educationSchool).Append("\t")
                .Append(educationMajor).Append("\t")
                .Append(maritalStatusName).Append("\t")
                .Append(RPRAddress).Append("\t")
                .Append(PRPPostCode).Append("\t")
                .Append(PRPStreet).Append("\t")
                .Append(PRPArea).Append("\t")
                .Append(familyAddress).Append("\t")
                .Append(familyPhone).Append("\t")
                .Append(postCode).Append("\t")
                .Append(departmentLeaderName).Append("\t")
                .Append(workTypeName).Append("\t")
                .Append(rDueDate).Append("\t")
                .Append(rOrgnaization).Append("\t")
                .Append(comeDate).Append("\t")
                .Append(_EmployeeDetails.ProbationStartTime.ToShortDateString()).Append("\t")
                .Append(_EmployeeDetails.ProbationTime.ToShortDateString()).Append("\t")
                .Append(strDate).Append("\t")
                .Append(newstrDate).Append("\t")
                .Append(endDate).Append("\t")
                //.Append(contractPosition).Append("\t")
                .Append(dimissionReason).Append("\t")
                .Append(dimissionDate).Append("\t")
                .Append("").Append("\t")
                .Append(childName).Append("\t")
                .Append(childBirthday).Append("\t")
                .Append(_EmployeeDetails.Height).Append("\t")
                .Append(_EmployeeDetails.Weight).Append("\t")
                .Append(_EmployeeDetails.NativePlace).Append("\t")
                .Append(_EmployeeDetails.PhysicalConditions).Append("\t")
                .Append(_EmployeeDetails.RecordPlace).Append("\t")
                .Append(foreignLanguageAbility).Append("\t")
                .Append(_EmployeeDetails.EmergencyContacts).Append("\t")
                .Append(workTitle).Append("\t")
                .Append(certificates).Append("\t")
                .Append(email1).Append("\t")
                .Append(email2).Append("\t")
                .Append(workPlace).Append("\t")
                .Append(countryNationalityName).Append("\t");
            return theEmployeeInfo.ToString();
        }


        #region 员工状态判断

        #region 基础判断
        /// <summary>
        /// 是否已进入职
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool IsJoinedEmployee(DateTime time)
        {
            if (EmployeeDetails == null || EmployeeDetails.Work == null)
            {
                return false;
            }
            if (DateTime.Compare(EmployeeDetails.Work.ComeDate.Date, time.Date) <= 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 在startTime-endTime时入职
        /// </summary>
        /// <returns></returns>
        public bool IsJoinedEmployee(DateTime startTime, DateTime endTime)
        {
            if (EmployeeDetails == null || EmployeeDetails.Work == null)
            {
                return false;
            }
            if (DateTime.Compare(EmployeeDetails.Work.ComeDate.Date, startTime.Date) >= 0
                && DateTime.Compare(EmployeeDetails.Work.ComeDate.Date, endTime.Date) <= 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否在职，true表示离职
        /// </summary>
        /// <returns>true表示离职</returns>
        public bool IsDimissionEmployee(DateTime time)
        {
            if (EmployeeDetails == null || EmployeeDetails.Work == null)
            {
                return false;
            }
            if (EmployeeType == EmployeeTypeEnum.DimissionEmployee
                && EmployeeDetails.Work.DimissionInfo != null
                && DateTime.Compare(EmployeeDetails.Work.ComeDate.Date,
                                    EmployeeDetails.Work.DimissionInfo.DimissionDate.Date) <= 0
                && DateTime.Compare(EmployeeDetails.Work.DimissionInfo.DimissionDate.Date, time.Date) < 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 是否在startTime-endTime时离职
        /// </summary>
        /// <returns>true表示离职</returns>
        public bool IsDimissionEmployee(DateTime startTime, DateTime endTime)
        {
            if (EmployeeDetails == null || EmployeeDetails.Work == null)
            {
                return false;
            }
            if (EmployeeType == EmployeeTypeEnum.DimissionEmployee
                && EmployeeDetails.Work.DimissionInfo != null
                && DateTime.Compare(EmployeeDetails.Work.ComeDate.Date,
                                    EmployeeDetails.Work.DimissionInfo.DimissionDate.Date) <= 0
                && DateTime.Compare(EmployeeDetails.Work.DimissionInfo.DimissionDate.Date, startTime.Date) >= 0
                && DateTime.Compare(EmployeeDetails.Work.DimissionInfo.DimissionDate.Date, endTime.Date) < 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否在职，true表示退休
        /// </summary>
        /// <returns>true表示退休</returns>
        public bool IsRetirementEmployee(DateTime time)
        {
            if (EmployeeDetails == null || EmployeeDetails.Work == null)
            {
                return false;
            }
            if (EmployeeType == EmployeeTypeEnum.Retirement)
            //&& EmployeeDetails.Work.Retire != null
            //&& DateTime.Compare(EmployeeDetails.Work.ComeDate.Date,
            //                    EmployeeDetails.Work.Retire.RetireDate.Date) <= 0
            //&& DateTime.Compare(EmployeeDetails.Work.Retire.RetireDate.Date, time.Date) < 0
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 是否在startTime-endTime时退休
        /// </summary>
        /// <returns>true表示退休</returns>
        public bool IsRetirementEmployee(DateTime startTime, DateTime endTime)
        {
            if (EmployeeDetails == null || EmployeeDetails.Work == null)
            {
                return false;
            }
            if (EmployeeType == EmployeeTypeEnum.Retirement)
            //&& EmployeeDetails.Work.Retire != null
            //&& DateTime.Compare(EmployeeDetails.Work.ComeDate.Date,
            //                    EmployeeDetails.Work.Retire.RetireDate.Date) <= 0
            //&& DateTime.Compare(EmployeeDetails.Work.Retire.RetireDate.Date, time.Date) < 0
            {
                return true;
            }
            return false;
        }

        #endregion

        #region 综合判断
        /// <summary>
        /// time这一天是否在职
        /// 在职定义：除离职、退休
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool IsOnDutyByDateTime(DateTime time)
        {
            if (EmployeeDetails == null || EmployeeDetails.Work == null)
            {
                return false;
            }
            if (!IsJoinedEmployee(time))
            {
                return false;
            }
            if (IsDimissionEmployee(time))
            {
                return false;
            }
            if (IsRetirementEmployee(time))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 是否在startTime-endTime之间上过班
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public bool IsOnDutyByDateTime(DateTime startTime, DateTime endTime)
        {
            if (EmployeeDetails == null || EmployeeDetails.Work == null)
            {
                return false;
            }
            if (!IsJoinedEmployee(endTime))
            {
                return false;
            }
            if (IsDimissionEmployee(startTime))
            {
                return false;
            }
            if (IsRetirementEmployee(startTime))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 在tartTime-endTime时间内，是因为离职或退休，而不在职的人员
        /// </summary>
        /// <returns></returns>
        public bool IsLeaveInTheTime(DateTime startTime, DateTime endTime)
        {
            if (EmployeeDetails == null || EmployeeDetails.Work == null)
            {
                return false;
            }
            if (IsDimissionEmployee(startTime, endTime))
            {
                return true;
            }
            if (IsRetirementEmployee(startTime, endTime))
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 在tartTime-endTime时间内，是因为离职或退休，而不在职的人员
        /// </summary>
        /// <returns></returns>
        public bool IsJoinInTheTime(DateTime startTime, DateTime endTime)
        {
            return IsJoinedEmployee(startTime, endTime);
        }

        #endregion

        #endregion

        /// <summary>
        /// -1,全部，0，在职，1，离职
        /// </summary>
        /// <param name="employeestatus"></param>
        /// <returns></returns>
        public bool IsNeedEmployeeStatusCondition(int employeestatus)
        {
            if (employeestatus == -1)
            {
                return true;
            }
            if (employeestatus == 0 && IsOnDutyByDateTime(DateTime.Now))
            {
                return true;
            }
            if (employeestatus == 1 && !IsOnDutyByDateTime(DateTime.Now))
            {
                return true;
            }
            return false;
        }



        #endregion

        #region 排序枚举

        /// <summary>
        /// 员工考勤字段排序枚举
        /// </summary>
        public enum EmployeeSortField
        {
            /// <summary>
            /// 员工AccountID字段
            /// </summary>
            EmployeeID,
            /// <summary>
            /// 员工月考勤出勤天字段
            /// </summary>
            EmployeeAttendance_MonthAttendance_RateofOnDuty,
            /// <summary>
            /// 员工月考勤年假天数字段
            /// </summary>
            EmployeeAttendance_MonthAttendance_DaysofLunarPeriodLeave,
            /// <summary>
            /// 员工月考勤事假天数字段
            /// </summary>
            EmployeeAttendance_MonthAttendance_DaysofPersonalReasonLeave,
            /// <summary>
            /// 员工月考勤病假天数字段
            /// </summary>
            EmployeeAttendance_MonthAttendance_DaysofSickLeave,
            /// <summary>
            /// 员工月考勤调休天数字段
            /// </summary>
            EmployeeAttendance_MonthAttendance_DaysofAdjustRestLeave,
            /// <summary>
            /// 员工月考勤其他请假天数字段
            /// </summary>
            EmployeeAttendance_MonthAttendance_DaysofOtherLeave,
            /// <summary>
            /// 员工月考勤普通加班天数字段
            /// </summary>
            EmployeeAttendance_MonthAttendance_DaysofCommonOvertime,
            /// <summary>
            /// 员工月考勤双休加班天数字段
            /// </summary>
            EmployeeAttendance_MonthAttendance_DaysofWeekendOvertime,
            /// <summary>
            /// 员工月考勤节日加班天数字段
            /// </summary>
            EmployeeAttendance_MonthAttendance_DaysofHolidayOvertime,
            /// <summary>
            /// 员工月考勤加班天数字段
            /// </summary>
            EmployeeAttendance_MonthAttendance_DaysofOvertime,
            /// <summary>
            /// 员工月考勤剩余调休字段
            /// </summary>
            EmployeeAttendance_MonthAttendance_DaysofAdjustRestRemained,
            /// <summary>
            /// 员工月考勤剩余年假字段
            /// </summary>
            EmployeeAttendance_Vacation_SurplusDayNum,
            /// <summary>
            /// 员工名字
            /// </summary>
            Name,
            /// <summary>
            /// 员工月考勤旷工天数字段
            /// </summary>
            EmployeeAttendance_MonthAttendance_DaysofNoReasonLeave,
            /// <summary>
            /// 员工月考勤迟到次数字段
            /// </summary>
            EmployeeAttendance_MonthAttendance_ArriveLate_Count,
            /// <summary>
            /// 员工月考勤迟到小时字段
            /// </summary>
            EmployeeAttendance_MonthAttendance_ArriveLate_TotalData,
            /// <summary>
            /// 员工月考勤早退次数字段
            /// </summary>
            EmployeeAttendance_MonthAttendance_LeaveEarly_Count,
            /// <summary>
            /// 员工月考勤早退小时字段
            /// </summary>
            EmployeeAttendance_MonthAttendance_LeaveEarly_TotalData
        }

        #endregion

        #region 排序方法

        /// <summary>
        /// 根据pkid排序
        /// </summary>
        /// <param name="otheremployee">要比较的employee</param>
        /// <returns></returns>
        public int CompareTo(Employee otheremployee)
        {
            return Account.Id.CompareTo(otheremployee.Account.Id);
        }

        /// <summary>
        /// 自定义要排序的列
        /// </summary>
        /// <param name="otheremployee">要比较的employee</param>
        /// <param name="field">要比较的列</param>
        /// <returns></returns>
        public int CompareTo(Employee otheremployee, EmployeeSortField field)
        {
            switch (field)
            {
                case EmployeeSortField.EmployeeID:
                    return Account.Id.CompareTo(otheremployee.Account.Id);

                case EmployeeSortField.Name:
                    return
                        Account.Name.CompareTo(
                            otheremployee.Account.Name);
                case EmployeeSortField.EmployeeAttendance_MonthAttendance_RateofOnDuty:
                    return
                        EmployeeAttendance.MonthAttendance.RateofOnDuty.CompareTo(
                            otheremployee.EmployeeAttendance.MonthAttendance.RateofOnDuty);

                case EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofLunarPeriodLeave:
                    return
                        EmployeeAttendance.MonthAttendance.DaysofLunarPeriodLeave.CompareTo(
                            otheremployee.EmployeeAttendance.MonthAttendance.DaysofLunarPeriodLeave);

                case EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofPersonalReasonLeave:
                    return
                        EmployeeAttendance.MonthAttendance.DaysofPersonalReasonLeave.CompareTo(
                            otheremployee.EmployeeAttendance.MonthAttendance.DaysofPersonalReasonLeave);

                case EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofSickLeave:
                    return
                        EmployeeAttendance.MonthAttendance.DaysofSickLeave.CompareTo(
                            otheremployee.EmployeeAttendance.MonthAttendance.DaysofSickLeave);

                case EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofAdjustRestLeave:
                    return
                        EmployeeAttendance.MonthAttendance.DaysofAdjustRestLeave.CompareTo(
                            otheremployee.EmployeeAttendance.MonthAttendance.DaysofAdjustRestLeave);

                case EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofOtherLeave:
                    return
                        EmployeeAttendance.MonthAttendance.DaysofOtherLeave.CompareTo(
                            otheremployee.EmployeeAttendance.MonthAttendance.DaysofOtherLeave);

                case EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofOvertime:
                    return
                        EmployeeAttendance.MonthAttendance.DaysofOvertime.CompareTo(
                            otheremployee.EmployeeAttendance.MonthAttendance.DaysofOvertime);

                case EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofAdjustRestRemained:
                    return
                        EmployeeAttendance.MonthAttendance.DaysofAdjustRestRemained.CompareTo(
                            otheremployee.EmployeeAttendance.MonthAttendance.DaysofAdjustRestRemained);

                case EmployeeSortField.EmployeeAttendance_Vacation_SurplusDayNum:
                    return
                        EmployeeAttendance.Vacation.SurplusDayNum.CompareTo(
                            otheremployee.EmployeeAttendance.Vacation.SurplusDayNum);


                case EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofNoReasonLeave:
                    return
                        EmployeeAttendance.MonthAttendance.DaysofNoReasonLeave.CompareTo(
                            otheremployee.EmployeeAttendance.MonthAttendance.DaysofNoReasonLeave);

                case EmployeeSortField.EmployeeAttendance_MonthAttendance_ArriveLate_Count:
                    return
                        EmployeeAttendance.MonthAttendance.ArriveLate.Count.CompareTo(
                            otheremployee.EmployeeAttendance.MonthAttendance.ArriveLate.Count);

                case EmployeeSortField.EmployeeAttendance_MonthAttendance_ArriveLate_TotalData:
                    return
                        EmployeeAttendance.MonthAttendance.ArriveLate.TotalData.CompareTo(
                            otheremployee.EmployeeAttendance.MonthAttendance.ArriveLate.TotalData);

                case EmployeeSortField.EmployeeAttendance_MonthAttendance_LeaveEarly_Count:
                    return
                        EmployeeAttendance.MonthAttendance.LeaveEarly.Count.CompareTo(
                            otheremployee.EmployeeAttendance.MonthAttendance.LeaveEarly.Count);

                case EmployeeSortField.EmployeeAttendance_MonthAttendance_LeaveEarly_TotalData:
                    return
                        EmployeeAttendance.MonthAttendance.LeaveEarly.TotalData.CompareTo(
                            otheremployee.EmployeeAttendance.MonthAttendance.LeaveEarly.TotalData);
                case EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofHolidayOvertime:
                    return
                        EmployeeAttendance.MonthAttendance.DaysofHolidayOvertime.CompareTo(
                            otheremployee.EmployeeAttendance.MonthAttendance.DaysofHolidayOvertime);

                case EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofWeekendOvertime:
                    return
                        EmployeeAttendance.MonthAttendance.DaysofWeekendOvertime.CompareTo(
                            otheremployee.EmployeeAttendance.MonthAttendance.DaysofWeekendOvertime);

                case EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofCommonOvertime:
                    return
                        EmployeeAttendance.MonthAttendance.DaysofCommonOvertime.CompareTo(
                            otheremployee.EmployeeAttendance.MonthAttendance.DaysofCommonOvertime);
                default:
                    return Account.Id.CompareTo(otheremployee.Account.Id);
            }
        }

        #endregion

        /// <summary>
        /// 根据ReimburseID获得Reimburse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Reimburse FindReimburseByReimburseID(int id)
        {
            if (Reimburses == null)
            {
                return null;
            }
            foreach (Reimburse reimburse in Reimburses)
            {
                if (reimburse.ReimburseID == id)
                {
                    return reimburse;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据ReimburseID移除Reimburse
        /// </summary>
        /// <param name="id"></param>
        public void RemoveReimburseByReimburseID(int id)
        {
            if (Reimburses == null)
            {
                return;
            }
            for (int i = 0; i < Reimburses.Count; i++)
            {
                if (Reimburses[i].ReimburseID == id)
                {
                    Reimburses.RemoveAt(i);
                    break;
                }
            }
        }


        /// <summary>
        /// 将员工历史记录转化为员工记录
        /// </summary>
        /// <param name="employeeHistoryList"></param>
        /// <returns></returns>
        public static List<Employee> ConvertEmployeeHistorysToEmployee(List<EmployeeHistory> employeeHistoryList)
        {
            List<Employee> employeeList = new List<Employee>();
            foreach (EmployeeHistory employeeHistory in employeeHistoryList)
            {
                employeeList.Add(employeeHistory.Employee);
            }
            return employeeList;
        }

        /// <summary>
        /// 根据acountid获得Employee
        /// </summary>
        /// <returns></returns>
        public static Employee FindEmployeeByAccountID(List<Employee> employeeList, int accountid)
        {
            employeeList = employeeList ?? new List<Employee>();
            foreach (Employee Employee in employeeList)
            {
                if (Employee.Account != null
                    && Employee.Account.Id == accountid)
                {
                    return Employee;
                }
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        public static List<Employee> CopyEmployeeList(List<Employee> employeesource)
        {
            List<Employee> allEmployeeList = new List<Employee>();
            for (int i = 0; i < employeesource.Count; i++)
            {
                allEmployeeList.Add(employeesource[i]);
            }
            return allEmployeeList;
        }

    }
}
