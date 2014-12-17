//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ISmsServiceContract.cs
// ������: �ߺ�
// ��������: 2008-11-21
// ����: ������ṩ�ķ���
// ----------------------------------------------------------------
using System.ServiceModel;

namespace SmsDataContract
{
    [ServiceContract]
    public interface ISmsServiceContract
    {
        /// <summary>
        /// Ͷ��һ����Ϣ���ȴ�����
        /// </summary>
        /// <param name="aMessage"></param>
        [OperationContract(IsOneWay=true)]
        void SendOneMessage(SendMessageDataModel aMessage);

        /// <summary>
        /// ע��ͻ���
        /// </summary>
        /// <param name="clientListenAddress">�ͻ��˼�����ַ</param>
        /// <param name="clientId">Hrmis��ʶ</param>
        /// <returns>�ظ���Ϣ�ֳ�����3�֣�
        ///         1��"Pass" ֤���ͻ���ͨ������֤
        ///         2��"Deny" �ͻ�����δ��֤�ģ��ȣ�û��ע����Ϣ��ü�¼���Ƿ���֤�ֶα�Ϊfalse
        ///         3��"Failed" �ͻ���ͨ������֤�����ǿ��ŵĶ˿��޷�����</returns>
        [OperationContract]
        void RegisterSmsClient(string clientListenAddress,string clientId);

        /// <summary>
        /// ע���ͻ��˷���
        /// </summary>
        /// <param name="clientListenAddrss">�ͻ��˼�����ַ</param>
        /// <param name="clientId">Hrmis��ʶ</param>
        [OperationContract(IsOneWay = true)]
        void UnRegisterSmsClient(string clientListenAddrss,string clientId);
    }
}