//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: AdjustRestDal.cs
// Creater:  Xue.wenlong
// Date:  2009-04-13
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAdjustRest;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 
    /// </summary>
    public class AdjustRestDal : IAdjustRest
    {
        private const string _Hours = "@Hours";
        private const string _AccountID = "@AccountID";
        private const string _AdjustYear = "@AdjustYear";
        private const string _PKID = "@PKID";
        private const string _DbHours = "Hours";
        private const string _DBPKID = "PKID";
        private const string _DBAccountID = "AccountId";
        private const string _DBAdjustYear = "AdjustYear";
        private const string _DBError = "数据库访问错误!";


        /// <summary>
        /// 更新调休
        /// </summary>
        public int UpdateAdjustRest(AdjustRest adjustRest)
        {
            int count = 1;
            bool hasValue;
            Get(adjustRest.Employee.Account.Id, adjustRest.AdjustYear, out hasValue);
            if (hasValue)
            {
                count = Update(adjustRest);
            }
            else
            {
                InsertAdjustRest(adjustRest);
            }
            return count;
        }

        public AdjustRest GetAdjustRestByPKID(int adjustID)
        {
            AdjustRest adjustRest = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = adjustID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAdjustRestByPKID", cmd))
            {
                if (sdr.Read())
                {
                    adjustRest=GetFieldFromParm(sdr);
                }
            }
            return adjustRest;
        }

        public AdjustRest GetAdjustRestByAccountIDAndYear(int accountid, DateTime adjustYear)
        {
            bool hasValue;
            AdjustRest adjustrest = Get(accountid, adjustYear, out hasValue);
            if (!hasValue)
            {
                adjustrest = new AdjustRest(0, 0, new Employee(accountid, EmployeeTypeEnum.All), adjustYear);
                adjustrest.AdjustRestID=InsertAdjustRest(adjustrest);
            }
            return adjustrest;
        }

        /// <summary>
        /// 
        /// </summary>
        public int InsertAdjustRest(AdjustRest adjustRest)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = adjustRest.Employee.Account.Id;
            cmd.Parameters.Add(_Hours, SqlDbType.Decimal).Value = adjustRest.SurplusHours;
            cmd.Parameters.Add(_AdjustYear, SqlDbType.DateTime).Value = new DateTime(adjustRest.AdjustYear.Year, 1, 1);
            SqlHelper.ExecuteNonQueryReturnPKID("AdjustRestInsert", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// 
        /// </summary>
        public int DeleteAdjustRestByAccountID(int accountID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            return SqlHelper.ExecuteNonQuery("DeleteAdjustRestByAccountID", cmd);
        }

        public List<AdjustRest> GetAdjustRestByAccountID(int accountID)
        {
            List<AdjustRest> iRet = new List<AdjustRest>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            try
            {
                using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAdjustRestByAccountID", cmd))
                {
                    while (sdr.Read())
                    {
                        AdjustRest adjustRest = GetFieldFromParm(sdr);
                        iRet.Add(adjustRest);
                    }
                }
                return iRet;
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
        }


        private static int Update(AdjustRest adjustrest)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = adjustrest.AdjustRestID;
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = adjustrest.Employee.Account.Id;
            cmd.Parameters.Add(_Hours, SqlDbType.Decimal).Value = adjustrest.SurplusHours;
            cmd.Parameters.Add(_AdjustYear, SqlDbType.DateTime).Value = new DateTime(adjustrest.AdjustYear.Year,1,1) ;
            return SqlHelper.ExecuteNonQuery("UpdateAdjustRestByAdjustID", cmd);
        }

        private static AdjustRest Get(int accountID, DateTime adjustYear, out bool hasvalue)
        {
            AdjustRest adjustRest = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_AdjustYear, SqlDbType.DateTime).Value = adjustYear;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAdjustRestByAccountIDAndYear", cmd))
            {
                if (sdr.Read())
                {
                    adjustRest=GetFieldFromParm(sdr);
                    hasvalue = true;
                }
                else
                {
                    hasvalue = false;
                }
            }
            return adjustRest;
        }

        /// <summary>
        /// 所有GET数据绑定
        /// </summary>
        private static AdjustRest GetFieldFromParm(IDataRecord sdr)
        {
            AdjustRest adjustRest=new AdjustRest();
            for (int i = 0; i < sdr.FieldCount; i++)
            {
                int tryIntParse;
                switch (sdr.GetName(i))
                {
                    case _DBPKID:
                        if (sdr[_DBPKID] != null && int.TryParse(sdr[_DBPKID].ToString(), out tryIntParse))
                        {
                            adjustRest.AdjustRestID = (int) sdr[_DBPKID];
                        }
                        break;
                    case _DBAccountID:
                        if (sdr[_DBAccountID] != null && int.TryParse(sdr[_DBAccountID].ToString(), out tryIntParse))
                        {
                            adjustRest.Employee = adjustRest.Employee ??
                                                  new Employee((int) sdr[_DBAccountID], EmployeeTypeEnum.All);
                        }
                        break;
                    case _DbHours:
                        decimal tryDecimalParse;
                        if (sdr[_DbHours] != null && decimal.TryParse(sdr[_DbHours].ToString(), out tryDecimalParse))
                        {
                            adjustRest.SurplusHours = (decimal) sdr[_DbHours];
                        }
                        break;
                    case _DBAdjustYear:
                        if (sdr[_DBAdjustYear] != null)
                        {
                            adjustRest.AdjustYear = Convert.ToDateTime(sdr[_DBAdjustYear]);
                        }
                        break;
                    default:
                        break;
                }
            }
            return adjustRest;
        }
    }
}