//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: PhoneMessageForConfirmDal.cs
// Creater:  Xue.wenlong
// Date:  2009-05-22
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.Model.Accounts;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 
    /// </summary>
    public class PhoneMessageDal:IPhoneMessage 
    {
        private const string _PKID = "@PKID";
        private const string _RequesterID = "@RequesterID";
        private const string _RequesterName = "@RequesterName";
        private const string _AssessorID = "@AssessorID";
        private const string _AssessorName = "@AssessorName";
        private const string _TypeID = "@TypeID";
        private const string _Type = "@Type";
        private const string _Status = "@Status";
        private const string _Message = "@Message";
        private const string _Answer = "@Answer";
        private const string _InsertTime = "@InsertTime";
        private const string _SendTime = "@SendTime";

        private const string _DBPKID = "PKID";
        private const string _DBRequesterID = "RequesterID";
        private const string _DBAssessorID = "AssessorID";
        private const string _DBTypeID = "TypeID";
        private const string _DBType = "Type";
        private const string _DBStatus = "Status";
        private const string _DBMessage = "Message";
        private const string _DBAnswer = "Answer";
        private const string _DBCount = "Count";
        private const string _DBSendTime = "SendTime";

        /// <summary>
        /// 找出待审核和待发送
        /// </summary>
        /// <returns></returns>
        public List<PhoneMessage> GetNeedConfirmMessage()
        {
            List<PhoneMessage> phoneMessageList = new List<PhoneMessage>();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetNeedConfirmMessage", cmd))
            {
                while (sdr.Read())
                {
                    PhoneMessage phoneMessage= new PhoneMessage();
                    phoneMessage.Message = sdr[_DBMessage].ToString();
                    phoneMessage.PhoneMessageType = new PhoneMessageType((PhoneMessageEnumType)sdr[_DBType], Convert.ToInt32(sdr[_DBTypeID]));
                    phoneMessage.PKID = Convert.ToInt32(sdr[_DBPKID]);
                    phoneMessage.Requester = new Account(Convert.ToInt32(sdr[_DBRequesterID]), "", "");
                    phoneMessage.Assessor = new Account(Convert.ToInt32(sdr[_DBAssessorID]), "", "");
                    phoneMessage.Answer = sdr[_DBAnswer].ToString();
                    phoneMessage.Status = (PhoneMessageStatus)sdr[_DBStatus];
                    phoneMessage.SendTime = sdr[_DBSendTime] == DBNull.Value ? Convert.ToDateTime("2008-11-1") : Convert.ToDateTime(sdr[_DBSendTime]);
                    phoneMessageList.Add(phoneMessage);
                }
            }
            return phoneMessageList;
        }
        /// <summary>
        /// 修改短信内容
        /// </summary>
        public int UpdatePhoneMessage(PhoneMessage phoneMessage)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = phoneMessage.PKID;
            cmd.Parameters.Add(_AssessorID, SqlDbType.Int).Value = phoneMessage.Assessor.Id;
            cmd.Parameters.Add(_AssessorName, SqlDbType.NVarChar, 50).Value = phoneMessage.Assessor.Name;
            cmd.Parameters.Add(_Message, SqlDbType.NVarChar, 1000).Value = phoneMessage.Message;
            cmd.Parameters.Add(_Status, SqlDbType.Int).Value =phoneMessage.Status;
            cmd.Parameters.Add(_Answer, SqlDbType.NVarChar, 1000).Value = phoneMessage.Answer;
            cmd.Parameters.Add(_SendTime, SqlDbType.DateTime).Value = phoneMessage.SendTime == null ? DBNull.Value : (object)phoneMessage.SendTime.Value;
            return SqlHelper.ExecuteNonQuery("PhoneMessageUpdate", cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneMessage"></param>
        /// <returns></returns>
        public int InsertPhoneMessage(PhoneMessage phoneMessage)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_RequesterID, SqlDbType.Int).Value = phoneMessage.Requester.Id;
            cmd.Parameters.Add(_RequesterName, SqlDbType.NVarChar, 50).Value = phoneMessage.Requester.Name;
            cmd.Parameters.Add(_Type, SqlDbType.Int).Value = phoneMessage.PhoneMessageType.PhoneMessageEnumType;
            cmd.Parameters.Add(_TypeID, SqlDbType.Int).Value = phoneMessage.PhoneMessageType.PKID;
            cmd.Parameters.Add(_Message, SqlDbType.NVarChar, 1000).Value = phoneMessage.Message ?? "";
            cmd.Parameters.Add(_InsertTime, SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add(_AssessorID, SqlDbType.Int).Value = phoneMessage.Assessor.Id;
            cmd.Parameters.Add(_AssessorName, SqlDbType.NVarChar, 50).Value = phoneMessage.Assessor.Name;
            cmd.Parameters.Add(_Status, SqlDbType.Int).Value = phoneMessage.Status;
            cmd.Parameters.Add(_Answer, SqlDbType.NVarChar, 1000).Value = phoneMessage.Answer ?? "";
            SqlHelper.ExecuteNonQueryReturnPKID("PhoneMessageInsert", cmd, out pkid);
            return pkid;
        }

 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneMessageType"></param>
        /// <returns></returns>
        public PhoneMessage GetPhoneMessageByType(PhoneMessageType phoneMessageType)
        {
            PhoneMessage phoneMessage = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_Type, SqlDbType.Int).Value = phoneMessageType.PhoneMessageEnumType;
            cmd.Parameters.Add(_TypeID, SqlDbType.Int).Value = phoneMessageType.PKID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPhoneMessageByType", cmd))
            {
                while (sdr.Read())
                {
                    phoneMessage = new PhoneMessage();
                    phoneMessage.Message = sdr[_DBMessage].ToString();
                    phoneMessage.PhoneMessageType = new PhoneMessageType((PhoneMessageEnumType)sdr[_DBType], Convert.ToInt32(sdr[_DBTypeID]));
                    phoneMessage.PKID = Convert.ToInt32(sdr[_DBPKID]);
                    phoneMessage.Requester = new Account(Convert.ToInt32(sdr[_DBRequesterID]), "", "");
                    phoneMessage.Assessor = new Account(Convert.ToInt32(sdr[_DBAssessorID]), "", "");
                    phoneMessage.Answer = sdr[_DBAnswer].ToString();
                    phoneMessage.Status = (PhoneMessageStatus)sdr[_DBStatus];
                    phoneMessage.SendTime = sdr[_DBSendTime] == DBNull.Value ? Convert.ToDateTime("2008-11-1") : Convert.ToDateTime(sdr[_DBSendTime]);
                }
            }
            return phoneMessage;
        }
        /// <summary>
        /// 
        /// </summary>
        public PhoneMessage GetPhoneMessageByPKID(int PKID)
        {
            PhoneMessage phoneMessage = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = PKID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPhoneMessageByPKID", cmd))
            {
                while (sdr.Read())
                {
                    phoneMessage = new PhoneMessage();
                    phoneMessage.Message = sdr[_DBMessage].ToString();
                    phoneMessage.PhoneMessageType = new PhoneMessageType((PhoneMessageEnumType)sdr[_DBType], Convert.ToInt32(sdr[_DBTypeID]));
                    phoneMessage.PKID = Convert.ToInt32(sdr[_DBPKID]);
                    phoneMessage.Requester = new Account(Convert.ToInt32(sdr[_DBRequesterID]), "", "");
                    phoneMessage.Assessor = new Account(Convert.ToInt32(sdr[_DBAssessorID]), "", "");
                    phoneMessage.Answer = sdr[_DBAnswer].ToString();
                    phoneMessage.Status = (PhoneMessageStatus)sdr[_DBStatus];
                    phoneMessage.SendTime = sdr[_DBSendTime] == DBNull.Value ? Convert.ToDateTime("2008-11-1") : Convert.ToDateTime(sdr[_DBSendTime]);
                }
            }
            return phoneMessage;
        }
        /// <summary>
        /// 
        /// </summary>
        public PhoneMessage GetToBeConfirmPhoneMessageByAssessorID(int employeeID)
        {
            PhoneMessage phoneMessage = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AssessorID, SqlDbType.Int).Value = employeeID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetToBeConfirmPhoneMessageByAssessorID", cmd))
            {
                while (sdr.Read())
                {
                    phoneMessage = new PhoneMessage();
                    phoneMessage.Message = sdr[_DBMessage].ToString();
                    phoneMessage.PhoneMessageType = new PhoneMessageType((PhoneMessageEnumType)sdr[_DBType], Convert.ToInt32(sdr[_DBTypeID]));
                    phoneMessage.PKID = Convert.ToInt32(sdr[_DBPKID]);
                    phoneMessage.Requester = new Account(Convert.ToInt32(sdr[_DBRequesterID]), "", "");
                    phoneMessage.Assessor = new Account(Convert.ToInt32(sdr[_DBAssessorID]), "", "");
                    phoneMessage.Answer = sdr[_DBAnswer].ToString();
                    phoneMessage.Status = (PhoneMessageStatus)sdr[_DBStatus];
                    phoneMessage.SendTime = sdr[_DBSendTime] == DBNull.Value ? Convert.ToDateTime("2008-11-1") : Convert.ToDateTime(sdr[_DBSendTime]);
                }
            }
            return phoneMessage;
        }
      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PKID"></param>
        /// <returns></returns>
        public int FinishPhoneMessageByPKID(int PKID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = PKID;
            return SqlHelper.ExecuteNonQuery("FinishPhoneMessageByPKID", cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int CountToBeConfirmMessageWithSameAssessor(int assessorID)
        {
            int _retVal = -1;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AssessorID, SqlDbType.Int).Value = assessorID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountToBeConfirmMessageWithSameAssessor", cmd))
            {
                while (sdr.Read())
                {
                    _retVal = Convert.ToInt32(sdr[_DBCount]);
                }
            }
            return _retVal;
        }

        /// <summary>
        /// 为测试清理数据
        /// </summary>
        public int DeleteMessageByPKID(int PKID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = PKID;
            return SqlHelper.ExecuteNonQuery("PhoneMessageDelete", cmd);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PhoneMessage> GetToBeConfirmMessage()
        {
            List<PhoneMessage> phoneMessageList = new List<PhoneMessage>();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetToBeConfirmMessage", cmd))
            {
                while (sdr.Read())
                {
                    PhoneMessage phoneMessage = new PhoneMessage();
                    phoneMessage.Message = sdr[_DBMessage].ToString();
                    phoneMessage.PhoneMessageType = new PhoneMessageType((PhoneMessageEnumType)sdr[_DBType], Convert.ToInt32(sdr[_DBTypeID]));
                    phoneMessage.PKID = Convert.ToInt32(sdr[_DBPKID]);
                    phoneMessage.Requester = new Account(Convert.ToInt32(sdr[_DBRequesterID]), "", "");
                    phoneMessage.Assessor = new Account(Convert.ToInt32(sdr[_DBAssessorID]), "", "");
                    phoneMessage.Answer = sdr[_DBAnswer].ToString();
                    phoneMessage.Status = (PhoneMessageStatus)sdr[_DBStatus];
                    phoneMessage.SendTime = sdr[_DBSendTime] == DBNull.Value ? Convert.ToDateTime("2008-11-1") : Convert.ToDateTime(sdr[_DBSendTime]);
                    phoneMessageList.Add(phoneMessage);
                }
            }
            return phoneMessageList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PhoneMessage> GetPhoneMessageByCondition(int assessorID, PhoneMessageStatus status)
        {
            List<PhoneMessage> phoneMessageList = new List<PhoneMessage>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AssessorID, SqlDbType.Int).Value = assessorID;
            cmd.Parameters.Add(_Status, SqlDbType.Int).Value = status;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPhoneMessageByCondition", cmd))
            {
                while (sdr.Read())
                {
                    PhoneMessage phoneMessage = new PhoneMessage();
                    phoneMessage.Message = sdr[_DBMessage].ToString();
                    phoneMessage.PhoneMessageType = new PhoneMessageType((PhoneMessageEnumType)sdr[_DBType], Convert.ToInt32(sdr[_DBTypeID]));
                    phoneMessage.PKID = Convert.ToInt32(sdr[_DBPKID]);
                    phoneMessage.Requester = new Account(Convert.ToInt32(sdr[_DBRequesterID]), "", "");
                    phoneMessage.Assessor = new Account(Convert.ToInt32(sdr[_DBAssessorID]), "", "");
                    phoneMessage.Answer = sdr[_DBAnswer].ToString();
                    phoneMessage.Status = (PhoneMessageStatus)sdr[_DBStatus];
                    phoneMessage.SendTime = sdr[_DBSendTime] == DBNull.Value ? Convert.ToDateTime("2008-11-1") : Convert.ToDateTime(sdr[_DBSendTime]);
                    phoneMessageList.Add(phoneMessage);
                }
            }
            return phoneMessageList;
        }
    }
}