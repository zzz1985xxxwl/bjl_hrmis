//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ContractDal.cs
// 创建者: 张燕
// 创建日期: 2008-05-23
// 概述:  实现IContract接口中的方法

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.SqlServerDal
{
    public class ContractDal : IContract
    {
        private const string _ContractID = "@PKID";
        private const string _AccountID = "@AccountID";
        private const string _ContractTypeID = "@ContractTypeID";
        private const string _StartDate = "@StartDate";
        private const string _EndDate = "@EndDate";
        private const string _EndTimeFrom = "@EndTimeFrom";
        private const string _EndTimeTo = "@EndTimeTo";
        private const string _StartTimeFrom = "@StartTimeFrom";
        private const string _StartTimeTo = "@StartTimeTo";
        private const string _EmployeeName = "@EmployeeName";
        private const string _Remark = "@Remark";
        private const string _Attachment = "@Attachment";
        private const string _DBContractID = "PKID";
        private const string _DBContractTypeName = "ContractTypeName";
        private const string _DBContractTypeID = "ContractTypeID";
        private const string _DBStartDate = "StartDate";
        private const string _DBEndDate = "EndDate";
        private const string _DBAccountID = "AccountID";
        private const string _DBEmployeeName = "EmployeeName";
        private const string _DBRemark = "Remark";
        private const string _DBAttachment = "Attachment";
        private const string _CurrentTime = "@CurrentTime";

        /// <summary>
        /// 新增员工合同
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="contract"></param>
        /// <returns></returns>
        public int InsertEmployeeContract(int accountID, Contract contract)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_ContractID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_ContractTypeID, SqlDbType.Int).Value = contract.ContractType.ContractTypeID;
            cmd.Parameters.Add(_StartDate, SqlDbType.DateTime).Value = contract.StartDate;
            cmd.Parameters.Add(_EndDate, SqlDbType.DateTime).Value = contract.EndDate;
            cmd.Parameters.Add(_Attachment, SqlDbType.Text).Value = contract.Attachment;
            cmd.Parameters.Add(_Remark, SqlDbType.Text).Value = contract.Remark;
            SqlHelper.ExecuteNonQueryReturnPKID("EmployeeContractInsert", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// 更新员工合同
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public int UpdateEmployeeContract(Contract contract)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ContractID, SqlDbType.Int).Value = contract.ContractID;
            cmd.Parameters.Add(_ContractTypeID, SqlDbType.Int).Value = contract.ContractType.ContractTypeID;
            cmd.Parameters.Add(_StartDate, SqlDbType.DateTime).Value = contract.StartDate;
            cmd.Parameters.Add(_EndDate, SqlDbType.DateTime).Value = contract.EndDate;
            cmd.Parameters.Add(_Attachment, SqlDbType.Text).Value = contract.Attachment;
            cmd.Parameters.Add(_Remark, SqlDbType.Text).Value = contract.Remark;
            return SqlHelper.ExecuteNonQuery("EmployeeContractUpdate", cmd);
        }

        /// <summary>
        /// 删除员工合同
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        public int DeleteEmployeeContract(int contractId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ContractID, SqlDbType.Int).Value = contractId;
            return SqlHelper.ExecuteNonQuery("EmployeeContractDelete", cmd);
        }
        public List<Contract> GetAllEmployeeContract()
        {
            List<Contract> contracts = new List<Contract>();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllEmployeeContract", cmd))
            {
                while (sdr.Read())
                {
                    int contractID = (Int32)sdr[_DBContractID];
                    int contractTypeID = (Int32)sdr[_DBContractTypeID];
                    string contractTypeName = sdr[_DBContractTypeName].ToString();
                    DateTime startDate = Convert.ToDateTime(sdr[_DBStartDate]);
                    DateTime endDate = Convert.ToDateTime(sdr[_DBEndDate]);

                    ContractType contractType = new ContractType(contractTypeID, contractTypeName);
                    Contract contract = new Contract(contractID, contractType, startDate, endDate);
                    contract.EmployeeID = (Int32)sdr[_DBAccountID];
                    contract.Remark = sdr[_DBRemark].ToString();
                    contract.Attachment = sdr[_DBAttachment].ToString();
                    contracts.Add(contract);
                }
                return contracts;
            }
        }

        /// <summary>
        /// 查询员工的合同
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        /// <param name="currentDate"></param>
        public Contract GetCurrentContractByAccountID(int accountID, DateTime currentDate)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_CurrentTime, SqlDbType.DateTime).Value = currentDate;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetCurrentContractByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    int contractID = (Int32)sdr[_DBContractID];
                    int contractTypeID = (Int32)sdr[_DBContractTypeID];
                    string contractTypeName = sdr[_DBContractTypeName].ToString();
                    DateTime startDate = Convert.ToDateTime(sdr[_DBStartDate]);
                    DateTime endDate = Convert.ToDateTime(sdr[_DBEndDate]);
                    ContractType contractType = new ContractType(contractTypeID, contractTypeName);
                    Contract contract = new Contract(contractID, contractType, startDate, endDate);
                    contract.Remark = sdr[_DBRemark].ToString();
                    contract.Attachment = sdr[_DBAttachment].ToString();
                    return contract;
                }
                return null;
            }
        }

        /// <summary>
        /// 根据合同类型查询合同
        /// </summary>
        /// <param name="contractTypeId"></param>
        /// <returns></returns>
        public List<Contract> GetEmployeeContractByContractTypeId(int contractTypeId)
        {
            List<Contract> contractList = new List<Contract>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ContractTypeID, SqlDbType.Int).Value = contractTypeId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeContractByContractTypeId", cmd))
            {
                while (sdr.Read())
                {
                    int contractID = (Int32)sdr[_DBContractID];
                    int contractTypeID = (Int32)sdr[_DBContractTypeID];
                    string contractTypeName = sdr[_DBContractTypeName].ToString();
                    DateTime startDate = Convert.ToDateTime(sdr[_DBStartDate]);
                    DateTime endDate = Convert.ToDateTime(sdr[_DBEndDate]);

                    ContractType contractType = new ContractType(contractTypeID, contractTypeName);

                    Contract contract = new Contract(contractID, contractType, startDate, endDate);
                    contract.Remark = sdr[_DBRemark].ToString();
                    contract.Attachment = sdr[_DBAttachment].ToString();
                    contractList.Add(contract);

                }
            }
            return contractList;
        }

        /// <summary>
        /// 根据PKID查询合同
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        public Contract GetEmployeeContractByContractId(int contractId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ContractID, SqlDbType.Int).Value = contractId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeContractByContractId", cmd))
            {
                while (sdr.Read())
                {
                    int contractID = (Int32)sdr[_DBContractID];
                    int contractTypeID = (Int32)sdr[_DBContractTypeID];
                    string contractTypeName = sdr[_DBContractTypeName].ToString();
                    DateTime startDate = Convert.ToDateTime(sdr[_DBStartDate]);
                    DateTime endDate = Convert.ToDateTime(sdr[_DBEndDate]);

                    ContractType contractType = new ContractType(contractTypeID, contractTypeName);
                    Contract contract = new Contract(contractID, contractType, startDate, endDate);
                    contract.EmployeeID = Convert.ToInt32(sdr[_DBAccountID]);
                    contract.Remark = sdr[_DBRemark].ToString();
                    contract.Attachment = sdr[_DBAttachment].ToString();
                    return contract;
                }
                return null;
            }
        }

        public List<Contract> GetEmployeeContractByAccountID(int accountID)
        {
            List<Contract> contracts = new List<Contract>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeContractByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    int contractID = (Int32)sdr[_DBContractID];
                    int contractTypeID = (Int32)sdr[_DBContractTypeID];
                    string contractTypeName = sdr[_DBContractTypeName].ToString();
                    DateTime startDate = Convert.ToDateTime(sdr[_DBStartDate]);
                    DateTime endDate = Convert.ToDateTime(sdr[_DBEndDate]);

                    ContractType contractType = new ContractType(contractTypeID, contractTypeName);
                    Contract contract = new Contract(contractID, contractType, startDate, endDate);
                    contract.Remark = sdr[_DBRemark].ToString();
                    contract.Attachment = sdr[_DBAttachment].ToString();
                    contracts.Add(contract);
                }
                return contracts;
            }
        }

        public List<Contract> GetEmployeeContractByCondition(int accountID, DateTime StratTimeFrom,
                                                              DateTime StratTimeTo, DateTime EndTimeFrom,
                                                              DateTime EndTimeTo, int ContractTypeId)
        {
            List<Contract> contracts = new List<Contract>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_StartTimeFrom, SqlDbType.DateTime).Value = StratTimeFrom;
            cmd.Parameters.Add(_StartTimeTo, SqlDbType.DateTime).Value = StratTimeTo;
            cmd.Parameters.Add(_EndTimeFrom, SqlDbType.DateTime).Value = EndTimeFrom;
            cmd.Parameters.Add(_EndTimeTo, SqlDbType.DateTime).Value = EndTimeTo;
            cmd.Parameters.Add(_ContractTypeID, SqlDbType.Int).Value = ContractTypeId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeContractByCondition", cmd))
            {
                while (sdr.Read())
                {
                    int contractID = (Int32)sdr[_DBContractID];
                    int contractTypeID = (Int32)sdr[_DBContractTypeID];
                    string contractTypeName = sdr[_DBContractTypeName].ToString();
                    DateTime startDate = Convert.ToDateTime(sdr[_DBStartDate]);
                    DateTime endDate = Convert.ToDateTime(sdr[_DBEndDate]);

                    ContractType contractType = new ContractType(contractTypeID, contractTypeName);
                    Contract contract = new Contract(contractID, contractType, startDate, endDate);
                    contract.EmployeeID = (Int32)sdr[_DBAccountID];
                    contract.Remark = sdr[_DBRemark].ToString();
                    contract.Attachment = sdr[_DBAttachment].ToString();
                    contracts.Add(contract);
                }
                return contracts;
            }
        }
        private const string _ConditionID = "@PKID";
        private const string _EmployeeContractID = "@EmployeeContractID";
        private const string _ApplyDate = "@ApplyDate";
        private const string _ApplyAssessCharacterType = "@ApplyAssessCharacterType";
        private const string _AssessScopeFrom = "@AssessScopeFrom";
        private const string _AssessScopeTo = "@AssessScopeTo";
        private const string _DBConditionID = "PKID";
        private const string _DBEmployeeContractID = "EmployeeContractID";
        private const string _DBApplyDate = "ApplyDate";
        private const string _DBApplyAssessCharacterType = "ApplyAssessCharacterType";
        private const string _DBAssessScopeFrom = "AssessScopeFrom";
        private const string _DBAssessScopeTo = "AssessScopeTo";

        public int InsertApplyAssessCondition(ApplyAssessCondition conditioin)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_ConditionID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_EmployeeContractID, SqlDbType.Int).Value = conditioin.EmployeeContractID;
            cmd.Parameters.Add(_ApplyDate, SqlDbType.DateTime).Value = conditioin.ApplyDate;
            cmd.Parameters.Add(_AssessScopeFrom, SqlDbType.DateTime).Value = conditioin.AssessScopeFrom;
            cmd.Parameters.Add(_AssessScopeTo, SqlDbType.DateTime).Value = conditioin.AssessScopeTo;
            cmd.Parameters.Add(_ApplyAssessCharacterType, SqlDbType.Int).Value = Convert.ToInt32(conditioin.ApplyAssessCharacterType);

            SqlHelper.ExecuteNonQueryReturnPKID("ApplyAssessConditionInsert", cmd, out pkid);
            return pkid;
        }
        public int DeleteApplyAssessCondition(int conditionID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ConditionID, SqlDbType.Int).Value = conditionID;
            return SqlHelper.ExecuteNonQuery("ApplyAssessConditionDelete", cmd);
        }

        public List<ApplyAssessCondition> GetApplyAssessConditionByEmployeeContractID(int employeeContractID)
        {
            List<ApplyAssessCondition> conditionList = new List<ApplyAssessCondition>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_EmployeeContractID, SqlDbType.Int).Value = employeeContractID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetApplyAssessConditionByEmployeeContractID", cmd))
            {
                while (sdr.Read())
                {
                    ApplyAssessCondition condition = new ApplyAssessCondition((Int32)sdr[_DBConditionID]);
                    condition.EmployeeContractID = (Int32)sdr[_DBEmployeeContractID];
                    condition.ApplyDate = (DateTime)sdr[_DBApplyDate];
                    condition.AssessScopeFrom = (DateTime)sdr[_DBAssessScopeFrom];
                    condition.AssessScopeTo = (DateTime)sdr[_DBAssessScopeTo];
                    condition.ApplyAssessCharacterType = (AssessCharacterType)sdr[_DBApplyAssessCharacterType];
                    conditionList.Add(condition);
                }
            }
            return conditionList;
        }


        public ApplyAssessCondition GetApplyAssessConditionByPKID(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ConditionID, SqlDbType.Int).Value = pkid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetApplyAssessConditionByPKID", cmd))
            {
                while (sdr.Read())
                {
                    ApplyAssessCondition condition = new ApplyAssessCondition((Int32) sdr[_DBConditionID]);
                    condition.EmployeeContractID = (Int32) sdr[_DBEmployeeContractID];
                    condition.ApplyDate = (DateTime) sdr[_DBApplyDate];
                    condition.AssessScopeFrom = (DateTime) sdr[_DBAssessScopeFrom];
                    condition.AssessScopeTo = (DateTime) sdr[_DBAssessScopeTo];
                    condition.ApplyAssessCharacterType = (AssessCharacterType) sdr[_DBApplyAssessCharacterType];
                    return condition;
                }
            }
            return null;
        }

        public int DeleteApplyAssessConditionsByEmployeeContractID(int contractID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_EmployeeContractID, SqlDbType.Int).Value = contractID;
            return SqlHelper.ExecuteNonQuery("ApplyAssessConditionDeleteByEmployeeContractID", cmd);
        }

        public List<ApplyAssessCondition> GetApplyAssessConditionByCurrDate(DateTime currentDate)
        {
            List<ApplyAssessCondition> conditionList = new List<ApplyAssessCondition>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_CurrentTime, SqlDbType.DateTime).Value = currentDate;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetApplyAssessConditionByCurrDate", cmd))
            {
                while (sdr.Read())
                {
                    ApplyAssessCondition condition = new ApplyAssessCondition((Int32)sdr[_DBConditionID]);
                    condition.EmployeeContractID = (Int32)sdr[_DBEmployeeContractID];
                    condition.ApplyDate = (DateTime)sdr[_DBApplyDate];
                    condition.AssessScopeFrom = (DateTime)sdr[_DBAssessScopeFrom];
                    condition.AssessScopeTo = (DateTime)sdr[_DBAssessScopeTo];
                    condition.ApplyAssessCharacterType = (AssessCharacterType)sdr[_DBApplyAssessCharacterType];
                    conditionList.Add(condition);
                }
            }
            return conditionList;
        }
        /// <summary>
        /// 以currentDate为准，在员工所有的合同类型中，查询员工的最新合同
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        /// <param name="currentDate"></param>
        public Contract GetLastContractInAllTypeByAccountID(int accountID, DateTime currentDate)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_CurrentTime, SqlDbType.DateTime).Value = currentDate;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLastContractInAllTypeByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    int contractID = (Int32)sdr[_DBContractID];
                    int contractTypeID = (Int32)sdr[_DBContractTypeID];
                    string contractTypeName = sdr[_DBContractTypeName].ToString();
                    DateTime startDate = Convert.ToDateTime(sdr[_DBStartDate]);
                    DateTime endDate = Convert.ToDateTime(sdr[_DBEndDate]);
                    ContractType contractType = new ContractType(contractTypeID, contractTypeName);
                    Contract contract = new Contract(contractID, contractType, startDate, endDate);
                    contract.Remark = sdr[_DBRemark].ToString();
                    contract.Attachment = sdr[_DBAttachment].ToString();
                    return contract;
                }
                return null;
            }
        }
    }
}


    
     
  

