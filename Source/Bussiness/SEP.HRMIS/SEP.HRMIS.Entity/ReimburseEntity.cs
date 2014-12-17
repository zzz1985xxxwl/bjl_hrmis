using System;
using SEP.HRMIS.Model;
using SEP.Model.Departments;

namespace SEP.HRMIS.Entity
{
    /// <summary>
    ///   TReimburse的实体类
    /// </summary>
    public class ReimburseEntity
    {
        private int _PKID;

        /// <summary>
        /// </summary>
        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }

        private int _EmployeeId;

        /// <summary>
        /// </summary>
        public int EmployeeId
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value; }
        }

        private int _DepartmentID;

        /// <summary>
        /// </summary>
        public int DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }

        private DateTime _ApplyDate;

        /// <summary>
        /// </summary>
        public DateTime ApplyDate
        {
            get { return _ApplyDate; }
            set { _ApplyDate = value; }
        }

        private int _ReimburseCategoriesEnum;

        /// <summary>
        /// </summary>
        public int ReimburseCategoriesEnum
        {
            get { return _ReimburseCategoriesEnum; }
            set { _ReimburseCategoriesEnum = value; }
        }

        private int _PaperCount;

        /// <summary>
        /// </summary>
        public int PaperCount
        {
            get { return _PaperCount; }
            set { _PaperCount = value; }
        }

        private DateTime _ConsumeDateFrom;

        /// <summary>
        /// </summary>
        public DateTime ConsumeDateFrom
        {
            get { return _ConsumeDateFrom; }
            set { _ConsumeDateFrom = value; }
        }

        private DateTime _ConsumeDateTo;

        /// <summary>
        /// </summary>
        public DateTime ConsumeDateTo
        {
            get { return _ConsumeDateTo; }
            set { _ConsumeDateTo = value; }
        }

        private string _Destinations;

        /// <summary>
        /// </summary>
        public string Destinations
        {
            get { return _Destinations; }
            set { _Destinations = value; }
        }

        private string _Project;

        /// <summary>
        /// </summary>
        public string Project
        {
            get { return _Project; }
            set { _Project = value; }
        }

        private int _ReimburseStatus;

        /// <summary>
        /// </summary>
        public int ReimburseStatus
        {
            get { return _ReimburseStatus; }
            set { _ReimburseStatus = value; }
        }

        private decimal _TotalCost;

        /// <summary>
        /// </summary>
        public decimal TotalCost
        {
            get { return _TotalCost; }
            set { _TotalCost = value; }
        }

        private string _DepartmentName;

        /// <summary>
        /// </summary>
        public string DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
        }

        private DateTime? _CommitTime;

        /// <summary>
        /// </summary>
        public DateTime? CommitTime
        {
            get { return _CommitTime; }
            set { _CommitTime = value; }
        }

        private DateTime? _BillingTime;

        /// <summary>
        /// </summary>
        public DateTime? BillingTime
        {
            get { return _BillingTime; }
            set { _BillingTime = value; }
        }

        private decimal _OutCityDays;

        /// <summary>
        /// </summary>
        public decimal OutCityDays
        {
            get { return _OutCityDays; }
            set { _OutCityDays = value; }
        }

        private decimal _OutCityAllowance;

        /// <summary>
        /// </summary>
        public decimal OutCityAllowance
        {
            get { return _OutCityAllowance; }
            set { _OutCityAllowance = value; }
        }

        private string _Remark;

        /// <summary>
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private int _CurrencyType;

        /// <summary>
        /// </summary>
        public int CurrencyType
        {
            get { return _CurrencyType; }
            set { _CurrencyType = value; }
        }

        public int ExchangeRateID { get; set; }
        public string ExchangeRateName { get; set; }
        public string ExchangeSymbol { get; set; }
        public decimal ExchangeRate { get; set; }
        public string Discription { get; set; }

        public static Reimburse ConvertToReimburse(ReimburseEntity entity)
        {
            Reimburse reimburse = null;
            if (entity == null)
            {
                return reimburse;
            }
            reimburse = new Reimburse(entity.ApplyDate,
                                      (ReimburseStatusEnum)entity.ReimburseStatus);
            reimburse.ReimburseID = entity.PKID;
            reimburse.ApplierID = entity.EmployeeId;
            reimburse.Department =
                new Department(entity.DepartmentID, entity.DepartmentName);
            reimburse.ReimburseCategoriesEnum = Model.ReimburseCategoriesEnum.GetById(entity.ReimburseCategoriesEnum);
            reimburse.PaperCount = entity.PaperCount;
            reimburse.ConsumeDateFrom = entity.ConsumeDateFrom;
            reimburse.ConsumeDateTo = entity.ConsumeDateTo;
            reimburse.Destinations = entity.Destinations;
            reimburse.ProjectName = entity.Project;
            reimburse.TotalCost = entity.TotalCost;
            reimburse.Remark = entity.Remark;
            reimburse.Discription = entity.Discription;
            reimburse.OutCityAllowance = entity.OutCityAllowance;
            reimburse.OutCityDays = entity.OutCityDays;
            if (entity.BillingTime != null)
            {
                reimburse.BillingTime = entity.BillingTime.ToString();
            }
            if (entity.CommitTime != null)
            {
                reimburse.CommitTime = entity.CommitTime.ToString();
            }
            reimburse.ExchangeRateName = entity.ExchangeRateName;
            reimburse.ExchangeSymbol = entity.ExchangeSymbol;
            reimburse.ExchangeRateID = entity.ExchangeRateID;
            reimburse.ExchangeRate = entity.ExchangeRate;
            return reimburse;
        }
    }
}