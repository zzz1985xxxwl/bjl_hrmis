//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: SmsServerServiceType.cs
// ������: �ߺ�
// ��������: 2008-11-21
// ����: ������ṩ�����ݷ���
// ----------------------------------------------------------------
using System;
using System.ServiceModel;
using MachineDll;
using ProvideSmsServerServices.Register;
using SmsDataContract;
using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices
{
    public class SmsServerServiceType:ISmsServiceContract
    {
        #region ISmsContract ��Ա

        public void SendOneMessage(SendMessageDataModel aMessage)
        {
            ObjectSource.GetMessageBox.EnqueueWaitMessage(aMessage);
        }

        public void RegisterSmsClient(string clientListenAddress, string hrmisId)
        {
            try
            {
                new RegisterClientAddressTransaction(clientListenAddress, hrmisId,
                                                     new SingleSmsClientContractImplement(),
                                                     new SqlServerImplClientInformation()).Excute();
            }
            catch(ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void UnRegisterSmsClient(string clientListenAddrss, string clientId)
        {
            //todo nh ע���ͻ���
        }

        #endregion
    }
}