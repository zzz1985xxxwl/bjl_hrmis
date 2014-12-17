using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 员工详细信息
    /// </summary>
    [Serializable]
    public class EmployeeDetails
    {
        //构造赋值
        private string _EnglishName;
        private Gender _Gender;
        private string _Nationality;
        [OptionalField]
        private MaritalStatus _MaritalStatusEnum;
        private decimal _Height;
        private decimal _Weight;
        private string _NativePlace;
        private string _PhysicalConditions;
        private string _EmergencyContacts;
        private string _RecordPlace;
        private int _Age;
        private DateTime _Birthday;
        private DateTime _ProbationTime;
        private DateTime _ProbationStartTime;
        private DateTime _StatisticsTime;
        private PoliticalAffiliation _PoliticalAffiliation;
        private Nationality _NationalityContry;
        //非构造赋值
        [NonSerialized]
        private byte[] _Photo;
        private IDCard _IDCard;
        private ResidencePermit _ResidencePermits;
        private RegisteredPermanentResidence _RegisteredPermanentResidence;
        private List<FileCargo> _FileCargo = new List<FileCargo>();
        private Family _Family;
        private Education _Education;
        private Work _Work;
        /// <summary>
        /// 员工详细信息构造函数
        /// </summary>
        public EmployeeDetails()
        {
        }
        /// <summary>
        /// 员工详细信息构造函数
        /// </summary>
        /// <param name="englishName"></param>
        /// <param name="gender"></param>
        /// <param name="maritalStatus"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <param name="nativePlace"></param>
        /// <param name="physicalConditions"></param>
        /// <param name="emergencyContacts"></param>
        /// <param name="birthday"></param>
        /// <param name="politicalAffiliation"></param>
        /// <param name="ProbationTime"></param>
        /// <param name="Nationality"></param>
        /// <param name="RecordPlace"></param>
        public EmployeeDetails(string englishName, Gender gender, MaritalStatus maritalStatus, decimal height, decimal weight, string nativePlace,
            string physicalConditions, string emergencyContacts, DateTime birthday, PoliticalAffiliation politicalAffiliation, DateTime ProbationTime, string Nationality, string RecordPlace)
        {
            _EnglishName = englishName;
            _Gender = gender;
            _MaritalStatusEnum = maritalStatus;
            _Height = height;
            _Weight = weight;
            _NativePlace = nativePlace;
            _PhysicalConditions = physicalConditions;
            _EmergencyContacts = emergencyContacts;
            _Birthday = birthday;
            _PoliticalAffiliation = politicalAffiliation;
            _ProbationTime = ProbationTime;
            _Nationality = Nationality;
            _RecordPlace = RecordPlace;
        }

        #region 属性

        /// <summary>
        /// 政治面貌
        /// </summary>
        public PoliticalAffiliation PoliticalAffiliation
        {
            get { return _PoliticalAffiliation; }
            set { _PoliticalAffiliation = value; }
        }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public MaritalStatus MaritalStatus
        {
            get { return _MaritalStatusEnum; }
            set { _MaritalStatusEnum = value; }
        }

        /// <summary>
        /// 高度（单位：厘米）
        /// </summary>
        public decimal Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        /// <summary>
        /// 重量（单位：公斤）
        /// </summary>
        public decimal Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }

        /// <summary>
        /// 籍贯
        /// </summary>
        public string NativePlace
        {
            get { return _NativePlace; }
            set { _NativePlace = value; }
        }

        /// <summary>
        /// 身体状况
        /// </summary>
        public string PhysicalConditions
        {
            get { return _PhysicalConditions; }
            set { _PhysicalConditions = value; }
        }

        /// <summary>
        /// 紧急联系人
        /// </summary>
        public string EmergencyContacts
        {
            get { return _EmergencyContacts; }
            set { _EmergencyContacts = value; }
        }

        /// <summary>
        /// 照片
        /// </summary>
        public byte[] Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
        }

        /// <summary>
        /// 户口
        /// </summary>
        public RegisteredPermanentResidence RegisteredPermanentResidence
        {
            get { return _RegisteredPermanentResidence; }
            set { _RegisteredPermanentResidence = value; }
        }

        /// <summary>
        /// 身份证
        /// </summary>
        public IDCard IDCard
        {
            get { return _IDCard; }
            set { _IDCard = value; }
        }

        /// <summary>
        /// 居住证
        /// </summary>
        public ResidencePermit ResidencePermits
        {
            get { return _ResidencePermits; }
            set { _ResidencePermits = value; }
        }

        /// <summary>
        /// 档案
        /// </summary>
        public List<FileCargo> FileCargo
        {
            get { return _FileCargo; }
            set { _FileCargo = value; }
        }

        /// <summary>
        /// 家庭
        /// </summary>
        public Family Family
        {
            get
            {
                return _Family;
            }
            set
            {
                _Family = value;
            }
        }

        /// <summary>
        /// 教育和培训
        /// </summary>
        public Education Education
        {
            get
            {
                return _Education;
            }
            set
            {
                _Education = value;
            }
        }

        /// <summary>
        /// 工作
        /// </summary>
        public Work Work
        {
            get
            {
                return _Work;
            }
            set
            {
                _Work = value;
            }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender
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

        /// <summary>
        /// 英文名
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

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday
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

        /// <summary>
        /// 试用期到期日
        /// </summary>
        public DateTime ProbationTime
        {
            get { return _ProbationTime; }
            set { _ProbationTime = value; }
        }
        /// <summary>
        /// 试用期开始日
        /// </summary>
        public DateTime ProbationStartTime
        {
            get { return _ProbationStartTime; }
            set { _ProbationStartTime = value; }
        }

        /// <summary>
        /// 民族
        /// </summary>
        public string Nationality
        {
            get { return _Nationality; }
            set { _Nationality = value; }
        }

        /// <summary>
        /// 档案所在地
        /// </summary>
        public string RecordPlace
        {
            get { return _RecordPlace; }
            set { _RecordPlace = value; }
        }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age
        {
            get
            {
                if (StatisticsTime.Date.Year == 1)
                {
                    _Age = DateTime.Now.Subtract(Birthday).Days / 365;
                }
                else
                {
                    _Age = StatisticsTime.Date.Subtract(Birthday).Days / 365;
                } 
                return _Age;
            }
            set
            {
                _Age = value;
            }
        }

        /// <summary>
        /// 统计时间
        /// </summary>
        public DateTime StatisticsTime
        {
            get { return _StatisticsTime; }
            set { _StatisticsTime = value; }
        }

        /// <summary>
        /// 国籍
        /// </summary>
        public Nationality CountryNationality
        {
            get { return _NationalityContry; }
            set { _NationalityContry = value; }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 重写Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            EmployeeDetails anOtherObj = obj as EmployeeDetails;
            if (anOtherObj == null)
            {
                return false;
            }

            return _EnglishName.Equals(anOtherObj._EnglishName) &&
                   _Gender.Equals(anOtherObj._Gender) &&
                   _Nationality.Equals(anOtherObj._Nationality) &&
                   _MaritalStatusEnum.Equals(anOtherObj._MaritalStatusEnum) &&
                   _Height.Equals(anOtherObj._Height) &&
                   _Weight.Equals(anOtherObj._Weight) &&
                   _NativePlace.Equals(anOtherObj._NativePlace) &&
                   _RecordPlace.Equals(anOtherObj._RecordPlace) &&
                   _PhysicalConditions.Equals(anOtherObj._PhysicalConditions) &&
                   _EmergencyContacts.Equals(anOtherObj._EmergencyContacts) &&
                   _Birthday.Equals(anOtherObj._Birthday) &&
                   _ProbationTime.Equals(anOtherObj._ProbationTime) &&
                   _PoliticalAffiliation.Equals(anOtherObj._PoliticalAffiliation) &&
                   _IDCard.Equals(anOtherObj._IDCard) &&
                   _ResidencePermits.Equals(anOtherObj._ResidencePermits) &&
                   _RegisteredPermanentResidence.Equals(anOtherObj._RegisteredPermanentResidence) &&
                   _Family.Equals(anOtherObj._Family) &&
                   _Education.Equals(anOtherObj._Education) &&
                   _Work.Equals(anOtherObj._Work) &&
                   JudgeFileCargo(anOtherObj);
        }
        /// <summary>
        /// 判断JudgeFileCargo是否相同
        /// </summary>
        /// <param name="anOtherObj"></param>
        /// <returns></returns>
        private bool JudgeFileCargo(EmployeeDetails anOtherObj)
        {
            bool retVal = true;
            if (_FileCargo.Count != anOtherObj._FileCargo.Count)
            {
                retVal = false;
            }
            else
            {
                for (int i = 0; i < _FileCargo.Count; i++)
                {
                    if (!_FileCargo[i].Equals(anOtherObj._FileCargo[i]))
                    {
                        retVal = false;
                    }
                }
            }
            return retVal;
        }

        #endregion

    }
}