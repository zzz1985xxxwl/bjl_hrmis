//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IAddressDal.cs
// ������: �ߺ�
// ��������: 2008-11-24
// ����: ������������δ�ȡ�ͻ���Ϣ�Ľӿ�
// ----------------------------------------------------------------
using System.Collections.Generic;
using SmsControlContract.ClientAddressModels;

namespace SqlServerDal.AddressDal
{
    public interface IClientInformationDal
    {
        /// <summary>
        /// ��ȡ���еĿͻ���Ϣ
        /// </summary>
        /// <returns></returns>
        List<ClientInformationModel> GetAllClientInfomationModel();
        /// <summary>
        /// ����Id��ȡ����
        /// </summary>
        ClientInformationModel GetClientInformationById(int pkid);
        /// <summary>
        /// �����µĿͻ���Ϣ
        /// </summary>
        void InsertClientInfomationModel(ClientInformationModel aClientAddressModel);
        /// <summary>
        /// �޸Ŀͻ���Ϣ
        /// </summary>
        void UpdateClientInfomationModel(ClientInformationModel theClientAddress);
    }
}