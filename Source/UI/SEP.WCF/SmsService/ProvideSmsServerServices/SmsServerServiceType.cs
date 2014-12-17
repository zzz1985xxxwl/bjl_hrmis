//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SmsServerServiceType.cs
// 创建者: 倪豪
// 创建日期: 2008-11-21
// 概述: 服务端提供的数据服务
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
        #region ISmsContract 成员

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
            //todo nh 注销客户端
        }

        #endregion
    }
}