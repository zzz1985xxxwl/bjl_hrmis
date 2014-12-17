using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.Entity
{
    /// <summary>
    /// TEmployee的实体类
    /// </summary>
    public class EmployeeEntity
    {
        private int _PKID;
        /// <summary>
        /// 
        /// </summary>
        public int PKID
        {
            get
            {
                return _PKID;
            }
            set
            {
                _PKID = value;
            }
        }

        private int _CompanyID;
        /// <summary>
        /// 
        /// </summary>
        public int CompanyID
        {
            get
            {
                return _CompanyID;
            }
            set
            {
                _CompanyID = value;
            }
        }

        private int _AccountID;
        /// <summary>
        /// 
        /// </summary>
        public int AccountID
        {
            get
            {
                return _AccountID;
            }
            set
            {
                _AccountID = value;
            }
        }

        private DateTime? _ComeDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ComeDate
        {
            get
            {
                return _ComeDate;
            }
            set
            {
                _ComeDate = value;
            }
        }

        private DateTime? _LeaveDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LeaveDate
        {
            get
            {
                return _LeaveDate;
            }
            set
            {
                _LeaveDate = value;
            }
        }

        private DateTime? _Birthday;
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Birthday
        {
            get
            {
                return _Birthday;
            }
            set
            {
                _Birthday = value;
            }
        }

        private DateTime? _ResidencePermit;
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ResidencePermit
        {
            get
            {
                return _ResidencePermit;
            }
            set
            {
                _ResidencePermit = value;
            }
        }

        private int _EmployeeType;
        /// <summary>
        /// 
        /// </summary>
        public int EmployeeType
        {
            get
            {
                return _EmployeeType;
            }
            set
            {
                _EmployeeType = value;
            }
        }

        private string _EnglishName;
        /// <summary>
        /// 
        /// </summary>
        public string EnglishName
        {
            get
            {
                return _EnglishName;
            }
            set
            {
                _EnglishName = value;
            }
        }

        private int? _Gender;
        /// <summary>
        /// 
        /// </summary>
        public int? Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }

        private int? _PoliticalAffiliation;
        /// <summary>
        /// 
        /// </summary>
        public int? PoliticalAffiliation
        {
            get
            {
                return _PoliticalAffiliation;
            }
            set
            {
                _PoliticalAffiliation = value;
            }
        }

        private int? _MaritalStatus;
        /// <summary>
        /// 
        /// </summary>
        public int? MaritalStatus
        {
            get
            {
                return _MaritalStatus;
            }
            set
            {
                _MaritalStatus = value;
            }
        }

        private int? _EducationalBackground;
        /// <summary>
        /// 
        /// </summary>
        public int? EducationalBackground
        {
            get
            {
                return _EducationalBackground;
            }
            set
            {
                _EducationalBackground = value;
            }
        }

        private int? _WorkType;
        /// <summary>
        /// 
        /// </summary>
        public int? WorkType
        {
            get
            {
                return _WorkType;
            }
            set
            {
                _WorkType = value;
            }
        }

        private int? _HasChild;
        /// <summary>
        /// 
        /// </summary>
        public int? HasChild
        {
            get
            {
                return _HasChild;
            }
            set
            {
                _HasChild = value;
            }
        }

        private byte[] _EmployeeDetails;
        /// <summary>
        /// 
        /// </summary>
        public byte[] EmployeeDetails
        {
            get
            {
                return _EmployeeDetails;
            }
            set
            {
                _EmployeeDetails = value;
            }
        }

        private string _Certificates;
        /// <summary>
        /// 
        /// </summary>
        public string Certificates
        {
            get
            {
                return _Certificates;
            }
            set
            {
                _Certificates = value;
            }
        }

        private string _PRPArea;
        /// <summary>
        /// 
        /// </summary>
        public string PRPArea
        {
            get
            {
                return _PRPArea;
            }
            set
            {
                _PRPArea = value;
            }
        }

        private DateTime? _ProbationTime;
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ProbationTime
        {
            get
            {
                return _ProbationTime;
            }
            set
            {
                _ProbationTime = value;
            }
        }

        private byte[] _Photo;
        /// <summary>
        /// 
        /// </summary>
        public byte[] Photo
        {
            get
            {
                return _Photo;
            }
            set
            {
                _Photo = value;
            }
        }

        private string _DoorCardNo;
        /// <summary>
        /// 
        /// </summary>
        public string DoorCardNo
        {
            get
            {
                return _DoorCardNo;
            }
            set
            {
                _DoorCardNo = value;
            }
        }

        private int? _SocietyWorkAge;
        /// <summary>
        /// 
        /// </summary>
        public int? SocietyWorkAge
        {
            get
            {
                return _SocietyWorkAge;
            }
            set
            {
                _SocietyWorkAge = value;
            }
        }

        private int? _CountryNationalityID;
        /// <summary>
        /// 
        /// </summary>
        public int? CountryNationalityID
        {
            get
            {
                return _CountryNationalityID;
            }
            set
            {
                _CountryNationalityID = value;
            }
        }

        private string _WorkPlace;
        /// <summary>
        /// 
        /// </summary>
        public string WorkPlace
        {
            get
            {
                return _WorkPlace;
            }
            set
            {
                _WorkPlace = value;
            }
        }

        private int _PositionGradeId;
        /// <summary>
        /// 
        /// </summary>
        public int PositionGradeId
        {
            get
            {
                return _PositionGradeId;
            }
            set
            {
                _PositionGradeId = value;
            }
        }

        private DateTime? _ProbationStartTime;
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ProbationStartTime
        {
            get
            {
                return _ProbationStartTime;
            }
            set
            {
                _ProbationStartTime = value;
            }
        }

        private int? _PrincipalShipID;
        /// <summary>
        /// 
        /// </summary>
        public int? PrincipalShipID
        {
            get
            {
                return _PrincipalShipID;
            }
            set
            {
                _PrincipalShipID = value;
            }
        }

        private string _SalaryCardNo;
        /// <summary>
        /// 
        /// </summary>
        public string SalaryCardNo
        {
            get
            {
                return _SalaryCardNo;
            }
            set
            {
                _SalaryCardNo = value;
            }
        }

        private string _SalaryCardBank;
        /// <summary>
        /// 
        /// </summary>
        public string SalaryCardBank
        {
            get
            {
                return _SalaryCardBank;
            }
            set
            {
                _SalaryCardBank = value;
            }
        }

        public string EmployeeName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public string CompanyName { get; set; }
        public string MobileNum { get; set; }
        public DateTime? DimissionDate { get; set; }

        public static Employee Convert(EmployeeEntity e)
        {
            return new Employee
             {
                 Account = new Account
                 {
                     Id = e.AccountID,
                     Name = e.EmployeeName,
                     MobileNum = e.MobileNum,
                     Dept = new Department(e.DepartmentID, e.DepartmentName),
                     Position = new Position(e.PositionID, e.PositionName, null)
                 },
                 EmployeeType = (EmployeeTypeEnum)e.EmployeeType,
                 EmployeeDetails = new EmployeeDetails
                 {
                     Work = new Work
                     {
                         ComeDate =
                             e.ComeDate.GetValueOrDefault(),
                         DimissionInfo = new DimissionInfo
                                             {
                                                 DimissionDate = e.LeaveDate.GetValueOrDefault()
                                             },
                         Company =
                             new Department(e.CompanyID,
                                            e.CompanyName)
                     }
                 }
             };
        }
    }
}

