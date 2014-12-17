using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;

namespace SEP.HRMIS.Entity
{
    /// <summary>
    /// TAssessActivityItem的实体类
    /// </summary>
    public class AssessActivityItemEntity
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

        private int _AssessActivityPaperID;
        /// <summary>
        /// 
        /// </summary>
        public int AssessActivityPaperID
        {
            get
            {
                return _AssessActivityPaperID;
            }
            set
            {
                _AssessActivityPaperID = value;
            }
        }

        private int _Type;
        /// <summary>
        /// 
        /// </summary>
        public int Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }

        private string _Question;
        /// <summary>
        /// 
        /// </summary>
        public string Question
        {
            get
            {
                return _Question;
            }
            set
            {
                _Question = value;
            }
        }

        private decimal _Grade;
        /// <summary>
        /// 
        /// </summary>
        public decimal Grade
        {
            get
            {
                return _Grade;
            }
            set
            {
                _Grade = value;
            }
        }

        private string _Note;
        /// <summary>
        /// 
        /// </summary>
        public string Note
        {
            get
            {
                return _Note;
            }
            set
            {
                _Note = value;
            }
        }

        private string _Option;
        /// <summary>
        /// 
        /// </summary>
        public string Option
        {
            get
            {
                return _Option;
            }
            set
            {
                _Option = value;
            }
        }

        private int _Classfication;
        /// <summary>
        /// 
        /// </summary>
        public int Classfication
        {
            get
            {
                return _Classfication;
            }
            set
            {
                _Classfication = value;
            }
        }

        private string _Description;
        /// <summary>
        /// 
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

        private int _AssessTemplateItemType;
        /// <summary>
        /// 
        /// </summary>
        public int AssessTemplateItemType
        {
            get
            {
                return _AssessTemplateItemType;
            }
            set
            {
                _AssessTemplateItemType = value;
            }
        }

        private decimal _Weight;
        /// <summary>
        /// 
        /// </summary>
        public decimal Weight
        {
            get
            {
                return _Weight;
            }
            set
            {
                _Weight = value;
            }
        }

        public int AssessActivityID { get; set; }

        public static AssessActivityItem Convert(AssessActivityItemEntity entity)
        {
            return  new AssessActivityItem(entity.Question,entity.Option, (ItemClassficationEmnu)entity.Classfication, entity.Description)
                                                        {
                                                            Grade = entity.Grade,
                                                            Note = entity.Note,
                                                            AssessTemplateItemType =
                                                                (AssessTemplateItemType) entity.AssessTemplateItemType,
                                                            Weight = entity.Weight,
                                                            AssessActivityItemType =
                                                                (AssessActivityItemType) entity.Type
                                                        };
        }

    }
}

