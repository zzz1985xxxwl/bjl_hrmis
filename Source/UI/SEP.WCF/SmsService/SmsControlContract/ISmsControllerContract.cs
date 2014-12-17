//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ISmsControllerContract.cs
// ������: �ߺ�
// ��������: 2008-11-21
// ����: ������ṩ�Ŀ��ƹ���
// ----------------------------------------------------------------
using System.Collections.Generic;
using System.ServiceModel;
using SmsControlContract.ClientAddressModels;
using SmsDataContract;

namespace SmsControlContract
{
    [ServiceContract]
    public interface ISmsControllerContract
    {
        /// <summary>
        /// Ͷ�ݶ���(���뵽���Ͷ���)
        /// </summary>
        [OperationContract]
        void DelieveAMessage(SendMessageDataModel aMessage);

        //--------------------------------------
        //  ��������
        //--------------------------------------

        /// <summary>
        /// ����״̬
        /// </summary>
        [OperationContract]
        bool GetPortStatus();
        /// <summary>
        /// �򿪴���
        /// </summary>
        [OperationContract]
        void StartConnection();
        /// <summary>
        /// ֹͣ����
        /// </summary>
        [OperationContract]
        void StopConnection();

        //--------------------------------------
        //  ��������
        //--------------------------------------

        /// <summary>
        /// �����շ��߳�״̬
        /// </summary>
        [OperationContract]
        bool GetWorkThreadStatus();
        /// <summary>
        /// ���շ������߳�
        /// </summary>
        [OperationContract]
        void StartTheSmsThread();
        /// <summary>
        /// �ر��շ������߳�
        /// </summary>
        [OperationContract]
        void StopTheSmsThread();
        /// <summary>
        /// �㲥��Ϣ״̬
        /// </summary>
        [OperationContract]
        bool GetTheBoardStatus();
        /// <summary>
        /// �����Ƿ�Ҫ��ʼ�㲥��Ϣ
        /// </summary>
        [OperationContract]
        void SetTheBoardStatus(bool status);
        /// <summary>
        /// ���Ի����������û���ΪPDU����(�ɷ����Ķ��ŷ�ʽ)��������ֹͣ�����߳�
        /// </summary>
        [OperationContract]
        bool TestMachine();
        /// <summary>
        /// at����
        /// </summary>
        /// <param name="commandText">�����asc2��</param>
        /// <param name="waitReplayMillionSeconds">��ȡ�ȴ�ʱ�䣬���ǻ������ԣ���õȴ�5000����ʱ��</param>
        [OperationContract]
        string SendCommand(string commandText, int waitReplayMillionSeconds);

        //--------------------------------------
        //  ��������
        //--------------------------------------

        /// <summary>
        /// ͬ�����Ͷ���
        /// </summary>
        [OperationContract]
        bool SendAMessage(SendMessageDataModel aMessage);
        /// <summary>
        /// ͬ���������ж���
        /// </summary>
        [OperationContract]
        void ReceiveAllMessage();
        /// <summary>
        /// ��������ѯ����
        /// </summary>
        [OperationContract]
        void SendSearchMoneyMessage();

        //--------------------------------------
        //  ��ϢԴ��ʷ
        //--------------------------------------

        /// <summary>
        /// �յ�����Ϣ����
        /// </summary>
        [OperationContract]
        List<ReceiveMessageDataModel> GetLogsForReceiveMessages();
        /// <summary>
        /// �ȴ����͵���Ϣ����
        /// </summary>
        [OperationContract]
        List<SendMessageDataModel> GetLogsForWaitSendMessages();
        /// <summary>
        ///  ���ͳɹ�����Ϣ
        /// </summary>
        [OperationContract]
        List<SendMessageDataModel> GetLogsForSuccesssSendMessages();
        /// <summary>
        ///   ����ʧ�ܵ���Ϣ
        /// </summary>
        [OperationContract]
        List<SendMessageDataModel> GetLogsForFailedSendMessages();
        /// <summary>
        /// ɾ�����н��ܵ��Ķ��ţ�����δ���͵ģ�����
        /// </summary>
        [OperationContract]
        void ClearAllReceivedMessages();
        /// <summary>
        /// ������з��͵Ķ��ţ��������ͳɹ�/����ʧ��/�ȴ����͵Ķ��ţ�����
        /// </summary>
        [OperationContract]
        void ClearAllSendMessages();

        //--------------------------------------
        //  ע������
        //--------------------------------------

        /// <summary>
        /// ͨ��Id��ȡ�ͻ���Ϣ
        /// </summary>
        [OperationContract]
        ClientInformationModel GetClientAddressModelById(int id);
        /// <summary>
        /// ͨ���ͻ���Ϣ��ʾ��ȡ��ַ��Ϣ�б�
        /// </summary>
        [OperationContract]
        List<ListenAddressModel> GetListenAddressModelsByClientId(int clientInformationId);
        /// <summary>
        /// ��ȡ���еĿͻ���Ϣ
        /// </summary>
        [OperationContract]
        List<ClientInformationModel> GetAllClientAddressModel();
        /// <summary>
        /// ����ͻ���Ϣ��ͨ��
        /// </summary>
        [OperationContract]
        void ActiveTheClientInformation(int clientInformationId);
        /// <summary>
        /// ��տͻ���Ϣ��ͨ��
        /// </summary>
        [OperationContract]
        void DisableTheClientInformation(int clientInformationId);
        /// <summary>
        /// ���������ַ��ͨ��
        /// </summary>
        [OperationContract]
        void ActiveTheListenAddress(int clientInformationid, int listenAddressId);
        /// <summary>
        /// ��ռ�����ַ��ͨ��
        /// </summary>
        [OperationContract]
        void DisableTheListenAddress(int clientInformationid, int listenAddressId);
        /// <summary>
        /// ����һ������Ŀͻ���Ϣ
        /// </summary>
        [OperationContract]
        void AddActivedClientInformation(string hrmisId, string companyDescription);
        /// <summary>
        /// ����һ���ͻ���Ϣ
        /// </summary>
        [OperationContract]
        void DescriptClientInformation(int clientInformationId, string description);
        /// <summary>
        /// ��ϵÿһ���ͻ����쿴�ÿͻ��Ƿ���Ȼ����
        /// </summary>
        [OperationContract]
        void ClearBlockMessages();
    }
}
