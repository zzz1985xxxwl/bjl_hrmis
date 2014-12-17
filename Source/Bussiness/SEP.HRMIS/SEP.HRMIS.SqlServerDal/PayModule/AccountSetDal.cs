//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AccountSetDal.cs
// 创建者: wyq
// 创建日期: 2008-12-23
// 概述: 实现IAccountSet接口中的方法
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.SqlServerDal.PayModule
{
    ///<summary>
    ///</summary>
    public class AccountSetDal:IAccountSet
    {
        #region 定义 私有变量
        private const string _ParmPKID = "@PKID";
        private const string _DBPKID = "PKID";
        private const string _DBCount="counts";
        #region AccountSetPara
        private const string _ParmAccountSetParaName = "@AccountSetParaName";
        private const string _ParmFieldAttribute = "@FieldAttribute";
        private const string _ParmBindItem = "@BindItem";
        private const string _ParmMantissaRound = "@MantissaRound";
        private const string _ParmIsVisibleToEmployee = "@IsVisibleToEmployee";
        private const string _ParmIsVisibleWhenZero = "@IsVisibleWhenZero";
        private const string _DBAccountSetParaName = "AccountSetParaName";
        private const string _DBFieldAttribute = "FieldAttribute";
        private const string _DBBindItem = "BindItem";
        private const string _DBMantissaRound = "MantissaRound";
        private const string _DBIsVisibleToEmployee = "IsVisibleToEmployee";
        private const string _DBIsVisibleWhenZero = "IsVisibleWhenZero";
        #endregion
        #region AccountSet
        private const string _ParmAccountSetName = "@AccountSetName";
        private const string _ParmDescription = "@Description";
        private const string _DBAccountSetName = "AccountSetName";
        private const string _DBDescription = "Description";
        #endregion
        #region AccountSetItem
        private const string _ParmAccountSetID = "@AccountSetID";
        private const string _ParmAccountSetParaID = "@AccountSetParaID";
        private const string _ParmCalculateFormula = "@CalculateFormula";
        //private const string _ParmSortNo = "@SortNo";
        //private const string _DBAccountSetID = "AccountSetID";
        private const string _DBAccountSetParaID = "AccountSetParaID";
        private const string _DBCalculateFormula = "CalculateFormula";
        //private const string _DBSortNo = "SortNo";
        #endregion
        private SqlConnection _Conn;
        private SqlTransaction _Trans;
        #endregion
        private void InitializeTranscation()
        {
            _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
            _Conn.Open();
            _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        #region AccountSetPara

        /// <summary>
        /// 新增帐套参数
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public int InsertAccountSetPara(AccountSetPara para)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountSetParaName, SqlDbType.NVarChar, 255).Value = para.AccountSetParaName;
            cmd.Parameters.Add(_ParmDescription, SqlDbType.Text).Value = para.Description;
            cmd.Parameters.Add(_ParmFieldAttribute, SqlDbType.Int).Value = para.FieldAttribute.Id;
            cmd.Parameters.Add(_ParmBindItem, SqlDbType.Int).Value = para.BindItem.Id;
            cmd.Parameters.Add(_ParmIsVisibleToEmployee, SqlDbType.Int).Value = para.IsVisibleToEmployee;
            cmd.Parameters.Add(_ParmIsVisibleWhenZero, SqlDbType.Int).Value = para.IsVisibleWhenZero;
            cmd.Parameters.Add(_ParmMantissaRound, SqlDbType.Int).Value = para.MantissaRound.Id;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertAccountSetPara", cmd, out pkid);
            return pkid;
        }
        /// <summary>
        /// 更新帐套参数
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public int UpdateAccountSetPara(AccountSetPara para)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = para.AccountSetParaID;
            cmd.Parameters.Add(_ParmAccountSetParaName, SqlDbType.NVarChar, 255).Value = para.AccountSetParaName;
            cmd.Parameters.Add(_ParmDescription, SqlDbType.Text).Value = para.Description;
            cmd.Parameters.Add(_ParmFieldAttribute, SqlDbType.Int).Value = para.FieldAttribute.Id;
            cmd.Parameters.Add(_ParmBindItem, SqlDbType.Int).Value = para.BindItem.Id;
            cmd.Parameters.Add(_ParmIsVisibleToEmployee, SqlDbType.Int).Value = para.IsVisibleToEmployee;
            cmd.Parameters.Add(_ParmIsVisibleWhenZero, SqlDbType.Int).Value = para.IsVisibleWhenZero;
            cmd.Parameters.Add(_ParmMantissaRound, SqlDbType.Int).Value = para.MantissaRound.Id;         
            return SqlHelper.ExecuteNonQuery("UpdateAccountSetPara", cmd);
        }
        /// <summary>
        /// 通过PKID，和name查找数据库中除该PKID外是否还有同名数据
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int CountAccountSetParaByNameDiffPKID(int pkid, string name)
        {
            int count=0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;
            cmd.Parameters.Add(_ParmAccountSetParaName, SqlDbType.NVarChar, 255).Value = name;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountAccountSetParaByNameDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    count = Convert.ToInt32(sdr[_DBCount]);
                    return count;
                }
            }
            return count;
        }
        /// <summary>
        /// 通过PKID删除帐号参数
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public int DeleteAccountSetParaByPKID(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;
            return SqlHelper.ExecuteNonQuery("DeleteAccountSetParaByPKID", cmd);
        }
        /// <summary>
        /// 通过ID查找记录
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public AccountSetPara GetAccountSetParaByPKID(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccountSetParaByPKID", cmd))
            {
                while (sdr.Read())
                {
                    int accountSetParaId = Convert.ToInt32(sdr[_DBPKID]);
                    string name = sdr[_DBAccountSetParaName].ToString();
                    AccountSetPara accountSetPara = new AccountSetPara(accountSetParaId, name);
                    accountSetPara.BindItem=BindItemEnum.ChangeValueToBindItemEnum(Convert.ToInt32(sdr[_DBBindItem]));
                    accountSetPara.FieldAttribute = FieldAttributeEnum.ChangeValueToFieldAttributeEnum(Convert.ToInt32(sdr[_DBFieldAttribute]));
                    accountSetPara.MantissaRound = MantissaRoundEnum.ChangeValueToMantissaRoundEnum(Convert.ToInt32(sdr[_DBMantissaRound]));
                    accountSetPara.Description = sdr[_DBDescription].ToString();
                    accountSetPara.IsVisibleToEmployee = Convert.ToBoolean(sdr[_DBIsVisibleToEmployee]);
                    accountSetPara.IsVisibleWhenZero =
                        Convert.ToBoolean(sdr[_DBIsVisibleWhenZero]);
                    return accountSetPara;
                }
            }
            return null;
        }
        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fieldAttribute"></param>
        /// <param name="mantissaRound"></param>
        /// <param name="bindItem"></param>
        /// <returns></returns>
        public List<AccountSetPara> GetAccountSetParaByCondition(string name,
                                                                 FieldAttributeEnum fieldAttribute, MantissaRoundEnum mantissaRound, BindItemEnum bindItem)
        {
            List<AccountSetPara> accountSetParaList = new List<AccountSetPara>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountSetParaName, SqlDbType.NVarChar, 255).Value = name;
            cmd.Parameters.Add(_ParmFieldAttribute, SqlDbType.Int).Value = fieldAttribute.Id;
            cmd.Parameters.Add(_ParmBindItem, SqlDbType.Int).Value = bindItem.Id;
            cmd.Parameters.Add(_ParmMantissaRound, SqlDbType.Int).Value = mantissaRound.Id;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccountSetParaByCondition", cmd))
            {
                while (sdr.Read())
                {
                    int pkid = Convert.ToInt32(sdr[_DBPKID]);
                    string accountSetParaName = sdr[_DBAccountSetParaName].ToString();
                    AccountSetPara accountSetPara = new AccountSetPara(pkid, accountSetParaName);
                    accountSetPara.BindItem = BindItemEnum.ChangeValueToBindItemEnum(Convert.ToInt32(sdr[_DBBindItem]));
                    accountSetPara.FieldAttribute = FieldAttributeEnum.ChangeValueToFieldAttributeEnum(Convert.ToInt32(sdr[_DBFieldAttribute]));
                    accountSetPara.MantissaRound = MantissaRoundEnum.ChangeValueToMantissaRoundEnum(Convert.ToInt32(sdr[_DBMantissaRound]));
                    accountSetPara.Description = sdr[_DBDescription].ToString();
                    accountSetPara.IsVisibleToEmployee = Convert.ToBoolean(sdr[_DBIsVisibleToEmployee]);
                    accountSetPara.IsVisibleWhenZero =
                        Convert.ToBoolean(sdr[_DBIsVisibleWhenZero]);
                    accountSetParaList.Add(accountSetPara);
                }
            }
            return accountSetParaList;
        }

        public AccountSetPara GetAccountSetParaByName(string accountSetParaName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountSetParaName, SqlDbType.NVarChar, 255).Value = accountSetParaName;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccountSetParaByName", cmd))
            {
                while (sdr.Read())
                {
                    int accountSetParaId = Convert.ToInt32(sdr[_DBPKID]);
                    string name = sdr[_DBAccountSetParaName].ToString();
                    AccountSetPara accountSetPara = new AccountSetPara(accountSetParaId, name);
                    accountSetPara.BindItem = BindItemEnum.ChangeValueToBindItemEnum(Convert.ToInt32(sdr[_DBBindItem]));
                    accountSetPara.FieldAttribute = FieldAttributeEnum.ChangeValueToFieldAttributeEnum(Convert.ToInt32(sdr[_DBFieldAttribute]));
                    accountSetPara.MantissaRound = MantissaRoundEnum.ChangeValueToMantissaRoundEnum(Convert.ToInt32(sdr[_DBMantissaRound]));
                    accountSetPara.Description = sdr[_DBDescription].ToString();
                    accountSetPara.IsVisibleToEmployee = Convert.ToBoolean(sdr[_DBIsVisibleToEmployee]);
                    accountSetPara.IsVisibleWhenZero =
                        Convert.ToBoolean(sdr[_DBIsVisibleWhenZero]);
                    return accountSetPara;
                }
            }
            return null;
        } 
        #endregion

        #region AccountSet
        /// <summary>
        /// 新增帐套，包括帐套项
        /// </summary>
        /// <param name="accountSet"></param>
        /// <returns></returns>
        public int InsertWholeAccountSet(AccountSet accountSet)
        {
            InitializeTranscation();
            int accountSetId;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmAccountSetName, SqlDbType.NVarChar, 255).Value = accountSet.AccountSetName;
                cmd.Parameters.Add(_ParmDescription, SqlDbType.Text).Value = accountSet.Description;

                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlHelper.TransExecuteNonQueryReturnPKID("InsertAccountSet", cmd, _Conn, _Trans, out accountSetId);
                //循环新增每一个项
                for(int i=0;i<accountSet.Items.Count;i++)
                {
                    InsertAccountSetItem(accountSetId,accountSet.Items[i],_Conn,_Trans);
                }
                _Trans.Commit();
            }
            catch
            {
                _Trans.Rollback();
                throw;
            }
            finally
            {
                _Conn.Close();
            }
            return accountSetId;
        }
        /// <summary>
        /// 更新帐套，包括帐套项
        /// </summary>
        /// <param name="accountSet"></param>
        /// <returns></returns>
        public int UpdateWholeAccountSet(AccountSet accountSet)
        {
            InitializeTranscation();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = accountSet.AccountSetID;
                cmd.Parameters.Add(_ParmAccountSetName, SqlDbType.NVarChar, 255).Value = accountSet.AccountSetName;
                cmd.Parameters.Add(_ParmDescription, SqlDbType.Text).Value = accountSet.Description;
                SqlHelper.TransExecuteNonQuery("UpdateAccountSet", cmd,_Conn, _Trans);
                //删除原有的每一个项
                DeleteAccountSetItemByAccountSetID(accountSet.AccountSetID, _Conn, _Trans);
                //循环新增每一个项
                for (int i = 0; i < accountSet.Items.Count; i++)
                {
                    InsertAccountSetItem(accountSet.AccountSetID, accountSet.Items[i],_Conn,_Trans);
                }
                _Trans.Commit();
            }
            catch
            {
                _Trans.Rollback();
                throw;
            }
            finally
            {
                _Conn.Close();
            }
            return accountSet.AccountSetID;
        }
        /// <summary>
        /// 删除帐套，包括帐套项
        /// </summary>
        /// <param name="accountSetID"></param>
        /// <returns></returns>
        public int DeleteWholeAccountSetByPKID(int accountSetID)
        {
            InitializeTranscation();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = accountSetID;
                SqlHelper.TransExecuteNonQuery("DeleteAccountSetByPKID", cmd, _Conn, _Trans);
                //删除原有的每一个项
                DeleteAccountSetItemByAccountSetID(accountSetID, _Conn, _Trans);
                
                _Trans.Commit();
            }
            catch
            {
                _Trans.Rollback();
                throw;
            }
            finally
            {
                _Conn.Close();
            }
            return accountSetID;
        }
        /// <summary>
        /// 通过PKID，和name查找数据库中除该PKID外是否还有同名数据
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int CountAccountSetByNameDiffPKID(int pkid, string name)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;
            cmd.Parameters.Add(_ParmAccountSetName, SqlDbType.NVarChar, 255).Value = name;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountAccountSetByNameDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    count = Convert.ToInt32(sdr[_DBCount]);
                    return count;
                }
            }
            return count;
        }
        /// <summary>
        /// 通过ID查找帐套，包括帐套项
        /// </summary>
        /// <param name="accountSetID"></param>
        /// <returns></returns>
        public AccountSet GetWholeAccountSetByPKID(int accountSetID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = accountSetID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccountSetByPKID", cmd))
            {
                while (sdr.Read())
                {
                    int accountSetPkid = Convert.ToInt32(sdr[_DBPKID]);
                    string name = sdr[_DBAccountSetName].ToString();
                    AccountSet accountSet = new AccountSet(accountSetPkid, name);
                    accountSet.Description = sdr[_DBDescription].ToString();
                    accountSet.Items = GetAccountSetItemByAccountSetID(accountSetID);
                    return accountSet;
                }
            }
            return null;
        }
        /// <summary>
        /// 通过姓名模糊查询
        /// </summary>
        ///  <param name="accountSetName"></param>
        /// <returns></returns>
        public List<AccountSet> GetAccountSetByCondition(string accountSetName)
        {
            List<AccountSet> accountSetList=new List<AccountSet>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountSetName, SqlDbType.NVarChar, 255).Value = accountSetName;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccountSetByCondition", cmd))
            {
                while (sdr.Read())
                {
                    int accountSetPkid = Convert.ToInt32(sdr[_DBPKID]);
                    string name = sdr[_DBAccountSetName].ToString();
                    AccountSet accountSet = new AccountSet(accountSetPkid, name);
                    accountSet.Description = sdr[_DBDescription].ToString();
                    accountSetList.Add(accountSet); 
                }
            }
            return accountSetList;
        }


        /// <summary>
        /// 通过姓名精确查询
        /// </summary>
        ///  <param name="accountSetName"></param>
        /// <returns></returns>
        public AccountSet GetAccountSetByName(string accountSetName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountSetName, SqlDbType.NVarChar, 255).Value = accountSetName;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccountSetByName", cmd))
            {
                while (sdr.Read())
                {
                    int accountSetPkid = Convert.ToInt32(sdr[_DBPKID]);
                    string name = sdr[_DBAccountSetName].ToString();
                    AccountSet accountSet = new AccountSet(accountSetPkid, name);
                    accountSet.Description = sdr[_DBDescription].ToString();
                    return accountSet;
                }
            }
            return null;
        }

        //

        #endregion

        #region AccountSetItem
        /// <summary>
        /// 新增帐套项
        /// </summary>
        /// <param name="accountSetID"></param>
        /// <param name="accountSetItem"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        private static void InsertAccountSetItem(int accountSetID,AccountSetItem accountSetItem, SqlConnection conn, SqlTransaction trans)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountSetID, SqlDbType.Int).Value = accountSetID;
            cmd.Parameters.Add(_ParmAccountSetParaID, SqlDbType.Int).Value = accountSetItem.AccountSetPara.AccountSetParaID;
            cmd.Parameters.Add(_ParmFieldAttribute, SqlDbType.Int).Value = accountSetItem.AccountSetPara.FieldAttribute.Id;
            cmd.Parameters.Add(_ParmBindItem, SqlDbType.Int).Value = accountSetItem.AccountSetPara.BindItem.Id;
            cmd.Parameters.Add(_ParmMantissaRound, SqlDbType.Int).Value = accountSetItem.AccountSetPara.MantissaRound.Id;
            cmd.Parameters.Add(_ParmCalculateFormula, SqlDbType.NVarChar,255).Value = accountSetItem.CalculateFormula;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlHelper.TransExecuteNonQueryReturnPKID("InsertAccountSetItem", cmd, conn, trans, out pkid);
            //return pkid;
        }
        /// <summary>
        /// 根据帐号ID删除相关的帐套项
        /// </summary>
        /// <param name="accountSetID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        private static void DeleteAccountSetItemByAccountSetID(int accountSetID, SqlConnection conn, SqlTransaction trans)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountSetID, SqlDbType.Int).Value = accountSetID;
            SqlHelper.TransExecuteNonQuery("DeleteAccountSetItemByAccountSetID", cmd, conn, trans);
        }
        /// <summary>
        /// 通过帐号ID查找相关的帐套项
        /// </summary>
        /// <param name="accountSetID"></param>
        /// <returns></returns>
        private static List<AccountSetItem> GetAccountSetItemByAccountSetID(int accountSetID)
        {
            List<AccountSetItem> accountSetItemList = new List<AccountSetItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountSetID, SqlDbType.Int).Value = accountSetID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccountSetItemByAccountSetID", cmd))
            {
                while (sdr.Read())
                {
                    int accountSetParaID = Convert.ToInt32(sdr[_DBAccountSetParaID]);
                    string name = sdr[_DBAccountSetParaName].ToString();
                    AccountSetPara accountSetPara = new AccountSetPara(accountSetParaID, name);
                    accountSetPara.BindItem = BindItemEnum.ChangeValueToBindItemEnum(Convert.ToInt32(sdr[_DBBindItem]));
                    accountSetPara.FieldAttribute = FieldAttributeEnum.ChangeValueToFieldAttributeEnum(Convert.ToInt32(sdr[_DBFieldAttribute]));
                    accountSetPara.MantissaRound = MantissaRoundEnum.ChangeValueToMantissaRoundEnum(Convert.ToInt32(sdr[_DBMantissaRound]));
                    accountSetPara.Description = sdr[_DBDescription].ToString();
                    accountSetPara.IsVisibleToEmployee = Convert.ToBoolean(sdr[_DBIsVisibleToEmployee]);
                    accountSetPara.IsVisibleWhenZero =
                        Convert.ToBoolean(sdr[_DBIsVisibleWhenZero]);

                    AccountSetItem accountSetItem =
                        new AccountSetItem(Convert.ToInt32(sdr[_DBPKID]), accountSetPara,
                                           sdr[_DBCalculateFormula].ToString());
                    accountSetItemList.Add(accountSetItem);
                }
            }
            return accountSetItemList;
        }
        /// <summary>
        /// 通过帐套参数ID查找是否有帐套使用
        /// </summary>
        /// <param name="accountSetParaID"></param>
        /// <returns></returns>
        public int CountAccountSetItemByAccountSetParaID(int accountSetParaID)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountSetParaID, SqlDbType.Int).Value = accountSetParaID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountAccountSetItemByAccountSetParaID", cmd))
            {
                while (sdr.Read())
                {
                    count = Convert.ToInt32(sdr[_DBCount]);
                    return count;
                }
            }
            return count;
        }

        #endregion
    }
}