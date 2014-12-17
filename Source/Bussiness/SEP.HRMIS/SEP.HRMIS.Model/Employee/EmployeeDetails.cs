using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// Ա����ϸ��Ϣ
    /// </summary>
    [Serializable]
    public class EmployeeDetails
    {
        //���츳ֵ
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
        //�ǹ��츳ֵ
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
        /// Ա����ϸ��Ϣ���캯��
        /// </summary>
        public EmployeeDetails()
        {
        }
        /// <summary>
        /// Ա����ϸ��Ϣ���캯��
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

        #region ����

        /// <summary>
        /// ������ò
        /// </summary>
        public PoliticalAffiliation PoliticalAffiliation
        {
            get { return _PoliticalAffiliation; }
            set { _PoliticalAffiliation = value; }
        }

        /// <summary>
        /// ����״��
        /// </summary>
        public MaritalStatus MaritalStatus
        {
            get { return _MaritalStatusEnum; }
            set { _MaritalStatusEnum = value; }
        }

        /// <summary>
        /// �߶ȣ���λ�����ף�
        /// </summary>
        public decimal Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        /// <summary>
        /// ��������λ�����
        /// </summary>
        public decimal Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string NativePlace
        {
            get { return _NativePlace; }
            set { _NativePlace = value; }
        }

        /// <summary>
        /// ����״��
        /// </summary>
        public string PhysicalConditions
        {
            get { return _PhysicalConditions; }
            set { _PhysicalConditions = value; }
        }

        /// <summary>
        /// ������ϵ��
        /// </summary>
        public string EmergencyContacts
        {
            get { return _EmergencyContacts; }
            set { _EmergencyContacts = value; }
        }

        /// <summary>
        /// ��Ƭ
        /// </summary>
        public byte[] Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public RegisteredPermanentResidence RegisteredPermanentResidence
        {
            get { return _RegisteredPermanentResidence; }
            set { _RegisteredPermanentResidence = value; }
        }

        /// <summary>
        /// ���֤
        /// </summary>
        public IDCard IDCard
        {
            get { return _IDCard; }
            set { _IDCard = value; }
        }

        /// <summary>
        /// ��ס֤
        /// </summary>
        public ResidencePermit ResidencePermits
        {
            get { return _ResidencePermits; }
            set { _ResidencePermits = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public List<FileCargo> FileCargo
        {
            get { return _FileCargo; }
            set { _FileCargo = value; }
        }

        /// <summary>
        /// ��ͥ
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
        /// ��������ѵ
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
        /// ����
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
        /// �Ա�
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
        /// Ӣ����
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
        /// ����
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
        /// �����ڵ�����
        /// </summary>
        public DateTime ProbationTime
        {
            get { return _ProbationTime; }
            set { _ProbationTime = value; }
        }
        /// <summary>
        /// �����ڿ�ʼ��
        /// </summary>
        public DateTime ProbationStartTime
        {
            get { return _ProbationStartTime; }
            set { _ProbationStartTime = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Nationality
        {
            get { return _Nationality; }
            set { _Nationality = value; }
        }

        /// <summary>
        /// �������ڵ�
        /// </summary>
        public string RecordPlace
        {
            get { return _RecordPlace; }
            set { _RecordPlace = value; }
        }

        /// <summary>
        /// ����
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
        /// ͳ��ʱ��
        /// </summary>
        public DateTime StatisticsTime
        {
            get { return _StatisticsTime; }
            set { _StatisticsTime = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public Nationality CountryNationality
        {
            get { return _NationalityContry; }
            set { _NationalityContry = value; }
        }

        #endregion

        #region ����
        /// <summary>
        /// ��дEquals
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
        /// �ж�JudgeFileCargo�Ƿ���ͬ
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