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
        /// ����ʱ���������Ϣ����ʱ�䣬��Ϊ��������£�����ʱ��״̬Ϊ����
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
        /// ͨ��ReceiverID�ҵ�һ���ѱ����ͣ�׼������ļ�¼
        /// </summary>
        PhoneMessage GetToBeConfirmPhoneMessageByAssessorID(int accountID);

        /// <summary>
        /// ������״̬��Ϊ������
        /// </summary>
        int FinishPhoneMessageByPKID(int PKID);


        /// <summary>
        /// ����ͬһ�������ߣ��Ƿ��д�ȷ�ϵ����������
        /// </summary>
        int CountToBeConfirmMessageWithSameAssessor(int AssessorID);
        /// <summary>
        /// 
        /// </summary>
        List<PhoneMessage> GetToBeConfirmMessage();

        /// <summary>
        /// �޸Ķ��ţ�ֻ�޸�message
        /// </summary>
        int UpdatePhoneMessage(PhoneMessage phoneMessage);

        /// <summary>
        /// ɾ��PhoneMessageOperation
        /// </summary>
        //int DeletePhoneMessageOperationByPhoneMessageID(int phoneMessageID);

        /// <summary>
        /// Ϊ����ɾ������
        /// </summary>
        int DeleteMessageByPKID(int pkid);

        /// <summary>
        /// 
        /// </summary>
        List<PhoneMessage> GetPhoneMessageByCondition(int assessorID, PhoneMessageStatus status);
        
    }
}