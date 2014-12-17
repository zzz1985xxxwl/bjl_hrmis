//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IndividualIncomeTaxDal.cs
// 创建者: Xue.wenlong
// 创建日期: 2008-12-24
// 概述: 数据库访问类
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.SqlServerDal.PayModule
{
    ///<summary>
    ///</summary>
    public class TaxDal : ITax
    {
        private const string _PKID = "@PKID";
        private const string _BandMin = "@BandMin";
        private const string _TaxRate = "@TaxRate";
        //0代表起征税，1代表税阶，2,代表国外起征点，代表起征点时，数字存BandMin
        private const string _Type = "@Type";
        private const string _DbPKID = "PKID";
        private const string _DbBandMin = "BandMin";
        private const string _DbTaxRate = "TaxRate";

        private const string _DbCount = "counts";

        public int InsertTaxCutoffPoint(decimal taxCutoffPoint)
        {
            return InsertIndividualIncomeTax(taxCutoffPoint, 0, 0);
        }

        public int UpdateTaxCutoffPoint(decimal taxCutoffPoint)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_BandMin, SqlDbType.Decimal).Value = taxCutoffPoint;
            return SqlHelper.ExecuteNonQuery("UpdateTaxCutoffPoint", cmd);
        }
        public int InsertForeignTaxCutoffPoint(decimal taxForeignCutoffPoint)
        {
            return InsertIndividualIncomeTax(taxForeignCutoffPoint, 0, 2);
        }

        public int UpdateForeignTaxCutoffPoint(decimal taxForeignCutoffPoint)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_BandMin, SqlDbType.Decimal).Value = taxForeignCutoffPoint;
            return SqlHelper.ExecuteNonQuery("UpdateForeignTaxCutoffPoint", cmd);
        }
        public decimal GetTaxCutoffPoint()
        {
            decimal taxCutoffPoint = -1;
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetTaxCutoffPoint", cmd))
            {
                while (sdr.Read())
                {
                    taxCutoffPoint = Convert.ToDecimal(sdr[_DbBandMin]);
                }
            }
            return taxCutoffPoint;
        }
        /// <summary>
        /// 得到外国起征点
        /// </summary>
        /// <returns>为空则返回-1</returns>
        public decimal GetForeignTaxCutoffPoint()
        {
            decimal taxCutoffPoint = -1;
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetForeignTaxCutoffPoint", cmd))
            {
                while (sdr.Read())
                {
                    taxCutoffPoint = Convert.ToDecimal(sdr[_DbBandMin]);
                }
            }
            return taxCutoffPoint;
        }
        public int InsertTaxBand(decimal bandMin, decimal taxRate)
        {
            return InsertIndividualIncomeTax(bandMin, taxRate, 1);
        }

        private static int InsertIndividualIncomeTax(decimal bandMin, decimal taxRate, int type)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_BandMin, SqlDbType.Decimal).Value = bandMin;
            cmd.Parameters.Add(_TaxRate, SqlDbType.Decimal).Value = taxRate;
            cmd.Parameters.Add(_Type, SqlDbType.Int).Value = type;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertIndividualIncomeTax", cmd, out pkid);
            return pkid;
        }

        public int UpdateTaxBand(int taxBandID, decimal bandMin, decimal taxRate)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = taxBandID;
            cmd.Parameters.Add(_BandMin, SqlDbType.Decimal).Value = bandMin;
            cmd.Parameters.Add(_TaxRate, SqlDbType.Decimal).Value = taxRate;
            return SqlHelper.ExecuteNonQuery("UpdateTaxBand", cmd);
        }

        public int DeleteTaxBandByTaxBandID(int taxBandID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = taxBandID;
            return SqlHelper.ExecuteNonQuery("DeleteTaxBandByTaxBandID", cmd);
        }

        public TaxBand GetTaxBandByTaxBandID(int taxBandID)
        {
            TaxBand taxBand = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = taxBandID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetTaxBandByTaxBandID", cmd))
            {
                while (sdr.Read())
                {
                    taxBand =
                        new TaxBand(Convert.ToInt32(sdr[_DbPKID]), Convert.ToDecimal(sdr[_DbBandMin]),
                                    Convert.ToDecimal(sdr[_DbTaxRate]));
                }
            }
            return taxBand;
        }

        public List<TaxBand> GetAllTaxBand()
        {
            List<TaxBand> taxBandList = new List<TaxBand>();
            SqlCommand cmd = new SqlCommand();

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllTaxBand", cmd))
            {
                while (sdr.Read())
                {
                    TaxBand taxBand =
                        new TaxBand(Convert.ToInt32(sdr[_DbPKID]), Convert.ToDecimal(sdr[_DbBandMin]),
                                    Convert.ToDecimal(sdr[_DbTaxRate]));
                    taxBandList.Add(taxBand);
                }
            }
            return taxBandList;
        }

        public int GetTaxBandCountByBindMin(decimal bandMin)
        {
            int retVal = -1;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_BandMin, SqlDbType.Decimal).Value = bandMin;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetTaxBandCountByBindMin", cmd))
            {
                while (sdr.Read())
                {
                    retVal = Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return retVal;
        }

        public int GetTaxBandCountByBindMinDiffPKID(int taxBandID, decimal bandMin)
        {
            int retVal = -1;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = taxBandID;
            cmd.Parameters.Add(_BandMin, SqlDbType.Decimal).Value = bandMin;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetTaxBandCountByBindMinDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    retVal = Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return retVal;
        }
    }
}