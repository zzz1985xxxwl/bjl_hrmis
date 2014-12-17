using System;
using System.Collections.Generic;
using System.Text;
using ShiXin.Security;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 用于列表显示的Contract
    /// </summary>
    public class ContractStringValue
    {
        private readonly Contract contract;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_Contract"></param>
        public ContractStringValue(Contract _Contract)
        {
            contract = _Contract;
        }
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="sources"></param>
        /// <returns></returns>
        public static List<ContractStringValue> Turn(List<Contract> sources)
        {
            List<ContractStringValue> list = new List<ContractStringValue>();
            foreach (Contract item in sources)
            {
                list.Add(new ContractStringValue(item));
            }
            return list;
        }

        #region TextField

        public string WorkAgeString
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.EmployeeDetails != null
                    && contract.Employee.EmployeeDetails.Work != null
                    && contract.Employee.EmployeeDetails.Work.WorkAgeString != null
                        ? contract.Employee.EmployeeDetails.Work.WorkAgeString
                        : null;
            }
        }
        public string WorkPlace
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.EmployeeDetails != null
                    && contract.Employee.EmployeeDetails.Work != null
                    && contract.Employee.EmployeeDetails.Work.WorkPlace != null
                        ? contract.Employee.EmployeeDetails.Work.WorkPlace
                        : null;
            }
        }
        public string Leader
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.Account != null
                    && contract.Employee.Account.Dept != null
                    && contract.Employee.Account.Dept.Leader != null
                    && contract.Employee.Account.Dept.Leader.Name != null
                        ? contract.Employee.Account.Dept.Leader.Name
                        : null;
            }
        }

        public string Name
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.Account != null
                    && contract.Employee.Account.Name != null
                        ? contract.Employee.Account.Name
                        : null;
            }
        }
        public string MobileNum
        {
            get
            {
                return
                contract != null && contract.Employee != null && contract.Employee.Account != null
                && contract.Employee.Account.MobileNum != null
                    ? contract.Employee.Account.MobileNum
                    : null;
            }
        }
        public string Remark
        {
            get
            {
                return
                    contract != null && contract.Remark != null
                        ? contract.Remark.Replace("\r\n", "").Replace("\n", "")
                        : null;
            }
        }
        #endregion

        #region DateTimeField
        public string ContractEndTime
        {
            get
            {
                return contract != null ? contract.EndDate.ToShortDateString() : null;
            }
        }
        public string ContractStartTime
        {
            get
            {
                return contract != null ? contract.StartDate.ToShortDateString() : null;
            }
        }
        public string ProbationTime
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.EmployeeDetails != null
                        ? contract.Employee.EmployeeDetails.ProbationTime.ToShortDateString()
                        : null;
            }
        }
        public string ComeDate
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.EmployeeDetails != null
                    && contract.Employee.EmployeeDetails.Work != null
                        ? contract.Employee.EmployeeDetails.Work.ComeDate.ToShortDateString()
                        : null;
            }
        }
        public string LeaveDate
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.EmployeeDetails != null
                    && contract.Employee.EmployeeDetails.Work != null
                    && contract.Employee.EmployeeDetails.Work.DimissionInfo != null
                        ? contract.Employee.EmployeeDetails.Work.DimissionInfo.DimissionDate.ToShortDateString()
                        : null;
            }
        }
        #endregion

        #region NumField
        public string ContractNum
        {
            get
            {
                return
                    contract != null
                        ? contract.ContractID.ToString()
                        : null;
            }
        }
        public string WorkAgeDecaiml
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.EmployeeDetails != null
                    && contract.Employee.EmployeeDetails.Work != null
                        ? contract.Employee.EmployeeDetails.Work.WorkAgeDecaiml.ToString()
                        : null;
            }
        }
        public string SocietyWorkAge
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.SocWorkAgeAndVacationList != null
                        ? contract.Employee.SocWorkAgeAndVacationList.SocietyWorkAge.ToString()
                        : null;
            }
        }
        public string EmployeeNum
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.Account != null
                        ? contract.Employee.Account.Id.ToString()
                        : null;
            }
        }
        public string AnnualMaintainDays
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.EmployeeAttendance != null
                    && contract.Employee.EmployeeAttendance.Vacation != null
                        ? contract.Employee.EmployeeAttendance.Vacation.SurplusDayNum.ToString()
                        : null;
            }
        }
        public string AdjustMaintainDays
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.EmployeeAttendance != null
                    && contract.Employee.EmployeeAttendance.MonthAttendance != null
                        ? contract.Employee.EmployeeAttendance.MonthAttendance.DaysofAdjustRestRemained.ToString()
                        : null;
            }
        }

        #endregion

        #region StaticEnumField
        public string ContractType
        {
            get
            {
                return
                contract != null && contract.ContractType != null && contract.ContractType.ContractTypeName != null
                    ? contract.ContractType.ContractTypeName
                    : null;
            }

        }
        public string PositionGrade
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.Account != null
                    && contract.Employee.Account.Position != null
                    && contract.Employee.Account.Position.Grade != null
                    && contract.Employee.Account.Position.Grade.Name != null
                        ? contract.Employee.Account.Position.Grade.Name
                        : null;
            }
        }
        public string WorkType
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.EmployeeDetails != null
                    && contract.Employee.EmployeeDetails.Work != null
                    && contract.Employee.EmployeeDetails.Work.WorkType != null
                    && contract.Employee.EmployeeDetails.Work.WorkType.Name != null
                        ? contract.Employee.EmployeeDetails.Work.WorkType.Name
                        : null;
            }
        }
        public string EmployeeType
        {
            get
            {
                return
                    contract != null && contract.Employee != null
                        ? EmployeeTypeUtility.EmployeeTypeDisplay(contract.Employee.EmployeeType)
                        : null;
            }
        }

        #endregion

        #region ActiveEnumField
        public string Position
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.Account != null
                    && contract.Employee.Account.Position != null && contract.Employee.Account.Position.Name != null
                        ? contract.Employee.Account.Position.Name
                        : null;
            }
        }
        public string Company
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.EmployeeDetails != null
                    && contract.Employee.EmployeeDetails.Work != null
                    && contract.Employee.EmployeeDetails.Work.Company != null
                    && contract.Employee.EmployeeDetails.Work.Company.Name != null
                        ? contract.Employee.EmployeeDetails.Work.Company.Name
                        : null;
            }
        }
        #endregion

        #region TreeActiveEnumField

        public string Department
        {
            get
            {
                return
                  contract != null && contract.Employee != null && contract.Employee.Account != null
                  && contract.Employee.Account.Dept != null &&
                    contract.Employee.Account.Dept.Name != null
                        ? contract.Employee.Account.Dept.Name
                        : null;
            }
        }
        #endregion

        #region OtherValue
        public string EmployeeNumDECEncrypt
        {
            get
            {
                return
                    contract != null && contract.Employee != null && contract.Employee.Account != null
                        ? SecurityUtil.DECEncrypt(contract.Employee.Account.Id.ToString())
                        : null;
            }
        }
        public string ContractNumDECEncrypt
        {
            get
            {
                return
                    contract != null
                        ? SecurityUtil.DECEncrypt(contract.ContractID.ToString())
                        : null;
            }
        }

        #endregion
    }
}