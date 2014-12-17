using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 报销数据
    /// </summary>
    public class ReimburseDal : IReimburse
    {
        private readonly EmployeeDal _EmployeeDal = new EmployeeDal();

        #region Reimburse const
        private const string _ParmPKID = "@PKID";
        private const string _ParmEmployeeId = "@EmployeeId";
        private const string _ParmDepartmentID = "@DepartmentID";
        private const string _ParmApplyDate = "@ApplyDate";
        private const string _ParmReimburseCategoriesEnum = "@ReimburseCategoriesEnum";
        private const string _ParmPaperCount = "@PaperCount";
        private const string _ParmConsumeDateFrom = "@ConsumeDateFrom";
        private const string _ParmConsumeDateTo = "@ConsumeDateTo";
        private const string _ParmDestinations = "@Destinations";
        private const string _ParmCustomerID = "@CustomerID";
        private const string _ParmCustomerName = "@CustomerName";

        private const string _ParmProject = "@Project";
        private const string _ParmReimburseStatus = "@ReimburseStatus";
        private const string _ParmTotalCost = "@TotalCost";
        private const string _ParmDepartmentName = "@DepartmentName";
        private const string _ParmDiyProcess = "@DiyProcess";
        private const string _ParmNextStepIndex = "@NextStepIndex";
        private const string _ParmBillingTime = "@BillingTime";
        private const string _ParmCommitTime = "@CommitTime";

        private const string _ParmOutCityDays = "@OutCityDays";
        private const string _ParmOutCityAllowance = "@OutCityAllowance";
        private const string _ParmRemark = "@Remark";

        private const string _ParmTotalCostFrom = "@TotalCostFrom";
        private const string _ParmTotalCostTo = "@TotalCostTo";
        private const string _ParmApplyDateFrom = "@ApplyDateFrom";
        private const string _ParmApplyDateTo = "@ApplyDateTo";
        private const string _ParmBillingTimeFrom = "@BillingTimeFrom";
        private const string _ParmBillingTimeTo = "@BillingTimeTo";
        private const string _ParaDateTime = "@DateTime";
        private const string _ParmCompanyID = "@CompanyID";
        private const string _ParmFinishStatus = "@FinishStatus";
        private const string _ParmCurrencyType = "@CurrencyType";
        private const string _ParmExchangeRateID = "@ExchangeRateID";
        private const string _ParmDiscription = "@Discription";

        private const string _DBPKID = "PKID";
        private const string _DBEmployeeId = "EmployeeId";
        private const string _DBDepartmentID = "DepartmentID";
        private const string _DBApplyDate = "ApplyDate";
        private const string _DBReimburseCategoriesEnum = "ReimburseCategoriesEnum";
        private const string _DBPaperCount = "PaperCount";
        private const string _DBConsumeDateFrom = "ConsumeDateFrom";
        private const string _DBConsumeDateTo = "ConsumeDateTo";
        private const string _DBDestinations = "Destinations";
        private const string _DBCustomerName = "CustomerID";
        private const string _DBProject = "Project";
        private const string _DBReimburseStatus = "ReimburseStatus";
        private const string _DBTotalCost = "TotalCost";
        private const string _DBDepartmentName = "DepartmentName";
        private const string _DBDiyProcess = "DiyProcess";
        private const string _DBNextStepIndex = "NextStepIndex";
        private const string _DBBillingTime = "BillingTime";
        private const string _DBCommitTime = "CommitTime";
        private const string _DBOutCityDays = "OutCityDays";
        private const string _DBOutCityAllowance = "OutCityAllowance";
        private const string _DBRemark = "Remark";
        private const string _DBError = "数据库访问错误!";
        private const string _DBCount = "countId";

        private const string _DBReimburseId = "ReimburseId";
        private const string _DBReimburseItemId = "ReimburseItemId";
        private const string _DBCurrencyType = "CurrencyType";
        private const string _DBExchangeRateName = "ExchangeRateName";
        private const string _DBExchangeRate = "ExchangeRate";

        private const string _DBExchangeRateID = "ExchangeRateID";
        private const string _DBExchangeSymbol = "ExchangeSymbol";
        private const string _DBDiscription = "Discription";
        #endregion

        #region ReimburseItem const
        private const string _ParmReimburseID = "@ReimburseID";
        private const string _ParmReimburseType = "@ReimburseType";
        private const string _ParmConsumePlace = "@ConsumePlace";
        private const string _ParmProjectName = "@ProjectName";
        private const string _ParmReason = "@Reason";

        private const string _DBReimburseType = "ReimburseType";
        private const string _DBConsumePlace = "ConsumePlace";
        private const string _DBProjectName = "ProjectName";
        private const string _DBReason = "Reason";

        #endregion

        #region ReimburseFlow const

        private const string _ParmOperatorID = "@OperatorID";
        private const string _ParmOperationTime = "@OperationTime";

        private const string _DBOperatorID = "OperatorID";
        private const string _DBOperationTime = "OperationTime";

        private SqlConnection _Conn;
        private SqlTransaction _Trans;

        #endregion


        /// <summary>
        /// 新增报销
        /// </summary>
        /// <param name="employeeReimburse"></param>
        public void InsertEmployeeReimburse(Employee employeeReimburse)
        {
            try
            {
                foreach (Reimburse eachReimburse in employeeReimburse.Reimburses)
                {
                    eachReimburse.ReimburseID = InsertReimburse(employeeReimburse, eachReimburse);
                    if (eachReimburse.ReimburseItems != null)
                    {
                        foreach (ReimburseItem eachReimburseItem in eachReimburse.ReimburseItems)
                        {
                            eachReimburseItem.ReimburseItemID =
                                InsertReimburseItem(eachReimburse.ReimburseID, eachReimburseItem);
                        }
                    }
                    if (eachReimburse.ReimburseFlows != null)
                    {
                        foreach (ReimburseFlow eachReimburseFlow in eachReimburse.ReimburseFlows)
                        {
                            eachReimburseFlow.ReimburseFlowID =
                                InsertReimburseFlow(eachReimburse.ReimburseID, eachReimburseFlow);
                        }
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
        }

        /// <summary>
        /// 新增报销
        /// </summary>
        /// <param name="reimburse"></param>
        private void InsertEmployeeReimburse(Reimburse reimburse)
        {
            try
            {

                if (reimburse.ReimburseItems != null)
                {
                    foreach (ReimburseItem eachReimburseItem in reimburse.ReimburseItems)
                    {
                        eachReimburseItem.ReimburseItemID =
                            InsertReimburseItem(reimburse.ReimburseID, eachReimburseItem);
                    }
                }
                if (reimburse.ReimburseFlows != null)
                {
                    foreach (ReimburseFlow eachReimburseFlow in reimburse.ReimburseFlows)
                    {
                        eachReimburseFlow.ReimburseFlowID =
                            InsertReimburseFlow(reimburse.ReimburseID, eachReimburseFlow);
                    }
                }

            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
        }

        public Employee GetEmployeeReimburseByEmployeeID(int employeeID)
        {
            Employee employee = _EmployeeDal.GetEmployeeByAccountID(employeeID);

            GetReimburseByEmployeeID(employee);
            return employee;

        }
        public List<Reimburse> GetReimburseByEmployeeIDConsumeTime
            (int employeeId, DateTime consumeFrom, DateTime consumeTo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmEmployeeId, SqlDbType.Int).Value = employeeId;
            cmd.Parameters.Add(_ParmConsumeDateFrom, SqlDbType.DateTime).Value = consumeFrom;
            cmd.Parameters.Add(_ParmConsumeDateTo, SqlDbType.DateTime).Value = consumeTo;

            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetReimburseByEmployeeIDConsumeTime", cmd))
            {
                List<Reimburse> Reimburses = new List<Reimburse>();
                while (sdr.Read())
                {
                    Reimburse reimburse =
                        new Reimburse(Convert.ToDateTime(sdr[_DBApplyDate]), ReimburseStatusEnum.Reimbursed);
                    reimburse.ReimburseCategoriesEnum = ReimburseCategoriesEnum.GetById(Convert.ToInt32(sdr[_DBReimburseCategoriesEnum]));
                    reimburse.TotalCost = (decimal)(sdr[_DBTotalCost]);
                    reimburse.OutCityAllowance = (decimal)(sdr[_DBOutCityAllowance]);
                    reimburse.ReimburseID = Convert.ToInt32(sdr[_DBPKID]);
                    reimburse.ReimburseItems = new List<ReimburseItem>();
                    ReimburseItem reimburseItem = new ReimburseItem((ReimburseTypeEnum)sdr[_DBReimburseType],
                                          Convert.ToDecimal(sdr[_DBTotalCost]), sdr[_DBProjectName].ToString());
                    reimburseItem.ConsumePlace = sdr[_DBConsumePlace].ToString();
                    reimburseItem.Reason = sdr[_DBReason].ToString();
                    reimburse.ReimburseItems.Add(reimburseItem);
                    //    new ReimburseItem((ReimburseTypeEnum) sdr[_DBReimburseType],
                    //                      Convert.ToDateTime(sdr[_DBConsumeDateFrom]),
                    //                      Convert.ToDateTime(sdr[_DBConsumeDateTo]), Convert.ToInt32(sdr[_DBPaperCount]),
                    //                      Convert.ToDecimal(sdr[_DBTotalCost]), sdr[_DBProjectName].ToString());
                    //reimburseItem.ConsumePlace = sdr[_DBConsumePlace].ToString();
                    //reimburseItem.Reason = sdr[_DBReason].ToString();
                    //reimburse.ReimburseItems.Add(reimburseItem);
                    Reimburses.Add(reimburse);
                }
                return Reimburses;
            }
        }

        public List<Reimburse> GetReimburseByEmployeeIDBillingTime
    (int employeeId, DateTime billingFrom, DateTime billingTo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmEmployeeId, SqlDbType.Int).Value = employeeId;
            cmd.Parameters.Add(_ParmConsumeDateFrom, SqlDbType.DateTime).Value = billingFrom;
            cmd.Parameters.Add(_ParmConsumeDateTo, SqlDbType.DateTime).Value = billingTo;

            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetReimburseByEmployeeIDBillingTime", cmd))
            {
                List<Reimburse> Reimburses = new List<Reimburse>();
                while (sdr.Read())
                {
                    Reimburse reimburse =
                        new Reimburse(Convert.ToDateTime(sdr[_DBApplyDate]), ReimburseStatusEnum.Reimbursed);
                    reimburse.ReimburseCategoriesEnum = ReimburseCategoriesEnum.GetById(Convert.ToInt32(sdr[_DBReimburseCategoriesEnum]));
                    reimburse.TotalCost = (decimal)(sdr[_DBTotalCost]);
                    reimburse.OutCityAllowance = (decimal)(sdr[_DBOutCityAllowance]);
                    reimburse.ReimburseID = Convert.ToInt32(sdr[_DBPKID]);
                    reimburse.ReimburseItems = new List<ReimburseItem>();
                    ReimburseItem reimburseItem = new ReimburseItem((ReimburseTypeEnum)sdr[_DBReimburseType],
                                          Convert.ToDecimal(sdr[_DBTotalCost]), sdr[_DBProjectName].ToString());
                    reimburseItem.ConsumePlace = sdr[_DBConsumePlace].ToString();
                    reimburseItem.Reason = sdr[_DBReason].ToString();
                    reimburseItem.ExchangeRate = Convert.ToDecimal(sdr[_DBExchangeRate]);
                    reimburse.ReimburseItems.Add(reimburseItem);
                    //    new ReimburseItem((ReimburseTypeEnum) sdr[_DBReimburseType],
                    //                      Convert.ToDateTime(sdr[_DBConsumeDateFrom]),
                    //                      Convert.ToDateTime(sdr[_DBConsumeDateTo]), Convert.ToInt32(sdr[_DBPaperCount]),
                    //                      Convert.ToDecimal(sdr[_DBTotalCost]), sdr[_DBProjectName].ToString());
                    //reimburseItem.ConsumePlace = sdr[_DBConsumePlace].ToString();
                    //reimburseItem.Reason = sdr[_DBReason].ToString();
                    //reimburse.ReimburseItems.Add(reimburseItem);
                    Reimburses.Add(reimburse);
                }
                return Reimburses;
            }
        }

        public List<Reimburse> GetReimburseByCondition(int departmentId, ReimburseStatusEnum statusEnum, int reimburseCategoriesEnumID,
                                                        decimal? totalcostfrom,
                                                       decimal? totalcostto, DateTime? applydateFrom,
                                                       DateTime? applydateTo, DateTime? billtimeFrom, DateTime? billtimeTo,
                                                        int companyID, int finishStatus)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmDepartmentID, SqlDbType.Int).Value = departmentId;
            cmd.Parameters.Add(_ParmReimburseStatus, SqlDbType.Int).Value = (int)statusEnum;
            cmd.Parameters.Add(_ParmReimburseCategoriesEnum, SqlDbType.Int).Value = reimburseCategoriesEnumID;
            cmd.Parameters.Add(_ParmTotalCostFrom, SqlDbType.Decimal, 2).Value = totalcostfrom.HasValue ? (object)totalcostfrom.Value : DBNull.Value;
            cmd.Parameters.Add(_ParmTotalCostTo, SqlDbType.Decimal).Value = totalcostto.HasValue ? (object)totalcostto.Value : DBNull.Value;
            cmd.Parameters.Add(_ParmApplyDateFrom, SqlDbType.DateTime).Value = applydateFrom.HasValue ? (object)applydateFrom.Value : DBNull.Value;
            cmd.Parameters.Add(_ParmApplyDateTo, SqlDbType.DateTime).Value = applydateTo.HasValue ? (object)applydateTo.Value : DBNull.Value;
            cmd.Parameters.Add(_ParmBillingTimeFrom, SqlDbType.DateTime).Value = billtimeFrom.HasValue ? (object)billtimeFrom.Value : DBNull.Value;
            cmd.Parameters.Add(_ParmBillingTimeTo, SqlDbType.DateTime).Value = billtimeTo.HasValue ? (object)billtimeTo.Value : DBNull.Value;
            cmd.Parameters.Add(_ParmCompanyID, SqlDbType.Int).Value = companyID;
            cmd.Parameters.Add(_ParmFinishStatus, SqlDbType.Int).Value = finishStatus;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetReimburseByCondition", cmd))
            {
                List<Reimburse> Reimburses = new List<Reimburse>();
                while (sdr.Read())
                {
                    Reimburse reimburse = GetReimburseFromDB(sdr);
                    Reimburses.Add(reimburse);
                    GetReimburseItemByReimburseID(reimburse);
                    //GetReimburseFlowByReimburseID(reimburse);
                }
                return Reimburses;
            }
        }

        public void UpdateEmployeeReimburse(Employee employeeReimburse)
        {
            try
            {
                foreach (Reimburse eachReimburse in employeeReimburse.Reimburses)
                {
                    UpdateEmployeeReimburse(eachReimburse);
                    DeleteReimburseFlowByReimburseID(eachReimburse.ReimburseID);
                    DeleteReimburseItemByReimburseID(eachReimburse.ReimburseID);

                    if (eachReimburse.ReimburseItems != null)
                    {
                        foreach (ReimburseItem eachReimburseItem in eachReimburse.ReimburseItems)
                        {
                            eachReimburseItem.ReimburseItemID =
                                InsertReimburseItem(eachReimburse.ReimburseID, eachReimburseItem);
                        }
                    }
                    if (eachReimburse.ReimburseFlows != null)
                    {
                        foreach (ReimburseFlow eachReimburseFlow in eachReimburse.ReimburseFlows)
                        {
                            eachReimburseFlow.ReimburseFlowID =
                                InsertReimburseFlow(eachReimburse.ReimburseID, eachReimburseFlow);
                        }
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
        }

        public void DeleteEmployeeReimburse(Employee employeeReimburse)
        {
            try
            {
                foreach (Reimburse eachReimburse in employeeReimburse.Reimburses)
                {
                    DeleteReimburseFlowByReimburseID(eachReimburse.ReimburseID);
                    DeleteReimburseItemByReimburseID(eachReimburse.ReimburseID);
                }
                DeleteReimburseByEmployeeID(employeeReimburse.Account.Id);
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }

        }

        public void UpdateEmployeeReimburse(Reimburse reimburse)
        {
            try
            {
                UpdateReimburse(reimburse);
                DeleteEmployeeReimburse(reimburse);
                InsertEmployeeReimburse(reimburse);
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
        }

        public void UpdateReimburse(Reimburse reimburse)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = reimburse.ReimburseID;
            cmd.Parameters.Add(_ParmReimburseCategoriesEnum, SqlDbType.Int).Value = Convert.ToInt32(reimburse.ReimburseCategoriesEnum.Id);
            cmd.Parameters.Add(_ParmPaperCount, SqlDbType.Int).Value = reimburse.PaperCount;
            cmd.Parameters.Add(_ParmDestinations, SqlDbType.NVarChar, 50).Value = reimburse.Destinations;
            // cmd.Parameters.Add(_ParmCustomerName, SqlDbType.NVarChar, 50).Value = reimburse.CustomerID;
            cmd.Parameters.Add(_ParmProject, SqlDbType.NVarChar, 50).Value = reimburse.ProjectName;
            cmd.Parameters.Add(_ParmConsumeDateFrom, SqlDbType.DateTime).Value = reimburse.ConsumeDateFrom;
            cmd.Parameters.Add(_ParmConsumeDateTo, SqlDbType.DateTime).Value = reimburse.ConsumeDateTo;

            cmd.Parameters.Add(_ParmBillingTime, SqlDbType.DateTime).Value = reimburse.BillingTime;
            cmd.Parameters.Add(_ParmTotalCost, SqlDbType.Decimal).Value = reimburse.TotalCost;
            cmd.Parameters.Add(_ParmReimburseStatus, SqlDbType.Int).Value = reimburse.ReimburseStatus;
            cmd.Parameters.Add(_ParmCommitTime, SqlDbType.DateTime).Value = reimburse.CommitTime;
            cmd.Parameters.Add(_ParmRemark, SqlDbType.NVarChar, 500).Value = reimburse.Remark;
            cmd.Parameters.Add(_ParmDiscription, SqlDbType.NVarChar, 500).Value = reimburse.Discription;
            cmd.Parameters.Add(_ParmOutCityAllowance, SqlDbType.Decimal).Value = reimburse.OutCityAllowance;
            cmd.Parameters.Add(_ParmOutCityDays, SqlDbType.Decimal).Value = reimburse.OutCityDays;
            cmd.Parameters.Add(_ParmApplyDate, SqlDbType.DateTime).Value = reimburse.ApplyDate;
            cmd.Parameters.Add(_ParmExchangeRateID, SqlDbType.Int).Value = reimburse.ExchangeRateID;
            SqlHelper.ExecuteNonQuery("UpdateReimburseStatus", cmd);
        }

        public void DeleteEmployeeReimburse(Reimburse reimburse)
        {
            try
            {
                DeleteReimburseFlowByReimburseID(reimburse.ReimburseID);
                DeleteReimburseItemByReimburseID(reimburse.ReimburseID);
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }

        }


        #region Reimburse

        private int InsertReimburse(Employee employee, Reimburse reimburse)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_ParmEmployeeId, SqlDbType.Int).Value = employee.Account.Id;
            cmd.Parameters.Add(_ParmDepartmentID, SqlDbType.Int).Value = reimburse.Department.DepartmentID;
            cmd.Parameters.Add(_ParmApplyDate, SqlDbType.DateTime).Value = reimburse.ApplyDate;
            cmd.Parameters.Add(_ParmReimburseCategoriesEnum, SqlDbType.Int).Value = Convert.ToInt32(reimburse.ReimburseCategoriesEnum.Id);
            cmd.Parameters.Add(_ParmPaperCount, SqlDbType.Int).Value = reimburse.PaperCount;
            cmd.Parameters.Add(_ParmConsumeDateFrom, SqlDbType.DateTime).Value = reimburse.ConsumeDateFrom;
            cmd.Parameters.Add(_ParmConsumeDateTo, SqlDbType.DateTime).Value = reimburse.ConsumeDateTo;
            cmd.Parameters.Add(_ParmDestinations, SqlDbType.NVarChar, 50).Value = reimburse.Destinations;
            //remove by liudan 2009-09-07  
            //cmd.Parameters.Add(_ParmCustomerName, SqlDbType.NVarChar, 50).Value = reimburse.CustomerID;
            cmd.Parameters.Add(_ParmProject, SqlDbType.NVarChar, 50).Value = reimburse.ProjectName;
            cmd.Parameters.Add(_ParmReimburseStatus, SqlDbType.Int).Value = Convert.ToInt32(reimburse.ReimburseStatus);
            cmd.Parameters.Add(_ParmTotalCost, SqlDbType.Decimal).Value = reimburse.TotalCost;
            cmd.Parameters.Add(_ParmDepartmentName, SqlDbType.NVarChar, 50).Value = reimburse.Department.DepartmentName;
            cmd.Parameters.Add(_ParmCommitTime, SqlDbType.DateTime).Value = reimburse.CommitTime;
            cmd.Parameters.Add(_ParmRemark, SqlDbType.NVarChar, 500).Value = reimburse.Remark;
            cmd.Parameters.Add(_ParmDiscription, SqlDbType.NVarChar, 500).Value = reimburse.Discription;
            cmd.Parameters.Add(_ParmOutCityAllowance, SqlDbType.Decimal).Value = reimburse.OutCityAllowance;
            cmd.Parameters.Add(_ParmOutCityDays, SqlDbType.Decimal).Value = reimburse.OutCityDays;
            cmd.Parameters.Add(_ParmExchangeRateID, SqlDbType.Int).Value = reimburse.ExchangeRateID;
            if (reimburse.BillingTime != null)
            {
                cmd.Parameters.Add(_ParmBillingTime, SqlDbType.DateTime).Value = reimburse.BillingTime;
            }
            else
            {
                cmd.Parameters.Add(_ParmBillingTime, SqlDbType.DateTime).Value = DBNull.Value;
            }

            SqlHelper.ExecuteNonQueryReturnPKID("ReimburseInsert", cmd, out pkid);
            return pkid;
        }

        private int DeleteReimburseByEmployeeID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmEmployeeId, SqlDbType.Int).Value = id;
            return SqlHelper.ExecuteNonQuery("DeleteReimburseByEmployeeID", cmd);
        }

        private void GetReimburseByEmployeeID(Employee employee)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmEmployeeId, SqlDbType.Int).Value = employee.Account.Id;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetReimburseByEmployeeID", cmd))
            {
                employee.Reimburses = new List<Reimburse>();
                while (sdr.Read())
                {
                    Reimburse reimburse = GetReimburseFromDB(sdr);
                   employee.Reimburses.Add(reimburse);
                }
            }
            var items = GetReimburseItemByEmployeeID(employee.Account.Id);
            var flows = GetReimburseFlowByEmployeeID(employee.Account.Id);
            
            foreach (var reimburse in employee.Reimburses)
            {
                reimburse.ReimburseItems = items.Where(x => x.ReimburseID == reimburse.ReimburseID).ToList();
                reimburse.ReimburseFlows = flows.Where(x => x.ReimburseID == reimburse.ReimburseID).ToList();
            }
        }

        #endregion

        #region ReimburseItem

        private int InsertReimburseItem(int id, ReimburseItem item)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_ParmReimburseID, SqlDbType.Int).Value = id;
            cmd.Parameters.Add(_ParmReimburseType, SqlDbType.Int).Value = Convert.ToInt32(item.ReimburseTypeEnum);
            cmd.Parameters.Add(_ParmConsumePlace, SqlDbType.NVarChar, 100).Value = item.ConsumePlace ?? "";
            cmd.Parameters.Add(_ParmProjectName, SqlDbType.NVarChar, 50).Value = item.ProjectName;
            cmd.Parameters.Add(_ParmTotalCost, SqlDbType.Decimal).Value = item.TotalCost;
            cmd.Parameters.Add(_ParmReason, SqlDbType.Text).Value = item.Reason ?? "";
            cmd.Parameters.Add(_ParmCurrencyType, SqlDbType.Int).Value = item.CurrencyType;
            //add by liudan 2009-09-07
            cmd.Parameters.Add(_ParmCustomerID, SqlDbType.Int).Value = item.CustomerID;
            SqlHelper.ExecuteNonQueryReturnPKID("ReimburseItemInsert", cmd, out pkid);
            return pkid;

        }

        private int DeleteReimburseItemByReimburseID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmReimburseID, SqlDbType.Int).Value = id;
            return SqlHelper.ExecuteNonQuery("DeleteReimburseItemByReimburseID", cmd);
        }

        private void GetReimburseItemByReimburseID(Reimburse reimburse)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmReimburseID, SqlDbType.Int).Value = reimburse.ReimburseID;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetReimburseItemByReimburseID", cmd))
            {
                reimburse.ReimburseItems = new List<ReimburseItem>();
                while (sdr.Read())
                {
                    ReimburseItem reimburseItem =
                        new ReimburseItem((ReimburseTypeEnum)sdr[_DBReimburseType],
                                          Convert.ToDecimal(sdr[_DBTotalCost]), sdr[_DBProjectName].ToString());
                    reimburseItem.ReimburseItemID = Convert.ToInt32(sdr[_DBPKID]);
                    reimburseItem.ConsumePlace = sdr[_DBConsumePlace].ToString();
                    reimburseItem.Reason = sdr[_DBReason].ToString();
                    reimburseItem.CustomerID = Convert.ToInt32(sdr[_DBCustomerName]);
                    reimburseItem.CurrencyType = Convert.ToInt32(sdr[_DBCurrencyType]);
                    reimburseItem.ExchangeRateName = sdr[_DBExchangeRateName].ToString();
                    reimburseItem.ExchangeSymbol = sdr[_DBExchangeSymbol].ToString();
                    reimburseItem.ExchangeRate = Convert.ToDecimal(sdr[_DBExchangeRate]);
                    CustomerInfo info = new CustomerInfoDal().GetCustomerInfoByCustomerInfoID(reimburseItem.CustomerID);
                    if (info != null)
                    {
                        reimburseItem.CustomerName = info.CompanyName;
                    }
                    reimburse.ReimburseItems.Add(reimburseItem);
                }
            }
        }


        private List<ReimburseItem> GetReimburseItemByEmployeeID(int accountID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"  SELECT a.*,c.Name as ExchangeRateName,c.Rate as ExchangeRate,c.Symbol as ExchangeSymbol
	     FROM TReimburseItem as a with(nolock) inner join TReimburse as b on a.ReimburseID=b.PKID
	     left join TExchangeRate as c  with(nolock) on b.ExchangeRateID=c.PKID
         WHERE ReimburseID in (select PKID from TReimburse where EmployeeID=@EmployeeID) ";
            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = accountID;
            var customers = new CustomerInfoDal().GetCustomerInfoByNameLike("");
            using (
                SqlDataReader sdr = SqlHelper.ExecuteReader(cmd))
            {
                var reimburseItems = new List<ReimburseItem>();
                while (sdr.Read())
                {
                    ReimburseItem reimburseItem =
                        new ReimburseItem((ReimburseTypeEnum)sdr[_DBReimburseType],
                                          Convert.ToDecimal(sdr[_DBTotalCost]), sdr[_DBProjectName].ToString());
                    reimburseItem.ReimburseItemID = Convert.ToInt32(sdr[_DBPKID]);
                    reimburseItem.ReimburseID = Convert.ToInt32(sdr["ReimburseID"]);
                    reimburseItem.ConsumePlace = sdr[_DBConsumePlace].ToString();
                    reimburseItem.Reason = sdr[_DBReason].ToString();
                    reimburseItem.CustomerID = Convert.ToInt32(sdr[_DBCustomerName]);
                    reimburseItem.CurrencyType = Convert.ToInt32(sdr[_DBCurrencyType]);
                    reimburseItem.ExchangeRateName = sdr[_DBExchangeRateName].ToString();
                    reimburseItem.ExchangeSymbol = sdr[_DBExchangeSymbol].ToString();
                    reimburseItem.ExchangeRate = Convert.ToDecimal(sdr[_DBExchangeRate]);
                    CustomerInfo info =customers.Where(x=>x.CustomerInfoId==reimburseItem.CustomerID).FirstOrDefault();
                    if (info != null)
                    {
                        reimburseItem.CustomerName = info.CompanyName;
                    }
                    reimburseItems.Add(reimburseItem);
                }
                return reimburseItems;
            }
        }


        #endregion

        #region ReimburseFlow

        private int InsertReimburseFlow(int id, ReimburseFlow reimburseFlow)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_ParmReimburseID, SqlDbType.Int).Value = id;
            cmd.Parameters.Add(_ParmOperatorID, SqlDbType.Int).Value = reimburseFlow.Operator.Account.Id;
            cmd.Parameters.Add(_ParmOperationTime, SqlDbType.DateTime).Value = reimburseFlow.OperationTime;
            cmd.Parameters.Add(_ParmReimburseStatus, SqlDbType.Int).Value = Convert.ToInt32(reimburseFlow.ReimburseStatusEnum);
            SqlHelper.ExecuteNonQueryReturnPKID("ReimburseFlowInsert", cmd, out pkid);
            return pkid;
        }

        private int DeleteReimburseFlowByReimburseID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmReimburseID, SqlDbType.Int).Value = id;
            return SqlHelper.ExecuteNonQuery("DeleteReimburseFlowByReimburseID", cmd);
        }

        private void GetReimburseFlowByReimburseID(Reimburse reimburse)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmReimburseID, SqlDbType.Int).Value = reimburse.ReimburseID;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetReimburseFlowByReimburseID", cmd))
            {
                reimburse.ReimburseFlows = new List<ReimburseFlow>();
                while (sdr.Read())
                {
                    ReimburseFlow reimburseFlow =
                        new ReimburseFlow(null, Convert.ToDateTime(sdr[_DBOperationTime]),
                                          (ReimburseStatusEnum)sdr[_DBReimburseStatus]);
                    reimburseFlow.ReimburseFlowID = Convert.ToInt32(sdr[_DBPKID]);
                    reimburseFlow.Operator = _EmployeeDal.GetEmployeeBasicInfoByAccountID(Convert.ToInt32(sdr[_DBOperatorID]));
                    reimburse.ReimburseFlows.Add(reimburseFlow);
                }
            }
        }


        private List<ReimburseFlow> GetReimburseFlowByEmployeeID(int accountID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT * 
	     FROM TReimburseFlow
         WHERE ReimburseID in (select PKID from TReimburse where EmployeeId=@EmployeeID) ";
            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = accountID;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader(cmd))
            {
               var reimburseFlows = new List<ReimburseFlow>();
                while (sdr.Read())
                {
                    ReimburseFlow reimburseFlow =
                        new ReimburseFlow(null, Convert.ToDateTime(sdr[_DBOperationTime]),
                                          (ReimburseStatusEnum)sdr[_DBReimburseStatus]);
                    reimburseFlow.ReimburseFlowID = Convert.ToInt32(sdr[_DBPKID]);
                    reimburseFlow.Operator = new Employee() { Account = new Account() { Id = Convert.ToInt32(sdr[_DBOperatorID]) } };
                    reimburseFlow.ReimburseID = Convert.ToInt32(sdr["ReimburseID"]);
                    reimburseFlows.Add(reimburseFlow);
                }
                return reimburseFlows;
            }
        }


        public Reimburse GetReimburseByReimburseID(int ReimburseID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = ReimburseID;
            Reimburse reimburse = null;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetReimburseByReimburseID", cmd))
            {

                while (sdr.Read())
                {
                    reimburse = GetReimburseFromDB(sdr);
                    //reimburse = new Reimburse(Convert.ToDateTime(sdr[_DBApplyDate]),(ReimburseStatusEnum)sdr[_DBReimburseStatus]);
                    //reimburse.ReimburseID = Convert.ToInt32(sdr[_DBPKID]);
                    //reimburse.NextStepIndex = Convert.ToInt32(sdr[_DBNextStepIndex]);
                    //reimburse.ApplierID = Convert.ToInt32(sdr[_DBEmployeeId]);
                    //reimburse.Department =
                    //    new Department((Int32)sdr[_DBDepartmentID], sdr[_DBDepartmentName].ToString());
                    //reimburse.ApplyDate = Convert.ToDateTime(sdr[_DBApplyDate]);
                    //reimburse.ReimburseStatus = (ReimburseStatusEnum) sdr[_DBReimburseStatus];
                    //reimburse.TotalCost = (decimal)(sdr[_DBTotalCost]);
                    //reimburse.DiyProcess = DiyProcessDal.ConvertToObject(sdr[_DBDiyProcess].ToString());
                    GetReimburseFlowByReimburseID(reimburse);
                    GetReimburseItemByReimburseID(reimburse);
                }
            }
            return reimburse;
        }

        public void UpdateReimburse(Account loginUser, Reimburse reimburse, ReimburseStatusEnum statusEnum)
        {
            InitializeTranscation();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = reimburse.ReimburseID;
                cmd.Parameters.Add(_ParmReimburseCategoriesEnum, SqlDbType.Int).Value = Convert.ToInt32(reimburse.ReimburseCategoriesEnum.Id);
                cmd.Parameters.Add(_ParmPaperCount, SqlDbType.Int).Value = reimburse.PaperCount;
                cmd.Parameters.Add(_ParmDestinations, SqlDbType.NVarChar, 50).Value = reimburse.Destinations;
                //cmd.Parameters.Add(_ParmCustomerName, SqlDbType.NVarChar, 50).Value = reimburse.CustomerID;
                cmd.Parameters.Add(_ParmProject, SqlDbType.NVarChar, 50).Value = reimburse.ProjectName;
                cmd.Parameters.Add(_ParmConsumeDateFrom, SqlDbType.DateTime).Value = reimburse.ConsumeDateFrom;
                cmd.Parameters.Add(_ParmConsumeDateTo, SqlDbType.DateTime).Value = reimburse.ConsumeDateTo;

                cmd.Parameters.Add(_ParmBillingTime, SqlDbType.DateTime).Value = reimburse.BillingTime;
                cmd.Parameters.Add(_ParmTotalCost, SqlDbType.Decimal).Value = reimburse.TotalCost;
                cmd.Parameters.Add(_ParmReimburseStatus, SqlDbType.Int).Value = reimburse.ReimburseStatus;
                cmd.Parameters.Add(_ParmCommitTime, SqlDbType.DateTime).Value = reimburse.CommitTime;
                cmd.Parameters.Add(_ParmRemark, SqlDbType.NVarChar, 500).Value = reimburse.Remark;
                cmd.Parameters.Add(_ParmDiscription, SqlDbType.NVarChar, 500).Value = reimburse.Discription;
                cmd.Parameters.Add(_ParmOutCityAllowance, SqlDbType.Decimal).Value = reimburse.OutCityAllowance;
                cmd.Parameters.Add(_ParmOutCityDays, SqlDbType.Decimal).Value = reimburse.OutCityDays;
                cmd.Parameters.Add(_ParmApplyDate, SqlDbType.DateTime).Value = reimburse.ApplyDate;
                cmd.Parameters.Add(_ParmExchangeRateID, SqlDbType.Int).Value = reimburse.ExchangeRateID;
                SqlHelper.ExecuteNonQuery("UpdateReimburseStatus", cmd);

                ReimburseFlow reimburseFlow = new ReimburseFlow(new Employee(loginUser.Id, EmployeeTypeEnum.All), reimburse.ApplyDate, statusEnum);
                reimburseFlow.Operator = new Employee();
                reimburseFlow.Operator.Account = new Account();
                reimburseFlow.Operator.Account.Id = loginUser.Id;
                reimburseFlow.OperationTime = DateTime.Now;

                InsertReimburseFlow(reimburse.ReimburseID, reimburseFlow);
                _Trans.Commit();
            }
            catch (Exception)
            {
                _Trans.Rollback();
                throw;
            }
            finally
            {
                _Conn.Close();
            }

        }

        private void InitializeTranscation()
        {
            _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
            _Conn.Open();
            _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
        }
        /// <summary>
        /// 查找我审核完成的报销单
        /// </summary>
        public List<Reimburse> GetMyAuditingReimburses(int accountID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmOperatorID, SqlDbType.Int).Value = accountID;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetMyAuditingReimburses", cmd))
            {
                List<Reimburse> Reimburses = new List<Reimburse>();
                while (sdr.Read())
                {
                    Reimburse reimburse = GetReimburseFromDB(sdr);
                    //    new Reimburse(Convert.ToDateTime(sdr[_DBApplyDate]), (ReimburseStatusEnum)sdr[_DBReimburseStatus]);
                    //reimburse.ReimburseID = (Int32)sdr[_DBPKID];
                    //reimburse.Department = new Department();
                    //reimburse.Department.Id = (Int32)sdr[_DBDepartmentID];
                    //reimburse.Department.Name = sdr[_DBDepartmentName].ToString();
                    //reimburse.TotalCost = (decimal)(sdr[_DBTotalCost]);
                    //reimburse.ApplierID = Convert.ToInt32(sdr[_DBEmployeeId]);
                    //reimburse.DiyProcess = DiyProcessDal.ConvertToObject(sdr[_DBDiyProcess].ToString());
                    //reimburse.NextStepIndex = Convert.ToInt32(sdr[_DBNextStepIndex]);
                    Reimburses.Add(reimburse);
                    GetReimburseItemByReimburseID(reimburse);
                }
                return Reimburses;
            }
        }

        /// <summary>
        /// 查找报销的流程历史
        /// </summary>
        public List<ReimburseFlow> GetReimbursesHistory(int ReimburseID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmReimburseID, SqlDbType.Int).Value = ReimburseID;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetReimbursesHistory", cmd))
            {
                List<ReimburseFlow> reimburseFlows = new List<ReimburseFlow>();
                while (sdr.Read())
                {
                    ReimburseFlow reimburseFlow =
                        new ReimburseFlow(new Employee(), Convert.ToDateTime(sdr[_DBOperationTime]), (ReimburseStatusEnum)sdr[_DBReimburseStatus]);
                    reimburseFlow.Operator = new Employee();
                    reimburseFlow.Operator.Account = new Account();
                    reimburseFlow.Operator.Account.Id = Convert.ToInt32(sdr[_DBOperatorID]);
                    reimburseFlows.Add(reimburseFlow);
                }
                return reimburseFlows;
            }
        }

        private static Reimburse GetReimburseFromDB(IDataRecord sdr)
        {
            Reimburse reimburse = null;
            if (sdr == null)
                return reimburse;

            if (sdr[_DBPKID] == DBNull.Value)
                return reimburse;
            reimburse = new Reimburse(Convert.ToDateTime(sdr[_DBApplyDate]),
                                      (ReimburseStatusEnum)sdr[_DBReimburseStatus]);
            reimburse.ReimburseID = (Int32)sdr[_DBPKID];
            reimburse.ApplierID = (Int32)sdr[_DBEmployeeId];
            reimburse.Department =
                new Department((Int32)sdr[_DBDepartmentID], sdr[_DBDepartmentName].ToString());
            reimburse.ReimburseCategoriesEnum =
                ReimburseCategoriesEnum.GetById(Convert.ToInt32(sdr[_DBReimburseCategoriesEnum]));
            reimburse.PaperCount = (Int32)sdr[_DBPaperCount];
            reimburse.ConsumeDateFrom = Convert.ToDateTime(sdr[_DBConsumeDateFrom]);
            reimburse.ConsumeDateTo = Convert.ToDateTime(sdr[_DBConsumeDateTo]);
            reimburse.Destinations = sdr[_DBDestinations].ToString();
            //reimburse.CustomerID = sdr[_DBCustomerName].ToString();
            reimburse.ProjectName = sdr[_DBProject].ToString();
            reimburse.TotalCost = (decimal)(sdr[_DBTotalCost]);
            reimburse.Remark = sdr[_DBRemark].ToString();
            reimburse.Discription = sdr[_DBDiscription].ToString();
            reimburse.OutCityAllowance = Convert.ToDecimal(sdr[_DBOutCityAllowance]);
            reimburse.OutCityDays = Convert.ToDecimal(sdr[_DBOutCityDays]);
            DateTime tempBillingTime;
            if (sdr[_DBBillingTime] != null &&
                DateTime.TryParse(sdr[_DBBillingTime].ToString(), out tempBillingTime))
            {
                reimburse.BillingTime = sdr[_DBBillingTime].ToString();
            }
            DateTime tempCommitTime;
            if (sdr[_DBCommitTime] != null &&
            DateTime.TryParse(sdr[_DBCommitTime].ToString(), out tempCommitTime))
            {
                reimburse.CommitTime = sdr[_DBCommitTime].ToString();
            }
            reimburse.ExchangeRateID = Convert.ToInt32(sdr[_DBExchangeRateID]);
            reimburse.ExchangeSymbol = sdr[_DBExchangeSymbol].ToString();
            reimburse.ExchangeRateName = sdr[_DBExchangeRateName].ToString();
            reimburse.ExchangeRate = Convert.ToDecimal(sdr[_DBExchangeRate]);
            //reimburse.DiyProcess = DiyProcessDal.ConvertToObject(sdr[_DBDiyProcess].ToString());
            //reimburse.NextStepIndex = Convert.ToInt32(sdr[_DBNextStepIndex]);)
            return reimburse;
        }


        public List<Reimburse> GetReimburseByDateTime()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParaDateTime, SqlDbType.DateTime).Value = DateTime.Now.AddDays(-1);
            cmd.Parameters.Add(_ParmReimburseStatus, SqlDbType.Int).Value = (int)ReimburseStatusEnum.Reimbursing;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetReimburseByDateTime", cmd))
            {
                List<Reimburse> Reimburses = new List<Reimburse>();
                while (sdr.Read())
                {
                    Reimburse reimburse = GetReimburseFromDB(sdr);
                    Reimburses.Add(reimburse);
                    GetReimburseItemByReimburseID(reimburse);
                    GetReimburseFlowByReimburseID(reimburse);
                }
                return Reimburses;
            }
        }

        #endregion

        #region IReimburse 成员

        public int GetCustomerCountByReiburseID(int reiburseID)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmReimburseID, SqlDbType.Int).Value = reiburseID;

            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetCustomerCountByReiburseID", cmd))
            {
                while (sdr.Read())
                {
                    count = Convert.ToInt32(sdr[_DBCount]);
                }
            }
            return count;
        }
        public List<Reimburse> GetReiburseTotalByCondition(string employeename, string place, string customerName, string projectName, DateTime? applydateFrom, DateTime? applydateTo, string remark, int ReimburseCategoriesId, DateTime? billingTimeFrom, DateTime? billingTimeTo, int companyID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmReimburseStatus, SqlDbType.Int).Value = (int)ReimburseStatusEnum.Reimbursed;
            cmd.Parameters.Add(_ParmReimburseCategoriesEnum, SqlDbType.Int).Value =
                ReimburseCategoriesId;
            cmd.Parameters.Add(_ParmCustomerName, SqlDbType.NVarChar, 50).Value = customerName;
            cmd.Parameters.Add(_ParmProject, SqlDbType.NVarChar, 50).Value = projectName;
            cmd.Parameters.Add(_ParmDestinations, SqlDbType.NVarChar, 50).Value = place;
            cmd.Parameters.Add(_ParmRemark, SqlDbType.NVarChar, 500).Value = remark;
            cmd.Parameters.Add(_ParmApplyDateFrom, SqlDbType.DateTime).Value = applydateFrom.HasValue
                                                                                   ? (object)applydateFrom.Value
                                                                                   : DBNull.Value;
            cmd.Parameters.Add(_ParmApplyDateTo, SqlDbType.DateTime).Value = applydateTo.HasValue
                                                                                 ? (object)applydateTo.Value
                                                                                 : DBNull.Value;
            cmd.Parameters.Add(_ParmBillingTimeFrom, SqlDbType.DateTime).Value = billingTimeFrom.HasValue
                                                                                   ? (object)billingTimeFrom.Value
                                                                                   : DBNull.Value;
            cmd.Parameters.Add(_ParmBillingTimeTo, SqlDbType.DateTime).Value = billingTimeTo.HasValue
                                                                                 ? (object)billingTimeTo.Value
                                                                                 : DBNull.Value;
            cmd.Parameters.Add(_ParmCompanyID, SqlDbType.Int).Value = companyID;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetReiburseTotalByCondition", cmd))
            {
                List<Reimburse> Reimburses = new List<Reimburse>();
                while (sdr.Read())
                {
                    Reimburse reimburse =
                        new Reimburse(Convert.ToDateTime(sdr[_DBApplyDate]), ReimburseStatusEnum.Reimbursed);
                    reimburse.ReimburseID = Convert.ToInt32(sdr[_DBReimburseId]);
                    reimburse.ReimburseCategoriesEnum = ReimburseCategoriesEnum.GetById(Convert.ToInt32(sdr[_DBReimburseCategoriesEnum]));
                    reimburse.ApplierID = (Int32)sdr[_DBEmployeeId];
                    //reimburse.TotalCost = (decimal)(sdr[_DBTotalCost]);
                    reimburse.OutCityAllowance = (decimal)(sdr[_DBOutCityAllowance]);
                    reimburse.Destinations = sdr[_DBDestinations].ToString();
                    reimburse.ProjectName = sdr[_DBProject].ToString();
                    reimburse.Remark = sdr[_DBRemark].ToString();
                    reimburse.Discription = sdr[_DBDiscription].ToString();
                    reimburse.OutCityDays = Convert.ToDecimal(sdr[_DBOutCityDays]);
                    reimburse.ConsumeDateFrom = Convert.ToDateTime(sdr[_DBConsumeDateFrom]);
                    reimburse.ConsumeDateTo = Convert.ToDateTime(sdr[_DBConsumeDateTo]);
                    DateTime tempBillingTime;
                    if (sdr[_DBBillingTime] != null &&
                        DateTime.TryParse(sdr[_DBBillingTime].ToString(), out tempBillingTime))
                    {
                        reimburse.BillingTime = sdr[_DBBillingTime].ToString();
                    }
                    reimburse.ReimburseItems = new List<ReimburseItem>();
                    ReimburseItem reimburseItem = new ReimburseItem((ReimburseTypeEnum)sdr[_DBReimburseType],
                                          Convert.ToDecimal(sdr[_DBTotalCost]), sdr[_DBProjectName].ToString());
                    reimburseItem.ReimburseItemID = Convert.ToInt32(sdr[_DBReimburseItemId]);
                    reimburseItem.ConsumePlace = sdr[_DBConsumePlace].ToString();
                    reimburseItem.Reason = sdr[_DBReason].ToString();
                    reimburseItem.CustomerID = Convert.ToInt32(sdr[_DBCustomerName]);
                    reimburseItem.CurrencyType = Convert.ToInt32(sdr[_DBCurrencyType]);
                    reimburseItem.ExchangeRateName = sdr[_DBExchangeRateName].ToString();
                    reimburseItem.ExchangeSymbol = sdr[_DBExchangeSymbol].ToString();
                    reimburseItem.ExchangeRate = Convert.ToDecimal(sdr[_DBExchangeRate]) ;
                    CustomerInfo info = new CustomerInfoDal().GetCustomerInfoByCustomerInfoID(reimburseItem.CustomerID);
                    if (info != null)
                    {
                        reimburseItem.CustomerName = info.CompanyName;
                    }
                    reimburse.ReimburseItems.Add(reimburseItem);

                    Reimburses.Add(reimburse);
                }
                return Reimburses;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public bool GetReiburseByCustomerID(int customerID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmCustomerID, SqlDbType.Int).Value = customerID;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetReiburseByCustomerID", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DBCount]) > 0;
                }
            }
            return false;
        }

        #endregion

        #region IReimburse 成员


        public void DeleteReimburseByID(int reimburseID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = reimburseID;
            SqlHelper.ExecuteNonQuery("DeleteReimburseByID", cmd);
            DeleteReimburseFlowByReimburseID(reimburseID);
            DeleteReimburseItemByReimburseID(reimburseID);
        }

        public void UpdateReimburseItemCustomer(Reimburse reimburse)
        {
            try
            {
                DeleteReimburseItemByReimburseID(reimburse.ReimburseID);

                if (reimburse.ReimburseItems != null)
                {
                    foreach (ReimburseItem eachReimburseItem in reimburse.ReimburseItems)
                    {
                        eachReimburseItem.ReimburseItemID =
                            InsertReimburseItem(reimburse.ReimburseID, eachReimburseItem);
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
        }

        #endregion
    }
}
