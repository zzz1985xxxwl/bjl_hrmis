using System;
using SEP.Model.Positions;

namespace SEP.HRMIS.Entity
{
    public class PositionEntity
    {
        private int _PKID;

        /// <summary>
        /// </summary>
        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }

        private string _PositionName;

        /// <summary>
        /// </summary>
        public string PositionName
        {
            get { return _PositionName; }
            set { _PositionName = value; }
        }

        private int? _LevelId;

        /// <summary>
        /// </summary>
        public int? LevelId
        {
            get { return _LevelId; }
            set { _LevelId = value; }
        }

        private string _PositionDescription;

        /// <summary>
        /// </summary>
        public string PositionDescription
        {
            get { return _PositionDescription; }
            set { _PositionDescription = value; }
        }

        private string _Number;

        /// <summary>
        /// </summary>
        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }

        private int? _Reviewer;

        /// <summary>
        /// </summary>
        public int? Reviewer
        {
            get { return _Reviewer; }
            set { _Reviewer = value; }
        }

        private int _PositionStatus;

        /// <summary>
        /// </summary>
        public int PositionStatus
        {
            get { return _PositionStatus; }
            set { _PositionStatus = value; }
        }

        private string _Version;

        /// <summary>
        /// </summary>
        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        private DateTime? _Commencement;

        /// <summary>
        /// </summary>
        public DateTime? Commencement
        {
            get { return _Commencement; }
            set { _Commencement = value; }
        }

        private string _Summary;

        /// <summary>
        /// </summary>
        public string Summary
        {
            get { return _Summary; }
            set { _Summary = value; }
        }

        private string _MainDuties;

        /// <summary>
        /// </summary>
        public string MainDuties
        {
            get { return _MainDuties; }
            set { _MainDuties = value; }
        }

        private string _ReportScope;

        /// <summary>
        /// </summary>
        public string ReportScope
        {
            get { return _ReportScope; }
            set { _ReportScope = value; }
        }

        private string _ControlScope;

        /// <summary>
        /// </summary>
        public string ControlScope
        {
            get { return _ControlScope; }
            set { _ControlScope = value; }
        }

        private string _Coordination;

        /// <summary>
        /// </summary>
        public string Coordination
        {
            get { return _Coordination; }
            set { _Coordination = value; }
        }

        private string _Authority;

        /// <summary>
        /// </summary>
        public string Authority
        {
            get { return _Authority; }
            set { _Authority = value; }
        }

        private string _Education;

        /// <summary>
        /// </summary>
        public string Education
        {
            get { return _Education; }
            set { _Education = value; }
        }

        private string _ProfessionalBackground;

        /// <summary>
        /// </summary>
        public string ProfessionalBackground
        {
            get { return _ProfessionalBackground; }
            set { _ProfessionalBackground = value; }
        }

        private string _WorkExperience;

        /// <summary>
        /// </summary>
        public string WorkExperience
        {
            get { return _WorkExperience; }
            set { _WorkExperience = value; }
        }

        private string _Qualification;

        /// <summary>
        /// </summary>
        public string Qualification
        {
            get { return _Qualification; }
            set { _Qualification = value; }
        }

        private string _Competence;

        /// <summary>
        /// </summary>
        public string Competence
        {
            get { return _Competence; }
            set { _Competence = value; }
        }

        private string _OtherRequirements;

        /// <summary>
        /// </summary>
        public string OtherRequirements
        {
            get { return _OtherRequirements; }
            set { _OtherRequirements = value; }
        }

        private string _KnowledgeAndSkills;

        /// <summary>
        /// </summary>
        public string KnowledgeAndSkills
        {
            get { return _KnowledgeAndSkills; }
            set { _KnowledgeAndSkills = value; }
        }

        private string _RelatedProcesses;

        /// <summary>
        /// </summary>
        public string RelatedProcesses
        {
            get { return _RelatedProcesses; }
            set { _RelatedProcesses = value; }
        }

        private string _ManagementSkills;

        /// <summary>
        /// </summary>
        public string ManagementSkills
        {
            get { return _ManagementSkills; }
            set { _ManagementSkills = value; }
        }

        private string _AuxiliarySkills;

        /// <summary>
        /// </summary>
        public string AuxiliarySkills
        {
            get { return _AuxiliarySkills; }
            set { _AuxiliarySkills = value; }
        }

        public static Position Convert(PositionEntity entity)
        {
            Position model = new Position();
            model.PositionStatus = SEP.Model.Positions.PositionStatus.GetById(entity.PositionStatus);
            model.Id = entity.PKID;
            model.Name = entity.PositionName;
            model.Description = entity.PositionDescription;
            return model;
        }
    }
}