//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: Education.cs
// ������: �����
// ��������: 2008-08-26
// ����: ��������ѵ
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��������ѵ
    /// </summary>
    [Serializable]
    public class Education
    {
        //����
        private EducationalBackground _EducationalBackground;
        private string _School;
        private string _Major;
        private string _ForeignLanguageAbility;
        private string _Certificates;
        //�ǹ���
        [OptionalField]
        private DateTime _GraduateTime;
        private List<EducationExperience> _EducationExperiences = new List<EducationExperience>();
        /// <summary>
        /// ��������ѵ���캯��
        /// </summary>
        public Education()
        {
        }
        /// <summary>
        /// ��������ѵ���캯��
        /// </summary>
        /// <param name="EducationalBackground"></param>
        /// <param name="School"></param>
        /// <param name="Major"></param>
        /// <param name="ForeignLanguageAbility"></param>
        /// <param name="Certificates"></param>
        public Education(EducationalBackground EducationalBackground, string School, string Major, string ForeignLanguageAbility, string Certificates)
        {
            _EducationalBackground = EducationalBackground;
            _School = School;
            _Major = Major;
            _ForeignLanguageAbility = ForeignLanguageAbility;
            _Certificates = Certificates;
        }

        /// <summary>
        /// �Ļ��̶�
        /// </summary>
        public EducationalBackground EducationalBackground
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

        /// <summary>
        /// ѧУ
        /// </summary>
        public string School
        {
            get
            {
                return _School;
            }
            set
            {
                _School = value;
            }
        }

        /// <summary>
        /// רҵ
        /// </summary>
        public string Major
        {
            get
            {
                return _Major;
            }
            set
            {
                _Major = value;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string ForeignLanguageAbility
        {
            get
            {
                return _ForeignLanguageAbility;
            }
            set
            {
                _ForeignLanguageAbility = value;
            }
        }

        /// <summary>
        /// ֤��
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

        /// <summary>
        /// ��������ѵ����
        /// </summary>
        public List<EducationExperience> EducationExperiences
        {
            get
            {
                return _EducationExperiences;
            }
            set
            {
                _EducationExperiences = value;
            }
        }
        /// <summary>
        /// ��ҵʱ��
        /// </summary>
        public DateTime GraduateTime
        {
            get { return _GraduateTime; }
            set { _GraduateTime = value; }
        }

        #region ����
        /// <summary>
        /// ��дEquals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Education anOtherObj = obj as Education;
            if (anOtherObj == null)
            {
                return false;
            }
            return _EducationalBackground.Equals(anOtherObj._EducationalBackground) &&
                   _School.Equals(anOtherObj._School) &&
                   _Major.Equals(anOtherObj._Major) &&
                   _ForeignLanguageAbility.Equals(anOtherObj._ForeignLanguageAbility) &&
                   JudgeEducationExperience(anOtherObj) &&
                   _GraduateTime.Equals(anOtherObj._GraduateTime) &&
                   _Certificates.Equals(anOtherObj._Certificates);
        }
        /// <summary>
        /// �ж�Education�Ƿ���ͬ
        /// </summary>
        /// <param name="anOtherObj"></param>
        /// <returns></returns>
        private bool JudgeEducationExperience(Education anOtherObj)
        {
            bool retVal = true;
            if (_EducationExperiences.Count != anOtherObj._EducationExperiences.Count)
            {
                retVal = false;
            }
            else
            {
                for (int i = 0; i < _EducationExperiences.Count; i++)
                {
                    if (!_EducationExperiences[i].Equals(anOtherObj._EducationExperiences[i]))
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