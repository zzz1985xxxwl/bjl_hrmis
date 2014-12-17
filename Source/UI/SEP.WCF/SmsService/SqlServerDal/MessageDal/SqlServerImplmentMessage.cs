//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SqlServerImplment.cs
// 创建者: 倪豪
// 创建日期: 2008-11-24
// 概述: SqlServer实现Message存储接口
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SmsDataContract;
using SqlServerDal.MessageDal;

namespace SqlServerDal.MessageDal
{
    public class SqlServerImplMessage : IMessageDal
    {
        //参数
        private const string _PKID = "@PKID";
        private const string _SendStatusEnum = "@SendStatusEnum";
        private const string _SystemSmsId = "@SystemSmsId";
        private const string _SendToNumber = "@SendToNumber";
        private const string _SystemNumber = "@SystemNumber";
        private const string _LastestSendTime = "@LastestSendTime";
        private const string _HrmisId = "@HrmisId";
        private const string _Content = "@Content";
        private const string _TriedCount = "@TriedCount";
        private const string _BoradCasted = "@BoradCasted";
        private const string _Id = "@Id";
        private const string _TheNumber = "@TheNumber";
        private const string _ReceivedTime = "@ReceivedTime";
        private const string _IsCleanMessage = "@IsCleanMessage";
        //数据库字段
        private const string _DBPKID = "PKID";
        private const string _DBSendToNumber = "SendToNumber";
        private const string _DBHrmisId = "HrmisId";
        private const string _DBSystemSmsId = "SystemSmsId";
        private const string _DBSystemNumber = "SystemNumber";
        private const string _DBSendStatusEnum = "SendStatusEnum";
        private const string _DBBoradCasted = "BoradCasted";
        private const string _DBContent = "Content";
        private const string _DBTriedCount = "TriedCount";
        private const string _DBIsCleanMessage = "IsCleanMessage";
        private const string _DBId = "Id";
        private const string _DBTheNumber = "TheNumber";
        private const string _DBReceivedTime = "ReceivedTime";
        private const string _DBLastestSendTime = "LastestSendTime";

        #region IMessageDal 成员
        /// <summary>
        /// 保存短信，如果是新增的短信则新增，如果只是修改短信，则修改，
        /// </summary>
        public void SaveSendMessage(SendMessageDataModel aMessage)
        {
            if(!aMessage.IsObjectStatus)
            {
                SendMessageInsert(aMessage);
            }
            else
            {
                SendMessageUpdate(aMessage);
            }
        }

        public void SaveReceiveMessage(ReceiveMessageDataModel aMessage)
        {
            if (!aMessage.IsObjectStatus)
            {
                ReceiveMessageInsert(aMessage);
            }
            else
            {
                ReceiveMessageUpdate(aMessage);
            }
        }

        public void DeleteSendMessageByPkid(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pkid;
            SqlHelper.ExecuteNonQuery("DeleteSendMessageByPkid", cmd);
        }

        public void DeleteReceiveMessageByPkid(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pkid;
            SqlHelper.ExecuteNonQuery("DeleteReceiveMessageByPkid", cmd);
        }

        public List<SendMessageDataModel> GetSendMessageByStatus(SendStatusEnum theStatus)
        {
            return GetSendMessageByStatus((int)theStatus);
        }

        public List<SendMessageDataModel> GetAllSendMessages()
        {
            List<SendMessageDataModel> retVal = new List<SendMessageDataModel>();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllSendMessage", cmd))
            {
                while (sdr.Read())
                {
                    SendMessageDataModel aMessage = new SendMessageDataModel(int.Parse(sdr[_DBSystemSmsId].ToString()), sdr[_DBSendToNumber].ToString(), sdr[_DBContent].ToString(), sdr[_DBHrmisId].ToString());
                    aMessage.SystemNumber = sdr[_DBSystemNumber].ToString();
                    aMessage.TheStatus = (SendStatusEnum)sdr[_DBSendStatusEnum];
                    aMessage.TriedCount = int.Parse(sdr[_DBTriedCount].ToString());
                    aMessage.SendTime = DateTime.Parse(sdr[_DBLastestSendTime].ToString());
                    aMessage.IsObjectStatus = true;
                    aMessage.Pkid = int.Parse(sdr[_DBPKID].ToString());
                    retVal.Add(aMessage);
                }
            }
            return retVal;
        }

        public List<ReceiveMessageDataModel> GetReceiveMessageByStatus(bool broadCasted)
        {
            int theParameter = broadCasted ? 1 : 0;
            return GetReceiveMessageByStatus(theParameter);
        }

        public List<ReceiveMessageDataModel> GetAllReceiveMessages()
        {
            List<ReceiveMessageDataModel> retVal = new List<ReceiveMessageDataModel>();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllReceiveMessage", cmd))
            {
                while (sdr.Read())
                {
                    ReceiveMessageDataModel aMessage = new ReceiveMessageDataModel(int.Parse(sdr[_DBId].ToString()), sdr[_DBTheNumber].ToString(), sdr[_DBContent].ToString(), DateTime.Parse(sdr[_DBReceivedTime].ToString()));
                    aMessage.IsCleanMessage = int.Parse(sdr[_DBIsCleanMessage].ToString()) == 0 ? false : true;
                    aMessage.BoradCasted = int.Parse(sdr[_DBBoradCasted].ToString()) == 0 ? false : true;
                    aMessage.IsObjectStatus = true;
                    aMessage.Pkid = int.Parse(sdr[_DBPKID].ToString());
                    retVal.Add(aMessage);
                }
            }
            return retVal;
        }

        public void DeleteAllSendMessage()
        {
            DeleteSendMessageByPkid(-1);
        }

        public void DeleteAllReceiveMessage()
        {
            DeleteReceiveMessageByPkid(-1);
        }


        #endregion

        #region 私有方法

        private List<SendMessageDataModel> GetSendMessageByStatus(int theStatus)
        {
            List<SendMessageDataModel> retVal = new List<SendMessageDataModel>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_SendStatusEnum, SqlDbType.Int).Value = theStatus;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetSendMessageByStatus", cmd))
            {
                while (sdr.Read())
                {
                    SendMessageDataModel aMessage = new SendMessageDataModel(int.Parse(sdr[_DBSystemSmsId].ToString()), sdr[_DBSendToNumber].ToString(), sdr[_DBContent].ToString(), sdr[_DBHrmisId].ToString());
                    aMessage.SystemNumber = sdr[_DBSystemNumber].ToString();
                    aMessage.TheStatus = (SendStatusEnum)sdr[_DBSendStatusEnum];
                    aMessage.TriedCount = int.Parse(sdr[_DBTriedCount].ToString());
                    aMessage.SendTime = DateTime.Parse(sdr[_DBLastestSendTime].ToString());
                    aMessage.IsObjectStatus = true;
                    aMessage.Pkid = int.Parse(sdr[_DBPKID].ToString());
                    retVal.Add(aMessage);
                }
            }
            return retVal;
        }

        public List<ReceiveMessageDataModel> GetReceiveMessageByStatus(int broadCasted)
        {
            List<ReceiveMessageDataModel> retVal = new List<ReceiveMessageDataModel>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_BoradCasted, SqlDbType.Int).Value = broadCasted;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetReceiveMessageByStatus", cmd))
            {
                while (sdr.Read())
                {
                    ReceiveMessageDataModel aMessage = new ReceiveMessageDataModel(int.Parse(sdr[_DBId].ToString()), sdr[_DBTheNumber].ToString(), sdr[_DBContent].ToString(), DateTime.Parse(sdr[_DBReceivedTime].ToString()));
                    aMessage.IsCleanMessage = int.Parse(sdr[_DBIsCleanMessage].ToString()) == 0 ? false : true;
                    aMessage.BoradCasted = int.Parse(sdr[_DBBoradCasted].ToString()) == 0 ? false : true;
                    aMessage.IsObjectStatus = true;
                    aMessage.Pkid = int.Parse(sdr[_DBPKID].ToString());
                    retVal.Add(aMessage);
                }
            }
            return retVal;
        }

        private void SendMessageInsert(SendMessageDataModel message)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            TheNeedParametersForSendMessage(cmd, message);
            int pkid;
            SqlHelper.ExecuteNonQueryReturnPKID("SendMessageInsert", cmd, out pkid);
            message.Pkid = pkid;
        }

        private void SendMessageUpdate(SendMessageDataModel message)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = message.Pkid;
            TheNeedParametersForSendMessage(cmd, message);
            SqlHelper.ExecuteNonQuery("SendMessageUpdate", cmd);
        }

        private void ReceiveMessageInsert(ReceiveMessageDataModel message)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            TheNeedParametersForReceiveMessageMessage(cmd, message);
            int pkid;
            SqlHelper.ExecuteNonQueryReturnPKID("ReceiveMessageInsert", cmd, out pkid);
            message.Pkid = pkid;
        }

        private void ReceiveMessageUpdate(ReceiveMessageDataModel message)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = message.Pkid;
            TheNeedParametersForReceiveMessageMessage(cmd, message);
            SqlHelper.ExecuteNonQuery("ReceiveMessageUpdate", cmd);
        }

        private void TheNeedParametersForSendMessage(SqlCommand cmd, SendMessageDataModel message)
        {
            cmd.Parameters.Add(_SendStatusEnum, SqlDbType.Int).Value = message.TheStatus;
            cmd.Parameters.Add(_SystemSmsId, SqlDbType.Int).Value = message.SystemSmsId;
            cmd.Parameters.Add(_SendToNumber, SqlDbType.NVarChar, 50).Value = message.SendNumber;
            cmd.Parameters.Add(_SystemNumber, SqlDbType.NVarChar, 50).Value = message.SystemNumber;
            cmd.Parameters.Add(_Content, SqlDbType.NVarChar, 1000).Value = message.Content;
            cmd.Parameters.Add(_TriedCount, SqlDbType.Int).Value = message.TriedCount;
            cmd.Parameters.Add(_LastestSendTime, SqlDbType.DateTime).Value = message.SendTime < new DateTime(1900, 1, 1) ? new DateTime(1900, 1, 1) : message.SendTime;
            cmd.Parameters.Add(_HrmisId, SqlDbType.NVarChar, 255).Value = message.HrmisId;
        }

        private void TheNeedParametersForReceiveMessageMessage(SqlCommand cmd, ReceiveMessageDataModel message)
        {
            cmd.Parameters.Add(_BoradCasted, SqlDbType.Int).Value = message.BoradCasted;
            cmd.Parameters.Add(_Id, SqlDbType.Int).Value = message.Id;
            cmd.Parameters.Add(_TheNumber, SqlDbType.NVarChar, 50).Value = message.TheNumber;
            cmd.Parameters.Add(_Content, SqlDbType.NVarChar, 1000).Value = message.Content;
            cmd.Parameters.Add(_ReceivedTime, SqlDbType.DateTime).Value = message.ReceivedTime < new DateTime(1900, 1, 1) ? new DateTime(1900, 1, 1) : message.ReceivedTime;
            cmd.Parameters.Add(_IsCleanMessage, SqlDbType.Int).Value = message.IsCleanMessage;
        }

        #endregion

    }
}