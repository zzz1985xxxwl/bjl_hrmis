//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: Position.cs
// ������: colbert
// ��������: 2009-02-02
// ����: ְλ
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.Model.Positions
{
    /// <summary>
    /// ְλ
    /// </summary>
    [Serializable]
    public class Position
    {
        public Position()
        {
        }

        public Position(int id, string name, PositionGrade level)
        {
            _Id = id;
            _Name = name;
            _Level = level;
        }

        private int _Id;
        private string _Name = string.Empty;
        private string _Description = string.Empty;
        private PositionGrade _Level = new PositionGrade();
        private List<PositionNature> _Nature = new List<PositionNature>();
        private string _Number = string.Empty;
        private Account _Reviewer = new Account();
        private PositionStatus _PositionStatus = PositionStatus.All;
        private string _Version = string.Empty;
        private DateTime _Commencement;

        private string _Summary = string.Empty;
        private string _MainDuties = string.Empty;
        private string _ReportScope = string.Empty;
        private string _ControlScope = string.Empty;
        private string _Coordination = string.Empty;
        private string _Authority = string.Empty;

        private string _Education = string.Empty;
        private string _ProfessionalBackground = string.Empty;
        private string _WorkExperience = string.Empty;
        private string _Qualification = string.Empty;
        private string _Competence = string.Empty;
        private string _OtherRequirements = string.Empty;
        private string _KnowledgeAndSkills = string.Empty;
        private string _RelatedProcesses = string.Empty;
        private string _ManagementSkills = string.Empty;
        private string _AuxiliarySkills = string.Empty;

        private List<Department> _Departments = new List<Department>();
        private List<Account> _Members = new List<Account>();

        public int ParameterID
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        /// <summary>
        /// ְλ����
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        /// <summary>
        /// �ȼ�
        /// </summary>
        public PositionGrade Grade
        {
            get
            {
                return _Level;
            }
            set
            {
                _Level = value;
            }
        }

        /// <summary>
        /// ��λ����
        /// </summary>
        public List<PositionNature> Nature
        {
            get
            {
                return _Nature;
            }
            set
            {
                _Nature = value;
            }
        }

        /// <summary>
        /// ���
        /// </summary>
        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }

        /// <summary>
        /// �����
        /// </summary>
        public Account Reviewer
        {
            get { return _Reviewer; }
            set { _Reviewer = value; }
        }

        /// <summary>
        /// ��׼/����
        /// </summary>
        public PositionStatus PositionStatus
        {
            get { return _PositionStatus; }
            set { _PositionStatus = value; }
        }

        /// <summary>
        /// �汾
        /// </summary>
        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        /// <summary>
        /// ��Ч����
        /// </summary>
        public DateTime Commencement
        {
            get { return _Commencement; }
            set { _Commencement = value; }
        }

        /// <summary>
        /// ������Ҫ
        /// </summary>
        public string Summary
        {
            get { return _Summary; }
            set { _Summary = value; }
        }

        /// <summary>
        /// ��Ҫְ��
        /// </summary>
        public string MainDuties
        {
            get { return _MainDuties; }
            set { _MainDuties = value; }
        }

        /// <summary>
        /// ���淶Χ
        /// </summary>
        public string ReportScope
        {
            get { return _ReportScope; }
            set { _ReportScope = value; }
        }

        /// <summary>
        /// ���Ʒ�Χ
        /// </summary>
        public string ControlScope
        {
            get { return _ControlScope; }
            set { _ControlScope = value; }
        }

        /// <summary>
        /// ����Э����ϵ
        /// </summary>
        public string Coordination
        {
            get { return _Coordination; }
            set { _Coordination = value; }
        }

        /// <summary>
        /// Ȩ��
        /// </summary>
        public string Authority
        {
            get { return _Authority; }
            set { _Authority = value; }
        }

        /// <summary>
        /// ѧ��
        /// </summary>
        public string Education
        {
            get { return _Education; }
            set { _Education = value; }
        }

        /// <summary>
        /// רҵ����
        /// </summary>
        public string ProfessionalBackground
        {
            get { return _ProfessionalBackground; }
            set { _ProfessionalBackground = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string WorkExperience
        {
            get { return _WorkExperience; }
            set { _WorkExperience = value; }
        }

        /// <summary>
        /// ����Ҫ��
        /// </summary>
        public string Qualification
        {
            get { return _Qualification; }
            set { _Qualification = value; }
        }

        /// <summary>
        /// ʤ������
        /// </summary>
        public string Competence
        {
            get { return _Competence; }
            set { _Competence = value; }
        }

        /// <summary>
        /// ����Ҫ��
        /// </summary>
        public string OtherRequirements
        {
            get { return _OtherRequirements; }
            set { _OtherRequirements = value; }
        }

        /// <summary>
        /// ��λ֪ʶ�뼼��
        /// </summary>
        public string KnowledgeAndSkills
        {
            get { return _KnowledgeAndSkills; }
            set { _KnowledgeAndSkills = value; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public string RelatedProcesses
        {
            get { return _RelatedProcesses; }
            set { _RelatedProcesses = value; }
        }

        /// <summary>
        /// ���˹�����
        /// </summary>
        public string ManagementSkills
        {
            get { return _ManagementSkills; }
            set { _ManagementSkills = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string AuxiliarySkills
        {
            get { return _AuxiliarySkills; }
            set { _AuxiliarySkills = value; }
        }

        /// <summary>
        /// ���ò���
        /// </summary>
        public List<Department> Departments
        {
            get { return _Departments; }
            set { _Departments = value; }
        }

        /// <summary>
        /// ����Ա��
        /// </summary>
        public List<Account> Members
        {
            get
            {
                return _Members;
            }
            set
            {
                _Members = value;
            }
        }
        public bool IsEqual(Position obj)
        {
            if (obj.Id != Id
                || obj.Name != Name
                //|| obj.Grade.Id != Grade.Id
                || obj.Description != Description
                || obj.Number != Number
                || obj.PositionStatus.Id != PositionStatus.Id
                || obj.Version != Version
                || obj.Commencement != Commencement
                || obj.Summary != Summary
                || obj.MainDuties != MainDuties
                || obj.ReportScope != ReportScope
                || obj.ControlScope != ControlScope
                || obj.Coordination != Coordination
                || obj.Authority != Authority
                || obj.Education != Education
                || obj.ProfessionalBackground != ProfessionalBackground
                || obj.WorkExperience != WorkExperience
                || obj.Qualification != Qualification
                || obj.Competence != Competence
                || obj.OtherRequirements != OtherRequirements
                || obj.KnowledgeAndSkills != KnowledgeAndSkills
                || obj.RelatedProcesses != RelatedProcesses
                || obj.ManagementSkills != ManagementSkills
                || obj.AuxiliarySkills != AuxiliarySkills
                || !PositionNature.PositionNaturesIsEqual(obj.Nature, Nature)
                || !Department.DepartmentsIsEqual(obj.Departments, Departments)
                )
            {
                return false;
            }
            if ((obj.Reviewer != null && Reviewer == null)
                || (obj.Reviewer == null && Reviewer != null))
            {
                return false;
            }
            if (obj.Reviewer != null && Reviewer != null && obj.Reviewer.Id != Reviewer.Id)
            {
                return false;
            }
            return true;
        }


        public static Position FindPosition(List<Position> positions, int positionID)
        {
            foreach (Position position in positions)
            {
                if (position.Id == positionID)
                    return position;
            }
            return null;
        }

        public static void OrderByName(List<Position> retpositions)
        {
            Position temp;
            for (int i = 0; i < retpositions.Count - 1; i++)
            {
                for (int j = 1; j < retpositions.Count; j++)
                    if (retpositions[i].Name.CompareTo(retpositions[j].Name) > 0)
                    {
                        temp = retpositions[i];
                        retpositions[i] = retpositions[j];
                        retpositions[j] = temp;
                    }
            }
        }
    }
}
