using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;

namespace SEP.HRMIS.Entity
{
    public class AssessActivityPaperEntity
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

        private int _AssessActivityID;
        /// <summary>
        /// 
        /// </summary>
        public int AssessActivityID
        {
            get
            {
                return _AssessActivityID;
            }
            set
            {
                _AssessActivityID = value;
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

        private string _FillPerson;
        /// <summary>
        /// 
        /// </summary>
        public string FillPerson
        {
            get
            {
                return _FillPerson;
            }
            set
            {
                _FillPerson = value;
            }
        }

        private DateTime _SubmitTime;
        /// <summary>
        /// 
        /// </summary>
        public DateTime SubmitTime
        {
            get
            {
                return _SubmitTime;
            }
            set
            {
                _SubmitTime = value;
            }
        }

        private string _ChoseIntention;
        /// <summary>
        /// 
        /// </summary>
        public string ChoseIntention
        {
            get
            {
                return _ChoseIntention;
            }
            set
            {
                _ChoseIntention = value;
            }
        }

        private string _Content;
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            get
            {
                return _Content;
            }
            set
            {
                _Content = value;
            }
        }

        private int? _StepIndex;
        /// <summary>
        /// 
        /// </summary>
        public int? StepIndex
        {
            get
            {
                return _StepIndex;
            }
            set
            {
                _StepIndex = value;
            }
        }

        private decimal? _SalaryNow;
        /// <summary>
        /// 
        /// </summary>
        public decimal? SalaryNow
        {
            get
            {
                return _SalaryNow;
            }
            set
            {
                _SalaryNow = value;
            }
        }

        private decimal? _SalaryChange;
        /// <summary>
        /// 
        /// </summary>
        public decimal? SalaryChange
        {
            get
            {
                return _SalaryChange;
            }
            set
            {
                _SalaryChange = value;
            }
        }
        public static SubmitInfo Convert(AssessActivityPaperEntity entity)
        {
            return new SubmitInfo
                       {
                           Choose = entity.ChoseIntention,
                           Comment = entity.Content,
                           FillPerson = entity.FillPerson,
                           StepIndex = entity.StepIndex.GetValueOrDefault(),
                           SubmitTime = entity.SubmitTime,
                           SalaryNow = EmployeeWelfare.ConvertToDecimal(entity.SalaryNow),
                           SalaryChange = EmployeeWelfare.ConvertToDecimal(entity.SalaryChange),
                           SubmitInfoType = SubmitInfoType.RechieveSubmitInfoTypeByID(entity.Type),
                           SubmitInfoID = entity.PKID,
                           AssessActivityID = entity.AssessActivityID
            };
        }
    }
}

