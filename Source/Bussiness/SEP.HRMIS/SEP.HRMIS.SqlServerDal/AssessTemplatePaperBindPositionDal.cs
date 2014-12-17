//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: AssessTemplatePaperBindPositionDal.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-06
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.Model.Positions;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 
    /// </summary>
    public class AssessTemplatePaperBindPositionDal : IAssessTemplatePaperBindPosition
    {
        private const string _PKID = "@PKID";
        private const string _PaperID = "@PaperID";
        private const string _PositionID = "@PositionID";
        private const string _DbPositionID = "PositionID";
        private const string _DbPaperID = "PaperID";
        /// <summary>
        /// 
        /// </summary>
        public int Insert(int paperID, int positionID)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_PaperID, SqlDbType.Int).Value = paperID;
            cmd.Parameters.Add(_PositionID, SqlDbType.Int).Value = positionID;
            SqlHelper.ExecuteNonQueryReturnPKID("AssessTemplatePaperBindPostionInsert", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// 
        /// </summary>
        public int DeleteByPaperID(int paperID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PaperID, SqlDbType.Int).Value = paperID;
            return SqlHelper.ExecuteNonQuery("DeleteAssessTemplatePaperBindPostionByPaperID", cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Position> GetBindPostionByPaperID(int paperID)
        {
            List<Position> positionList = new List<Position>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_PaperID, SqlDbType.Int).Value = paperID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAssessTemplatePaperBindPostionByPaperID", cmd))
            {
                while (sdr.Read())
                {
                    positionList.Add(new Position(Convert.ToInt32(sdr[_DbPositionID]), "", null));
                }
            }
            return positionList;
        }


        /// <summary>
        /// 
        /// </summary>
        public List<Position> GetAssessTemplatePaperBindPostionByPositionIDDiffPaperID(int paperID, int positionID)
        {
            List<Position> positionList = new List<Position>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PaperID, SqlDbType.Int).Value = paperID;
            cmd.Parameters.Add(_PositionID, SqlDbType.Int).Value = positionID;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetAssessTemplatePaperBindPostionByPositionIDDiffPaperID", cmd))
            {
                while (sdr.Read())
                {
                    positionList.Add(new Position(Convert.ToInt32(sdr[_DbPositionID]), "", null));
                }
            }
            return positionList;
        }

        /// <summary>
        /// 
        /// </summary>
        public int GetAssessTemplatePaperIDByPositionID( int positionID)
        {
            int ret = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PositionID, SqlDbType.Int).Value = positionID;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetAssessTemplatePaperBindPostionByPositionID", cmd))
            {
                while (sdr.Read())
                {
                    ret = Convert.ToInt32(sdr[_DbPaperID]);
                }
            }
            return ret;
        }
    }
}