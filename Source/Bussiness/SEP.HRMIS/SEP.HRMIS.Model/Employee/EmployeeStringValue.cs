using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.Model.Accounts;
using ShiXin.Security;
using System.Linq;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 用于列表显示的Employee
    /// </summary>
    public class EmployeeStringValue
    {
        private readonly Employee employee;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_Employee"></param>
        public EmployeeStringValue(Employee _Employee)
        {
            employee = _Employee;
        }

        public static List<EmployeeStringValue> Turn(List<Employee> sources)
        {
            List<EmployeeStringValue> list = new List<EmployeeStringValue>();
            foreach (Employee item in sources)
            {
                list.Add(new EmployeeStringValue(item));
            }
            return list;
        }

        #region TextField
        public string Email
        {
            get
            {
                return
                    employee != null && employee.Account != null
                     && employee.Account.Email1 != null
                        ? employee.Account.Email1
                        : null;
            }
        }
        public string Email2
        {
            get
            {
                return
                    employee != null && employee.Account != null
                     && employee.Account.Email2 != null
                        ? employee.Account.Email2
                        : null;
            }
        }
        public string WorkAgeString
        {
            get
            {
                return
                    employee != null && employee.EmployeeDetails != null
                     && employee.EmployeeDetails.Work != null && employee.EmployeeDetails.Work.WorkAgeString != null
                        ? employee.EmployeeDetails.Work.WorkAgeString
                        : null;
            }
        }
        public string DimissionType
        {
            get
            {
                return
                    employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Work != null
                     && employee.EmployeeDetails.Work.DimissionInfo != null
                     && employee.EmployeeDetails.Work.DimissionInfo.DimissionType != null
                        ? employee.EmployeeDetails.Work.DimissionInfo.DimissionType
                        : null;
            }
        }
        public string ChildNameShow
        {
            get
            {
                if (ChildName == ChildName2)
                {
                    return ChildName;
                }
                return ChildName + " " + ChildName2;
            }
        }
        public string ChildName
        {
            get
            {
                return
                    employee != null && employee.EmployeeDetails != null
                    && employee.EmployeeDetails.Family != null
                    && employee.EmployeeDetails.Family.ChildName != null
                        ? employee.EmployeeDetails.Family.ChildName
                        : null;
            }
        }
        public string ChildName2
        {
            get
            {
                return
                    employee != null && employee.EmployeeDetails != null
                    && employee.EmployeeDetails.Family != null
                    && employee.EmployeeDetails.Family.ChildName2 != null
                        ? employee.EmployeeDetails.Family.ChildName2
                        : null;
            }
        }
        public string EmergencyContacts
        {
            get
            {
                return
                    employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.EmergencyContacts != null
                        ? employee.EmployeeDetails.EmergencyContacts
                        : null;
            }
        }
        public string RecordPlace
        {
            get
            {
                return
                    employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.RecordPlace != null
                        ? employee.EmployeeDetails.RecordPlace
                        : null;
            }
        }

        public string PRPStreet
        {
            get
            {
                return
                   employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.RegisteredPermanentResidence != null
                      && employee.EmployeeDetails.RegisteredPermanentResidence.PRPStreet != null
                        ? employee.EmployeeDetails.RegisteredPermanentResidence.PRPStreet
                        : null;
            }
        }
        public string PRPArea
        {
            get
            {
                return
                    employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.RegisteredPermanentResidence != null
                      && employee.EmployeeDetails.RegisteredPermanentResidence.PRPArea != null
                        ? employee.EmployeeDetails.RegisteredPermanentResidence.PRPArea
                        : null;
            }
        }
        public string PRPPostCode
        {

            get
            {
                return
                     employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.RegisteredPermanentResidence != null
                       && employee.EmployeeDetails.RegisteredPermanentResidence.PRPPostCode != null
                         ? employee.EmployeeDetails.RegisteredPermanentResidence.PRPPostCode
                         : null;
            }
        }

        public string RPRAddress
        {

            get
            {
                return
                      employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.RegisteredPermanentResidence != null
                        && employee.EmployeeDetails.RegisteredPermanentResidence.RPRAddress != null
                          ? employee.EmployeeDetails.RegisteredPermanentResidence.RPRAddress
                          : null;
            }
        }

        public string Certificates
        {

            get
            {
                return
                    employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Education != null
                      && employee.EmployeeDetails.Education.Certificates != null
                        ? employee.EmployeeDetails.Education.Certificates
                        : null;
            }
        }
        public string ForeignLanguageAbility
        {

            get
            {
                return
                      employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Education != null
                        && employee.EmployeeDetails.Education.ForeignLanguageAbility != null
                          ? employee.EmployeeDetails.Education.ForeignLanguageAbility
                          : null;
            }
        }
        public string WorkTitle
        {

            get
            {
                return
                      employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Work != null
                        && employee.EmployeeDetails.Work.Title != null
                          ? employee.EmployeeDetails.Work.Title
                          : null;
            }
        }

        public string AccumulationFundSupplyAccount
        {

            get
            {
                return
                     employee != null && employee.EmployeeWelfare != null && employee.EmployeeWelfare.AccumulationFund != null
                       && employee.EmployeeWelfare.AccumulationFund.SupplyAccount != null
                         ? employee.EmployeeWelfare.AccumulationFund.SupplyAccount
                         : null;
            }
        }
        public string AccumulationFundAccount
        {

            get
            {
                return
                       employee != null && employee.EmployeeWelfare != null && employee.EmployeeWelfare.AccumulationFund != null
                         && employee.EmployeeWelfare.AccumulationFund.Account != null
                           ? employee.EmployeeWelfare.AccumulationFund.Account
                           : null;
            }
        }
        public string SalaryCardNo
        {

            get
            {
                return
                      employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Work != null
                        && employee.EmployeeDetails.Work.SalaryCardNo != null
                          ? employee.EmployeeDetails.Work.SalaryCardNo
                          : null;
            }
        }
        public string SalaryCardBank
        {

            get
            {
                return
                      employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Work != null
                        && employee.EmployeeDetails.Work.SalaryCardBank != null
                          ? employee.EmployeeDetails.Work.SalaryCardBank
                          : null;
            }
        }
        public string EmployeeWelfareDescription
        {

            get
            {
                return
                     employee != null && employee.Account != null && employee.Account.Position != null
                      && employee.Account.Position.Grade != null && employee.Account.Position.Grade.Description != null
                         ? employee.Account.Position.Grade.Description
                         : null;
            }
        }
        public string ResidencePermitsOrgnaization
        {

            get
            {
                return
                    employee != null && employee.EmployeeDetails != null &&
                    employee.EmployeeDetails.ResidencePermits != null
                    && employee.EmployeeDetails.ResidencePermits.Orgnaization != null
                        ? employee.EmployeeDetails.ResidencePermits.Orgnaization
                        : null;
            }
        }

        public string Responsibility
        {
            get
            {
                return
                    employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Work != null
                     && employee.EmployeeDetails.Work.Responsibility != null
                        ? employee.EmployeeDetails.Work.Responsibility
                        : null;
            }
        }
        public string WorkPlace
        {
            get
            {
                return
                    employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Work != null
                    && employee.EmployeeDetails.Work.WorkPlace != null
                        ? employee.EmployeeDetails.Work.WorkPlace
                        : null;
            }
        }
        public string DoorCardNo
        {
            get
            {
                return
                                   employee != null && employee.EmployeeAttendance != null && employee.EmployeeAttendance.DoorCardNo != null
                                       ? employee.EmployeeAttendance.DoorCardNo
                                       : null;
            }
        }
        public string Leader
        {
            get
            {
                return
                    employee != null && employee.Account != null && employee.Account.Dept != null
                    && employee.Account.Dept.Leader != null && employee.Account.Dept.Leader.Name != null
                        ? employee.Account.Dept.Leader.Name
                        : null;
            }
        }
        public string Major
        {
            get
            {
                return
                    employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Education != null
                    && employee.EmployeeDetails.Education.Major != null
                        ? employee.EmployeeDetails.Education.Major
                        : null;
            }
        }

        public string IDCardNo
        {
            get
            {
                return
                    employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.IDCard != null
                    && employee.EmployeeDetails.IDCard.IDCardNo != null
                        ? employee.EmployeeDetails.IDCard.IDCardNo
                        : null;
            }
        }
        public string PhysicalConditions
        {
            get
            {
                return
                    employee != null && employee.EmployeeDetails != null &&
                    employee.EmployeeDetails.PhysicalConditions != null
                        ? employee.EmployeeDetails.PhysicalConditions
                        : null;
            }
        }

        public string NativePlace
        {
            get
            {
                return
                    employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.NativePlace != null
                        ? employee.EmployeeDetails.NativePlace
                        : null;
            }
        }
        public string Nationality
        {
            get
            {
                return
                                   employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Nationality != null
                                       ? employee.EmployeeDetails.Nationality
                                       : null;
            }
        }
        public string LoginName
        {
            get
            {
                return
                    employee != null && employee.Account != null && employee.Account.LoginName != null
                        ? employee.Account.LoginName
                        : null;
            }
        }
        public string Name
        {
            get
            {
                return
                    employee != null && employee.Account != null && employee.Account.Name != null
                        ? employee.Account.Name
                        : null;
            }
        }
        public string EnglishName
        {
            get
            {
                return
                                employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.EnglishName != null
                                    ? employee.EmployeeDetails.EnglishName
                                    : null;
            }
        }
        public string School
        {
            get
            {
                return
                                employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Education != null &&
                                employee.EmployeeDetails.Education.School != null
                                    ? employee.EmployeeDetails.Education.School
                                    : null;
            }
        }
        public string FamilyAddress
        {
            get
            {
                return
                                employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Family != null &&
                                employee.EmployeeDetails.Family.FamilyAddress != null
                                    ?
                                          employee.EmployeeDetails.Family.FamilyAddress
                                    : null;
            }
        }
        public string PostCode
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Family != null &&
                employee.EmployeeDetails.Family.PostCode != null
                    ? employee.EmployeeDetails.Family.PostCode
                    : null;
            }
        }
        public string FamilyPhone
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Family != null &&
                employee.EmployeeDetails.Family.FamilyPhone != null
                    ? employee.EmployeeDetails.Family.FamilyPhone
                    : null;
            }
        }
        public string MobileNum
        {
            get
            {
                return
                employee != null && employee.Account != null && employee.Account.MobileNum != null
                    ? employee.Account.MobileNum
                    : null;
            }
        }
        #endregion

        #region DateTimeField
        public string ChildBirthdayShow
        {
            get
            {
                if (ChildBirthday == ChildBirthday2)
                {
                    return ChildBirthday;
                }
                return ChildBirthday + " " + ChildBirthday2;
            }
        }

        public string ChildBirthday
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Family != null
                 && employee.EmployeeDetails.Family.ChildBirthday != null
                    ? employee.EmployeeDetails.Family.ChildBirthday.Value.ToString("yyyy-MM-dd")
                    : null;

            }
        }
        public string ChildBirthday2
        {
            get
            {
                return
                      employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Family != null
                       && employee.EmployeeDetails.Family.ChildBirthday2 != null
                          ? employee.EmployeeDetails.Family.ChildBirthday2.Value.ToString("yyyy-MM-dd")
                          : null;
            }
        }
        public string ResidencePermits
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.ResidencePermits != null
                    ? employee.EmployeeDetails.ResidencePermits.DueDate.ToString("yyyy-MM-dd")
                    : null;
            }
        }
        public string ProbationStartTime
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null
                    ? employee.EmployeeDetails.ProbationStartTime.ToString("yyyy-MM-dd")
                    : null;
            }
        }
        public string ProbationTime
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null
                    ? employee.EmployeeDetails.ProbationTime.ToString("yyyy-MM-dd")
                    : null;
            }
        }
        public string GraduateTime
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Education != null
                    ? employee.EmployeeDetails.Education.GraduateTime.ToString("yyyy-MM-dd")
                    : null;
            }
        }
        public string IDCardDueDate
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.IDCard != null
                    ? employee.EmployeeDetails.IDCard.DueDate.ToString("yyyy-MM-dd")
                    : null;
            }
        }
        public string Birthday
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null
                    ? employee.EmployeeDetails.Birthday.ToString("yyyy-MM-dd")
                    : null;
            }
        }
        public string ComeDate
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Work != null
                    ? employee.EmployeeDetails.Work.ComeDate.ToString("yyyy-MM-dd")
                    : null;
            }
        }
        public string LeaveDate
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Work != null
                && employee.EmployeeDetails.Work.DimissionInfo != null
                    ? employee.EmployeeDetails.Work.DimissionInfo.DimissionDate.ToString("yyyy-MM-dd")
                    : null;
            }
        }
        #endregion

        #region NumField

        public string WorkAgeDecaiml
        {
            get
            {
                return
                    employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Work != null
                        ? employee.EmployeeDetails.Work.WorkAgeDecaiml.ToString()
                        : null;
            }
        }
        public string Age
        {
            get
            {
                return
                    employee != null && employee.EmployeeDetails != null
                        ? employee.EmployeeDetails.Age.ToString()
                        : null;
            }
        }
        public string NewDimissionMonth
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null
                 && employee.EmployeeDetails.Work != null && employee.EmployeeDetails.Work.DimissionInfo != null
                    ? employee.EmployeeDetails.Work.DimissionInfo.NewDimissionMonth.ToString()
                    : null;
            }
        }
        public string SocietyWorkAge
        {
            get
            {
                return
                employee != null && employee.SocWorkAgeAndVacationList != null
                    ? employee.SocWorkAgeAndVacationList.SocietyWorkAge.ToString()
                    : null;
            }

        }
        public string Num
        {
            get
            {
                return
                employee != null && employee.Account != null
                    ? employee.Account.Id.ToString()
                    : null;
            }
        }

        public string Height
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null
                    ? employee.EmployeeDetails.Height.ToString()
                    : null;
            }

        }
        public string Weight
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null
                    ? employee.EmployeeDetails.Weight.ToString()
                    : null;
            }

        }
        public string AnnualMaintainDays
        {
            get
            {
                return
                employee != null && employee.EmployeeAttendance != null && employee.EmployeeAttendance.Vacation != null
                    ? employee.EmployeeAttendance.Vacation.SurplusDayNum.ToString()
                    : null;
            }

        }
        public string AdjustMaintainDays
        {
            get
            {
                return
                employee != null && employee.EmployeeAttendance != null
                && employee.EmployeeAttendance.MonthAttendance != null
                    ?
                          employee.EmployeeAttendance.MonthAttendance.DaysofAdjustRestRemained.ToString()
                    : null;
            }
        }

        #endregion

        #region StaticEnumField


        public string PositionGrade
        {
            get
            {
                return
                employee != null && employee.Account != null && employee.Account.Position != null
                && employee.Account.Position.Grade != null
                && employee.Account.Position.Grade.Name != null
                    ? employee.Account.Position.Grade.Name
                    : null;
            }

        }
        public string DimissionReasonType
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Work != null
                && employee.EmployeeDetails.Work.DimissionInfo != null
                && employee.EmployeeDetails.Work.DimissionInfo.DimissionReasonType != null
                && employee.EmployeeDetails.Work.DimissionInfo.DimissionReasonType.Name != null
                    ? employee.EmployeeDetails.Work.DimissionInfo.DimissionReasonType.Name
                    : null;
            }

        }
        public string WorkType
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Work != null
                && employee.EmployeeDetails.Work.WorkType != null
                && employee.EmployeeDetails.Work.WorkType.Name != null
                    ? employee.EmployeeDetails.Work.WorkType.Name
                    : null;
            }

        }
        public string EducationalBackground
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Education != null
                && employee.EmployeeDetails.Education.EducationalBackground != null
                && employee.EmployeeDetails.Education.EducationalBackground.Name != null
                    ? employee.EmployeeDetails.Education.EducationalBackground.Name
                    : null;
            }

        }
        public string MaritalStatus
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null
                && employee.EmployeeDetails.MaritalStatus != null && employee.EmployeeDetails.MaritalStatus.Name != null
                    ? employee.EmployeeDetails.MaritalStatus.Name
                    : null;
            }

        }
        public string PoliticalAffiliation
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null
                && employee.EmployeeDetails.PoliticalAffiliation != null && employee.EmployeeDetails.PoliticalAffiliation.Name != null
                    ? employee.EmployeeDetails.PoliticalAffiliation.Name
                    : null;
            }

        }
        public string Gender
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null
                && employee.EmployeeDetails.Gender != null && employee.EmployeeDetails.Gender.Name != null
                    ? employee.EmployeeDetails.Gender.Name
                    : null;
            }

        }
        public string EmployeeType
        {
            get
            {
                return
                employee != null
                    ?
                          EmployeeTypeUtility.EmployeeTypeDisplay(employee.EmployeeType)
                    : null;
            }
        }

        #endregion

        #region ActiveEnumField

        public string Skill
        {
            get
            {
                if (employee != null && employee.EmployeeSkills != null)
                {
                    string strRet = "";
                    foreach (EmployeeSkill skill in employee.EmployeeSkills)
                    {
                        strRet += string.IsNullOrEmpty(strRet) ? skill.Skill.SkillName : ";" + skill.Skill.SkillName;
                    }
                    if (string.IsNullOrEmpty(strRet))
                    {
                        strRet = null;
                    }
                    return strRet;
                }
                else
                {
                    return null;
                }
            }
        }
        
        public string DiyProcessHRPrincipal
        {
            get
            {
                if (employee != null && employee.DiyProcessList != null)
                {
                    foreach (DiyProcess process in employee.DiyProcessList)
                    {
                        if (process.Type.Id == ProcessType.HRPrincipal.Id && process.Name != null)
                        {
                            return process.Name;
                        }
                    }
                }
                return null;
            }

        }

        public string DiyProcessTraineeApplication
        {
            get
            {
                if (employee != null && employee.DiyProcessList != null)
                {
                    foreach (DiyProcess process in employee.DiyProcessList)
                    {
                        if (process.Type.Id == ProcessType.TraineeApplication.Id && process.Name != null)
                        {
                            return process.Name;
                        }
                    }
                } 
                return null;
            }
        }

        public string DiyProcessAssess
        {
            get
            {
                if (employee != null && employee.DiyProcessList != null)
                {
                    foreach (DiyProcess process in employee.DiyProcessList)
                    {
                        if (process.Type.Id == ProcessType.Assess.Id && process.Name != null)
                        {
                            return process.Name;
                        }
                    }
                }
                return null;
            }
        }

        public string DiyProcessApplicationTypeOverTime
        {
            get
            {
                if (employee != null && employee.DiyProcessList != null)
                {
                    foreach (DiyProcess process in employee.DiyProcessList)
                    {
                        if (process.Type.Id == ProcessType.ApplicationTypeOverTime.Id && process.Name != null)
                        {
                            return process.Name;
                        }
                    }
                }
                return null;
            }
        }

        public string DiyProcessApplicationTypeOut
        {
            get
            {
                if (employee != null && employee.DiyProcessList != null)
                {
                    foreach (DiyProcess process in employee.DiyProcessList)
                    {
                        if (process.Type.Id == ProcessType.ApplicationTypeOut.Id && process.Name != null)
                        {
                            return process.Name;
                        }
                    }
                }
                return null;
            }
        }

        public string DiyProcessLeaveRequest
        {
            get
            {
                if (employee != null && employee.DiyProcessList != null)
                {
                    foreach (DiyProcess process in employee.DiyProcessList)
                    {
                        if (process.Type.Id == ProcessType.LeaveRequest.Id && process.Name != null)
                        {
                            return process.Name;
                        }
                    }
                }
                return null;
            }
        }

        public string CountryNationality
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.CountryNationality != null
                && employee.EmployeeDetails.CountryNationality.Name != null
                    ? employee.EmployeeDetails.CountryNationality.Name
                    : null;
            }
        }
        public string Position
        {
            get
            {
                return
                employee != null && employee.Account != null && employee.Account.Position != null && employee.Account.Position.Name != null
                    ? employee.Account.Position.Name
                    : null;
            }
        }
        public string Grades
        {
            get
            {
                return
                employee != null && employee.Account != null && employee.Account.GradesID != null
                    ? GradesType.GetAll().Where(x=>x.ID==employee.Account.GradesID.GetValueOrDefault()).FirstOrDefault().Name
                    : null;
            }
        }
        public string Company
        {
            get
            {
                return
                employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Work != null
                && employee.EmployeeDetails.Work.Company != null && employee.EmployeeDetails.Work.Company.Name != null
                    ? employee.EmployeeDetails.Work.Company.Name
                    : null;
            }
        }
        #endregion

        #region TreeActiveEnumField

        public string Department
        {
            get
            {
                return
                    employee != null && employee.Account != null && employee.Account.Dept != null &&
                    employee.Account.Dept.Name != null
                        ? employee.Account.Dept.Name
                        : null;
            }
        }
        #endregion

        #region OtherValue
        public string NumDECEncrypt
        {
            get
            {
                return
                employee != null && employee.Account != null
                    ? SecurityUtil.DECEncrypt(employee.Account.Id.ToString())
                    : null;
            }
        }
        public string DECEncrypt4
        {
            get
            {
                return SecurityUtil.DECEncrypt(4.ToString());
            }
        }
        #endregion
    }
}
