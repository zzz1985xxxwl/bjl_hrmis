//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: Work.cs
// ������: �����
// ��������: 2008-08-26
// ����: ����
// ----------------------------------------------------------------

using System.Collections.Generic;
using System;
using System.Runtime.Serialization;
using SEP.Model.Departments;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ����
    /// </summary>
    [Serializable]
    public class Work
    {
        private string _Title;
        private string _ContractPosition;
        private WorkType _WorkType;
        private DateTime _ComeDate;
        private decimal _WorkAgeDecaiml;
        private DateTime _StatisticsTime = DateTime.Now;
        private string _Responsibility;
        private string _WorkPlace;
        private string _SalaryCardNo;
        private string _SalaryCardBank;
        //�ǹ���
        [OptionalField]
        private Department _Company;
        private DimissionInfo _DimissionInfo;
        private List<WorkExperience> _WorkExperiences = new List<WorkExperience>();
        /// <summary>
        /// �������캯��
        /// </summary>
        public Work()
        {
        }
        /// <summary>
        /// �������캯��
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="ContractPosition"></param>
        /// <param name="WorkType"></param>
        /// <param name="ComeDate"></param>
        /// <param name="Responsibility"></param>
        public Work(string Title, string ContractPosition, WorkType WorkType, DateTime ComeDate, string Responsibility)
        {
            _Title = Title;
            _ContractPosition = ContractPosition;
            _WorkType = WorkType;
            _ComeDate = ComeDate;
            _Responsibility = Responsibility;
        }

        /// <summary>
        /// �ù�����
        /// </summary>
        public WorkType WorkType
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

        /// <summary>
        /// ְ��
        /// </summary>
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }

        /// <summary>
        /// Ƹ��ְ��
        /// </summary>
        public string ContractPosition
        {
            get
            {
                return _ContractPosition;
            }
            set
            {
                _ContractPosition = value;
            }
        }

        /// <summary>
        /// ְ��
        /// </summary>
        public string Responsibility
        {
            get
            {
                return _Responsibility;
            }
            set
            {
                _Responsibility = value;
            }
        }

        /// <summary>
        /// ��ְʱ��
        /// </summary>
        public DateTime ComeDate
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
        /// <summary>
        /// ���������б�
        /// </summary>
        public List<WorkExperience> WorkExperiences
        {
            get
            {
                return _WorkExperiences;
            }
            set
            {
                _WorkExperiences = value;
            }
        }
        /// <summary>
        /// ��ְ��Ϣ
        /// </summary>
        public DimissionInfo DimissionInfo
        {
            get { return _DimissionInfo; }
            set { _DimissionInfo = value; }
        }

        /// <summary>
        /// ������˾
        /// </summary>
        public Department Company
        {
            get { return _Company; }
            set { _Company = value; }
        }

        /// <summary>
        /// ˾��
        /// </summary>
        public decimal WorkAgeDecaiml
        {
            get
            {
                if (StatisticsTime.Date.Year == 1)
                {
                    _WorkAgeDecaiml = DateTime.Now.Subtract(ComeDate).Days / 365m;
                }
                else
                {
                    _WorkAgeDecaiml = StatisticsTime.Date.Subtract(ComeDate.Date).Days / 365m;
                }
                return _WorkAgeDecaiml;
            }

        }
        /// <summary>
        /// ˾��
        /// </summary>
        public string WorkAgeString
        {
            get
            {
                decimal year ;
                decimal month = 0;
                DateTime dt = ComeDate;
                DateTime now = DateTime.Now;
                while (now > dt)
                {
                    month++;
                    dt = dt.AddMonths(1);
                }
                year = (month - month % 12) / 12;
                return string.Format("{0}��{1}��", year, month % 12);
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
        /// �����ص�
        /// </summary>
        public string WorkPlace
        {
            get { return _WorkPlace; }
            set { _WorkPlace = value; }
        }

        private PrincipalShip _PrincipalShip;
        ///<summary>
        /// ְλ
        ///</summary>
        public PrincipalShip Principalship
        {
            get { return _PrincipalShip; }
            set { _PrincipalShip = value; }
        }
        /// <summary>
        /// ���ʿ���
        /// </summary>
        public string SalaryCardNo
        {
            get { return _SalaryCardNo; }
            set { _SalaryCardNo = value; }
        }
        /// <summary>
        /// ���ʿ���������
        /// </summary>
        public string SalaryCardBank
        {
            get { return _SalaryCardBank; }
            set { _SalaryCardBank = value; }
        }
        #region ����
        /// <summary>
        /// ��дEquals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Work anOtherObj = obj as Work;
            if (anOtherObj == null)
            {
                return false;
            }
            return
                _Title.Equals(anOtherObj._Title) &&
                _ContractPosition.Equals(anOtherObj._ContractPosition) &&
                _WorkType.Equals(anOtherObj._WorkType) &&
                _ComeDate.Equals(anOtherObj._ComeDate) &&
                DimissionInfo.Equals(anOtherObj.DimissionInfo) &&
                _Responsibility.Equals(anOtherObj._Responsibility) &&
                _Company.DepartmentID.Equals(anOtherObj._Company.DepartmentID) &&
                _Company.DepartmentName.Equals(anOtherObj._Company.DepartmentName) &&
                _WorkPlace.Equals(anOtherObj._WorkPlace) &&
                JudgeWorkExperiences(anOtherObj);
        }
        private bool JudgeWorkExperiences(Work anOtherObj)
        {
            bool retVal = true;
            if (_WorkExperiences.Count != anOtherObj._WorkExperiences.Count)
            {
                retVal = false;
            }
            else
            {
                for (int i = 0; i < _WorkExperiences.Count; i++)
                {
                    if (!_WorkExperiences[i].Equals(anOtherObj._WorkExperiences[i]))
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
