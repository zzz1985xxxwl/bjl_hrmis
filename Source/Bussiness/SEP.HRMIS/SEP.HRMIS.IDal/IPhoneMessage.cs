//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IPhoneMessage.cs
// Creater:  Xue.wenlong
// Date:  2009-05-22
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.PhoneMessage;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPhoneMessage
    {
        /// <summary>
        /// 
        /// </summary>
        List<PhoneMessage> GetNeedConfirmMessage();

        /// <summary>
        /// 插入时不会插入消息发送时间，因为正常情况下，插入时的状态为新增
        /// </summary>
        int InsertPhoneMessage(PhoneMessage phoneMessage);
        /// <summary>
        /// 
        /// </summary>
        PhoneMessage GetPhoneMessageByType(PhoneMessageType phoneMessageType);
        /// <summary>
        /// 
        /// </summary>
        PhoneMessage GetPhoneMessageByPKID(int PKID);

        /// <summary>
        /// 通过ReceiverID找到一条已被发送，准备处理的记录
        /// </summary>
        PhoneMessage GetToBeConfirmPhoneMessageByAssessorID(int accountID);

        /// <summary>
        /// 将短信状态变为处理完
        /// </summary>
        int FinishPhoneMessageByPKID(int PKID);


        /// <summary>
        /// 查找同一个接收者，是否有待确认的申请的数量
        /// </summary>
        int CountToBeConfirmMessageWithSameAssessor(int AssessorID);
        /// <summary>
        /// 
        /// </summary>
        List<PhoneMessage> GetToBeConfirmMessage();

        /// <summary>
        /// 修改短信，只修改message
        /// </summary>
        int UpdatePhoneMessage(PhoneMessage phoneMessage);

        /// <summary>
        /// 删除PhoneMessageOperation
        /// </summary>
        //int DeletePhoneMessageOperationByPhoneMessageID(int phoneMessageID);

        /// <summary>
        /// 为测试删除数据
        /// </summary>
        int DeleteMessageByPKID(int pkid);

        /// <summary>
        /// 
        /// </summary>
        List<PhoneMessage> GetPhoneMessageByCondition(int assessorID, PhoneMessageStatus status);
        
    }
}